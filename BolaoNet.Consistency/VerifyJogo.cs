using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Consistency
{
    public class VerifyJogo
    {
        #region Variables
        private Model.Campeonatos.Jogo _jogo;
        #endregion

        #region Properties
        public Model.Campeonatos.Jogo Jogo
        {
            get { return _jogo; }
        }
        #endregion

        #region Constructors/Destructors
        public VerifyJogo(Model.Campeonatos.Jogo jogo)
        {
            _jogo = jogo;
        }
        #endregion
    }
}
