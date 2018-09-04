using System;
using System.Collections.Generic;
using Autofac;
using Common;
using Lykke.Common.Log;
using Lykke.Job.OpsGenie.PeriodicalHandlers.Functions;

namespace Lykke.Job.OpsGenie.PeriodicalHandlers
{
    public class PeriodicalHandlerHost:IStartable, IStopable
    {
        private readonly IEnumerable<TimerTrigger> _timerTriggers;

        public PeriodicalHandlerHost(ILogFactory logFactory, DomainQueueFunctions domainQueueFunctions)
        {
            var refreshQueueTimerTrigger = new TimerTrigger(nameof(DomainQueueFunctions.Refresh),
                TimeSpan.FromMinutes(1),
                logFactory);
            
            refreshQueueTimerTrigger.Triggered += (trigger, args, token) => domainQueueFunctions.Refresh();

            _timerTriggers = new[]
            {
                refreshQueueTimerTrigger
            }; 
        }

        public void Start()
        {
            foreach (var timerTrigger in _timerTriggers)
            {
                timerTrigger.Start();
            }
        }

        public void Stop()
        {
            foreach (var timerTrigger in _timerTriggers)
            {
                timerTrigger.Stop();
            }
        }

        public void Dispose()
        {
            foreach (var timerTrigger in _timerTriggers)
            {
                timerTrigger.Dispose();
            }
        }
    }
}
