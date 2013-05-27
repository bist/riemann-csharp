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

        public Riemann(string host="localhost", int port=5555,ProtocolType protocol=ProtocolType.Tcp)
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



        private void deliverViaUDP(byte[] array)
        {
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.Connect(this.host, this.port);
            socket.Send(array);
        }

        private void deliverViaTCP(byte[] array)
        {
            try
            {
                var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(this.host, this.port); 
                NetworkStream ns = new NetworkStream(socket, true);
                
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            /*
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); 
            socket.Connect(this.host, this.port);
            socket.Send(array);
            NetworkStream ns = new NetworkStream(socket, true);
            ns.Write(array, 0, array.Length);
           */

        }

    }
}
