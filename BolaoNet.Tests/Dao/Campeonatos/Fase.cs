using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Text;

namespace BolaoNet.Tests.Dao.Campeonatos
{
    [TestFixture]
    public class Fase 
    {
        #region Constants
        public const string EntryToLoad = "EntryToLoad";
        public const string EntryToUpdate = "EntryToUpdate";
        public const string EntryToInsert = "EntryToInsert";
        public const string EntryToDelete = "EntryToDelete";
        #endregion    


        #region Constructors/Destructors
        public Fase()
        {
        }

        [TestFixtureSetUp]
        public void Init()
        {
            //base.Init(InitQueries);   
        }

        [TearDown]
        public void Cleanup()
        {
            //base.CleanUp(CleanUpQueries);
        }
        #endregion

    }
}
