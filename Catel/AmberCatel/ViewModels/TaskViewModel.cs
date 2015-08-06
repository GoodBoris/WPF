using Catel;
using Catel.Data;

namespace AmberCatel.ViewModels
{
    using Catel.MVVM;
    using System.Threading.Tasks;

    public class TaskViewModel : ViewModelBase
    {
        public TaskViewModel(Task task)
        {
            Argument.IsNotNull(() => task);

        }

        public override string Title => "TaskVM";

        #region Task model property
        [Model]
        public Task Task
        {
            get { return GetValue<Task>(TaskProperty); }
            private set { SetValue(TaskProperty, value); }
        }
        public static readonly PropertyData TaskProperty = RegisterProperty("Task", typeof (Task));

        #endregion

        #region Number property
        [ViewModelToModel("Task")]
        public string Number
        {
            get { return GetValue<string>(NumberProperty); }
            set { SetValue(NumberProperty, value); }
        }
        public static readonly PropertyData NumberProperty = RegisterProperty("Number", typeof (string));
        #endregion

        #region TextToSpeach property
        [ViewModelToModel("Task")]
        public string TextToSpeach
        {
            get { return GetValue<string>(TextToSpeachProperty); }
            set { SetValue(TextToSpeachProperty, value); }
        }
        public static readonly PropertyData TextToSpeachProperty = RegisterProperty("TextToSpeach", typeof (string));
        #endregion

        #region Time property
        [ViewModelToModel("Task")]
        public Models.Task.Period Time
        {
            get { return GetValue<Models.Task.Period>(TimeProperty); }
            set { SetValue(TimeProperty, value); }
        }
        public static readonly PropertyData TimeProperty = RegisterProperty("Time", typeof (Models.Task.Period));
        #endregion


        // TODO: Register models with the vmpropmodel codesnippet
        // TODO: Register view model properties with the vmprop or vmpropviewmodeltomodel codesnippets
        // TODO: Register commands with the vmcommand or vmcommandwithcanexecute codesnippets

        protected override async Task Initialize()
        {
            await base.Initialize();

            // TODO: subscribe to events here
        }

        protected override async Task Close()
        {
            // TODO: unsubscribe from events here

            await base.Close();
        }
    }
}
