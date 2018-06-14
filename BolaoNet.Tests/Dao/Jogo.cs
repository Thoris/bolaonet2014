using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using NUnit.Framework;

namespace BolaoNet.Tests.Dao
{
    public class Jogo : DaoBase
    {
        #region Constants
        //public const string EntryToLoad = "EntryToLoad";
        //public const string EntryToUpdate = "EntryToUpdate";
        //public const string EntryToInsert = "EntryToInsert";
        //public const string EntryToDelete = "EntryToDelete";

        public const string SelectPageOrder = "IdJogo";

        public const string SelectAllCondition = "Title IS NULL";
        public const string SelectPageCondition = "Title IS NULL";

        public readonly string[] InitQueries = 
            { 
                "DELETE FROM " + BolaoNet.Dao.Campeonatos.Util.Jogo.TableName + " WHERE NomeCampeonato = '" +  Tests.Dao.Campeonato.EntryToLoad + "'",
                "DELETE FROM " + BolaoNet.Dao.Campeonatos.Util.Campeonato.TableName + " WHERE Nome = '" +  Tests.Dao.Campeonato.EntryToLoad + "'",



                "INSERT INTO " + BolaoNet.Dao.Campeonatos.Util.Campeonato.TableName + "(Nome) VALUES ('" + Tests.Dao.Campeonato.EntryToLoad + "')",
                "INSERT INTO " + BolaoNet.Dao.Campeonatos.Util.Jogo.TableName + "(NomeCampeonato) VALUES ('" + Tests.Dao.Campeonato.EntryToLoad + "')",
                "INSERT INTO " + BolaoNet.Dao.Campeonatos.Util.Jogo.TableName + "(NomeCampeonato) VALUES ('" + Tests.Dao.Campeonato.EntryToLoad + "')",
                
                //"DELETE FROM " + BolaoNet.Dao.Time.TableName + " WHERE Nome = '" + EntryToLoad + "'",
                //"DELETE FROM " + BolaoNet.Dao.Time.TableName + " WHERE Nome = '" + EntryToUpdate + "'",
                //"DELETE FROM " + BolaoNet.Dao.Time.TableName + " WHERE Nome = '" + EntryToInsert + "'",
                //"DELETE FROM " + BolaoNet.Dao.Time.TableName + " WHERE Nome = '" + EntryToDelete + "'",
                //"INSERT INTO " + BolaoNet.Dao.Time.TableName + "(Nome) VALUES ('" + EntryToLoad + "')",                
                //"INSERT INTO " + BolaoNet.Dao.Time.TableName + "(Nome) VALUES ('" + EntryToUpdate + "')",                
                //"INSERT INTO " + BolaoNet.Dao.Time.TableName + "(Nome) VALUES ('" + EntryToDelete + "')"
            };

        public readonly string[] CleanUpQueries = 
            {
                "DELETE FROM " + BolaoNet.Dao.Campeonatos.Util.Jogo.TableName + " WHERE NomeCampeonato = '" +  Tests.Dao.Campeonato.EntryToLoad + "'",
                "DELETE FROM " + BolaoNet.Dao.Campeonatos.Util.Campeonato.TableName + " WHERE Nome = '" +  Tests.Dao.Campeonato.EntryToLoad + "'",


                //"DELETE FROM " + BolaoNet.Dao.Time.TableName + " WHERE Nome = '" + EntryToLoad + "'",
                //"DELETE FROM " + BolaoNet.Dao.Time.TableName + " WHERE Nome = '" + EntryToUpdate + "'",
                //"DELETE FROM " + BolaoNet.Dao.Time.TableName + " WHERE Nome = '" + EntryToInsert + "'",
                //"DELETE FROM " + BolaoNet.Dao.Time.TableName + " WHERE Nome = '" + EntryToDelete + "'"
            };

        public const string QueryToGetTheLastID =
            "SELECT ISNULL(Count(*),0) FROM " + BolaoNet.Dao.Campeonatos.Util.Jogo.TableName + " WHERE NomeCampeonato = '" + Tests.Dao.Campeonato.EntryToLoad + "'";

        public const string QueryToCompareInsert =
            "SELECT ISNULL(Count(*),0) FROM " + BolaoNet.Dao.Campeonatos.Util.Jogo.TableName + " WHERE NomeCampeonato = '" + Tests.Dao.Campeonato.EntryToLoad + "' AND IDJogo = {0}";

        public const string QueryToCompareUpdate =
            "SELECT Titulo FROM " + BolaoNet.Dao.Campeonatos.Util.Jogo.TableName + " WHERE NomeCampeonato = '" + Tests.Dao.Campeonato.EntryToLoad + "' AND IDJogo = {0}";

        public const string QueryToCompareDelete =
            "SELECT ISNULL(Count(*),0) FROM " + BolaoNet.Dao.Campeonatos.Util.Jogo.TableName + " WHERE NomeCampeonato = '" + Tests.Dao.Campeonato.EntryToLoad + "' AND IDJogo = {0}";

        public const string QueryToCompareSelectAll =
            "SELECT ISNULL(Count(*),0) FROM " + BolaoNet.Dao.Campeonatos.Util.Jogo.TableName + " WHERE " + SelectAllCondition;

        public const string QueryToCompareSelectPage =
            "SELECT ISNULL(Count(*),0) FROM " + BolaoNet.Dao.Campeonatos.Util.Jogo.TableName + " WHERE " + SelectPageCondition;

        public const string QueryToCompareSelectCount =
            "SELECT ISNULL(Count(*),0) FROM " + BolaoNet.Dao.Campeonatos.Util.Jogo.TableName + " WHERE " + SelectPageCondition;

        public const string QueryToCompareSelectCombo =
            "SELECT ISNULL(Count(*),0) FROM " + BolaoNet.Dao.Campeonatos.Util.Jogo.TableName;

        #endregion

        #region Constructors/Destructors
        public Jogo()
            : base (BolaoNet.Tests.Constants.CurrentUser,
                    new BolaoNet.Dao.Campeonatos.SQLSupport.Jogo(
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
                BolaoNet.Model.Campeonatos.Jogo();

            object result = base.CommonDatabase.ExecuteScalar(
                CommandType.Text, QueryToGetTheLastID, false, Constants.CurrentUser);

            ((Model.Campeonatos.Jogo)entry).IDJogo = (int)result;
            ((Model.Campeonatos.Jogo)entry).Campeonato = new BolaoNet.Model.Campeonatos.Campeonato(Tests.Dao.Campeonato.EntryToLoad);
            

            base.Load(entry);
        }
        [Test]
        public void Update()
        {
            Framework.DataServices.Model.EntityBaseData entry = new
                BolaoNet.Model.Campeonatos.Jogo();

            object result = base.CommonDatabase.ExecuteScalar(
                CommandType.Text, QueryToGetTheLastID, false, Constants.CurrentUser);

            ((Model.Campeonatos.Jogo)entry).IDJogo = (int)result;
            ((Model.Campeonatos.Jogo)entry).Campeonato = new BolaoNet.Model.Campeonatos.Campeonato(Tests.Dao.Campeonato.EntryToLoad);


            ((BolaoNet.Model.Campeonatos.Jogo)entry).Titulo = "Descricao";

            base.Update(entry, string.Format(QueryToCompareUpdate, (int)result), ((Model.Campeonatos.Jogo)entry).Titulo);
        }
        [Test]
        public void Delete()
        {
            Framework.DataServices.Model.EntityBaseData entry = new
                BolaoNet.Model.Campeonatos.Jogo();

            object result = base.CommonDatabase.ExecuteScalar(
                CommandType.Text, QueryToGetTheLastID, false, Constants.CurrentUser);

            ((Model.Campeonatos.Jogo)entry).IDJogo = (int)result;
            ((Model.Campeonatos.Jogo)entry).Campeonato = new BolaoNet.Model.Campeonatos.Campeonato(Tests.Dao.Campeonato.EntryToLoad);
            

            base.Delete(entry, string.Format (QueryToCompareDelete, (int)result));
        }
        [Test]
        public void Insert()
        {
            Framework.DataServices.Model.EntityBaseData entry = new
                BolaoNet.Model.Campeonatos.Jogo();

            ((Model.Campeonatos.Jogo)entry).Campeonato = new BolaoNet.Model.Campeonatos.Campeonato(Tests.Dao.Campeonato.EntryToLoad);
            ((Model.Campeonatos.Jogo)entry).Titulo = "Test";

            object result = base.CommonDatabase.ExecuteScalar(
                CommandType.Text, QueryToGetTheLastID, false, Constants.CurrentUser);

            base.Insert(entry, string.Format(QueryToCompareInsert, (int)result));

            if (((Model.Campeonatos.Jogo)entry).IDJogo == 0)
                throw new AssertTestException("Didn't find the ID item");

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

        [Test]
        public void InsertResult()
        {
        }
        [Test]
        public void RemoveResult()
        {
        }
        #endregion
    }
}
