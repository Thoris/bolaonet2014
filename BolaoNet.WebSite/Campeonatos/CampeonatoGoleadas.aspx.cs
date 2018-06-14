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
    public partial class CampeonatoGoleadas : CampeonatoUserBasePage
    {
        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGrid();
        }
        #endregion

        #region Methods
        private void BindGrid()
        {
            string maxGolGoleadas = System.Configuration.ConfigurationManager.AppSettings["MaxGolGoleadas"];

            int maxGolsValue = 4;

            if (!string.IsNullOrEmpty(maxGolGoleadas))
            {
                maxGolsValue = Convert.ToInt32(maxGolGoleadas);
            }


            Business.Campeonatos.Support.Jogo business = new BolaoNet.Business.Campeonatos.Support.Jogo(base.UserName);
            IList<Framework.DataServices.Model.EntityBaseData> list = 
                business.SelectGoleadas(CurrentCampeonato, maxGolsValue, null, null);


            this.grdJogos.DataSource = list;
            this.grdJogos.DataBind();
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
        protected void grdJogos_DataBinding(object sender, EventArgs e)
        {

        }

        protected void grdJogos_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        #endregion
    }
}
