using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Model.Boloes
{
    [Serializable]
    public class ApostaExtraUsuario : ApostaExtra
    {
        #region Variables
        private string _userName;
        private DateTime _dataAposta;
        private int _pontos;
        private string _nomeTime;
        private bool _isValido;        

        #endregion

        #region Properties
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        public DateTime DataAposta
        {
            get { return _dataAposta; }
            set { _dataAposta = value; }
        }
        public int Pontos
        {
            get { return _pontos; }
            set { _pontos = value; }
        }
        public string NomeTime
        {
            get { return _nomeTime; }
            set { _nomeTime = value; }
        }
        public bool IsApostaValida
        {
            get { return _isValido; }
            set { _isValido = value; }
        }
        #endregion

        #region Constructors/Destructors
        public ApostaExtraUsuario()
        {
        }
        public ApostaExtraUsuario(int posicao, string nomeBolao, string userName)
        {
            base.Posicao = posicao;
            base.Bolao = new Bolao(nomeBolao);
            _userName = userName;
        }
        #endregion

        #region Methods
        public void Copy(ApostaExtraUsuario entry)
        {
            base.Copy(entry);
            _dataAposta = entry._dataAposta;
            _isValido = entry._isValido;
            _nomeTime = entry._nomeTime;
            _pontos = entry._pontos;
            _userName = entry._userName;
        }
        #endregion
    }
}
