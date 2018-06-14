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
    public partial class ApostasExtrasPosicao : BolaoUserBasePage
    {
        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Business.Boloes.Support.ApostaExtra business = new BolaoNet.Business.Boloes.Support.ApostaExtra(base.UserName);
                IList<Framework.DataServices.Model.EntityBaseData> list = business.SelectAll("NomeBolao='" + CurrentBolao.Nome + "'");

                this.cboTitulo.DataSource = list;
                this.cboTitulo.DataTextField = "Titulo";
                this.cboTitulo.DataValueField = "Posicao";
                this.cboTitulo.DataBind();


                if (this.cboTitulo.Items.Count > 0)
                {
                    this.cboTitulo.SelectedValue = this.cboTitulo.Items[0].Value;
                    BindGrid();
                }

            }
        }
        #endregion

        #region Methods
        private void BindGrid()
        {
            if (this.cboTitulo.SelectedIndex == -1)
                return;


            Business.Boloes.Support.ApostaExtraUsuario business = new BolaoNet.Business.Boloes.Support.ApostaExtraUsuario(base.UserName);
            business.Bolao = CurrentBolao;
            business.Posicao = Convert.ToInt32(this.cboTitulo.SelectedItem.Value);

            IList<Framework.DataServices.Model.EntityBaseData> list = business.SelectByPosicao(CurrentBolao, business.Posicao, null);

            ViewState["Calculo"] = list;

            this.grdExtras.DataSource = list;
            this.grdExtras.DataBind();

            


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
                case WebSite.Controls.MenuManager.MenuTools.Return:
                    break;
                case WebSite.Controls.MenuManager.MenuTools.Save:

                    break;

                default:
                    break;
            }
        }
        protected void cboTitulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();

        }
        protected void grdExtras_DataBound(object sender, EventArgs e)
        {
            IList<Framework.DataServices.Model.EntityBaseData> list = (IList<Framework.DataServices.Model.EntityBaseData>)ViewState["Calculo"];

            for (int c = 0; c < this.grdExtras.Rows.Count; c++)
            {
                BolaoNet.Model.Boloes.ApostaExtraUsuario corrente = (BolaoNet.Model.Boloes.ApostaExtraUsuario)list[c];

                int count = 0;

                foreach (BolaoNet.Model.Boloes.ApostaExtraUsuario aposta in list)
                {
                    if (string.Compare(aposta.NomeTime, corrente.NomeTime, true) == 0)
                    {
                        count++;
                    }
                }

                this.grdExtras.Rows[c].Cells[this.grdExtras.Rows[c].Cells.Count -1].Text = count.ToString () + " (" + ( (double)count / (double)list.Count * (double)100).ToString("0.00") + " %)";
            }
        }
        #endregion



    }
}
