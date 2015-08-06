using System.Collections.ObjectModel;
using Catel.Data;

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
    }
}