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
using System.Collections;
using System.Globalization;
using System.Runtime.Serialization;

namespace Framework.Configuration
{
	/// <summary>
    ///		Class: KeySetCollection
	///		
	///		Author: Kevin Jankunas
	///		
	///		Created: 4/15/2003
	///		
	///		Description: Typesafe collection of KeySet class.
	///		
	///		Comments: 
	/// </summary>
	/// 
    public sealed class KeySetCollection : CollectionBase, IList<KeySet>
	{
        public KeySetCollection() { }

		public void Add(KeySet keySet)
		{
            List.Add(keySet);
		}
		
		public void Remove(int index)
		{
			List.RemoveAt(index); 
		}

		public KeySet this[int index]
		{
			get{return (KeySet)List[index];}
			set{List[index] = value;}
		}

		public KeySet this[string name]
		{
			get
			{
				KeySet keyset = null;
				if(!string.IsNullOrEmpty(name))
				{
					for(int i = 0; i < Count; i++)
					{
						keyset = (KeySet)List[i];
						if(string.Compare(keyset.Name,name,true,CultureInfo.InvariantCulture) == 0)
						{
							break;
						}
						keyset = null;
					}
				}
				if(keyset == null)
				{
                    throw (new KeySetDoesNotExistException(string.Format(ResourceData.Culture, ResourceData.KeySetDoesNotExist, name)));
				}

				return keyset;
			}
			set
			{
                if (!string.IsNullOrEmpty(name))
				{
					for(int i = 0; i < Count; i++)
					{
						KeySet keyset = (KeySet)List[i];
						if(string.Compare(keyset.Name,name,true,CultureInfo.InvariantCulture) == 0)
						{
							List[i] = value;
							return;
						}
					}
				}
                throw (new KeySetDoesNotExistException(string.Format(ResourceData.Culture, ResourceData.KeySetDoesNotExist, name)));
			}
		}

		public bool Exists(string name)
		{
			KeySet keySet = null;
            if (!string.IsNullOrEmpty(name))
			{
				for(int i = 0; i < Count; i++)
				{
					keySet = (KeySet)List[i];
					if(string.Compare(keySet.Name,name,true,CultureInfo.InvariantCulture) == 0)
					{
						return true;
					}
					keySet = null;
				}
			}
			
			return false;
		}

        #region IList<KeySet> Members

        int IList<KeySet>.IndexOf(KeySet item)
        {
            return InnerList.IndexOf(item);
        }

        void IList<KeySet>.Insert(int index, KeySet item)
        {
            InnerList.Insert(index, item);
        }

        void IList<KeySet>.RemoveAt(int index)
        {
            InnerList.RemoveAt(index);
        }

        KeySet IList<KeySet>.this[int index]
        {
            get
            {
                return (KeySet)InnerList[index];
            }
            set
            {
                InnerList[index] = value;
            }
        }

        #endregion

        #region ICollection<KeySet> Members

        void ICollection<KeySet>.Add(KeySet item)
        {
            InnerList.Add(item);
        }

        void ICollection<KeySet>.Clear()
        {
            InnerList.Clear();
        }

        bool ICollection<KeySet>.Contains(KeySet item)
        {
            return InnerList.Contains(item);
        }

        void ICollection<KeySet>.CopyTo(KeySet[] array, int arrayIndex)
        {
            InnerList.CopyTo(array, arrayIndex);
        }

        int ICollection<KeySet>.Count
        {
            get { return InnerList.Count; }
        }

        bool ICollection<KeySet>.IsReadOnly
        {
            get { return InnerList.IsReadOnly; }
        }

        bool ICollection<KeySet>.Remove(KeySet item)
        {
            if (InnerList.Contains(item))
            {
                InnerList.Remove(item);
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region IEnumerable<KeySet> Members

        IEnumerator<KeySet> IEnumerable<KeySet>.GetEnumerator()
        {
            return new KeySetCollectionEnumerator(InnerList.GetEnumerator());
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return InnerList.GetEnumerator();
        }

        #endregion
    }
}
