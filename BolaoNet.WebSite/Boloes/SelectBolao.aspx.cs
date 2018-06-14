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

namespace BolaoNet.WebSite.Boloes
{
    public partial class SelectBolao : UserBasePage
    {
        #region Variables
        #endregion

        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ViewState["ReturnURL"] = Request.QueryString["ReturnURL"];

                if (ViewState["ReturnURL"] != null)
                {
                    this.ctlMenuTools.ReturnVisible = true;
                }
                else
                {
                    this.ctlMenuTools.ReturnVisible = false;
                }
            }


            ShowCurrentBolao();

            BindList();


        }
        #endregion

        #region Methods
        private void ShowCurrentBolao()
        {
            if (BolaoUserBasePage.CurrentBolao == null)
            {
                this.lblBolaoCurrent.Text = "Bolão não selecionado.";
                this.imgSelected.Visible = false;
            }
            else
            {
                this.lblBolaoCurrent.Text = BolaoUserBasePage.CurrentBolao.Nome;
                this.imgSelected.ImageUrl = "~/Images/Database/Boloes/" +
                    BolaoUserBasePage.CurrentBolao.Nome + ".jpg";

                this.imgSelected.DescriptionUrl = BolaoUserBasePage.CurrentBolao.Nome;
                this.imgSelected.Visible = true;
            }
        }
        private void BindList()
        {
            //Business.Boloes.Bolao business = new Business.Boloes.Bolao(base.UserName);
            //IList<Framework.DataServices.Model.EntityBaseData> list = business.SelectAll(null);

            Business.Users.Support.User business = new BolaoNet.Business.Users.Support.User(base.UserName, base.UserName);
            IList<BolaoNet.Model.Users.UserBoloes> list = business.LoadBoloes();


            this.dtlBolao.DataSource = list;
            this.dtlBolao.DataBind();

        }
        private void ReturnPageRequested()
        {
            if (ViewState["ReturnURL"] != null)
                Response.Redirect(ViewState["ReturnURL"].ToString());
        }
        
        #endregion

        #region Events
        protected override void  OnInit(EventArgs e)
        {
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
                case WebSite.Controls.MenuManager.MenuTools.Return:
                    ReturnPageRequested();
                    break;

                default:
                    break;
            }
        }
        protected void dtlBolao_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            LinkButton lnkBolao = (LinkButton)e.Item.FindControl("lnkBolao");


            //Model.Boloes.Bolao bolao = (Model.Boloes.Bolao)e.Item.DataItem;
            Model.Users.UserBoloes bolao = (Model.Users.UserBoloes)e.Item.DataItem;
            
            
            Image ibtnBolao = (Image)e.Item.FindControl("ibtnBolao");

            ibtnBolao.ImageUrl = "~/Images/Database/Boloes/" + bolao.Bolao.Nome + ".jpg";
            ibtnBolao.DescriptionUrl = bolao.Bolao.Nome;

            lnkBolao.Text = bolao.Bolao.Nome;
            lnkBolao.CommandArgument = bolao.Bolao.Nome;
            //ibtnBolao.CommandArgument = bolao.Nome;

        }
        protected void lnkBolao_Click(object sender, EventArgs e)
        {
            string bolao = ((LinkButton)sender).CommandArgument;
            
            //Business.Boloes.Bolao business = new Business.Boloes.Bolao(
            //    base.UserName, bolao);

            //business.Load();
            //BolaoUserBasePage.CurrentBolao = (Model.Boloes.Bolao)business;
            //CampeonatoUserBasePage.CurrentCampeonato = business.Campeonato;

            base.SelectBolao(bolao);
            ReturnPageRequested();

            ShowCurrentBolao();
        }
        protected void ibtnBolao_Click(object sender, ImageClickEventArgs e)
        {
            string bolao = ((ImageButton)sender).CommandArgument;


        }
        #endregion
    }
}
