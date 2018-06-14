/******************************************************************************
* Copyright (c) 2007, Damikaa Consulting Services
* All rights reserved.
*
* Redistribution and use in source and binary forms, with or without
* modification, are permitted provided that the following conditions are met:
*     * Redistributions of source code must retain the above copyright
*       notice, this list of conditions and the following disclaimer.
*     * Redistributions in binary form must reproduce the above copyright
*       notice, this list of conditions and the following disclaimer in the
*       documentation and/or other materials provided with the distribution.
*     * Neither Damikaa Consulting Services Inc nor the
*       names of its contributors may be used to endorse or promote products
*       derived from this software without specific prior written permission.
*
* THIS SOFTWARE IS PROVIDED BY Damikaa Consulting Services ``AS IS'' AND ANY
* EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
* WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
* DISCLAIMED. IN NO EVENT SHALL Damikaa Consulting Services BE LIABLE FOR ANY
* DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
* (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
* LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
* ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
* (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
* SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
******************************************************************************/
using System;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Reflection;
using System.Globalization;
using System.Collections;
using System.Collections.Specialized;
using Framework.Logging.Logger.Transports;
using Framework.Logging.Logger.Settings;

namespace Framework.Logging.Logger
{
	/// <summary>
	///		Class: LogManager
	///		
	///		Author: Kevin Jankunas
	///		
	///		Created: 4/8/2003
	///		
	///		Description: LogManager manages the configuration and submittal of logrecords
	///					to the LogServer.  It needs to be Initialized with a
	///					configuration file before first use.  The static methods of this
	///					class are thread safe.
	///		
	///		Comments: 
	/// </summary>
	/// 

	public sealed class LogManager
	{
		//don't allow this class to be created
		private LogManager(){}

		public static Guid CreateLoggingContext()
		{
			return System.Guid.NewGuid();
		}

		public static bool IsLogging(LogLevel logLevel)
		{
			return LoggerSettings.Current.LoggingLevels.IsLogging(logLevel);
		}


		#region WriteTrace

		public static void WriteTrace(string currentUser,object source, string description, string content)
		{
			WriteMessage(currentUser,
				Guid.NewGuid(),
				GetAssemblyName(source),
				GetClassName(source),
				GetMethodName(), 
				LogLevel.LogLevelTrace,
				ContentType.ContentTypeTextPlain,
				description,
				content);
		}

		public static void WriteTrace(string currentUser,object source, string description, string content, ContentType contentType)
		{
			WriteMessage(currentUser,
				Guid.NewGuid(),
				GetAssemblyName(source),
				GetClassName(source),
				GetMethodName(), 
				LogLevel.LogLevelTrace,
				contentType,
				description,
				content);
		}

		public static void WriteTrace(string currentUser,Guid loggingContext, object source, string description, string content)
		{
			WriteMessage(currentUser,
				loggingContext, 
				GetAssemblyName(source),
				GetClassName(source),
				GetMethodName(), 
				LogLevel.LogLevelTrace,
				ContentType.ContentTypeTextPlain,
				description,
				content);
		}

		public static void WriteTrace(string currentUser,Guid loggingContext, object source, string description, string content, ContentType contentType)
		{
			WriteMessage(currentUser,
				loggingContext, 
				GetAssemblyName(source),
				GetClassName(source),
				GetMethodName(), 
				LogLevel.LogLevelTrace,
				contentType,
				description,
				content);
		}

		#endregion


		#region WriteDebug

		public static void WriteDebug(string currentUser,object source, string description, string content)
		{
			WriteMessage(currentUser,
				Guid.NewGuid(),
				GetAssemblyName(source),
				GetClassName(source),
				GetMethodName(), 
				LogLevel.LogLevelDebug,
				ContentType.ContentTypeTextPlain,
				description,
				content);
		}

		public static void WriteDebug(string currentUser,object source, string description, string content, ContentType contentType)
		{
			WriteMessage(currentUser,
				Guid.NewGuid(),
				GetAssemblyName(source),
				GetClassName(source),
				GetMethodName(), 
				LogLevel.LogLevelDebug,
				contentType,
				description,
				content);
		}

		public static void WriteDebug(string currentUser,Guid loggingContext, object source, string description, string content)
		{
			WriteMessage(currentUser,
				loggingContext,
				GetAssemblyName(source),
				GetClassName(source),
				GetMethodName(), 
				LogLevel.LogLevelDebug,
				ContentType.ContentTypeTextPlain,
				description,
				content);
		}

		public static void WriteDebug(string currentUser,Guid loggingContext, object source, string description, string content, ContentType contentType)
		{
			WriteMessage(currentUser,
				loggingContext,
				GetAssemblyName(source),
				GetClassName(source),
				GetMethodName(), 
				LogLevel.LogLevelDebug,
				contentType,
				description,
				content);
		}

		#endregion


		#region WriteInformation

		public static void WriteInformation(string currentUser,object source,  string description, string content)
		{
			WriteMessage(currentUser,
				Guid.NewGuid(),
				GetAssemblyName(source),
				GetClassName(source),
				GetMethodName(), 
				LogLevel.LogLevelInformation,
				ContentType.ContentTypeTextPlain,
				description,
				content);
		}

		public static void WriteInformation(string currentUser,object source, string description, string content, ContentType contentType)
		{
			WriteMessage(currentUser,
				Guid.NewGuid(),
				GetAssemblyName(source),
				GetClassName(source),
				GetMethodName(), 
				LogLevel.LogLevelInformation,
				contentType,
				description,
				content);
		}

		public static void WriteInformation(string currentUser,Guid loggingContext,object source, string description, string content)
		{
			WriteMessage(currentUser,
				loggingContext,
				GetAssemblyName(source),
				GetClassName(source),
				GetMethodName(), 
				LogLevel.LogLevelInformation,
				ContentType.ContentTypeTextPlain,
				description,
				content);
		}

		public static void WriteInformation(string currentUser,Guid loggingContext, object source, string description, string content, ContentType contentType)
		{
			WriteMessage(currentUser,
				loggingContext,
				GetAssemblyName(source),
				GetClassName(source),
				GetMethodName(), 
				LogLevel.LogLevelInformation,
				contentType,
				description,
				content);
		}

		#endregion


		#region WriteWarning


		public static void WriteWarning(string currentUser,object source, string description, string content)
		{
			WriteMessage(currentUser,
				Guid.NewGuid(),
				GetAssemblyName(source),
				GetClassName(source),
				GetMethodName(), 
				LogLevel.LogLevelWarning,
				ContentType.ContentTypeTextPlain,
				description,
				content);
		}

		public static void WriteWarning(string currentUser,object source, string description, string content, ContentType contentType)
		{
			WriteMessage(currentUser,
				Guid.NewGuid(),
				GetAssemblyName(source),
				GetClassName(source),
				GetMethodName(), 
				LogLevel.LogLevelWarning,
				contentType,
				description,
				content);
		}

		public static void WriteWarning(string currentUser,Guid loggingContext, object source, string description, string content)
		{
			WriteMessage(currentUser,
				loggingContext,
				GetAssemblyName(source),
				GetClassName(source),
				GetMethodName(), 
				LogLevel.LogLevelWarning,
				ContentType.ContentTypeTextPlain,
				description,
				content);
		}

		public static void WriteWarning(string currentUser,Guid loggingContext, object source, string description, string content, ContentType contentType)
		{
			WriteMessage(currentUser,
				loggingContext,
				GetAssemblyName(source),
				GetClassName(source),
				GetMethodName(), 
				LogLevel.LogLevelWarning,
				contentType,
				description,
				content);
		}

		#endregion


		#region WriteSuccessAudit

		public static void WriteSuccessAudit(string currentUser,string description)
		{
			LogRecord logRec = new LogRecord();
			logRec.UserLogon = currentUser;
			logRec.LogLevel = LogLevel.LogLevelSuccessAudit;
			logRec.ContentType = ContentType.ContentTypeTextPlain;
			logRec.Description = description;

			WriteMessage(logRec);
		}

		#endregion


		#region WriteFailureAudit

		public static void WriteFailureAudit(string currentUser,string description)
		{
			LogRecord logRec = new LogRecord();
			logRec.UserLogon = currentUser;
			logRec.LogLevel = LogLevel.LogLevelFailureAudit;
			logRec.ContentType = ContentType.ContentTypeTextPlain;
			logRec.Description = description;

			WriteMessage(logRec);
		}

		#endregion


		#region WriteError

		public static void WriteError(string currentUser,object source, string description, string content)
		{
			WriteMessage(currentUser,
				Guid.NewGuid(),
				GetAssemblyName(source),
				GetClassName(source),
				GetMethodName(), 
				LogLevel.LogLevelError,
				ContentType.ContentTypeTextPlain,
				description,
				content);
		}

		public static void WriteError(string currentUser,object source, string description, string content, ContentType contentType)
		{
			WriteMessage(currentUser,
				Guid.NewGuid(),
				GetAssemblyName(source),
				GetClassName(source),
				GetMethodName(), 
				LogLevel.LogLevelError,
				contentType,
				description,
				content);
		}

		public static void WriteError(string currentUser,Guid loggingContext, object source, string description, string content)
		{
			WriteMessage(currentUser,
				loggingContext,
				GetAssemblyName(source),
				GetClassName(source),
				GetMethodName(), 
				LogLevel.LogLevelError,
				ContentType.ContentTypeTextPlain,
				description,
				content);
		}

		public static void WriteError(string currentUser,Guid loggingContext, object source, string description, string content, ContentType contentType)
		{
			WriteMessage(currentUser,
				loggingContext,
				GetAssemblyName(source),
				GetClassName(source),
				GetMethodName(), 
				LogLevel.LogLevelError,
				contentType,
				description,
				content);
		}

		public static void WriteError(string currentUser,object source,System.Exception error)
		{
			WriteMessage(currentUser,
				Guid.NewGuid(),
				GetAssemblyName(source),
				GetClassName(source),
				GetMethodName(), 
				LogLevel.LogLevelError,
				ContentType.ContentTypeException,
                error != null ? error.Message : string.Empty,
                error != null ? ExceptionFormatter.Format(error) : string.Empty);
		}

        public static void WriteError(string currentUser, Guid loggingContext, object source, System.Exception error)
		{
			WriteMessage(currentUser,
				loggingContext,
				GetAssemblyName(source),
				GetClassName(source),
				GetMethodName(), 
				LogLevel.LogLevelError,
				ContentType.ContentTypeException,
                error != null ? error.Message : string.Empty,
                error != null ? ExceptionFormatter.Format(error) : string.Empty);
		}

		public static void WriteError(string currentUser,object source,LogLevel logLevel, System.Exception error)
		{
			WriteMessage(currentUser,
				Guid.NewGuid(),
				GetAssemblyName(source),
				GetClassName(source),
				GetMethodName(), 
				logLevel,
				ContentType.ContentTypeException,
                error != null ? error.Message : string.Empty,
                error != null ? ExceptionFormatter.Format(error) : string.Empty);
		}

		public static void WriteError(string currentUser,Guid loggingContext, object source,LogLevel logLevel, System.Exception error)
		{
			WriteMessage(currentUser,
				loggingContext,
				GetAssemblyName(source),
				GetClassName(source),
				GetMethodName(), 
				logLevel,
				ContentType.ContentTypeException,
                error != null ? error.Message : string.Empty,
                error != null ? ExceptionFormatter.Format(error) : string.Empty);
		}

		public static void WriteError(string currentUser,string assemblyName,string className, string methodName, LogLevel logLevel,System.Exception error)
		{
			WriteMessage(currentUser,
				Guid.NewGuid(),
				assemblyName,
				className,
				methodName, 
				logLevel,
				ContentType.ContentTypeException,
                error != null ? error.Message : string.Empty,
                error != null ? ExceptionFormatter.Format(error) : string.Empty);
		}

		public static void WriteError(string currentUser,Guid loggingContext, string assemblyName,string className, string methodName, LogLevel logLevel,System.Exception error)
		{
			WriteMessage(currentUser,
				loggingContext,
				assemblyName,
				className,
				methodName, 
				logLevel,
				ContentType.ContentTypeException,
                error != null ? error.Message : string.Empty,
                error != null ? ExceptionFormatter.Format(error) : string.Empty);
        }

		#endregion


		#region WriteMessage

		public static void WriteMessage(string currentUser,object source, LogLevel logLevel, ContentType contentType,string description, string content)
		{
			WriteMessage(currentUser,
				Guid.NewGuid(),
				GetAssemblyName(source),
				GetClassName(source),
				GetMethodName(), 
				logLevel,
				contentType,
				description,
				content);
		}

		public static void WriteMessage(string currentUser,Guid loggingContext, object source, LogLevel logLevel, ContentType contentType,string description, string content)
		{
			WriteMessage(currentUser,
				loggingContext,
				GetAssemblyName(source),
				GetClassName(source),
				GetMethodName(), 
				logLevel,
				contentType,
				description,
				content);
		}

      public static void WriteMessage(string currentUser,string assemblyName,string className, string methodName, LogLevel logLevel, ContentType contentType,string description, string content)
      {
		  WriteMessage(currentUser,
			  Guid.NewGuid(),
            assemblyName,
            className,
            methodName,
            logLevel,
            contentType,
            description,
            content);
      }

		public static void WriteMessage(string currentUser, Guid loggingContext, string assemblyName,string className, string methodName, LogLevel logLevel, ContentType contentType,string description, string content)
		{
			LogRecord oLogRec = new LogRecord();
			oLogRec.UserLogon = currentUser;
			oLogRec.LoggingContextGUID = loggingContext;
			oLogRec.ContentType = contentType;
			oLogRec.LogLevel = logLevel;
			oLogRec.Source = assemblyName != null ? assemblyName : string.Empty;
			oLogRec.ClassName = className != null ? className : string.Empty;
			oLogRec.MethodName = methodName != null ? methodName : string.Empty;
			oLogRec.Description = description != null ? description : string.Empty;
			oLogRec.Content = content != null ? content : string.Empty;
			WriteMessage(oLogRec);
		}

        public static void WriteMessage(LogRecord logRecord)
		{
            if (logRecord == null)
                throw new ArgumentNullException("logRecord");

			//determine if we should log anything
            if (LoggerSettings.Current.LoggingLevels.IsLogging(logRecord.LogLevel) == false)
			{
				return;
			}

            logRecord.ApplicationId = LoggerSettings.Current.ApplicationId;

			for(int i = 0; i < LoggerSettings.Current.Transports.Length; i++)
			{
				TransportSettings transportSettings = LoggerSettings.Current.Transports[i];

                if (transportSettings.LoggingLevels.IsLogging(logRecord.LogLevel) == true)
				{
					try
					{
						LoggerTransport transport = GetTransport(transportSettings);
                        transport.WriteLog(logRecord, transportSettings);
					}
					catch(Exception ex)
					{
                        ProcessTransportFailure(ex, transportSettings, logRecord);
					}
				}
			}
		}

		#endregion


		#region Private Methods

		private static void ProcessTransportFailure(Exception ex,TransportSettings transport,LogRecord logRec)
		{
			string error = string.Empty;

			try
			{
				error = string.Format(CultureInfo.CurrentCulture,ResourceData.LoggerTransportFailed,transport.TransportType,logRec.LogGUID);
                error += ex.ToString();

				if(LoggerSettings.Current.LogFailuresToDisk == true)
				{ 
					LogToDisk(LoggerSettings.Current.FailurePath,logRec);
                    string persistedMessage = string.Format(CultureInfo.CurrentCulture, ResourceData.LogRecordPersistedToDisk, LoggerSettings.Current.FailurePath);
					error += persistedMessage;
				}
					
				EventLog.WriteEntry(LoggerSettings.EventSourceName,error,EventLogEntryType.Error);
			}
			catch(Exception internalEx)
			{
				string internalError = string.Format(CultureInfo.CurrentCulture,ResourceData.LoggerTriedPersistingFile,LoggerSettings.Current.FailurePath,internalEx.ToString());
				error += internalError;

				try
				{
                    EventLog.WriteEntry(LoggerSettings.EventSourceName, error, EventLogEntryType.Error);
				}
				catch(Exception innerInnerEx)
				{
                    throw new LoggerException(string.Format(CultureInfo.CurrentCulture, ResourceData.ErrorWritingToSystemEventLog + error), innerInnerEx);
				}
			}
		}

		private static LoggerTransport GetTransport(TransportSettings transportSetting)
		{
            string transportName = transportSetting.TransportType;

            if(string.IsNullOrEmpty(transportName))
                throw new LoggerException(string.Format(CultureInfo.CurrentCulture, ResourceData.InvalidTransportType));

			//TODO change this to a provider interface
            //transportName converted to lower during load of settings
            switch (transportName)
			{
				case "msmq":
					return new MSMQTransport();
				case "nteventlog":
					return new NTEventLogTransport();
				case "webservice":
					return new WebServiceTransport();
				case "remoting":
					return new RemotingTransport();
				case "logfile":
					return new LogFileTransport();
                case "sql":
                    return new SQLTransport();
                case "smtp":
                    return new SMTPTransport();
				default:
					throw new LoggerException(string.Format(CultureInfo.CurrentCulture,ResourceData.InvalidTransportType,transportName));
			}
		}

		private static string GetMethodName()
		{
			//get the calling method from 2 stack frames up.
			StackTrace st = new StackTrace(true);
			StackFrame sf = st.GetFrame(st.FrameCount >= 2 ? 2 : 0); 
			MethodBase mb = sf.GetMethod();
			return mb.Name;
		}
		
		private static string GetAssemblyName(object obj)
		{
			if(obj != null)
			{
				System.Type oType = obj.GetType();
				Assembly oAssem = oType.Assembly;
				AssemblyName oAssemName = oAssem.GetName();
				return oAssemName.Name;
			}

			return "";
		}

		private static string GetClassName(object obj)
		{
			if(obj != null)
			{
				System.Type type = obj.GetType();
                return type.Name;
			}

			return "";
		}

		private static void LogToDisk(string failedPath, LogRecord logRec)
		{
			if(Directory.Exists(failedPath) == false)
			{
				Directory.CreateDirectory(failedPath);
			}
			
			string dirPath = failedPath;

			int slashIndex = dirPath.LastIndexOf("\\");
			if(slashIndex != dirPath.Length - 1)
			{
				dirPath += "\\";
			}

			TextWriter writer = new StreamWriter(dirPath + "\\" + logRec.LogGUID + ".xml");
			XmlSerializer serializer = new XmlSerializer(typeof(LogRecord));
			serializer.Serialize(writer,logRec);
			writer.Close();
		}

		#endregion

	}
}
