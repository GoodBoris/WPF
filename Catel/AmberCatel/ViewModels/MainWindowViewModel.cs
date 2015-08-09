using System.Collections.ObjectModel;
using System.Windows;
using AmberCatel.Models;
using AmberCatel.Services;
using AmberCatel.Services.Interfaces;
using Catel;
using Catel.Data;
using Catel.MVVM;
using Catel.Windows;
using Quartz;
using Task = System.Threading.Tasks.Task;

namespace AmberCatel.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly ISerializerService<Account> _accountService;
        private readonly ISchedulerService _schedulerService;
        public MainWindowViewModel(ISerializerService<Account> accountService, ISchedulerService schedulerService)
        {
            Argument.IsNotNull(() => accountService);
            _accountService = accountService;
            _schedulerService = schedulerService;

            var job = JobBuilder.Create<HelloJob>().WithIdentity(new JobKey("Task_1", "TaskGroup")).Build();
            var t =
                TriggerBuilder.Create()
                    .WithIdentity("Trigger_1", "TaskGroup")
                    .StartAt(DateBuilder.TodayAt(21, 15, 0))
                    .EndAt(DateBuilder.TodayAt(21, 18, 0))
                    .Build();
            _schedulerService.Scheduler.ScheduleJob(job, t);
            MessageBox.Show(_schedulerService.Scheduler.IsStarted.ToString());  
        }

        public ObservableCollection<Account> Accounts
        {
            get { return GetValue<ObservableCollection<Account>>(AccountsProperty); }
            set { SetValue(AccountsProperty, value); }
        }
        public static readonly PropertyData AccountsProperty = RegisterProperty("Accounts", typeof(ObservableCollection<Account>));
        public override string Title => "MainVM";

        // TODO: Register models with the vmpropmodel codesnippet
        // TODO: Register view model properties with the vmprop or vmpropviewmodeltomodel codesnippets
        // TODO: Register commands with the vmcommand or vmcommandwithcanexecute codesnippets


        protected override async Task Initialize()
        {
            Accounts = new ObservableCollection<Account>(_accountService.LoadData());
            // TODO: subscribe to events here 
            StyleHelper.CreateStyleForwardersForDefaultStyles();
            await base.Initialize();
        }

        protected override async Task Close()
        {
            // TODO: unsubscribe from events here
            _accountService.SaveData(Accounts);
            await base.Close();
        }
    }
}
