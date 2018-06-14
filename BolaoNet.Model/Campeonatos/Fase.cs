using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Model.Campeonatos
{
    [Serializable]
    public class Fase : Framework.DataServices.Model.EntityBaseData
    {
        #region Variables
        private Model.Campeonatos.Campeonato _campeonato = null;
        private string _nome = string.Empty;
        private string _descricao = string.Empty;
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
        #endregion

        #region Constructors/Destructors
        public Fase()
        {
        }
        public Fase(string nome)
        {
            //if (string.IsNullOrEmpty(nome))
            //    throw new ArgumentNullException("nome");

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

        public void Copy(Model.Campeonatos.Fase entry)
        {
            _nome = entry._nome;
            _descricao = entry._descricao;
            _campeonato = entry._campeonato;
        }
        #endregion
    }
}
