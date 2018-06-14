using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Model.Boloes.Simulation
{
    [Serializable]
    public class ApostasExtrasBolaoMembros : BolaoMembros 
    {
        #region Variables
        private int _lastPontos = 0;
        private int _lastPosicao = 0;
        private IList<Model.Boloes.ApostaExtraUsuario> _listApostasExtras = new List<Model.Boloes.ApostaExtraUsuario>();
        #endregion

        #region Properties
        public int Difference
        {
            get { return this.TotalPontosCalculado - _lastPontos; }
        }
        public int TotalPontosCalculado
        {
            get
            {
                int totalPontos = 0;

                for (int c = 0; c < _listApostasExtras.Count; c++)
                {
                    totalPontos += _listApostasExtras[c].Pontos;
                }

                return totalPontos + _lastPontos;
            }
        }
        public int LastPontos
        {
            get { return _lastPontos; }
            set { _lastPontos = value; }
        }
        public new int LastPosicao
        {
            get { return _lastPosicao; }
            set { _lastPosicao = value; }
        }
        public IList<Model.Boloes.ApostaExtraUsuario> ListApostasExtras
        {
            get { return _listApostasExtras; }
            set { _listApostasExtras = value; }
        }

        public string Campeao
        {
            get 
            {
                if (_listApostasExtras.Count > 0)
                    return _listApostasExtras[0].NomeTime;
                else
                    return null;

            }
        }
        public string ViceCampeao
        {
            get
            {
                if (_listApostasExtras.Count > 1)
                    return _listApostasExtras[1].NomeTime;
                else
                    return null;

            }
        }
        public string Terceiro
        {
            get
            {
                if (_listApostasExtras.Count > 2)
                    return _listApostasExtras[2].NomeTime;
                else
                    return null;

            }
        }
        public string QuartoLugar
        {
            get
            {
                if (_listApostasExtras.Count > 3)
                    return _listApostasExtras[3].NomeTime;
                else
                    return null;

            }
        }
        #endregion

        #region Constructors/Destructors
        public ApostasExtrasBolaoMembros()
            : base()
        {
        }
        public ApostasExtrasBolaoMembros(string userName)
            : base(userName)
        {
        }
        #endregion
    }
}
