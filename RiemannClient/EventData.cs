using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RiemannClient
{
    public class EventData
    {

        public String[] tags { get; set; }
        public long time { get; set; }
        public String host { get; set; }
        public String service { get; set; }
        public String state { get; set; }
        public String description { get; set; }
        public double metric_d { get; set; }
        public float ttl { get; set; }

        public EventData(long time, string host, string service, string state, string description, double metric_d, float ttl = 300, string[] tags=null)
        {
            this.tags = tags;
            this.time = time;
            this.host = host;
            this.service = service;
            this.state = state;
            this.description = description;
            this.metric_d = metric_d;
            this.ttl = ttl;
        }

    }
}
