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

namespace BolaoNet.WebSite.Boloes.Admin
{
    public partial class GerenciamentoBolao : BolaoUserBasePage
    {
        #region Properties
        public Business.Util.ActionMode ModeView
        {
            get
            {
                if (ViewState["BolaoInfo.Mode"] == null)
                    return Business.Util.ActionMode.View;
                else
                    return (Business.Util.ActionMode)ViewState["BolaoInfo.Mode"];
            }
            set
            {
                ChangeModeView(value);

                ViewState["BolaoInfo.Mode"] = value;


            }
        }
        public Model.Boloes.Bolao BolaoData
        {
            get { return (Model.Boloes.Bolao)ViewState["BolaoInfo"]; }
            set
            {
                if (ViewState["BolaoInfo"] != value && value != null)
                {
                    ShowBolao(value);
                }

                ViewState["BolaoInfo"] = value;
            }
        }
        
        #endregion

        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Carregando todos os campeonatos
                Business.Campeonatos.Support.Campeonato campeonato = new Business.Campeonatos.Support.Campeonato(base.UserName);
                this.cboCobertura.DataSource = campeonato.SelectAll(null);
                this.cboCobertura.DataTextField = "Nome";
                this.cboCobertura.DataValueField = "Nome";
                this.cboCobertura.DataBind();


                string mode = Request.QueryString["mode"];

                if (string.IsNullOrEmpty(mode) && Request.QueryString["NomeBolao"] == null)
                {
                    mode = ((int)Business.Util.ActionMode.Edit).ToString ();
                }

                ModeView = Business.Util.Mode.GetAction(mode);


                //Changing the mode view
                ChangeModeView(ModeView);

                string nomeBolao = CurrentBolao.Nome;

                if (Request.QueryString["NomeBolao"] != null)
                {
                    nomeBolao = Request.QueryString["NomeBolao"];
                }

                Business.Boloes.Support.Bolao bolao = new BolaoNet.Business.Boloes.Support.Bolao(base.UserName, nomeBolao);
                bolao.Load();

                //BolaoData = (Model.Boloes.Bolao)bolao;

                ShowBolao(bolao);
            }

        }
        #endregion

        #region Methods
        private void EditMode(bool enable)
        {
            this.fileUploadPicture.Visible = enable;

            this.txtCity.Visible = enable;
            this.txtCountry.Visible = enable;
            this.txtDataInicio.Visible = enable;
            this.txtHorasAllowed.Visible = enable;
            this.txtNome.Visible = enable;
            this.txtState.Visible = enable;
            this.txtTaxa.Visible = enable;
            this.chkForumAtivado.Enabled = enable;
            this.chkIniciado.Enabled = enable;
            this.chkPermitirApostasDepois.Enabled = enable;
            this.chkPermitirMsgAnonimos.Enabled = enable;
            this.chkPublico.Enabled = enable;
            this.PopCalendarBirthDate.Visible = enable;
            this.cboCobertura.Visible = enable;


            this.lblCity.Visible = !enable;
            this.lblCobertura.Visible = !enable;
            this.lblCountry.Visible = !enable;
            this.lblDataInicio.Visible = !enable;
            this.lblHorasPermitidasAntes.Visible = !enable;
            this.lblNome.Visible = !enable;
            this.lblState.Visible = !enable;
            this.lblTaxa.Visible = !enable;           
            



        }
        public void ChangeModeView(Business.Util.ActionMode mode)
        {





            switch (mode)
            {
                case Business.Util.ActionMode.Insert:

                    EditMode(true);

                    break;

                case BolaoNet.Business.Util.ActionMode.Edit:

                    EditMode(true);

                    this.lblNome.Visible = true;
                    this.txtNome.Visible = false;

                    this.cboCobertura.Visible = false;
                    this.lblCobertura.Visible = true;


                    break;

                case BolaoNet.Business.Util.ActionMode.View:

                    EditMode(false);

                    break;

                case BolaoNet.Business.Util.ActionMode.Delete:

                    EditMode(false);

                    break;
            }
        }       
        private Model.Boloes.Bolao GetBolao()
        {
            Model.Boloes.Bolao entry = (Model.Boloes.Bolao)ViewState["BolaoInfo"];

            if (ModeView ==  BolaoNet.Business.Util.ActionMode.View)
                return entry;


            if (entry == null)
                entry = new BolaoNet.Model.Boloes.Bolao();


            entry.Nome = this.txtNome.Text;
            entry.Campeonato = new BolaoNet.Model.Campeonatos.Campeonato(this.cboCobertura.Text);
            entry.ApostasApenasAntes = !this.chkPermitirApostasDepois.Checked;
            entry.HorasLimiteAposta = int.Parse (this.txtHorasAllowed.Text);

            if (this.txtDataInicio.Text.Length > 0)
                entry.DataInicio = DateTime.Parse(this.txtDataInicio.Text);

            entry.TaxaParticipacao = decimal.Parse(this.txtTaxa.Text);
            entry.Publico = this.chkPublico.Checked;

            entry.IsIniciado = this.chkIniciado.Checked;

            if (this.lblDataIniciado.Text.Length > 0 && this.lblDataIniciado.Text != "-")
                entry.DataIniciado = DateTime.Parse(this.lblDataIniciado.Text);

            entry.IniciadoBy = this.lblIniciadoPor.Text;

            entry.ForumAtivado = this.chkForumAtivado.Checked;
            entry.PermitirMsgAnonimos = this.chkPermitirMsgAnonimos.Checked;

            entry.Pais = this.txtCountry.Text;
            entry.Estado = this.txtState.Text;
            entry.Cidade = this.txtCity.Text;

            entry.Descricao = this.txtDescricao.Text;





            return entry;
        }
        private void ShowBolao(Model.Boloes.Bolao bolao)
        {

            string fileImage = "~/Images/Database/Boloes/" + bolao.Nome + ".jpg";

            if (!System.IO.File.Exists(Server.MapPath(fileImage)))
                fileImage = "~/Images/Database/Boloes/No-Image.png";

            this.imgUser.ImageUrl = fileImage;


            this.txtNome.Text = bolao.Nome;
            this.lblNome.Text = this.txtNome.Text;


            this.cboCobertura.SelectedValue = bolao.Campeonato.Nome;
            this.lblCobertura.Text = bolao.Campeonato.Nome;


            this.chkPermitirApostasDepois.Checked = !bolao.ApostasApenasAntes;
            this.txtHorasAllowed.Text = bolao.HorasLimiteAposta.ToString();
            this.lblHorasPermitidasAntes.Text = this.txtHorasAllowed.Text;


            if (bolao.DataInicio != DateTime.MinValue)
            {
                this.txtDataInicio.Text = bolao.DataInicio.ToString("dd/MM/yyyy HH:mm:ss");
                this.lblDataInicio.Text = this.txtDataInicio.Text;
            }
            else
            {
                this.txtDataInicio.Text = "";
                this.lblDataInicio.Text = "-";
            }



            this.txtTaxa.Text = bolao.TaxaParticipacao.ToString();
            this.lblTaxa.Text = this.txtTaxa.Text;

            this.chkPublico.Checked = bolao.Publico;

            this.chkIniciado.Checked = bolao.IsIniciado;
            
            if (bolao.DataInicio != DateTime.MinValue)
                this.lblDataIniciado.Text = bolao.DataInicio.ToString("dd/MM/yyyy HH:mm:ss");
            else
                this.lblDataIniciado.Text = "-";

            this.lblIniciadoPor.Text = bolao.IniciadoBy;
            if (this.lblIniciadoPor.Text.Length == 0)
                this.lblIniciadoPor.Text = "-";


            this.chkForumAtivado.Checked = bolao.ForumAtivado;
            this.chkPermitirMsgAnonimos.Checked = bolao.PermitirMsgAnonimos;


            this.txtCountry.Text = bolao.Pais;
            this.lblCountry.Text = this.txtCountry.Text;

            this.txtState.Text = bolao.Estado;
            this.lblState.Text = this.txtState.Text;
            
            this.txtCity.Text = bolao.Cidade;
            this.lblCity.Text = this.txtCity.Text;
            



        }
        private void Save()
        {
            Model.Boloes.Bolao model = GetBolao ();

            SavePictureFile(model.Nome);


            Business.Boloes.Support.Bolao business = new BolaoNet.Business.Boloes.Support.Bolao(base.UserName, model.Nome);
            business.Copy(model);

            if (business.Update())
            {
                base.ShowMessages("Bolão armazenado com sucesso.");
            }
            else
            {
                base.ShowErrors("Erro ao armazenar o bolão");
            }
        }
        public bool SavePictureFile(string nomeBolao)
        {
            if (this.fileUploadPicture.HasFile)
            {
                // BLOQUEIA A TRANSFERÊNCIA DE ARQUIVOS MAIOR QUE 1MB
                if (this.fileUploadPicture.PostedFile.ContentLength < 1048576)
                {
                    this.fileUploadPicture.SaveAs(Server.MapPath("~/Images/Database/Boloes/" + nomeBolao + ".jpg"));
                    return true;
                }
                else
                {
                    return false;
                    //// MENSAGEM INFORMATIVA PARA O USUÁRIO
                    //ClientScript.RegisterStartupScript(
                    //    this.GetType(),
                    //    "arquivo",
                    //    "alert('Limite máximo para arquivo é de 1MB');",
                    //    true);
                }

            }

            return true;
        }
        #endregion

        #region Events
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

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

                default:
                    break;
            }
        }
        #endregion
    }
}
