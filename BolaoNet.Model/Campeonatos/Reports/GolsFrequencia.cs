using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Model.Campeonatos.Reports
{
    [Serializable]
    public class GolsFrequencia : Framework.DataServices.Model.EntityBaseData
    {
        #region Variables
        private int _gols1 = 0;
        private int _gols2 = 0;
        private int _total = 0;
        #endregion

        #region Properties
        public int Gols1
        {
            get{return _gols1;}
            set{_gols1 = value;}
        }
        public int Gols2
        {
            get{return _gols2;}
            set{_gols2 = value;}
        }
        public int Total
        {
            get{return _total;}
            set{_total = value;}
        }
        #endregion

        #region Constructors/Destructors
        public GolsFrequencia()
        {
        }        
        #endregion
    }
}
