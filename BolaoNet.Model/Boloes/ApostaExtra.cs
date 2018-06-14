using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Model.Boloes
{
    [Serializable]
    public class ApostaExtra : Framework.DataServices.Model.EntityBaseData
    {
        #region Variables
        private int _posicao;
        private Bolao _bolao = new Bolao();
        private string _titulo;
        private string _descricao;
        private int _totalPontos;
        private bool _isValido;
        private DateTime _dataValidacao;
        private string _validadoBy;
        private string _nomeTimeValidado;

        #endregion

        #region Properties
        public int Posicao
        {
            get { return _posicao; }
            set { _posicao = value; }
        }
        public Bolao Bolao
        {
            get { return _bolao; }
            set { _bolao = value; }
        }
        public string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }
        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }
        public int TotalPontos
        {
            get { return _totalPontos; }
            set { _totalPontos = value; }
        }
        public bool IsValido
        {
            get { return _isValido; }
            set { _isValido = value; }
        }
        public DateTime DataValidacao
        {
            get { return _dataValidacao; }
            set { _dataValidacao = value; }
        }
        public string ValidadoBy
        {
            get { return _validadoBy; }
            set { _validadoBy = value; }
        }
        public string NomeTimeValidado
        {
            get { return _nomeTimeValidado; }
            set { _nomeTimeValidado = value; }
        }
        #endregion

        #region Constructors/Destructors
        public ApostaExtra()
        {

        }
        public ApostaExtra(int posicao, string bolao)
        {
            _posicao = posicao;
            _bolao = new Bolao(bolao);
        }
        #endregion

        #region Methods
        public void Copy(ApostaExtra entry)
        {
            _bolao = entry._bolao;
            _dataValidacao = entry._dataValidacao;
            _descricao = entry._descricao;
            _isValido = entry._isValido;
            _nomeTimeValidado = entry._nomeTimeValidado;
            _posicao = entry._posicao;
            _titulo = entry._titulo;
            _totalPontos = entry._totalPontos;
            _validadoBy = entry._validadoBy;

            base.Copy(entry);
        }
        #endregion
    }
}
