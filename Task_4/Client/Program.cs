using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Clients.Translate;

namespace Clients
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client("127.0.0.1", 5000);
            client.Subscribe(text =>
            {
                switch (Translitor.LangDefine(text))
                {
                    case Lang.Rus:
                        return Translitor.ToEng(text);
                    case Lang.Eng:
                        return Translitor.ToRus(text);
                    default:
                        throw new ArgumentException("Wrong language!");
                }
            });

            Thread tread = new Thread(client.ChatMode);
            client.Connect();
            tread.Start();
            client.Disconect();
        }
    }
}
