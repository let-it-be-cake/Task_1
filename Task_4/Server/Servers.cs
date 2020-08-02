using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Servers
{
    public class Server : Network.NetworkClass
    {
        private Thread _clientMessage;
        private Thread _clientWait;

        public delegate void GetMessage(TcpClient client, string message);

        private event GetMessage Notify;

        private int _clientCount = 1;
        private List<TcpClient> _clients = new List<TcpClient>();
        public TcpListener ServerSocket { get; private set; }

        /// <summary>
        /// Send a message to all clients
        /// </summary>
        /// <param name="message">Message in UTF 8 encoded bytes array to send</param>
        private void SendToAll(byte[] message)
        {
            foreach (var client in _clients)
            {
                var ns = client.GetStream();
                ns.Write(message, 0, message.Length);
            }
        }

        /// <summary>
        /// Send a message to all clients
        /// </summary>
        /// <param name="message">Message to send</param>
        private void SendToAll(string message)
            => SendToAll(Encoding.UTF8.GetBytes(message));

        /// <summary>
        /// Server constructor for class Server
        /// </summary>
        /// <param name="ip">Ip address of the server</param>
        /// <param name="port">Port of the server</param>
        public Server(string ip, int port) : base(ip, port)
        {
            IPAddress address = IPAddress.Parse(ip);
            ServerSocket = new TcpListener(address, port);
        }

        /// <summary>
        /// Subscribe to an event when receiving a message from the client
        /// </summary>
        /// <param name="function">Delegate for the event</param>
        public void Subscribe(GetMessage message)
            => Notify += message;
        /// <summary>
        /// Unsubscribe to an event when receiving a message from the client
        /// </summary>
        /// <param name="function">Delegate for the event</param>
        public void Unsubscribe(GetMessage message)
            => Notify -= message;

        /// <summary>
        /// Send message to all clients
        /// </summary>
        /// <param name="message">Message sent to clients</param>
        public void MessageToClients(string message) =>
            SendToAll(message);


        /// <summary>
        /// Start chat mode. The server can send messages to the client and receive a response
        /// </summary>
        public void ChatMode()
        {
            string s;
            while (!string.IsNullOrEmpty((s = Console.ReadLine())))
            {
                byte[] buffer = Encoding.UTF8.GetBytes(s + "\n");
                SendToAll(buffer);
            }
        }

        /// <summary>
        /// Server startup
        /// </summary>
        public void Start()
        {
            #region Methods

            void ClientWait()
            {
                while (true)
                {
                    //Waiting client
                    TcpClient client = ServerSocket.AcceptTcpClient();
                    _clients.Add(client);
                    _clientCount++;

                    _clientMessage = new Thread(ClientMessage);
                    _clientMessage.Start(client);
                }
            }

            void ClientMessage(object o)
            {
                TcpClient client = (TcpClient)o;

                NetworkStream stream = client.GetStream();

                while (true)
                {
                    byte[] buffer = new byte[1024];
                    int byteCount = 0;
                    //exception warning
                    try
                    {
                        byteCount = stream.Read(buffer, 0, buffer.Length);
                        if (byteCount == 0) throw new System.IO.IOException();
                    }
                    catch (System.IO.IOException)
                    {
                        _clientCount--;
                        _clients.Remove(client);
                        break;
                    }
                    byte[] formated = new Byte[byteCount];
                    //handle  the null characteres in the byte array
                    Array.Copy(buffer, formated, byteCount);
                    string data = Encoding.UTF8.GetString(formated);
                    //Broadcast(data);
                    //event
                    Notify?.Invoke(client, data);
                    Console.WriteLine(data);
                }
            }

            #endregion Methods

            ServerSocket.Start();
            _clientWait = new Thread(ClientWait);
            _clientWait.Start();
        }

        /// <summary>
        /// Server stopping
        /// </summary>
        public void Stop()
        {
            try
            {
                if (!(_clientMessage is null))_clientMessage.Join();
            }
            catch { }
            try
            {
                if (!(_clientWait is null)) _clientWait.Join();
            }
            catch { }
            ServerSocket.Stop();
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj is null)
                throw new ArgumentNullException(nameof(obj));

            return obj is Server client &&
                   Ip == client.Ip &&
                   Port == client.Port;
        }

        // override object.GetHashCode
        public override int GetHashCode()
            => HashCode.Combine(base.GetHashCode(), Ip, Port);
    }
}