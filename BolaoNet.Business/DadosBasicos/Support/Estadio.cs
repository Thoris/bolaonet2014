﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Business.DadosBasicos.Support
{
    public class Estadio : Model.DadosBasicos.Estadio, IBusinessBase
    {
        #region Variables
        
        private string _currentLogin = null;
        private BolaoNet.Dao.IDaoBase _daoBase = null;

        #endregion

        #region Constructors/Destructors
        public Estadio(string currentLogin, BolaoNet.Dao.IDaoBase daoBase)            
        {
            _currentLogin = currentLogin;
            _daoBase = daoBase;
        }
        public Estadio(string currentLogin, BolaoNet.Dao.IDaoBase daoBase, string nome)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentNullException("nome");

            _currentLogin = currentLogin;
            _daoBase = daoBase;
            base.Nome = nome;
        }
        public Estadio(string currentLogin)
        {
            _currentLogin = currentLogin;
            _daoBase = new Dao.DadosBasicos.SQLSupport.Estadio();
        }

        public Estadio(string currentLogin, string nome)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentNullException("nome");

            _currentLogin = currentLogin;
            _daoBase = new Dao.DadosBasicos.SQLSupport.Estadio();
        }
        
        #endregion

        #region IBusinessBase Members
        public BolaoNet.Dao.IDaoBase DaoBase
        {
            get { return _daoBase; }
        }

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

            Model.DadosBasicos.Estadio model = (Model.DadosBasicos.Estadio)result;

            this.Nome = model.Nome;
            this.ActiveFlag = model.ActiveFlag;
            this.CreatedBy = model.CreatedBy;
            this.CreatedDate = model.CreatedDate;
            this.ModifiedBy = model.ModifiedBy;
            this.ModifiedDate = model.ModifiedDate;

            this.Foto = model.Foto;
            this.Pais = model.Pais;
            this.Estado = model.Estado;
            this.Cidade = model.Cidade;
            this.Time = model.Time;
            
            this.Descricao = model.Descricao;
            

            return errorNumber == 0 ? true : false;
        }

        public IList<Framework.DataServices.Model.EntityBaseData> SelectAll(string condition)
        {
            int errorNumber = 0;
            string errorDescription = null;

            IList < Framework.DataServices.Model.EntityBaseData > list = _daoBase.SelectAll(
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

        #endregion
    }
}
