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

namespace Framework.Logging.Logger
{
	/// <summary>
	///		Class: LogManager
	///		
	///		Author: Kevin Jankunas
	///		
	///		Created: 5/16/2003
	///		
	///		Description: LoggerTraceListener derives from the abstract
	///					class TraceListener of the .NET Framework.  It listens for
	///					trace messages and submits them to the Log Server.
	///		
	///		Comments: 
	/// </summary>
	/// 
	public class LoggerTraceListener : TraceListener
	{
		public LoggerTraceListener(){}

		//WriteLine overrides
        public override void WriteLine(object o)
        {
            if (o == null)
                throw new ArgumentNullException("o");

            LogManager.WriteTrace("",null,"",o.ToString());
        }

		public override void WriteLine(string message)
		{
            if (string.IsNullOrEmpty(message))
                return;

			LogManager.WriteTrace("",null,"",message);
		}

		public override void WriteLine(object o, string category)
		{
            if (o == null)
                throw new ArgumentNullException("o");

            LogManager.WriteTrace("", null, category, o.ToString());
		}

		public override void WriteLine(string message,string category)
		{
			LogManager.WriteTrace("",null,category,message);
		}
		//End WriteLine overrides

		//Write overrides
		public override void Write(object o)
        {
            if (o == null)
                throw new ArgumentNullException("o");

            LogManager.WriteTrace("", null, "", o.ToString());
		}

		public override void Write(string message)
		{
			LogManager.WriteTrace("",null,"",message);
		}

		public override void Write(object o, string category)
        {
            if (o == null)
                throw new ArgumentNullException("o");

            LogManager.WriteTrace("", null, category, o.ToString());
		}

		public override void Write(string message,string category)
		{
			LogManager.WriteTrace("",null,category,message);
		}
		//End Write overrides

	}
}
