using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Consistency
{
    public class VerifyJogos
    {
        #region Variables
        private Model.Campeonatos.Jogo _jogo;
        private IList<Model.Boloes.JogoUsuario> _list= new List<Model.Boloes.JogoUsuario>();
        #endregion

        #region Properties
        public Model.Campeonatos.Jogo Jogo
        {
            get { return _jogo; }
            set { _jogo = value; }
        }
        public IList<Model.Boloes.JogoUsuario> List
        {
            get { return _list; }
            set { _list = value; }
        }
        #endregion

        #region Constructors/Destructors
        public VerifyJogos(Model.Campeonatos.Jogo jogo)
        {
            _jogo = jogo;
        }
        #endregion
    }
}
