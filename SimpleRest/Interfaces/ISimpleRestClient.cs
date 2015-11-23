using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRest {
    public interface ISimpleRestClient {
        HttpResponseFormat ResponseFormat { get; set; }
        string BaseUrl { get; set; }
        Dictionary<string, string> Headers { get; set; }
        Dictionary<string, string> GlobalMessageParameters { get; set; }
        Task<ISimpleResponse<T>> SendMessageAsync<T>(ISimpleMessage simpleMessage);
    }
}
