using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BolaoNet.Model.DadosBasicos
{
    [Serializable]
    public class Time : Framework.DataServices.Model.EntityBaseData 
    {
        #region Variables
        private string _nome;
        private bool _isClube;
        private Image _escudo;
        private DateTime _fundacao;
        private string _site;
        private string _pais;
        private string _estado;
        private string _cidade;
        private string _descricao;
        private string _nomeMascote;
        private Image _mascote;

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
        public Image Escudo
        {
            get { return _escudo ; }
            set { _escudo = value; }
        }
        public DateTime Fundacao
        {
            get { return _fundacao; }
            set { _fundacao = value; }
        }
        public string Site
        {
            get { return _site; }
            set { _site = value; }
        }
        public string Pais
        {
            get { return _pais; }
            set { _pais = value; }
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
        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }
        public string NomeMascote
        {
            get { return _nomeMascote; }
            set { _nomeMascote = value; }
        }
        public Image Mascote
        {
            get { return _mascote; }
            set { _mascote = value; }
        }
        #endregion

        #region Constructors/Destructors
        public Time()
        {
        }
        public Time(string nome)
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
        public void Copy(Model.DadosBasicos.Time entry)
        {
            _cidade = entry._cidade;
            _descricao = entry._descricao;
            _escudo = entry._escudo;
            _estado = entry._estado;
            _fundacao = entry._fundacao;
            _isClube = entry._isClube;
            _mascote = entry._mascote;
            _nome = entry._nome;
            _nomeMascote = entry._nomeMascote;
            _pais = entry._pais;
            _site = entry._site;
        }
        #endregion
    }
}
