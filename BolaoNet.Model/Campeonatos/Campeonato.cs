using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Model.Campeonatos
{
    [Serializable]
    public class Campeonato : Framework.DataServices.Model.EntityBaseData
    {
        #region Variables
        private string _nome = string.Empty;

        private bool _isClube = false;
        private string _descricao = string.Empty;
        private string _faseAtual = string.Empty;
        private string _grupoAtual = string.Empty;
        private int _rodadaAtual = 0;
        private bool _isIniciado = false;
        private DateTime _dataIniciado = DateTime.MinValue;

        protected EntryCollection _timesCollection = null;
        protected EntryCollection _gruposCollection = null;
        protected EntryCollection _fasesCollection = null;

        #endregion

        #region Properties
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        public bool IsClube
        {
            get { return _isClube; }
            set { _isClube = value; }
        }
        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }
        public string FaseAtual
        {
            get { return _faseAtual; }
            set { _faseAtual  = value; }
        }
        public int RodadaAtual
        {
            get { return _rodadaAtual; }
            set { _rodadaAtual  = value; }
        }
        public bool IsIniciado
        {
            get { return _isIniciado; }
            set { _isIniciado = value; }
        }
        public DateTime DataIniciado
        {
            get { return _dataIniciado; }
            set { _dataIniciado = value; }
        }
        public EntryCollection Times
        {
            get { return _timesCollection; }            
        }
        public EntryCollection Grupos
        {
            get { return _gruposCollection; }
        }
        public EntryCollection Fases
        {
            get { return _fasesCollection; }
        }
        #endregion

        #region Constructors/Destructors
        public Campeonato()
        {
        }
        public Campeonato(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentNullException("nome");

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

        public void Copy(Model.Campeonatos.Campeonato entry)
        {
            _dataIniciado = entry._dataIniciado;
            _descricao = entry._descricao;
            _faseAtual = entry._faseAtual;
            _grupoAtual = entry._grupoAtual;
            _gruposCollection = entry._gruposCollection;
            _isClube = entry._isClube;
            _isIniciado = entry._isIniciado;
            _nome = entry._nome;
            _rodadaAtual = entry._rodadaAtual;
            _timesCollection = entry._timesCollection;
        }
        #endregion
    }
}
