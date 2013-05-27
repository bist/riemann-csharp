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
    class Program
    {
        static void Main(string[] args)
        {

            Riemann cli = new Riemann("10.40.8.11",5555,ProtocolType.Tcp);
            while (true)
            {
                Console.WriteLine("hellö");
                try
                {
                    String[] tags = new string[]{"top10","top5"};
                    long time = 9988;
                    String host = "host";
                    String service = "servis";
                    String state = "durum";
                    String description = "açıklama";
                    float metric_f = 15;
                    float ttl = 300;

                    EventData data = new EventData(tags, time, host, service, state, description, metric_f, ttl);
                    cli.sendEvent(data);
               
                }
                catch (Exception e) {
                    Console.WriteLine(e.Message);
                }

            }

            

        }
        
    }
    
}
