using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRest {
    public  class SimpleMessage : ISimpleMessage {
       
        /// <summary>
        /// Constructs a message to be sent by the SimpleRestClient
        /// Parameters: e.g. SimpleMessage.Parameters["searchTerm"] = "Denver"
        /// </summary>
        public SimpleMessage() {
            this.Parameters = new Dictionary<string, string>();
        }
       
        /// <summary>
        /// Method used to send the HTTP Message
        /// e.g. HttpMethod = HttpMethod.{Get/Post}
        /// </summary>
        public HttpMethod HttpMethod { get; set; }
       
        /// <summary>
        /// Type of message
        /// e.g. HttpMessageType.{Request/Response}
        /// </summary>
        public HttpMessageType MessageType { get; set; }
     
        /// <summary>
        /// The parameters to be send in the request
        /// e.g. SimpleMessage["searchTerm"] = "Denver"
        /// </summary>
        public Dictionary<string, string> Parameters { get; set; }
     
        /// <summary>
        /// The path to the specific API End Point
        /// e.g. "account/login"
        /// </summary>
        public string EndPointPath { get; set; }
    }
}
