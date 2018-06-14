/******************************************************************************
* Copyright (c) 2007, Damikaa Consulting Group
* All rights reserved.
*
* Redistribution and use in source and binary forms, with or without
* modification, are permitted provided that the following conditions are met:
*     * Redistributions of source code must retain the above copyright
*       notice, this list of conditions and the following disclaimer.
*     * Redistributions in binary form must reproduce the above copyright
*       notice, this list of conditions and the following disclaimer in the
*       documentation and/or other materials provided with the distribution.
*     * Neither Damikaa Consulting Group Inc nor the
*       names of its contributors may be used to endorse or promote products
*       derived from this software without specific prior written permission.
*
* THIS SOFTWARE IS PROVIDED BY Damikaa Consulting Group ``AS IS'' AND ANY
* EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
* WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
* DISCLAIMED. IN NO EVENT SHALL Damikaa Consulting Group BE LIABLE FOR ANY
* DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
* (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
* LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
* ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
* (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
* SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
******************************************************************************/
using System;
using System.Xml.XPath;
using System.Xml;

namespace Framework.Configuration
{
	/// <summary>
	///		Class: Key
	///		
	///		Author: Kevin Jankunas
	///		
	///		Created: 4/15/2003
	///		
	///		Description: Represents a single key from a configuration provider.
	///		
	///		Comments: 
	/// </summary>
	/// 
	public sealed class Key
	{
		const string KEY_NAME_ATTRIBUTE = "name";
		const string KEY_DATATYPE_ATTRIBUTE = "dataType";

		private string _name = string.Empty;
		private string _value = string.Empty;
		private string _dataType = "string";

        /// <summary>
        /// nitializes a new instance of the Key class
        /// </summary>
		public Key(){}

        /// <summary>
        /// Overloaded. Initializes a new instance of the Key class. 
        /// </summary>
        /// <param name="name">The unique name associated with this key</param>
        /// <param name="value">The value this key will hold</param>
		public Key(string name, string value)
		{
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");

            if (value == null)
                throw new ArgumentNullException("value");

			_name = name;
			_value = value;
		}

        /// <summary>
        /// Initializes a new instance of the Key class 
        /// </summary>
        /// <param name="node">An IXPathNavigable that holds the Key class data</param>
        public Key(IXPathNavigable node)
		{
            if (node == null)
                throw new ArgumentNullException("node");

            XPathNavigator navigator = node.CreateNavigator();
            _value = navigator.InnerXml;
            _name = navigator.GetAttribute(KEY_NAME_ATTRIBUTE, string.Empty);
            _dataType = navigator.GetAttribute(KEY_DATATYPE_ATTRIBUTE, string.Empty);

		}

        /// <summary>
        /// The unique name of the Key
        /// </summary>
		[System.Xml.Serialization.XmlAttributeAttribute("name")]
		public string Name
		{
			get{return _name;}
			set{_name = value;}
		}

        /// <summary>
        /// The value the Key
        /// </summary>
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value
		{
			get{return _value;}
			set{_value = value;}
		}

        /// <summary>
        /// The data type of the value.  The default is string.
        /// </summary>
		[System.Xml.Serialization.XmlAttributeAttribute("dataType")]
		public string DataType
		{
			get{return _dataType;}
			set{_dataType = value;}
		}

	}
}
