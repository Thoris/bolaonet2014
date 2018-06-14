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
    public partial class CampeonatoEstatisticas : CampeonatoUserBasePage
    {
        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {

            Business.Campeonatos.Support.Campeonato business = new BolaoNet.Business.Campeonatos.Support.Campeonato(base.UserName);
            IList<Model.Campeonatos.Reports.GolsFrequencia> list = business.LoadGolsFrequencia(CurrentCampeonato);







            //Criando os dados do time
            System.Web.UI.DataVisualization.Charting.Series timeSeries =
                new System.Web.UI.DataVisualization.Charting.Series("Placares", list.Count);

            //timeSeries.IsXValueIndexed = true;
            timeSeries.ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.StackedColumn;

            timeSeries.YValuesPerPoint = 1;
            

            this.ctlChartPlacares.Series.Add(timeSeries);



            int count = 0;
            int total = 0;

            foreach (Model.Campeonatos.Reports.GolsFrequencia gols in list)
            {

                if (++count > 8)
                {
                    total += gols.Total;
                }
                else
                {
                    string placar = gols.Gols1.ToString() + "x" + gols.Gols2.ToString();
                    timeSeries.Points.AddXY(placar, gols.Total);
                }
            }

            timeSeries.Points.AddXY("Outros", total);



















            //this.ctlChart.Series.Clear();


            //System.Web.UI.DataVisualization.Charting.Series series =
            //    new System.Web.UI.DataVisualization.Charting.Series ("Placares");


            //series.ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.StackedArea;
            //series.IsValueShownAsLabel = true;


            //foreach (Model.Campeonatos.Reports.GolsFrequencia gols in list)
            //{
                
            //   //series.Points.Add(new System.Web.UI.DataVisualization.Charting.DataPoint (
            //}



            //this.ctlChartPlacares.Series.Clear();
            //this.ctlChartPlacares.Series.Add(series);


                

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
