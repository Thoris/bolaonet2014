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

namespace BolaoNet.WebSite.Pontuacao
{
    public partial class BolaoCriteriosPontos : BolaoUserBasePage
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
                BindGridTimes();
            }
        }
        #endregion

        #region Methods
        private void BindGrid()
        {
            Business.Boloes.Support.Bolao business = new BolaoNet.Business.Boloes.Support.Bolao(base.UserName, CurrentBolao.Nome);
            IList<Framework.DataServices.Model.EntityBaseData> list = business.LoadCriteriosPontos(null);

            this.grdCriterios.DataSource = list;
            this.grdCriterios.DataBind();


            ViewState["Grid"] = list;

        }

        private void BindGridTimes()
        {
            Business.Boloes.Support.Bolao business = new BolaoNet.Business.Boloes.Support.Bolao(base.UserName, CurrentBolao.Nome);
            IList<Framework.DataServices.Model.EntityBaseData> list = business.LoadCriteriosPontosTimes (null);

            this.grdTimes.DataSource = list;
            this.grdTimes.DataBind();


            ViewState["GridTimes"] = list;

        }


        public void Save()
        {

            IList<Framework.DataServices.Model.EntityBaseData> list =
                (IList<Framework.DataServices.Model.EntityBaseData>)ViewState["Grid"];

            IList<Framework.DataServices.Model.EntityBaseData> listTimes =
                (IList<Framework.DataServices.Model.EntityBaseData>)ViewState["GridTimes"];

            #region Critérios

            for (int c = 0; c < this.grdCriterios.Rows.Count; c++)
            {
                Model.Boloes.BolaoCriterioPontos criterio = (Model.Boloes.BolaoCriterioPontos)list[c];
                

                TextBox txtPontos = (TextBox)this.grdCriterios.Rows[c].FindControl("txtPontos");
                DropDownList cboNomeTime = (DropDownList)this.grdCriterios.Rows[c].FindControl("cboNomeTime");
                TextBox txtMultiplo = (TextBox)this.grdCriterios.Rows[c].FindControl("txtMultiplo");



                //Se mudou os pontos
                if ((txtPontos.Text.Length > 0 && Convert.ToInt32 (txtPontos.Text) != criterio.Pontos))// ||
                //      string.Compare (cboNomeTime.SelectedValue, criterio.Time.Nome) != 0 ||
                //    (txtMultiplo.Text.Length > 0 && Convert.ToInt32 (txtMultiplo.Text) != criterio.MultiploTime))
                {
                    Business.Boloes.Support.Bolao business =
                        new Business.Boloes.Support.Bolao(base.UserName, CurrentBolao.Nome);

                    criterio.Pontos = Convert.ToInt32 (txtPontos.Text);
                    //criterio.MultiploTime = Convert.ToInt32(txtMultiplo.Text);
                    //criterio.Time = new BolaoNet.Model.DadosBasicos.Time(cboNomeTime.SelectedValue);
                    
                    business.UpdateCriterioPontos(criterio);

                }//endif mudou pontos


            }//end for c
            #endregion

            #region Critérios times

            for (int c = 0; c < this.grdTimes.Rows.Count; c++)
            {
                Model.Boloes.BolaoCriterioPontosTimes criterio = (Model.Boloes.BolaoCriterioPontosTimes)listTimes[c];

                Label lblTime = (Label)this.grdTimes.Rows[c].FindControl("lblTime");
                TextBox txtMultiplo = (TextBox)this.grdTimes.Rows[c].FindControl("txtMultiplo");

                if (criterio.MultiploTime != Convert.ToInt32(txtMultiplo.Text))
                {
                    Business.Boloes.Support.Bolao business =
                        new Business.Boloes.Support.Bolao(base.UserName, CurrentBolao.Nome);

                    criterio.MultiploTime = Convert.ToInt32(txtMultiplo.Text);

                    business.UpdateCriterioPontosTimes(criterio);
                }



            }//end for times

            #endregion

            BindGrid();
            BindGridTimes();

            base.ShowMessages("Pontos armazenados com sucesso.");
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
                    Save();
                    break;

                default:
                    break;
            }
        }
        protected void grdCriterios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType != DataControlRowType.DataRow)
            //    return;


            //DropDownList cboNomeTime = (DropDownList)e.Row.FindControl("cboNomeTime");

            //IList<Framework.DataServices.Model.EntityBaseData> list =
            //    (IList<Framework.DataServices.Model.EntityBaseData>)ViewState["Times"];

            //cboNomeTime.DataSource = list;
            //cboNomeTime.DataValueField = "Nome";
            //cboNomeTime.DataTextField = "Nome";
            //cboNomeTime.DataBind();


            //Model.Boloes.BolaoCriterioPontos criterio = (Model.Boloes.BolaoCriterioPontos)e.Row.DataItem;


            //if (!string.IsNullOrEmpty(criterio.Time.Nome))
            //{
            //    cboNomeTime.SelectedValue = criterio.Time.Nome;
            //}

            //Label lblPontos = (Label)e.Row.FindControl("lblPontos");
            //Label lblDataAposta = (Label)e.Row.FindControl("lblDataAposta");
            //Label lblNomeTime = (Label)e.Row.FindControl("lblNomeTime");


            //if (aposta.DataAposta == DateTime.MinValue)
            //{
            //    lblDataAposta.Text = "-";
            //}
            //else
            //{
            //    lblDataAposta.Text = aposta.DataAposta.ToString("dd/MM/yyyy HH:mm:ss");
            //}


            //if (!aposta.IsValido)
            //{
            //    lblPontos.Text = "-";
            //    lblNomeTime.Visible = false;
            //    cboNomeTime.Visible = true;
            //}
            //else
            //{
            //    lblPontos.Text = aposta.Pontos.ToString();
            //    lblNomeTime.Visible = true;
            //    cboNomeTime.Visible = false;
            //}
        }
        #endregion
    }
}
