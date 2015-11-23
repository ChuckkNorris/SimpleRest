using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Web.Http;

namespace SimpleRest.Api {
    public static class MessageHelper {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseUrl">"https://api.site.com"</param>
        /// <param name="endPointPath">"Person/Dogs"</param>
        /// <param name="queryStringParameters"></param>
        /// <returns></returns>
        public static async Task<Uri> BuildUri(string baseUrl, string endPointPath, Dictionary<string,string> queryStringParameters) {
            string fixedBaseUrl = baseUrl.TrimEnd('/') + "/";
            string fixedEndPoint = endPointPath.TrimStart('/');
            var builder = new UriBuilder(fixedBaseUrl + fixedEndPoint);
            builder.Port = -1;
            HttpFormUrlEncodedContent encodedQueryString = new HttpFormUrlEncodedContent(queryStringParameters);
            builder.Query = await encodedQueryString.ReadAsStringAsync();
            return builder.Uri;
        }

    }
}