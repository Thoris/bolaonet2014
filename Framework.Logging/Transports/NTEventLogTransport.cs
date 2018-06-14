using System;
using System.Diagnostics;
using Framework.Logging.Logger;
using Framework.Logging.Logger.Settings;

namespace Framework.Logging.Logger.Transports
{
	/// <summary>
	/// Summary description for NTEventLogTransport.
	/// </summary>
	internal class NTEventLogTransport : LoggerTransport
	{
		public NTEventLogTransport(){}

		public override void WriteLog(LogRecord record,TransportSettings settings)
		{
			System.Diagnostics.EventLog.WriteEntry(LoggerSettings.EventSourceName,
				record.ToString(),
				GetNTEventLogEntryType(record.LogLevel));
		}

		private static EventLogEntryType GetNTEventLogEntryType(LogLevel level)
		{
			switch(level)
			{
				case LogLevel.LogLevelDebug:
					return EventLogEntryType.Information;
				case LogLevel.LogLevelTrace:
					return EventLogEntryType.Information;				
				case LogLevel.LogLevelInformation:
					return EventLogEntryType.Information;
				case LogLevel.LogLevelWarning:
					return EventLogEntryType.Warning;
				case LogLevel.LogLevelError:
					return EventLogEntryType.Error;
				case LogLevel.LogLevelFailureAudit:
					return EventLogEntryType.FailureAudit;
				case LogLevel.LogLevelSuccessAudit:
					return EventLogEntryType.SuccessAudit;
				default:
					return EventLogEntryType.Error;
			}
		}
	}
}
