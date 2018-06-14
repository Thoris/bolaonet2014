using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Business.Boloes.Support
{
    public class Bolao : Model.Boloes.Bolao, IBusinessBolao
    {
        #region Variables

        private string _currentLogin = null;
        private Dao.Boloes.IDaoBolao _daoBase = null;

        #endregion

        #region Constructors/Destructors
        public Bolao(string currentLogin)
        {
            _currentLogin = currentLogin;
            _daoBase = new Dao.Boloes.SQLSupport.Bolao();
        }
        public Bolao(string currentLogin, string nome)
        {
            _currentLogin = currentLogin;
            _daoBase = new Dao.Boloes.SQLSupport.Bolao();

            base.Nome = nome;
        }

        
        public Bolao(string currentLogin, Dao.Boloes.IDaoBolao daoBase)
        {
            if (daoBase == null)
                throw new ArgumentNullException("daoBase");

            _currentLogin = currentLogin;
            _daoBase = daoBase;

        }

                
        #endregion

        #region IBusinessBolao Members

        public IList<BolaoNet.Model.Boloes.BolaoMembros> LoadClassificacao(int rodada)
        {
            int errorNumber = 0;
            string errorDescription = null;

            IList<BolaoNet.Model.Boloes.BolaoMembros> list = _daoBase.LoadClassificacao(
                _currentLogin, this, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return null;

            return list;
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

            if (result == null)
                return false;

            this.Copy((Model.Boloes.Bolao)result);

            return errorNumber == 0 ? true : false;
        }

        public IList<Framework.DataServices.Model.EntityBaseData> SelectAllEnabled(string condition)
        {
            int errorNumber = 0;
            string errorDescription = null;

            IList<Framework.DataServices.Model.EntityBaseData> list = _daoBase.SelectAllEnabled(
                _currentLogin, condition, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return null;

            return list;
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


        public IList<Framework.DataServices.Model.EntityBaseData> LoadBoloes(Framework.Security.Model.UserData usuario)
        {
            int errorNumber = 0;
            string errorDescription = null;

            IList<Framework.DataServices.Model.EntityBaseData> list = _daoBase.LoadBoloes(
                _currentLogin, usuario, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return null;

            return list;
        }
        public IList<Framework.DataServices.Model.EntityBaseData> LoadMembros()
        {
            int errorNumber = 0;
            string errorDescription = null;

            IList<Framework.DataServices.Model.EntityBaseData> list = _daoBase.LoadMembros (
                _currentLogin, this, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return null;

            return list;
        }
        public bool InsertMembro(Framework.Security.Model.UserData usuario)
        {
            int errorNumber = 0;
            string errorDescription = null;

            bool result = _daoBase.InsertMembro(
                _currentLogin, this, usuario, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return false;

            return result;
        }
        public bool DeleteMembro(Framework.Security.Model.UserData usuario)
        {
            int errorNumber = 0;
            string errorDescription = null;

            bool result = _daoBase.DeleteMembro(
                _currentLogin, this, usuario, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return false;

            return result;
        }
        public bool ClearMembros()
        {
            int errorNumber = 0;
            string errorDescription = null;

            bool result = _daoBase.ClearMembros(
                _currentLogin, this,out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return false;

            return result;
        }

        public IList<Framework.DataServices.Model.EntityBaseData> SelectPremios()
        {
            int errorNumber = 0;
            string errorDescription = null;

            IList<Framework.DataServices.Model.EntityBaseData> list = _daoBase.SelectPremios(
                _currentLogin, this,  out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return null;

            return list;
        }

        public bool BolaoParticipar(Model.Boloes.BolaoRequest request)
        {
            int errorNumber = 0;
            string errorDescription = null;

            bool result = _daoBase.BolaoParticipar(
                _currentLogin, request, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return false;

            return result;
        }
        public bool BolaoChangeStatus(Model.Boloes.BolaoRequest request)
        {
            int errorNumber = 0;
            string errorDescription = null;

            bool result = _daoBase.BolaoChangeStatus(
                _currentLogin, request, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return false;

            return result;
        }

        public bool BolaoAceitar(Model.Boloes.BolaoRequest request)
        {
            int errorNumber = 0;
            string errorDescription = null;

            request.StatusRequestID = BolaoNet.Model.Boloes.BolaoRequest.Status.Aprovado;

            bool result = _daoBase.BolaoChangeStatus(
                _currentLogin, request, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return false;


            //Inserindo o membro
            result = InsertMembro(new Framework.Security.Model.UserData(request.RequestedBy));


            return result;
        }
        public IList<Framework.DataServices.Model.EntityBaseData> SelectRequestsAll(string condition)
        {
            int errorNumber = 0;
            string errorDescription = null;

            IList<Framework.DataServices.Model.EntityBaseData> list = _daoBase.SelectRequestsAll(
                _currentLogin, condition, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return null;

            return list;
        }

        public bool IsUserInBolao(Framework.Security.Model.UserData usuario)
        {
            int errorNumber = 0;
            string errorDescription = null;

            bool result = _daoBase.IsUserInBolao(
                _currentLogin, usuario, this, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return false;

            return result;
        }

        public IList<Framework.DataServices.Model.EntityBaseData> SelectRequestsAllByBolao(string condition)
        {
            int errorNumber = 0;
            string errorDescription = null;

            IList<Framework.DataServices.Model.EntityBaseData> list = _daoBase.SelectRequestsAll(
                _currentLogin, this, condition, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return null;

            return list;
        }
        public IList<Framework.DataServices.Model.EntityBaseData> SelectRequestsPendentesByBolao(string condition)
        {
            int errorNumber = 0;
            string errorDescription = null;

            IList<Framework.DataServices.Model.EntityBaseData> list = _daoBase.SelectRequestsPendentes(
                _currentLogin, this, condition, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return null;

            return list;
        }

        #endregion

        #region IBusinessBolaoCriteriosPontos Members


        public IList<Framework.DataServices.Model.EntityBaseData> LoadCriteriosPontos(string condition)
        {

            int errorNumber = 0;
            string errorDescription = null;

            IList<Framework.DataServices.Model.EntityBaseData> list = _daoBase.LoadCriteriosPontos( 
                _currentLogin, this, condition, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return null;

            return list;
        }

        public bool UpdateCriterioPontos(BolaoNet.Model.Boloes.BolaoCriterioPontos entry)
        {
            int errorNumber = 0;
            string errorDescription = null;

            bool result = _daoBase.UpdateCriterioPontos(
                _currentLogin, entry, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return false;

            return result;
        }

        #endregion

        #region IBusinessBolaoCriteriosPontosTimes Members


        public IList<Framework.DataServices.Model.EntityBaseData> LoadCriteriosPontosTimes(string condition)
        {

            int errorNumber = 0;
            string errorDescription = null;

            IList<Framework.DataServices.Model.EntityBaseData> list = _daoBase.LoadCriteriosPontosTimes(
                _currentLogin, this, condition, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return null;

            return list;
        }

        public bool UpdateCriterioPontosTimes(BolaoNet.Model.Boloes.BolaoCriterioPontosTimes entry)
        {
            int errorNumber = 0;
            string errorDescription = null;

            bool result = _daoBase.UpdateCriterioPontosTimes(
                _currentLogin, entry, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return false;

            return result;
        }

        #endregion


        #region IBusinessBolao Members


        public bool Iniciar()
        {

            int errorNumber = 0;
            string errorDescription = null;

            bool result = _daoBase.Iniciar(
                _currentLogin, base.IniciadoBy, this, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return false;

            return result;
        }

        public bool Aguardar()
        {
            int errorNumber = 0;
            string errorDescription = null;

            bool result = _daoBase.Aguardar(
                _currentLogin, this, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return false;

            return result;
        }



        public IList<Framework.DataServices.Model.EntityBaseData> LoadApostasRestantes()
        {
            int errorNumber = 0;
            string errorDescription = null;

            IList<Framework.DataServices.Model.EntityBaseData> result = _daoBase.LoadApostasRestantes(
                _currentLogin, this, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return null;

            return result;
        }

        #endregion

        #region IBusinessBolao Members


        public IList<Framework.DataServices.Model.EntityBaseData> SelectPontuacao()
        {
            int errorNumber = 0;
            string errorDescription = null;

            IList<Framework.DataServices.Model.EntityBaseData> result = _daoBase.SelectPontuacao(
                _currentLogin, this, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return null;

            return result;
        }

        #endregion

        #region IBusinessBolao Members


        public IList<BolaoNet.Model.Boloes.Reports.UserPontosData> LoadAllPontosDataByUser(Framework.Security.Model.UserData usuario)
        {
            int errorNumber = 0;
            string errorDescription = null;

            IList<BolaoNet.Model.Boloes.Reports.UserPontosData> list = _daoBase.LoadAllPontosDataByUser(
                _currentLogin, this, usuario, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return null;

            return list;
        }

        #endregion

        #region IBusinessBolao Members


        public IList<Model.Boloes.Reports.UserClassificacaoRodada> LoadHistoricoClassificacao()
        {
            int errorNumber = 0;
            string errorDescription = null;

            IList<Model.Boloes.Reports.UserClassificacaoRodada> rodadas =
                new List<Model.Boloes.Reports.UserClassificacaoRodada>();
                


            IList<BolaoNet.Model.Boloes.Reports.UserClassificacaoRodada> list = _daoBase.LoadHistoricoClassificacao(
                _currentLogin, this, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return null;

            return list;


        }



        public IList<Model.Boloes.BolaoMembros> LoadClassificacaoGrupo(Framework.Security.Model.UserData usuario)
        {
            int errorNumber = 0;
            string errorDescription = null;

            IList<Model.Boloes.BolaoMembros> rodadas =
                new List<Model.Boloes.BolaoMembros>();



            IList<BolaoNet.Model.Boloes.BolaoMembros> list = _daoBase.LoadClassificacaoGrupo(
                _currentLogin, this, usuario, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return null;

            return list;
        }
        public bool InsertGrupoMembro(Framework.Security.Model.UserData usuario, Model.Boloes.BolaoMembros usuarioSelecionado)
        {
            int errorNumber = 0;
            string errorDescription = null;

            bool result = _daoBase.InsertGrupoMembro(
                _currentLogin, this, usuario, usuarioSelecionado, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return false;

            return result;
        }
        public bool DeleteGrupoMembro(Framework.Security.Model.UserData usuario, Model.Boloes.BolaoMembros usuarioSelecionado)
        {
            int errorNumber = 0;
            string errorDescription = null;

            bool result = _daoBase.DeleteGrupoMembro(
                _currentLogin, this, usuario, usuarioSelecionado, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return false;

            return result;
        }

        #endregion


        
    }
}
