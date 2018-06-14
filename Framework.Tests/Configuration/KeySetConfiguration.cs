using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Framework.Tests.Configuration
{
    [TestFixture]
    public class KeySetConfiguration
    {
        #region Constants
        private const string FileTestConfig = "test.config";
        private const string FileToCreateTestConfig = "TestToCreate.config";


        private const string RootNode = "KeysetRootNodeTest";
        private const string NotExistingRootNode = "WrongKeySet";

        private const string KeySetDefault = "<Keyset xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" " +
                "xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" " +
                "name=\"KeySetRoot\">" +
                    "<Keyset name=\"Level2.Tree1\">" +
                        "<Key name=\"Item1.Level2.Tree1\" dataType=\"string\">Value1.Level2.Tree1</Key>" +
                        "<Key name=\"Item2.Level2.Tree1\" dataType=\"string\">Value2.Level2.Tree1</Key>" +
                    "</Keyset>" +
                    "<Keyset name=\"Level2.Tree2\">" +
                        "<Key name=\"Item1.Level2.Tree2\" dataType=\"string\">Value1.Level2.Tree2</Key>" +
                        "<Key name=\"Item2.Level2.Tree2\" dataType=\"string\">Value2.Level2.Tree2</Key>" +
                    "</Keyset>" +
                    "<Key name=\"Item1.Level1.Tree1\" dataType=\"string\">Value1.Level1.Tree1</Key>" +
                    "<Key name=\"Item2.Level1.Tree1\" dataType=\"string\">Value2.Level1.Tree1</Key>" +
                "</Keyset>";

        private Framework.Configuration.KeySet _keySetDefault = null;
        #endregion

        #region Constructors/Destructors
        public KeySetConfiguration()
        {
        }

        [TestFixtureSetUp]
        public void Init()
        {
            if (System.IO.File.Exists(FileToCreateTestConfig))
                System.IO.File.Delete(FileToCreateTestConfig);




            _keySetDefault = new Framework.Configuration.KeySet("KeySetRoot");
            _keySetDefault.Keys.Add(new Framework.Configuration.Key("Item1.Level1.Tree1", "Value1.Level1.Tree1"));
            _keySetDefault.Keys.Add(new Framework.Configuration.Key("Item2.Level1.Tree1", "Value2.Level1.Tree1"));
            

            Framework.Configuration.KeySet _keySetLevel2 = new Framework.Configuration.KeySet("Level2.Tree1");
            _keySetLevel2.Keys.Add(new Framework.Configuration.Key("Item1.Level2.Tree1", "Value1.Level2.Tree1"));
            _keySetLevel2.Keys.Add(new Framework.Configuration.Key("Item2.Level2.Tree1", "Value2.Level2.Tree1"));
            _keySetDefault.KeySets.Add(_keySetLevel2);

            Framework.Configuration.KeySet _keySetLevel2Tree2 = new Framework.Configuration.KeySet("Level2.Tree2");
            _keySetLevel2Tree2.Keys.Add(new Framework.Configuration.Key("Item1.Level2.Tree2", "Value1.Level2.Tree2"));
            _keySetLevel2Tree2.Keys.Add(new Framework.Configuration.Key("Item2.Level2.Tree2", "Value2.Level2.Tree2"));
            _keySetDefault.KeySets.Add(_keySetLevel2Tree2);
            




            
        }

        [TearDown]
        public void Cleanup()
        {
            if (System.IO.File.Exists(FileToCreateTestConfig))
                System.IO.File.Delete(FileToCreateTestConfig);
        }
        #endregion

        #region Methods
        [Test]
        public void SaveKeySet()
        {
            
            Framework.Configuration.KeySetConfiguration.Save(FileToCreateTestConfig, _keySetDefault);

            if (!System.IO.File.Exists(FileToCreateTestConfig))
                throw new Exception("File didn't create");

        }

        [Test]
        public void LoadKeySet()
        {
            Framework.Configuration.KeySet keySet = 
                Framework.Configuration.KeySetConfiguration.Load(FileTestConfig);


            Assert.Greater(keySet.Keys.Count, 0);
            Assert.Greater(keySet.KeySets.Count, 0);
             
        }

        [Test]
        public void Serialize()
        {
            string result = Framework.Configuration.KeySetConfiguration.Serialize(_keySetDefault);

            Assert.AreEqual(result, KeySetDefault);
        }

        [Test]
        public void Deserialize()
        {
            //Framework.Configuration.KeySet keySet = 
            //    Framework.Configuration.KeySetConfiguration.Deserialize(KeySetDefault);

            //
            // TODO: Create a unit test to Deserialize the item
            //

        }

        [Test]
        [ExpectedException]
        public void FailToSaveKeySet()
        {
            throw new Exception();
        }

        [Test]
        [ExpectedException]
        public void FailToLoadKeySet()
        {
            throw new Exception();
        }

        [Test]
        [ExpectedException]
        public void FailToSerialize()
        {
            throw new Exception();
        }

        [Test]
        [ExpectedException]
        public void FailToDeserialize()
        {
            throw new Exception();
        }
        

        #endregion
    }
}
