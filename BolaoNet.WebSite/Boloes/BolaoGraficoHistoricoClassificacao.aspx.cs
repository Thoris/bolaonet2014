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

namespace BolaoNet.WebSite.Boloes
{
    public partial class BolaoGraficoHistoricoClassificacao : BolaoUserBasePage
    {
        #region Properties
        private IList<Model.Boloes.Reports.UserClassificacaoRodada> DataSourceRodada
        {
            get 
            {
                if (ViewState["DataSourceRodada"] == null)
                    return null;
                else
                {
                    return (IList<Model.Boloes.Reports.UserClassificacaoRodada>)ViewState["DataSourceRodada"];
                }
            }
            set
            {
                ViewState["DataSourceRodada"] = value;
            }
        }
        #endregion

        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Business.Boloes.Support.Bolao business = new BolaoNet.Business.Boloes.Support.Bolao(base.UserName, CurrentBolao.Nome);
                this.cboUsuario.DataSource = business.LoadMembros();
                this.cboUsuario.DataBind();
            }

            BindChart();

        }
        #endregion

        #region Methods
        private void BindChart()
        {
            if (ViewState["List"] == null)
                return;


            List<string> usuarios = (List<string>)ViewState["List"];

            this.ctlChart.Series.Clear();

            //Se não tem nenhuma informação de dados
            if (DataSourceRodada == null)
            {
                Business.Boloes.Support.Bolao business = new BolaoNet.Business.Boloes.Support.Bolao(base.UserName, CurrentBolao.Nome);
                DataSourceRodada = business.LoadHistoricoClassificacao();
 
            }//endif sem informações


            foreach (string usuario in usuarios)
            {

                //Criando os dados do time
                System.Web.UI.DataVisualization.Charting.Series timeSeries =
                    new System.Web.UI.DataVisualization.Charting.Series(usuario, this.cboUsuario.Items.Count);

                timeSeries.IsXValueIndexed = true;
                timeSeries.IsValueShownAsLabel = true;
                timeSeries.ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;

                this.ctlChart.Series.Add(timeSeries);


                //Buscando dados em todas as rodadas
                foreach (Model.Boloes.Reports.UserClassificacaoRodada rodada in DataSourceRodada)
                {

                    foreach (Model.Boloes.Reports.UserClassificacao classificacao in rodada.Membros)
                    {
                        if (string.Compare(classificacao.UserName, usuario, true) == 0)
                        {
                            timeSeries.Points.AddXY(rodada.Rodada, classificacao.Posicao);
                            break;
                        }
                    }

                }//endif buscando dados em todas as rodadas


            }


        }
        #endregion

        #region Events
        protected void grdUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
        protected void grdUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            List<string> usuarios = (List<string>)ViewState["List"];
            usuarios.RemoveAt(e.RowIndex);

            ViewState["List"] = usuarios;

            this.grdUsuarios.DataSource = usuarios;
            this.grdUsuarios.DataBind();

            BindChart();
        }
        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (this.cboUsuario.SelectedIndex == -1)
            {
                //BindChart();
                return;
            }

            List<string> usuarios = (List<string>)ViewState["List"];

            if (usuarios == null)
                usuarios = new List<string>();

            if (usuarios.Contains(this.cboUsuario.Text))
            {
                //BindChart();
                return;
            }
            else
            {
                usuarios.Add(this.cboUsuario.Text);
            }



            ViewState["List"] = usuarios;

            this.grdUsuarios.DataSource = usuarios;
            this.grdUsuarios.DataBind();

            BindChart();

        }
        #endregion

    }
}
