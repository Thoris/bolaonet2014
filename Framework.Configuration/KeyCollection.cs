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
using System.Globalization;
using System.Collections.Generic;
using System.Collections;

namespace Framework.Configuration
{
	/// <summary>
	///		Class: KeyCollection
	///		
	///		Author: Kevin Jankunas
	///		
	///		Created: 4/15/2003
	///		
	///		Description: Type safe collection of Key.
	///		
	///		Comments: 
	/// </summary>
	/// 
    public sealed class KeyCollection : CollectionBase, IList<Key>
	{
        /// <summary>
        /// Default Constructor
        /// </summary>
        public KeyCollection() { }

        /// <summary>
        /// Adds a new Key to the KeyCollection
        /// </summary>
        /// <param name="key"></param>
		public void Add(Key key)
		{
			List.Add(key);
		}
		
        /// <summary>
        /// Removes a key at the specified index.
        /// </summary>
        /// <param name="index"></param>
		public void Remove(int index)
		{
			List.RemoveAt(index); 
		}

        /// <summary>
        /// Returns a key at the specified index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
		public Key this[int index]
		{
			get{return (Key)List[index];}
			set{List[index] = value;}
		}

        /// <summary>
        /// Returns a Key by name.  The name is case sensitive.
        /// </summary>
        /// <param name="name">the name of the Key to return</param>
        /// <returns>The key. If the key does not exist KeyDoesNotExistException will be thrown</returns>
		public Key this[string name]
		{
			get
			{
				Key key = null;
                if (!string.IsNullOrEmpty(name))
				{
					for(int i = 0; i < Count; i++)
					{
						key = (Key)List[i];
                        if (string.Compare(key.Name, name, true, CultureInfo.InvariantCulture) == 0)
						{
							break;
						}
						key = null;
					}
				}

				if(key == null)
				{
					throw(new KeyDoesNotExistException(string.Format(ResourceData.Culture,ResourceData.KeyDoesNotExist,name)));
				}

				return key;
			}
			set
			{
                if (!string.IsNullOrEmpty(name))
				{			
					for(int i = 0; i < Count; i++)
					{
						Key key = (Key)List[i];
						if(string.Compare(key.Name,name,true,CultureInfo.InvariantCulture) == 0)
						{
							List[i] = value;
							return;
						}
					}
				}
                throw (new KeyDoesNotExistException(string.Format(ResourceData.Culture, ResourceData.KeyDoesNotExist, name)));
			}
		}

        /// <summary>
        /// Determine if a specified Key exists.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>returns true if the Key exists otherwise false</returns>
		public bool Exists(string name)
		{
			Key key = null;

            if (!string.IsNullOrEmpty(name))
			{
				for(int i = 0; i < Count; i++)
				{
					key = (Key)List[i];
					if(string.Compare(key.Name,name,true,CultureInfo.InvariantCulture) == 0)
					{
						return true;
					}
					key = null;
				}
			}
			
			return false;
		}

        #region IList<Key> Members

        /// <summary>
        /// Returns the index of the specified Key.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        int IList<Key>.IndexOf(Key item)
        {
            return InnerList.IndexOf(item);
        }

        /// <summary>
        /// Inserts the supplied Key in the specified index position.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        void IList<Key>.Insert(int index, Key item)
        {
            InnerList.Insert(index, item);
        }

        /// <summary>
        /// Removes a Key at the specified index.
        /// </summary>
        /// <param name="index"></param>
        void IList<Key>.RemoveAt(int index)
        {
            InnerList.RemoveAt(index);
        }


        /// <summary>
        /// Returns a Key based on the specified index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        Key IList<Key>.this[int index]
        {
            get
            {
                return (Key)InnerList[index];
            }
            set
            {
                InnerList[index] = value;
            }
        }

        #endregion

        #region ICollection<Key> Members

        /// <summary>
        /// Adds a key to the collection.
        /// </summary>
        /// <param name="item"></param>
        void ICollection<Key>.Add(Key item)
        {
            InnerList.Add(item);
        }

        /// <summary>
        /// Clears all Keys in the collection.
        /// </summary>
        void ICollection<Key>.Clear()
        {
            InnerList.Clear();
        }

        /// <summary>
        /// Determines if the specified Key exists in the collection.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool ICollection<Key>.Contains(Key item)
        {
            return InnerList.Contains(item);
        }

        /// <summary>
        /// Copies an array of Keys to the collection starting at the 
        /// specified index.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        void ICollection<Key>.CopyTo(Key[] array, int arrayIndex)
        {
            InnerList.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Returns the number of Keys in the collection.
        /// </summary>
        int ICollection<Key>.Count
        {
            get { return InnerList.Count; }
        }

        /// <summary>
        /// Returns true or false depending on if the Collection
        /// is ReadOnly.
        /// </summary>
        bool ICollection<Key>.IsReadOnly
        {
            get { return InnerList.IsReadOnly; }
        }

        /// <summary>
        /// Removed the specified Key from the collection.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Returns true if the key was removed otherwise false.  If the Key does
        /// not exist this function will always return false.</returns>
        bool ICollection<Key>.Remove(Key item)
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

        #region IEnumerable<Key> Members

        /// <summary>
        /// Generics Implemenation of IEnumerable<>.  Returns a type safe
        /// enumerator of Key
        /// </summary>
        /// <returns></returns>
        IEnumerator<Key> IEnumerable<Key>.GetEnumerator()
        {
            return new KeyCollectionEnumerator(InnerList.GetEnumerator());
        }

        #endregion

        #region IEnumerable Members

        /// <summary>
        /// Implemenation of IEnumerable.  Returns a non type safe
        /// enumerator
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return InnerList.GetEnumerator();
        }

        #endregion

    }
}
