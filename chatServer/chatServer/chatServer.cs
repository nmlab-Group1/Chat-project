
using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace chatServer
{
    class chatServer
    {
        List<chatSocket> clientList = new List<chatSocket>();
        List<String> clientIDList = new List<string>();
        
        public static void Main(String[] args)
        {
            chatServer server = new chatServer();
            server.run();
        }

        public void run()
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, setting.port);
            Socket newSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            newSocket.Bind(ipep);
            newSocket.Listen(10);

            while (true)
            {
                Socket socket = newSocket.Accept();
                Console.WriteLine("-- WAITING FOR CONNECTIONS --\n");
                chatSocket client = new chatSocket(socket);

                try
                {
                    clientList.Add(client);
                    client.newListener(processMessage);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public String processMessage(String msg)
        {
            Console.WriteLine("RECEIVED：" + msg);
            char[] del = { ':' };
            String[] words = msg.Split(del);
            /*
            if (msg.IndexOf("sendPic:") == 0)
            {
                char[] del = { ':' };
                String[] words = msg.Split(del);
                Console.WriteLine("picture coming in\n");
                broadCast(msg);
                
                int index = clientIDList.IndexOf(words[1]);
                int length = Convert.ToInt32(words[2]);
                Byte[] buffer = new Byte[length];

                receiveFile(clientList[index], buffer);
                
                File.WriteAllBytes("tempFile", buffer);
                
                broadCastfile(buffer);

                return "";
            }*/
            String nameAndTime = msg.Substring(0, msg.IndexOf(':') - 1) + " ─ " + DateTime.Now.ToLongTimeString();
            String message = msg.Substring(msg.IndexOf(':') + 2);
            broadCast(nameAndTime + "\n    " + message);
            return "";
        }

        public void broadCast(String msg)
        {
            Console.WriteLine("BROADCAST：\"" + msg + "\" to " + clientList.Count + " people");
            foreach (chatSocket client in clientList)
            {
                if (client.active)
                {
                    Console.WriteLine("  Send to " + client.remoteEndPoint.ToString());
                    client.sendMessage(msg);
                }
            }
            Console.WriteLine("");
        }

        public void receiveFile(chatSocket client, Byte[] buffer)
        {
            int received = 0;
            while(received < buffer.Length)
                received += client.socket.Receive(buffer, received, buffer.Length - received, System.Net.Sockets.SocketFlags.None);
        }

        public void broadCastfile(Byte[] buffer)
        {
            foreach (chatSocket client in clientList)
            {
                int sent = 0;
                while (sent < buffer.Length)
                    sent += client.socket.Send(buffer, sent, buffer.Length - sent, System.Net.Sockets.SocketFlags.None);
            }
        }
    }
}
