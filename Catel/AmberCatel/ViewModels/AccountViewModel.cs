using AmberCatel.Models;
using Catel;
using Catel.Data;

namespace AmberCatel.ViewModels
{
    using Catel.MVVM;
    using System.Threading.Tasks;

    public class AccountViewModel : ViewModelBase
    {
        public AccountViewModel(Account account)
        {
            Argument.IsNotNull(() => account);
            Account = account;
        }

        public override string Title => "AccountVM";

        #region AccountProperty model property
        [Model]
        public Account Account  
        {
            get { return GetValue<Account>(AccountProperty); }
            private set { SetValue(AccountProperty, value); }
        }

        public static readonly PropertyData AccountProperty = RegisterProperty("Account", typeof (Account));
        #endregion

        #region Server property
        [ViewModelToModel("Account", "Server")]
        public string Server
        {
            get { return GetValue<string>(ServerProperty); }
            set { SetValue(ServerProperty, value); }
        }
        public static readonly PropertyData ServerProperty = RegisterProperty("AccountServer", typeof (string));
        #endregion

        #region Login property
        [ViewModelToModel("Account", "Login")]
        public string Login
        {
            get { return GetValue<string>(LoginProperty); }
            set { SetValue(LoginProperty, value); }
        }
        public static readonly PropertyData LoginProperty = RegisterProperty("AccountLogin", typeof (string));
        #endregion

        #region Password property
        [ViewModelToModel("Account", "Password")]
        public string Password
        {
            get { return GetValue<string>(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }
        public static readonly PropertyData PasswordProperty = RegisterProperty("AccountPassword", typeof (string));
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
