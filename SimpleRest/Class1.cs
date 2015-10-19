using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRest
{
    public class SimpleRest : Headers {
        private SimpleRestSettings simpleRestSettings;
        public Headers Headers { get; set; }
        public string MyProperty { get; set; }
        public SimpleRest() {
            
        }
        public async Task<T> SendMessageAsync<T>(SimpleHttpMessage restMessageToSend) {
            T messageTypeToReturn = Activator.CreateInstance<T>();
            return messageTypeToReturn;
        }
        public SimpleRest(SimpleRestSettings simpleRestSettings) {
            this.simpleRestSettings = simpleRestSettings;
        }
        

    }

    internal interface IMessage {
    }

    public class Headers {
        // params string[] 
        public void Add([]params string[] restParameters) {

        }
    }


    public class SimpleRestSettings {
        public MessageType MessageType { get; internal set; }
        public ResponseType ResponseType { get; internal set; }
        public MessageType Type { get; internal set; }
        public string BaseUrl { get; set; }
        public Headers Headers { get; internal set; }
    }

    internal static class ParameterCleaner {
        private static Uri ConvertToUri(this string stringToConvert) {
            return new Uri(stringToConvert);
        }
    }


    public enum SimpleRestDefaultSettings {
        HttpRequestMessageXmlSettings,
        HttpResponseMessageJson
    }

    public enum MessageType {
        HttpRequestMessage
    }

    public enum ResponseType {
        Json,
        Xml
    }
    public enum HttpMethod {
        Get,
        Post
    }
    public class ExampleApiUsage {
        public async void RestCallExamples() {
            
            SimpleRestSettings requestMessageSettings = new SimpleRestSettings() {
                ResponseType = ResponseType.Json, //ResponseType.Xml
                BaseUrl = "https://sandbox.tradier.com/v1/"
            };
            requestMessageSettings.Headers.Add(
                "AppKey = a8@8j_kjd!n190jas?kpojv8!7xc896",
                "AccessToken = 123435352"
                );
            SimpleRest restClient = new SimpleRest(simpleRestSettings: requestMessageSettings);


            SimpleHttpMessage stockOrderRequest = new SimpleHttpMessage() {
                MessageType = MessageType.HttpRequestMessage, //HttpResponseMessage
                HttpMethod = HttpMethod.Post
            };
            stockOrderRequest.Parameters.Add(
                "AccountNumber = userAccountNumber",
                "TickerSymbol = MSFT",
                "Count = 42",
                "OrderType = Market",
                "Preview = true"
            );

            dynamic dynamo = new ExpandoObject() {
                Name = "tom",
                Age = "4"
            };
     

            StockOrder orderPreview = await restClient.SendMessageAsync<StockOrder>(restMessageToSend: stockOrderRequest);
            List<string> Errors = orderPreview.Errors;
            int shareCount = orderPreview.NumberOfShares;
        }
    }

    public class StockOrder {
        public List<string> Errors { get; set; }
        public int NumberOfShares { get; set; }
    }

    public class SimpleHttpMessage {
        public HttpMethod HttpMethod { get; internal set; }
        public MessageType MessageType { get; internal set; }
        public Parameters Parameters { get; internal set; }
    }
    public class Parameters {
        public void Add(params string[] parameters) { }
    }
}
