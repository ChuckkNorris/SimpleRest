using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Web.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRest.Api {
    internal class MessageSender {
        public static async Task<ISimpleResponse<T>> SendMessage<T>(ISimpleRestClient client, ISimpleMessage message) {
            T messageTypeToReturn = Activator.CreateInstance<T>();
            ISimpleResponse<T> toReturn = new SimpleResponse<T>();
            
            HttpClient restClient = new HttpClient();
            Windows.Web.Http.HttpMethod method = message.HttpMethod == HttpMethod.Get ? Windows.Web.Http.HttpMethod.Get : Windows.Web.Http.HttpMethod.Post;
            Uri uriWithQueryString = await MessageHelper.BuildUri(client, message);
            HttpRequestMessage requestMessage = new HttpRequestMessage(method, uriWithQueryString);
            foreach (var header in client.Headers) {
                requestMessage.Headers.Add(header.Key, header.Value);
            }

            string mediaType = client.ResponseFormat == HttpResponseFormat.Json ? "application/json" : "application/xml";
            object serializedObject = new { a = "" };
            string content = Newtonsoft.Json.JsonConvert.SerializeObject(message.Parameters);

            // requestMessage.Content = new HttpStringContent(content, Windows.Storage.Streams.UnicodeEncoding.Utf8, mediaType);
            HttpResponseMessage response = await restClient.SendRequestAsync(requestMessage);
            toReturn.DataRaw = response.Content;
            

            return toReturn;
        }
    }
}
