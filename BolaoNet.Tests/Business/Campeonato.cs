using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace BolaoNet.Tests.Business
{
    [TestFixture]
    public class Campeonato : BusinessBase
    {
        
        #region Variables
        private BolaoNet.Dao.IDaoBase _daoBase = null;
        #endregion

        #region Constructors/Destructors
        public Campeonato()
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
            _daoBase = new BolaoNet.Dao.Campeonatos.SQLSupport.Campeonato
                    (
                        BolaoNet.Tests.Constants.ConnectionName,
                        BolaoNet.Tests.Constants.ConnectionString,
                        BolaoNet.Tests.Constants.ProviderName
                    );


        }
        [TestFixtureSetUp]
        public void Init()
        {
            BolaoNet.Tests.Dao.Campeonato newItem = new BolaoNet.Tests.Dao.Campeonato();
            base.Init(newItem.InitQueries);
        }

        [TearDown]
        public void Cleanup()
        {
            BolaoNet.Tests.Dao.Campeonato newItem = new BolaoNet.Tests.Dao.Campeonato();            
            base.CleanUp(newItem.CleanUpQueries);
        }
        #endregion

        #region Methods
        [Test]
        public void Load()
        {
            BolaoNet.Business.Campeonatos.Support.Campeonato entry = new BolaoNet.Business.Campeonatos.Support.Campeonato(
                Constants.CurrentUser, (BolaoNet.Dao.Campeonatos.IDaoCampeonato)_daoBase,
                BolaoNet.Tests.Dao.Campeonato.EntryToLoad);

            base.Load(entry);
        }
        [Test]
        public void Update()
        {
            BolaoNet.Business.Campeonatos.Support.Campeonato entry = new BolaoNet.Business.Campeonatos.Support.Campeonato(
                Constants.CurrentUser, (BolaoNet.Dao.Campeonatos.IDaoCampeonato)_daoBase,
                BolaoNet.Tests.Dao.Campeonato.EntryToUpdate);

            entry.Descricao = "Testando";

            base.Update(entry, BolaoNet.Tests.Dao.Campeonato.QueryToCompareUpdate);
        }
        [Test]
        public void Insert()
        {
            BolaoNet.Business.Campeonatos.Support.Campeonato entry = new BolaoNet.Business.Campeonatos.Support.Campeonato(
                Constants.CurrentUser, (BolaoNet.Dao.Campeonatos.IDaoCampeonato)_daoBase,
                BolaoNet.Tests.Dao.Campeonato.EntryToInsert);

            base.Insert(entry, BolaoNet.Tests.Dao.Campeonato.QueryToCompareInsert);
        }
        [Test]
        public void Delete()
        {
            BolaoNet.Business.Campeonatos.Support.Campeonato entry = new BolaoNet.Business.Campeonatos.Support.Campeonato(
                Constants.CurrentUser, (BolaoNet.Dao.Campeonatos.IDaoCampeonato)_daoBase,
                BolaoNet.Tests.Dao.Campeonato.EntryToDelete);

            base.Delete(entry, BolaoNet.Tests.Dao.Campeonato.QueryToCompareDelete);
        }
        [Test]
        public void SelectAll()
        {
            BolaoNet.Business.Campeonatos.Support.Campeonato entry = new BolaoNet.Business.Campeonatos.Support.Campeonato(
                Constants.CurrentUser, (BolaoNet.Dao.Campeonatos.IDaoCampeonato)_daoBase);

            base.SelectAll (entry,
                BolaoNet.Tests.Dao.Campeonato.SelectAllCondition,
                BolaoNet.Tests.Dao.Campeonato.QueryToCompareSelectAll);
        }
        [Test]
        public void SelectPage()
        {
            BolaoNet.Business.Campeonatos.Support.Campeonato entry = new BolaoNet.Business.Campeonatos.Support.Campeonato(
                Constants.CurrentUser, (BolaoNet.Dao.Campeonatos.IDaoCampeonato)_daoBase);

            base.SelectAll(entry,
                BolaoNet.Tests.Dao.Campeonato.SelectPageCondition,
                BolaoNet.Tests.Dao.Campeonato.QueryToCompareSelectPage);
        }
        [Test]
        public void SelectCount()
        {
            BolaoNet.Business.Campeonatos.Support.Campeonato entry = new BolaoNet.Business.Campeonatos.Support.Campeonato(
                Constants.CurrentUser, (BolaoNet.Dao.Campeonatos.IDaoCampeonato)_daoBase);

            base.SelectAll(entry,
                BolaoNet.Tests.Dao.Campeonato.SelectPageCondition,
                BolaoNet.Tests.Dao.Campeonato.QueryToCompareSelectCount);
        }
        [Test]
        public void SelectCombo()
        {
            BolaoNet.Business.Campeonatos.Support.Campeonato entry = new BolaoNet.Business.Campeonatos.Support.Campeonato(
                Constants.CurrentUser, (BolaoNet.Dao.Campeonatos.IDaoCampeonato)_daoBase);

            base.SelectCombo(entry,
                BolaoNet.Tests.Dao.Campeonato.QueryToCompareSelectCombo);
        }
        #endregion

        #region Times
        [Test]
        public void InsertTime()
        {
            BolaoNet.Business.Campeonatos.Support.Campeonato entry = new BolaoNet.Business.Campeonatos.Support.Campeonato(
                Constants.CurrentUser, (BolaoNet.Dao.Campeonatos.IDaoCampeonato)_daoBase,
                BolaoNet.Tests.Dao.Campeonato.EntryToLoad);


            Model.DadosBasicos.Time entryLinked = new Model.DadosBasicos.Time(BolaoNet.Tests.Dao.Time.EntryToInsert);



            bool result = entry.InsertTime(entryLinked);

            if (result == false)
                throw new AssertTestException("Couldn't insert the time");
            
            object objResult = base.CommonDatabase.ExecuteScalar(
               System.Data.CommandType.Text, BolaoNet.Tests.Dao.Campeonato.QueryToCompareTimeInsert, false, base.CurrentUser);

            if ((int)objResult != 1)
                throw new AssertTestException("The row was not inserted in database."); 

        }
        [Test]
        public void DeleteTime()
        {
            BolaoNet.Business.Campeonatos.Support.Campeonato entry = new BolaoNet.Business.Campeonatos.Support.Campeonato(
                Constants.CurrentUser, (BolaoNet.Dao.Campeonatos.IDaoCampeonato)_daoBase,
                BolaoNet.Tests.Dao.Campeonato.EntryToLoad);


            Model.DadosBasicos.Time entryLinked = new Model.DadosBasicos.Time(BolaoNet.Tests.Dao.Time.EntryToDelete);



            bool result = entry.DeleteTime(entryLinked);

            if (result == false)
                throw new AssertTestException("Couldn't delete the time");

            object objResult = base.CommonDatabase.ExecuteScalar(
                System.Data.CommandType.Text, BolaoNet.Tests.Dao.Campeonato.QueryToCompareTimeDelete, false, base.CurrentUser);

            if ((int)objResult >= 1)
                throw new AssertTestException("The row was not deleted in database."); 
        }
        [Test]
        public void ClearTimes()
        {
            BolaoNet.Business.Campeonatos.Support.Campeonato entry = new BolaoNet.Business.Campeonatos.Support.Campeonato(
                Constants.CurrentUser, (BolaoNet.Dao.Campeonatos.IDaoCampeonato)_daoBase,
                BolaoNet.Tests.Dao.Campeonato.EntryToLoad);



            bool result = entry.ClearTimes();

            if (result == false)
                throw new AssertTestException("Couldn't clear the times");

            
            object objResult = base.CommonDatabase.ExecuteScalar(
                System.Data.CommandType.Text, BolaoNet.Tests.Dao.Campeonato.QueryToCompareTimesClear, false, base.CurrentUser);

            if ((int)objResult >= 1)
                throw new AssertTestException("The rows were not deleted in database."); 
        }
        [Test]
        public void LoadTimes()
        {
            BolaoNet.Business.Campeonatos.Support.Campeonato entry = new BolaoNet.Business.Campeonatos.Support.Campeonato(
                Constants.CurrentUser, (BolaoNet.Dao.Campeonatos.IDaoCampeonato)_daoBase,
                BolaoNet.Tests.Dao.Campeonato.EntryToLoad);




            IList<Framework.DataServices.Model.EntityBaseData> result = entry.LoadTimes();

            if (result == null)
                throw new AssertTestException("Couldn't load the times");

            
        }
        #endregion

        #region Grupos
        [Test]
        public void InsertGrupo()
        {
            BolaoNet.Business.Campeonatos.Support.Campeonato entry = new BolaoNet.Business.Campeonatos.Support.Campeonato(
                Constants.CurrentUser, (BolaoNet.Dao.Campeonatos.IDaoCampeonato)_daoBase,
                BolaoNet.Tests.Dao.Campeonato.EntryToLoad);


            Model.Campeonatos.Grupo entryLinked = new Model.Campeonatos.Grupo(BolaoNet.Tests.Dao.Campeonatos.Grupo.EntryToInsert);



            bool result = entry.InsertGrupo(entryLinked);

            if (result == false)
                throw new AssertTestException("Couldn't insert the grupo");

            object objResult = base.CommonDatabase.ExecuteScalar(
               System.Data.CommandType.Text, BolaoNet.Tests.Dao.Campeonato.QueryToCompareGrupoInsert, false, base.CurrentUser);

            if ((int)objResult != 1)
                throw new AssertTestException("The row was not inserted in database.");

        }
        [Test]
        public void DeleteGrupo()
        {
            BolaoNet.Business.Campeonatos.Support.Campeonato entry = new BolaoNet.Business.Campeonatos.Support.Campeonato(
                Constants.CurrentUser, (BolaoNet.Dao.Campeonatos.IDaoCampeonato)_daoBase,
                BolaoNet.Tests.Dao.Campeonato.EntryToLoad);


            Model.Campeonatos.Grupo entryLinked = new Model.Campeonatos.Grupo(BolaoNet.Tests.Dao.Campeonatos.Grupo.EntryToDelete);



            bool result = entry.DeleteGrupo(entryLinked);

            if (result == false)
                throw new AssertTestException("Couldn't delete the grupo");

            object objResult = base.CommonDatabase.ExecuteScalar(
                System.Data.CommandType.Text, BolaoNet.Tests.Dao.Campeonato.QueryToCompareGrupoDelete, false, base.CurrentUser);

            if ((int)objResult >= 1)
                throw new AssertTestException("The row was not deleted in database.");
        }
        [Test]
        public void ClearGrupos()
        {
            BolaoNet.Business.Campeonatos.Support.Campeonato entry = new BolaoNet.Business.Campeonatos.Support.Campeonato(
                Constants.CurrentUser, (BolaoNet.Dao.Campeonatos.IDaoCampeonato)_daoBase,
                BolaoNet.Tests.Dao.Campeonato.EntryToLoad);



            bool result = entry.ClearGrupos();

            if (result == false)
                throw new AssertTestException("Couldn't clear the grupos");


            object objResult = base.CommonDatabase.ExecuteScalar(
                System.Data.CommandType.Text, BolaoNet.Tests.Dao.Campeonato.QueryToCompareGruposClear, false, base.CurrentUser);

            if ((int)objResult >= 1)
                throw new AssertTestException("The rows were not deleted in database.");
        }
        [Test]
        public void LoadGrupos()
        {
            BolaoNet.Business.Campeonatos.Support.Campeonato entry = new BolaoNet.Business.Campeonatos.Support.Campeonato(
                Constants.CurrentUser, (BolaoNet.Dao.Campeonatos.IDaoCampeonato)_daoBase,
                BolaoNet.Tests.Dao.Campeonato.EntryToLoad);




            IList<Framework.DataServices.Model.EntityBaseData> result = entry.LoadGrupos();

            if (result == null)
                throw new AssertTestException("Couldn't load the grupos");


        }
        [Test]
        public void UpdateGrupo()
        {
            BolaoNet.Business.Campeonatos.Support.Campeonato entry = new BolaoNet.Business.Campeonatos.Support.Campeonato(
                Constants.CurrentUser, (BolaoNet.Dao.Campeonatos.IDaoCampeonato)_daoBase,
                BolaoNet.Tests.Dao.Campeonato.EntryToLoad);


            Model.Campeonatos.Grupo entryLinked = new Model.Campeonatos.Grupo(BolaoNet.Tests.Dao.Campeonatos.Grupo.EntryToUpdate);


            bool result = entry.UpdateGrupo(entryLinked);

            //
            // TODO: Fix this test
            //
            return;


            //if (result == false)
            //    throw new AssertTestException("Couldn't update the grupo");


            //object objResult = base.CommonDatabase.ExecuteScalar(
            //    System.Data.CommandType.Text, BolaoNet.Tests.Dao.Campeonato.QueryToCompareGrupoUpdate, false, base.CurrentUser);

            //if (string.Compare(entryLinked.Descricao.ToString(), objResult.ToString()) != 0)
            //    throw new AssertTestException("Incompatible results between database and object.");
        }

        #endregion
    }
}
