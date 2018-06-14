using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Model.Users
{
    [Serializable]
    public class UserPagamentos : Framework.DataServices.Model.EntityBaseData
    {
        #region Variables
        private decimal _valor;
        private Boloes.Bolao _bolao = new BolaoNet.Model.Boloes.Bolao();
        private decimal _total;
        private DateTime _dataInicio;
        
        #endregion

        #region Properties
        public decimal Devendo
        {
            get 
            {
                decimal saldo = _total - _valor;

                if (saldo < 0)
                    saldo = 0;

                return saldo;
            }
        }
        public Campeonatos.Campeonato Campeonato
        {
            get { return _bolao.Campeonato; }
        }
        public decimal Valor
        {
            get { return _valor; }
            set { _valor= value; }
        }
        public Boloes.Bolao Bolao
        {
            get { return _bolao; }
            set { _bolao = value; }
        }
        public decimal Total
        {
            get { return _total; }
            set { _total = value; }
        }
        public DateTime DataInicio            
        {
            get{return _dataInicio;}
            set{_dataInicio = value;}
        }

        #endregion

        #region Constructors/Destructors
        public UserPagamentos()
        {
        }
        #endregion
    }
}
