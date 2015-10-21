using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRest {
    public  class SimpleMessage : ISimpleMessage {
        public SimpleMessage() {
            this.Parameters = new Dictionary<string, string>();
        }
        public HttpMethod HttpMethod { get; set; }
        public HttpMessageType MessageType { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
        public string EndPointPath { get; set; }
    }
}
