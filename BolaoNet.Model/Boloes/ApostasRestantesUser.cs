using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Model.Boloes
{
    [Serializable]
    public class ApostasRestantesUser : Framework.Security.Model.UserData
    {
        #region Variables
        private int _apostasRestantes;
        private decimal _pagamentoRestante;
        #endregion

        #region Properties
        public int ApostasRestantes
        {
            get { return _apostasRestantes; }
            set { _apostasRestantes = value; }
        }
        public decimal PagamentoRestante
        {
            get { return _pagamentoRestante; }
            set { _pagamentoRestante = value; }
        }
        public bool IsPago
        {
            get
            {
                if (_pagamentoRestante > 0)
                    return false;
                else
                    return true;
            }
        }
        #endregion

        #region Constructors/Destructors
        public ApostasRestantesUser()
            : base ()
        {
        }
        public ApostasRestantesUser(string userName)
            : base (userName)
        {
        }
        #endregion
    }
}
