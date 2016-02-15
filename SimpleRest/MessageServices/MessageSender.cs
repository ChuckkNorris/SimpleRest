using System;
using Web = Windows.Web.Http;
using Windows.Web.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Windows.Storage.Streams;
using Windows.Web.Http.Headers;


//using System.Net.Http;

namespace SimpleRest.Api {
    internal class MessageSender {
        public static async Task<SimpleResponse<T>> SendMessage<T>(SimpleRestClient simpleClient, SimpleMessage simpleMessage) {
            SimpleResponse<T> toReturn = new SimpleResponse<T>();
            Web.HttpClient httpClient = new Web.HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new HttpMediaTypeWithQualityHeaderValue("application/json"));
            HttpRequestMessage requestMessage = await BuildHttpRequestMessage(simpleClient, simpleMessage);
           
            HttpResponseMessage response = await httpClient.SendRequestAsync(requestMessage);
            toReturn.DataRaw = response.Content;
            toReturn.DataConverted = JsonConvert.DeserializeObject<T>(response.Content.ToString());
            
          

            return toReturn;
        }

        #region Helper Methods
        private static async Task<HttpRequestMessage> BuildHttpRequestMessage(SimpleRestClient simpleClient, SimpleMessage simpleMessage) {
            HttpRequestMessage toReturn = new HttpRequestMessage();
            AddGlobalRequestParameters(simpleMessage, simpleClient.GlobalMessageParameters);
            toReturn.Method = GetWebHttpMethod(simpleMessage.HttpMethod);
            // Construct full URI {BaseUrl}/{endPointPath}?{Parameters}
            toReturn.RequestUri = await MessageHelper.BuildUri(baseUrl: simpleClient.BaseUrl, endPointPath: simpleMessage.EndPointPath, queryStringParameters: simpleMessage.Parameters);
            AddRequestHeaders(toReturn, simpleClient.Headers);

            // Set content for post/put
            if (simpleMessage.Content != null) {
                var contentToSend = JsonConvert.SerializeObject(simpleMessage.Content);
                toReturn.Content = new Web.HttpStringContent(contentToSend, UnicodeEncoding.Utf8, "application/json");
            }




            return toReturn;
        }

        private static void AddRequestHeaders(HttpRequestMessage httpRequest, Dictionary<string, string> requestHeaders) {
            // Add Headers
            foreach (var header in requestHeaders) {
                httpRequest.Headers.Add(header.Key, header.Value);
            }
        }

        private static Web.HttpMethod GetWebHttpMethod(SimpleRest.HttpMethod toSet) {
            switch (toSet) {
                case HttpMethod.Get:
                    return Web.HttpMethod.Get;
                case HttpMethod.Post:
                    return Web.HttpMethod.Post;
                case HttpMethod.Put:
                    return Web.HttpMethod.Put;
                case HttpMethod.Delete:
                    return Web.HttpMethod.Delete;
                default:
                    return Web.HttpMethod.Get;
            }
           
        }

        private static void AddGlobalRequestParameters(SimpleMessage simpleMessage, Dictionary<string,string> globalRequestParameters) {
            foreach (var globalRequestParameter in globalRequestParameters) {
                simpleMessage.Parameters[globalRequestParameter.Key] = globalRequestParameter.Value;
            }
        }

        #endregion

    }

    public class Person {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
