using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Model.Campeonatos
{
    [Serializable]
    public class Jogo : Framework.DataServices.Model.EntityBaseData
    {
        #region Variables
        private long _idJogo;
        
        private Model.DadosBasicos.Time _time1 = new Model.DadosBasicos.Time ();
        private string _descricaoTime1;
        private int _golsTime1;
        private int _penaltisTime1;


        private Model.DadosBasicos.Time _time2 = new Model.DadosBasicos.Time ();
        private string _descricaoTime2;
        private int _golsTime2;
        private int _penaltisTime2;

        private Model.DadosBasicos.Estadio _estadio = new Model.DadosBasicos.Estadio ();

        private DateTime _dataJogo;

        private int _rodada;

        private bool _partidaValida;
        private DateTime _dataValidacao;
        private string _validadoBy;

        private Campeonatos.Fase _fase = new Fase ();
        private Campeonatos.Grupo _grupo = new Grupo ();

        private string _titulo;

        private Campeonato _campeonato = new Campeonato ();

        private string _jogoLabel;

        private int _pendenteIdTime1 = 0;
        private int _pendenteIdTime2 = 0;
        private bool _pendenteTime1Ganhador = false;
        private bool _pendenteTime2Ganhador = false;

        private string _pendenteTime1NomeGrupo;
        private string _pendenteTime2NomeGrupo;

        private int _pendenteTime1PosGrupo;
        private int _pendenteTime2PosGrupo;

        #endregion

        #region Properties
        public long IDJogo
        {
            get { return _idJogo; }
            set { _idJogo = value; }
        }

        public Campeonato Campeonato
        {
            get { return _campeonato; }
            set { _campeonato = value; }
        }

        public Model.DadosBasicos.Time Time1
        {
            get { return _time1; }
            set { _time1 = value; }
        }
        public string DescricaoTime1
        {
            get { return _descricaoTime1; }
            set { _descricaoTime1 = value; }
        }
        public int GolsTime1
        {
            get { return _golsTime1; }
            set { _golsTime1 = value; }
        }
        public int PenaltisTime1
        {
            get { return _penaltisTime1; }
            set { _penaltisTime1 = value; }
        }
        
        public Model.DadosBasicos.Time Time2
        {
            get { return _time2; }
            set { _time2 = value; }
        }
        public string DescricaoTime2
        {
            get { return _descricaoTime2; }
            set { _descricaoTime2 = value; }
        }
        public int GolsTime2
        {
            get { return _golsTime2; }
            set { _golsTime2 = value; }
        }
        public int PenaltisTime2
        {
            get { return _penaltisTime2; }
            set { _penaltisTime2 = value; }
        }

        public Model.DadosBasicos.Estadio Estadio
        {
            get { return _estadio; }
            set { _estadio = value; }
        }

        public DateTime DataJogo
        {
            get { return _dataJogo; }
            set { _dataJogo = value; }
        }
        public DateTime OnlyDataJogo
        {
            get { return new DateTime(_dataJogo.Year, _dataJogo.Month, _dataJogo.Day); }
        }
        public TimeSpan HoraJogo
        {
            get { return new TimeSpan(_dataJogo.Hour, _dataJogo.Minute, _dataJogo.Second); }
        }

        public int Rodada
        {
            get { return _rodada; }
            set { _rodada = value; }
        }
        public bool PartidaValida
        {
            get { return _partidaValida; }
            set { _partidaValida = value; }
        }
        public DateTime DataValidacao
        {
            get { return _dataValidacao; }
            set { _dataValidacao = value; }
        }

        public Campeonatos.Fase Fase
        {
            get { return _fase; }
            set { _fase = value; }
        }
        public Campeonatos.Grupo Grupo
        {
            get { return _grupo; }
            set { _grupo = value; }
        }
        public string ValidadoBy
        {
            get { return _validadoBy; }
            set { _validadoBy = value; }
        }
        public string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }

        public string JogoLabel
        {
            get { return _jogoLabel; }
            set { _jogoLabel = value; }
        }

        public int PendenteIdTime1
        {
            get { return _pendenteIdTime1; }
            set { _pendenteIdTime1 = value; }
        }
        public int PendenteIdTime2
        {
            get { return _pendenteIdTime2; }
            set { _pendenteIdTime2 = value; }
        }
        public bool PendenteTime1Ganhador
        {
            get { return _pendenteTime1Ganhador; }
            set { _pendenteTime1Ganhador = value; }
        }
        public bool PendenteTime2Ganhador
        {
            get { return _pendenteTime2Ganhador; }
            set { _pendenteTime2Ganhador = value; }
        }


        public string PendenteTime1NomeGrupo
        {
            get { return _pendenteTime1NomeGrupo; }
            set { _pendenteTime1NomeGrupo = value; }
        }
        public string PendenteTime2NomeGrupo
        {
            get { return _pendenteTime2NomeGrupo; }
            set { _pendenteTime2NomeGrupo = value; }
        }
        public int PendenteTime1PosGrupo
        {
            get { return _pendenteTime1PosGrupo; }
            set { _pendenteTime1PosGrupo = value; }
        }
        public int PendenteTime2PosGrupo
        {
            get { return _pendenteTime2PosGrupo; }
            set { _pendenteTime2PosGrupo = value; }
        }


        #endregion

        #region Constructors/Destructors
        public Jogo()
        {
        }
        public Jogo(long idJogo)
        {

            _idJogo = idJogo;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            if (_time1 != null && _time2 != null)
            {
                if (_partidaValida)
                {
                    return _time1.Nome + " " + _golsTime1 + " x " + _golsTime2 + " " + _time2.Nome;
                }
                else
                {
                    return _time1.Nome + " x " + _time2.Nome;                
                }
            }
            else
            {
                return base.ToString();
            }
        }

        public void Copy(Model.Campeonatos.Jogo entry)
        {
            _campeonato = entry._campeonato;
            _dataJogo = entry._dataJogo;
            _dataValidacao = entry._dataValidacao;
            _descricaoTime1 = entry._descricaoTime1;
            _descricaoTime2 = entry._descricaoTime2;
            _estadio = entry._estadio;
            _fase = entry._fase;
            _golsTime1 = entry._golsTime1;
            _golsTime2 = entry._golsTime2;
            _grupo = entry._grupo;
            _idJogo = entry._idJogo;
            _partidaValida = entry._partidaValida;
            _penaltisTime1 = entry._penaltisTime1;
            _penaltisTime2 = entry._penaltisTime2;
            _rodada = entry._rodada;
            _time1 = entry._time1;
            _time2 = entry._time2;
            _titulo = entry._titulo;
            _validadoBy = entry._validadoBy;
            _jogoLabel = entry._jogoLabel;

            _pendenteTime1Ganhador = entry._pendenteTime1Ganhador;
            _pendenteTime2Ganhador = entry._pendenteTime2Ganhador;
            _pendenteIdTime1 = entry._pendenteIdTime1;
            _pendenteIdTime2 = entry._pendenteIdTime2;

        }
        #endregion
    }
}
