using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Consistency
{
    public class VerifyJogoUsuario
    {
        #region Variables
        private Model.Campeonatos.Jogo _jogo;
        private Model.Boloes.JogoUsuario _jogoUsuario;
        #endregion

        #region Properties
        public Model.Campeonatos.Jogo Jogo
        {
            get { return _jogo; }
        }
        public Model.Boloes.JogoUsuario JogoUsuario
        {
            get { return _jogoUsuario; }
        }
        #endregion

        #region Constructors/Destructors
        public VerifyJogoUsuario(Model.Campeonatos.Jogo jogo, Model.Boloes.JogoUsuario jogoUsuario)
        {
            _jogo = jogo;
            _jogoUsuario = jogoUsuario;
        }
        #endregion
    }
}
