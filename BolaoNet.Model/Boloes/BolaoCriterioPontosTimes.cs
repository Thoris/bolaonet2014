using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Model.Boloes
{
    [Serializable]
    public class BolaoCriterioPontosTimes : Framework.DataServices.Model.EntityBaseData
    {
        #region Variables   
        private Bolao _bolao = new Bolao();
        private int _multiplo = 0;
        private Model.DadosBasicos.Time _time = new Model.DadosBasicos.Time();
        #endregion

        #region Properties
        public Bolao Bolao
        {
            get { return _bolao; }
            set { _bolao = value; }
        }
        
        public Model.DadosBasicos.Time Time
        {
            get { return _time; }
            set { _time = value; }
        }
        public int MultiploTime
        {
            get { return _multiplo; }
            set { _multiplo = value; }
        }
        #endregion

        #region Constructors/Destructors
        public BolaoCriterioPontosTimes()
        {

        }
        public BolaoCriterioPontosTimes(string nomeBolao, string nomeTime)
        {
            _bolao = new Bolao(nomeBolao);
            _time = new BolaoNet.Model.DadosBasicos.Time(nomeTime);
        }
        #endregion

        #region Methods
        public void Copy(BolaoCriterioPontosTimes entry)
        {
            _bolao = entry._bolao;
            _multiplo = entry._multiplo;
            _time = entry._time;
           


            base.Copy(entry);
        }
        #endregion
    }
}
