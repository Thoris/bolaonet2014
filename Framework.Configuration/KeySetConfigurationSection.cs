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
using System.Xml;
using System.Configuration;
using System.Reflection;

namespace Framework.Configuration
{
    /// <summary>
    ///		Class: KeySetConfigurationSection
    ///	
    ///		Author: Kevin Jankunas
    ///		
    ///		Created: 11/21/2007
    ///		
    ///		Description: Derives from the System.Configuration.ConfigurationSection class
    ///		and overrides the DeserializeElement function
    ///		
    ///		Comments: 	
    /// </summary>
    public sealed class KeySetConfigurationSection : System.Configuration.ConfigurationSection
    {
        private KeySet _rootKeySet = null;

        private const string ROOTNODE = "./Keyset";

        public KeySetConfigurationSection() { }

        public KeySet RootKeySet
        {
            get { return _rootKeySet; }
        }

        public override bool IsReadOnly()
        {
            return true; //updates not supported
        }

        protected override void DeserializeElement(XmlReader reader, bool serializeCollectionKey)
        {
            try
            {
                if (reader == null)
                {
                    throw (new ArgumentNullException("reader", string.Format(ResourceData.Culture, ResourceData.MissingConfigSection)));
                }

                XmlDocument doc = new XmlDocument();
                doc.Load(reader);

                XmlNodeList nodes = doc.DocumentElement.SelectNodes(ROOTNODE);
                if ((nodes.Count != 1))
                {
                    throw (new KeySetConfigurationException(string.Format(ResourceData.Culture, ResourceData.MissingConfigSectionRootKeySet)));
                }

               _rootKeySet = new KeySet(nodes[0]);

            }
            catch (Exception ex)
            {
                throw (new KeySetConfigurationException(string.Format(ResourceData.Culture, ResourceData.FailedToLoadConfiguration), ex));
            }
        }

    }
}
