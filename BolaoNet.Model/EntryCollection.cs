using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace BolaoNet.Model
{
    [Serializable]
    public class EntryCollection : CollectionBase
    {
        #region Delegates/Events
        #endregion

        #region Constructors/Destructors
        public EntryCollection(IList<Framework.DataServices.Model.EntityBaseData> list)
            : base ()
        {
            foreach (Framework.DataServices.Model.EntityBaseData entry in list)
            {
                this.Add(entry);
            }
        }

        public EntryCollection()
            : base ()
        {

        }
        public Framework.DataServices.Model.EntityBaseData this[int index]
        {
            get
            {
                return ((Framework.DataServices.Model.EntityBaseData)List[index]);
            }
            set
            {
                List[index] = value;
            }
        }

        #endregion

        #region Methods


        public int Add(Framework.DataServices.Model.EntityBaseData value)
        {
            return (List.Add(value));
        }

        public int IndexOf(Framework.DataServices.Model.EntityBaseData value)
        {
            return (List.IndexOf(value));
        }

        public void Insert(int index, Framework.DataServices.Model.EntityBaseData value)
        {
            List.Insert(index, value);
        }

        public void Remove(Framework.DataServices.Model.EntityBaseData value)
        {
            List.Remove(value);
        }

        public bool Contains(Framework.DataServices.Model.EntityBaseData value)
        {
            // If value is not of type Int16, this will return false.
            return (List.Contains(value));
        }

        #endregion

        #region Events

        protected override void OnInsert(int index, Object value)
        {
            // Insert additional code to be run only when inserting values.
        }

        protected override void OnRemove(int index, Object value)
        {
            // Insert additional code to be run only when removing values.
        }

        protected override void OnClear()
        {
            base.OnClear();
        }

        protected override void OnSet(int index, Object oldValue, Object newValue)
        {
            // Insert additional code to be run only when setting values.
        }

        #endregion
    }
}
