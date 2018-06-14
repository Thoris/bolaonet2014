using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Framework.Tests.Configuration
{
    [TestFixture]
    public class KeySet
    {
     
        #region Constants
        #endregion

        #region Constructors/Destructors
        public KeySet()
        {
        }

        [TestFixtureSetUp]
        public void Init()
        {
            
        }

        [TearDown]
        public void Cleanup()
        {
        }
        #endregion

        #region Methods
        [Test]
        public void GetExistingKey()
        {
        }
        [Test]
        public void GetExistingKeySet()
        {
        }

        [Test]
        [ExpectedException]
        public void GetNonExistingKey()
        {
            throw new Exception();
        }
        [Test]
        [ExpectedException]
        public void GetNonExistingKeySet()
        {
            throw new Exception();
        }
        #endregion

    }

}
