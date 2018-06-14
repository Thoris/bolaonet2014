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

namespace BolaoNet.WebSite.Campeonatos
{
    public partial class SelectCampeonato : UserBasePage
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


            ShowCurrentCampeonato();

            BindList();


        }
        #endregion

        #region Methods
        private void ShowCurrentCampeonato()
        {
            if (CampeonatoUserBasePage.CurrentCampeonato == null)
            {
                this.lblCampeonatoCurrent.Text = "Campeonato não selecionado.";
                this.imgSelected.Visible = false;
            }
            else
            {
                this.lblCampeonatoCurrent.Text = CampeonatoUserBasePage.CurrentCampeonato.Nome;
                this.imgSelected.ImageUrl = "~/Images/Database/Campeonatos/" +
                    CampeonatoUserBasePage.CurrentCampeonato.Nome + ".jpg";

                this.imgSelected.DescriptionUrl = CampeonatoUserBasePage.CurrentCampeonato.Nome;
                this.imgSelected.Visible = true;
            }
        }
        private void BindList()
        {
            Business.Campeonatos.Support.Campeonato business = new Business.Campeonatos.Support.Campeonato(base.UserName);
            IList<Framework.DataServices.Model.EntityBaseData> list = business.SelectAll(null);

            this.dtlCampeonatos.DataSource = list;
            this.dtlCampeonatos.DataBind();

        }
        private void ReturnPageRequested()
        {
            if (ViewState["ReturnURL"]!= null)
                Response.Redirect(ViewState["ReturnURL"].ToString ());
        }
        #endregion

        #region Events
        protected override void  OnInit(EventArgs e)        
        {
            this.ctlNavigateHomeControl.ButtonClick += new CommandEventHandler(ctlNavigateHomeControl_ButtonClick);
            this.ctlMenuTools.ButtonClick += new CommandEventHandler(ctlMenuTools_ButtonClick);
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
        protected void dtlCampeonatos_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            LinkButton lnkCampeonato = (LinkButton)e.Item.FindControl("lnkCampeonato");
            

            Model.Campeonatos.Campeonato campeonato = (Model.Campeonatos.Campeonato)e.Item.DataItem;
            Image ibtnCampeonato = (Image)e.Item.FindControl("ibtnCampeonato");

            ibtnCampeonato.ImageUrl = "~/Images/Database/Campeonatos/" + campeonato.Nome + ".jpg";
            ibtnCampeonato.DescriptionUrl = campeonato.Nome;


            lnkCampeonato.Text = campeonato.Nome;
            lnkCampeonato.CommandArgument = campeonato.Nome;
            //ibtnCampeonato.CommandArgument = campeonato.Nome;
            
        }
        protected void lnkCampeonato_Click(object sender, EventArgs e)
        {
            string campeonato = ((LinkButton)sender).CommandArgument;

            Business.Campeonatos.Support.Campeonato business = new Business.Campeonatos.Support.Campeonato(
                base.UserName, campeonato);


            business.Load();            
            CampeonatoUserBasePage.CurrentCampeonato = (Model.Campeonatos.Campeonato)business;



            base.SelectCampeonato(campeonato);

            ReturnPageRequested(); 
            
            ShowCurrentCampeonato();


            

        }
        protected void ibtnCampeonato_Click(object sender, ImageClickEventArgs e)
        {
            
             string campeonato = ((ImageButton)sender).CommandArgument;


        }
        #endregion
    }
}