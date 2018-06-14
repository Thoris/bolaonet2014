using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Model
{

    [Serializable]
    public class RecordTime : Framework.DataServices.Model.EntityBaseData
    {
        #region Variables
        private int _posicao;
        private Model.DadosBasicos.Time _time = new BolaoNet.Model.DadosBasicos.Time ();
        private int _empates;
        private int _derrotas;
        private int _vitorias;
        #endregion

        #region Properties
        public int Posicao
        {
            get { return _posicao; }
            set { _posicao= value; }
        }
        public int Empates
        {
            get { return _empates; }
            set { _empates= value; }
        }
        public int Derrotas
        {
            get { return _derrotas; }
            set { _derrotas= value; }
        }
        public int Vitorias
        {
            get { return _vitorias; }
            set { _vitorias= value; }
        }
        
        public Model.DadosBasicos.Time Time
        {
            get { return _time; }
            set { _time = value; }
        }
        #endregion

        #region Constructors/Destructors
        public RecordTime()
        {
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return base.ToString();
        }
        #endregion
    }
}
