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
    public partial class CampeonatoJogosTime : CampeonatoUserBasePage
    {
        #region Constants
        public int PosGridResultado = 20;
        #endregion

        #region Properties

        public bool IsUserCanSetResultadoJogo
        {
            get
            {
                if (Session["ListJogo.CanSetJogo"] == null)
                {
                    bool result = System.Web.Security.Roles.IsUserInRole("Gerenciador de Resultados");

                    if (result)
                    {
                        Session["ListJogo.CanSetJogo"] = result;
                        return result;
                    }
                    else
                    {
                        result = System.Web.Security.Roles.IsUserInRole("Administrador");

                        return result;
                    }

                }
                else
                {
                    return Convert.ToBoolean(Session["ListJogo.CanSetJogo"]);
                }
            }
        }
        #endregion

        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Business.Campeonatos.Support.Campeonato campeonato =
                    new Business.Campeonatos.Support.Campeonato(base.UserName, CurrentCampeonato);

                this.cboTime.DataSource = campeonato.LoadTimes();
                this.cboTime.DataTextField = "Nome";
                this.cboTime.DataValueField = "Nome";
                this.cboTime.DataBind();
            }

            BindGrid();

        }
        #endregion

        #region Methods
        private void BindGrid()
        {

            IList<Framework.DataServices.Model.EntityBaseData> list =
                new List<Framework.DataServices.Model.EntityBaseData>();


            //Criando a classe de business
            Business.Campeonatos.Support.Jogo business = new Business.Campeonatos.Support.Jogo(base.UserName);

            Model.DadosBasicos.Time time = new Model.DadosBasicos.Time(this.cboTime.Text);


            list = business.SelectJogosByTime(CurrentCampeonato, time, null, null);



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
            if (e.Row.RowType != DataControlRowType.DataRow)
            {
                return;
            }


            Model.Campeonatos.Jogo entry = (Model.Campeonatos.Jogo)e.Row.DataItem;

            Label lblGolsTime1 = (Label)e.Row.FindControl("lblGolsTime1");
            Label lblGolsTime2 = (Label)e.Row.FindControl("lblGolsTime2");


            if (entry.PartidaValida)
            {
                lblGolsTime1.Text = entry.GolsTime1.ToString();
                lblGolsTime2.Text = entry.GolsTime2.ToString();
            }
            else
            {

                lblGolsTime1.Text = "-";
                lblGolsTime2.Text = "-";
            }


        }

        protected void grdJogos_DataBound(object sender, EventArgs e)
        {
            this.grdJogos.Columns[PosGridResultado].Visible = IsUserCanSetResultadoJogo;
        }
        #endregion

    }
}
