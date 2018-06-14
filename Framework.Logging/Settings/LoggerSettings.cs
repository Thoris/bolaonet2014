using System;
using System.Configuration;
using System.Globalization;
using System.Diagnostics;
using Framework.Configuration;

namespace Framework.Logging.Logger.Settings
{
	/// <summary>
	///		Class: LoggerSettings
	///		
	///		Author: Kevin Jankunas
	///		
	///		Created: 4/8/2003
	///		
	///		Description: Provides Logger settings
	///		
	///		Comments: 
	/// </summary>
	/// 
	internal class LoggerSettings
	{
		private const string LOGGER_SECTION = "LoggerSettings";
		private const string APPLICATION_ID_KEY = "ApplicationId";
		private const string LOG_FRAMEWORK_TRACE_MESSAGES_KEY = "LogFrameworkTraceMessages";
		private const string LOG_FAILURES_TO_DISK_KEY = "LogFailuresToDisk";
		private const string FAILURE_PATH_KEY = "FailurePath";
		private const string TRANSPORTS_KEY = "Transports";
        private const string EVENT_SOURCE_NAME = "Logging";
		private int _applicationId;
		private bool _logFrameworkTraceMessages;
		private string _failurePath = string.Empty;
		private bool _logFailuresToDisk;
		private TransportSettings[] _transports;
		private LogLevelSettings _loggingLevels;

        private class Nested
        {
            static Nested() { }
            internal static readonly LoggerSettings Settings = new LoggerSettings();
        }

		public LoggerSettings()
		{
			Initialize();
		}

        public static LoggerSettings Current
        {
            get { return Nested.Settings; }
        }

		private void Initialize()
		{

		    KeySet loggerSettings = KeySetConfiguration.Config(LOGGER_SECTION);

            if (loggerSettings == null)
            {
                throw new ConfigurationErrorsException(string.Format(CultureInfo.CurrentCulture, ResourceData.MissingConfigSetting, LOGGER_SECTION));
            }

		    _applicationId = int.Parse(loggerSettings.Keys[APPLICATION_ID_KEY].Value,CultureInfo.InvariantCulture);
		    _logFrameworkTraceMessages = string.Compare(loggerSettings.Keys[LOG_FRAMEWORK_TRACE_MESSAGES_KEY].Value, "true", true, CultureInfo.InvariantCulture) == 0 ? true : false;
    		
		    LoggerTraceListener listener = new LoggerTraceListener();
		    if(Trace.Listeners.Contains(listener) == false)
		    {
			    Trace.Listeners.Add(listener);
		    }

            _logFailuresToDisk = string.Compare(loggerSettings.Keys[LOG_FAILURES_TO_DISK_KEY].Value, "true", true, CultureInfo.InvariantCulture) == 0 ? true : false;
		    if(_logFailuresToDisk == true)
		    {
			    _failurePath = loggerSettings.Keys[FAILURE_PATH_KEY].Value;
		    }

		    _loggingLevels = new LogLevelSettings(loggerSettings);

		    _transports = new TransportSettings[loggerSettings.KeySets[TRANSPORTS_KEY].KeySets.Count];

		    for(int i = 0; i < loggerSettings.KeySets[TRANSPORTS_KEY].KeySets.Count; i++)
		    {
			    _transports[i] = new TransportSettings(loggerSettings.KeySets[TRANSPORTS_KEY].KeySets[i]);
		    }
		}

        public static string EventSourceName
        {
            get { return EVENT_SOURCE_NAME; }
        }

		public int ApplicationId
		{
			get{return _applicationId;}
		}

		public bool LogFrameworkTraceMessages
		{
			get{return _logFrameworkTraceMessages;}
		}

		public bool LogFailuresToDisk
		{
			get{return _logFailuresToDisk;}
		}

		public string FailurePath
		{
			get{return _failurePath;}
		}

		public TransportSettings[] Transports
		{
			get{return _transports;}
		}

		public LogLevelSettings LoggingLevels
		{
			get{return _loggingLevels;}
		}
	}
}
