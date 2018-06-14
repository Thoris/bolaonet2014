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

namespace BolaoNet.WebSite.Resultados
{
    public partial class CampeonatoResultado : CampeonatoUserBasePage
    {
        #region Variables
        #endregion

        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {
            this.JogoDetail.JogoMode = WebSite.Controls.JogoDetail.Mode.Result;

            if (!IsPostBack)
            {
                Business.Campeonatos.Support.Jogo business = new Business.Campeonatos.Support.Jogo(base.UserName);                
                business.Campeonato = CurrentCampeonato;
                
                



                //Se encontrou valor para o ID do jogo
                if (Request.QueryString["IDJogo"] != null)
                {
                    //this.JogoDetail.LoadJogo(Convert.ToInt64 (Request.QueryString["IDJogo"]));

                    business.IDJogo = Convert.ToInt64(Request.QueryString["IDJogo"].ToString());


                }//endif encointrou o id do jogo

                business.Load();
                this.JogoDetail.Jogo = business;

            }
        }
        #endregion

        #region Methods
        private void Save()
        {
            Model.Campeonatos.Jogo jogo = this.JogoDetail.Jogo;

            Business.Campeonatos.Support.Jogo business = new BolaoNet.Business.Campeonatos.Support.Jogo(
                base.UserName, jogo);


            //Se não conseguiu inserir o resultado
            if (!business.InsertResult(
                jogo.GolsTime1, jogo.GolsTime2,
                jogo.PenaltisTime1, jogo.PenaltisTime2))
            {
                base.ShowErrors("Ocorreu um erro interno ao tentar salvar o resultado.");
            }
            //Se conseguiu inserir o resultado
            else
            {
                base.ShowMessages("Jogo armazenado com sucesso.");

            }//endif inserir o resultado


        }
        #endregion

        #region Events
        protected void Page_Init(object sender, EventArgs e)
        {
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

                case WebSite.Controls.MenuManager.MenuTools.Return:
                    Response.Redirect("~/Campeonatos/CampeonatoJogos.aspx");
                    break;

                default:
                    break;
            }
        }
        #endregion
    }
}
