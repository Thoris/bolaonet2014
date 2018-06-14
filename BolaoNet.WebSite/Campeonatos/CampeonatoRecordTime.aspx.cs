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
    public partial class CampeonatoRecordTime : CampeonatoUserBasePage
    {
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

        }
        #endregion

        #region Events

        protected void mnuRecords_MenuItemClick(object sender, MenuEventArgs e)
        {
            IList<Model.Campeonatos.CampeonatoRecord> general = null;
            IList<Model.Campeonatos.CampeonatoRecord> dentro = null;
            IList<Model.Campeonatos.CampeonatoRecord> fora = null;



            int action = int.Parse (e.Item.Value.ToString());

            Business.Campeonatos.Support.Campeonato business = 
                new BolaoNet.Business.Campeonatos.Support.Campeonato(base.UserName, CurrentCampeonato.Nome);
            business.LoadRecordPlacar((Dao.Campeonatos.RecordTipoPesquisa)action, out general, out dentro,out  fora);


            this.grdGeneral.DataSource = general;
            this.grdGeneral.DataBind();

            this.grdDentro.DataSource = dentro;
            this.grdDentro.DataBind();

            this.grdFora.DataSource = fora;
            this.grdFora.DataBind();



            switch ((Dao.Campeonatos.RecordTipoPesquisa)action)
            {
                case BolaoNet.Dao.Campeonatos.RecordTipoPesquisa.QtdJogosSemGanhar:
                    this.lblTitle.Text = "Quantidade de jogos sem ganhar atualmente";
                    break;
                case BolaoNet.Dao.Campeonatos.RecordTipoPesquisa.QtdJogosSemPerder:
                    this.lblTitle.Text = "Quantidade de jogos sem perder atualmente";
                    break;
                case BolaoNet.Dao.Campeonatos.RecordTipoPesquisa.RecordQtdJogosSemGanhar:
                    this.lblTitle.Text = "Record de quantidade de jogos sem ganhar";
                    break;
                case BolaoNet.Dao.Campeonatos.RecordTipoPesquisa.RecordQtdJogosSemPerder:
                    this.lblTitle.Text = "Record de quantidade de jogos sem perder";
                    break;
                case BolaoNet.Dao.Campeonatos.RecordTipoPesquisa.RecordSeqDerrotas:
                    this.lblTitle.Text = "Record de sequência de derrotas";
                    break;
                case BolaoNet.Dao.Campeonatos.RecordTipoPesquisa.RecordSeqEmpates:
                    this.lblTitle.Text = "Record de sequência de empates";
                    break;
                case BolaoNet.Dao.Campeonatos.RecordTipoPesquisa.RecordSeqVitorias:
                    this.lblTitle.Text = "Record de sequência de vitórias";
                    break;
                case BolaoNet.Dao.Campeonatos.RecordTipoPesquisa.SequenciaDerrotas:
                    this.lblTitle.Text = "Sequência de derrotas atualmente";
                    break;
                case BolaoNet.Dao.Campeonatos.RecordTipoPesquisa.SequenciaEmpates:
                    this.lblTitle.Text = "Sequência de empates atualmente";
                    break;
                case BolaoNet.Dao.Campeonatos.RecordTipoPesquisa.SequenciaVitorias:
                    this.lblTitle.Text = "Sequência de vitórias atualmente";
                    break;

            }

            return;





        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            this.ctlNavigateHomeControl.ButtonClick += new CommandEventHandler(ctlNavigateHomeControl_ButtonClick);
            this.ctlMenuTools.ButtonClick += new CommandEventHandler(ctlMenuTools_ButtonClick);
        }

        private void ctlNavigateHomeControl_ButtonClick(object sender, CommandEventArgs e)
        {
            base.NavigateHome();
        }

        private void ctlMenuTools_ButtonClick(object sender, CommandEventArgs e)
        {
            
        }

        #endregion
    }
}
