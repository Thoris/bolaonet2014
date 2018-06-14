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
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Framework.Logging.Logger
{
	/// <summary>
	///		Class: LogRecord
	///		
	///		Author: Kevin Jankunas
	///		
	///		Created: 4/8/2003
	///		
	///		Description: Encapsulates the data for logging a message.  The Instance methods of this
	///		class are NOT thread safe.
	///		
	///		Comments: 
	/// </summary>
	/// 

	[Serializable()]
	public class LogRecord
	{
		private string _className = string.Empty;
		private string _methodName = string.Empty;
		private string _source = string.Empty;
		private int _applicationId;
		private string _description = string.Empty;
		private string _content = string.Empty;
		private string _referenceId = string.Empty;
		private string _computerName = System.Environment.MachineName;
		private string _userLogon = string.Empty;
		private Guid _logGUID = System.Guid.NewGuid();
		private Guid _loggingContextGUID = System.Guid.NewGuid();
		private DateTime _timeStamp = DateTime.Now;
		private LogLevel _logLevel = LogLevel.LogLevelDebug;
		private ContentType _contentType = ContentType.ContentTypeTextPlain;

		public LogRecord(){}

		[System.Xml.Serialization.XmlAttributeAttribute]
		public string ClassName
		{
			get{return _className;}
			set{_className = value;}
		}

		[System.Xml.Serialization.XmlAttributeAttribute]
		public string MethodName
		{
			get{return _methodName;}
			set{_methodName = value;}
		}

		[System.Xml.Serialization.XmlAttributeAttribute]
		public string Source
		{
			get{return _source;}
			set{_source = value;}
		}

		[System.Xml.Serialization.XmlAttributeAttribute]
		public int ApplicationId
		{
			get{return _applicationId;}
			set{_applicationId = value;}
		}

		[System.Xml.Serialization.XmlElementAttribute]
		public string Description
		{
			get{return _description;}
			set{_description = value;}
		}

		[System.Xml.Serialization.XmlElementAttribute]
		public string Content
		{
			get{return _content;}
			set{_content = value;}
		}

		[System.Xml.Serialization.XmlAttributeAttribute]
		public string ReferenceId
		{
			get{return _referenceId;}
			set{_referenceId = value;}
		}

		[System.Xml.Serialization.XmlAttributeAttribute]
		public string ComputerName
		{
			get{return _computerName;}
			set{_computerName = value;}
		}

		[System.Xml.Serialization.XmlAttributeAttribute]
		public string UserLogon
		{
			get{return _userLogon;}
			set{_userLogon = value;}
		}

		[System.Xml.Serialization.XmlAttributeAttribute]
		public Guid LogGUID
		{
			get{return _logGUID;}
			set{_logGUID = value;}
		}

		[System.Xml.Serialization.XmlAttributeAttribute]
		public Guid LoggingContextGUID
		{
			get{return _loggingContextGUID;}
			set{_loggingContextGUID = value;}
		}

		[System.Xml.Serialization.XmlAttributeAttribute]
		public DateTime TimeStamp
		{
			get{return _timeStamp;}
			set{_timeStamp = value;}
		}

		[System.Xml.Serialization.XmlAttributeAttribute]
		public LogLevel LogLevel
		{
			get{return _logLevel;}
			set{_logLevel = value;}
		}

		[System.Xml.Serialization.XmlAttributeAttribute]
		public ContentType ContentType
		{
			get{return _contentType;}
			set{_contentType = value;}
		}

		public override string ToString()
		{
			return Serialize(this);
		}

		private static string Serialize(LogRecord rec)
		{
			using(MemoryStream oStream = new MemoryStream())
			{
				XmlTextWriter oXmlWriter = new XmlTextWriter(oStream,System.Text.UTF8Encoding.UTF8);
				oXmlWriter.Formatting = Formatting.Indented;
				XmlSerializer oSerializer = new XmlSerializer(typeof(LogRecord));
				oSerializer.Serialize(oXmlWriter,rec);
				oStream.Seek(0,SeekOrigin.Begin);
				string sOutput = System.Text.UTF8Encoding.UTF8.GetString(oStream.GetBuffer());
				return sOutput;
			}
		}

	}
}
