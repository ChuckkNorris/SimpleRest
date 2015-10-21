using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Web.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRest.Api {
    internal class MessageSender {
        public static async Task<ISimpleResponse<T>> SendMessage<T>(ISimpleRestClient rest, ISimpleMessage message) {
            T messageTypeToReturn = Activator.CreateInstance<T>();
            ISimpleResponse<T> toReturn = new SimpleResponse<T>();
            
            HttpClient restClient = new HttpClient();
            Windows.Web.Http.HttpMethod method = message.HttpMethod == HttpMethod.Get ? Windows.Web.Http.HttpMethod.Get : Windows.Web.Http.HttpMethod.Post;
            string fixedBaseUrl = rest.BaseUrl.TrimEnd('/') + "/";
            string fixedEndPoint = message.EndPointPath.TrimStart('/');
            HttpRequestMessage requestMessage = new HttpRequestMessage(method, new Uri(fixedBaseUrl + fixedEndPoint));
            foreach (var header in rest.Headers) {
                requestMessage.Headers.Add(header.Key, header.Value);
            }

            string mediaType = rest.ResponseType == HttpResponseFormat.Json ? "application/json" : "application/xml";
            object serializedObject = new { a = "" };
            string content = Newtonsoft.Json.JsonConvert.SerializeObject(message.Parameters);

            // requestMessage.Content = new HttpStringContent(content, Windows.Storage.Streams.UnicodeEncoding.Utf8, mediaType);
            HttpResponseMessage response = await restClient.SendRequestAsync(requestMessage);
            toReturn.DataRaw = response.Content;
            

            return toReturn;
        }
    }
}
