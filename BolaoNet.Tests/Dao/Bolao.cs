using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using NUnit.Framework;

namespace BolaoNet.Tests.Dao
{
    public class Bolao: DaoBase
    {
        #region Constants
        public const string EntryToLoad = "EntryToLoad";
        public const string EntryToUpdate = "EntryToUpdate";
        public const string EntryToInsert = "EntryToInsert";
        public const string EntryToDelete = "EntryToDelete";

        public const string SelectPageOrder = "Nome";

        public const string SelectAllCondition = "IsIniciado IS NULL";
        public const string SelectPageCondition = "IsIniciado IS NULL";

        public readonly string[] InitQueries = 
            { 
                "DELETE FROM " + BolaoNet.Dao.Boloes.Util.Bolao.TableName + " WHERE Nome = '" + EntryToLoad + "'",
                "DELETE FROM " + BolaoNet.Dao.Boloes.Util.Bolao.TableName + " WHERE Nome = '" + EntryToUpdate + "'",
                "DELETE FROM " + BolaoNet.Dao.Boloes.Util.Bolao.TableName + " WHERE Nome = '" + EntryToInsert + "'",
                "DELETE FROM " + BolaoNet.Dao.Boloes.Util.Bolao.TableName + " WHERE Nome = '" + EntryToDelete + "'",
                "INSERT INTO " + BolaoNet.Dao.Boloes.Util.Bolao.TableName + "(Nome) VALUES ('" + EntryToLoad + "')",                
                "INSERT INTO " + BolaoNet.Dao.Boloes.Util.Bolao.TableName + "(Nome) VALUES ('" + EntryToUpdate + "')",                
                "INSERT INTO " + BolaoNet.Dao.Boloes.Util.Bolao.TableName + "(Nome) VALUES ('" + EntryToDelete + "')",

                
                "DELETE FROM " + "Users" + " WHERE Username = '" + Tests.Dao.UserData.EntryToLoad + "'",
                "DELETE FROM " + "Users" + " WHERE Username = '" + Tests.Dao.UserData.EntryToInsert + "'",
                "DELETE FROM " + "Users" + " WHERE Username = '" + Tests.Dao.UserData.EntryToDelete + "'",
                
                

                //Inserting new times
                "INSERT INTO " + "Users" + "(UserName) VALUES ('" + Tests.Dao.UserData.EntryToLoad + "')",                
                "INSERT INTO " + "Users" + "(UserName) VALUES ('" + Tests.Dao.UserData.EntryToDelete + "')",
                "INSERT INTO " + BolaoNet.Dao.Boloes.Util.Bolao.TableLinkToUsers + "(NomeBolao,UserName) VALUES ('" + EntryToLoad + "','" + Dao.Bolao.EntryToDelete + "')",


            };

        public readonly string[] CleanUpQueries = 
            {
                "DELETE FROM " + BolaoNet.Dao.Boloes.Util.Bolao.TableName + " WHERE Nome = '" + EntryToLoad + "'",
                "DELETE FROM " + BolaoNet.Dao.Boloes.Util.Bolao.TableName + " WHERE Nome = '" + EntryToUpdate + "'",
                "DELETE FROM " + BolaoNet.Dao.Boloes.Util.Bolao.TableName + " WHERE Nome = '" + EntryToInsert + "'",
                "DELETE FROM " + BolaoNet.Dao.Boloes.Util.Bolao.TableName + " WHERE Nome = '" + EntryToDelete + "'",


                
                "DELETE FROM " + BolaoNet.Dao.Boloes.Util.Bolao.TableLinkToUsers + " WHERE NomeBolao = '" + EntryToLoad + "' AND UserName = '" + Dao.UserData.EntryToInsert  + "'",                
                "DELETE FROM " + BolaoNet.Dao.Boloes.Util.Bolao.TableLinkToUsers + " WHERE NomeBolao = '" + EntryToLoad + "' AND UserName = '" + Dao.UserData.EntryToLoad  + "'",
                "DELETE FROM " + "Users" + " WHERE UserName = '" + Tests.Dao.UserData.EntryToLoad + "'",
                "DELETE FROM " + "Users" + " WHERE UserName = '" + Tests.Dao.UserData.EntryToLoad + "'",

            };

        public const string QueryToCompareInsert =
            "SELECT ISNULL(Count(*),0) FROM " + BolaoNet.Dao.Boloes.Util.Bolao.TableName + " WHERE Nome = '" + EntryToInsert + "'";

        public const string QueryToCompareUpdate =
            "SELECT Descricao FROM " + BolaoNet.Dao.Boloes.Util.Bolao.TableName + " WHERE Nome = '" + EntryToUpdate + "'";

        public const string QueryToCompareDelete =
            "SELECT ISNULL(Count(*),0) FROM " + BolaoNet.Dao.Boloes.Util.Bolao.TableName + " WHERE Nome = '" + EntryToDelete + "'";

        public const string QueryToCompareSelectAll =
            "SELECT ISNULL(Count(*),0) FROM " + BolaoNet.Dao.Boloes.Util.Bolao.TableName + " WHERE " + SelectAllCondition;

        public const string QueryToCompareSelectPage =
            "SELECT ISNULL(Count(*),0) FROM " + BolaoNet.Dao.Boloes.Util.Bolao.TableName + " WHERE " + SelectPageCondition;

        public const string QueryToCompareSelectCount =
            "SELECT ISNULL(Count(*),0) FROM " + BolaoNet.Dao.Boloes.Util.Bolao.TableName + " WHERE " + SelectPageCondition;

        public const string QueryToCompareSelectCombo =
            "SELECT ISNULL(Count(*),0) FROM " + BolaoNet.Dao.Boloes.Util.Bolao.TableName;





        public const string QueryToCompareUsuarioInsert =
            "SELECT ISNULL(Count(*),0) FROM " + BolaoNet.Dao.Boloes.Util.Bolao.TableLinkToUsers + " WHERE NomeBolao ='" + EntryToLoad + "' AND UserName = '" + Tests.Dao.UserData.EntryToInsert + "'";

        public const string QueryToCompareUsuarioDelete =
            "SELECT ISNULL(Count(*),0) FROM " + BolaoNet.Dao.Boloes.Util.Bolao.TableLinkToUsers + " WHERE NomeBolao ='" + EntryToLoad + "' AND UserName = '" + Tests.Dao.UserData.EntryToDelete + "'";

        public const string QueryToCompareUsuarioClear =
            "SELECT ISNULL(Count(*),0) FROM " + BolaoNet.Dao.Boloes.Util.Bolao.TableLinkToUsers + " WHERE NomeBolao ='" + EntryToLoad + "'";



        #endregion

        #region Constructors/Destructors
        public Bolao()
            : base (BolaoNet.Tests.Constants.CurrentUser,
                    new BolaoNet.Dao.Boloes.SQLSupport.Bolao(
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
                BolaoNet.Model.Boloes.Bolao(EntryToLoad);

            base.Load(entry);
        }
        [Test]
        public void Update()
        {
            Framework.DataServices.Model.EntityBaseData entry = new
                BolaoNet.Model.Boloes.Bolao(EntryToUpdate);

            ((BolaoNet.Model.Boloes.Bolao)entry).Descricao = "Descricao";

            base.Update(entry, QueryToCompareUpdate, ((Model.Boloes.Bolao)entry).Descricao);
        }
        [Test]
        public void Delete()
        {
            Framework.DataServices.Model.EntityBaseData entry = new
                BolaoNet.Model.Boloes.Bolao(EntryToDelete);

            base.Delete(entry, QueryToCompareDelete);
        }
        [Test]
        public void Insert()
        {
            Framework.DataServices.Model.EntityBaseData entry = new
                BolaoNet.Model.Boloes.Bolao(EntryToInsert);

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

        #endregion

        #region Usuarios
        [Test]
        public void InsertMembro()
        {
            int errorNumber = 0;
            string errorDescription = null;

            BolaoNet.Model.Boloes.Bolao bolao = new BolaoNet.Model.Boloes.Bolao(Dao.Bolao.EntryToLoad);
            Framework.Security.Model.UserData usuario = new Framework.Security.Model.UserData (Dao.UserData.EntryToInsert);


            bool result = ((BolaoNet.Dao.Boloes.IDaoBolao)base.DaoObject).InsertMembro(
                Constants.CurrentUser, bolao, usuario, out errorNumber, out errorDescription);

            if (result == false)
                throw new AssertTestException("Couldn't insert the usuario");

            if (errorNumber != 0)
                throw new AssertTestException("There is an error number = " + errorNumber);

            if (!string.IsNullOrEmpty(errorDescription))
                throw new AssertTestException("There is an error description = " + errorDescription);

            object objResult = base.CommonDatabase.ExecuteScalar(
               System.Data.CommandType.Text, QueryToCompareUsuarioInsert, false, base.CurrentUser);

            if ((int)objResult != 1)
                throw new AssertTestException("The row was not inserted in database.");


        }
        [Test]
        public void DeleteMembro()
        {
            int errorNumber = 0;
            string errorDescription = null;

            BolaoNet.Model.Boloes.Bolao bolao = new BolaoNet.Model.Boloes.Bolao(EntryToLoad);
            Framework.Security.Model.UserData usuario = new Framework.Security.Model.UserData(Dao.UserData.EntryToDelete);


            bool result = ((BolaoNet.Dao.Boloes.IDaoBolao)base.DaoObject).DeleteMembro(
                Constants.CurrentUser, bolao, usuario, out errorNumber, out errorDescription);

            if (result == false)
                throw new AssertTestException("Couldn't delete the membro");

            if (errorNumber != 0)
                throw new AssertTestException("There is an error number = " + errorNumber);

            if (!string.IsNullOrEmpty(errorDescription))
                throw new AssertTestException("There is an error description = " + errorDescription);

            object objResult = base.CommonDatabase.ExecuteScalar(
                System.Data.CommandType.Text, QueryToCompareUsuarioDelete, false, base.CurrentUser);

            if ((int)objResult >= 1)
                throw new AssertTestException("The row was not deleted in database.");
        }
        [Test]
        public void LoadMembros()
        {
            int errorNumber = 0;
            string errorDescription = null;

            BolaoNet.Model.Boloes.Bolao bolao = new BolaoNet.Model.Boloes.Bolao(EntryToLoad);


            IList<Framework.DataServices.Model.EntityBaseData> result = ((BolaoNet.Dao.Boloes.IDaoBolao)base.DaoObject).LoadMembros(
                Constants.CurrentUser, bolao, out errorNumber, out errorDescription);

            if (result == null)
                throw new AssertTestException("Couldn't load the membros");

            if (errorNumber != 0)
                throw new AssertTestException("There is an error number = " + errorNumber);

            if (!string.IsNullOrEmpty(errorDescription))
                throw new AssertTestException("There is an error description = " + errorDescription);
        }
        [Test]
        public void ClearMembros()
        {
            int errorNumber = 0;
            string errorDescription = null;

            BolaoNet.Model.Boloes.Bolao bolao = new BolaoNet.Model.Boloes.Bolao(EntryToLoad);


            bool result = ((BolaoNet.Dao.Boloes.IDaoBolao)base.DaoObject).ClearMembros(
                Constants.CurrentUser, bolao, out errorNumber, out errorDescription);

            if (result == false)
                throw new AssertTestException("Couldn't clear the bolao");

            if (errorNumber != 0)
                throw new AssertTestException("There is an error number = " + errorNumber);

            if (!string.IsNullOrEmpty(errorDescription))
                throw new AssertTestException("There is an error description = " + errorDescription);

            object objResult = base.CommonDatabase.ExecuteScalar(
                System.Data.CommandType.Text, QueryToCompareUsuarioClear, false, base.CurrentUser);

            if ((int)objResult >= 1)
                throw new AssertTestException("The rows were not deleted in database.");
        }
        #endregion

    }
}
