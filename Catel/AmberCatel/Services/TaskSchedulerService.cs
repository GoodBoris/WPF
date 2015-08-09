using System;
using System.Collections.Specialized;
using System.IO;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Matchers;
using ISchedulerService = AmberCatel.Services.Interfaces.ISchedulerService;

namespace AmberCatel.Services
{
    public class TaskSchedulerService : ISchedulerService
    {
        private IScheduler _scheduler = new StdSchedulerFactory(
            new NameValueCollection { { "quartz.threadPool.threadCount", "50" },
                { "quartz.scheduler.instanceName", "ScheduleExecutorService" } })
            .GetScheduler();

        public TaskSchedulerService()
        {
            _scheduler.ListenerManager.AddJobListener(new RepeatAfterCompletionJobListener(), GroupMatcher<JobKey>.GroupEquals("TaskGroup"));
            _scheduler.Start();
        }
        public IScheduler Scheduler => _scheduler;

        public void SetThreadCount(int count)
        {
            _scheduler.ListenerManager.RemoveJobListener("RepeatAfterCompletionJobListener");
            var currentJobs = _scheduler.GetCurrentlyExecutingJobs();
            //ToDo: Create private methods, inject currentJobs if need
            _scheduler.Shutdown(true);
            _scheduler = new StdSchedulerFactory(
            new NameValueCollection { { "quartz.threadPool.threadCount", count.ToString() },
                { "quartz.scheduler.instanceName", "ScheduleExecutorService" } })
            .GetScheduler();
            _scheduler.ListenerManager.AddJobListener(new RepeatAfterCompletionJobListener(), GroupMatcher<JobKey>.GroupEquals("TaskGroup"));
            _scheduler.Start();
            //ToDo: Add Jobs
        }
    }

    public class RepeatAfterCompletionJobListener : IJobListener
    {
        public void JobToBeExecuted(IJobExecutionContext context)
        {

        }

        public void JobExecutionVetoed(IJobExecutionContext context)
        {

        }

        public void JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException)
        {
            if (DateTime.UtcNow > context.Trigger.EndTimeUtc)
                return;
            File.AppendAllText(@"C:\Intel\Logs\1.txt", context.Trigger.StartTimeUtc + " " + context.Trigger.EndTimeUtc);
            context.Scheduler.RescheduleJob(context.Trigger.Key, context.Trigger);
        }

        public string Name => "RepeatAfterCompletionJobListener";
    }

    public class HelloJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
        }
    }
}