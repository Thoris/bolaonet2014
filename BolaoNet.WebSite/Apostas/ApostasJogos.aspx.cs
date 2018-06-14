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
using System.IO;

namespace BolaoNet.WebSite.Apostas
{
    public partial class ApostasJogos : ApostaBolaoBasePage
    {
        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {
            lnkDownloaApostas.NavigateUrl = "~/Apostas/DownloadApostas.aspx";

            if (!IsEnabledToAposta(base.BaseCurrentBolao))
            {
                this.btnSave.Visible = false;
                this.ctlMenuTools.SaveVisible = false;
            }

        }
        #endregion

        #region Methods

        private bool IsEnabledToAposta(Model.Boloes.Bolao bolao)
        {
            //Se deve ser feita aposta dos jogos antes do bolão começar
            if (bolao.ApostasApenasAntes)
            {
                //Se o bolão ainda não foi iniciado
                if (bolao.IsIniciado)
                    return false;
                else
                    return true;
            }
            return true;

        }


        private void Save()
        {

            //Carregando todas as apostas modificadas
            List<Model.Boloes.JogoUsuario> list = this.ctlListJogo.LoadApostasChanged();

            //Para cada jogo modificado
            foreach (Model.Boloes.JogoUsuario jogo in list)
            {
                Business.Boloes.Support.JogoUsuario business = new BolaoNet.Business.Boloes.Support.JogoUsuario(
                    base.UserName, jogo);

                business.Bolao = CurrentBolao;
                business.UserName = base.UserName;
                business.Automatico = false;

                business.Insert();

            }//end foreach

            Business.Boloes.Support.JogoUsuario correcao = new BolaoNet.Business.Boloes.Support.JogoUsuario(
                base.UserName, new Model.Boloes.JogoUsuario());
            
            correcao.CorrecaoEliminatorias(base.BaseCurrentBolao, base.UserName);
            
            this.ctlListJogo.BindGrid();


            base.ShowMessages("Apostas armazenadas com sucesso");


        }
        #endregion

        #region Events
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            this.ctlMenuTools.ButtonClick += new CommandEventHandler(ctlMenuTools_ButtonClick);
            this.ctlNavigateHomeControl.ButtonClick += new CommandEventHandler(ctlNavigateHomeControl_ButtonClick);

            this.ctlListJogo.ModeList = WebSite.Controls.Filters.ListJogo.Mode.Apostas;
            this.ctlListJogo.UserNameToCheck = CurrentUserName;
            

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
       
        #endregion

    }
}
