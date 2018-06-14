using System;
using Framework.Logging.Logger;
using Framework.Logging.Logger.Settings;

namespace Framework.Logging.Logger.Transports
{
	/// <summary>
	/// Summary description for LoggerTransport.
	/// </summary>
	internal abstract class LoggerTransport
	{
		public abstract void WriteLog(LogRecord record,TransportSettings settings);
	}
}
