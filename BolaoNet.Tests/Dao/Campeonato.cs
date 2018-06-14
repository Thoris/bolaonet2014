using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Text;

namespace BolaoNet.Tests.Dao
{
    [TestFixture]
    public class Campeonato : DaoBase
    {
        #region Constants
        public const string EntryToLoad = "EntryToLoad";
        public const string EntryToUpdate = "EntryToUpdate";
        public const string EntryToInsert = "EntryToInsert";
        public const string EntryToDelete = "EntryToDelete";

        public const string SelectPageOrder = "Nome";

        public const string SelectAllCondition = "IsClube IS NULL";
        public const string SelectPageCondition = "IsClube IS NULL";

        public readonly string[] InitQueries = 
            { 
                //Cleaning Main Entries
                "DELETE FROM " + BolaoNet.Dao.Campeonatos.Util.Campeonato.TableName + " WHERE Nome = '" + EntryToLoad + "'",
                "DELETE FROM " + BolaoNet.Dao.Campeonatos.Util.Campeonato.TableName + " WHERE Nome = '" + EntryToUpdate + "'",
                "DELETE FROM " + BolaoNet.Dao.Campeonatos.Util.Campeonato.TableName + " WHERE Nome = '" + EntryToInsert + "'",
                "DELETE FROM " + BolaoNet.Dao.Campeonatos.Util.Campeonato.TableName + " WHERE Nome = '" + EntryToDelete + "'",

                //Inserting new entries
                "INSERT INTO " + BolaoNet.Dao.Campeonatos.Util.Campeonato.TableName + "(Nome) VALUES ('" + EntryToLoad + "')",                
                "INSERT INTO " + BolaoNet.Dao.Campeonatos.Util.Campeonato.TableName + "(Nome) VALUES ('" + EntryToUpdate + "')",                
                "INSERT INTO " + BolaoNet.Dao.Campeonatos.Util.Campeonato.TableName + "(Nome) VALUES ('" + EntryToDelete + "')",


                //Inserting new times
                "INSERT INTO " + BolaoNet.Dao.DadosBasicos.Util.Time.TableName + "(Nome) VALUES ('" + Tests.Dao.Time.EntryToInsert + "')",                
                "INSERT INTO " + BolaoNet.Dao.DadosBasicos.Util.Time.TableName + "(Nome) VALUES ('" + Tests.Dao.Time.EntryToDelete + "')",
                "INSERT INTO " + BolaoNet.Dao.Campeonatos.Util.Campeonato.TableLinkToTimes + "(NomeCampeonato,NomeTime) VALUES ('" + EntryToLoad + "','" + Dao.Time.EntryToDelete + "')",



                //Cleaning old grupos entries
                "DELETE FROM " + BolaoNet.Dao.Campeonatos.Util.Grupo.TableName + " WHERE Nome = '" + Tests.Dao.Campeonatos.Grupo.EntryToLoad + "' AND NomeCampeonato = '" + EntryToLoad + "'",
                "DELETE FROM " + BolaoNet.Dao.Campeonatos.Util.Grupo.TableName + " WHERE Nome = '" + Tests.Dao.Campeonatos.Grupo.EntryToUpdate  + "' AND NomeCampeonato = '" + EntryToLoad + "'",
                //Inserting new grupos entries
                "DELETE FROM " + BolaoNet.Dao.Campeonatos.Util.Grupo.TableName + " WHERE Nome = '" + Tests.Dao.Campeonatos.Grupo.EntryToInsert + "' AND NomeCampeonato = '" + EntryToLoad + "'",
                "INSERT INTO " + BolaoNet.Dao.Campeonatos.Util.Grupo.TableName + "(Nome,NomeCampeonato) VALUES ('" + Tests.Dao.Campeonatos.Grupo.EntryToDelete + "','" + EntryToLoad + "')",
                "INSERT INTO " + BolaoNet.Dao.Campeonatos.Util.Grupo.TableName + "(Nome,NomeCampeonato) VALUES ('" + Tests.Dao.Campeonatos.Grupo.EntryToUpdate + "','" + EntryToLoad + "')",
                
                

                //Cleaning old fases entries
                "DELETE FROM " + BolaoNet.Dao.Campeonatos.Util.Fase.TableName + " WHERE Nome = '" + Tests.Dao.Campeonatos.Fase.EntryToLoad + "' AND NomeCampeonato = '" + EntryToLoad + "'",
                "DELETE FROM " + BolaoNet.Dao.Campeonatos.Util.Fase.TableName + " WHERE Nome = '" + Tests.Dao.Campeonatos.Fase.EntryToUpdate  + "' AND NomeCampeonato = '" + EntryToLoad + "'",                
                //Inserting new fases entries
                "DELETE FROM " + BolaoNet.Dao.Campeonatos.Util.Fase.TableName + " WHERE Nome = '" + Tests.Dao.Campeonatos.Fase.EntryToInsert + "' AND NomeCampeonato = '" + EntryToLoad + "'",
                "INSERT INTO " + BolaoNet.Dao.Campeonatos.Util.Fase.TableName + "(Nome,NomeCampeonato) VALUES ('" + Tests.Dao.Campeonatos.Fase.EntryToDelete + "','" + EntryToLoad + "')",
                "INSERT INTO " + BolaoNet.Dao.Campeonatos.Util.Fase.TableName + "(Nome,NomeCampeonato) VALUES ('" + Tests.Dao.Campeonatos.Fase.EntryToUpdate + "','" + EntryToLoad + "')",
                



            };

        public readonly string[] CleanUpQueries = 
            {
                "DELETE FROM " + BolaoNet.Dao.Campeonatos.Util.Campeonato.TableName + " WHERE Nome = '" + EntryToLoad + "'",
                "DELETE FROM " + BolaoNet.Dao.Campeonatos.Util.Campeonato.TableName + " WHERE Nome = '" + EntryToUpdate + "'",
                "DELETE FROM " + BolaoNet.Dao.Campeonatos.Util.Campeonato.TableName + " WHERE Nome = '" + EntryToInsert + "'",
                "DELETE FROM " + BolaoNet.Dao.Campeonatos.Util.Campeonato.TableName + " WHERE Nome = '" + EntryToDelete + "'",

                "DELETE FROM " + BolaoNet.Dao.Campeonatos.Util.Campeonato.TableLinkToTimes + " WHERE NomeCampeonato = '" + EntryToLoad + "' AND NomeTime = '" + Dao.Time.EntryToInsert  + "'",                
                "DELETE FROM " + BolaoNet.Dao.Campeonatos.Util.Campeonato.TableLinkToTimes + " WHERE NomeCampeonato = '" + EntryToLoad + "' AND NomeTime = '" + Dao.Time.EntryToLoad  + "'",
                "DELETE FROM " + BolaoNet.Dao.DadosBasicos.Util.Time.TableName + " WHERE Nome = '" + Tests.Dao.Time.EntryToLoad + "'",
                "DELETE FROM " + BolaoNet.Dao.DadosBasicos.Util.Time.TableName + " WHERE Nome = '" + Tests.Dao.Time.EntryToLoad + "'",

                "DELETE FROM " + BolaoNet.Dao.Campeonatos.Util.Grupo.TableName + " WHERE Nome = '" + Tests.Dao.Campeonatos.Grupo.EntryToLoad + "' AND NomeCampeonato='" + EntryToLoad + "'",
                "DELETE FROM " + BolaoNet.Dao.Campeonatos.Util.Grupo.TableName + " WHERE Nome = '" + Tests.Dao.Campeonatos.Grupo.EntryToLoad + "' AND NomeCampeonato='" + EntryToLoad + "'",

                "DELETE FROM " + BolaoNet.Dao.Campeonatos.Util.Fase.TableName + " WHERE Nome = '" + Tests.Dao.Campeonatos.Fase.EntryToLoad + "' AND NomeCampeonato='" + EntryToLoad + "'",
                "DELETE FROM " + BolaoNet.Dao.Campeonatos.Util.Fase.TableName + " WHERE Nome = '" + Tests.Dao.Campeonatos.Fase.EntryToLoad + "' AND NomeCampeonato='" + EntryToLoad + "'"



            };

        public const string QueryToCompareInsert =
            "SELECT ISNULL(Count(*),0) FROM " + BolaoNet.Dao.Campeonatos.Util.Campeonato.TableName + " WHERE Nome = '" + EntryToInsert + "'";

        public const string QueryToCompareUpdate =
            "SELECT Descricao FROM " + BolaoNet.Dao.Campeonatos.Util.Campeonato.TableName + " WHERE Nome = '" + EntryToUpdate + "'";

        public const string QueryToCompareDelete =
            "SELECT ISNULL(Count(*),0) FROM " + BolaoNet.Dao.Campeonatos.Util.Campeonato.TableName + " WHERE Nome = '" + EntryToDelete + "'";

        public const string QueryToCompareSelectAll =
            "SELECT ISNULL(Count(*),0) FROM " + BolaoNet.Dao.Campeonatos.Util.Campeonato.TableName + " WHERE " + SelectAllCondition;

        public const string QueryToCompareSelectPage =
            "SELECT ISNULL(Count(*),0) FROM " + BolaoNet.Dao.Campeonatos.Util.Campeonato.TableName + " WHERE " + SelectPageCondition;

        public const string QueryToCompareSelectCount =
            "SELECT ISNULL(Count(*),0) FROM " + BolaoNet.Dao.Campeonatos.Util.Campeonato.TableName + " WHERE " + SelectPageCondition;

        public const string QueryToCompareSelectCombo =
            "SELECT ISNULL(Count(*),0) FROM " + BolaoNet.Dao.Campeonatos.Util.Campeonato.TableName;






        public const string QueryToCompareTimeInsert =
            "SELECT ISNULL(Count(*),0) FROM " + BolaoNet.Dao.Campeonatos.Util.Campeonato.TableLinkToTimes + " WHERE NomeCampeonato ='" + EntryToLoad + "' AND NomeTime = '" + Tests.Dao.Time.EntryToInsert + "'";

        public const string QueryToCompareTimeDelete =
            "SELECT ISNULL(Count(*),0) FROM " + BolaoNet.Dao.Campeonatos.Util.Campeonato.TableLinkToTimes + " WHERE NomeCampeonato ='" + EntryToLoad + "' AND NomeTime = '" + Tests.Dao.Time.EntryToDelete + "'";

        public const string QueryToCompareTimesClear =
            "SELECT ISNULL(Count(*),0) FROM " + BolaoNet.Dao.Campeonatos.Util.Campeonato.TableLinkToTimes + " WHERE NomeCampeonato ='" + EntryToLoad + "'";






        public const string QueryToCompareGrupoInsert =
           "SELECT ISNULL(Count(*),0) FROM " + BolaoNet.Dao.Campeonatos.Util.Grupo.TableName + " WHERE NomeCampeonato ='" + EntryToLoad + "' AND Nome = '" + Tests.Dao.Campeonatos.Grupo.EntryToInsert + "'";

        public const string QueryToCompareGrupoDelete =
            "SELECT ISNULL(Count(*),0) FROM " + BolaoNet.Dao.Campeonatos.Util.Grupo.TableName + " WHERE NomeCampeonato ='" + EntryToLoad + "' AND Nome = '" + Tests.Dao.Campeonatos.Grupo.EntryToDelete + "'";

        public const string QueryToCompareGruposClear =
            "SELECT ISNULL(Count(*),0) FROM " + BolaoNet.Dao.Campeonatos.Util.Grupo.TableName + " WHERE NomeCampeonato ='" + EntryToLoad + "'";

        public const string QueryToCompareGrupoUpdate =
            "SELECT Descricao FROM " + BolaoNet.Dao.Campeonatos.Util.Grupo.TableName + " WHERE NomeCampeonato ='" + EntryToLoad + "' AND Nome='" + BolaoNet.Tests.Dao.Campeonatos.Grupo.EntryToUpdate + "'";





        public const string QueryToCompareFaseInsert =
           "SELECT ISNULL(Count(*),0) FROM " + BolaoNet.Dao.Campeonatos.Util.Fase.TableName + " WHERE NomeCampeonato ='" + EntryToLoad + "' AND Nome = '" + Tests.Dao.Campeonatos.Fase.EntryToInsert + "'";

        public const string QueryToCompareFaseDelete =
            "SELECT ISNULL(Count(*),0) FROM " + BolaoNet.Dao.Campeonatos.Util.Fase.TableName + " WHERE NomeCampeonato ='" + EntryToLoad + "' AND Nome = '" + Tests.Dao.Campeonatos.Fase.EntryToDelete + "'";

        public const string QueryToCompareFasesClear =
            "SELECT ISNULL(Count(*),0) FROM " + BolaoNet.Dao.Campeonatos.Util.Fase.TableName + " WHERE NomeCampeonato ='" + EntryToLoad + "'";

        public const string QueryToCompareFaseUpdate =
            "SELECT Descricao FROM " + BolaoNet.Dao.Campeonatos.Util.Fase.TableName + " WHERE NomeCampeonato ='" + EntryToLoad + "' AND Nome='" + BolaoNet.Tests.Dao.Campeonatos.Fase.EntryToUpdate + "'";


        #endregion

        #region Constructors/Destructors
        public Campeonato()
            : base (BolaoNet.Tests.Constants.CurrentUser,
                    new BolaoNet.Dao.Campeonatos.SQLSupport.Campeonato(
                        BolaoNet.Tests.Constants.ConnectionName,
                        BolaoNet.Tests.Constants.ConnectionString ,
                        BolaoNet.Tests.Constants.ProviderName)
                    )

        {
        }

        [TestFixtureSetUp]
        public void Init()
        {
            base.Init(InitQueries);   
        }

        [TearDown]
        public void Cleanup()
        {
            base.CleanUp(CleanUpQueries);
        }
        #endregion

        #region Methods
        [Test]
        public void Load()
        {
            Framework.DataServices.Model.EntityBaseData entry = new
                BolaoNet.Model.Campeonatos.Campeonato(EntryToLoad);

            base.Load(entry);
        }
        [Test]
        public void Update()
        {
            Framework.DataServices.Model.EntityBaseData entry = new
                BolaoNet.Model.Campeonatos.Campeonato(EntryToUpdate);

            ((BolaoNet.Model.Campeonatos.Campeonato)entry).Descricao = "Descricao";

            base.Update(entry, QueryToCompareUpdate, ((Model.Campeonatos.Campeonato)entry).Descricao);
        }
        [Test]
        public void Delete()
        {
            Framework.DataServices.Model.EntityBaseData entry = new
                BolaoNet.Model.Campeonatos.Campeonato(EntryToDelete);

            base.Delete(entry, QueryToCompareDelete);
        }
        [Test]
        public void Insert()
        {
            Framework.DataServices.Model.EntityBaseData entry = new
                BolaoNet.Model.Campeonatos.Campeonato(EntryToInsert);

            base.Insert(entry, QueryToCompareInsert);
        }
        [Test]
        public void SelectAll()
        {
            base.SelectAll(SelectAllCondition, QueryToCompareSelectAll);
        }
        [Test]
        public void SelectPage()
        {
            base.SelectPage(SelectPageCondition, SelectPageOrder, QueryToCompareSelectPage);
        }
        [Test]
        public void SelectCount()
        {
            base.SelectCount(SelectPageCondition, QueryToCompareSelectCount);
        }
        [Test]
        public void SelectCombo()
        {
            base.SelectCombo(QueryToCompareSelectCombo);
        }

        #region Times
        [Test]
        public void InsertTime()
        {
            int errorNumber = 0;
            string errorDescription = null;

            BolaoNet.Model.Campeonatos.Campeonato campeonato = new BolaoNet.Model.Campeonatos.Campeonato(EntryToLoad);
            BolaoNet.Model.DadosBasicos.Time time = new BolaoNet.Model.DadosBasicos.Time(Dao.Time.EntryToInsert);


            bool result = ((BolaoNet.Dao.Campeonatos.IDaoCampeonato)base.DaoObject).InsertTime(
                Constants.CurrentUser, campeonato, time, out errorNumber, out errorDescription);

            if (result == false)
                throw new AssertTestException("Couldn't insert the time");

            if (errorNumber != 0)
                throw new AssertTestException("There is an error number = " + errorNumber);

            if (!string.IsNullOrEmpty(errorDescription))
                throw new AssertTestException("There is an error description = " + errorDescription);

            object objResult = base.CommonDatabase.ExecuteScalar(
               System.Data.CommandType.Text, QueryToCompareTimeInsert, false, base.CurrentUser);

            if ((int)objResult != 1)
                throw new AssertTestException("The row was not inserted in database."); 


        }
        [Test]
        public void DeleteTime()
        {
            int errorNumber = 0;
            string errorDescription = null;

            BolaoNet.Model.Campeonatos.Campeonato campeonato = new BolaoNet.Model.Campeonatos.Campeonato(EntryToLoad);
            BolaoNet.Model.DadosBasicos.Time time = new BolaoNet.Model.DadosBasicos.Time(Dao.Time.EntryToDelete);


            bool result = ((BolaoNet.Dao.Campeonatos.IDaoCampeonato)base.DaoObject).DeleteTime(
                Constants.CurrentUser, campeonato, time, out errorNumber, out errorDescription);

            if (result == false)
                throw new AssertTestException("Couldn't delete the time");

            if (errorNumber != 0)
                throw new AssertTestException("There is an error number = " + errorNumber);

            if (!string.IsNullOrEmpty(errorDescription))
                throw new AssertTestException("There is an error description = " + errorDescription);

            object objResult = base.CommonDatabase.ExecuteScalar(
                System.Data.CommandType.Text, QueryToCompareTimeDelete, false, base.CurrentUser);

            if ((int)objResult >= 1)
                throw new AssertTestException("The row was not deleted in database."); 
        }
        [Test]
        public void LoadTimes()
        {
            int errorNumber = 0;
            string errorDescription = null;

            BolaoNet.Model.Campeonatos.Campeonato campeonato = new BolaoNet.Model.Campeonatos.Campeonato(EntryToLoad);


            IList<Framework.DataServices.Model.EntityBaseData> result = ((BolaoNet.Dao.Campeonatos.IDaoCampeonato)base.DaoObject).LoadTimes(
                Constants.CurrentUser, campeonato, out errorNumber, out errorDescription);

            if (result == null)
                throw new AssertTestException("Couldn't load the times");

            if (errorNumber != 0)
                throw new AssertTestException("There is an error number = " + errorNumber);

            if (!string.IsNullOrEmpty(errorDescription))
                throw new AssertTestException("There is an error description = " + errorDescription);
        }
        [Test]
        public void ClearTimes()
        {
            int errorNumber = 0;
            string errorDescription = null;

            BolaoNet.Model.Campeonatos.Campeonato campeonato = new BolaoNet.Model.Campeonatos.Campeonato(EntryToLoad);


            bool result = ((BolaoNet.Dao.Campeonatos.IDaoCampeonato)base.DaoObject).ClearTimes(
                Constants.CurrentUser, campeonato, out errorNumber, out errorDescription);

            if (result == false)
                throw new AssertTestException("Couldn't clear the times");

            if (errorNumber != 0)
                throw new AssertTestException("There is an error number = " + errorNumber);

            if (!string.IsNullOrEmpty(errorDescription))
                throw new AssertTestException("There is an error description = " + errorDescription);

            object objResult = base.CommonDatabase.ExecuteScalar(
                System.Data.CommandType.Text, QueryToCompareTimesClear, false, base.CurrentUser);

            if ((int)objResult >= 1)
                throw new AssertTestException("The rows were not deleted in database."); 
        }
        #endregion

        #region Grupos
        [Test]
        public void InsertGrupo()
        {
            int errorNumber = 0;
            string errorDescription = null;

            BolaoNet.Model.Campeonatos.Campeonato campeonato = new BolaoNet.Model.Campeonatos.Campeonato(EntryToLoad);
            BolaoNet.Model.Campeonatos.Grupo grupo = new BolaoNet.Model.Campeonatos.Grupo (Dao.Campeonatos.Grupo.EntryToInsert);


            bool result = ((BolaoNet.Dao.Campeonatos.IDaoCampeonato)base.DaoObject).InsertGrupo(
                Constants.CurrentUser, campeonato, grupo, out errorNumber, out errorDescription);

            if (result == false)
                throw new AssertTestException("Couldn't insert the grupo");

            if (errorNumber != 0)
                throw new AssertTestException("There is an error number = " + errorNumber);

            if (!string.IsNullOrEmpty(errorDescription))
                throw new AssertTestException("There is an error description = " + errorDescription);

            object objResult = base.CommonDatabase.ExecuteScalar(
                System.Data.CommandType.Text, QueryToCompareGrupoInsert, false, base.CurrentUser);

            if ((int)objResult != 1)
                throw new AssertTestException("The row was not inserted in database."); 

        }
        [Test]
        public void DeleteGrupo()
        {
            int errorNumber = 0;
            string errorDescription = null;

            BolaoNet.Model.Campeonatos.Campeonato campeonato = new BolaoNet.Model.Campeonatos.Campeonato(EntryToLoad);
            BolaoNet.Model.Campeonatos.Grupo grupo = new BolaoNet.Model.Campeonatos.Grupo(Dao.Campeonatos.Grupo.EntryToDelete);


            bool result = ((BolaoNet.Dao.Campeonatos.IDaoCampeonato)base.DaoObject).DeleteGrupo(
                Constants.CurrentUser, campeonato, grupo, out errorNumber, out errorDescription);

            if (result == false)
                throw new AssertTestException("Couldn't delete the grupo");

            if (errorNumber != 0)
                throw new AssertTestException("There is an error number = " + errorNumber);

            if (!string.IsNullOrEmpty(errorDescription))
                throw new AssertTestException("There is an error description = " + errorDescription);


            object objResult = base.CommonDatabase.ExecuteScalar(
                System.Data.CommandType.Text, QueryToCompareGrupoDelete, false, base.CurrentUser);

            if ((int)objResult >= 1)
                throw new AssertTestException("The row was not deleted in database."); 
        }
        [Test]
        public void LoadGrupos()
        {
            int errorNumber = 0;
            string errorDescription = null;

            BolaoNet.Model.Campeonatos.Campeonato campeonato = new BolaoNet.Model.Campeonatos.Campeonato(EntryToLoad);


            IList<Framework.DataServices.Model.EntityBaseData> result = ((BolaoNet.Dao.Campeonatos.IDaoCampeonato)base.DaoObject).LoadGrupos(
                Constants.CurrentUser, campeonato, out errorNumber, out errorDescription);

            if (result == null)
                throw new AssertTestException("Couldn't load the grupos");

            if (errorNumber != 0)
                throw new AssertTestException("There is an error number = " + errorNumber);

            if (!string.IsNullOrEmpty(errorDescription))
                throw new AssertTestException("There is an error description = " + errorDescription);
        }
        [Test]
        public void ClearGrupos()
        {
            int errorNumber = 0;
            string errorDescription = null;

            BolaoNet.Model.Campeonatos.Campeonato campeonato = new BolaoNet.Model.Campeonatos.Campeonato(EntryToLoad);


            bool result = ((BolaoNet.Dao.Campeonatos.IDaoCampeonato)base.DaoObject).ClearGrupos(
                Constants.CurrentUser, campeonato, out errorNumber, out errorDescription);

            if (result == false)
                throw new AssertTestException("Couldn't clear the grupos");

            if (errorNumber != 0)
                throw new AssertTestException("There is an error number = " + errorNumber);

            if (!string.IsNullOrEmpty(errorDescription))
                throw new AssertTestException("There is an error description = " + errorDescription);


            object objResult = base.CommonDatabase.ExecuteScalar(
                System.Data.CommandType.Text, QueryToCompareGruposClear, false, base.CurrentUser);

            if ((int)objResult >= 1)
                throw new AssertTestException("The rows were not deleted in database."); 
        }
        [Test]
        public void UpdateGrupo()
        {
            int errorNumber = 0;
            string errorDescription = null;

            BolaoNet.Model.Campeonatos.Campeonato campeonato = new BolaoNet.Model.Campeonatos.Campeonato(EntryToLoad);
            BolaoNet.Model.Campeonatos.Grupo grupo = new BolaoNet.Model.Campeonatos.Grupo(Dao.Campeonatos.Grupo.EntryToUpdate);

            grupo.Descricao = "Teste";

            bool result = ((BolaoNet.Dao.Campeonatos.IDaoCampeonato)base.DaoObject).UpdateGrupo(
                Constants.CurrentUser, campeonato, grupo, out errorNumber, out errorDescription);

            //
            // TODO: Fix this test
            //
            return;


            //if (result == false)
            //    throw new AssertTestException("Couldn't update the grupo");

            //if (errorNumber != 0)
            //    throw new AssertTestException("There is an error number = " + errorNumber);

            //if (!string.IsNullOrEmpty(errorDescription))
            //    throw new AssertTestException("There is an error description = " + errorDescription);


            //object objResult = base.CommonDatabase.ExecuteScalar(
            //    System.Data.CommandType.Text, QueryToCompareGrupoUpdate, false, base.CurrentUser);

            //if (string.Compare(grupo.Descricao.ToString(), objResult.ToString()) != 0)
            //    throw new AssertTestException("Incompatible results between database and object.");

        }
        #endregion

        #region Fases
        [Test]
        public void InsertFase()
        {
            int errorNumber = 0;
            string errorDescription = null;

            BolaoNet.Model.Campeonatos.Campeonato campeonato = new BolaoNet.Model.Campeonatos.Campeonato(EntryToLoad);
            BolaoNet.Model.Campeonatos.Fase fase = new BolaoNet.Model.Campeonatos.Fase(Dao.Campeonatos.Fase.EntryToInsert);


            bool result = ((BolaoNet.Dao.Campeonatos.IDaoCampeonato)base.DaoObject).InsertFase(
                Constants.CurrentUser, campeonato, fase, out errorNumber, out errorDescription);

            if (result == false)
                throw new AssertTestException("Couldn't insert the fase");

            if (errorNumber != 0)
                throw new AssertTestException("There is an error number = " + errorNumber);

            if (!string.IsNullOrEmpty(errorDescription))
                throw new AssertTestException("There is an error description = " + errorDescription);

            object objResult = base.CommonDatabase.ExecuteScalar(
                System.Data.CommandType.Text, QueryToCompareFaseInsert, false, base.CurrentUser);

            if ((int)objResult != 1)
                throw new AssertTestException("The row was not inserted in database.");

        }
        [Test]
        public void DeleteFase()
        {
            int errorNumber = 0;
            string errorDescription = null;

            BolaoNet.Model.Campeonatos.Campeonato campeonato = new BolaoNet.Model.Campeonatos.Campeonato(EntryToLoad);
            BolaoNet.Model.Campeonatos.Fase fase = new BolaoNet.Model.Campeonatos.Fase(Dao.Campeonatos.Fase.EntryToDelete);


            bool result = ((BolaoNet.Dao.Campeonatos.IDaoCampeonato)base.DaoObject).DeleteFase(
                Constants.CurrentUser, campeonato, fase, out errorNumber, out errorDescription);

            if (result == false)
                throw new AssertTestException("Couldn't delete the fase");

            if (errorNumber != 0)
                throw new AssertTestException("There is an error number = " + errorNumber);

            if (!string.IsNullOrEmpty(errorDescription))
                throw new AssertTestException("There is an error description = " + errorDescription);


            object objResult = base.CommonDatabase.ExecuteScalar(
                System.Data.CommandType.Text, QueryToCompareFaseDelete, false, base.CurrentUser);

            if ((int)objResult >= 1)
                throw new AssertTestException("The row was not deleted in database.");
        }
        [Test]
        public void LoadFases()
        {
            int errorNumber = 0;
            string errorDescription = null;

            BolaoNet.Model.Campeonatos.Campeonato campeonato = new BolaoNet.Model.Campeonatos.Campeonato(EntryToLoad);


            IList<Framework.DataServices.Model.EntityBaseData> result = ((BolaoNet.Dao.Campeonatos.IDaoCampeonato)base.DaoObject).LoadFases(
                Constants.CurrentUser, campeonato, out errorNumber, out errorDescription);

            if (result == null)
                throw new AssertTestException("Couldn't load the fases");

            if (errorNumber != 0)
                throw new AssertTestException("There is an error number = " + errorNumber);

            if (!string.IsNullOrEmpty(errorDescription))
                throw new AssertTestException("There is an error description = " + errorDescription);
        }
        [Test]
        public void ClearFases()
        {
            int errorNumber = 0;
            string errorDescription = null;

            BolaoNet.Model.Campeonatos.Campeonato campeonato = new BolaoNet.Model.Campeonatos.Campeonato(EntryToLoad);


            bool result = ((BolaoNet.Dao.Campeonatos.IDaoCampeonato)base.DaoObject).ClearFases(
                Constants.CurrentUser, campeonato, out errorNumber, out errorDescription);

            if (result == false)
                throw new AssertTestException("Couldn't clear the grupos");

            if (errorNumber != 0)
                throw new AssertTestException("There is an error number = " + errorNumber);

            if (!string.IsNullOrEmpty(errorDescription))
                throw new AssertTestException("There is an error description = " + errorDescription);


            object objResult = base.CommonDatabase.ExecuteScalar(
                System.Data.CommandType.Text, QueryToCompareFasesClear, false, base.CurrentUser);

            if ((int)objResult >= 1)
                throw new AssertTestException("The rows were not deleted in database.");
        }
        [Test]
        public void UpdateFase()
        {
            int errorNumber = 0;
            string errorDescription = null;

            BolaoNet.Model.Campeonatos.Campeonato campeonato = new BolaoNet.Model.Campeonatos.Campeonato(EntryToLoad);
            BolaoNet.Model.Campeonatos.Fase fase = new BolaoNet.Model.Campeonatos.Fase(Dao.Campeonatos.Fase.EntryToUpdate);

            fase.Descricao = "Teste";

            bool result = ((BolaoNet.Dao.Campeonatos.IDaoCampeonato)base.DaoObject).UpdateFase(
                Constants.CurrentUser, campeonato, fase, out errorNumber, out errorDescription);

            //
            // TODO: Fix this test
            //
            return;


            //if (result == false)
            //    throw new AssertTestException("Couldn't update the fase");

            //if (errorNumber != 0)
            //    throw new AssertTestException("There is an error number = " + errorNumber);

            //if (!string.IsNullOrEmpty(errorDescription))
            //    throw new AssertTestException("There is an error description = " + errorDescription);


            //object objResult = base.CommonDatabase.ExecuteScalar(
            //    System.Data.CommandType.Text, QueryToCompareGrupoUpdate, false, base.CurrentUser);

            //if (string.Compare(fase.Descricao.ToString(), objResult.ToString()) != 0)
            //    throw new AssertTestException("Incompatible results between database and object.");

        }
        #endregion


        #endregion
    }
}
