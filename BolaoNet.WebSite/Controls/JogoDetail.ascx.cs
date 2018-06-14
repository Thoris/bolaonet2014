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

namespace BolaoNet.WebSite.Controls
{
    public partial class JogoDetail : System.Web.UI.UserControl
    {
        #region Enumerations/Constants
        public enum Mode
        {
            ReadOnly,
            Result,
            New,
        }
        #endregion

        #region Properties
        public Mode JogoMode
        {
            set 
            {
                ViewState["mode"] = value;

                ChangeMode(value);
            }
            get
            {
                if (ViewState["mode"] == null)
                {
                    return Mode.ReadOnly;
                }
                else
                {
                    return (Mode)ViewState["mode"];
                }
            }
        }
        public Model.Campeonatos.Jogo Jogo
        {
            get 
            {
                return GetCurrentJogo ();
            }
            set
            {
                SetJogo (value);
            }
        }
        public long IDJogo
        {
            get
            {
                if (this.lblIDJogo.Text.Length == 0 || string.Compare(this.lblIDJogo.Text, "0") == 0)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt64(this.lblIDJogo.Text);
                }
            }
            set
            {
                this.lblIDJogo.Text = value.ToString ();
            }
                
        }
            
        #endregion

        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
                
        }
        #endregion

        #region Methods
        public void SetJogo(Model.Campeonatos.Jogo jogo)
        {
            if (jogo.DataJogo == DateTime.MinValue)
            {
                this.lblDataJogo.Text = "";
                this.lblHoraJogo.Text = "";
            }
            else
            {
                this.lblDataJogo.Text = jogo.DataJogo.ToString ("dd/MM/yyyy");
                this.lblHoraJogo.Text = jogo.DataJogo.ToString ("HH:mm");
            }



            if (!jogo.PartidaValida)
            {
                this.lblDataValidacao.Text = "-";
                this.chkValido.Checked = false;
                this.lblValidadoBy.Text = "-";

            }
            else
            {
                this.lblDataValidacao.Text = jogo.DataValidacao.ToString("dd/MM/yyyy HH:mm:ss");
                this.chkValido.Checked = true; 
                this.lblValidadoBy.Text = jogo.ValidadoBy;
            }

            

            this.lblDescricaoTime1.Text = jogo.DescricaoTime1;
            this.lblDescricaoTime2.Text = jogo.DescricaoTime2;

            if (jogo.Estadio == null)
            {
                this.lblEstadio.Text = "";
            }
            else
            {
                this.lblEstadio.Text = jogo.Estadio.Nome;
            }


            if (jogo.Fase == null)
            {
                this.lblFase.Text = "";
            }
            else
            {
                this.lblFase.Text = jogo.Fase.Nome;
            }

            if (jogo.Grupo == null)
            {
                this.lblGrupo.Text = "";
            }
            else
            {
                this.lblGrupo.Text = jogo.Grupo.Nome;
            }

            if (jogo.Rodada == 0)
            {
                this.lblRodada.Text = "";
            }
            else
            {
                this.lblRodada.Text = jogo.Rodada.ToString ();
            }

            if (jogo.Time1 == null)
            {
                this.lblTime1.Text = "";
            }
            else
            {
                this.lblTime1.Text = jogo.Time1.Nome;
                this.imgTime1.ImageUrl = "/Images/database/Times/" + jogo.Time1.Nome + ".gif";
            }


            if (jogo.Time2 == null)
            {
                this.lblTime2.Text = "";
            }
            else
            {
                this.lblTime2.Text = jogo.Time2.Nome;

                this.imgTime2.ImageUrl = "/Images/database/Times/" + jogo.Time2.Nome + ".gif";
            }

            if (string.IsNullOrEmpty(jogo.Titulo))
            {
                this.lblTitulo.Text = "Jogo";
            }
            else
            {
                this.lblTitulo.Text = jogo.Titulo;
            }

            
            this.lblIDJogo.Text = jogo.IDJogo.ToString();


            this.txtGols1.Text = jogo.GolsTime1.ToString();
            this.lblGols1.Text = this.txtGols1.Text;

            this.txtGols2.Text = jogo.GolsTime2.ToString();
            this.lblGols2.Text = this.txtGols2.Text;

            this.txtPenaltis1.Text = jogo.PenaltisTime1.ToString();
            this.lblPenaltis1.Text = this.txtPenaltis1.Text;

            this.txtPenaltis2.Text = jogo.PenaltisTime2.ToString();
            this.lblPenaltis2.Text = this.txtPenaltis2.Text;

            if (jogo.PenaltisTime1 > 0 || jogo.PenaltisTime2 > 0)
            {
                this.chkPenaltis.Checked = true;
                this.cellPenaltis.Visible = true;
            }
            else
            {
                this.chkPenaltis.Checked = false;
                this.cellPenaltis.Visible = false;
            }

            switch (JogoMode)
            {
                case Mode.New:
                    this.chkPenaltis.Visible = false;
                    break;
                case Mode.ReadOnly:
                    this.chkPenaltis.Visible = false;
                    break;
                case Mode.Result:
                    this.chkPenaltis.Visible = true;
                    break;
            }
            

            //this.chkPenaltis.Visible = this.cellPenaltis.Visible;



            if (jogo.Campeonato != null)
            {
                this.lblCampeonato.Text = jogo.Campeonato.Nome;
            }
            else
            {
                this.lblCampeonato.Text = "";
            }


        }
        public Model.Campeonatos.Jogo GetCurrentJogo()
        {
            Model.Campeonatos.Jogo jogo = new BolaoNet.Model.Campeonatos.Jogo();

            if (this.lblIDJogo.Text.Length > 0)
            {
                jogo.IDJogo = Convert.ToInt32(this.lblIDJogo.Text);
            }

            if (this.lblDataJogo.Text.Length > 0 && this.lblHoraJogo.Text.Length > 0)
            {
                jogo.DataJogo = Convert.ToDateTime(this.lblDataJogo.Text + " " + this.lblHoraJogo.Text);
            }

            if (this.lblDataValidacao.Text.Length > 0 && this.lblDataValidacao.Text != "-")
            {
                jogo.ValidadoBy = this.lblValidadoBy.Text;
                jogo.DataValidacao = Convert.ToDateTime(this.lblDataValidacao.Text);
            }

            jogo.DescricaoTime1 = this.lblDescricaoTime1.Text;
            jogo.DescricaoTime2 = this.lblDescricaoTime2.Text;

            jogo.Estadio = new Model.DadosBasicos.Estadio(this.lblEstadio.Text);
            jogo.Fase = new Model.Campeonatos.Fase(this.lblFase.Text);

            if (this.txtGols1.Text.Length > 0)
            {
                jogo.GolsTime1 = Convert.ToInt16(this.txtGols1.Text);
            }

            if (this.txtGols2.Text.Length > 0)
            {
                jogo.GolsTime2 = Convert.ToInt16(this.txtGols2.Text);
            }


            if (this.txtPenaltis1.Text.Length > 0)
            {
                jogo.PenaltisTime1 = Convert.ToInt16(this.txtPenaltis1.Text);
            }
            if (this.txtPenaltis2.Text.Length > 0)
            {
                jogo.PenaltisTime2 = Convert.ToInt16(this.txtPenaltis2.Text);
            }

            if (this.lblRodada.Text.Length > 0)
            {
                jogo.Rodada = Convert.ToInt32(this.lblRodada.Text);
            }

            jogo.Time1 = new Model.DadosBasicos.Time(this.lblTime1.Text);
            jogo.Time2 = new Model.DadosBasicos.Time(this.lblTime2.Text);

            jogo.Titulo = this.lblTime1.Text;


            jogo.Campeonato = new BolaoNet.Model.Campeonatos.Campeonato(this.lblCampeonato.Text);


            return jogo;
        }
        private void ChangeMode(Mode mode)
        {

            switch (JogoMode)
            {
                case Mode.New:
                    break;

                case Mode.ReadOnly:

                    this.txtGols1.Visible = false;
                    this.txtGols2.Visible = false;
                    this.txtPenaltis1.Visible = false;
                    this.txtPenaltis2.Visible = false;


                    this.lblGols1.Visible = true;
                    this.lblGols2.Visible = true;
                    this.lblPenaltis1.Visible = true;
                    this.lblPenaltis2.Visible = true;


                    break;

                case Mode.Result:

                    this.txtGols1.Visible = true;
                    this.txtGols2.Visible = true;
                    this.txtPenaltis1.Visible = true;
                    this.txtPenaltis2.Visible = true;


                    this.lblGols1.Visible = false;
                    this.lblGols2.Visible = false;
                    this.lblPenaltis1.Visible = false;
                    this.lblPenaltis2.Visible = false;


                    break;
            }

        }       
        #endregion

        #region Events
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);


            //this.penaltisCell.Visible = false;

            ChangeMode(JogoMode);

        }
        protected void chkPenaltis_CheckedChanged(object sender, EventArgs e)
        {
            cellPenaltis.Visible = chkPenaltis.Checked;
        }
        #endregion
    }
}