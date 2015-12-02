using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRest {
    /// <summary>
    /// Allows you to send Requests/Responses to/from a Restful API
    /// BaseUrl: e.g. "https://restapisample/send/v1.0/jsonsdk"
    /// Headers: e.g. SimpleRestClient.Headers["apikey"] = "abc123"
    /// GlobalRequestParameters: e.g. SimpleRestClient.GlobalMessageParameters["sessiontoken"] = "1a2b3d4e5f6g"
    /// </summary>
    public interface ISimpleRestClient {
        /// <summary>
        ///  Desired message response type
        /// e.g. SimpleRestClient.ResponseFormat = HttpResponseFormat.Xml
        /// Default is HttpResponseFormat.Json
        /// </summary>
        HttpResponseFormat ResponseFormat { get; set; }
        /// <summary>
        /// Base Restful API URL
        /// Each message will be sent to {BaseUrl}/{ISimpleMessage.EndPointPath}
        /// e.g. "https://restapisample/send/v1.0/jsonsdk"
        /// </summary>
        string BaseUrl { get; set; }
        Dictionary<string, string> Headers { get; set; }
        Dictionary<string, string> GlobalMessageParameters { get; set; }
        Task<ISimpleResponse<T>> SendMessageAsync<T>(ISimpleMessage simpleMessage);
    }
}
