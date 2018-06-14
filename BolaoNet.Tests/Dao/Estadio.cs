using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Text;

namespace BolaoNet.Tests.Dao
{
    [TestFixture]
    public class Estadio: DaoBase
    {
        #region Constants
        public const string EntryToLoad = "EntryToLoad";
        public const string EntryToUpdate = "EntryToUpdate";
        public const string EntryToInsert = "EntryToInsert";
        public const string EntryToDelete = "EntryToDelete";

        public const string SelectPageOrder = "Nome";

        public const string SelectAllCondition = "Descricao IS NULL";
        public const string SelectPageCondition = "Descricao IS NULL";

        public readonly string[] InitQueries = 
            { 
                "DELETE FROM " + BolaoNet.Dao.DadosBasicos.Util.Estadio.TableName + " WHERE Nome = '" + EntryToLoad + "'",
                "DELETE FROM " + BolaoNet.Dao.DadosBasicos.Util.Estadio.TableName + " WHERE Nome = '" + EntryToUpdate + "'",
                "DELETE FROM " + BolaoNet.Dao.DadosBasicos.Util.Estadio.TableName + " WHERE Nome = '" + EntryToInsert + "'",
                "DELETE FROM " + BolaoNet.Dao.DadosBasicos.Util.Estadio.TableName + " WHERE Nome = '" + EntryToDelete + "'",
                "INSERT INTO " + BolaoNet.Dao.DadosBasicos.Util.Estadio.TableName + "(Nome) VALUES ('" + EntryToLoad + "')",                
                "INSERT INTO " + BolaoNet.Dao.DadosBasicos.Util.Estadio.TableName + "(Nome) VALUES ('" + EntryToUpdate + "')",                
                "INSERT INTO " + BolaoNet.Dao.DadosBasicos.Util.Estadio.TableName + "(Nome) VALUES ('" + EntryToDelete + "')"
            };

        public readonly string[] CleanUpQueries = 
            {
                "DELETE FROM " + BolaoNet.Dao.DadosBasicos.Util.Estadio.TableName + " WHERE Nome = '" + EntryToLoad + "'",
                "DELETE FROM " + BolaoNet.Dao.DadosBasicos.Util.Estadio.TableName + " WHERE Nome = '" + EntryToUpdate + "'",
                "DELETE FROM " + BolaoNet.Dao.DadosBasicos.Util.Estadio.TableName + " WHERE Nome = '" + EntryToInsert + "'",
                "DELETE FROM " + BolaoNet.Dao.DadosBasicos.Util.Estadio.TableName + " WHERE Nome = '" + EntryToDelete + "'"
            };

        public const string QueryToCompareInsert =
            "SELECT ISNULL(Count(*),0) FROM " + BolaoNet.Dao.DadosBasicos.Util.Estadio.TableName + " WHERE Nome = '" + EntryToInsert + "'";

        public const string QueryToCompareUpdate =
            "SELECT Descricao FROM " + BolaoNet.Dao.DadosBasicos.Util.Estadio.TableName + " WHERE Nome = '" + EntryToUpdate + "'";

        public const string QueryToCompareDelete =
            "SELECT ISNULL(Count(*),0) FROM " + BolaoNet.Dao.DadosBasicos.Util.Estadio.TableName + " WHERE Nome = '" + EntryToDelete + "'";

        public const string QueryToCompareSelectAll =
            "SELECT ISNULL(Count(*),0) FROM " + BolaoNet.Dao.DadosBasicos.Util.Estadio.TableName + " WHERE " + SelectAllCondition;

        public const string QueryToCompareSelectPage =
            "SELECT ISNULL(Count(*),0) FROM " + BolaoNet.Dao.DadosBasicos.Util.Estadio.TableName + " WHERE " + SelectPageCondition;

        public const string QueryToCompareSelectCount =
            "SELECT ISNULL(Count(*),0) FROM " + BolaoNet.Dao.DadosBasicos.Util.Estadio.TableName + " WHERE " + SelectPageCondition;

        public const string QueryToCompareSelectCombo =
            "SELECT ISNULL(Count(*),0) FROM " + BolaoNet.Dao.DadosBasicos.Util.Estadio.TableName;

        #endregion

        #region Constructors/Destructors
        public Estadio()
            : base (BolaoNet.Tests.Constants.CurrentUser,
                    new BolaoNet.Dao.DadosBasicos.SQLSupport.Estadio(
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
                BolaoNet.Model.DadosBasicos.Estadio(EntryToLoad);

            base.Load(entry);
        }
        [Test]
        public void Update()
        {
            Framework.DataServices.Model.EntityBaseData entry = new
                BolaoNet.Model.DadosBasicos.Estadio(EntryToUpdate);

            ((BolaoNet.Model.DadosBasicos.Estadio)entry).Descricao = "Descricao";

            base.Update(entry, QueryToCompareUpdate, ((Model.DadosBasicos.Estadio)entry).Descricao);
        }
        [Test]
        public void Delete()
        {
            Framework.DataServices.Model.EntityBaseData entry = new
                BolaoNet.Model.DadosBasicos.Estadio(EntryToDelete);

            base.Delete(entry, QueryToCompareDelete);
        }
        [Test]
        public void Insert()
        {
            Framework.DataServices.Model.EntityBaseData entry = new
                BolaoNet.Model.DadosBasicos.Estadio(EntryToInsert);

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
    }
}
