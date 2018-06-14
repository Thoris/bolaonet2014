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
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Serialization;
using System.Text;

namespace Framework.Configuration
{
	/// <summary>
	///		Class: KeySet
	///		
	///		Author: Kevin Jankunas
	///		
	///		Created: 4/15/2003
	///		
	///		Description: Represents a single Keyset from a configuration provider.
	///					Can hold both Keys and KeySetCollection.
	///		
	///		Comments: 
	/// </summary>
	/// 
	[System.Xml.Serialization.XmlRootAttribute("Keyset")]
    public sealed class KeySet
	{
		const string KEYSET_NODE_NAME = "Keyset";
		const string KEYSET_XPATH = "./Keyset";
		const string KEY_XPATH = "./Key";
		const string KEYSET_NAME_ATTRIBUTE = "name";

        private KeySetCollection _keySets = new KeySetCollection();
        private KeyCollection _keys = new KeyCollection();
		private string _name = string.Empty;
		
		public KeySet(){}

		public KeySet(string name)
		{
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");

			_name = name;
		}

		public KeySet(IXPathNavigable node)
		{
            if (node == null)
                throw new ArgumentNullException("node");

            XPathNavigator navigator = node.CreateNavigator();

            _name = navigator.GetAttribute(KEYSET_NAME_ATTRIBUTE, string.Empty);

            if (navigator.Name.Equals(KEYSET_NODE_NAME) == false)
			{
                throw new KeySetConfigurationException(string.Format(ResourceData.Culture, ResourceData.InvalidConfigurationFile));
			}

			//get all keys 
            XPathNodeIterator keys = navigator.Select(KEY_XPATH);
			while(keys.MoveNext())
			{
                _keys.Add(new Key(keys.Current));
			}

			//get all keysets 
            XPathNodeIterator keysets = navigator.Select(KEYSET_XPATH);
            while (keysets.MoveNext())
            {
                _keySets.Add(new KeySet(keysets.Current));
			}
		
		}

		[System.Xml.Serialization.XmlAttributeAttribute("name")]
		public string Name
		{
			get{return _name;}
			set{_name = value;}
		}

		[System.Xml.Serialization.XmlElement("Keyset")]
        public KeySetCollection KeySets
		{
			get{return _keySets;}
			set{_keySets = value;}
        }

		[System.Xml.Serialization.XmlElement("Key")]
        public KeyCollection Keys
		{
			get{return _keys;}
			set{_keys = value;}
		}


		public Key GetKey(string path, char delimiter)
		{
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException("path");

            if (delimiter == 0)
                throw new ArgumentNullException("delimiter");

			string[] sPath = path.Split(new char[]{delimiter});
			KeySet oKeySet = this;

			for(int i = 0; i < sPath.Length; i++)
			{
				if(i < sPath.Length - 1)
				{
					oKeySet = oKeySet.KeySets[sPath[i]];
				}
				else
				{
					return oKeySet.Keys[sPath[i]];
				}
			}

			return null;
		}

		public KeySet GetKeySet(string path, char delimiter)
		{
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException("path");

            if (delimiter == 0)
                throw new ArgumentNullException("delimiter");

			string[] sPath = path.Split(new char[]{delimiter});
			KeySet oKeySet = this;

			for(int i = 0; i < sPath.Length; i++)
			{
				if(i < sPath.Length - 1)
				{
					oKeySet = oKeySet.KeySets[sPath[i]];
				}
				else
				{
					return oKeySet.KeySets[sPath[i]];
				}
			}

			return null;
		}


	}
}
