using System.Net.Sockets;

using Servers.Log;

namespace Servers
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Logger logger = new Logger();
            Server ser = new Server("127.0.0.1", 5000);

            ser.Subscribe(delegate (TcpClient client, string message)
            {
                logger.Add(client, message);
            });

            ser.Start();
            ser.ChatMode();
            ser.Stop();
        }
    }
}