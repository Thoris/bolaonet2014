using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Collections.Generic;

namespace BolaoNet.WebSite.Users.Admin.Roles
{
    public partial class UsersInRoles : System.Web.UI.Page
    {
        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string[] roles = System.Web.Security.Roles.Provider.GetAllRoles();
                this.cboRoles.DataSource = roles;
                this.cboRoles.DataBind();

            }

        }
        #endregion

        #region Methods
        private void BindUsersInRole()
        {
            string role = this.lblRoleSelected.Text;

            List<Framework.Security.Model.UserData> usersInRole = new List<Framework.Security.Model.UserData>();

            string [] listusersInRole = System.Web.Security.Roles.Provider.GetUsersInRole(role);

            foreach (string user in listusersInRole)
            {
                usersInRole.Add(new Framework.Security.Model.UserData(user));
            }

            this.grdUsersInRole.DataSource = usersInRole;
            this.grdUsersInRole.DataBind();

        }
        #endregion


        protected void cboRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblRoleSelected.Text = this.cboRoles.Text;

            BindUsersInRole();
        }

        #region Methods
        #endregion
    }
}
