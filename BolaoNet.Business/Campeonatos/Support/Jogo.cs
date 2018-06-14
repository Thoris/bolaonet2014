using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Business.Campeonatos.Support
{
    public class Jogo : Model.Campeonatos.Jogo , IBusinessJogo
    {
        #region Variables
        private string _currentLogin = null;
        private BolaoNet.Dao.Campeonatos.IDaoJogo _daoBase = null;
        #endregion

        #region Constructors/Destructors
        public Jogo(string currentLogin, BolaoNet.Dao.Campeonatos.IDaoJogo daoBase)
        {
            if (daoBase == null)
                throw new ArgumentNullException("daoBase");

            _currentLogin = currentLogin;
            _daoBase = daoBase;

        }
        public Jogo(string currentLogin)
        {
            _currentLogin = currentLogin;
            _daoBase = new Dao.Campeonatos.SQLSupport.Jogo();
        }
        public Jogo(string currentLogin, BolaoNet.Dao.Campeonatos.IDaoJogo daoBase, Model.Campeonatos.Jogo jogo)
        {
            if (jogo == null)
                throw new ArgumentNullException("jogo");

            if (daoBase == null)
                throw new ArgumentNullException("daoBase");

            _currentLogin = currentLogin;
            _daoBase = daoBase;

            this.Copy(jogo);
        }
        public Jogo(string currentLogin, Model.Campeonatos.Jogo jogo)
        {
            if (jogo == null)
                throw new ArgumentNullException("jogo");

            _currentLogin = currentLogin;
            _daoBase = new Dao.Campeonatos.SQLSupport.Jogo();

            this.Copy(jogo);
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

            this.Copy((Model.Campeonatos.Jogo)result);


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
        public bool InsertResult(int gols1, int gols2, int penaltis1, int penaltis2)
        {
            int errorNumber = 0;
            string errorDescription = null;

            bool result = _daoBase.InsertResult(
                _currentLogin, gols1, gols2, penaltis1, penaltis2, this, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return false;

            return result;
        }
        public bool RemoveResult()
        {
            int errorNumber = 0;
            string errorDescription = null;

            bool result = _daoBase.RemoveResult(
                _currentLogin, this, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return false;

            return result;
        }
        public IList<Framework.DataServices.Model.EntityBaseData> SelectAllByPeriod(Model.Campeonatos.Campeonato campeonato, int rodada, DateTime dataInicial, DateTime dataFinal, string time, string fase, string grupo, string condition, string order)
        {
            int errorNumber = 0;
            string errorDescription = null;

            IList<Framework.DataServices.Model.EntityBaseData> list = _daoBase.SelectAllByPeriod(
                _currentLogin, rodada, campeonato, dataInicial, dataFinal, time, fase, grupo,
                condition, order, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return null;

            return list;
        }
        public IList<Framework.DataServices.Model.EntityBaseData> SelectJogosByTime(Model.Campeonatos.Campeonato campeonato, Model.DadosBasicos.Time time, string condition, string order)
        {
            int errorNumber = 0;
            string errorDescription = null;

            IList<Framework.DataServices.Model.EntityBaseData> list = _daoBase.SelectJogosByTime(
                _currentLogin, campeonato, time, condition, order, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return null;

            return list;
        }
        public bool InsertWithAllData(bool isClube, Framework.DataServices.Model.EntityBaseData entry)
        {
            int errorNumber = 0;
            string errorDescription = null;

            Model.Campeonatos.Jogo jogo = (Model.Campeonatos.Jogo)entry;

            bool result = _daoBase.InsertWithAllData(_currentLogin, isClube, entry, out errorNumber, out errorDescription);

            if (errorNumber > 0 || !string.IsNullOrEmpty(errorDescription))
            {
                return false;
            }

            return result;


        }
        public IList<Framework.DataServices.Model.EntityBaseData> SelectGoleadas(BolaoNet.Model.Campeonatos.Campeonato campeonato, int maxGols, string condition, string order)
        {
            int errorNumber = 0;
            string errorDescription = null;


            IList<Framework.DataServices.Model.EntityBaseData> list = _daoBase.SelectGoleadas(
                _currentLogin, campeonato, maxGols, condition, order, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return null;

            return list;
        }
        public IList<Framework.DataServices.Model.EntityBaseData> LoadNextJogos(BolaoNet.Model.Campeonatos.Campeonato campeonato, int totalJogos)
        {
            int errorNumber = 0;
            string errorDescription = null;


            IList<Framework.DataServices.Model.EntityBaseData> list = _daoBase.LoadNextJogos(
                _currentLogin, campeonato, totalJogos, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return null;

            return list;
        }
        public IList<Framework.DataServices.Model.EntityBaseData> LoadFinishedJogos(BolaoNet.Model.Campeonatos.Campeonato campeonato, int totalJogos)
        {
            int errorNumber = 0;
            string errorDescription = null;


            IList<Framework.DataServices.Model.EntityBaseData> list = _daoBase.LoadFinishedJogos(
                _currentLogin, campeonato, totalJogos, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return null;

            return list;
        }
        public int NextJogo(Model.Campeonatos.Campeonato campeonato)
        {
            int errorNumber = 0;
            string errorDescription = null;

            int result = _daoBase.NextJogo(_currentLogin, campeonato, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return 0;

            
            return result;
        }
        #endregion

        #region Methods
        public bool InsertCampeonatoCopaMundo2010Jogo(string currentLogin, bool isClube,
            string nomeCampeonato, DateTime dataJogo, string estadio,
            string time1, string time2, string nomeFase, string nomeGrupo, int rodada, 
            string titulo)
        {
            Model.Campeonatos.Jogo jogo = new BolaoNet.Model.Campeonatos.Jogo();
            jogo.Campeonato = new BolaoNet.Model.Campeonatos.Campeonato(nomeCampeonato);
            jogo.DataJogo = dataJogo;
            jogo.Estadio = new BolaoNet.Model.DadosBasicos.Estadio(estadio);
            jogo.Fase = new BolaoNet.Model.Campeonatos.Fase(nomeFase);
            jogo.Grupo = new BolaoNet.Model.Campeonatos.Grupo(nomeGrupo);
            jogo.Rodada = rodada;
            jogo.Time1 = new BolaoNet.Model.DadosBasicos.Time(time1);
            jogo.Time2 = new BolaoNet.Model.DadosBasicos.Time(time2);
            jogo.Titulo = titulo;

            Business.Campeonatos.Support.Jogo business = new Jogo(currentLogin, jogo);
            bool result = business.InsertWithAllData(isClube, jogo);

            return result;
        }

        public void InsertCampeonatoCopaMundo2010(string nomeCampeonato)
        {

            //--------------------- A -----------------------

            InsertCampeonatoCopaMundo2010Jogo(_currentLogin, false, nomeCampeonato,
                            new DateTime(2010, 06, 11, 11, 0, 0), "Johanesburgo", "África do Sul", "México",
                            "Classificatória", "A", 1, "");


            InsertCampeonatoCopaMundo2010Jogo(_currentLogin, false, nomeCampeonato,
                            new DateTime(2010, 06, 11, 15, 30, 0), "Cidade do Cabo", "Uruguai", "França",
                            "Classificatória", "A", 1, "");

            InsertCampeonatoCopaMundo2010Jogo(_currentLogin, false, nomeCampeonato,
                            new DateTime(2010, 06, 16, 15, 30, 0), "Pretória", "África do Sul", "Uruguai",
                            "Classificatória", "A", 2, "");

            InsertCampeonatoCopaMundo2010Jogo(_currentLogin, false, nomeCampeonato,
                            new DateTime(2010, 06, 17, 15, 30, 0), "Polokwane", "França", "México",
                            "Classificatória", "A", 2, "");

            InsertCampeonatoCopaMundo2010Jogo(_currentLogin, false, nomeCampeonato,
                            new DateTime(2010, 06, 22, 11, 00, 0), "Rustenburg", "México", "Uruguai",
                            "Classificatória", "A", 3, "");

            InsertCampeonatoCopaMundo2010Jogo(_currentLogin, false, nomeCampeonato,
                            new DateTime(2010, 06, 22, 11, 00, 0), "Bloemfontein", "França", "África do Sul",
                            "Classificatória", "A", 3, "");


            //--------------------- B -----------------------


            InsertCampeonatoCopaMundo2010Jogo(_currentLogin, false, nomeCampeonato,
                            new DateTime(2010, 06, 12, 08, 30, 0), "Port Elizabeth", "Coreia do Sul", "Grécia",
                            "Classificatória", "B", 1, "");

            InsertCampeonatoCopaMundo2010Jogo(_currentLogin, false, nomeCampeonato,
                            new DateTime(2010, 06, 12, 11, 0, 0), "Johanesburgo", "Argentina", "Nigéria",
                            "Classificatória", "B", 1, "");

            InsertCampeonatoCopaMundo2010Jogo(_currentLogin, false, nomeCampeonato,
                            new DateTime(2010, 06, 17, 8, 30, 0), "Johanesburgo", "Argentina", "Coreia do Sul",
                            "Classificatória", "B", 2, "");

            InsertCampeonatoCopaMundo2010Jogo(_currentLogin, false, nomeCampeonato,
                            new DateTime(2010, 06, 17, 11, 0, 0), "Bloemfontein", "Grécia", "Nigéria",
                            "Classificatória", "B", 2, "");

            InsertCampeonatoCopaMundo2010Jogo(_currentLogin, false, nomeCampeonato,
                            new DateTime(2010, 06, 22, 15, 30, 0), "Durban", "Nigéria", "Coreia do Sul",
                            "Classificatória", "B", 3, "");

            InsertCampeonatoCopaMundo2010Jogo(_currentLogin, false, nomeCampeonato,
                            new DateTime(2010, 06, 22, 15, 30, 0), "Polokwane", "Grécia", "Argentina",
                            "Classificatória", "B", 3, "");


            //--------------------- C -----------------------


            InsertCampeonatoCopaMundo2010Jogo(_currentLogin, false, nomeCampeonato,
                            new DateTime(2010, 06, 12, 15, 30, 0), "Rustenburg", "Inglaterra", "Estados Unidos",
                            "Classificatória", "C", 1, "");

            InsertCampeonatoCopaMundo2010Jogo(_currentLogin, false, nomeCampeonato,
                            new DateTime(2010, 06, 13, 8, 30, 0), "Polokwane", "Argélia", "Eslovênia",
                            "Classificatória", "C", 1, "");

            InsertCampeonatoCopaMundo2010Jogo(_currentLogin, false, nomeCampeonato,
                            new DateTime(2010, 06, 18, 11, 0, 0), "Johanesburgo", "Eslovênia", "Estados Unidos",
                            "Classificatória", "C", 2, "");

            InsertCampeonatoCopaMundo2010Jogo(_currentLogin, false, nomeCampeonato,
                            new DateTime(2010, 06, 18, 15, 30, 0), "Cidade do Cabo", "Inglaterra", "Argélia",
                            "Classificatória", "C", 2, "");

            InsertCampeonatoCopaMundo2010Jogo(_currentLogin, false, nomeCampeonato,
                            new DateTime(2010, 06, 23, 11, 0, 0), "Port Elizabeth", "Eslovênia", "Inglaterra",
                            "Classificatória", "C", 3, "");

            InsertCampeonatoCopaMundo2010Jogo(_currentLogin, false, nomeCampeonato,
                            new DateTime(2010, 06, 23, 11, 0, 0), "Pretória", "Estados Unidos", "Argélia",
                            "Classificatória", "C", 3, "");

            //--------------------- D -----------------------


            InsertCampeonatoCopaMundo2010Jogo(_currentLogin, false, nomeCampeonato,
                            new DateTime(2010, 06, 13, 11, 0, 0), "Pretória", "Sérvia", "Gana",
                            "Classificatória", "D", 1, "");

            InsertCampeonatoCopaMundo2010Jogo(_currentLogin, false, nomeCampeonato,
                            new DateTime(2010, 06, 13, 15, 30, 0), "Durban", "Alemanha", "Austrália",
                            "Classificatória", "D", 1, "");

            InsertCampeonatoCopaMundo2010Jogo(_currentLogin, false, nomeCampeonato,
                            new DateTime(2010, 06, 18, 8, 30, 0), "Port Elizabeth", "Alemanha", "Sérvia",
                            "Classificatória", "D", 2, "");

            InsertCampeonatoCopaMundo2010Jogo(_currentLogin, false, nomeCampeonato,
                            new DateTime(2010, 06, 19, 11, 0, 0), "Rustenburg", "Gana", "Austrália",
                            "Classificatória", "D", 2, "");

            InsertCampeonatoCopaMundo2010Jogo(_currentLogin, false, nomeCampeonato,
                            new DateTime(2010, 06, 23, 15, 30, 0), "Johanesburgo", "Gana", "Alemanha",
                            "Classificatória", "D", 3, "");

            InsertCampeonatoCopaMundo2010Jogo(_currentLogin, false, nomeCampeonato,
                            new DateTime(2010, 06, 23, 15, 30, 0), "Nelspruit", "Austrália", "Sérvia",
                            "Classificatória", "D", 3, "");

            //--------------------- E -----------------------


            InsertCampeonatoCopaMundo2010Jogo(_currentLogin, false, nomeCampeonato,
                            new DateTime(2010, 06, 14, 8, 30, 0), "Johanesburgo", "Holanda", "Dinamarca",
                            "Classificatória", "E", 1, "");

            InsertCampeonatoCopaMundo2010Jogo(_currentLogin, false, nomeCampeonato,
                            new DateTime(2010, 06, 14, 11, 0, 0), "Bloemfontein", "Japão", "Camarões",
                            "Classificatória", "E", 1, "");

            InsertCampeonatoCopaMundo2010Jogo(_currentLogin, false, nomeCampeonato,
                            new DateTime(2010, 06, 19, 8, 30, 0), "Durbain", "Holanda", "Japão",
                            "Classificatória", "E", 2, "");

            InsertCampeonatoCopaMundo2010Jogo(_currentLogin, false, nomeCampeonato,
                            new DateTime(2010, 06, 19, 15, 30, 0), "Pretória", "Camarões", "Dinamarca",
                            "Classificatória", "E", 2, "");

            InsertCampeonatoCopaMundo2010Jogo(_currentLogin, false, nomeCampeonato,
                            new DateTime(2010, 06, 24, 15, 30, 0), "Rustenburg", "Dinamarca", "Japão",
                            "Classificatória", "E", 3, "");

            InsertCampeonatoCopaMundo2010Jogo(_currentLogin, false, nomeCampeonato,
                            new DateTime(2010, 06, 24, 15, 30, 0), "Cidade do Cabo", "Camarões", "Holanda",
                            "Classificatória", "E", 3, "");

            
            //--------------------- F -----------------------


            InsertCampeonatoCopaMundo2010Jogo(_currentLogin, false, nomeCampeonato,
                            new DateTime(2010, 06, 14, 15, 30, 0), "Cidade do Cabo", "Itália", "Paraguai",
                            "Classificatória", "F", 1, "");

            InsertCampeonatoCopaMundo2010Jogo(_currentLogin, false, nomeCampeonato,
                            new DateTime(2010, 06, 15, 8, 30, 0), "Rustenburg", "Nova Zelândia", "Eslováquia",
                            "Classificatória", "F", 1, "");

            InsertCampeonatoCopaMundo2010Jogo(_currentLogin, false, nomeCampeonato,
                            new DateTime(2010, 06, 20, 8, 30, 0), "Bloemfontein", "Eslováquia", "Paraguai",
                            "Classificatória", "F", 2, "");

            InsertCampeonatoCopaMundo2010Jogo(_currentLogin, false, nomeCampeonato,
                            new DateTime(2010, 06, 20, 11, 0, 0), "Nelspruit", "Itália", "Nova Zelândia",
                            "Classificatória", "F", 2, "");

            InsertCampeonatoCopaMundo2010Jogo(_currentLogin, false, nomeCampeonato,
                            new DateTime(2010, 06, 24, 11, 0, 0), "Johanesburgo", "Eslováquia", "Itália",
                            "Classificatória", "F", 3, "");

            InsertCampeonatoCopaMundo2010Jogo(_currentLogin, false, nomeCampeonato,
                            new DateTime(2010, 06, 24, 11, 0, 0), "Polokwane", "Paraguai", "Nova Zelândia",
                            "Classificatória", "F", 3, "");

            //--------------------- G -----------------------


            InsertCampeonatoCopaMundo2010Jogo(_currentLogin, false, nomeCampeonato,
                            new DateTime(2010, 06, 15, 11, 0, 0), "Port Elizabeth", "Costa do Marfim", "Portugal",
                            "Classificatória", "G", 1, "");

            InsertCampeonatoCopaMundo2010Jogo(_currentLogin, false, nomeCampeonato,
                            new DateTime(2010, 06, 15, 15, 30, 0), "Johanesburgo", "Brasil", "Coreia do Norte",
                            "Classificatória", "G", 1, "");

            InsertCampeonatoCopaMundo2010Jogo(_currentLogin, false, nomeCampeonato,
                            new DateTime(2010, 06, 20, 15, 30, 0), "Johanesburgo", "Brasil", "Costa do Marfim",
                            "Classificatória", "G", 2, "");

            InsertCampeonatoCopaMundo2010Jogo(_currentLogin, false, nomeCampeonato,
                            new DateTime(2010, 06, 21, 8, 30, 0), "Cidade do Cabo", "Portugal", "Coreia do Norte",
                            "Classificatória", "G", 2, "");

            InsertCampeonatoCopaMundo2010Jogo(_currentLogin, false, nomeCampeonato,
                            new DateTime(2010, 06, 25, 11, 0, 0), "Durban", "Portugal", "Brasil",
                            "Classificatória", "G", 3, "");

            InsertCampeonatoCopaMundo2010Jogo(_currentLogin, false, nomeCampeonato,
                            new DateTime(2010, 06, 25, 11, 0, 0), "Nelspruit", "Coreia do Norte", "Costa do Marfim",
                            "Classificatória", "G", 3, "");

            //--------------------- H -----------------------


            InsertCampeonatoCopaMundo2010Jogo(_currentLogin, false, nomeCampeonato,
                            new DateTime(2010, 06, 16, 8, 30, 0), "Nelspruit", "Honduras", "Chile",
                            "Classificatória", "H", 1, "");

            InsertCampeonatoCopaMundo2010Jogo(_currentLogin, false, nomeCampeonato,
                            new DateTime(2010, 06, 16, 11, 0, 0), "Durban", "Espanha", "Suíça",
                            "Classificatória", "H", 1, "");

            InsertCampeonatoCopaMundo2010Jogo(_currentLogin, false, nomeCampeonato,
                            new DateTime(2010, 06, 21, 11, 0, 0), "Port Elizabeth", "Chile", "Suíça",
                            "Classificatória", "H", 2, "");

            InsertCampeonatoCopaMundo2010Jogo(_currentLogin, false, nomeCampeonato,
                            new DateTime(2010, 06, 21, 15, 30, 0), "Johanesburgo", "Espanha", "Honduras",
                            "Classificatória", "H", 2, "");

            InsertCampeonatoCopaMundo2010Jogo(_currentLogin, false, nomeCampeonato,
                            new DateTime(2010, 06, 25, 15, 30, 0), "Pretória", "Chile", "Espanha",
                            "Classificatória", "H", 3, "");

            InsertCampeonatoCopaMundo2010Jogo(_currentLogin, false, nomeCampeonato,
                            new DateTime(2010, 06, 25, 15, 30, 0), "Bloemfontein", "Suíça", "Honduras",
                            "Classificatória", "H", 3, "");


        }
       
        

        #endregion
    }
}
