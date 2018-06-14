using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;

namespace BolaoNet.WebSite.Apostas
{
    public partial class HomeApostas : UserBasePage
    {
        #region Constructors/Destructors

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string bolao = null;


                if (Request.QueryString["Bolao"] != null)
                {
                    bolao = Request.QueryString["Bolao"];
                }
                //if (Request.QueryString["Campeonato"] != null)
                //{
                //    campeonato = Request.QueryString["Campeonato"];
                //}

                if (!string.IsNullOrEmpty(bolao))
                {

                    Business.Boloes.Support.Bolao bolaoBO = new Business.Boloes.Support.Bolao (CurrentUserName, bolao);
                    bolaoBO.Load ();

                    CampeonatoUserBasePage.CurrentCampeonato = bolaoBO.Campeonato;
                    BolaoUserBasePage.CurrentCampeonato = bolaoBO.Campeonato;
                    BolaoUserBasePage.CurrentBolao = bolaoBO;
                }
                
            }


            Response.Redirect("~/Apostas/ApostasJogos.aspx");

            BindGrid();
        }
        #endregion

        #region Methods
        public void BindGrid()
        {
            Business.Users.Support.User user = new BolaoNet.Business.Users.Support.User(base.UserName);
            user.UserName = base.UserName;
            IList<BolaoNet.Model.Users.UserBoloes> list = user.LoadBoloes();


            this.grdMeusBoloes.DataSource = list;
            this.grdMeusBoloes.DataBind();
            
        }
        #endregion

        #region Events
        protected void grdMeusBoloes_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

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

        }
        #endregion
    }
}
