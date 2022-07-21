using StatisticsService.Classes;
using StatisticsService.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsService
{
    public partial class TwitterStatisticsService : ServiceBase
    {
        private IPublisher publisher = null;
        public TwitterStatisticsService()
        {
            InitializeComponent();
            publisher = new Publisher();
        }

        protected override void OnStart(string[] args)
        {
            publisher.StartPublishing();
        }

        protected override void OnStop()
        {
            publisher.StopPublishing();
        }
    }
}
