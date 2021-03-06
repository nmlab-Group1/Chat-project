﻿
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
        List<chatRoom> roomList = new List<chatRoom>();
        List<chatSocket> clientList = new List<chatSocket>();

        int IDcounter;
        int roomIDcounter;
        chatRoom lobby;
        
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

            IDcounter = 0;
            roomIDcounter = 0;

            lobby = new chatRoom(roomIDcounter++, "Lobby");
            roomList.Add(lobby);

            while (true)
            {
                Socket socket = newSocket.Accept();
                chatSocket client = new chatSocket(socket);

                try
                {
                    clientList.Add(client);
                    lobby.clientList.Add(client);
                    client.newListener(processMessage);
                    client.ID = IDcounter;
                    Console.WriteLine("New user with ID: " + IDcounter);
                    client.sendMessage("REGNEWUSER:" + IDcounter);
                    IDcounter++;
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

            // super large if/else
            if (words[0].Equals("AVAILABLEID"))
            {// AVAILABLEID:senderID:sID
                bool found = false;
                foreach (chatSocket client in clientList)
                {
                    if (String.IsNullOrEmpty(client.sID))
                    {
                        continue;
                    }

                    if (client.sID.Equals(words[2]))
                    {
                        found = true;
                        break;
                    }
                }

                if (found)
                {
                    messageToPerson(Convert.ToInt32(words[1]), "AVAILABLEID:USED");
                }
                else
                {
                    messageToPerson(Convert.ToInt32(words[1]), "AVAILABLEID:USABLE");
                }
            }

            else if (words[0].Equals("MESSAGE"))
            {// MESSAGE:roomID:senderID:color:message
                chatSocket client = clientNo(Convert.ToInt32(words[2]));
                msg = "MESSAGE:" + words[1] + ":" + client.sID + ":" + words[3] + ":" + words[4];
                messageToRoom(Convert.ToInt32(words[1]), msg);
            }

            else if (words[0].Equals("IDPHOTO"))
            {// IDPHOTO:senderID:fileLength
                int fileLength = Convert.ToInt32(words[2]);
                Byte[] buffer = new Byte[fileLength];

                int ID = Convert.ToInt32(words[1]);
                fileFromPerson(clientNo(ID), buffer);

                messageToEveryone(msg);
                fileToEveryone(buffer);
            }

            else if (words[0].Equals("FILE"))
            {// FILE:senderID:receiverID:fileLength:fileName
                int fileLength = Convert.ToInt32(words[3]);
                Byte[] buffer = new Byte[fileLength];

                int senderID = Convert.ToInt32(words[1]);
                fileFromPerson(clientNo(senderID), buffer);

                int receiverID = Convert.ToInt32(words[2]);
                msg = words[0] + ':' + words[1] + ':' + words[3] + ':' + words[4];
                messageToPerson(receiverID, msg);
                fileToPerson(clientNo(receiverID), buffer);
            }

            else if (words[0].Equals("SEARCHID"))
            {// SEARCHID:senderID:ID
                List<String> IDList = new List<string>();
                foreach (chatSocket client in clientList)
                {
                    if (client.active)
                    {
                        if (client.sID.IndexOf(words[2]) > 0)
                        {
                            IDList.Add(client.sID);
                        }
                    }
                }
                int senderID = Convert.ToInt32(words[1]);
                msg = "SEARCHLISTUPDATE";
                foreach (String ID in IDList)
                {
                    msg += ':' + ID;
                }
                messageToPerson(senderID, msg);
            }

            else if (words[0].Equals("SECRETMESSAGE"))
            {// SECRETMESSAGE:senderID:receiverID:message
                chatSocket client = clientNo(Convert.ToInt32(words[2]));
                msg = words[0] + ':' + client.sID + ':' + words[3];
                messageToPerson(Convert.ToInt32(words[2]), msg);
            }

            else if (words[0].Equals("PIC"))
            {// PIC:roomID:senderID:index
                chatSocket client = clientNo(Convert.ToInt32(words[2]));
                msg = words[0] + ":" + words[1] + ":" + client.sID + ":" + words[3];
                messageToRoom(Convert.ToInt32(words[1]), msg);
            }

            else if (words[0].Equals("WELCOME"))
            {// WELCOME:senderID:sID
                int thisID = Convert.ToInt32(words[1]);
                chatSocket client = clientNo(thisID);
                client.sID = words[2];

                msg += ":" + Convert.ToInt32(clientList.Count);
                foreach (chatSocket person in clientList)
                {
                    msg += ":" + Convert.ToInt32(person.ID) + ":" + person.sID;
                }
                messageToRoom(lobby.ID, msg);
            }

            else if (words[0].Equals("NEWROOM"))
            {// NEWROOM:senderID:invitedID
                chatRoom newRoom = new chatRoom(roomIDcounter, "");
                chatSocket sendClient = clientNo(Convert.ToInt32(words[1]));
                chatSocket invitedClient = clientNo(Convert.ToInt32(words[2]));
                newRoom.clientList.Add(sendClient);
                newRoom.clientList.Add(invitedClient);
                roomList.Add(newRoom);

                msg = "NEWROOM:" + roomIDcounter.ToString() + ":";
                messageToPerson(sendClient.ID, msg + invitedClient.sID);
                messageToPerson(invitedClient.ID, msg + sendClient.sID);
                roomIDcounter++;
            }

            else if (words[0].Equals("INVITE"))
            {// INVITE:senderID:invitedID:roomID
                foreach (chatRoom room in roomList)
                {
                    if (room.ID == Convert.ToInt32(words[3]))
                    {
                        room.clientList.Add(clientNo(Convert.ToInt32(words[2])));
                        msg = "INVITE:" + clientNo(Convert.ToInt32(words[1])).sID + ":" + words[3];
                        messageToPerson(Convert.ToInt32(words[2]), msg);
                        break;
                    }
                }
            }

            else if (words[0].Equals("SHUTDOWN"))
            {
                foreach (chatSocket clnt in clientList)
                {
                    if (clnt.sID.Equals(words[1]))
                    {
                        clientList.Remove(clnt);
                        break;
                    }
                }
            }

            else if (words[0].Equals("CALL"))
            {// CHAT:ID1:ID2:sID1
                chatSocket client1 = clientNo(Convert.ToInt32(words[1]));
                chatSocket client2 = clientNo(Convert.ToInt32(words[2]));
                String IP1 = client1.socket.RemoteEndPoint.ToString();
                String IP2 = client2.socket.RemoteEndPoint.ToString();
                IP1 = IP1.Substring(0, IP1.IndexOf(':'));
                IP2 = IP2.Substring(0, IP2.IndexOf(':'));
                //messageToPerson(client1.ID, "CALL:" + IP1 + ":" + IP2);
                messageToPerson(client2.ID, "CALL:" + IP2 + ":" + IP1 + ":" +client1.sID);
            }

            else
            {
                Console.WriteLine("ERROR OCCCURRED");
            }

            return "";
        }

        public chatSocket clientNo(int clientID)
        {
            foreach (chatSocket client in clientList)
            {
                if (client.ID == clientID)
                    return client;
            }
            return null;
        }

        public chatRoom roomNo(int roomID)
        {
            foreach (chatRoom room in roomList)
            {
                if (room.ID == roomID)
                    return room;
            }
            return null;
        }

        public void messageToEveryone(String msg)
        {
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

        public void messageToRoom(int roomID, String msg)
        {
            chatRoom room = roomNo(roomID);
            Console.WriteLine("Message to room" + roomID);
            foreach (chatSocket client in room.clientList)
            {
                if (client.active)
                {
                    Console.WriteLine("   Send to " + client.remoteEndPoint.ToString());
                    client.sendMessage(msg);
                }
            }
            Console.WriteLine("");
        }

        public void messageToPerson(int clientID, String msg)
        {
            chatSocket client = clientNo(clientID);
            if (client.active)
            {
                Console.WriteLine("   Send to " + client.remoteEndPoint.ToString());
                client.sendMessage(msg);
            }
            Console.WriteLine("");
        }

        public void fileFromPerson(chatSocket client, Byte[] buffer)
        {
            int received = 0;
            while(received < buffer.Length)
                received += client.socket.Receive(buffer, received, buffer.Length - received, System.Net.Sockets.SocketFlags.None);
        }

        public void fileToEveryone(Byte[] buffer)
        {
            foreach (chatSocket client in clientList)
            {
                fileToPerson(client, buffer);
            }
        }

        public void fileToRoom(int roomID, Byte[] buffer)
        {
            chatRoom room = roomNo(roomID);
            foreach (chatSocket client in room.clientList)
            {
                fileToPerson(client, buffer);
            }
        }

        public void fileToPerson(chatSocket client, Byte[] buffer)
        {
            if (client.active)
            {
                int sent = 0;
                while (sent < buffer.Length)
                    sent += client.socket.Send(buffer, sent, buffer.Length - sent, System.Net.Sockets.SocketFlags.None);
            }
        }
    }
}
