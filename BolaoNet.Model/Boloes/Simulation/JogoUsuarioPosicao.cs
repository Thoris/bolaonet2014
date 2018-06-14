using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Model.Boloes.Simulation
{
    [Serializable]
    public class JogoUsuarioPosicao : JogoUsuario
    {
        #region Variables
        private int _posicao = 0;
        private int _pontos = 0;
        private int _lastPosicao = 0;
        private int _lastPontos = 0;
        private int _lastApostaPontos = 0;
        #endregion

        #region Properties
        public int Posicao
        {
            get { return _posicao; }
            set { _posicao = value; }
        }
        public int TotalPontos
        {
            get { return _pontos; }
            set { _pontos = value; }
        }
        public int LastPosicao
        {
            get { return _lastPosicao; }
            set { _lastPosicao = value; }
        }
        public int LastPontos
        {
            get { return _lastPontos; }
            set { _lastPontos = value; }
        }
        public int LastApostaPontos
        {
            get { return _lastApostaPontos; }
            set { _lastApostaPontos = value; }
        }
        #endregion

        #region Constructors/Destructors
        public JogoUsuarioPosicao()
            : base ()
        {
        }
        #endregion
    }
}
