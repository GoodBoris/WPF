using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Catel.Data;

namespace AmberCatel.Models
{
    /// <summary>
    /// $Name$ model which fully supports serialization, property changed notifications,
    /// backwards compatibility and error checking.
    /// </summary>
#if !SILVERLIGHT
    [Serializable]
#endif
    public class Account : ModelBase
    {
        #region Fields

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new object from scratch.
        /// </summary>
        public Account()
        {
        }

#if !SILVERLIGHT
        /// <summary>
        /// Initializes a new object based on <see cref="SerializationInfo"/>.
        /// </summary>
        /// <param name="info"><see cref="SerializationInfo"/> that contains the information.</param>
        /// <param name="context"><see cref="StreamingContext"/>.</param>
        protected Account(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
#endif

        #endregion

        #region Properties


        public string Server
        {
            get { return GetValue<string>(ServerProperty); }
            set { SetValue(ServerProperty, value); }
        }
        public static readonly PropertyData ServerProperty = RegisterProperty("Server", typeof(string));

        public string Login
        {
            get { return GetValue<string>(LoginProperty); }
            set { SetValue(LoginProperty, value); }
        }
        public static readonly PropertyData LoginProperty = RegisterProperty("Login", typeof(string));

        public string Password
        {
            get { return GetValue<string>(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }
        public static readonly PropertyData PasswordProperty = RegisterProperty("Password", typeof(string));

        public ObservableCollection<Account> Accounts
        {
            get { return GetValue<ObservableCollection<Account>>(AccountsProperty); }
            set { SetValue(AccountsProperty, value); }
        }
        public static readonly PropertyData AccountsProperty =
            RegisterProperty("Accounts", typeof(ObservableCollection<Account>), () => new ObservableCollection<Account>());

        #endregion

        #region Methods
        /// <summary>
        /// Validates the business rules of this object. Override this method to enable
        ///             validation of business rules.
        /// </summary>
        /// <param name="validationResults">The validation results, add additional results to this list.</param>
        protected override void ValidateBusinessRules(List<IBusinessRuleValidationResult> validationResults)
        {
            base.ValidateBusinessRules(validationResults);
        }

        /// <summary>
        /// Validates the field values of this object. Override this method to enable
        ///             validation of field values.
        /// </summary>
        /// <param name="validationResults">The validation results, add additional results to this list.</param>
        protected override void ValidateFields(List<IFieldValidationResult> validationResults)
        {
            if (string.IsNullOrWhiteSpace(Server))
                validationResults.Add(FieldValidationResult.CreateError(ServerProperty, "Необходимо ввести сервер подключения"));

            if (string.IsNullOrWhiteSpace(Login))
                validationResults.Add(FieldValidationResult.CreateError(LoginProperty, "Необходимо указать логин"));

            if (string.IsNullOrWhiteSpace(Password))
                validationResults.Add(FieldValidationResult.CreateError(PasswordProperty, "Введите пожалуйста пароль"));

            base.ValidateFields(validationResults);
        }

        #endregion
    }
}
