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

namespace BolaoNet.WebSite.Boloes.Admin
{
    public partial class GerenciamentoMembros : BolaoUserBasePage
    {
        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {
            BindRequests();
            BindMembros();

        }
        #endregion

        #region Methods
        private void BindMembros()
        {
            Business.Boloes.Support.Bolao bolao = new BolaoNet.Business.Boloes.Support.Bolao(base.UserName, CurrentBolao.Nome);
            IList<Framework.DataServices.Model.EntityBaseData> list = bolao.LoadMembros();

            this.grdUserBolao.DataSource = list;
            this.grdUserBolao.DataBind();
        }

        private void BindRequests()
        {
            Business.Boloes.Support.Bolao bolao = new BolaoNet.Business.Boloes.Support.Bolao(base.UserName, CurrentBolao.Nome);
            IList<Framework.DataServices.Model.EntityBaseData> list = bolao.SelectRequestsPendentesByBolao(null);

            this.grdRequests.DataSource = list;
            this.grdRequests.DataBind();


            ViewState["RequestList"] = list;
                
        }
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

        }
        protected void grdUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            Framework.Security.Business.CustomMembershipUser user = 
                (Framework.Security.Business.CustomMembershipUser)e.Row.DataItem;

            LinkButton lnkConvidar = (LinkButton)e.Row.FindControl("lnkConvidar");
            lnkConvidar.CommandArgument = user.UserName;
           
        }
        protected void grdUserBolao_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            Framework.Security.Model.UserData user = (Framework.Security.Model.UserData)e.Row.DataItem;

            LinkButton lnkConvidar = (LinkButton)e.Row.FindControl("lnkRemover");
            lnkConvidar.CommandArgument = user.UserName;
        }
        protected void lnkRemover_Click(object sender, EventArgs e)
        {
            string nomeUser = ((LinkButton)sender).CommandArgument;

            Business.Boloes.Support.Bolao business = new BolaoNet.Business.Boloes.Support.Bolao(base.UserName, CurrentBolao.Nome);
            Framework.Security.Model.UserData user = new Framework.Security.Model.UserData(nomeUser);

            if (business.DeleteMembro(user))
            {
                base.ShowMessages(user + " removido do bolão com sucesso.");
            }
            else
            {
                base.ShowErrors(user + " com problemas para remover do bolão.");
            }

            BindMembros();

        }
        protected void lnkConvidar_Click(object sender, EventArgs e)
        {
            string nomeUser = ((LinkButton)sender).CommandArgument;

            Business.Boloes.Support.Bolao business = new BolaoNet.Business.Boloes.Support.Bolao(base.UserName, CurrentBolao.Nome);

            Model.Boloes.BolaoRequest request = new BolaoNet.Model.Boloes.BolaoRequest();
            request.Bolao = business;
            request.Owner = nomeUser;
            request.AnsweredBy = base.UserName;
            request.StatusRequestID = BolaoNet.Model.Boloes.BolaoRequest.Status.Convidado;

            if (business.BolaoParticipar(request))
            {
                base.ShowMessages("Foi enviado um convite para o usuário " + nomeUser + " para participar do bolão.");
            }
            else
            {
                base.ShowErrors("Erro ao enviar um convite para o usuário " + nomeUser);
            }




        }
        protected void grdRequests_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            Model.Boloes.BolaoRequest request = (Model.Boloes.BolaoRequest)e.Row.DataItem;

            Label lblStatus = (Label)e.Row.FindControl("lblStatus");
            LinkButton lnkAprovar = (LinkButton)e.Row.FindControl("lnkAprovar");
            LinkButton lnkRejeitar = (LinkButton)e.Row.FindControl("lnkRejeitar");


            lnkAprovar.CommandArgument = e.Row.RowIndex.ToString();
            lnkRejeitar.CommandArgument = e.Row.RowIndex.ToString ();



            if (request.StatusRequestID == BolaoNet.Model.Boloes.BolaoRequest.Status.Convidado)
            {
                lblStatus.Visible = true;
                lnkAprovar.Visible = false;
                lnkRejeitar.Visible = false;
            }
            else
            {
                lblStatus.Visible = false;
                lnkAprovar.Visible = true;
                lnkRejeitar.Visible = true;
            }


        }
        protected void grdRequests_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Business.Boloes.Support.Bolao business = new BolaoNet.Business.Boloes.Support.Bolao(base.UserName, CurrentBolao.Nome);

            IList<Framework.DataServices.Model.EntityBaseData> list = 
                (IList<Framework.DataServices.Model.EntityBaseData>)ViewState["RequestList"];

            int rowIndex = int.Parse (e.CommandArgument.ToString ());

            Model.Boloes.BolaoRequest request = (Model.Boloes.BolaoRequest)list[rowIndex];
            request.AnsweredBy = base.UserName;


            switch (e.CommandName)
            {
                case "Rejeitar":

                    if (business.BolaoChangeStatus(request))
                    {
                        base.ShowMessages("Requisição rejeitada com sucesso.");
                    }
                    else
                    {
                        base.ShowErrors("Erro ao rejeitar a requisição.");
                    }


                    break;

                case "Aprovar":

                    if (business.BolaoAceitar(request))
                    {
                        base.ShowMessages("Requisição aceita com sucesso.");
                    }
                    else
                    {
                        base.ShowErrors("Erro ao aceitar a requisição.");
                    }


                    break;
            }
        }


        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            this.ctlMenuTools.ButtonClick += new CommandEventHandler(ctlMenuTools_ButtonClick);
            this.ctlNavigateHomeControl.ButtonClick += new CommandEventHandler(ctlNavigateHomeControl_ButtonClick);

        }

        private void ctlNavigateHomeControl_ButtonClick(object sender, CommandEventArgs e)
        {
            base.NavigateHome();
        }

        private void ctlMenuTools_ButtonClick(object sender, CommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case WebSite.Controls.MenuManager.MenuTools.Save:
                
                    break;

                default:
                    break;
            }
        }
        #endregion
    }
}
