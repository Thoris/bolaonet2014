using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using NUnit.Framework;

namespace BolaoNet.Tests.Business
{
    [TestFixture]
    public class Estadio: BusinessBase
    {

        #region Variables
        private BolaoNet.Dao.IDaoBase _daoBase = null;
        #endregion

        #region Constructors/Destructors
        public Estadio()
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
            _daoBase = new BolaoNet.Dao.DadosBasicos.SQLSupport.Estadio
                    (
                        BolaoNet.Tests.Constants.ConnectionName,
                        BolaoNet.Tests.Constants.ConnectionString,
                        BolaoNet.Tests.Constants.ProviderName
                    );


        }
        [TestFixtureSetUp]
        public void Init()
        {
            BolaoNet.Tests.Dao.Estadio newItem = new BolaoNet.Tests.Dao.Estadio();
            base.Init(newItem.InitQueries);
        }

        [TearDown]
        public void Cleanup()
        {
            BolaoNet.Tests.Dao.Estadio newItem = new BolaoNet.Tests.Dao.Estadio();            
            base.CleanUp(newItem.CleanUpQueries);
        }
        #endregion

        #region Methods
        [Test]
        public void Load()
        {
            BolaoNet.Business.DadosBasicos.Support.Estadio entry = new BolaoNet.Business.DadosBasicos.Support.Estadio(
                Constants.CurrentUser, _daoBase,
                BolaoNet.Tests.Dao.Estadio.EntryToLoad);

            base.Load(entry);
        }
        [Test]
        public void Update()
        {
            BolaoNet.Business.DadosBasicos.Support.Estadio entry = new BolaoNet.Business.DadosBasicos.Support.Estadio(
                Constants.CurrentUser, _daoBase,
                BolaoNet.Tests.Dao.Estadio.EntryToUpdate);

            entry.Descricao = "Testando";

            base.Update(entry, BolaoNet.Tests.Dao.Estadio.QueryToCompareUpdate);
        }
        [Test]
        public void Insert()
        {
            BolaoNet.Business.DadosBasicos.Support.Estadio entry = new BolaoNet.Business.DadosBasicos.Support.Estadio(
                Constants.CurrentUser, _daoBase,
                BolaoNet.Tests.Dao.Estadio.EntryToInsert);

            base.Insert(entry, BolaoNet.Tests.Dao.Estadio.QueryToCompareInsert);
        }
        [Test]
        public void Delete()
        {
            BolaoNet.Business.DadosBasicos.Support.Estadio entry = new BolaoNet.Business.DadosBasicos.Support.Estadio(
                Constants.CurrentUser, _daoBase,
                BolaoNet.Tests.Dao.Estadio.EntryToDelete);

            base.Delete(entry, BolaoNet.Tests.Dao.Estadio.QueryToCompareDelete);
        }
        [Test]
        public void SelectAll()
        {
            BolaoNet.Business.DadosBasicos.Support.Estadio entry = new BolaoNet.Business.DadosBasicos.Support.Estadio(
                Constants.CurrentUser, _daoBase);

            base.SelectAll (entry,
                BolaoNet.Tests.Dao.Estadio.SelectAllCondition,
                BolaoNet.Tests.Dao.Estadio.QueryToCompareSelectAll);
        }
        [Test]
        public void SelectPage()
        {
            BolaoNet.Business.DadosBasicos.Support.Estadio entry = new BolaoNet.Business.DadosBasicos.Support.Estadio(
                Constants.CurrentUser, _daoBase);

            base.SelectAll(entry,
                BolaoNet.Tests.Dao.Estadio.SelectPageCondition,
                BolaoNet.Tests.Dao.Estadio.QueryToCompareSelectPage);
        }
        [Test]
        public void SelectCount()
        {
            BolaoNet.Business.DadosBasicos.Support.Estadio entry = new BolaoNet.Business.DadosBasicos.Support.Estadio(
                Constants.CurrentUser, _daoBase);

            base.SelectAll(entry,
                BolaoNet.Tests.Dao.Estadio.SelectPageCondition,
                BolaoNet.Tests.Dao.Estadio.QueryToCompareSelectCount);
        }
        [Test]
        public void SelectCombo()
        {
            BolaoNet.Business.DadosBasicos.Support.Estadio entry = new BolaoNet.Business.DadosBasicos.Support.Estadio(
                Constants.CurrentUser, _daoBase);

            base.SelectCombo(entry,
                BolaoNet.Tests.Dao.Estadio.QueryToCompareSelectCombo);
        }
        #endregion
    }
}
