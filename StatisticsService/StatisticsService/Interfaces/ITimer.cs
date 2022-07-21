using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsService.Interfaces
{
    interface ITimer
    {
        void StartAlarm();

        void StopAlarm();
    }
}
