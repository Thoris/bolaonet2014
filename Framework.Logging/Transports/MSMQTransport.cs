using System;
using System.Globalization;
using System.Messaging;
using Framework.Logging.Logger;
using Framework.Logging.Logger.Settings;

namespace Framework.Logging.Logger.Transports
{
	/// <summary>
	/// Summary description for MSMQTransport.
	/// </summary>
	internal class MSMQTransport : LoggerTransport
	{
		private const string QUEUUEPATH_KEY = "queuepath";

		public MSMQTransport(){}

		public override void WriteLog(LogRecord record,TransportSettings settings)
		{
			string path =  settings.Configs[QUEUUEPATH_KEY] as string;

			MessageQueueTransaction tran = null;
			MessageQueue queue = new MessageQueue();

			try
			{
				if(path.ToLowerInvariant().IndexOf("direct=") != -1)
				{
					queue.Path = "FormatName:" + path;
				}
				else
				{
					queue.Path = "FormatName:DIRECT=OS:" + path;
				}
				
				tran = new MessageQueueTransaction();
				tran.Begin();
				queue.Send(record,tran);
				tran.Commit();
			}
			catch(Exception e)
			{
				if(tran != null)
				{
					tran.Abort();					
				}

                throw new LoggerException(string.Format(CultureInfo.CurrentCulture, ResourceData.WriteMessageToEndpointFailed, path), e);
			}
		}
	}
}
