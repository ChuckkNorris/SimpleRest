using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRest {
    public interface ISimpleMessage {
        HttpMethod HttpMethod { get; set; }
        HttpMessageType MessageType { get; set; }
        Dictionary<string, string> Parameters { get; set; }
        string EndPointPath { get; set; }
    }
}
