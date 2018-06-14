using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Model.Campeonatos.Reports
{
    [Serializable]
    public class TimeRodadas
    {
        #region Variables
        private int _rodada;
        private DadosBasicos.Time _time = new BolaoNet.Model.DadosBasicos.Time();
        private int _posicao;
        #endregion

        #region Properties
        public int Rodada
        {
            get { return _rodada; }
            set { _rodada = value; }
        }
        public DadosBasicos.Time Time
        {
            get { return _time; }
            set { _time = value; }
        }
        public int Posicao
        {
            get { return _posicao; }
            set { _posicao = value; }
        }
            
        #endregion

        #region Constructors/Destructors
        public TimeRodadas()
        {
        }
        #endregion

    }
}
