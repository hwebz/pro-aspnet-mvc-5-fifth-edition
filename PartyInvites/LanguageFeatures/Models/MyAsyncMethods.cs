using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace LanguageFeatures.Models
{
    public static class MyAsyncMethods
    {
        public static Task<long?> GetPageLength()
        {
            HttpClient client = new HttpClient();

            var httpTask = client.GetAsync("https://learning.oreilly.com/library/view/pro-aspnet-mvc/9781430265290/9781430265290_Ch04.xhtml");

            // we could do other things here while we are waiting
            // for the HTTP request to complete
            Console.WriteLine("Doing something others while client is fetching...");

            return httpTask.ContinueWith((Task<HttpResponseMessage> antecedent) =>
            {
                return antecedent.Result.Content.Headers.ContentLength;
            });
        }

        public async static Task<long?> GetPageLength2()
        {
            HttpClient client = new HttpClient();

            var httpMessage = await client.GetAsync("https://learning.oreilly.com/library/view/pro-aspnet-mvc/9781430265290/9781430265290_Ch04.xhtml");

            // we could do other things here while we are waiting
            // for the HTTP request to complete
            Console.WriteLine("Doing something others while client is fetching...");

            return httpMessage.Content.Headers.ContentLength;
        }
    }
}