using System;
using System.IO;
using System.Globalization;
using Framework.Logging.Logger;
using Framework.Logging.Logger.Settings;

namespace Framework.Logging.Logger.Transports
{
	/// <summary>
	/// Summary description for LogFileTransport.
	/// </summary>
	internal class LogFileTransport : LoggerTransport
	{
		private const string LOGFILEDIR_KEY = "logfiledirectory";
		private const string LOG_FILE_EXT = ".xml";


		public LogFileTransport(){}

		public override void WriteLog(LogRecord record,TransportSettings settings)
		{
			string sLogRecord = record.ToString().Trim();
			string sDirPath = settings.Configs[LOGFILEDIR_KEY].ToString();

			if(sDirPath == null || sDirPath.Length <= 2)
                throw new LoggerException(string.Format(CultureInfo.CurrentCulture, ResourceData.ConfigurationKeyDoesNotExist, LOGFILEDIR_KEY));

			int iSlashIndex = sDirPath.LastIndexOf("\\");
			if(iSlashIndex != sDirPath.Length - 1)
			{
				sDirPath += "\\";
			}

			if(Directory.Exists(sDirPath) == false)
			{
				Directory.CreateDirectory(sDirPath);
			}

			string sLogPath = sDirPath + record.LogGUID.ToString() + LOG_FILE_EXT;

			StreamWriter writer = null;

			try
			{
				writer = new StreamWriter(sLogPath,false,System.Text.UTF8Encoding.UTF8);
				writer.Write(sLogRecord);
				writer.Close();
			}
			finally
			{
				if(writer != null)
					writer.Close();
			}
		}

	}
}
