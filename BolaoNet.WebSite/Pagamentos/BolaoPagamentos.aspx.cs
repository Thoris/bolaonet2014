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

namespace BolaoNet.WebSite.Pagamentos
{
    public partial class BolaoPagamentos : BolaoUserBasePage
    {
        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPagamentos();
            }
        }
        #endregion

        #region Methods
        private void BindPagamentos()
        {
            Business.Boloes.Support.Pagamento business = new BolaoNet.Business.Boloes.Support.Pagamento(base.UserName);
            business.Bolao = CurrentBolao;
            IList<Framework.DataServices.Model.EntityBaseData> list = business.SelectAllByBolao(CurrentBolao, null);

            this.grdPagamentos.DataSource = list;
            this.grdPagamentos.DataBind();

        }

        private void Delete(string parameters)
        {
            string[] paramItems = parameters.Split(new char []{'|'});

            Business.Boloes.Support.Pagamento business = new BolaoNet.Business.Boloes.Support.Pagamento(base.UserName);
            business.Bolao = new BolaoNet.Model.Boloes.Bolao (paramItems[0]);
            business.UserName = paramItems[1];
            business.DataPagamento = Convert.ToDateTime (paramItems[2]);

            if (!business.Delete())
            {
                base.ShowErrors("Não foi possível excluir o pagamento.");
            }
            else
            {
                BindPagamentos();
            }
        }
        #endregion

        #region Events
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

                case WebSite.Controls.MenuManager.MenuTools.AddNew:

                    Response.Redirect("~/Pagamentos/BolaoPagamentosItem.aspx?Mode=" + (int)Business.Util.ActionMode.Insert);

                    break;

                case WebSite.Controls.MenuManager.MenuTools.Return:

                    break;

                default:
                    break;
            }
        }
        
        protected void grdPagamentos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "ViewDetails":

                    Response.Redirect("/Pagamentos/BolaoPagamentosItem.aspx?" + e.CommandArgument);

                    break;

                case "EditItem":

                    Response.Redirect("/Pagamentos/BolaoPagamentosItem.aspx?" + e.CommandArgument);

                    break;

                case "DeleteItem":

                    //Delete(e.CommandArgument.ToString());

                    break;
            }
        }


        protected void ibtnDelete_Command(object sender, CommandEventArgs e)
        {
            Delete(e.CommandArgument.ToString());

        }
        #endregion


   


    }
}
