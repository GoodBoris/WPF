using AmberCatel.Models;
using Catel;
using Catel.Data;

namespace AmberCatel.ViewModels
{
    using Catel.MVVM;
    using System.Threading.Tasks;

    public class TargetViewModel : ViewModelBase
    {
        public TargetViewModel(Target target)
        {
            Argument.IsNotNull(() => target);
            Target = target;
        }

        public override string Title => "TARGET View model title";

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
