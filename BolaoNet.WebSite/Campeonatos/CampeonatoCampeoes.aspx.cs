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
    public partial class CampeonatoCampeoes : CampeonatoUserBasePage
    {
        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }
        #endregion

        #region Methods
        private void BindGrid()
        {
            Business.Campeonatos.Support.Campeonato business = 
                new BolaoNet.Business.Campeonatos.Support.Campeonato(base.UserName, CurrentCampeonato.Nome);


            IList<Framework.DataServices.Model.EntityBaseData> list =  business.LoadHistorico(null);

            this.grdHistorico.DataSource = list;
            this.grdHistorico.DataBind();



        }
        #endregion

        #region Events
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            this.ctlNavigateHomeControl.ButtonClick += new CommandEventHandler(ctlNavigateHomeControl_ButtonClick);

        }

        private void ctlNavigateHomeControl_ButtonClick(object sender, CommandEventArgs e)
        {
            base.NavigateHome();
        }
        #endregion
    }
}
