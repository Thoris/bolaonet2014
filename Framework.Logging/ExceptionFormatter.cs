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
using System.Globalization;
using System.Xml;

namespace Framework.Logging.Logger
{
	/// <summary>
	///		Class: ExceptionFormatter
	///		
	///		Author: Kevin Jankunas
	///		
	///		Created: 4/8/2003
	///		
	///		Description: Converts .NET exceptions to an Xml String
	///		
	///		Comments: 
	/// </summary>
	/// 
	internal sealed class ExceptionFormatter
	{
		private ExceptionFormatter(){}

		public static string Format(System.Exception e)
		{
			XmlDocument doc = ExceptionToXml(e,null);
			return doc.InnerXml;
		}

		private static XmlDocument ExceptionToXml(System.Exception e,XmlElement parentElement)
		{

			XmlDocument xmlDoc = null;

			if(parentElement == null)
			{
				xmlDoc = new XmlDocument();
				xmlDoc.LoadXml("<Exception/>");
				parentElement = xmlDoc.DocumentElement;
			}

			CreateElement(parentElement,"Message",e.Message);
			CreateElement(parentElement,"Source",e.Source);
			CreateElement(parentElement,"StackTrace",e.StackTrace);
			if(e.TargetSite != null)
			{
				CreateElement(parentElement,"MethodName",e.TargetSite.Name);
				CreateElement(parentElement,"ClassName",e.TargetSite.DeclaringType.Name);
				CreateElement(parentElement,"Source",e.TargetSite.DeclaringType.Assembly.ToString());
			}
			CreateElement(parentElement,"ThreadId",System.Threading.Thread.CurrentThread.GetHashCode().ToString(CultureInfo.InvariantCulture));
			XmlElement innerException = CreateElement(parentElement,"InnerException",null);
			if(e.InnerException != null)
			{
				ExceptionToXml(e.InnerException,innerException);
			}

			return xmlDoc;
		}

		private static XmlElement CreateElement(XmlElement parent,string elementName, string elementValue)
		{
			XmlElement element = parent.OwnerDocument.CreateElement(elementName);
			if(elementValue != null)
			{
				element.InnerText = elementValue;
			}
			parent.AppendChild(element);
			return element;
		}

	}
}
