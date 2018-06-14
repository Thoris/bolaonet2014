using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.DataServices.Model
{
    /// <summary>
    /// Base class all entities in the framework derive from.  
    /// Provides base functionality for Seriziation, Cloning and
    /// Versioning.
    /// </summary>
    [Serializable]
    public class EntityBaseData
    {
        #region Variables
        private bool _activeFlag = true;
        private string _createdBy = string.Empty;
        private DateTime _createdDate = DateTime.MinValue;
        private string _modifiedBy = string.Empty;
        private DateTime _modifiedDate = DateTime.MinValue;
        private bool _isLoaded = false;
        #endregion

        #region Properties

        /// <summary>
        /// Flag to determine if this entity is active or not.
        /// This is essentially a deleted flag
        /// </summary>
        public bool ActiveFlag
        {
            get { return _activeFlag; }
            set { _activeFlag = value; }
        }

        /// <summary>
        /// The userid/username of the user who created this entity
        /// </summary>
        public string CreatedBy
        {
            get { return _createdBy; }
            set { _createdBy = value; }
        }

        /// <summary>
        /// The Date and Time this entity was created.
        /// </summary>
        public DateTime CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate = value; }
        }

        /// <summary>
        /// The userid/username of the last user to modify this entity
        /// </summary>
        public string ModifiedBy
        {
            get { return _modifiedBy; }
            set { _modifiedBy = value; }
        }

        /// <summary>
        /// The Date and Time this entity was last modified.
        /// If their is an inheritance heirarchy in table structure
        /// used to store the data and this property is assigned, multiple
        /// times during rehydration.  This property will keep the last
        /// modified date.
        /// </summary>
        public DateTime ModifiedDate
        {
            get { return _modifiedDate; }
            set
            {
                //due to inheritance we could have mulitple objects
                //in the chain setting this value.  For consistency
                //this will always be the greatest value for any object
                //in the inheritance chain.
                if (value > _modifiedDate)
                {
                    _modifiedDate = value;
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is loaded.
        /// </summary>
        /// <value><c>true</c> if this instance is loaded; otherwise, <c>false</c>.</value>
        public bool IsLoaded
        {
            get { return _isLoaded; }
        }
        #endregion

        #region Constructors/Destructorss

        protected EntityBaseData() 
        {
        }

        #endregion

        #region Methods
        public void LoadDataRow(System.Data.DataRow row)
        {
            if (row.Table.Columns.Contains("CreatedBy") && !Convert.IsDBNull(row["CreatedBy"]))
            {
                this._createdBy = Convert.ToString(row["CreatedBy"]);
            }
            if (row.Table.Columns.Contains("CreatedDate") && !Convert.IsDBNull(row["CreatedDate"]))
            {
                this._createdDate = Convert.ToDateTime(row["CreatedDate"]);
            }
            if (row.Table.Columns.Contains("ModifiedBy") && !Convert.IsDBNull(row["ModifiedBy"]))
            {
                this._modifiedBy = Convert.ToString(row["ModifiedBy"]);
            }
            if (row.Table.Columns.Contains("ModifiedDate") && !Convert.IsDBNull(row["ModifiedDate"]))
            {
                this._modifiedDate = Convert.ToDateTime(row["ModifiedDate"]);
            }
            if (row.Table.Columns.Contains("ActiveFlag") && !Convert.IsDBNull(row["ActiveFlag"]))
            {
                this._activeFlag = Convert.ToBoolean(row["ActiveFlag"]);
            }

            _isLoaded = true;
        }

        public void Copy(EntityBaseData entry)
        {
            if (entry == null)
                return;
            _createdBy = entry._createdBy;
            _createdDate = entry._createdDate;
            _modifiedBy = entry._modifiedBy;
            _modifiedDate = entry._modifiedDate;
            _activeFlag = entry._activeFlag;
            _isLoaded = entry._isLoaded;
        }
        #endregion

    }
}
