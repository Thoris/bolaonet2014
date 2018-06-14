using System;
using System.Globalization;
using System.Collections;
using Framework.Configuration;

namespace Framework.Logging.Logger.Settings
{
	/// <summary>
	///		Class: TransportSettings
	///		
	///		Author: Kevin Jankunas
	///		
	///		Created: 4/8/2003
	///		
	///		Description: Provides Transport Level settings
	///		
	///		Comments: 
	/// </summary>
	/// 
	internal class TransportSettings
	{
        private LogLevelSettings _loggingLevels;
        private string _transportType = string.Empty;
        private Hashtable _configs = new Hashtable(StringComparer.InvariantCultureIgnoreCase);

		public TransportSettings(KeySet transportKeySet)
		{
            if (transportKeySet == null)
                throw new ArgumentNullException("transportKeySet");

            if (string.IsNullOrEmpty(transportKeySet.Name))
                throw new LoggerException(string.Format(CultureInfo.CurrentCulture,ResourceData.InvalidTransportType,""));

            _transportType = transportKeySet.Name.Trim().ToLowerInvariant();
			_loggingLevels = new LogLevelSettings(transportKeySet);

			for(int i = 0; i < transportKeySet.Keys.Count; i++)
			{
				_configs.Add(transportKeySet.Keys[i].Name,transportKeySet.Keys[i].Value);
			}
		}

		public string TransportType
		{
			get{return _transportType;}
		}

		public Hashtable Configs
		{
			get{return _configs;}
		}

		public LogLevelSettings LoggingLevels
		{
			get{return _loggingLevels;}
		}
	}

}
