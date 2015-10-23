using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleRest.Api;

namespace SimpleRest {
    public class SimpleRestClient : ISimpleRestClient {
        public SimpleRestClient() {
            this.Headers = new Dictionary<string, string>();
        }
        public HttpResponseFormat ResponseFormat { get; set; } = HttpResponseFormat.Json;
        public string BaseUrl { get; set; }
        public Dictionary<string, string> Headers { get; set; }

        public async Task<ISimpleResponse<T>> SendMessageAsync<T>(ISimpleMessage restMessageToSend) {
            return await MessageSender.SendMessage<T>(client: this, message: restMessageToSend);
        }
    }
}
