using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Security.Model
{
    public class Role : Framework.DataServices.Model.EntityBaseData
    {
        #region Variables
        private string _roleName;
        private string _description;
        #endregion

        #region Properties
        public string RoleName
        {
            get { return _roleName; }
            set { _roleName = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        #endregion

        #region Constructors/Destructors
        public Role()
        {

        }
        public Role(string roleName)
        {
            _roleName = roleName;
        }
        #endregion
    }
}
