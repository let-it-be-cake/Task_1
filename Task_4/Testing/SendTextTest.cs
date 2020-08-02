using System;
using Xunit;

using Clients;
using Clients.Translate;
using Servers;
using Servers.Log;
using System.Threading;
using System.Net.Sockets;
using System.Linq;

namespace Testing
{
    public class SendTextTest
    {
        [Theory]
        [InlineData("127.0.0.1", 5000, "Hello")]
        [InlineData("127.0.0.2", 5000, "Test")]
        [InlineData("127.0.0.3", 5000, "This test work!")]
        public void Client_send_Message_to_Server(string ip, int port, string expected)
        {

            //arrange
            //string ip = "127.0.0.1";
            //int port = 5000;

            Logger logger = new Logger();

            Server server = new Server(ip, port);

            server.Subscribe(delegate (TcpClient client, string message)
            {
                logger.Add(client, message);
            });

            server.Start();

            Client client = new Client(ip, port);
            client.Connect();
            //act

            client.SendMessage(expected);
            Thread.Sleep(100);
            var actual = logger.ClientMessages.First().Value.First();

            //assert
            Assert.Equal(expected, actual);
        }
    }
}
