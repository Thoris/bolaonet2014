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

namespace BolaoNet.WebSite.Visitante
{
    public partial class Login : System.Web.UI.Page
    {
        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {
            //string user = this.Profile.UserName;
            //string user = Context.Profile.UserName;

            //Profile.Bolao = "Teste";


            
            //HttpContext.Current.Profile["Bolao"] = "Teste";


            //bool result = Membership.ValidateUser("thoris", "thoris");



           //FormsAuthentication.SetAuthCookie("thoris", true);

            //if (Request.Cookies["username"] == null || 
            //    Request.Cookies["username"].Value.ToString().Trim() == "")
            //{
            //    this.loginUser.RememberMeSet = true;
            //}
            //else
            //{
            //    this.loginUser.UserName = Request.Cookies["username"].Value.ToString().Trim();
            //    this.loginUser.RememberMeSet = true;
            //}

            

         




            //if (!IsPostBack)
            //{
            //    if (!HttpContext.Current.Request.IsAuthenticated)
            //    {
            //        if (Request.Cookies["BolaoNet"] != null)
            //        {
            //            string userName = Request.Cookies["BolaoNet"]["UserName"];
            //            string password = Request.Cookies["BolaoNet"]["password"];

            //            TextBox txtUserName = (TextBox)this.loginUser.FindControl("UserName");
            //            TextBox txtPassword = (TextBox)this.loginUser.FindControl("password");
            //        }
            //    }
            //}





        }
        #endregion

        #region Events
        protected void loginUser_LoggingIn(object sender, LoginCancelEventArgs e)
        {
           

        }
        #endregion

        protected void loginUser_LoggedIn(object sender, EventArgs e)
        {
            bool updated = false;

            
            //Atribuindo o nome do usuário
            UserBasePage.CurrentUserName = this.loginUser.UserName;
            
            Business.Profile.CustomProfile profile = Business.Profile.CustomProfile.GetProfile(this.loginUser.UserName);

            #region Campeonato
            //Se já tem nenhum campeonato selecionado
            if (CampeonatoUserBasePage.CurrentCampeonato != null)
            {
                //Atribuindo o campeonato no profile
                profile.NomeCampeonato = CampeonatoUserBasePage.CurrentCampeonato.Nome;
                updated = true;
            }
            //Se não tem um campeonato selecionado
            else
            {
                string nomeCampeonato = profile.NomeCampeonato;
                
                //Se existe existe um nome de campeonato associado ao profile
                if (!string.IsNullOrEmpty(nomeCampeonato))
                {
                    //Carregando o campeonato para o profile
                    Business.Campeonatos.Support.Campeonato business = new BolaoNet.Business.Campeonatos.Support.Campeonato(
                        UserBasePage.CurrentUserName, nomeCampeonato);
                    business.Load ();

                    CampeonatoUserBasePage.CurrentCampeonato = business;                        
                }
            }//endif campeonato selecionado

            #endregion

            #region Bolao
            //Se já existe um bolão selecionado
            if (BolaoUserBasePage.CurrentBolao != null)
            {
                //Atribuindo ao profile o bolão selecionado
                profile.NomeBolao = BolaoUserBasePage.CurrentBolao.Nome;
                updated = true;
            }
            else
            {
                string nomeBolao = profile.NomeBolao;

                //Se encontrou um bolão no profile do usuário
                if (!string.IsNullOrEmpty(nomeBolao))
                {
                    //Carregando o bolão para o profile do usuário
                    Business.Boloes.Support.Bolao business = new BolaoNet.Business.Boloes.Support.Bolao(
                        UserBasePage.CurrentUserName, nomeBolao);
                    business.Load();

                    BolaoUserBasePage.CurrentBolao = business;

                }//endif encontrou bolão no profile
            }//bolão selecionado
            #endregion


            //Se teve alteração do profile do usuário
            if (updated)            
                profile.Save();
            




        }
}
}
