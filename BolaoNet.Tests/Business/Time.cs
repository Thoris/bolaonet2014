using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Text;

namespace BolaoNet.Tests.Business
{
    [TestFixture]
    public class Time : BusinessBase
    {

        #region Variables
        private BolaoNet.Dao.IDaoBase _daoBase = null;
        #endregion

        #region Constructors/Destructors
        public Time()
            : base (
                BolaoNet.Tests.Constants.CurrentUser,
                new System.Configuration.ConnectionStringSettings 
                    (                
                        BolaoNet.Tests.Constants.ConnectionName,
                        BolaoNet.Tests.Constants.ConnectionString ,
                        BolaoNet.Tests.Constants.ProviderName
                    )
                )
        
        {
            _daoBase = new BolaoNet.Dao.DadosBasicos.SQLSupport.Time
                    (
                        BolaoNet.Tests.Constants.ConnectionName,
                        BolaoNet.Tests.Constants.ConnectionString,
                        BolaoNet.Tests.Constants.ProviderName
                    );


        }
        [TestFixtureSetUp]
        public void Init()
        {
            BolaoNet.Tests.Dao.Time newItem = new BolaoNet.Tests.Dao.Time();
            base.Init(newItem.InitQueries);
        }

        [TearDown]
        public void Cleanup()
        {
            BolaoNet.Tests.Dao.Time newItem = new BolaoNet.Tests.Dao.Time();            
            base.CleanUp(newItem.CleanUpQueries);
        }
        #endregion

        #region Methods
        [Test]
        public void Load()
        {
            BolaoNet.Business.DadosBasicos.Support.Time entry = new BolaoNet.Business.DadosBasicos.Support.Time(
                Constants.CurrentUser, _daoBase, 
                BolaoNet.Tests.Dao.Time.EntryToLoad);

            base.Load(entry);
        }
        [Test]
        public void Update()
        {
            BolaoNet.Business.DadosBasicos.Support.Time entry = new BolaoNet.Business.DadosBasicos.Support.Time(
                Constants.CurrentUser, _daoBase,
                BolaoNet.Tests.Dao.Time.EntryToUpdate);

            entry.Descricao = "Testando";

            base.Update(entry, BolaoNet.Tests.Dao.Time.QueryToCompareUpdate);
        }
        [Test]
        public void Insert()
        {
            BolaoNet.Business.DadosBasicos.Support.Time entry = new BolaoNet.Business.DadosBasicos.Support.Time(
                Constants.CurrentUser, _daoBase,
                BolaoNet.Tests.Dao.Time.EntryToInsert);

            base.Insert(entry, BolaoNet.Tests.Dao.Time.QueryToCompareInsert);
        }
        [Test]
        public void Delete()
        {
            BolaoNet.Business.DadosBasicos.Support.Time entry = new BolaoNet.Business.DadosBasicos.Support.Time(
                Constants.CurrentUser, _daoBase,
                BolaoNet.Tests.Dao.Time.EntryToDelete);

            base.Delete(entry, BolaoNet.Tests.Dao.Time.QueryToCompareDelete);
        }
        [Test]
        public void SelectAll()
        {
            BolaoNet.Business.DadosBasicos.Support.Time entry = new BolaoNet.Business.DadosBasicos.Support.Time(
                Constants.CurrentUser, _daoBase);

            base.SelectAll (entry,
                BolaoNet.Tests.Dao.Time.SelectAllCondition,
                BolaoNet.Tests.Dao.Time.QueryToCompareSelectAll);
        }
        [Test]
        public void SelectPage()
        {
            BolaoNet.Business.DadosBasicos.Support.Time entry = new BolaoNet.Business.DadosBasicos.Support.Time(
                Constants.CurrentUser, _daoBase);

            base.SelectAll(entry,
                BolaoNet.Tests.Dao.Time.SelectPageCondition,
                BolaoNet.Tests.Dao.Time.QueryToCompareSelectPage);
        }
        [Test]
        public void SelectCount()
        {
            BolaoNet.Business.DadosBasicos.Support.Time entry = new BolaoNet.Business.DadosBasicos.Support.Time(
                Constants.CurrentUser, _daoBase);

            base.SelectAll(entry,
                BolaoNet.Tests.Dao.Time.SelectPageCondition,
                BolaoNet.Tests.Dao.Time.QueryToCompareSelectCount);
        }
        [Test]
        public void SelectCombo()
        {
            BolaoNet.Business.DadosBasicos.Support.Time entry = new BolaoNet.Business.DadosBasicos.Support.Time(
                Constants.CurrentUser, _daoBase);

            base.SelectCombo(entry,
                BolaoNet.Tests.Dao.Time.QueryToCompareSelectCombo);
        }
        #endregion
    }
}
