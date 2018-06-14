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
    public partial class RolesInUsers : UserBasePage
    {
        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string[] roles = System.Web.Security.Roles.Provider.GetAllRoles();

                this.chklRoles.DataSource = roles;
                this.chklRoles.DataBind();
                this.chklRoles.Enabled = false;

            }
        }
        #endregion

        #region Methods
        #endregion

        #region Events
        protected void btnFind_Click(object sender, EventArgs e)
        {
            MembershipUserCollection list = null;
            int totalRows = 0;
            string dataInput = this.txtTextToFind.Text;


            switch (this.cboSearchBy.SelectedIndex)
            {
                //UserName
                case 0:

                    list = Membership.Provider.FindUsersByName(
                        dataInput, this.grdUsers.PageIndex, this.grdUsers.PageSize, out totalRows);

                    break;

                //Email
                case 1:

                    list = Membership.Provider.FindUsersByEmail(
                        dataInput, this.grdUsers.PageIndex, this.grdUsers.PageSize, out totalRows);

                    break;

            }//end switch


            this.grdUsers.DataSource = list;
            this.grdUsers.DataBind();

            this.chklRoles.Enabled = false;

            this.lblSelectedUser.Text = "";

        }

        protected void grdUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void lnkEditRoles_Click(object sender, EventArgs e)
        {
            this.lblSelectedUser.Text = ((LinkButton)sender).CommandArgument;
            this.chklRoles.Enabled = true;


            string[] listRoles = System.Web.Security.Roles.GetRolesForUser(this.lblSelectedUser.Text);

            for (int c = 0; c < this.chklRoles.Items.Count; c++)
            {
                bool found = false;
                foreach (string role in listRoles)
                {
                    if (string.Compare(this.chklRoles.Items[c].Text, role, true) == 0)
                    {
                        found = true;
                        break;
                    }

                }
                this.chklRoles.Items[c].Selected = found;
            }

            ViewState["roles"] = listRoles;


        }

        protected void grdUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
            {
                return;
            }

            LinkButton lnkEditRoles = (LinkButton)e.Row.FindControl("lnkEditRoles");

            Framework.Security.Business.CustomMembershipUser user =
                (Framework.Security.Business.CustomMembershipUser)e.Row.DataItem;

            lnkEditRoles.CommandArgument = user.UserName;

        }

        protected void chklRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> roles = new List<string>();

            //Buscando a lista de items ativos
            foreach (ListItem item in this.chklRoles.Items)
            {
                //Se o item está marcado
                if (item.Selected)
                {
                    roles.Add(item.Text);

                }//endif seleted item
            }//end foreach item


            string[] listRoles = (string[])ViewState["roles"];


            //Se removeu um item
            if (listRoles.Length > roles.Count)
            {
                //Buscando qual o item foi removido
                foreach (string originalRole in listRoles)
                {
                    bool found = false;
                    //Buscando na lista de novos items
                    foreach (string newItem in roles)
                    {
                        if (string.Compare(originalRole, newItem, true) == 0)
                        {
                            found = true;
                        }
                    }//end foreach new items

                    if (!found)
                    {
                        string[] userNames = new string[1];
                        userNames[0] = this.lblSelectedUser.Text;

                        string[] roleNames = new string[1];
                        roleNames[0] = originalRole;

                        System.Web.Security.Roles.Provider.RemoveUsersFromRoles(userNames, roleNames);

                        break;
                    }
                }//end foreach original item
            }
            //Se adicionou um item
            else
            {
                //Buscando qual o item foi removido
                foreach (string newItem in roles)
                {
                    bool found = false;
                    //Buscando na lista de novos items
                    foreach (string orinalItem in listRoles)
                    {
                        if (string.Compare(orinalItem, newItem, true) == 0)
                        {
                            found = true;
                        }
                    }//end foreach new items

                    if (!found)
                    {
                        string[] userNames = new string[1];
                        userNames[0] = this.lblSelectedUser.Text;

                        string[] roleNames = new string[1];
                        roleNames[0] = newItem;

                        System.Web.Security.Roles.Provider.AddUsersToRoles(userNames, roleNames);

                        break;
                    }
                }//end foreach original item

            }//endif removeu ou inseriu item

            string[] result = new string[roles.Count];

            for (int c = 0; c < roles.Count; c++)
            {
                result[c] = roles[c];
            }

            ViewState["roles"] = result;



        }

        protected void lnkLetter_Click(object sender, EventArgs e)
        {
            MembershipUserCollection list = null;
            int totalRows = 0;
            string dataInput = ((LinkButton)sender).Text;


            switch (this.cboSearchBy.SelectedIndex)
            {
                //UserName
                case 0:

                    list = Membership.Provider.FindUsersByName(
                        dataInput, this.grdUsers.PageIndex, this.grdUsers.PageSize, out totalRows);

                    break;

                //Email
                case 1:

                    list = Membership.Provider.FindUsersByEmail(
                        dataInput, this.grdUsers.PageIndex, this.grdUsers.PageSize, out totalRows);

                    break;

            }//end switch


            this.grdUsers.DataSource = list;
            this.grdUsers.DataBind();

            this.chklRoles.Enabled = false;

            this.lblSelectedUser.Text = "";

        }

        #endregion

        protected void chkIsLockedOut_CheckedChanged(object sender, EventArgs e)
        {
            //Buscando em todos os objetos
            for (int c = 0; c < this.grdUsers.Rows.Count; c++)
            {
                CheckBox chkIsLockedOut = (CheckBox)this.grdUsers.Rows[c].FindControl("chkIsLockedOut");
                Label lblUsername = (Label)this.grdUsers.Rows[c].FindControl("lblUsername");

                //Se encontrou o objeto
                if (chkIsLockedOut == sender)
                {


                    //Criando o modelo de dados a ser manipulado
                    Framework.Security.Business.UserDataService userDataService = new Framework.Security.Business.UserDataService(this.UserName);
                    userDataService.UserName = lblUsername.Text;


                    //Se está ativando o item
                    if (((CheckBox)sender).Checked)
                    {
                        if (!userDataService.LockUser())
                            chkIsLockedOut.Checked = false;
                    }
                    //Se está desativando o item
                    else
                    {

                        if (!userDataService.UnlockUser())
                            chkIsLockedOut.Checked = true;

                    }//endif ativando o item
                }//endif objeto encontrado

                return;
            }//end for items
        }

        protected void chkIsApproved_CheckedChanged(object sender, EventArgs e)
        {

            //Buscando em todos os objetos
            for (int c = 0; c < this.grdUsers.Rows.Count; c++)
            {
                CheckBox chkIsApproved = (CheckBox)this.grdUsers.Rows[c].FindControl("chkIsApproved");
                Label lblUsername = (Label)this.grdUsers.Rows[c].FindControl("lblUsername");


                //Criando o modelo de dados a ser manipulado
                Framework.Security.Business.UserDataService userDataService = new Framework.Security.Business.UserDataService(this.UserName);
                userDataService.UserName = lblUsername.Text;


                //Se encontrou o objeto
                if (chkIsApproved == sender)
                {
                    //Se está ativando o item
                    if (((CheckBox)sender).Checked)
                    {
                        //Realizando o load do usuário para buscar as informações necessárias para aprovar o usuário
                        Framework.Security.Model.UserData userData = userDataService.LoadUser();
                        userDataService = new Framework.Security.Business.UserDataService(base.UserName, userData);

                        if (!userDataService.ApproveUser())
                            chkIsApproved.Checked = false;

                    }
                    //Se está desativando o item
                    else
                    {

                        if (!userDataService.DesapproveUser())
                            chkIsApproved.Checked = true;

                    }//endif ativando o item
                }//endif objeto encontrado

                return;
            }//end for items
        }

    }
}
