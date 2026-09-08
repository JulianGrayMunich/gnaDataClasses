namespace gnaDataClasses
{
    #region SMS Recipient Models

    public enum SmsNotificationGroup
    {
        All = 0,
        Red = 1
    }


    public sealed class SmsRecipient
    {
        #region Constructor

        public SmsRecipient(
            string configurationKey,
            string phoneNumber,
            SmsNotificationGroup notificationGroup)
        {
            #region Validate Configuration Key

            configurationKey = configurationKey
                ?? throw new ArgumentNullException(
                    paramName: nameof(configurationKey));

            string strConfigurationKey =
                configurationKey.Trim();

            if (strConfigurationKey.Length == 0)
            {
                throw new ArgumentException(
                    message:
                        "The SMS recipient configuration key is required.",
                    paramName: nameof(configurationKey));
            }

            #endregion

            #region Validate Telephone Number

            phoneNumber = phoneNumber
                ?? throw new ArgumentNullException(
                    paramName: nameof(phoneNumber));

            string strPhoneNumber = phoneNumber.Trim();

            if (strPhoneNumber.Length == 0)
            {
                throw new ArgumentException(
                    message:
                        "The SMS recipient telephone number is required.",
                    paramName: nameof(phoneNumber));
            }

            #endregion

            #region Validate Notification Group

            if (!Enum.IsDefined(
                enumType: typeof(SmsNotificationGroup),
                value: notificationGroup))
            {
                throw new ArgumentOutOfRangeException(
                    paramName: nameof(notificationGroup),
                    actualValue: notificationGroup,
                    message:
                        "The SMS notification group is invalid.");
            }

            #endregion

            #region Assign Properties

            ConfigurationKey = strConfigurationKey;
            PhoneNumber = strPhoneNumber;
            NotificationGroup = notificationGroup;

            #endregion
        }

        #endregion

        #region Properties

        public string ConfigurationKey { get; }

        public string PhoneNumber { get; }

        public SmsNotificationGroup NotificationGroup { get; }

        #endregion
    }

    #endregion


    #region Alarm Evaluation Models

    public enum AlarmSeverity
    {
        None = 0,
        Amber = 1,
        Red = 2
    }


    public enum AlarmStateChange
    {
        Unchanged = 0,
        Reset = 1,
        Raised = 2,
        Changed = 3
    }


    public enum RedAlarmTransition
    {
        None = 0,
        EnteredRed = 1,
        LeftRed = 2
    }


    public sealed class AlarmEvaluationResult
    {
        #region Constructor

        public AlarmEvaluationResult(
            string previousAlarmState,
            string currentAlarmState,
            AlarmStateChange stateChange,
            AlarmSeverity previousSeverity,
            AlarmSeverity currentSeverity,
            RedAlarmTransition redTransition,
            string responseText)
        {
            #region Validate Alarm States

            previousAlarmState = previousAlarmState
                ?? throw new ArgumentNullException(
                    paramName: nameof(previousAlarmState));

            currentAlarmState = currentAlarmState
                ?? throw new ArgumentNullException(
                    paramName: nameof(currentAlarmState));

            string strPreviousAlarmState =
                previousAlarmState.Trim();

            string strCurrentAlarmState =
                currentAlarmState.Trim();

            if (strPreviousAlarmState.Length == 0)
            {
                throw new ArgumentException(
                    message:
                        "The previous alarm state is required.",
                    paramName: nameof(previousAlarmState));
            }

            if (strCurrentAlarmState.Length == 0)
            {
                throw new ArgumentException(
                    message:
                        "The current alarm state is required.",
                    paramName: nameof(currentAlarmState));
            }

            #endregion

            #region Validate Enumerations

            ValidateEnumerationValue(
                enumValue: stateChange,
                parameterName: nameof(stateChange));

            ValidateEnumerationValue(
                enumValue: previousSeverity,
                parameterName: nameof(previousSeverity));

            ValidateEnumerationValue(
                enumValue: currentSeverity,
                parameterName: nameof(currentSeverity));

            ValidateEnumerationValue(
                enumValue: redTransition,
                parameterName: nameof(redTransition));

            #endregion

            #region Validate Red Transition

            bool blnRedTransitionIsValid =
                redTransition switch
                {
                    RedAlarmTransition.None =>
                        !(
                            previousSeverity != AlarmSeverity.Red &&
                            currentSeverity == AlarmSeverity.Red) &&
                        !(
                            previousSeverity == AlarmSeverity.Red &&
                            currentSeverity != AlarmSeverity.Red),

                    RedAlarmTransition.EnteredRed =>
                        previousSeverity != AlarmSeverity.Red &&
                        currentSeverity == AlarmSeverity.Red,

                    RedAlarmTransition.LeftRed =>
                        previousSeverity == AlarmSeverity.Red &&
                        currentSeverity != AlarmSeverity.Red,

                    _ => false
                };

            if (!blnRedTransitionIsValid)
            {
                throw new ArgumentException(
                    message:
                        "The Red alarm transition is inconsistent with " +
                        "the previous and current alarm severities.",
                    paramName: nameof(redTransition));
            }

            #endregion

            #region Validate Response Text

            responseText = responseText
                ?? throw new ArgumentNullException(
                    paramName: nameof(responseText));

            string strResponseText = responseText.Trim();

            if (strResponseText.Length == 0)
            {
                throw new ArgumentException(
                    message:
                        "The alarm evaluation response text is required.",
                    paramName: nameof(responseText));
            }

            #endregion

            #region Assign Properties

            PreviousAlarmState = strPreviousAlarmState;
            CurrentAlarmState = strCurrentAlarmState;
            StateChange = stateChange;
            PreviousSeverity = previousSeverity;
            CurrentSeverity = currentSeverity;
            RedTransition = redTransition;
            ResponseText = strResponseText;

            #endregion
        }

        #endregion

        #region Properties

        public string PreviousAlarmState { get; }

        public string CurrentAlarmState { get; }

        public AlarmStateChange StateChange { get; }

        public AlarmSeverity PreviousSeverity { get; }

        public AlarmSeverity CurrentSeverity { get; }

        public RedAlarmTransition RedTransition { get; }

        public string ResponseText { get; }

        public bool AlarmNotificationRequired =>
            StateChange != AlarmStateChange.Unchanged;

        public bool RedNotificationRequired =>
            RedTransition != RedAlarmTransition.None;

        #endregion

        #region Validation Helper

        private static void ValidateEnumerationValue<TEnum>(
            TEnum enumValue,
            string parameterName)
            where TEnum : struct, Enum
        {
            if (!Enum.IsDefined(
                enumType: typeof(TEnum),
                value: enumValue))
            {
                throw new ArgumentOutOfRangeException(
                    paramName: parameterName,
                    actualValue: enumValue,
                    message:
                        $"The {typeof(TEnum).Name} value is invalid.");
            }
        }

        #endregion
    }

    #endregion
}
