using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BolaoNet.Consistency
{
    public partial class frmMain : Form
    {
        #region Enumerations
        private enum Log
        {
            Info,
            Warning,
            Error,
        }
        #endregion

        #region Variables
        private IList<VerifyJogoUsuario> _jogoUsuario = new List<VerifyJogoUsuario>();
        #endregion

        #region Constructors/Destructors
        public frmMain()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods

        private void SaveLog(Log log, int id, string userName, string message)
        {

        }
        private int SearchUser(string userName, IList<Model.Boloes.Reports.UserPontosData> list)
        {
            for (int c = 0; c < list.Count; c++)
            {
                if (string.Compare(list[c].UserName, userName, true) == 0)
                    return c;
            }
            return -1;
        }
        private Log CheckJogo(Model.Campeonatos.Jogo jogo, Model.Boloes.JogoUsuario jogoUsuario, out int atual, out int expected)
        {
            atual = 0;
            expected = 0;
            int value = 1;

            if (!jogo.PartidaValida)
                return Log.Warning;


            if (string.Compare(jogo.Time1.Nome, "Brasil", true) == 0 || string.Compare(jogo.Time2.Nome, "Brasil", true) == 0)
                value = 2;


            int pontos = 0;

            //Aposta em cheio
            if (jogo.GolsTime1 == jogoUsuario.ApostaTime1 && jogo.GolsTime2 == jogoUsuario.ApostaTime2)
            {
                pontos = 10;
            }
            //Empate
            else if (jogo.GolsTime1 == jogo.GolsTime2 && jogoUsuario.ApostaTime1 == jogoUsuario.ApostaTime2)
            {
                pontos = 5;
            }
            //Time 1 Ganhador
            else if (jogo.GolsTime1 > jogo.GolsTime2 && jogoUsuario.ApostaTime1 > jogoUsuario.ApostaTime2)
            {
                pontos = 3;

                if (jogo.GolsTime1 == jogoUsuario.ApostaTime1)
                    pontos++;
                if (jogo.GolsTime2 == jogoUsuario.ApostaTime2)
                    pontos++;
            }
            //Time 2 Ganhador
            else if (jogo.GolsTime1 < jogo.GolsTime2 && jogoUsuario.ApostaTime1 < jogoUsuario.ApostaTime2)
            {
                pontos = 3;

                if (jogo.GolsTime1 == jogoUsuario.ApostaTime1)
                    pontos++;
                if (jogo.GolsTime2 == jogoUsuario.ApostaTime2)
                    pontos++;
            }
            else
            {
                if (jogo.GolsTime1 == jogoUsuario.ApostaTime1)
                    pontos++;
                if (jogo.GolsTime2 == jogoUsuario.ApostaTime2)
                    pontos++;
            }


            pontos *= value;


            expected = pontos;
            atual = jogoUsuario.Pontos;

            if (jogoUsuario.Pontos != pontos)
                return Log.Error;


            return Log.Info;
        }

        #endregion

        #region Events

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.livLog.Items.Clear();
            this.livClassificacao.Items.Clear();
            this.livJogos.Items.Clear();
            this.livJogosUsuarios.Items.Clear();

            IList<ClassificacaoUsuario> compareList = new List<ClassificacaoUsuario>();


            BolaoNet.Business.Boloes.Support.Bolao bolao = new Business.Boloes.Support.Bolao("");
            bolao.Nome = this.cboBoloes.Text;

            bolao.Load();

            Business.Campeonatos.Support.Campeonato campeonato = new Business.Campeonatos.Support.Campeonato("", bolao.Campeonato);
            Business.Boloes.Support.JogoUsuario jogosUsuario = new Business.Boloes.Support.JogoUsuario("");
            jogosUsuario.Bolao = bolao;
            

            IList<Framework.DataServices.Model.EntityBaseData> jogos =
                campeonato.LoadJogos(0, null, null, DateTime.MinValue, DateTime.MinValue, null);


            IList<Model.Boloes.Reports.UserPontosData> pontuacao = new List<Model.Boloes.Reports.UserPontosData>();


            _jogoUsuario.Clear();

            this.pgbPartial.Value = 0;
            this.pgbPartial.Maximum = jogos.Count;



            foreach (Model.Campeonatos.Jogo jogo in jogos)
            {


                ListViewItem jogoItem = new ListViewItem(jogo.IDJogo.ToString());

                jogoItem.SubItems.Add(jogo.DataJogo.ToString ("dd/MM"));             
                jogoItem.SubItems.Add(jogo.Time1.Nome);
                jogoItem.SubItems.Add(jogo.GolsTime1.ToString());
                jogoItem.SubItems.Add(jogo.GolsTime1.ToString());
                jogoItem.SubItems.Add(jogo.Time2.Nome);
                jogoItem.SubItems.Add(jogo.PartidaValida.ToString());
                jogoItem.Tag = jogo;
                this.livJogos.Items.Add(jogoItem);


                IList<Framework.DataServices.Model.EntityBaseData> jogosUsu =
                    jogosUsuario.LoadApostasByJogo(bolao, jogo, "");

                Log logJogo = Log.Info;

                foreach (Model.Boloes.JogoUsuario jogoUsuario in jogosUsu)
                {
                    int atual = 0;
                    int expected = 0;
                    Log logTemp = CheckJogo(jogo, jogoUsuario, out atual, out expected);

                    switch (logTemp)
                    {
                        case Log.Error:

                            logJogo = Log.Error;

                            ListViewItem log = new ListViewItem(jogo.IDJogo.ToString ());
                            log.SubItems.Add(jogo.Time1.Nome + " x " + jogo.Time2.Nome);
                            log.SubItems.Add(jogoUsuario.UserName);
                            log.SubItems.Add(atual.ToString());
                            log.SubItems.Add(expected.ToString());
                            this.livLog.Items.Add(log);

                            break;
                        case Log.Warning:

                            if (logJogo == Log.Info)
                                logJogo = Log.Warning;

                            break;

                    }




                    int posCompare = -1;
                    for (int c = 0; c < compareList.Count; c++)
                    {
                        if (string.Compare(compareList[c].Usuario, jogoUsuario.UserName, true) == 0)
                        {
                            posCompare = c;
                            break;
                        }
                    }

                    if (posCompare == -1)
                    {
                        compareList.Add(new ClassificacaoUsuario());
                        compareList[compareList.Count - 1].Usuario = jogoUsuario.UserName;
                        posCompare = compareList.Count - 1;
                    }

                    compareList[posCompare].Pontos += jogoUsuario.Pontos;
                }

                switch (logJogo)
                {
                    case Log.Error:
                        this.livJogos.Items[this.livJogos.Items.Count - 1].BackColor = Color.Red;
                        break;

                    case Log.Warning:
                        this.livJogos.Items[this.livJogos.Items.Count - 1].BackColor = Color.Yellow;
                        break;

                    case Log.Info:
                        this.livJogos.Items[this.livJogos.Items.Count - 1].BackColor = Color.LightGreen;
                        break;

                }







                this.pgbPartial.Value++;
                this.pgbPartial.Show();
            }



            IList<Model.Boloes.BolaoMembros> classificacao = bolao.LoadClassificacao(0);
            IList<Framework.DataServices.Model.EntityBaseData> listPosicoes = bolao.SelectPremios();

            foreach (Model.Boloes.BolaoMembros pont in classificacao)
            {
                ListViewItem pontos = new ListViewItem(pont.Posicao.ToString());
                pontos.SubItems.Add(pont.UserName);
                pontos.SubItems.Add(pont.TotalPontos.ToString ());
                
                foreach (Model.Boloes.BolaoPremio premio in listPosicoes)
                {
                    if (premio.Posicao == pont.Posicao)
                    {
                        pontos.BackColor = premio.BackColor;
                        pontos.ForeColor = premio.ForeColor;
                    }
                }

                int total = 0;
                for (int c = 0; c < compareList.Count; c++)
                {
                    if (string.Compare(compareList[c].Usuario, pont.UserName, true) == 0)
                    {
                         total = pont.TotalPontos - compareList[c].Pontos;
                        break;
                    }
                }

                pontos.SubItems.Add(total.ToString());

                this.livClassificacao.Items.Add(pontos);


            }

            
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            Business.Boloes.Support.Bolao bolao = new Business.Boloes.Support.Bolao("");
            IList<Framework.DataServices.Model.EntityBaseData> list = bolao.SelectAll(null);

            foreach (Model.Boloes.Bolao entry in list)
            {
                this.cboBoloes.Items.Add(entry.Nome);

            }

            this.cboBoloes.SelectedIndex = 0;
        }
        private void livJogos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblJogo.Text = "";
            if (this.livJogos.SelectedIndices.Count == 0)
                return;

            Business.Boloes.Support.JogoUsuario jogoUsuario = new Business.Boloes.Support.JogoUsuario("");
            jogoUsuario.Bolao = new Model.Boloes.Bolao(this.cboBoloes.Text);

            int pos = this.livJogos.SelectedIndices[0];

            IList<Framework.DataServices.Model.EntityBaseData> list =
                jogoUsuario.SelectAll("jogos.idjogo='" + this.livJogos.Items[pos].Text + "'");


            this.lblJogo.Text = this.livJogos.Items[pos].SubItems[1].Text + " - " +
                this.livJogos.Items[pos].SubItems[2].Text + " " +
                this.livJogos.Items[pos].SubItems[3].Text + " " +
                " x " +
                this.livJogos.Items[pos].SubItems[4].Text + " " +
                this.livJogos.Items[pos].SubItems[5].Text;

            this.livJogosUsuarios.Items.Clear();


            Model.Campeonatos.Jogo jogoMain = (Model.Campeonatos.Jogo)this.livJogos.Items[pos].Tag;


            foreach (Model.Boloes.JogoUsuario jogo in list)
            {
                ListViewItem jogoItem = new ListViewItem(jogo.IDJogo.ToString());
                jogoItem.SubItems.Add(jogo.UserName);
                jogoItem.SubItems.Add(jogo.Time1.Nome);
                jogoItem.SubItems.Add(jogo.ApostaTime1.ToString());
                jogoItem.SubItems.Add(jogo.ApostaTime2.ToString());
                jogoItem.SubItems.Add(jogo.Time2.Nome);
                jogoItem.SubItems.Add(jogo.Pontos.ToString());
                this.livJogosUsuarios.Items.Add(jogoItem);

                int atual = 0;
                int expected = 0;
                    
                Log logTemp = CheckJogo(jogoMain, jogo, out atual, out expected);


                switch (logTemp)
                {
                    case Log.Error:
                        jogoItem.BackColor = Color.Red;
                        break;

                    case Log.Warning:
                        jogoItem.BackColor = Color.Yellow;
                        break;

                    case Log.Info:
                        jogoItem.BackColor = Color.LightGreen;
                        break;
                }
            }
        }

        #endregion
    }
}
