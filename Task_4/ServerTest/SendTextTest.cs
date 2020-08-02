using Clients;
using Servers;
using Servers.Log;
using System;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using Xunit;

namespace ServerTest
{
    public class SendTextTest
    {
        [Theory]
        [InlineData("127.0.0.1", 5000, "Hello")]
        [InlineData("127.0.0.2", 5000, "Test")]
        [InlineData("127.0.0.3", 5000, "This test work!")]
        public void Server_send_Message_to_Client(string ip, int port, string expected)
        {

            //arrange
            //string ip = "127.0.0.1";
            //int port = 5000;

            Logger logger = new Logger();

            Server server = new Server(ip, port);

            server.Start();

            Client client = new Client(ip, port);
            client.Connect();
            //act

            client.ListeningMode();
            server.MessageToClients(expected);
            Thread.Sleep(100);
            var actual = client.ServerHistory.First();

            //assert
            Assert.Equal(expected, actual);
        }
    }
}
