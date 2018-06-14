using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BolaoNet.Model.Boloes
{
    [Serializable]
    public class Bolao : Framework.DataServices.Model.EntityBaseData
    {
        #region Variables
        private string _nome;
        private Campeonatos.Campeonato _campeonato;
        private string _descricao;
        private decimal _taxaParticipacao;
        private Image _foto;
        private bool _publico;
        private bool _forumAtivado;
        private bool _permitirMsgAnonimos;
        private DateTime _dataInicio;
        private string _pais;
        private string _estado;
        private string _cidade;
        private bool _apostasApenasAntes;
        private int _horasLimiteAposta;
        private bool _isIniciado;
        private string _iniciadoBy;
        private DateTime _dataIniciado;


        #endregion

        #region Properties
        public string Nome { get { return _nome; } set { _nome = value; } }
        public Campeonatos.Campeonato Campeonato { get { return _campeonato; } set { _campeonato = value; } }
        public string Descricao { get { return _descricao; } set { _descricao = value; } }
        public decimal TaxaParticipacao { get { return _taxaParticipacao; } set { _taxaParticipacao = value; } }
        public Image Foto { get { return _foto; } set { _foto = value; } }
        public bool Publico { get { return _publico; } set { _publico = value; } }
        public bool ForumAtivado { get { return _forumAtivado; } set { _forumAtivado = value; } }
        public bool PermitirMsgAnonimos { get { return _permitirMsgAnonimos; } set { _permitirMsgAnonimos = value; } }
        public DateTime DataInicio { get { return _dataInicio; } set { _dataInicio = value; } }
        public string Pais { get { return _pais; } set { _pais = value; } }
        public string Estado { get { return _estado; } set { _estado = value; } }
        public string Cidade { get { return _cidade; } set { _cidade = value; } }
        public bool ApostasApenasAntes { get { return _apostasApenasAntes; } set { _apostasApenasAntes = value; } }
        public int HorasLimiteAposta { get { return _horasLimiteAposta; } set { _horasLimiteAposta = value; } }
        public bool IsIniciado { get { return _isIniciado; } set { _isIniciado = value; } }
        public string IniciadoBy { get { return _iniciadoBy; } set { _iniciadoBy = value; } }
        public DateTime DataIniciado { get { return _dataIniciado; } set { _dataIniciado = value; } }
        #endregion

        #region Constructors/Destructors
        public Bolao()
        {
        }
        public Bolao(string nome)
        {
            _nome = nome;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            if (string.IsNullOrEmpty(_nome))
                return "";
            else
                return _nome;


        }

        public void Copy(Model.Boloes.Bolao entry)
        {
            _apostasApenasAntes = entry._apostasApenasAntes;
            _campeonato = entry._campeonato;
            _cidade = entry._cidade;
            _dataIniciado  = entry._dataIniciado;
            _dataInicio = entry._dataInicio;
            _descricao = entry._descricao;
            _estado = entry._estado;
            _forumAtivado = entry._forumAtivado;
            _foto = entry._foto;
            _horasLimiteAposta = entry._horasLimiteAposta;
            _iniciadoBy = entry._iniciadoBy;
            _isIniciado  = entry._isIniciado;
            _nome = entry._nome;
            _pais = entry._pais;
            _permitirMsgAnonimos = entry._permitirMsgAnonimos;
            _publico = entry._publico;
            _taxaParticipacao = entry._taxaParticipacao;

            base.Copy(entry);

        }
        #endregion
    }
}
