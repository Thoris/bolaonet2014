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
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using System.Configuration;
using System.Threading;
using System.Collections;
using System.Globalization;
using System.Runtime.Serialization;

namespace Framework.Configuration
{
    /// <summary>
    ///		Class: KeySetConfiguration
    ///		
    ///		Author: Kevin Jankunas
    ///		
    ///		Created: 4/15/2003
    ///		
    ///		Description: Used for loading saving and retrieving
    ///					Keys and KeySets.  This and all other classes in this Assembly are 
    ///					NOT thread safe.
    ///		
    ///		Comments: 
    /// </summary>
    /// 

    public sealed class KeySetConfiguration
    {
        private KeySetConfiguration() { }

        /// <summary>
        /// Returns the root keyset for a given configuration section
        /// </summary>
        /// <param name="sectionName">configuration section name</param>
        /// <returns></returns>
        public static KeySet Config(string sectionName)
        {
            if (string.IsNullOrEmpty(sectionName))
                throw new ArgumentNullException("sectionName");

            KeySet config = ConfigurationManager.GetSection(sectionName) as KeySet;

            return config;
        }

        /// <summary>
        /// Deserializes and XML Keyset document.
        /// </summary>
        /// <param name="dataIn">UTF-16 Encoded xml document</param>
        /// <returns></returns>
        public static KeySet Deserialize(string dataIn)
        {
            if (string.IsNullOrEmpty(dataIn))
                throw new ArgumentNullException("dataIn");

            using (MemoryStream oStream = new MemoryStream(Encoding.Unicode.GetBytes(dataIn)))
            {
                return Deserialize(oStream);
            }
        }

        /// <summary>
        /// Deserializes an XML Keyset document given from a stream
        /// </summary>
        /// <param name="dataIn">An initilzied stream object</param>
        /// <returns></returns>
        public static KeySet Deserialize(Stream dataIn)
        {
            if (dataIn == null)
                throw new ArgumentNullException("dataIn");

            XmlSerializer oSerializer = new XmlSerializer(typeof(KeySet));
            KeySet keySetData = (KeySet)oSerializer.Deserialize(dataIn);
            return keySetData;
        }

        /// <summary>
        /// Serializes a Keyset object to a UTF-16 encoded XML document
        /// </summary>
        /// <param name="keySetData">Keyset object to serialize</param>
        /// <returns></returns>
        public static string Serialize(KeySet keySetData)
        {
            if (keySetData == null)
                throw new ArgumentNullException("keySetData");

            using (MemoryStream oStream = new MemoryStream())
            {
                Serialize(keySetData, oStream);
                oStream.Seek(0, SeekOrigin.Begin);
                XmlTextReader oReader = new XmlTextReader(oStream);
                while (oReader.Read() == true && oReader.NodeType != XmlNodeType.Element) { }
                return oReader.ReadOuterXml();
            }
        }

        /// <summary>
        /// Serializes a Keyset object to a UTF-16 encoded xml document
        /// </summary>
        /// <param name="keySetData">Keyset object to serialize</param>
        /// <param name="dataOut">Stream to serialized to Keyset to</param>
        public static void Serialize(KeySet keySetData, Stream dataOut)
        {
            if (keySetData == null)
                throw new ArgumentNullException("keySetData");

            if (dataOut == null)
                throw new ArgumentNullException("dataOut");

            XmlWriter oWriter = new XmlTextWriter(dataOut, Encoding.Unicode);
            XmlSerializer oSerializer = new XmlSerializer(typeof(KeySet));
            oSerializer.Serialize(oWriter, keySetData);
        }

        /// <summary>
        /// Loads a Keyset from file.  The file needs to be a UTF-16 encoded
        /// XML file.
        /// </summary>
        /// <param name="filePath">Fully qualified path to the XML document</param>
        /// <returns>Root Keyset contained in the XML document</returns>
        public static KeySet Load(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException("filePath");

            FileStream oStream = null;
            try
            {
                oStream = new FileStream(filePath, FileMode.Open);
                return Deserialize(oStream);
            }
            finally
            {
                if (oStream != null)
                {
                    oStream.Close();
                }
            }
        }

        /// <summary>
        /// Saves a Keyset object to the a UTF-16 encoded xml file.
        /// </summary>
        /// <param name="filePath">Fully qualified path to save the XML document to</param>
        /// <param name="keySetData">The Keyset to persist to the document</param>
        public static void Save(string filePath, KeySet keySetData)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException("filePath");

            if (keySetData == null)
                throw new ArgumentNullException("keySetData");

            FileStream oStream = null;
            try
            {
                oStream = new FileStream(filePath, FileMode.Create);
                Serialize(keySetData, oStream);
            }
            finally
            {
                if (oStream != null)
                {
                    oStream.Close();
                }
            }
        }
    }
}
