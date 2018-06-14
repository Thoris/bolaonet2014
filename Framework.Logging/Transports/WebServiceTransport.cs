using System;
using Framework.Logging.Logger;
using Framework.Logging.Logger.Settings;

namespace Framework.Logging.Logger.Transports
{
	/// <summary>
	/// Summary description for WebServiceTransport.
	/// </summary>
	internal class WebServiceTransport : LoggerTransport
	{
		public WebServiceTransport(){}

		public override void WriteLog(LogRecord record,TransportSettings settings)
		{
            throw new NotImplementedException();
		}
	}
}
