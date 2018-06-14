using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;

namespace BolaoNet.WebSite.Apostas
{
    public partial class JogosApostasAutomaticas : ApostaBolaoBasePage
    {
        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.txtDataInicial.Text = DateTime.Now.ToString("dd/MM/yyyy");
                this.txtDataFinal.Text = DateTime.Now.ToString("dd/MM/yyyy");



                Business.Campeonatos.Support.Campeonato campeonato = new BolaoNet.Business.Campeonatos.Support.Campeonato(base.UserName);
                campeonato.Nome = CurrentCampeonato.Nome;

                IList<int> list = campeonato.LoadRodadas();

                foreach (int value in list)                
                    this.cboRodadas.Items.Add(value.ToString ());
                
                
            }
        }
        #endregion

        #region Methods
        private long GetTotal(Model.Boloes.JogoUsuario.TypeAposta aposta, Model.Boloes.JogoUsuario.TypeAutomatico typeAutomatico)
        {
            DateTime dataInicial = DateTime.MinValue;
            DateTime dataFinal = DateTime.MinValue;
            int rodada = 0;

            if (this.rdoPeriodo.Checked)
            {
                dataInicial = Convert.ToDateTime(this.txtDataInicial.Text);
                dataFinal = Convert.ToDateTime(this.txtDataFinal.Text);
            }
            else if (this.rdoRodada.Checked)
            {
                rodada = Convert.ToInt32(this.cboRodadas.Text);
            }

            Business.Boloes.Support.JogoUsuario jogoUsuario = new BolaoNet.Business.Boloes.Support.JogoUsuario(base.UserName);

            return jogoUsuario.SelectCountByPeriodo(
                base.BaseCurrentBolao, base.UserName, rodada,
                dataInicial, dataFinal, aposta,
                typeAutomatico, "");
        }

        private void Save()
        {
            if (!Page.IsValid)
                return;


            DateTime dataInicial = DateTime.MinValue;
            DateTime dataFinal = DateTime.MaxValue;

            int random1 = 0;
            int random2 = 0;
            int time1 = 0;
            int time2 = 0;
            int rodada = 0;
            bool random = false;
            string nomeTime = null;

            Model.Boloes.JogoUsuario.TypeAposta typeAposta = Model.Boloes.JogoUsuario.TypeAposta.Nao_Apostados;
            Model.Boloes.JogoUsuario.TypeAutomatico typeAutomatico = Model.Boloes.JogoUsuario.TypeAutomatico.Automatico;



            if (this.rdoDefault.Checked)
            {
            }
            else if (this.rdoPeriodo.Checked)
            {
                dataInicial = Convert.ToDateTime(this.txtDataInicial.Text);
                dataFinal = Convert.ToDateTime(this.txtDataFinal.Text);
            }
            else if (this.rdoRodada.Checked)
            {
                rodada = Convert.ToInt32(this.cboRodadas.Text);
            }


            if (this.rdoFixo.Checked)
            {
                time1 = Convert.ToInt32(this.txtTimeCasa.Text);
                time2 = Convert.ToInt32(this.txtTimeFora.Text);

                random = false;
            }
            else if (this.rdoAleatorio.Checked)
            {
                random1 = Convert.ToInt32(this.txtValorInicial.Text);
                random2 = Convert.ToInt32(this.txtValorFinal.Text);

                random = true;
            }



            if (this.rdoTodasApostas.Checked)
            {
                typeAposta = BolaoNet.Model.Boloes.JogoUsuario.TypeAposta.Todos;
                typeAutomatico = BolaoNet.Model.Boloes.JogoUsuario.TypeAutomatico.Todos;
            }
            else if (this.rdoNaoApostados.Checked)
            {
                typeAposta = BolaoNet.Model.Boloes.JogoUsuario.TypeAposta.Nao_Apostados;
                typeAutomatico = BolaoNet.Model.Boloes.JogoUsuario.TypeAutomatico.Todos;

            }
            else if (this.rdoApostados.Checked)
            {
                typeAposta = BolaoNet.Model.Boloes.JogoUsuario.TypeAposta.Apostados;


                if (this.rdoApostadoTodos.Checked)
                {
                    typeAutomatico = BolaoNet.Model.Boloes.JogoUsuario.TypeAutomatico.Todos;
                }
                else if (this.rdoApostadoAuto.Checked)
                {
                    typeAutomatico = BolaoNet.Model.Boloes.JogoUsuario.TypeAutomatico.Automatico;
                }
                else if (this.rdoApostadoManual.Checked)
                {
                    typeAutomatico = BolaoNet.Model.Boloes.JogoUsuario.TypeAutomatico.Manual;
                }
            }





            Business.Boloes.Support.JogoUsuario business = new BolaoNet.Business.Boloes.Support.JogoUsuario(base.UserName);
            IList<Framework.DataServices.Model.EntityBaseData> list = business.InsertApostasAuto(
                CurrentBolao, base.UserName, typeAposta, typeAutomatico,
                dataInicial, dataFinal, rodada, random,
                time1, time2, random1, random2, nomeTime);


            Session["Apostas"] = list;

            Response.Redirect("~/Apostas/ApostasAutoResultado.aspx");
            
        }

        #endregion

        #region Events
        protected override void  OnInit(EventArgs e)
        {
            this.ctlMenuTools.ButtonClick += new CommandEventHandler(ctlMenuTools_ButtonClick);
            this.ctlNavigateHomeControl.ButtonClick += new CommandEventHandler(ctlNavigateHomeControl_ButtonClick);


            //Atualizando o bolão que está sendo analisado
            Business.Boloes.Support.Bolao business = new BolaoNet.Business.Boloes.Support.Bolao(
                base.UserName, CurrentBolao.Nome);

            business.Load();
            CurrentBolao = business;


            if (CurrentBolao.ApostasApenasAntes && CurrentBolao.IsIniciado)
            {
                this.MultiViewAuto.ActiveViewIndex = 1;
                this.ctlMenuTools.SaveVisible = false;
            }
            else
            {
                this.ctlMenuTools.SaveVisible = true;
                this.MultiViewAuto.ActiveViewIndex = 0;
            }

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
        protected void rdoDefault_CheckedChanged(object sender, EventArgs e)
        {
            this.MultiViewApostasTipo.ActiveViewIndex = 0;
        }
        protected void rdoPeriodo_CheckedChanged(object sender, EventArgs e)
        {
            this.MultiViewApostasTipo.ActiveViewIndex = 1;
        }
        protected void rdoRodada_CheckedChanged(object sender, EventArgs e)
        {
            this.MultiViewApostasTipo.ActiveViewIndex = 2;
        }
        protected void rdoFixo_CheckedChanged(object sender, EventArgs e)
        {
            this.MultiViewTipoValores.ActiveViewIndex = 0;
        }
        protected void rdoAleatorio_CheckedChanged(object sender, EventArgs e)
        {
            this.MultiViewTipoValores.ActiveViewIndex = 1;
        }

        protected void PopCalendarDataInicial_SelectionChanged(object sender, EventArgs e)
        {
            DateTime dataInicial;
            DateTime dataFinal;

            if (this.txtDataFinal.Text.Length == 0 || this.txtDataInicial.Text.Length == 0)
            {
                this.lblTotalPeriodo.Text = "";
                return;
            }

            dataInicial = Convert.ToDateTime(this.txtDataInicial.Text);
            dataFinal = Convert.ToDateTime(this.txtDataFinal.Text);


            Business.Boloes.Support.JogoUsuario jogoUsuario = new BolaoNet.Business.Boloes.Support.JogoUsuario(base.UserName);

            this.lblTotalPeriodo.Text = jogoUsuario.SelectCountByPeriodo(
                base.BaseCurrentBolao, base.UserName, 0,
                dataInicial, dataFinal, Model.Boloes.JogoUsuario.TypeAposta.Todos, 
                Model.Boloes.JogoUsuario.TypeAutomatico.Todos, "").ToString ();

        }
        protected void PopCalendarDataFinal_SelectionChanged(object sender, EventArgs e)
        {
            DateTime dataInicial;
            DateTime dataFinal;

            if (this.txtDataFinal.Text.Length == 0 || this.txtDataInicial.Text.Length == 0)
            {
                this.lblTotalPeriodo.Text = "";
                return;
            }

            dataInicial = Convert.ToDateTime(this.txtDataInicial.Text);
            dataFinal = Convert.ToDateTime(this.txtDataFinal.Text);


            Business.Boloes.Support.JogoUsuario jogoUsuario = new BolaoNet.Business.Boloes.Support.JogoUsuario(base.UserName);

            this.lblTotalPeriodo.Text = jogoUsuario.SelectCountByPeriodo(
                base.BaseCurrentBolao, base.UserName, 0,
                dataInicial, dataFinal, Model.Boloes.JogoUsuario.TypeAposta.Todos,
                Model.Boloes.JogoUsuario.TypeAutomatico.Todos, "").ToString();
        }
        protected void rdoTodasApostas_CheckedChanged(object sender, EventArgs e)
        {
            this.MultiViewApostas.ActiveViewIndex = 0;

            this.lblTotalJogos.Text = GetTotal(BolaoNet.Model.Boloes.JogoUsuario.TypeAposta.Todos, 
                BolaoNet.Model.Boloes.JogoUsuario.TypeAutomatico.Todos).ToString ();
        }
        protected void rdoNaoApostados_CheckedChanged(object sender, EventArgs e)
        {
            this.MultiViewApostas.ActiveViewIndex = 0;

            this.lblTotalJogosNaoApostados.Text = GetTotal(BolaoNet.Model.Boloes.JogoUsuario.TypeAposta.Nao_Apostados,
                BolaoNet.Model.Boloes.JogoUsuario.TypeAutomatico.Todos).ToString();
        }
        protected void rdoApostados_CheckedChanged(object sender, EventArgs e)
        {

            this.MultiViewApostas.ActiveViewIndex = 1;

            if (this.rdoApostadoManual.Checked)
            {
                this.lbltotalJogosApostados.Text = GetTotal(BolaoNet.Model.Boloes.JogoUsuario.TypeAposta.Apostados,
                    BolaoNet.Model.Boloes.JogoUsuario.TypeAutomatico.Manual).ToString();
            }
            else if (this.rdoApostadoAuto.Checked)
            {
                this.lbltotalJogosApostados.Text = GetTotal(BolaoNet.Model.Boloes.JogoUsuario.TypeAposta.Apostados,
                    BolaoNet.Model.Boloes.JogoUsuario.TypeAutomatico.Automatico).ToString();
            }
            else
            {
                this.lbltotalJogosApostados.Text = GetTotal(BolaoNet.Model.Boloes.JogoUsuario.TypeAposta.Apostados,
                    BolaoNet.Model.Boloes.JogoUsuario.TypeAutomatico.Todos).ToString();
            }


        }
        protected void cboRodadas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int rodada = Convert.ToInt32(this.cboRodadas.Text);

            Business.Boloes.Support.JogoUsuario jogoUsuario = new BolaoNet.Business.Boloes.Support.JogoUsuario(base.UserName);

            this.lblTotalRodada.Text = jogoUsuario.SelectCountByPeriodo(
                base.BaseCurrentBolao, base.UserName, rodada,
                DateTime.MinValue, DateTime.MinValue, Model.Boloes.JogoUsuario.TypeAposta.Todos,
                Model.Boloes.JogoUsuario.TypeAutomatico.Todos, "").ToString();
        }
        protected void rdoApostadoTodos_CheckedChanged(object sender, EventArgs e)
        {
            rdoApostados_CheckedChanged(sender, e);
        }
        protected void rdoApostadoAuto_CheckedChanged(object sender, EventArgs e)
        {
            rdoApostados_CheckedChanged(sender, e);
        }
        protected void rdoApostadoManual_CheckedChanged(object sender, EventArgs e)
        {
            rdoApostados_CheckedChanged(sender, e);
        }
        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            Save();
        }
        protected void cvTipoAposta_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!this.rdoDefault.Checked && !this.rdoPeriodo.Checked && !this.rdoRodada.Checked)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }
        protected void cvTipoValor_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!this.rdoFixo.Checked && !this.rdoAleatorio.Checked)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }
        protected void cvTipoAtualizacao_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!this.rdoTodasApostas.Checked && !this.rdoNaoApostados.Checked && !this.rdoApostados.Checked)
            {
                args.IsValid = false;
            }
            else
            {
                if (this.rdoApostados.Checked && !this.rdoApostadoTodos.Checked &&
                    !this.rdoApostadoManual.Checked && !this.rdoApostadoTodos.Checked)
                {
                    args.IsValid = false;
                }
                else
                {
                    args.IsValid = true;
                }
            }
        }
        #endregion
 
}
}
