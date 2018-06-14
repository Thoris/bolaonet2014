using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Business.Boloes.Support
{
    public class ApostaExtra : Model.Boloes.ApostaExtra, IBusinessApostaExtra
    {
        #region Variables

        private string _currentLogin = null;
        private Dao.Boloes.IDaoApostaExtra _daoBase = null;

        #endregion

        #region Constructors/Destructors
        public ApostaExtra(string currentLogin)
        {
            _currentLogin = currentLogin;
            _daoBase = new Dao.Boloes.SQLSupport.ApostaExtra();
        }
        public ApostaExtra(string currentLogin, int posicao, string nomeBolao)
        {
            _currentLogin = currentLogin;
            _daoBase = new Dao.Boloes.SQLSupport.ApostaExtra();

            base.Posicao = posicao;
            base.Bolao = new BolaoNet.Model.Boloes.Bolao(nomeBolao);
            
        }


        public ApostaExtra(string currentLogin, Dao.Boloes.IDaoApostaExtra daoBase)
        {
            if (daoBase == null)
                throw new ArgumentNullException("daoBase");

            _currentLogin = currentLogin;
            _daoBase = daoBase;

        }
        #endregion


        #region IBusinessBase Members

        public bool Insert()
        {
            int errorNumber = 0;
            string errorDescription = null;
            
            bool result = _daoBase.Insert(_currentLogin, this, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return false;


            return result;
        }

        public bool Update()
        {
            int errorNumber = 0;
            string errorDescription = null;

            bool result = _daoBase.Update(_currentLogin, this, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return false;

            return result;
        }

        public bool Delete()
        {
            int errorNumber = 0;
            string errorDescription = null;

            bool result = _daoBase.Delete(_currentLogin, this, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return false;

            return result;
        }

        public bool Load()
        {
            int errorNumber = 0;
            string errorDescription = null;

            Framework.DataServices.Model.EntityBaseData result = _daoBase.Load(
                _currentLogin, this, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return false;

            this.Copy((Model.Boloes.ApostaExtra)result);

            return errorNumber == 0 ? true : false;
        }

        public IList<Framework.DataServices.Model.EntityBaseData> SelectAll(string condition)
        {
            int errorNumber = 0;
            string errorDescription = null;

            IList<Framework.DataServices.Model.EntityBaseData> list = _daoBase.SelectAll(
                _currentLogin, condition, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return null;

            return list;
        }

        public IList<Framework.DataServices.Model.EntityBaseData> SelectPage(string condition, string order, int pageNumber, int pageSize)
        {
            int errorNumber = 0;
            string errorDescription = null;

            IList<Framework.DataServices.Model.EntityBaseData> list = _daoBase.SelectPage(
                _currentLogin, condition, order, pageNumber, pageSize, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return null;

            return list;
        }

        public int SelectCount(string condition)
        {
            int errorNumber = 0;
            string errorDescription = null;

            int result = _daoBase.SelectCount(
                _currentLogin, condition, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return -1;

            return result;
        }

        public IList<Framework.DataServices.Model.EntityBaseData> SelectCombo(params object[] fields)
        {
            int errorNumber = 0;
            string errorDescription = null;

            IList<Framework.DataServices.Model.EntityBaseData> list = _daoBase.SelectCombo(
                _currentLogin, out errorNumber, out errorDescription, fields);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return null;

            return list;
        }

        public BolaoNet.Dao.IDaoBase DaoBase
        {
            get { return _daoBase; }
        }


        public bool InsertResult()
        {
            int errorNumber = 0;
            string errorDescription = null;

            bool result = _daoBase.InsertResult(_currentLogin, this, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return false;

            return result;
        }

        #endregion
    }
}
