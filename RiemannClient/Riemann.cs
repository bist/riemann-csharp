using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using ProtoBuf;
using System.Threading.Tasks;

namespace RiemannClient
{
    public class Riemann
    {
        private string host;
        private int port;
        ProtocolType protocol;

        /// <summary>
        /// Constructor for client 
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="protocol"></param>
        public Riemann(string host="localhost", int port=5555,ProtocolType protocol=ProtocolType.Udp)
        {
            this.host = host;
            this.port = port;
            this.protocol = protocol;
        }

        /// <summary>
        /// prepares data array to be sent and trigger sending event.
        /// </summary>
        /// <param name="data">EventData to be sent to Riemann</param>
        public void sendEvents(List<EventData> dataList)
        {
            
            foreach (EventData data in dataList)
            {
                sendEvent(data);
            }
        }

        /// <summary>
        /// sends multiple events to Riemann via single connection
        /// </summary>
        /// <param name="dataList">event list that contains data to be sent to Riemann.</param>
        public void sendMultipleEvents(List<EventData> dataList)
        {
            List<byte[]> raw = new List<byte[]>();
            foreach (EventData data in dataList) 
            {
                var message = new RiemannClient.Msg();
                var e = new RiemannClient.Event
                {
                    time = data.time,
                    host = data.host,
                    service = data.service,
                    state = data.state,
                    description = data.description,
                    metric_d = data.metric_d,
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

                raw.Add(array);
                
            }
            


            if (this.protocol == ProtocolType.Tcp)
            {
                sendMultipleViaTCP(raw);
            }
            else if (this.protocol == ProtocolType.Udp)
            {
                sendMultipleViaUDP(raw);
            }

        }


        /// <summary>
        /// sends protobuf encoded multiple data to server using udp connection.
        /// </summary>
        /// <param name="dataList">protobuf encoded data list to be sent.</param>
        private void sendMultipleViaUDP(List<byte[]> dataList)
        {
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.Connect(this.host, this.port);
            foreach (byte[] data in dataList)
            {

                socket.Send(data);
         
            }

            socket.Close();
        }

        /// <summary>
        /// sends protobuf encoded multiple data to server using tcp connection.
        /// </summary>
        /// <param name="dataList">protobuf encoded data list to be sent.</param>
        private void sendMultipleViaTCP(List<byte[]> dataList)
        {
            try
            {
                TcpClient client = new TcpClient(this.host, this.port);
                NetworkStream ns = client.GetStream();
                foreach (byte[] data in dataList)
                {

                    var x = BitConverter.GetBytes(data.Length);
                    Array.Reverse(x);
                    ns.Write(x, 0, 4);
                    ns.Write(data, 0, data.Length);
                }
                

                ns.Close();

                client.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        /// <summary>
        /// prepares data to be sent and trigger sending event.
        /// </summary>
        /// <param name="data">EventData to be sent to Riemann</param>
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
                metric_d = data.metric_d,
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
       
        }

        /// <summary>
        /// chooses data delivery channel according to protocol 
        /// </summary>
        /// <param name="data">protobuf encoded data to be sent.</param>
        private void deliverEvent(byte[] data)
        {
            if (this.protocol == ProtocolType.Tcp)
            {
                deliverViaTCP(data);
            }
            else if (this.protocol == ProtocolType.Udp)
            {
                deliverViaUDP(data);
            }
            else
            {
                throw new NotImplementedException("Other than tcp or udp connections are not supported.");
            }
        }


        /// <summary>
        /// sends protobuf encoded data to server using udp connection.
        /// </summary>
        /// <param name="data">protobuf encoded data to be sent.</param>
        private void deliverViaUDP(byte[] data)
        {
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.Connect(this.host, this.port);
            socket.Send(data);
            socket.Close();
        }

        /// <summary>
        /// sends protobuf encoded data to server using tcp connection.
        /// </summary>
        /// <param name="data">protobuf encoded data to be sent.</param>
        private void deliverViaTCP(byte[] data)
        {
            try
            {
                TcpClient client = new TcpClient(this.host, this.port);
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
