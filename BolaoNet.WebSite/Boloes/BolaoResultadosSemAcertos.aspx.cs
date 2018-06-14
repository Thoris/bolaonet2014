using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Framework.UI.Web.Controls.GridView.Group;

namespace BolaoNet.WebSite.Boloes
{
    public partial class BolaoResultadosSemAcertos : BolaoUserBasePage
    {
        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                GridViewHelper helper = new GridViewHelper(this.grdJogos);
                helper.GroupHeader += new GroupEvent(helper_GroupHeader);

                helper.RegisterGroup("rodada", true, true);
                helper.RegisterGroup("onlydatajogo", true, true);

                ViewState["refreshed"] = true;

            }

            BindGrid();
        }
        #endregion

        #region Methods
        private void BindGrid()
        {


            Business.Boloes.IBusinessJogoUsuario business = new Business.Boloes.Support.JogoUsuario(base.UserName);
            IList<Framework.DataServices.Model.EntityBaseData> list = business.LoadSemAcertos(CurrentBolao);

            this.grdJogos.DataSource = list;
            this.grdJogos.DataBind();

            ViewState["JogosSource"] = list;
        }
        #endregion

        #region Events
        private void helper_GroupHeader(string groupName, object[] values, GridViewRow row)
        {
            switch (groupName.ToLower())
            {
                case "rodada":
                    row.CssClass = "header_jogo_rodada";
                    row.Cells[0].Text = "Rodada: " + row.Cells[0].Text;
                    break;

                case "grupo":
                    row.CssClass = "header_jogo_grupo";
                    row.Cells[0].Text = "Grupo: " + row.Cells[0].Text;
                    break;

                case "onlydatajogo":
                    row.CssClass = "header_jogo_data";
                    row.Cells[0].Text = "Dia: " + Convert.ToDateTime(row.Cells[0].Text).ToString("dd/MM/yyyy");
                    break;

                case "fase":
                    row.CssClass = "header_jogo_fase";
                    row.Cells[0].Text = "Fase: " + row.Cells[0].Text;
                    break;
            }
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.ctlNavigateHomeControl.ButtonClick += new CommandEventHandler(ctlNavigateHomeControl_ButtonClick);

        }
        private void ctlNavigateHomeControl_ButtonClick(object sender, CommandEventArgs e)
        {
            base.NavigateHome();
        }
        protected void grdJogos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
            {
                return;
            }
        }
        protected void grdJogos_DataBinding(object sender, EventArgs e)
        {
        }
        protected void grdJogos_DataBound(object sender, EventArgs e)
        {
        }
        #endregion
    }
}