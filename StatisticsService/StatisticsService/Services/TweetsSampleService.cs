using Newtonsoft.Json;
using StatisticsService.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsService.Services
{
    public class TweetsSampleService
    {
        private static readonly TweetsSampleService instance = new TweetsSampleService();

        private string baseAddress = null;
        private string mediaType = null;
        private HttpClient client = null;

        public static TweetsSampleService GetInstance()
        {
            return instance;

        }
        public TweetsSampleService()
        {
            baseAddress = "https://api.twitter.com";
            mediaType = "application/json";
            client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(mediaType));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "AAAAAAAAAAAAAAAAAAAAAD48fAEAAAAA2jOLHsMWavD0fQYZ6VPW%2BPMLSsA%3DPdP4C0S90DNkTp2zKE1kp0JKk8i0r8W0YHlUADf6RzkkK3vn7l");
        }
            

        public async Task<IList<Data>> GetSampleTweets()
        {
            string apiPath = "/2/tweets/sample/stream";

            var jsonResult = await client.GetStringAsync(apiPath);

            List<Data> tweetsList = JsonConvert.DeserializeObject<List<Data>>(jsonResult, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            return tweetsList;
        }
    }
}
