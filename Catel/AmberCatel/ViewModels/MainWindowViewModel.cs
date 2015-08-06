using System.Collections.ObjectModel;
using AmberCatel.Models;
using AmberCatel.Services.Interfaces;
using Catel;
using Catel.Data;
using Catel.MVVM;
using Task = System.Threading.Tasks.Task;

namespace AmberCatel.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly ISerializerService<Account> _accountService;
        public MainWindowViewModel(ISerializerService<Account> accountService)
        {
            Argument.IsNotNull(() => accountService);
            _accountService = accountService;
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
            await base.Initialize();
            Accounts = new ObservableCollection<Account>(_accountService.LoadData());
            // TODO: subscribe to events here
        }

        protected override async Task Close()
        {
            // TODO: unsubscribe from events here
            _accountService.SaveData(Accounts);
            await base.Close();
        }
    }
}
