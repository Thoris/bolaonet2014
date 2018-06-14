using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;

namespace Framework.Tests.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //Framework.DataServices.IPagingDatabase item = new Framework.DataServices.OleDbSupport



            //BolaoNet.Business.Campeonatos.Support.Campeonato campeonato = new BolaoNet.Business.Campeonatos.Support.Campeonato("thoris");
            //campeonato.Nome = "Paulista 2010";

            //campeonato.LoadCampeonato(true, ".\\planilha.txt");

            //System.Console.Write("Teste");

            //LoadDataFromFile(".\\jogos.txt");
            
            DoBolaoNetDaoTests();
            //DoBolaoNetBusinessTests();

            // DoSecurityTests();
            //DoConfigurationTests();
            //DoLoggingTests();
            //DoDataServicesTests();
            
        }


        #region Methods

        #region BolaoNet

        #region LoadData
        private static void LoadDataFromFile(string file)
        {
            string lastGroup = "";
            //string lastFase = "";

            List<BolaoNet.Model.Campeonatos.Jogo> list = new List<BolaoNet.Model.Campeonatos.Jogo>();


            System.IO.StreamReader reader = new System.IO.StreamReader(file);

            while (reader.Peek() >= 0)
            {
                string line = reader.ReadLine();

                //Se a linha tem conteudo
                if (!string.IsNullOrEmpty(line) && line.Length > 2)
                {
                    //Se é a data do jogo
                    if (char.IsNumber(line[0]) && char.IsNumber(line[1]))
                    {
                        DateTime dataJogo;
                        string time1;
                        string time2;
                        string estadio;

                        int posDate = line.IndexOf('\t');
                        int posLastDate = line.IndexOf('\t', posDate+1);

                        dataJogo = Convert.ToDateTime ( line.Substring(0, posLastDate));


                        int posEndTime1 = line.IndexOf('x', posLastDate + 1);
                        time1 = line.Substring(posLastDate, posEndTime1 - posLastDate).Trim();





                        int currentPos = line.Length - 1;

                        while (line[currentPos] != '\t')
                        {
                            currentPos--;
                        }

                        estadio = line.Substring(currentPos).Trim ();

                        time2 = line.Substring(posEndTime1+1, currentPos-posEndTime1 -1).Trim ();

                        BolaoNet.Model.Campeonatos.Jogo jogo = new BolaoNet.Model.Campeonatos.Jogo();
                        jogo.Campeonato = new BolaoNet.Model.Campeonatos.Campeonato("Copa do Mundo 2010");
                        jogo.DataJogo = dataJogo.AddMonths(-6);
                        jogo.Estadio = new BolaoNet.Model.DadosBasicos.Estadio(estadio);
                        jogo.Fase = new BolaoNet.Model.Campeonatos.Fase("1");
                        jogo.Grupo = new BolaoNet.Model.Campeonatos.Grupo(lastGroup);

                        jogo.Time1 = new BolaoNet.Model.DadosBasicos.Time(time1);
                        jogo.Time2 = new BolaoNet.Model.DadosBasicos.Time(time2);

                        


                    }
                    //Se é o título 
                    else
                    {
                        lastGroup = line.Substring(25).Replace("GRUPO", "").Trim();
                    }
                }//endif conteudo na linha

            }//end while
            reader.Close();


        }
        #endregion

        #region Dao
        private static void DoBolaoNetDaoTests()
        {
            DoBolaoNetDaoTimesTests();
            DoBolaoNetDaoEstadiosTests();
            DoBolaoNetDaoCampeonatosTests();
            DoBolaoNetDaoJogosTests();
            DoBolaoNetDaoBolaoTests();
            
            //DoBolaoNetDaoCampeonatosGruposTests();
        }
        private static void DoBolaoNetDaoTimesTests()
        {
            BolaoNet.Tests.Dao.Time daoObject = new BolaoNet.Tests.Dao.Time();
            daoObject.Init();

            daoObject.Delete();
            daoObject.Insert();
            daoObject.Load();
            daoObject.Update();
            daoObject.SelectAll();
            daoObject.SelectCount();
            daoObject.SelectPage();
            daoObject.SelectCombo();

            daoObject.Cleanup();
        }
        private static void DoBolaoNetDaoEstadiosTests()
        {
            BolaoNet.Tests.Dao.Estadio daoObject = new BolaoNet.Tests.Dao.Estadio();
            daoObject.Init();

            daoObject.Delete();
            daoObject.Insert();
            daoObject.Load();
            daoObject.Update();
            daoObject.SelectAll();
            daoObject.SelectCount();
            daoObject.SelectPage();
            daoObject.SelectCombo();

            daoObject.Cleanup();
        }        
        private static void DoBolaoNetDaoCampeonatosTests()
        {
            BolaoNet.Tests.Dao.Campeonato daoObject = new BolaoNet.Tests.Dao.Campeonato();
            daoObject.Init();

            daoObject.Delete();
            daoObject.Insert();
            daoObject.Load();
            daoObject.Update();
            daoObject.SelectAll();
            daoObject.SelectCount();
            daoObject.SelectPage();
            daoObject.SelectCombo();


            daoObject.LoadTimes();
            daoObject.DeleteTime();
            daoObject.InsertTime();            
            daoObject.ClearTimes();
            

            daoObject.DeleteGrupo();
            daoObject.InsertGrupo();
            daoObject.LoadGrupos();
            daoObject.ClearGrupos();
            daoObject.UpdateGrupo();

            daoObject.DeleteFase();
            daoObject.InsertFase();
            daoObject.LoadFases();
            daoObject.ClearFases();
            daoObject.UpdateFase();


            

            daoObject.Cleanup();
        }
        private static void DoBolaoNetDaoCampeonatosGruposTests()
        {
            BolaoNet.Tests.Dao.Campeonatos.Grupo daoObject = new BolaoNet.Tests.Dao.Campeonatos.Grupo();
            daoObject.Init();
            
            daoObject.LoadTimes();
            daoObject.InsertTime();
            daoObject.DeleteTime();
            daoObject.ClearTimes();
            
            daoObject.Cleanup();
        }

        private static void DoBolaoNetDaoJogosTests()
        {
            BolaoNet.Tests.Dao.Jogo daoObject = new BolaoNet.Tests.Dao.Jogo ();
            daoObject.Init();

            //daoObject.Load();
            //daoObject.Delete();
            //daoObject.Insert();            
            //daoObject.Update();
            //daoObject.SelectAll();
            //daoObject.SelectCount();
            //daoObject.SelectPage();
            //daoObject.SelectCombo();

            //daoObject.InsertResult();
            //daoObject.RemoveResult();

            
            daoObject.Cleanup();
        }

        private static void DoBolaoNetDaoBolaoTests()
        {
            BolaoNet.Tests.Dao.Bolao daoObject = new BolaoNet.Tests.Dao.Bolao();
            daoObject.Init();

            daoObject.Delete();
            daoObject.Insert();
            daoObject.Load();
            daoObject.Update();
            daoObject.SelectAll();
            daoObject.SelectCount();
            daoObject.SelectPage();
            daoObject.SelectCombo();


            daoObject.LoadMembros();
            daoObject.DeleteMembro();
            daoObject.InsertMembro();
            daoObject.ClearMembros();

            daoObject.Cleanup();
        } 
        
        #endregion

        #region Business
        private static void DoBolaoNetBusinessTests()
        {
            DoBolaoNetBusinessTimesTests();
            DoBolaoNetBusinessEstadiosTests();
            DoBolaoNetBusinessCampeonatosTests();
        }

        private static void DoBolaoNetBusinessTimesTests()
        {
            BolaoNet.Tests.Business.Time businessObject = new BolaoNet.Tests.Business.Time();
            businessObject.Init();

            businessObject.Delete();
            businessObject.Insert();
            businessObject.Load();
            businessObject.Update();
            businessObject.SelectAll();
            businessObject.SelectCount();
            businessObject.SelectPage();
            businessObject.SelectCombo();

            businessObject.Cleanup();
        }
        private static void DoBolaoNetBusinessEstadiosTests()
        {
            BolaoNet.Tests.Business.Estadio businessObject = new BolaoNet.Tests.Business.Estadio();
            businessObject.Init();

            businessObject.Delete();
            businessObject.Insert();
            businessObject.Load();
            businessObject.Update();
            businessObject.SelectAll();
            businessObject.SelectCount();
            businessObject.SelectPage();
            businessObject.SelectCombo();

            businessObject.Cleanup();
        }
        private static void DoBolaoNetBusinessCampeonatosTests()
        {
            BolaoNet.Tests.Business.Campeonato businessObject = new BolaoNet.Tests.Business.Campeonato();
            businessObject.Init();

            businessObject.Delete();
            businessObject.Insert();
            businessObject.Load();
            businessObject.Update();
            businessObject.SelectAll();
            businessObject.SelectCount();
            businessObject.SelectPage();
            businessObject.SelectCombo();

            businessObject.LoadTimes();
            businessObject.InsertTime();
            businessObject.DeleteTime();            
            businessObject.ClearTimes();


            businessObject.LoadGrupos();
            businessObject.InsertGrupo();
            businessObject.DeleteGrupo();
            businessObject.ClearGrupos();
            businessObject.UpdateGrupo();



            businessObject.Cleanup();
        }
        


        #endregion

        #endregion

        #region Configuration
        private static void DoConfigurationTests()
        {
            DoKeySetTests();
            DoKeySetConfigurationTests();
        }


        private static void DoKeySetTests()
        {
            Framework.Tests.Configuration.KeySet keySet = new Framework.Tests.Configuration.KeySet();
            keySet.Init();

            keySet.GetExistingKey();
            keySet.GetExistingKeySet();
            keySet.GetNonExistingKey();
            keySet.GetNonExistingKeySet();

            keySet.Cleanup();
        }

        private static void DoKeySetConfigurationTests()
        {
            Framework.Tests.Configuration.KeySetConfiguration keySetConfiguration =
                new Framework.Tests.Configuration.KeySetConfiguration();

            keySetConfiguration.Init();
            keySetConfiguration.Deserialize();
            keySetConfiguration.FailToDeserialize();
            keySetConfiguration.FailToLoadKeySet();
            keySetConfiguration.FailToSaveKeySet();
            keySetConfiguration.FailToSerialize();
            keySetConfiguration.LoadKeySet();
            keySetConfiguration.SaveKeySet();
            keySetConfiguration.Serialize();

            keySetConfiguration.Cleanup();

        }
        #endregion

        #region Dataservices
        private static void DoDataServicesTests()
        {
            DoCommonDatabaseTests();
            DoPagingDatabaseTests();
            DoItemPagingTests();
        }

        private static void DoCommonDatabaseTests()
        {
            Framework.Tests.DataServices.CommonDatabase commonDatabase = 
                new Framework.Tests.DataServices.CommonDatabase();

            commonDatabase.Init();

            commonDatabase.CreateConnection();
            commonDatabase.OpenAndCloseConnection();
            commonDatabase.CreateConnectionByConfigurationSettings();
            commonDatabase.ExecuteStoredProcedureToDataSetWithDataAndIntParameters();
            commonDatabase.ExecuteStoredProcedureToDataSetWithDataParameters();
            commonDatabase.ExecuteStoredProcedureToDataSetWithDefaultOutputParameters();
            commonDatabase.ExecuteStoredProcedureToDataSetWithIntParameters();
            commonDatabase.ExecuteStoredProcedureToDataSetWithoutParameters();
            commonDatabase.ExecuteStoredProcedureToNonQueryWithDataAndIntParameters();
            commonDatabase.ExecuteStoredProcedureToNonQueryWithDataParameters();
            commonDatabase.ExecuteStoredProcedureToNonQueryWithDefaultOutputParameters();
            commonDatabase.ExecuteStoredProcedureToNonQueryWithIntParameters();
            commonDatabase.ExecuteStoredProcedureToNonQueryWithoutParameters();
            commonDatabase.ExecuteStoredProcedureToReaderWithDataAndIntParameters();
            commonDatabase.ExecuteStoredProcedureToReaderWithDataParameters();
            commonDatabase.ExecuteStoredProcedureToReaderWithDefaultOutputParameters();
            commonDatabase.ExecuteStoredProcedureToReaderWithIntParameters();
            commonDatabase.ExecuteStoredProcedureToReaderWithoutParameters();
            commonDatabase.ExecuteStoredProcedureToScalarWithDataAndIntParameters();
            commonDatabase.ExecuteStoredProcedureToScalarWithDataParameters();
            commonDatabase.ExecuteStoredProcedureToScalarWithIntParameters();
            commonDatabase.ExecuteStoredProcedureToScalarWithoutParameters();
            commonDatabase.ExecuteTextToDataSetWithDataParameters();
            commonDatabase.ExecuteTextToDataSetWithIntAndDataParameters();
            commonDatabase.ExecuteTextToDataSetWithIntParameters();
            commonDatabase.ExecuteTextToDataSetWithoutParameters();
            commonDatabase.ExecuteTextToNonQueryWithDataParameters();
            commonDatabase.ExecuteTextToNonQueryWithIntAndDataParameters();
            commonDatabase.ExecuteTextToNonQueryWithIntParameters();
            commonDatabase.ExecuteTextToNonQueryWithoutParameters();
            commonDatabase.ExecuteTextToReaderWithDataParameters();
            commonDatabase.ExecuteTextToReaderWithIntAndDataParameters();
            commonDatabase.ExecuteTextToReaderWithIntParameters();
            commonDatabase.ExecuteTextToReaderWithoutParameters();
            commonDatabase.ExecuteTextToScalarWithDataParameters();
            commonDatabase.ExecuteTextToScalarWithIntAndDataParameters();
            commonDatabase.ExecuteTextToScalarWithIntParameters();
            commonDatabase.ExecuteTextToScalarWithoutParameters();

            try { commonDatabase.FailedToExecuteStoredProcedureToDataSetInWrongParameters();  }
            catch {  }
            try { commonDatabase.FailedToExecuteStoredProcedureToNonQueryInWrongParameters(); }
            catch { }
            try { commonDatabase.FailedToExecuteStoredProcedureToReaderInWrongParameters(); }
            catch {  }
            try { commonDatabase.FailedToExecuteStoredProcedureToScalarInWrongParameters();  }
            catch {  }
            try { commonDatabase.FailedToExecuteTextToDataSetInWrongFieldName();}
            catch {  }
            try { commonDatabase.FailedToExecuteTextToDataSetInWrongParameters();  }
            catch { }
            try { commonDatabase.FailedToExecuteTextToDataSetInWrongTable();  }
            catch { }
            try { commonDatabase.FailedToExecuteTextToNonQueryInWrongFieldName();  }
            catch {  }
            try { commonDatabase.FailedToExecuteTextToNonQueryInWrongParameters();  }
            catch {  }
            try { commonDatabase.FailedToExecuteTextToNonQueryInWrongTable();  }
            catch {  }
            try { commonDatabase.FailedToExecuteTextToReaderInWrongFieldName();  }
            catch {  }
            try { commonDatabase.FailedToExecuteTextToReaderInWrongParameters();  }
            catch {  }
            try { commonDatabase.FailedToExecuteTextToReaderInWrongTable();  }
            catch {  }
            try { commonDatabase.FailedToExecuteTextToScalarInWrongFieldName();  }
            catch {  }
            try { commonDatabase.FailedToExecuteTextToScalarInWrongParameters();  }
            catch {  }
            try { commonDatabase.FailedToExecuteTextToScalarInWrongTable();  }
            catch {  }
            try { commonDatabase.FailedToExecutStoredProcedureToDataSetInWrongStoredProcedure();  }
            catch {  }
            try { commonDatabase.FailedToExecutStoredProcedureToNonQueryInWrongStoredProcedure(); }
            catch {  }
            try { commonDatabase.FailedToExecutStoredProcedureToReaderInWrongStoredProcedure();  }
            catch {  }
            try { commonDatabase.FailedToExecutStoredProcedureToScalarInWrongStoredProcedure();  }
            catch {  }
            try { commonDatabase.FailToCreateConnection(); }
            catch {  }
            try { commonDatabase.FailToCreateConnectionInConnectionString();  }
            catch {  }
            try { commonDatabase.FailToCreateConnectionInProviderName();  }
            catch {  }
           


            commonDatabase.Cleanup();

        }

        private static void DoPagingDatabaseTests()
        {
            Framework.Tests.DataServices.PagingDatabase pagingDatabase =
                new Framework.Tests.DataServices.PagingDatabase();

            pagingDatabase.Init();

            pagingDatabase.ExecutePagingStoredProcedure();
            pagingDatabase.ExecutePagingStoredProcedureCount();
            pagingDatabase.ExecutePagingStoredProcedureCountWithDefaultParameters();
            pagingDatabase.ExecutePagingStoredProcedureWithDefaultParameters();

            pagingDatabase.Cleanup();

        }
 
        private static void DoItemPagingTests()
        {
            Framework.Tests.DataServices.ItemPaging itemPaging = 
                new Framework.Tests.DataServices.ItemPaging();

            itemPaging.Init();

            itemPaging.GetCount();
            itemPaging.GetCountWithDefaultParameters();
            itemPaging.GetPage();
            itemPaging.GetPageWithDefaultParameters();

            itemPaging.Cleanup();

        }
        #endregion

        #region Security
        private static void DoSecurityTests()
        {
            DoUserDataDaoTests();
            DoUserManagerDaoTests();



            DoUserDataBusinessTests();
            DoUserManagerBusinessTests();
        }

        public static void DoUserDataDaoTests()
        {
            Framework.Tests.Security.DataAccess.UserDataDao userDataDao = 
                new Framework.Tests.Security.DataAccess.UserDataDao();

            userDataDao.Init();


            userDataDao.ApproveUser();
            userDataDao.ChangePassword();
            userDataDao.ChangePasswordQuestionAndAnswer();
            userDataDao.CreateUser();
            userDataDao.DesapproveUser();
            userDataDao.GetPassword();
            userDataDao.GetPasswordWithFormat();
            userDataDao.LockUser();
            userDataDao.ResetPassword();
            userDataDao.SetPassword();
            userDataDao.UnLockUser();
            userDataDao.UpdateUser();
            userDataDao.UpdateUserInfo();
            userDataDao.ValidateUser();
            userDataDao.LoadUser();


            userDataDao.Cleanup();
        
        
        }

        public static void DoUserManagerDaoTests()
        {
            Framework.Tests.Security.DataAccess.UserManagerDao userManagerDao =
                new Framework.Tests.Security.DataAccess.UserManagerDao();

            userManagerDao.Init();


            userManagerDao.FindUsersByEmail();
            userManagerDao.FindUsersByName();
            userManagerDao.GetAllUsers();
            userManagerDao.GetNumberOfUsersOnline();
            userManagerDao.GetUserNameByEmail();
            userManagerDao.GetUser();
            


            userManagerDao.Cleanup();
        }


        public static void DoUserDataBusinessTests()
        {
            Framework.Tests.Security.Business.UserDataService userDataService = 
                new Framework.Tests.Security.Business.UserDataService() ;

            userDataService.Init();

            userDataService.ApproveUser();
            userDataService.ChangePassword();
            userDataService.ChangePasswordQuestionAndAnswer();
            userDataService.CreateUser();
            userDataService.DesapproveUser();
            userDataService.GetPassword();
            userDataService.GetPasswordWithFormat();
            userDataService.LockUser();
            userDataService.ResetPassword();
            userDataService.SetPassword();
            userDataService.UnLockUser();
            userDataService.UpdateUser();
            userDataService.UpdateUserInfo();
            userDataService.ValidateUser();
            userDataService.LoadUser();


            userDataService.Cleanup();

        }

        public static void DoUserManagerBusinessTests()
        {
            Framework.Tests.Security.Business.UserManagerService userManagerService =
                new Framework.Tests.Security.Business.UserManagerService();

            userManagerService.Init();

            userManagerService.ChangePassword();
            userManagerService.ChangePasswordQuestionAndAnswer();
            userManagerService.CreateUser();
            userManagerService.DecryptPassword();
            userManagerService.DeleteUser();
            userManagerService.EncryptPassword();
            userManagerService.FindUsersByEmail();
            userManagerService.FindUsersByName();
            userManagerService.GetAllUsers();
            userManagerService.GetNumberOfUsersOnline();
            userManagerService.GetPassword();
            userManagerService.GetUser();
            userManagerService.GetUserNameByEmail();
            userManagerService.Initialize();
            userManagerService.ResetPassword();
            userManagerService.UnlockUser();
            userManagerService.UpdateUser();
            userManagerService.ValidateUser();


            userManagerService.Cleanup();

        }


        #endregion

        #region Logging
        private static void DoLoggingTests()
        {
            DoLoggerSettingsTests();
            DoTransportSettingsTests();
            DoLogFileTransportTests();
            DoMSMQTransportTests();
            DoNTEventLogTransportTests();
            DoRemotingTransportTests();
            DoSQLTransportTests();
            DoWebServiceTransportTests();
            DoExceptionFormatterTests();
            DoLoggerTraceListenerTests();
            DoLogManagerTests();
            DoLogRecordTests();
        }

        private static void DoLoggerSettingsTests()
        {
        }
        private static void DoTransportSettingsTests()
        {
        }
        private static void DoLogFileTransportTests()
        {
        }
        private static void DoMSMQTransportTests()
        {
        }
        private static void DoNTEventLogTransportTests()
        {
        }
        private static void DoRemotingTransportTests()
        {
        }
        private static void DoSQLTransportTests()
        {
        }
        private static void DoWebServiceTransportTests()
        {
        }
        private static void DoExceptionFormatterTests()
        {
        }
        private static void DoLoggerTraceListenerTests()
        {
        }
        private static void DoLogManagerTests()
        {
        }
        private static void DoLogRecordTests()
        {
        }
        
        
        
        
        
        #endregion

        #endregion
    }
}
