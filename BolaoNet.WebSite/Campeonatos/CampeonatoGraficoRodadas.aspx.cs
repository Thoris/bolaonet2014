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
    public partial class CampeonatoGraficoRodadas : CampeonatoUserBasePage
    {
        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Business.Campeonatos.Support.Campeonato business =
                    new Business.Campeonatos.Support.Campeonato(base.UserName, CurrentCampeonato);

                this.cboTime.DataSource = business.LoadTimes();
                this.cboTime.DataTextField = "Nome";
                this.cboTime.DataValueField = "Nome";
                this.cboTime.DataBind();


                
                business.Nome = CurrentCampeonato.Nome;

                this.cboGrupo.DataSource = business.LoadGrupos();
                this.cboGrupo.DataTextField = "Nome";
                this.cboGrupo.DataValueField = "Nome";
                this.cboGrupo.DataBind();


                this.cboFase.DataSource = business.LoadFases();
                this.cboFase.DataTextField = "Nome";
                this.cboFase.DataValueField = "Nome";
                this.cboFase.DataBind();



            }

            BindChart();
        }
        #endregion

        #region Methods
        private void BindChart()
        {
            if (this.cboFase.SelectedIndex == -1 || this.cboGrupo.SelectedIndex == -1 || 
                this.cboTime.SelectedIndex == -1 || ViewState["List"] == null)
                return;


            List<string> times = (List<string>)ViewState["List"];

            this.ctlChart.Series.Clear();


            foreach (string time in times)
            {

                //Criando os dados do time
                System.Web.UI.DataVisualization.Charting.Series timeSeries = 
                    new System.Web.UI.DataVisualization.Charting.Series (time, this.cboTime.Items.Count);

                timeSeries.IsXValueIndexed = true;
                //timeSeries.IsValueShownAsLabel = true;
                timeSeries.ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;

                this.ctlChart.Series.Add(timeSeries);




                Business.Campeonatos.Support.Campeonato business =
                    new Business.Campeonatos.Support.Campeonato(base.UserName, CurrentCampeonato);

                IList<Model.Campeonatos.Reports.TimeRodadas> list = business.LoadTimesRodadas(
                    new BolaoNet.Model.Campeonatos.Fase(this.cboFase.SelectedValue),
                    new BolaoNet.Model.Campeonatos.Grupo(this.cboGrupo.SelectedValue),
                    new BolaoNet.Model.DadosBasicos.Time(time));


                foreach (Model.Campeonatos.Reports.TimeRodadas rodada in list)
                {

                    timeSeries.Points.AddXY(rodada.Rodada, rodada.Posicao);

                }

            }


        }
        #endregion

        #region Events
        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (this.cboTime.SelectedIndex == -1)
                return;


            List<string> times = (List<string>)ViewState["List"];

            if (times == null)
                times = new List<string>();

            if (times.Contains(this.cboTime.Text))
                return;
            else
            {
                times.Add(this.cboTime.Text);
            }



            ViewState["List"] = times;

            this.grdTimes.DataSource = times;
            this.grdTimes.DataBind();

            BindChart();

        }
        protected void grdTimes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (string.Compare(e.CommandName.ToLower(), "delete") == 0)
            //{
            //    List<string> times = (List<string>)ViewState["List"];


            //}
        }
        protected void grdTimes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            List<string> times = (List<string>)ViewState["List"];
            times.RemoveAt(e.RowIndex);

            ViewState["List"] = times;

            this.grdTimes.DataSource = times;
            this.grdTimes.DataBind();

            BindChart();
        }
        #endregion
    }
}
