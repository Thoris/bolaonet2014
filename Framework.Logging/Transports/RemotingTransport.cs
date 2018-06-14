using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using Framework.Logging.Logger;
using Framework.Logging.Logger.Settings;

namespace Framework.Logging.Logger.Transports
{
	/// <summary>
	/// Summary description for RemotingTransport.
	/// </summary>
	internal class RemotingTransport : LoggerTransport
	{
		private const string REMOTE_LOGMANAGER_URL_KEY = "remoteobjecturl";

		public RemotingTransport(){}

		public override void WriteLog(LogRecord record,TransportSettings settings)
		{
			string sObjectUrl = settings.Configs[REMOTE_LOGMANAGER_URL_KEY] as string;

			//"tcp://localhost:8082/HelloServiceApplication/MyUri"
			IRemoteLogManager logManager = (IRemoteLogManager)Activator.GetObject(typeof(IRemoteLogManager),sObjectUrl);
			logManager.WriteMessage(record);
		}
	}
}
