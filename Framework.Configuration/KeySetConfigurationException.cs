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
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;


namespace Framework.Configuration
{
    /// <summary>
    ///		Class: Key
    ///		
    ///		Author: Kevin Jankunas
    ///		
    ///		Created: 4/15/2003
    ///		
    ///		Description: Exception that is thrown when there is a 
    ///     problem with configuring (loading) Keyset information.
    ///		
    ///		Comments: 
    /// </summary>
    /// 
    [Serializable]
    public class KeySetConfigurationException : Exception
    {
        public KeySetConfigurationException() { }
        public KeySetConfigurationException(string message) : base(message) { }
        public KeySetConfigurationException(string message, Exception inner) : base(message, inner) { }
        protected KeySetConfigurationException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
