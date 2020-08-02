using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Clients
{
    /// <summary>
    /// Client class to connect to the server
    /// </summary>
    public class Client : Network.NetworkClass
    {
        private bool _writinMode = false;
        private bool _listeningMode = false;

        private event SendMessageEvent Notify;

        private TcpClient _client = new TcpClient();
        private IPAddress _address;
        private NetworkStream _ns;
        private Thread thread;

        public delegate string SendMessageEvent(string message);

        public List<string> ClientHistory { get; private set; }
            = new List<string>();

        public ObservableCollection<string> ServerHistory { get; private set; }
            = new ObservableCollection<string>();

        public List<string> AlternateTextServerHistory { get; private set; }
            = new List<string>();

        /// <summary>
        /// Listen for messages from the server
        /// </summary>
        /// <param name="client"></param>
        private void ReceiveData(TcpClient client)
        {
            _ns = client.GetStream();
            byte[] receivedBytes = new byte[1024];
            int byte_count;
            try
            {
                while ((byte_count = _ns.Read(receivedBytes, 0, receivedBytes.Length)) > 0)
                {
                    string message = Encoding.UTF8.GetString(receivedBytes, 0, byte_count);
                    ServerHistory.Add(message);
                    AlternateTextServerHistory.Add(Notify?.Invoke(message));
                }
            }
            catch { }
        }

        /// <summary>
        /// Client constructor for class Client
        /// </summary>
        /// <param name="ip">Ip address of the server to connect to</param>
        /// <param name="port">Port of the server to connect to</param>
        public Client(string ip, int port) : base(ip, port)
        {
            _address = IPAddress.Parse(ip);
            thread = new Thread(o => ReceiveData((TcpClient)o));
        }

        /// <summary>
        /// Subscribe to an event when receiving a message from the server
        /// </summary>
        /// <param name="function">Delegate for the event</param>
        public void Subscribe(SendMessageEvent function) =>
            Notify += function;

        /// <summary>
        /// Usubscribe to an event when receiving a message from the server
        /// </summary>
        /// <param name="function">Delegate for the event</param>
        public void Unsubscribe(SendMessageEvent function) =>
            Notify -= function;

        /// <summary>
        /// Send message to server
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool SendMessage(string message)
        {
            try
            {
                ClientHistory.Add(message);
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                if (!(_ns is null)) _ns.Write(buffer, 0, buffer.Length);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Coneecting to server
        /// </summary>
        public void Connect()
        {
            _client.Connect(_address, Port);
            _ns = _client.GetStream();
        }

        /// <summary>
        /// Client can receive messages from server
        /// </summary>
        public void ListeningMode()
        {
            thread.Start(_client);
        }

        /// <summary>
        /// Client can write messages to server
        /// </summary>
        public void WritingMode()
        {
            _writinMode = true;
            string s;
            while (!string.IsNullOrEmpty((s = Console.ReadLine())))
            {
                SendMessage(s);
            }

            _ns.Close();
            _client.Close();
            thread.Join();
            Console.WriteLine("disconnect from server!!");
            Console.ReadKey();
        }

        /// <summary>
        /// Start chat mode. The client can send messages to the server and receive a response
        /// </summary>
        public void ChatMode()
        {
            ServerHistory.CollectionChanged +=
                  (sender, e) =>
                  {
                      if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                          Console.WriteLine(ServerHistory.LastOrDefault());
                  };

            if (!_listeningMode) ListeningMode();
            if (!_writinMode) WritingMode();
        }

        /// <summary>
        /// Disconect from server
        /// </summary>
        public void Disconect()
        {
            if (thread.IsAlive) thread.Join();
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj is null)
                throw new ArgumentNullException(nameof(obj));

            return obj is Client client &&
                   Ip == client.Ip &&
                   Port == client.Port;
        }

        // override object.GetHashCode
        public override int GetHashCode()
            => HashCode.Combine(base.GetHashCode(), Ip, Port);
    }
}