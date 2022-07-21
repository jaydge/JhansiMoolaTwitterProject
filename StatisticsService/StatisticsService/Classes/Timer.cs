using StatisticsService.Interfaces;
using StatisticsService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using AlarmTimer = System.Timers.Timer;

namespace StatisticsService.Classes
{
    public class Timer:ITimer
    {
        private static readonly object _locker = new object();

        private TweetsSampleService sampleService = null;

        private AlarmTimer alarmTimer= null;

        private long TotalTweets = 0;

        private List<Data> Tweets = new List<Data>();

        private List<string> TopTenHashTags = new List<string>();
        public Timer(double interval)
        {
            sampleService = TweetsSampleService.GetInstance();
            alarmTimer = new AlarmTimer();
            alarmTimer.Interval = interval;
            alarmTimer.Enabled = true;
            alarmTimer.AutoReset = true;
            alarmTimer.Elapsed += AlarmEventHandler;
        }

        public void StartAlarm()
        {
            alarmTimer.Start();
        }

        public void StopAlarm()
        {
            CalculateTopHashTags();
            alarmTimer.Stop();
            alarmTimer.Dispose();
        }

        private List<string> CalculateTopHashTags()
        {
            var topTenTweets = Tweets.OrderByDescending(o => o.Id).Take(10);
            string hashTag = string.Empty;

            foreach (var tweet in topTenTweets)
            {
                hashTag = tweet.Text.Split(' ')[1];
                TopTenHashTags.Add(hashTag);
            }
            return TopTenHashTags;
        }
        private void AlarmEventHandler(object sender, ElapsedEventArgs args)
        {
            lock (_locker)
            {
                try
                {
                    IList<Data> tweets= sampleService.GetSampleTweets().Result;                    
                    TotalTweets += Convert.ToInt64(tweets.Count);
                    Tweets.AddRange(tweets);
                }
                catch(Exception ex)
                {
                    //we need to log the exception here 
                }
            }
        }
    }
}
