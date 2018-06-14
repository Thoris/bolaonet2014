using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Model.Boloes
{
    [Serializable]
    public class Regra : Framework.DataServices.Model.EntityBaseData
    {
        #region Variables
        private string _description;
        private int _regraID;
        private Bolao _bolao = new Bolao();
        #endregion

        #region Properties
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public int RegraID
        {
            get { return _regraID; }
            set { _regraID = value; }
        }
        public Bolao Bolao
        {
            get { return _bolao; }
            set { _bolao = value; }
        }

        #endregion

        #region Constructors/Destructors
        public Regra()
        {
        }
        public Regra(int regraID, string nomeBolao)
        {
            _regraID = regraID;
            _bolao = new Bolao(nomeBolao);
            
        }
        #endregion

    }
}
