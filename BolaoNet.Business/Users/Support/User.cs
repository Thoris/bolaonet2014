using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Business.Users.Support
{
    public class User : Framework.Security.Model.UserData, IBusinessUser
    {
        #region Variables

        private string _currentLogin = null;
        private Dao.Users.IDaoUsers _daoBase = null;

        #endregion

        #region Constructors/Destructors
        public User(string currentLogin, Dao.Users.IDaoUsers daoBase)
            : base ()
        {
            _currentLogin = currentLogin;
            _daoBase = daoBase;
        }
        public User(string currentLogin)
            : base ()
        {
            _currentLogin = currentLogin;
            _daoBase = new Dao.Users.SQLSupport.Users();
        }
        public User(string currentLogin, string nome)
            : base ()
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentNullException("nome");

            base.UserName = nome;
            _currentLogin = currentLogin;
            _daoBase = new Dao.Users.SQLSupport.Users();
        }
        #endregion



        #region IBusinessUser Members

        public IList<BolaoNet.Model.Users.UserBoloes> LoadBoloes()
        {
            int errorNumber = 0;
            string errorDescription = null;

            IList<BolaoNet.Model.Users.UserBoloes> list = (IList < BolaoNet.Model.Users.UserBoloes >) _daoBase.LoadBoloes(
                _currentLogin, base.UserName, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return null;

            return list;
        }

        public IList<BolaoNet.Model.Users.UserPagamentos> LoadPagamentos()
        {
            int errorNumber = 0;
            string errorDescription = null;

            IList<BolaoNet.Model.Users.UserPagamentos> list = (IList<BolaoNet.Model.Users.UserPagamentos>)_daoBase.LoadPagamentos(
                _currentLogin, base.UserName, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return null;

            return list;
        }




        public IList<Framework.DataServices.Model.EntityBaseData> LoadMensagens()
        {
            int errorNumber = 0;
            string errorDescription = null;

            IList<Framework.DataServices.Model.EntityBaseData> list = _daoBase.LoadMensagens(
                _currentLogin, base.UserName, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return null;

            return list;
        }

        #endregion
    }
}
