using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using ProtoBuf;

namespace Riemann
{
    class Riemann
    {
        private string host;
        private int port;
        ProtocolType protocol;

        public Riemann(string host="localhost", int port=5555,ProtocolType protocol=ProtocolType.Udp)
        {
            this.host = host;
            this.port = port;
            this.protocol = protocol;
        }

        public void sendEvent(EventData data)
        {
            
            var message = new RiemannClient.Msg();
            var e = new RiemannClient.Event
            {
                time =data.time,
                host = data.host,
                service = data.service,
                state = data.state,
                description = data.description,
                metric_f = data.metric_f,
                ttl = data.ttl
            };

            if (data.tags != null)
            {
                foreach (string tag in data.tags)
                {
                    e.tags.Add(tag);
                }
            }

            message.events.Add(e);

            var memoryStream = new MemoryStream();
            Serializer.Serialize(memoryStream, message);
            var array = memoryStream.ToArray();

            
            deliverEvent(array);
            
            Thread.Sleep(1000);

        }

        private void deliverEvent(byte[] array)
        {
            if (this.protocol == ProtocolType.Tcp)
            {
                deliverViaTCP(array);
            }
            else if (this.protocol == ProtocolType.Udp)
            {
                deliverViaUDP(array);
            }
            else
            {
                throw new NotImplementedException("Other than tcp or udp connections are not supported.");
            }
        }



        private void deliverViaUDP(byte[] data)
        {
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.Connect(this.host, this.port);
            socket.Send(data);
            socket.Close();
        }

        private void deliverViaTCP(byte[] data)
        {
            try
            {
                TcpClient client = new TcpClient(this.host, 5555);
                NetworkStream ns = client.GetStream();
                
                var x = BitConverter.GetBytes(data.Length); 
                Array.Reverse(x);
                ns.Write(x, 0, 4);
                ns.Write(data, 0, data.Length);
                
                ns.Close();

                client.Close();
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
        }

    }
}
