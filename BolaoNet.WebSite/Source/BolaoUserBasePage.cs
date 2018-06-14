using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace BolaoNet.WebSite
{
    public class BolaoUserBasePage : CampeonatoUserBasePage, Source.INavigate, Source.IValidate
    {
        #region Variables
        //protected static Model.Boloes.Bolao _currentBolao = null;
        #endregion

        #region Properties
        public static Model.Boloes.Bolao CurrentBolao
        {
            get 
            {

                if (HttpContext.Current.Session == null || HttpContext.Current.Session["CurrentBolao"] == null)
                    return null;

                return (Model.Boloes.Bolao) HttpContext.Current.Session["CurrentBolao"];

                //return _currentBolao; 
            }
            set 
            {
                if (HttpContext.Current.Session != null)
                    HttpContext.Current.Session["CurrentBolao"] = value; 
            }
        }
        
        protected Model.Boloes.Bolao BaseCurrentBolao
        {
            get
            {

                if (HttpContext.Current.Session == null || HttpContext.Current.Session["CurrentBolao"] == null)
                    return null;

                //return _currentBolao;
                return (Model.Boloes.Bolao)HttpContext.Current.Session["CurrentBolao"];
            }
            set
            {
                if (HttpContext.Current.Session != null)
                    HttpContext.Current.Session["CurrentBolao"] = value;
                //_currentBolao = value;
            }
        }
        
        #endregion

        #region Events
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);


            if (!IsPostBack)
            {
                if (Request.QueryString["Bolao"] != null)
                {
                    if (CurrentBolao == null ||
                        string.Compare(Request.QueryString["Bolao"].ToString(), CurrentBolao.Nome, true) != 0)
                    {
                        Business.Boloes.Support.Bolao business = new
                            Business.Boloes.Support.Bolao(
                            base.UserName, Request.QueryString["Bolao"].ToString());

                        if (business.Load())
                        {
                            CurrentBolao = business;
                            CurrentCampeonato = business.Campeonato;
                        }
                        else
                        {
                            CurrentBolao = null;
                            CurrentCampeonato = null;
                        }
                    }//endif currentBolao = null

                }//if querystring != null
            }

            //Se não foi encontrado o bolão
            if (CurrentBolao == null)
            {
                Response.Redirect("~\\Boloes\\SelectBolao.aspx?ReturnURL=" +
                    HttpContext.Current.Request.CurrentExecutionFilePath);
                return;
            }
            //Se foi encontrado o bolão
            else if (!IsPostBack)
            {
                //Se não é válido para visualizar os dados
                if (!IsValidToShow())
                {
                    Response.Redirect("~\\Boloes\\BolaoNaoPermitido.aspx");
                    return;

                }//endif válido para visualizar os dados

            }//endif bolão válido
        }
        #endregion

        #region Navigate Methods
        public new void NavigateHome()
        {
            Response.Redirect("~/Boloes/BolaoHome.aspx");
        }
        #endregion


        #region IValidate Members

        public virtual bool IsValidToShow()
        {
            //Se o bolão ainda não foi carregado
            //if (!_currentBolao.IsLoaded)
            //{
                //Carregando os dados do bolão
                Business.Boloes.Support.Bolao business = new
                    Business.Boloes.Support.Bolao(
                    //base.UserName, _currentBolao.Nome);
                    base.UserName, CurrentBolao.Nome);

                business.Load();

                //Atribuindo ao bolão atual
                //_currentBolao = (Model.Boloes.Bolao)business;
                CurrentBolao = (Model.Boloes.Bolao)business;

            //}//endif bolão não iniciado.


            //Se o bolão só permite apostas antes do início do campeonato
            //if (_currentBolao.ApostasApenasAntes)
            if (CurrentBolao.ApostasApenasAntes)
            {
                //Se o campeonato foi iniciado
                //if (_currentBolao.IsIniciado)
                if (CurrentBolao.IsIniciado)
                    return true;
                //Se o campeonato ainda não foi inciado
                else
                {

                    //Buscando as regras do usuário
                    string [] roles = System.Web.Security.Roles.Provider.GetRolesForUser(base.UserName);

                    //Percorrendo todos os roles
                    foreach (string role in roles)
                    {
                        //Se o usuário é permitido visualização mesmo que o bolão não foi iniciado
                        if (string.Compare(role, "Administrador", true) == 0 || string.Compare(role, "Gerenciador de Bolão", true) == 0)                        
                            return true;
                        

                    }//end foreach roles

                    return false;

                }//endif iniciado
            }
            //Se pode visualizar as apostas de todos
            else
                return true;


        }

        #endregion
    }
}
