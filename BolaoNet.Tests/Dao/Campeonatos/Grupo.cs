using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Text;

namespace BolaoNet.Tests.Dao.Campeonatos
{
    [TestFixture]
    public class Grupo : DaoBase 
    {
        #region Constants
        public const string EntryToLoad = "EntryToLoad";
        public const string EntryToUpdate = "EntryToUpdate";
        public const string EntryToInsert = "EntryToInsert";
        public const string EntryToDelete = "EntryToDelete";


        public readonly string[] InitQueries = 
            {   
 
                "INSERT INTO " + BolaoNet.Dao.Campeonatos.Util.Campeonato.TableName + "(Nome) VALUES ('" + BolaoNet.Tests.Dao.Campeonato.EntryToLoad + "')",                
                "INSERT INTO " + BolaoNet.Dao.DadosBasicos.Util.Time.TableName + "(Nome) VALUES ('" + BolaoNet.Tests.Dao.Time.EntryToLoad + "')",                
                



                "DELETE FROM " + BolaoNet.Dao.Campeonatos.Util.Campeonato.TableName + " WHERE Nome = '" + Tests.Dao.Campeonato.EntryToLoad + "'",
                "DELETE FROM " + BolaoNet.Dao.Campeonatos.Util.Campeonato.TableName + " WHERE Nome = '" + Tests.Dao.Campeonato.EntryToLoad + "'",
                
                


                "DELETE " + BolaoNet.Dao.Campeonatos.Util.Grupo.TableName + " WHERE Nome = '" + EntryToLoad + "'",
                "DELETE " + BolaoNet.Dao.Campeonatos.Util.Grupo.TableName + " WHERE Nome = '" + EntryToUpdate + "'",
                "DELETE " + BolaoNet.Dao.Campeonatos.Util.Grupo.TableName + " WHERE Nome = '" + EntryToInsert + "'",
                "DELETE " + BolaoNet.Dao.Campeonatos.Util.Grupo.TableName + " WHERE Nome = '" + EntryToDelete + "'",
                "INSERT INTO " + BolaoNet.Dao.Campeonatos.Util.Grupo.TableName + "(Nome) VALUES ('" + EntryToLoad + "')",                
                "INSERT INTO " + BolaoNet.Dao.Campeonatos.Util.Grupo.TableName + "(Nome) VALUES ('" + EntryToUpdate + "')",                
                "INSERT INTO " + BolaoNet.Dao.Campeonatos.Util.Grupo.TableName + "(Nome) VALUES ('" + EntryToDelete + "')"
            };

        public readonly string[] CleanUpQueries = 
            {
                "DELETE " + BolaoNet.Dao.Campeonatos.Util.Grupo.TableName + " WHERE Nome = '" + EntryToLoad + "'",
                "DELETE " + BolaoNet.Dao.Campeonatos.Util.Grupo.TableName + " WHERE Nome = '" + EntryToUpdate + "'",
                "DELETE " + BolaoNet.Dao.Campeonatos.Util.Grupo.TableName + " WHERE Nome = '" + EntryToInsert + "'",
                "DELETE " + BolaoNet.Dao.Campeonatos.Util.Grupo.TableName + " WHERE Nome = '" + EntryToDelete + "'",
            };



        public const string QueryToCompareTimeInsert =
            "SELECT ISNULL(Count(*),0) FROM " + BolaoNet.Dao.Campeonatos.Util.Campeonato.TableLinkToTimes + " WHERE NomeCampeonato ='" + EntryToLoad + "' AND NomeTime = '" + Tests.Dao.Time.EntryToInsert + "'";

        public const string QueryToCompareTimeDelete =
            "SELECT ISNULL(Count(*),0) FROM " + BolaoNet.Dao.Campeonatos.Util.Campeonato.TableLinkToTimes + " WHERE NomeCampeonato ='" + EntryToLoad + "' AND NomeTime = '" + Tests.Dao.Time.EntryToDelete + "'";

        public const string QueryToCompareTimesClear =
            "SELECT ISNULL(Count(*),0) FROM " + BolaoNet.Dao.Campeonatos.Util.Campeonato.TableLinkToTimes + " WHERE NomeCampeonato ='" + EntryToLoad + "'";


       

        #endregion

        #region Constructors/Destructors
        public Grupo()     
            : base (Constants.CurrentUser, 
                new System.Configuration.ConnectionStringSettings (
                    Constants.ConnectionName,
                    Constants.ConnectionString,
                    Constants.ProviderName)
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
        public void InsertTime()
        {
            int errorNumber = 0;
            string errorDescription = null;

            BolaoNet.Model.Campeonatos.Campeonato campeonato = new BolaoNet.Model.Campeonatos.Campeonato(EntryToLoad);
            BolaoNet.Model.Campeonatos.Grupo grupo = new BolaoNet.Model.Campeonatos.Grupo(BolaoNet.Tests.Dao.Campeonatos.Grupo.EntryToLoad);
            BolaoNet.Model.DadosBasicos.Time time = new BolaoNet.Model.DadosBasicos.Time(Dao.Time.EntryToInsert);


            bool result = ((BolaoNet.Dao.Campeonatos.IGrupo)base.DaoObject).InsertTime(
                Constants.CurrentUser, campeonato, grupo, time, out errorNumber, out errorDescription);

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
            BolaoNet.Model.Campeonatos.Grupo grupo = new BolaoNet.Model.Campeonatos.Grupo(BolaoNet.Tests.Dao.Campeonatos.Grupo.EntryToLoad);
            BolaoNet.Model.DadosBasicos.Time time = new BolaoNet.Model.DadosBasicos.Time(Dao.Time.EntryToDelete);


            bool result = ((BolaoNet.Dao.Campeonatos.IGrupo)base.DaoObject).DeleteTime(
                Constants.CurrentUser, campeonato, grupo, time, out errorNumber, out errorDescription);

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
            BolaoNet.Model.Campeonatos.Grupo grupo = new BolaoNet.Model.Campeonatos.Grupo(BolaoNet.Tests.Dao.Campeonatos.Grupo.EntryToLoad);


            IList<Framework.DataServices.Model.EntityBaseData> result = 
                ((BolaoNet.Dao.Campeonatos.IGrupo)base.DaoObject).LoadTimes(
                    Constants.CurrentUser, campeonato, grupo, out errorNumber, out errorDescription);

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
            BolaoNet.Model.Campeonatos.Grupo grupo = new BolaoNet.Model.Campeonatos.Grupo(BolaoNet.Tests.Dao.Campeonatos.Grupo.EntryToLoad);

            bool result = ((BolaoNet.Dao.Campeonatos.IGrupo)base.DaoObject).ClearTimes(
                Constants.CurrentUser, campeonato, grupo, out errorNumber, out errorDescription);

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
    }
}
