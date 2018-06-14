using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Consistency
{
    public class ClassificacaoUsuario
    {
        #region Variables
        private int _pontos;
        private string _usuario;
        #endregion

        #region Properties
        public int Pontos
        {
            get { return _pontos; }
            set { _pontos = value; }
        }
        public string Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }
        #endregion

        #region Constructors/Destructors
        public ClassificacaoUsuario()
        {
        }
        #endregion
    }
}
