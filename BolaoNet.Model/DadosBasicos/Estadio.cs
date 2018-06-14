using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BolaoNet.Model.DadosBasicos
{
    [Serializable]
    public class Estadio : Framework.DataServices.Model.EntityBaseData
    {
        #region Variables
        private string _nome = string.Empty;
        private string _descricao = string.Empty;
        private string _pais = string.Empty;
        private string _estado = string.Empty;
        private string _cidade = string.Empty;
        private Image _foto = null;
        private long _capacidade;
        private Model.DadosBasicos.Time _time = null;
        #endregion

        #region Properties
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        public string Pais
        {
            get { return _pais; }
            set { _pais= value; }
        }
        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
        public string Cidade
        {
            get { return _cidade; }
            set { _cidade = value; }
        }
        public Image Foto
        {
            get { return _foto; }
            set { _foto = value; }
        }
        public long Capacidade
        {
            get { return _capacidade; }
            set { _capacidade = value; }
        }
        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }
        public Model.DadosBasicos.Time Time
        {
            get { return _time; }
            set { _time = value; }
        }
        #endregion

        #region Constructors/Destructors
        public Estadio()
        {
        }
        public Estadio(string nome)
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


        public void Copy(Model.DadosBasicos.Estadio entry)
        {
            _capacidade =  entry._capacidade;
            _cidade = entry._cidade;
            _descricao = entry._descricao;
            _estado = entry._estado;
            _foto = entry._foto;
            _nome = entry._nome;
            _pais = entry._pais;
            _time = entry._time;
                
        }
        #endregion
    }
}
