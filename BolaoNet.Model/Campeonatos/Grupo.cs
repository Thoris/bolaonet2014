using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Model.Campeonatos
{
    [Serializable]
    public class Grupo : Framework.DataServices.Model.EntityBaseData
    {
        #region Variables
        private string _nome = string.Empty;
        private string _descricao = string.Empty;
        private Model.Campeonatos.Campeonato _campeonato = null;

        protected EntryCollection _timesCollection = null;
        #endregion

        #region Properties
        public Model.Campeonatos.Campeonato Campeonato
        {
            get { return _campeonato; }
            set { _campeonato = value; }
        }
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }
        public EntryCollection Times
        {
            get { return _timesCollection; }
        }
        #endregion

        #region Constructors/Destructors
        public Grupo()
        {
        }
        public Grupo(string nome)
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

        public void Copy(Model.Campeonatos.Grupo entry)
        {
            _nome = entry._nome;
            _descricao = entry._descricao;
            _campeonato = entry._campeonato;
            _timesCollection = entry._timesCollection;
        }

        #endregion
    }
}
