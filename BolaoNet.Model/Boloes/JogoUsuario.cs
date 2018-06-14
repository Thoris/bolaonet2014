using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Model.Boloes
{
    [Serializable]
    public class JogoUsuario : Model.Campeonatos.Jogo
    {
        #region Enumeration
        public enum TypeAposta
        {
            Todos = 0,
            Nao_Apostados = 1,
            Apostados = 2,
        }

        public enum TypeAutomatico
        {
            Todos = 0,
            Automatico = 1,
            Manual = 2,
        }
        #endregion

        #region Variables
        private DateTime _dataAposta;
        private bool _automatico;
        private int _apostaTime1;
        private int _apostaTime2;
        private ApostaPontos _apostaPontos = new ApostaPontos();
        private bool _valido;
        private string _userName;
        private Bolao _bolao = new Bolao ();
        private DadosBasicos.Time _timeResult1 = new Model.DadosBasicos.Time();
        private DadosBasicos.Time _timeResult2 = new Model.DadosBasicos.Time();
        private int _ganhador;
        #endregion

        #region Properties
        public DateTime DataAposta
        {
            get { return _dataAposta; }
            set { _dataAposta = value; }
        }
        public bool Automatico
        {
            get { return _automatico; }
            set { _automatico = value; }
        }
        public int ApostaTime1
        {
            get { return _apostaTime1; }
            set { _apostaTime1 = value; }
        }
        public int ApostaTime2
        {
            get { return _apostaTime2; }
            set { _apostaTime2 = value; }
        }
        public ApostaPontos ApostaPontos
        {
            get { return _apostaPontos; }
            set { _apostaPontos = value; }
        }
        public bool Valido
        {
            get { return _valido; }
            set { _valido = value; }
        }
        public string UserName
        {
            get { return _userName; }
            set { _userName= value; }
        }
        public Bolao Bolao
        {
            get { return _bolao; }
            set { _bolao = value; }
        }
        public DadosBasicos.Time NomeTimeResult1
        {
            get { return _timeResult1; }
            set { _timeResult1 = value; }
        }
        public DadosBasicos.Time NomeTimeResult2
        {
            get { return _timeResult2; }
            set { _timeResult2 = value; }
        }

        public new DadosBasicos.Time Time1
        {
            get 
            {
                if (_timeResult1 == null || string.IsNullOrEmpty(_timeResult1.Nome))
                    return base.Time1;
                else
                    return _timeResult1;
            }
            set { base.Time1 = value; }
        }
        public new DadosBasicos.Time Time2
        {
            get
            {
                if (_timeResult2 == null || string.IsNullOrEmpty(_timeResult2.Nome))
                    return base.Time2;
                else
                    return _timeResult2;
            }
            set { base.Time2 = value; }
        }

        public DadosBasicos.Time Time1Classificado
        {
            get { return base.Time1; }
        }
        public DadosBasicos.Time Time2Classificado
        {
            get { return base.Time2; }
        }

        public int Pontos
        {
            get { return _apostaPontos.Pontos; }
        }
        public bool IsEmpate
        {
            get { return _apostaPontos.IsEmpate; }
        }
        public bool IsDerrota
        {
            get { return _apostaPontos.IsDerrota; }
        }
        public bool IsVitoria
        {
            get { return _apostaPontos.IsVitoria; }
        }
        public bool IsGolsGanhador
        {
            get { return _apostaPontos.IsGolsGanhador; }
        }
        public bool IsGolsPerdedor
        {
            get { return _apostaPontos.IsGolsPerdedor; }
        }
        public bool IsResultTime1
        {
            get { return _apostaPontos.IsResultTime1; }
        }
        public bool IsResultTime2
        {
            get { return _apostaPontos.IsResultTime2; }
        }
        public bool IsVDE
        {
            get { return _apostaPontos.IsVDE; }
        }
        public bool IsErro
        {
            get { return _apostaPontos.IsErro; }
        }
        public bool IsGolsGanhadorFora
        {
            get { return _apostaPontos.IsGolsGanhadorFora; }
        }
        public bool IsGolsGanhadorDentro
        {
            get { return _apostaPontos.IsGolsGanhadorDentro; }
        }
        public bool IsGolsPerdedorFora
        {
            get { return _apostaPontos.IsGolsPerdedorFora; }
        }
        public bool IsGolsPerdedorDentro
        {
            get { return _apostaPontos.IsGolsPerdedorDentro; }
        }
        public bool IsGolsEmpate
        {
            get { return _apostaPontos.IsGolsEmpate; }
        }
        public bool IsGolsTime1
        {
            get { return _apostaPontos.IsGolsTime1; }
        }
        public bool IsGolsTime2
        {
            get { return _apostaPontos.IsGolsTime2; }
        }
        public bool IsPlacarCheio
        {
            get { return _apostaPontos.IsPlacarCheio; }
        }
        public bool IsMultiploTime
        {
            get { return _apostaPontos.IsMultiploTime; }
        }
        public int MultiploTime
        {
            get { return _apostaPontos.MultiploTime; }
        }
        public int Ganhador
        {
            get { return _ganhador; }
            set { _ganhador = value; }
        }
        public DateTime DataFacebook
        {
            get;
            set;
        }

        #endregion

        #region Constructors/Destructors
        public JogoUsuario()
        {
        }
        public JogoUsuario(long idJogo)
            : base (idJogo)
        {
        }
        public JogoUsuario(long idJogo, string nomeCampeonato, string nomeBolao, string userName )
            : base(idJogo)
        {
            base.Campeonato = new BolaoNet.Model.Campeonatos.Campeonato(nomeCampeonato);
            _bolao = new Bolao(nomeBolao);
            _userName = userName;
        }
        #endregion

        #region Methods
        public void CopyAposta(Model.Boloes.JogoUsuario jogoUsuario)
        {
            base.Copy(jogoUsuario);
            this._apostaPontos = jogoUsuario._apostaPontos;
            this._apostaTime1 = jogoUsuario._apostaTime1;
            this._apostaTime2 = jogoUsuario._apostaTime2;
            this._automatico = jogoUsuario._automatico;
            this._bolao = jogoUsuario._bolao;
            this._dataAposta = jogoUsuario._dataAposta;
            this._userName = jogoUsuario._userName;
            this._valido = jogoUsuario._valido;
            this._timeResult1 = jogoUsuario._timeResult1;
            this._timeResult2 = jogoUsuario._timeResult2;
            this._ganhador = jogoUsuario._ganhador;

        }
        #endregion
    }
}
