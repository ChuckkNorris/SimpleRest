using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleRest.Api;

namespace SimpleRest {
    /// <summary>
    /// Rest Client used for controlling response/request settings
    /// </summary>
    public class SimpleRestClient : ISimpleRestClient {
        
        /// <summary>
        /// Allows you to send Requests/Responses to/from a Restful API
        /// BaseUrl: e.g. "https://restapisample/send/v1.0/jsonsdk"
        /// Headers: e.g. SimpleRestClient.Headers["apikey"] = "abc123"
        /// GlobalRequestParameters: e.g. SimpleRestClient.GlobalMessageParameters["sessiontoken"] = "1a2b3d4e5f6g"
        /// </summary>
        public SimpleRestClient() {
            this.Headers = new Dictionary<string, string>();
            this.GlobalMessageParameters = new Dictionary<string, string>();
        }

        /// <summary>
        /// Base Restful API URL
        /// Each message will be sent to {BaseUrl}/{ISimpleMessage.EndPointPath}
        /// e.g. "https://restapisample/send/v1.0/jsonsdk"
        /// </summary>
        public string BaseUrl { get; set; }
       
        /// <summary>
        ///  Desired message response type
        /// e.g. SimpleRestClient.ResponseFormat = HttpResponseFormat.Xml
        /// Default is HttpResponseFormat.Json
        /// </summary>
        public HttpResponseFormat ResponseFormat { get; set; } = HttpResponseFormat.Json;
       
        /// <summary>
        /// The Headers to be sent with each message
        /// </summary>
        public Dictionary<string, string> Headers { get; set; }
       
        /// <summary>
        /// Parameters to be appended to each message sent
        /// </summary>
        public Dictionary<string, string> GlobalMessageParameters { get; set; }
       
        /// <summary>
        /// Sends a message to the 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="restMessageToSend"></param>
        /// <returns></returns>
        public async Task<ISimpleResponse<T>> SendMessageAsync<T>(ISimpleMessage restMessageToSend) {
            return await MessageSender.SendMessage<T>(client: this, message: restMessageToSend);
        }
    }
}
