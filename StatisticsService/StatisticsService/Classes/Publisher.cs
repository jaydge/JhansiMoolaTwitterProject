using StatisticsService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsService.Classes
{
    public class Publisher:IPublisher
    {
        private ITimer timer = null;
        public Publisher()
        {
            timer = new Timer(5000);
        }
        public void StartPublishing()
        {
            timer.StartAlarm();
        }

        public void StopPublishing()
        {
            timer.StopAlarm();
        }
    }
}
