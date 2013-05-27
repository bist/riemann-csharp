using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Riemann
{
    class EventData
    {

        public String[] tags { get; set; }
        public long time { get; set; }
        public String host { get; set; }
        public String service { get; set; }
        public String state { get; set; }
        public String description { get; set; }
        public float metric_f { get; set; }
        public float ttl { get; set; }

        public EventData(string[] tags , long time, string host, string service, string state, string description, float metric_f, float ttl)
        {
            this.tags = tags;
            this.time = time;
            this.host = host;
            this.service = service;
            this.state = state;
            this.description = description;
            this.metric_f = metric_f;
            this.ttl = ttl;
        }

    }
}
