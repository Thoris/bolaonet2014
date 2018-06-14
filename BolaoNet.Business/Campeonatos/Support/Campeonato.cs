using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Business.Campeonatos.Support
{
    public class Campeonato : Model.Campeonatos.Campeonato, IBusinessCampeonato
    {
        #region Variables
        
        private string _currentLogin = null;
        private BolaoNet.Dao.Campeonatos.IDaoCampeonato _daoBase = null;

        #endregion

        #region Constructors/Destructors
        public Campeonato(string currentLogin, BolaoNet.Dao.Campeonatos.IDaoCampeonato daoBase)
        {
            if (daoBase == null)
                throw new ArgumentNullException("daoBase");

            _currentLogin = currentLogin;
            _daoBase = daoBase;

        }
        public Campeonato(string currentLogin, BolaoNet.Dao.Campeonatos.IDaoCampeonato daoBase, string nome)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentNullException("nome");

            if (daoBase == null)
                throw new ArgumentNullException("daoBase");

            _currentLogin = currentLogin;
            _daoBase = daoBase;
            base.Nome = nome;
        }
        public Campeonato(string currentLogin)
        {
            _currentLogin = currentLogin;
            _daoBase = new Dao.Campeonatos.SQLSupport.Campeonato();
        }
        public Campeonato(string currentLogin, string nome)
            : base (nome)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentNullException("nome");

            _currentLogin = currentLogin;
            _daoBase = new Dao.Campeonatos.SQLSupport.Campeonato();
        }
        public Campeonato(string currentLogin, BolaoNet.Dao.Campeonatos.IDaoCampeonato daoBase, Model.Campeonatos.Campeonato campeonato)
        {
            if (campeonato == null)
                throw new ArgumentNullException("campeonato");

            if (daoBase == null)
                throw new ArgumentNullException("daoBase");

            _currentLogin = currentLogin;
            _daoBase = daoBase;

            this.Copy(campeonato);
        }
        public Campeonato(string currentLogin, Model.Campeonatos.Campeonato campeonato)
        {
            if (campeonato == null)
                throw new ArgumentNullException("campeonato");

            _currentLogin = currentLogin;
            _daoBase = new Dao.Campeonatos.SQLSupport.Campeonato();

            this.Copy(campeonato);
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

            //Model.Campeonatos.Campeonato model = (Model.Campeonatos.Campeonato)result;

            if (result == null)
                return false;

            this.Copy(result);

            //Model.DadosBasicos.Time model = (Model.DadosBasicos.Time)result;

            //this.Nome = model.Nome;
            //this.ActiveFlag = model.ActiveFlag;
            //this.ModifiedBy = model.ModifiedBy;
            //this.ModifiedDate = model.ModifiedDate;
            //this.CreatedBy = model.CreatedBy;
            //this.CreatedDate = model.CreatedDate;
            //this.Descricao = model.Descricao;
            //this.IsClube = model.IsClube;
            

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

        #region Times

        public bool InsertTime(BolaoNet.Model.DadosBasicos.Time time)
        {
            int errorNumber = 0;
            string errorDescription = null;

            bool result = _daoBase.InsertTime(_currentLogin, this, time, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return false;

            if (_timesCollection != null)            
                _timesCollection.Add(time);
            

            return result;
        }

        public bool DeleteTime(BolaoNet.Model.DadosBasicos.Time time)
        {
            int errorNumber = 0;
            string errorDescription = null;

            bool result = _daoBase.DeleteTime(_currentLogin, this, time, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return false;

            if (_timesCollection != null)
            {
                for (int c=0; c< _timesCollection.Count; c++)
                {
                    if (string.Compare(((Model.DadosBasicos.Time)_timesCollection[c]).Nome, time.Nome, true) == 0)
                    {
                        _timesCollection.RemoveAt(c);
                        break;
                    }
                }
            }

            
            return result;
        }

        public IList<Framework.DataServices.Model.EntityBaseData> LoadTimes()
        {
            int errorNumber = 0;
            string errorDescription = null;

            IList<Framework.DataServices.Model.EntityBaseData> result = _daoBase.LoadTimes(
                _currentLogin, this, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return null;


            _timesCollection = new BolaoNet.Model.EntryCollection(result);

            return result;
        }

        public bool ClearTimes()
        {
            int errorNumber = 0;
            string errorDescription = null;

            bool result = _daoBase.ClearTimes (
                _currentLogin, this, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return false;

            if (_timesCollection != null)            
                _timesCollection.Clear();
            

            return result;
        }


        #endregion

        #region Grupos

        public bool InsertGrupo(BolaoNet.Model.Campeonatos.Grupo grupo)
        {
            int errorNumber = 0;
            string errorDescription = null;

            bool result = _daoBase.InsertGrupo(_currentLogin, this, grupo, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return false;

            if (_gruposCollection != null)
                _gruposCollection.Add(grupo);


            return result;
        }

        public bool DeleteGrupo(BolaoNet.Model.Campeonatos.Grupo grupo)
        {
            int errorNumber = 0;
            string errorDescription = null;

            bool result = _daoBase.DeleteGrupo(_currentLogin, this, grupo, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return false;

            if (_gruposCollection != null)
            {
                for (int c = 0; c < _gruposCollection.Count; c++)
                {
                    if (string.Compare(((Model.Campeonatos.Grupo)_gruposCollection[c]).Nome, grupo.Nome, true) == 0)
                    {
                        _gruposCollection.RemoveAt(c);
                        break;
                    }
                }
            }


            return result;
        }

        public IList<Framework.DataServices.Model.EntityBaseData> LoadGrupos()
        {
            int errorNumber = 0;
            string errorDescription = null;

            IList<Framework.DataServices.Model.EntityBaseData> result = _daoBase.LoadGrupos(
                _currentLogin, this, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return null;

            _gruposCollection = new BolaoNet.Model.EntryCollection(result);


            return result;
        }

        public bool ClearGrupos()
        {
            int errorNumber = 0;
            string errorDescription = null;

            bool result = _daoBase.ClearGrupos(
                _currentLogin, this, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return false;

            if (_gruposCollection != null)
                _gruposCollection.Clear();


            return result;
        }

        public bool UpdateGrupo(BolaoNet.Model.Campeonatos.Grupo grupo)
        {
            int errorNumber = 0;
            string errorDescription = null;

            bool result = _daoBase.UpdateGrupo (
                _currentLogin, this, grupo, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return false;

            if (_gruposCollection != null)
            {
                for (int c = 0; c < _gruposCollection.Count; c++)
                {
                    if (string.Compare(((Model.Campeonatos.Grupo)_gruposCollection[c]).Nome, grupo.Nome, true) == 0)
                    {
                        _gruposCollection[c] = grupo;
                        break;
                    }
                }
            }

            return result;
        }

        #endregion

        #region Fases

        public bool InsertFase(BolaoNet.Model.Campeonatos.Fase fase)
        {
            int errorNumber = 0;
            string errorDescription = null;

            bool result = _daoBase.InsertFase(_currentLogin, this, fase, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return false;

            if (_fasesCollection != null)
                _fasesCollection.Add(fase);


            return result;
        }

        public bool DeleteFase(BolaoNet.Model.Campeonatos.Fase fase)
        {
            int errorNumber = 0;
            string errorDescription = null;

            bool result = _daoBase.DeleteFase(_currentLogin, this, fase, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return false;

            if (_fasesCollection != null)
            {
                for (int c = 0; c < _fasesCollection.Count; c++)
                {
                    if (string.Compare(((Model.Campeonatos.Fase)_fasesCollection[c]).Nome, fase.Nome, true) == 0)
                    {
                        _fasesCollection.RemoveAt(c);
                        break;
                    }
                }
            }


            return result;
        }

        public IList<Framework.DataServices.Model.EntityBaseData> LoadFases()
        {
            int errorNumber = 0;
            string errorDescription = null;

            IList<Framework.DataServices.Model.EntityBaseData> result = _daoBase.LoadFases(
                _currentLogin, this, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return null;

            _fasesCollection = new BolaoNet.Model.EntryCollection(result);


            return result;
        }

        public bool ClearFases()
        {
            int errorNumber = 0;
            string errorDescription = null;

            bool result = _daoBase.ClearFases(
                _currentLogin, this, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return false;

            if (_fasesCollection != null)
                _fasesCollection.Clear();


            return result;
        }

        public bool UpdateFase(BolaoNet.Model.Campeonatos.Fase fase)
        {
            int errorNumber = 0;
            string errorDescription = null;

            bool result = _daoBase.UpdateFase(
                _currentLogin, this, fase, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return false;

            if (_fasesCollection != null)
            {
                for (int c = 0; c < _fasesCollection.Count; c++)
                {
                    if (string.Compare(((Model.Campeonatos.Fase)_fasesCollection[c]).Nome, fase.Nome, true) == 0)
                    {
                        _fasesCollection[c] = fase;
                        break;
                    }
                }
            }

            return result;
        }

        #endregion

        #endregion

        #region Jogos


        public IList<int> LoadRodadas()
        {
            int errorNumber = 0;
            string errorDescription = null;

            IList<int> list = _daoBase.LoadRodadas(
                _currentLogin, this, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return null;

            return list;

        }

        #endregion

        #region Classificacao Members


        public IList<BolaoNet.Model.Campeonatos.CampeonatoClassificacao> LoadClassificacao(BolaoNet.Model.Campeonatos.Fase fase, BolaoNet.Model.Campeonatos.Grupo grupo)
        {
            int errorNumber = 0;
            string errorDescription = null;

            IList<BolaoNet.Model.Campeonatos.CampeonatoClassificacao> result = _daoBase.LoadClassificacao(
                _currentLogin, this, fase, grupo, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return null;

            return result;
        }


        public IList<Framework.DataServices.Model.EntityBaseData> LoadJogos(int rodada, Model.Campeonatos.Fase fase, Model.Campeonatos.Grupo grupo, DateTime dataInicial, DateTime dataFinal, string condition)
        {
            int errorNumber = 0;
            string errorDescription = null;

            IList<Framework.DataServices.Model.EntityBaseData> result = _daoBase.LoadJogos(
                _currentLogin, rodada, fase, grupo, this, dataInicial, dataFinal, condition, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return null;

            return result;
        }

        #endregion

        #region IBusinessCampeonato Members


        public bool LoadCampeonato(bool isClube, string file)
        {
            if (!System.IO.File.Exists(file))
            {
                return false;
            }


            List<Model.Campeonatos.Jogo> list = new List<BolaoNet.Model.Campeonatos.Jogo>();


            string line;


            System.IO.StreamReader reader = new System.IO.StreamReader(file);

            while (reader.Peek() >= 0)
            {
                line = reader.ReadLine();

                if (!string.IsNullOrEmpty ( line))
                {
                    int posEndRodada = line.IndexOf('\t');

                    int posEndData = line.IndexOf('\t', posEndRodada + 1);

                    int posEndHora = line.IndexOf('\t', posEndData + 1);

                    int posEndTime1 = line.IndexOf('\t', posEndHora + 1);

                    int posStartTime2 = line.IndexOf('x', posEndTime1);

                    int posEndTime2 = line.IndexOf('\t', posStartTime2 + 2);


                    int rodada = Convert.ToInt32 (line.Substring(0, posEndRodada).Trim());

                    string data = line.Substring(posEndRodada + 1, 5);
                    string hora = line.Substring(posEndData + 1, 5);

                    DateTime DataJogo = Convert.ToDateTime(data + "/2010 " + hora);

                    string time1 = line.Substring(posEndHora + 1, posEndTime1 - posEndHora).Trim();
                    string time2 = line.Substring(posStartTime2 + 1).Trim();


                    Model.Campeonatos.Jogo jogo = new BolaoNet.Model.Campeonatos.Jogo();

                    jogo.Campeonato = this;
                    jogo.Campeonato.IsClube = isClube;
                    jogo.DataJogo = DataJogo;
                    jogo.Fase = new BolaoNet.Model.Campeonatos.Fase ("Primeira Fase");
                    jogo.Grupo = new BolaoNet.Model.Campeonatos.Grupo (" ");
                    jogo.Rodada = rodada;
                    jogo.Time1 = new BolaoNet.Model.DadosBasicos.Time(time1);
                    jogo.Time2 = new BolaoNet.Model.DadosBasicos.Time(time2);

                    list.Add(jogo);


                }//endif conteudo na linha

            }//end while



            foreach (Model.Campeonatos.Jogo jogo in list)
            {
                Business.Campeonatos.Support.Jogo business = new Jogo(_currentLogin);
                bool result = business.InsertWithAllData(isClube, jogo) ;
            }


            return true;
        }


        public IList<Framework.DataServices.Model.EntityBaseData> SelectPosicoes(BolaoNet.Model.Campeonatos.Fase fase, BolaoNet.Model.Campeonatos.Grupo grupo)
        {
            int errorNumber = 0;
            string errorDescription = null;

            IList<Framework.DataServices.Model.EntityBaseData> list = _daoBase.SelectPosicoes(
                _currentLogin, this, fase, grupo, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return null;

            return list;
        }

        #endregion

        #region IBusinessCampeonato Members

        public bool LoadRecordPlacar(Dao.Campeonatos.RecordTipoPesquisa tipo,out IList<Model.Campeonatos.CampeonatoRecord> general,out IList<Model.Campeonatos.CampeonatoRecord> dentro,out IList<Model.Campeonatos.CampeonatoRecord> fora)
        {

            int errorNumber = 0;
            string errorDescription = null;

            general = null;
            dentro = null;
            fora = null;

            bool result = _daoBase.LoadRecordPlacar(
                _currentLogin, this, tipo, out general, out dentro, out fora, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return false;

            return result;
        }
        public bool LoadRecordJogosGols(Model.Campeonatos.Campeonato entry, Model.DadosBasicos.Time time, bool getRecord, out Model.Campeonatos.CampeonatoRecord general, out Model.Campeonatos.CampeonatoRecord dentro, out Model.Campeonatos.CampeonatoRecord fora)
        {

            int errorNumber = 0;
            string errorDescription = null;

            general = null;
            dentro = null;
            fora = null;

            bool result = _daoBase.LoadRecordJogosGols(
                _currentLogin, this, time, getRecord,  out general, out dentro, out fora, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return false;

            return result;
        }       
        public IList<BolaoNet.Model.Campeonatos.Reports.GolsFrequencia> LoadGolsFrequencia(BolaoNet.Model.Campeonatos.Campeonato campeonato)
        {
            int errorNumber = 0;
            string errorDescription = null;

            

            IList<BolaoNet.Model.Campeonatos.Reports.GolsFrequencia> list = _daoBase.LoadGolsFrequencia(
                _currentLogin, campeonato, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return null;

            return list;
        }
        public IList<BolaoNet.Model.Campeonatos.Reports.TimeRodadas> LoadTimesRodadas(BolaoNet.Model.Campeonatos.Fase fase, BolaoNet.Model.Campeonatos.Grupo grupo, BolaoNet.Model.DadosBasicos.Time time)
        {

            int errorNumber = 0;
            string errorDescription = null;

            IList<BolaoNet.Model.Campeonatos.Reports.TimeRodadas> list = _daoBase.LoadTimesRodadas(
                _currentLogin, this, fase, grupo, time, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return null;

            return list;
        }
        public IList<Framework.DataServices.Model.EntityBaseData> LoadHistorico(string condition)
        {
            int errorNumber = 0;
            string errorDescription = null;

            IList<Framework.DataServices.Model.EntityBaseData> list = _daoBase.LoadHistorico(
                _currentLogin, this, condition, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return null;

            return list;

        }

        #endregion
    }
}
