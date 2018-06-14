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
using System.Collections.Generic;

namespace BolaoNet.WebSite.Resultados
{
    public partial class CampeonatoApostasExtrasResultado : BolaoUserBasePage
    {
        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Business.Campeonatos.Support.Campeonato business =
                    new Business.Campeonatos.Support.Campeonato(base.UserName, CurrentCampeonato.Nome);

                IList<Framework.DataServices.Model.EntityBaseData> list = business.LoadTimes();

                ViewState["Times"] = list;

                BindGrid();
            }


        }
        #endregion

        #region Methods
        private void BindGrid()
        {

            Business.Boloes.Support.ApostaExtra business =
                    new Business.Boloes.Support.ApostaExtra(base.UserName);

            business.Bolao = CurrentBolao;
            IList<Framework.DataServices.Model.EntityBaseData> list = business.SelectAll ("NomeBolao='" + CurrentBolao.Nome + "'");

            ViewState["Grid"] = list;

            this.grdApostas.DataSource = ViewState["Grid"];
            this.grdApostas.DataBind();

        }
        private void Save()
        {
            IList<Framework.DataServices.Model.EntityBaseData> list =
                (IList<Framework.DataServices.Model.EntityBaseData>)ViewState["Grid"];




            for (int c = 0; c < this.grdApostas.Rows.Count; c++)
            {
                Model.Boloes.ApostaExtra aposta = (Model.Boloes.ApostaExtra)list[c];

                DropDownList cboNomeTime = (DropDownList)this.grdApostas.Rows[c].FindControl("cboNomeTime");

                //Se mudou o time atualizado
                if (string.Compare(cboNomeTime.Text, aposta.NomeTimeValidado, true) != 0)
                {
                    Business.Boloes.Support.ApostaExtra business =
                        new Business.Boloes.Support.ApostaExtra(base.UserName);

                    business.Copy(aposta);
                    business.Bolao = new BolaoNet.Model.Boloes.Bolao(CurrentBolao.Nome);
                    //business.UserName = base.UserName;

                    business.NomeTimeValidado = cboNomeTime.Text;

                    business.InsertResult();
                   

                }//endif mudou time


            }//end for c

            BindGrid();

            base.ShowMessages("Dados extras armazenados com sucesso.");

        }
        #endregion

        #region Events
        protected void grdApostas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;


            DropDownList cboNomeTime = (DropDownList)e.Row.FindControl("cboNomeTime");

            Image imgTime = (Image)e.Row.FindControl("imgTime");


            IList<Framework.DataServices.Model.EntityBaseData> list =
                (IList<Framework.DataServices.Model.EntityBaseData>)ViewState["Times"];

            cboNomeTime.DataSource = list;
            cboNomeTime.DataValueField = "Nome";
            cboNomeTime.DataTextField = "Nome";
            cboNomeTime.DataBind();


            Model.Boloes.ApostaExtra aposta = (Model.Boloes.ApostaExtra)e.Row.DataItem;


            if (!string.IsNullOrEmpty(aposta.NomeTimeValidado))
            {
                cboNomeTime.SelectedValue = aposta.NomeTimeValidado;
            }

            //Label lblPontos = (Label)e.Row.FindControl("lblPontos");
            //Label lblDataAposta = (Label)e.Row.FindControl("lblDataAposta");
            Label lblNomeTime = (Label)e.Row.FindControl("lblNomeTime");


            //if (aposta.DataValidacao == DateTime.MinValue)
            //{
            //    lblDataAposta.Text = "-";
            //}
            //else
            //{
            //    lblDataAposta.Text = aposta.DataAposta.ToString("dd/MM/yyyy HH:mm:ss");
            //}


            //if (CurrentBolao.ApostasApenasAntes && CurrentBolao.IsIniciado)
            //{
            //    //lblPontos.Text = aposta.Pontos.ToString();
            //    lblNomeTime.Visible = true;
            //    cboNomeTime.Visible = false;

            //    imgTime.ImageUrl = @"~\Images\Database\Times\" + lblNomeTime.Text + ".gif";
            //}
            //else
            //{
                //lblPontos.Text = "-";
                lblNomeTime.Visible = false;
                cboNomeTime.Visible = true;



                imgTime.ImageUrl = @"~\Images\Database\Times\" + cboNomeTime.Text + ".gif";
            //}


        }
        protected override void OnInit(EventArgs e)
        {

            base.OnInit(e);

            this.ctlMenuTools.ButtonClick += new CommandEventHandler(ctlMenuTools_ButtonClick);
            this.ctlNavigateHomeControl.ButtonClick += new CommandEventHandler(ctlNavigateHomeControl_ButtonClick);

            //Atualizando o bolão que está sendo analisado
            Business.Boloes.Support.Bolao business = new BolaoNet.Business.Boloes.Support.Bolao(
                base.UserName, CurrentBolao.Nome);

            business.Load();
            CurrentBolao = business;


            //if (CurrentBolao.ApostasApenasAntes && CurrentBolao.IsIniciado)
            //{
            //    this.ctlMenuTools.SaveVisible = false;
            //    //this.btnSave.Visible = false;
            //}
            //else
            //{
            //    this.ctlMenuTools.SaveVisible = true;
            //    //this.btnSave.Visible = true;
            //}




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
                    Save();
                    break;

                default:
                    break;
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        protected void cboNomeTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList combo = (DropDownList)sender;

            Image imgTime = (Image)combo.Parent.FindControl("imgTime");

            imgTime.ImageUrl = @"~\Images\Database\Times\" + combo.Text + ".gif";


        }

        #endregion

    }
}
