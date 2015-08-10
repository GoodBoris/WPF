using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
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
    public class Target : ModelBase
    {

        #region Fields

        public struct Period
        {
            public Period(int startTime, int endTime)
            {
                StartTime = startTime;
                EndTime = endTime;
            }

            public int StartTime { get; set; }

            public int EndTime { get; set; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new object from scratch.
        /// </summary>
        public Target()
        {

        }

#if !SILVERLIGHT
        /// <summary>
        /// Initializes a new object based on <see cref="SerializationInfo"/>.
        /// </summary>
        /// <param name="info"><see cref="SerializationInfo"/> that contains the information.</param>
        /// <param name="context"><see cref="StreamingContext"/>.</param>
        protected Target(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
#endif

        #endregion

        #region Properties

        // TODO: Define your custom properties here using the DataProp code template.

        public string Number
        {
            get { return GetValue<string>(NumberProperty); }
            set { SetValue(NumberProperty, value); }
        }
        public static readonly PropertyData NumberProperty = RegisterProperty("Number", typeof(string));

        public string TextToSpeach
        {
            get { return GetValue<string>(TextToSpeachProperty); }
            set { SetValue(TextToSpeachProperty, value); }
        }
        public static readonly PropertyData TextToSpeachProperty = RegisterProperty("TextToSpeach", typeof(string), ()=> "Big hello! How are you?");

        public Period Time
        {
            get { return GetValue<Period>(TimeProperty); }
            set { SetValue(TimeProperty, value); }
        }
        public static readonly PropertyData TimeProperty = RegisterProperty("Time", typeof(Period), () => new Period(24, 23));

        public ObservableCollection<Target> Targets
        {
            get { return GetValue<ObservableCollection<Target>>(TargetsProperty); }
            set { SetValue(TargetsProperty, value); }
        }
        public static readonly PropertyData TargetsProperty =
            RegisterProperty("Targets", typeof(ObservableCollection<Target>), () => new ObservableCollection<Target>());

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

        protected override void ValidateFields(List<IFieldValidationResult> validationResults)
        {
            if (((Time.StartTime & Time.EndTime) > 24) | ((Time.StartTime & Time.EndTime) < 1))
                validationResults.Add(FieldValidationResult.CreateError(TimeProperty, "Время задано неправильно!"));

            if (string.IsNullOrWhiteSpace(Number))
                validationResults.Add(FieldValidationResult.CreateError(NumberProperty, "Необходимо ввести номер абонента"));

            const string patternNumber = @"(^\+\d{1,2})?((\(\d{3}\))|(\-?\d{3}\-)|(\d{3}))((\d{3}\-\d{4})| 
                                    (\d{3}\-\d\d\20.-\d\d)|(\d{7})|(\d{3}\-\d\-\d{3}))";

            if (!Regex.IsMatch(Number, patternNumber))
                validationResults.Add(FieldValidationResult.CreateError(NumberProperty, "Неправильно задан номер"));

            base.ValidateFields(validationResults);
        }

        #endregion
    }
}