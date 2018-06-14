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
    public partial class ApostasExtrasUsuarios : BolaoUserBasePage
    {
        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Business.Boloes.Support.Bolao bolao = new BolaoNet.Business.Boloes.Support.Bolao(base.UserName, CurrentBolao.Nome);
                IList<Framework.DataServices.Model.EntityBaseData> list = bolao.LoadMembros();

                this.cboUsuarios.DataSource = list;
                this.cboUsuarios.DataTextField = "UserName";
                this.cboUsuarios.DataValueField = "UserName";
                this.cboUsuarios.DataBind();


                this.cboUsuarios.SelectedValue = base.UserName;
                this.lblUsuarioSelecionado.Text = base.UserName;


                BindGrid();

            }

        }
        #endregion

        #region Methods
        private void BindGrid()
        {
            Business.Boloes.Support.ApostaExtraUsuario business = new BolaoNet.Business.Boloes.Support.ApostaExtraUsuario(base.UserName);
            business.Bolao = CurrentBolao;
            IList<Framework.DataServices.Model.EntityBaseData> list = business.SelectByUser(CurrentBolao, this.lblUsuarioSelecionado.Text, null);

            this.grdApostas.DataSource = list;
            this.grdApostas.DataBind();

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
        protected void cboUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {


            this.lblUsuarioSelecionado.Text = this.cboUsuarios.Text;



            BindGrid();
        }
        #endregion

    }
}
