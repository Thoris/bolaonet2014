using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Model.Boloes.Reports
{
    [Serializable]
    public class UserClassificacao : Framework.DataServices.Model.EntityBaseData
    {
        #region Variables
        private int _posicao;
        private int _pontos ;
        private int _rodada ;
        private string _userName;
        #endregion

        #region Properties
        public int Posicao
        {
            get { return _posicao; }
            set { _posicao = value; }
        }
        public int Pontos
        {
            get { return _pontos; }
            set { _pontos = value; }
        }
        public int Rodada
        {
            get { return _rodada; }
            set { _rodada = value; }
        }
        public string UserName        
        {
            get { return _userName; }
            set { _userName = value; }
        }
        #endregion

        #region Constructors/Destructors
        public UserClassificacao()
        {
        }
        #endregion

        #region Methods
        public void Copy(UserClassificacao entry)
        {
            _userName = entry._userName;
            _rodada = entry._rodada;
            _posicao = entry._posicao;
            _pontos = entry._pontos;
        }
        #endregion
    }
}
