using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Business.Boloes.Support
{
    public class JogoUsuario : Model.Boloes.JogoUsuario, IBusinessJogoUsuario
    {
        #region Variables

        private string _currentLogin = null;
        private Dao.Boloes.IDaoJogoUsuario _daoBase = null;

        #endregion

        #region Constructors/Destructors
        public JogoUsuario(string currentLogin)
        {
            _currentLogin = currentLogin;
            _daoBase = new Dao.Boloes.SQLSupport.JogoUsuario();
        }
        public JogoUsuario(string currentLogin, Model.Boloes.JogoUsuario entry)
        {
            _currentLogin = currentLogin;
            _daoBase = new Dao.Boloes.SQLSupport.JogoUsuario();

            base.CopyAposta(entry);

        }
        public JogoUsuario(string currentLogin, Dao.Boloes.IDaoJogoUsuario daoBase)
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

            Model.Boloes.JogoUsuario model = (Model.Boloes.JogoUsuario)result;

            this.Copy(model);



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
        public IList<Framework.DataServices.Model.EntityBaseData> SelectAllByPeriod(BolaoNet.Model.Boloes.Bolao bolao, string userName, int rodada, DateTime dataInicial, DateTime dataFinal, string time, string fase, string grupo, string condition)
        {
            int errorNumber = 0;
            string errorDescription = null;

            IList<Framework.DataServices.Model.EntityBaseData> list = _daoBase.LoadApostas (
                _currentLogin, rodada, bolao, dataInicial, dataFinal, userName, time, fase, grupo, condition, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return null;

            return list;
        }
        public long SelectCountByPeriodo(BolaoNet.Model.Boloes.Bolao bolao, string userName, int rodada, DateTime dataInicial, DateTime dataFinal, BolaoNet.Model.Boloes.JogoUsuario.TypeAposta typeAposta, BolaoNet.Model.Boloes.JogoUsuario.TypeAutomatico typeAutomatico, string condition)
        {
            int errorNumber = 0;
            string errorDescription = null;

            long result = _daoBase.LoadCount(
                _currentLogin, rodada, bolao, dataInicial, dataFinal, userName, condition, typeAposta, typeAutomatico, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return -1;

            return result;
        }
        public IList<Framework.DataServices.Model.EntityBaseData> LoadApostasByJogo(BolaoNet.Model.Boloes.Bolao bolao, BolaoNet.Model.Campeonatos.Jogo jogo, string condition)
        {
            int errorNumber = 0;
            string errorDescription = null;

            IList<Framework.DataServices.Model.EntityBaseData> list = _daoBase.LoadApostasByJogo(
                _currentLogin, bolao, jogo, condition, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return null;

            return list;
        }

        #endregion

        #region IJogoUsuario Members

        public long LoadApostasCountByJogo(BolaoNet.Model.Boloes.Bolao bolao, BolaoNet.Model.Campeonatos.Jogo jogo, string condition)
        {
            int errorNumber = 0;
            string errorDescription = null;

            long result = _daoBase.LoadApostasCountByJogo(
                _currentLogin, bolao, jogo, condition, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return -1;

            return result;
        }
        public IList<Framework.DataServices.Model.EntityBaseData> InsertApostasAuto(BolaoNet.Model.Boloes.Bolao bolao, string userName, BolaoNet.Model.Boloes.JogoUsuario.TypeAposta typeAposta, BolaoNet.Model.Boloes.JogoUsuario.TypeAutomatico typeAutomatico, DateTime dataInicial, DateTime dataFinal, int rodada, bool random, int time1, int time2, int randomInicial, int randomFinal, string nomeTime)
        {
            int errorNumber = 0;
            string errorDescription = null;

            IList < Framework.DataServices.Model.EntityBaseData > list = _daoBase.InsertApostasAuto(
                _currentLogin, bolao, userName, typeAposta, typeAutomatico, 
                dataInicial, dataFinal, rodada, random, time1, time2, randomInicial, randomFinal, nomeTime, 
                out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return null;

            return list;
        }
        public IList<BolaoNet.Model.Campeonatos.CampeonatoClassificacao> LoadClassificacao(BolaoNet.Model.Boloes.Bolao bolao, BolaoNet.Model.Campeonatos.Fase fase, BolaoNet.Model.Campeonatos.Grupo grupo, Framework.Security.Model.UserData user)
        {

            int errorNumber = 0;
            string errorDescription = null;

            IList<Model.Campeonatos.CampeonatoClassificacao> list = _daoBase.LoadClassificacao(
                _currentLogin, bolao, fase, grupo, user,
                out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return null;

            return list;
        }
        public IList<Framework.DataServices.Model.EntityBaseData> LoadAcertosDificeis(Model.Boloes.Bolao bolao, int totalPessoas)
        {
            int errorNumber = 0;
            string errorDescription = null;

            IList<Framework.DataServices.Model.EntityBaseData> result = _daoBase.LoadAcertosDificeis(
                _currentLogin, bolao, totalPessoas, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return null;

            return result;
        }
        public void CorrecaoEliminatorias(Model.Boloes.Bolao bolao, string userName)
        {
            int errorNumber = 0;
            string errorDescription = null;

            _daoBase.CorrecaoEliminatorias(
                _currentLogin, bolao, userName, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return ;

        }
        public Model.Boloes.JogoUsuario LoadSocialNetwork(Model.Boloes.Bolao bolao, string userName, Model.Campeonatos.Jogo jogo)
        {
            int errorNumber = 0;
            string errorDescription = null;

            IList<Model.Boloes.JogoUsuario> list = _daoBase.LoadSocialNetwork(_currentLogin, bolao, userName, jogo, out errorNumber, out errorDescription);

            if (list == null || list.Count == 0)
                return null;
            else
                return list[0];

        }

        public bool UpdateFacebook(Model.Boloes.Bolao bolao, string userName, Model.Campeonatos.Jogo jogo)
        {

            int errorNumber = 0;
            string errorDescription = null;


            bool result = _daoBase.UpdateFacebook(_currentLogin, bolao, userName, jogo, out errorNumber, out errorDescription);

            return result;


        }

        public IList<Framework.DataServices.Model.EntityBaseData> LoadSemAcertos(Model.Boloes.Bolao bolao)
        {

            int errorNumber = 0;
            string errorDescription = null;

            IList<Framework.DataServices.Model.EntityBaseData> result = _daoBase.LoadSemAcertos(
                _currentLogin, bolao, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return null;

            return result;
        }
        public IList<Framework.DataServices.Model.EntityBaseData> LoadProximasApostas(string userName)
        {
            int errorNumber = 0;
            string errorDescription = null;

            IList<Framework.DataServices.Model.EntityBaseData> result = _daoBase.LoadProximasApostas(
                _currentLogin, userName, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return null;

            return result;

        }

        public IList<Framework.DataServices.Model.EntityBaseData> LoadPontosObtidos(string userName)
        {

            int errorNumber = 0;
            string errorDescription = null;

            IList<Framework.DataServices.Model.EntityBaseData> result = _daoBase.LoadPontosObtidos(
                _currentLogin, userName, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return null;

            return result;
        }

        #endregion
    }
}
