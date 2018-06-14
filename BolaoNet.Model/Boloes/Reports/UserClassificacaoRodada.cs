using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Model.Boloes.Reports
{
    [Serializable]
    public class UserClassificacaoRodada
    {
        #region Variables
        private int _rodada;
        private IList<Model.Boloes.Reports.UserClassificacao> _membros = 
            new List<Model.Boloes.Reports.UserClassificacao>();
        #endregion

        #region Properties
        public int Rodada
        {
            get { return _rodada; }
            set { _rodada = value; }
        }
        public IList<Model.Boloes.Reports.UserClassificacao> Membros
        {
            get { return _membros; }
            set { _membros = value; }
        }
        #endregion

        #region Constructors/Destructors
        public UserClassificacaoRodada(int rodada)
        {
            _rodada = rodada;
        }
        #endregion
    }
}
