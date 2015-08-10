using System.Collections.ObjectModel;
using Catel.Data;
using Quartz.Plugin.Xml;

namespace AmberCatel.Models
{
    public class Settings : SavableModelBase<Settings>
    {

        public ObservableCollection<Account> Accounts
        {
            get { return GetValue<ObservableCollection<Account>>(AccountsProperty); }
            set { SetValue(AccountsProperty, value); }
        }

        public static readonly PropertyData AccountsProperty =
            RegisterProperty("Accounts", typeof(ObservableCollection<Account>), () => new ObservableCollection<Account>());

        #region Targets property
        public ObservableCollection<Target> Targets
        {
            get { return GetValue<ObservableCollection<Target>>(TargetsProperty); }
            set { SetValue(TargetsProperty, value); }
        }
        public static readonly PropertyData TargetsProperty = 
            RegisterProperty("Targets", typeof (ObservableCollection<Target>), () => new ObservableCollection<Target>());
        #endregion
    }

}