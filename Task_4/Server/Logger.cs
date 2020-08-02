using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Servers.Log
{
    public class Logger
    {
        /// <summary>
        /// Dictionary of clients messages
        /// </summary>
        public Dictionary<TcpClient, List<string>> ClientMessages { get; private set; }
            = new Dictionary<TcpClient, List<string>>();
        /// <summary>
        /// Add a new client message to the Dictionary
        /// </summary>
        /// <param name="client">Message sender</param>
        /// <param name="message">Client message</param>
        public void Add(TcpClient client, string message)
        {
            if (!ClientMessages.ContainsKey(client))
            {
                var messages = new List<string>();
                messages.Add(message);
                ClientMessages.Add(client, messages);
            }
            else
                ClientMessages[client].Add(message);
        }
    }
}
