/******************************************************************************
* Copyright (c) 2007, Damikaa Consulting
* All rights reserved.
*
* Redistribution and use in source and binary forms, with or without
* modification, are permitted provided that the following conditions are met:
*     * Redistributions of source code must retain the above copyright
*       notice, this list of conditions and the following disclaimer.
*     * Redistributions in binary form must reproduce the above copyright
*       notice, this list of conditions and the following disclaimer in the
*       documentation and/or other materials provided with the distribution.
*     * Neither Damikaa Consulting Inc nor the
*       names of its contributors may be used to endorse or promote products
*       derived from this software without specific prior written permission.
*
* THIS SOFTWARE IS PROVIDED BY Damikaa Consulting ``AS IS'' AND ANY
* EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
* WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
* DISCLAIMED. IN NO EVENT SHALL Damikaa Consulting BE LIABLE FOR ANY
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
    ///		Class: KeySetConfigurationHandler
    ///		
    ///		Author: Kevin Jankunas
    ///		
    ///		Created: 4/15/2003
    ///		
    ///		Description: Implements IConfigurationSectionHandler for reading
    ///     key and keyset information from a configuration file, 
    ///     such as app.config and web.config.
    ///		
    ///		Comments: 	/// </summary>
    public sealed class KeySetConfigurationHandler : System.Configuration.IConfigurationSectionHandler
	{
        private const string ROOTNODE = "./Keyset";

		public KeySetConfigurationHandler(){}

		#region IConfigurationSectionHandler Implementation

		public object Create ( object parent,
            object configContext, 
			XmlNode section )		
		{
			try
			{
				if( section == null)
				{
					throw(new ArgumentNullException("section",string.Format(ResourceData.Culture,ResourceData.MissingConfigSection)));
				}

                XmlNodeList nodes = section.SelectNodes(ROOTNODE);
				if( (nodes.Count != 1))
				{
                    throw (new KeySetConfigurationException(string.Format(ResourceData.Culture, ResourceData.MissingConfigSectionRootKeySet)));
				}

				KeySet config =	new KeySet(nodes[0]);
							
				return config;
			}
			catch( Exception ex )
			{
                throw (new KeySetConfigurationException(string.Format(ResourceData.Culture, ResourceData.FailedToLoadConfiguration), ex));
			}			
		}
		#endregion

	}
}
