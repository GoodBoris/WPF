using Quartz;

namespace AmberCatel.Services.Interfaces
{
    public interface ISchedulerService
    {
        IScheduler Scheduler { get; }
        void SetThreadCount(int count);
    }
}