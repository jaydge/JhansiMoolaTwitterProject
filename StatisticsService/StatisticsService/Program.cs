using StatisticsService.Classes;
using StatisticsService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StatisticsService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            if (Environment.UserInteractive)
            {
                IPublisher publisher = new Publisher();
                publisher.StartPublishing();
                Thread.Sleep(600000);
                publisher.StopPublishing();
                return;
            }
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new TwitterStatisticsService()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
