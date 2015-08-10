using System.Collections.ObjectModel;
using AmberCatel.Models;
using AmberCatel.Services.Interfaces;
using Catel;
using Catel.Data;
using Catel.MVVM;
using Catel.Services;
using Catel.Windows;
using ISchedulerService = AmberCatel.Services.Interfaces.ISchedulerService;
using Task = System.Threading.Tasks.Task;

namespace AmberCatel.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly ISerializerService<Account> _accountSerializerService;
        private readonly ISchedulerService _accountSchedulerService;
        public MainWindowViewModel(Target target, ISerializerService<Account> accountSerializerService, ISchedulerService accountSchedulerService, 
            IUIVisualizerService uiVisualizerService, IMessageService messageService)
        {
            Argument.IsNotNull(() => accountSerializerService);
            Argument.IsNotNull(() => accountSchedulerService);
            Argument.IsNotNull(() => uiVisualizerService);
            Argument.IsNotNull(() => messageService);
            Argument.IsNotNull(() => target);
            _accountSerializerService = accountSerializerService;
            _accountSchedulerService = accountSchedulerService;
            _uiVisualizerService = uiVisualizerService;
            _messageService = messageService;
            Target = target;
            AddTarget = new Command(OnAddTargetExecute);
            RemoveTarget = new Command(OnRemoveTargetExecute, OnRemoveTargetCanExecute);

            /*var job = JobBuilder.Create<HelloJob>().WithIdentity(new JobKey("Task_1", "TaskGroup")).Build();
            var t =
                TriggerBuilder.Create()
                    .WithIdentity("Trigger_1", "TaskGroup")
                    .StartAt(DateBuilder.TodayAt(21, 15, 0))
                    .EndAt(DateBuilder.TodayAt(21, 18, 0))
                    .Build();
            _accountSchedulerService.Scheduler.ScheduleJob(job, t);
            MessageBox.Show(_accountSchedulerService.Scheduler.IsStarted.ToString());  */
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
        #region Target model property
        [Model]
        public Target Target
        {
            get { return GetValue<Target>(TargetProperty); }
            private set { SetValue(TargetProperty, value); }
        }
        public static readonly PropertyData TargetProperty = RegisterProperty("Target", typeof(Target));
        #endregion

        #region Number property
        [ViewModelToModel("Target")]
        public string Number
        {
            get { return GetValue<string>(NumberProperty); }
            set { SetValue(NumberProperty, value); }
        }
        public static readonly PropertyData NumberProperty = RegisterProperty("Number", typeof(string));
        #endregion

        #region TextToSpeach property
        [ViewModelToModel("Target")]
        public string TextToSpeach
        {
            get { return GetValue<string>(TextToSpeachProperty); }
            set { SetValue(TextToSpeachProperty, value); }
        }
        public static readonly PropertyData TextToSpeachProperty = RegisterProperty("TextToSpeach", typeof(string));
        #endregion

        #region Time property
        [ViewModelToModel("Target")]
        public Target.Period Time
        {
            get { return GetValue<Target.Period>(TimeProperty); }
            set { SetValue(TimeProperty, value); }
        }
        public static readonly PropertyData TimeProperty = RegisterProperty("Time", typeof(Target.Period));
        #endregion

        [ViewModelToModel("Target")]
        public ObservableCollection<Target> Targets
        {
            get { return GetValue<ObservableCollection<Target>>(TargetsProperty); }
            set { SetValue(TargetsProperty, value); }
        }
        public static readonly PropertyData TargetsProperty = RegisterProperty("Targets", typeof(ObservableCollection<Target>));

        #region SelectedTarget property
        public Target SelectedTarget
        {
            get { return GetValue<Target>(SelectedTargetProperty); }
            set { SetValue(SelectedTargetProperty, value); }
        }
        public static readonly PropertyData SelectedTargetProperty = RegisterProperty("SelectedTarget", typeof(Target));
        #endregion

        public Command AddTarget { get; private set; }
        public Command RemoveTarget { get; private set; }

        private async void OnAddTargetExecute()
        {
            var target = new Target();

        }

        private async void OnRemoveTargetExecute()
        {

        }

        private bool OnRemoveTargetCanExecute()
        {
            return SelectedTarget != null;
        }

        private readonly IUIVisualizerService _uiVisualizerService;
        private readonly IMessageService _messageService;


        protected override async Task Initialize()
        {
            Accounts = new ObservableCollection<Account>(_accountSerializerService.LoadData());
            // TODO: subscribe to events here 
            StyleHelper.CreateStyleForwardersForDefaultStyles();
            await base.Initialize();
        }

        protected override async Task Close()
        {
            // TODO: unsubscribe from events here
            _accountSchedulerService.Scheduler.Shutdown();
            _accountSerializerService.SaveData(Accounts);
            await base.Close();
        }
    }
}
