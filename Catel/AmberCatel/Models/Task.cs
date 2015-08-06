using System;
using System.Collections.Generic;
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
    public class Task : ModelBase
    {

        #region Fields

        public struct Period
        {
            private int _startTime, _endTime;

            public Period(int startTime, int endTime)
            {
                _startTime = startTime;
                _endTime = endTime;
            }

            public int StartTime
            {
                get { return _startTime; }
                set { _startTime = value; }
            }

            public int EndTime
            {
                get { return _endTime; }
                set { _endTime = value; }
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new object from scratch.
        /// </summary>
        public Task()
        {

        }

#if !SILVERLIGHT
        /// <summary>
        /// Initializes a new object based on <see cref="SerializationInfo"/>.
        /// </summary>
        /// <param name="info"><see cref="SerializationInfo"/> that contains the information.</param>
        /// <param name="context"><see cref="StreamingContext"/>.</param>
        protected Task(SerializationInfo info, StreamingContext context)
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
        public static readonly PropertyData TextToSpeachProperty = RegisterProperty("TextToSpeach", typeof(string), "Big hello! How are you?");

        public Period Time
        {
            get { return GetValue<Period>(TimeProperty); }
            set { SetValue(TimeProperty, value); }
        }
        public static readonly PropertyData TimeProperty = RegisterProperty("Time", typeof(Period), () => new Period(24, 23));

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
            base.ValidateFields(validationResults);
        }

        #endregion
    }
}