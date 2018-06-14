using System;
using System.Globalization;
using Framework.Configuration;

namespace Framework.Logging.Logger.Settings
{
	/// <summary>
	///		Class: LogLevelSettings
	///		
	///		Author: Kevin Jankunas
	///		
	///		Created: 4/8/2003
	///		
	///		Description: Provides Log Level settings
	///		
	///		Comments: 
	/// </summary>
	/// 
	internal class LogLevelSettings
	{
		private const string ActiveEventsKeySet = "ActiveEvents";
		private const string DebugKey = "Debug";
		private const string InformationKey = "Information";
        private const string WarningKey = "Warning";
        private const string ErrorKey = "Error";
        private const string TraceKey = "Trace";
        private const string SuccessAuditKey = "SuccessAudit";
        private const string FailureAuditKey = "FailureAudit";

		private bool _debug = true;
		private bool _information = true;
		private bool _warning = true;
		private bool _error = true;
		private bool _trace = true;
		private bool _successAudit = true;
		private bool _failureAudit = true;

		public LogLevelSettings(KeySet settingsKeySet)
		{
			KeySet activeEventsKeySet = settingsKeySet.KeySets[ActiveEventsKeySet];
            _debug = string.Compare(activeEventsKeySet.Keys[DebugKey].Value,"true",true,CultureInfo.InvariantCulture) == 0 ? true : false;
            _information = string.Compare(activeEventsKeySet.Keys[InformationKey].Value,"true",true,CultureInfo.InvariantCulture) == 0 ? true : false;
            _warning = string.Compare(activeEventsKeySet.Keys[WarningKey].Value,"true",true,CultureInfo.InvariantCulture) == 0 ? true : false;
			_error = string.Compare(activeEventsKeySet.Keys[ErrorKey].Value,"true",true,CultureInfo.InvariantCulture) == 0 ? true : false;
			_trace = string.Compare(activeEventsKeySet.Keys[TraceKey].Value,"true",true,CultureInfo.InvariantCulture) == 0 ? true : false;
			_successAudit = string.Compare(activeEventsKeySet.Keys[SuccessAuditKey].Value,"true",true,CultureInfo.InvariantCulture) == 0 ? true : false;
            _failureAudit = string.Compare(activeEventsKeySet.Keys[FailureAuditKey].Value, "true", true, CultureInfo.InvariantCulture) == 0 ? true : false;
		}

		public bool Debug
		{
			get{return _debug;}
		}

		public bool Information
		{
			get{return _information;}
		}

		public bool Warning
		{
			get{return _warning;}
		}

		public bool Error
		{
			get{return _error;}
		}

		public bool Trace
		{
			get{return _trace;}
		}

		public bool SuccessAudit
		{
			get{return _successAudit;}
		}

		public bool FailureAudit
		{
			get{return _failureAudit;}
		}

		public bool IsLogging(LogLevel logLevel)
		{
			bool retVal = false;

			switch(logLevel)
			{
				case LogLevel.LogLevelDebug:
					retVal = Debug;
					break;
				case LogLevel.LogLevelInformation:
					retVal = Information;
					break;
				case LogLevel.LogLevelWarning:
					retVal = Warning;
					break;
				case LogLevel.LogLevelError:
					retVal = Error;
					break;
				case LogLevel.LogLevelTrace:
					retVal = Trace;
					break;
				case LogLevel.LogLevelSuccessAudit:
					retVal = SuccessAudit;
					break;
				case LogLevel.LogLevelFailureAudit:
					retVal = FailureAudit;
					break;
				default:
					retVal = false;
					break;
			}

			return retVal;
		}
	}
}
