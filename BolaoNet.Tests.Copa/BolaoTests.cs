using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Data;



namespace BolaoNet.Tests.Copa
{
    [TestFixture]
    public class BolaoTests
    {

        #region Constants/Enumerations
        public const string FaseClassificatoria = "Classificatória";
        public const string FaseOitavasFinal = "Oitavas de Final";
        public const string FaseQuartasFinal = "Quartas de Final";
        public const string FaseSemiFinal = "Semi Finais";
        public const string FaseFinal = "Final";
        #endregion

        #region Variables
        private Framework.DataServices.CommonDatabase _db;


        string _currentUser = "Admin";
        string _emailUser = "tst@tst.com.br";
        string _nomeCampeonato = "CM2014";
        string _nomeBolao = "BCM2014";

        #endregion

        #region Constructors/Destructors
        public BolaoTests()            
        {
        }

        [TestFixtureSetUp]
        public void Init()
        {

            _db = new Framework.DataServices.CommonDatabase();

            CleanDatabase();
        }

        [TearDown]
        public void Cleanup()
        {
            CleanDatabase();

           
        }
        #endregion

        #region Methods
        private void CleanDatabase()
        {


            _db.ExecuteNonQuery(CommandType.Text,
              "DELETE FROM ApostasExtrasUsuarios WHERE NomeBolao = @NomeBolao", false, _currentUser,
              _db.Parameters.Create("@NomeBolao", DbType.String, _nomeBolao));


            _db.ExecuteNonQuery(CommandType.Text,
              "DELETE FROM BoloesMembrosPontos WHERE NomeBolao = @NomeBolao", false, _currentUser,
              _db.Parameters.Create("@NomeBolao", DbType.String, _nomeBolao));



            _db.ExecuteNonQuery(CommandType.Text,
              "DELETE FROM BoloesMembrosClassificacao WHERE NomeBolao = @NomeBolao", false, _currentUser,
              _db.Parameters.Create("@NomeBolao", DbType.String, _nomeBolao));



             _db.ExecuteNonQuery(CommandType.Text,
               "DELETE FROM BoloesCampeonatosClassificacaoUsuarios WHERE NomeBolao = @NomeBolao", false, _currentUser,
               _db.Parameters.Create("@NomeBolao", DbType.String, _nomeBolao));


            _db.ExecuteNonQuery(CommandType.Text,
               "DELETE FROM JogosUsuarios WHERE NomeBolao = @NomeBolao", false, _currentUser,
               _db.Parameters.Create("@NomeBolao", DbType.String, _nomeBolao));

            _db.ExecuteNonQuery(CommandType.Text,
                "DELETE FROM BoloesMembros WHERE username in ('XX_0_0','XX_1_0','XX_0_1','XX_1_1','XX_2_0','XX_0_2','XX_2_1','XX_1_2','XX_2_2','XX_3_0','XX_0_3','XX_3_1','XX_1_3','XX_3_2','XX_2_3','XX_3_3')", false, _currentUser
                );


            _db.ExecuteNonQuery(CommandType.Text,
                "DELETE FROM Users WHERE username in ('XX_0_0','XX_1_0','XX_0_1','XX_1_1','XX_2_0','XX_0_2','XX_2_1','XX_1_2','XX_2_2','XX_3_0','XX_0_3','XX_3_1','XX_1_3','XX_3_2','XX_2_3','XX_3_3')", false, _currentUser
                );


            _db.ExecuteNonQuery(CommandType.Text, "DELETE FROM BoloesPontuacao WHERE NomeBolao = @NomeBolao", false, _currentUser,
                _db.Parameters.Create("@NomeBolao", DbType.String, _nomeBolao));


            _db.ExecuteNonQuery(CommandType.Text, "DELETE FROM BoloesCriteriosPontos WHERE NomeBolao = @NomeBolao", false, _currentUser,
                _db.Parameters.Create("@NomeBolao", DbType.String, _nomeBolao));



            _db.ExecuteNonQuery(CommandType.Text, "DELETE FROM BOloesCriteriosPontosTimes WHERE NomeBolao = @NomeBolao", false, _currentUser,
                _db.Parameters.Create("@NomeBolao", DbType.String, _nomeBolao));


            _db.ExecuteNonQuery(CommandType.Text, "DELETE FROM BoloesPremios WHERE NomeBolao = @NomeBolao", false, _currentUser,
                _db.Parameters.Create("@NomeBolao", DbType.String, _nomeBolao));

            _db.ExecuteNonQuery(CommandType.Text, "DELETE FROM ApostasExtras WHERE NomeBolao = @NomeBolao", false, _currentUser,
               _db.Parameters.Create("@NomeBolao", DbType.String, _nomeBolao));


            _db.ExecuteNonQuery(CommandType.Text, "DELETE FROM Boloes WHERE Nome = @NomeBolao", false, _currentUser,
               _db.Parameters.Create("@NomeBolao", DbType.String, _nomeBolao));



            _db.ExecuteNonQuery(CommandType.Text, "DELETE FROM CampeonatosPosicoes WHERE NomeCampeonato = @NomeCampeonato", false, _currentUser,
               _db.Parameters.Create("@NomeCampeonato", DbType.String, _nomeCampeonato));


            _db.ExecuteNonQuery(CommandType.Text, "DELETE FROM CampeonatosClassificacao WHERE NomeCampeonato = @NomeCampeonato", false, _currentUser,
               _db.Parameters.Create("@NomeCampeonato", DbType.String, _nomeCampeonato));



            _db.ExecuteNonQuery(CommandType.Text, "DELETE FROM Jogos WHERE NomeCampeonato = @NomeCampeonato", false, _currentUser,
               _db.Parameters.Create("@NomeCampeonato", DbType.String, _nomeCampeonato));



            _db.ExecuteNonQuery(CommandType.Text, "DELETE FROM CampeonatosGruposTimes WHERE NomeCampeonato = @NomeCampeonato", false, _currentUser,
                _db.Parameters.Create("@NomeCampeonato", DbType.String, _nomeCampeonato));



            _db.ExecuteNonQuery(CommandType.Text, "DELETE FROM CampeonatosTimes WHERE NomeCampeonato = @NomeCampeonato", false, _currentUser,
                _db.Parameters.Create("@NomeCampeonato", DbType.String, _nomeCampeonato));



            _db.ExecuteNonQuery(CommandType.Text, "DELETE FROM CampeonatosGrupos WHERE NomeCampeonato = @NomeCampeonato", false, _currentUser,
                _db.Parameters.Create("@NomeCampeonato", DbType.String, _nomeCampeonato));


            _db.ExecuteNonQuery(CommandType.Text, "DELETE FROM CampeonatosFases WHERE NomeCampeonato = @NomeCampeonato", false, _currentUser,
                _db.Parameters.Create("@NomeCampeonato", DbType.String, _nomeCampeonato));


            _db.ExecuteNonQuery(CommandType.Text, "DELETE FROM Campeonatos WHERE Nome = @NomeCampeonato", false, _currentUser,
                _db.Parameters.Create("@NomeCampeonato", DbType.String, _nomeCampeonato));


            _db.ExecuteNonQuery(CommandType.Text, "DELETE FROM Users WHERE UserName = @UserName", false, _currentUser,
                _db.Parameters.Create("@UserName", DbType.String, _currentUser));

        }

        [Test]
        public void TestFull()
        {

            IList<string[]> times = new List<string[]>();
            string[] grupoA = new string[4]{
                "Brasil",
                "Croácia",
                "México",
                "Camarões"
            };
            string[] grupoB = new string[4]{
                "Espanha",
                "Holanda",
                "Chile",
                "Austrália"
            };
            string[] grupoC = new string[4]{
                "Colômbia",
                "Grécia",
                "Costa do Marfim",
                "Japão"
            };
            string[] grupoD = new string[4]{
                "Uruguai",
                "Costa Rica",
                "Inglaterra",
                "Itália"
            };
            string[] grupoE = new string[4]{
                "Suíça",
                "Equador",
                "França",
                "Honduras"
            };
            string[] grupoF = new string[4]{
                "Argentina",
                "Bósnia e Herzegovina",
                "Irã",
                "Nigéria"
            };
            string[] grupoG = new string[4]{
                "Alemanha",
                "Portugal",
                "Gana",
                "Estados Unidos"
            };
            string[] grupoH = new string[4]{
                "Bélgica",
                "Argélia",
                "Rússia",
                "Coreia do Sul"
            };
            times.Add(grupoA);
            times.Add(grupoB);
            times.Add(grupoC);
            times.Add(grupoD);
            times.Add(grupoE);
            times.Add(grupoF);
            times.Add(grupoG);
            times.Add(grupoH);


            int errorNumber = 0;
            string errorDescription = "";


            Framework.Security.DataAccess.SQLSupport.UserDataDao userDao = new Framework.Security.DataAccess.SQLSupport.UserDataDao();


            // ********************* Inserindo o Usuário Corrente *************************

            //Verificando se o usuário corrente existe
            Framework.Security.DataAccess.SQLSupport.UserManagerDao managerUser = new Framework.Security.DataAccess.SQLSupport.UserManagerDao();
            string userName = managerUser.GetUserNameByEmail(_currentUser, _emailUser, out errorNumber, out errorDescription);
            Assert.AreEqual(0, errorNumber);
            Assert.AreEqual(null, errorDescription);
            if (string.IsNullOrEmpty(userName))
            {
                Framework.Security.Model.UserData user = new Framework.Security.Model.UserData(_currentUser);
                user.Email = _emailUser;

                //Inserindo o usuário corrente
                System.Web.Security.MembershipCreateStatus status =
                    userDao.CreateUser(_currentUser, user, System.Web.Security.MembershipPasswordFormat.Clear, true,
                    out errorNumber, out errorDescription);


            }



            // ********************* Inserindo o Campeonato *************************

            BolaoNet.Business.Campeonatos.Support.Campeonato campeonato = new Business.Campeonatos.Support.Campeonato(_currentUser);


            //Testando se o campeonato existe
            campeonato.Nome = _nomeCampeonato;
            Assert.IsFalse(campeonato.Load());

            //Inserindo o campeonato
            campeonato.Nome = _nomeCampeonato;
            campeonato.IsClube = false;
            campeonato.IsIniciado = false;
            Assert.IsTrue(campeonato.Insert());



            // ********************* Inserindo as fases *************************

            IList<Framework.DataServices.Model.EntityBaseData> fases = campeonato.LoadFases();

            InsertFase(campeonato, FaseClassificatoria, fases);
            InsertFase(campeonato, FaseOitavasFinal, fases);
            InsertFase(campeonato, FaseQuartasFinal, fases);
            InsertFase(campeonato, FaseSemiFinal, fases);
            InsertFase(campeonato, FaseFinal, fases);

            // ********************* Inserindo os grupos *************************


            IList<Framework.DataServices.Model.EntityBaseData> grupos = campeonato.LoadGrupos();

            InsertGrupo(campeonato, " ", grupos);
            InsertGrupo(campeonato, "A", grupos);
            InsertGrupo(campeonato, "B", grupos);
            InsertGrupo(campeonato, "C", grupos);
            InsertGrupo(campeonato, "D", grupos);
            InsertGrupo(campeonato, "E", grupos);
            InsertGrupo(campeonato, "F", grupos);
            InsertGrupo(campeonato, "G", grupos);
            InsertGrupo(campeonato, "H", grupos);

            // ********************* Inserindo os Times *************************
            Assert.IsTrue(InsertTimes(times));

            // ********************* Inserindo os Times no campeonato*************************
            Assert.IsTrue(InsertCampeonatoTimes(campeonato, times));


            // ********************* Inserindo os Times dos grupos *************************
            Assert.IsTrue(InsertTimesGrupos(campeonato, times));

            // ********************* Inserindo as posições *************************
            Assert.IsTrue(InsertCampeonatoPosicao(campeonato, times));



            // ********************* Inserindo os Jogos *************************


            string grupo = "A";

            string[] grupoX = grupoA;
            InsertJogo(campeonato, 1, FaseClassificatoria, grupo, 1, DateTime.Now, "", grupoX[0], grupoX[1]);
            InsertJogo(campeonato, 1, FaseClassificatoria, grupo, 2, DateTime.Now, "", grupoX[2], grupoX[3]);
            InsertJogo(campeonato, 2, FaseClassificatoria, grupo, 17, DateTime.Now, "", grupoX[0], grupoX[2]);
            InsertJogo(campeonato, 2, FaseClassificatoria, grupo, 18, DateTime.Now, "", grupoX[3], grupoX[1]);
            InsertJogo(campeonato, 3, FaseClassificatoria, grupo, 33, DateTime.Now, "", grupoX[3], grupoX[0]);
            InsertJogo(campeonato, 3, FaseClassificatoria, grupo, 34, DateTime.Now, "", grupoX[1], grupoX[2]);

            grupo = "B";
            grupoX = grupoB;
            InsertJogo(campeonato, 1, FaseClassificatoria, grupo, 3, DateTime.Now, "", grupoX[0], grupoX[1]);
            InsertJogo(campeonato, 1, FaseClassificatoria, grupo, 4, DateTime.Now, "", grupoX[2], grupoX[3]);
            InsertJogo(campeonato, 2, FaseClassificatoria, grupo, 19, DateTime.Now, "", grupoX[0], grupoX[2]);
            InsertJogo(campeonato, 2, FaseClassificatoria, grupo, 20, DateTime.Now, "", grupoX[3], grupoX[1]);
            InsertJogo(campeonato, 3, FaseClassificatoria, grupo, 35, DateTime.Now, "", grupoX[3], grupoX[0]);
            InsertJogo(campeonato, 3, FaseClassificatoria, grupo, 36, DateTime.Now, "", grupoX[1], grupoX[2]);

            grupo = "C";
            grupoX = grupoC;
            InsertJogo(campeonato, 1, FaseClassificatoria, grupo, 5, DateTime.Now, "", grupoX[0], grupoX[1]);
            InsertJogo(campeonato, 1, FaseClassificatoria, grupo, 6, DateTime.Now, "", grupoX[2], grupoX[3]);
            InsertJogo(campeonato, 2, FaseClassificatoria, grupo, 21, DateTime.Now, "", grupoX[0], grupoX[2]);
            InsertJogo(campeonato, 2, FaseClassificatoria, grupo, 22, DateTime.Now, "", grupoX[3], grupoX[1]);
            InsertJogo(campeonato, 3, FaseClassificatoria, grupo, 37, DateTime.Now, "", grupoX[3], grupoX[0]);
            InsertJogo(campeonato, 3, FaseClassificatoria, grupo, 38, DateTime.Now, "", grupoX[1], grupoX[2]);

            grupo = "D";
            grupoX = grupoD;
            InsertJogo(campeonato, 1, FaseClassificatoria, grupo, 7, DateTime.Now, "", grupoX[0], grupoX[1]);
            InsertJogo(campeonato, 1, FaseClassificatoria, grupo, 8, DateTime.Now, "", grupoX[2], grupoX[3]);
            InsertJogo(campeonato, 2, FaseClassificatoria, grupo, 23, DateTime.Now, "", grupoX[0], grupoX[2]);
            InsertJogo(campeonato, 2, FaseClassificatoria, grupo, 24, DateTime.Now, "", grupoX[3], grupoX[1]);
            InsertJogo(campeonato, 3, FaseClassificatoria, grupo, 39, DateTime.Now, "", grupoX[3], grupoX[0]);
            InsertJogo(campeonato, 3, FaseClassificatoria, grupo, 40, DateTime.Now, "", grupoX[1], grupoX[2]);


            grupo = "E";
            grupoX = grupoE;
            InsertJogo(campeonato, 1, FaseClassificatoria, grupo, 9, DateTime.Now, "", grupoX[0], grupoX[1]);
            InsertJogo(campeonato, 1, FaseClassificatoria, grupo, 10, DateTime.Now, "", grupoX[2], grupoX[3]);
            InsertJogo(campeonato, 2, FaseClassificatoria, grupo, 25, DateTime.Now, "", grupoX[0], grupoX[2]);
            InsertJogo(campeonato, 2, FaseClassificatoria, grupo, 26, DateTime.Now, "", grupoX[3], grupoX[1]);
            InsertJogo(campeonato, 3, FaseClassificatoria, grupo, 41, DateTime.Now, "", grupoX[3], grupoX[0]);
            InsertJogo(campeonato, 3, FaseClassificatoria, grupo, 42, DateTime.Now, "", grupoX[1], grupoX[2]);

            grupo = "F";
            grupoX = grupoF;
            InsertJogo(campeonato, 1, FaseClassificatoria, grupo, 11, DateTime.Now, "", grupoX[0], grupoX[1]);
            InsertJogo(campeonato, 1, FaseClassificatoria, grupo, 12, DateTime.Now, "", grupoX[2], grupoX[3]);
            InsertJogo(campeonato, 2, FaseClassificatoria, grupo, 27, DateTime.Now, "", grupoX[0], grupoX[2]);
            InsertJogo(campeonato, 2, FaseClassificatoria, grupo, 28, DateTime.Now, "", grupoX[3], grupoX[1]);
            InsertJogo(campeonato, 3, FaseClassificatoria, grupo, 43, DateTime.Now, "", grupoX[3], grupoX[0]);
            InsertJogo(campeonato, 3, FaseClassificatoria, grupo, 44, DateTime.Now, "", grupoX[1], grupoX[2]);

            grupo = "G";
            grupoX = grupoG;
            InsertJogo(campeonato, 1, FaseClassificatoria, grupo, 13, DateTime.Now, "", grupoX[0], grupoX[1]);
            InsertJogo(campeonato, 1, FaseClassificatoria, grupo, 14, DateTime.Now, "", grupoX[2], grupoX[3]);
            InsertJogo(campeonato, 2, FaseClassificatoria, grupo, 29, DateTime.Now, "", grupoX[0], grupoX[2]);
            InsertJogo(campeonato, 2, FaseClassificatoria, grupo, 30, DateTime.Now, "", grupoX[3], grupoX[1]);
            InsertJogo(campeonato, 3, FaseClassificatoria, grupo, 45, DateTime.Now, "", grupoX[3], grupoX[0]);
            InsertJogo(campeonato, 3, FaseClassificatoria, grupo, 46, DateTime.Now, "", grupoX[1], grupoX[2]);

            grupo = "H";
            grupoX = grupoH;
            InsertJogo(campeonato, 1, FaseClassificatoria, grupo, 15, DateTime.Now, "", grupoX[0], grupoX[1]);
            InsertJogo(campeonato, 1, FaseClassificatoria, grupo, 16, DateTime.Now, "", grupoX[2], grupoX[3]);
            InsertJogo(campeonato, 2, FaseClassificatoria, grupo, 31, DateTime.Now, "", grupoX[0], grupoX[2]);
            InsertJogo(campeonato, 2, FaseClassificatoria, grupo, 32, DateTime.Now, "", grupoX[3], grupoX[1]);
            InsertJogo(campeonato, 3, FaseClassificatoria, grupo, 47, DateTime.Now, "", grupoX[3], grupoX[0]);
            InsertJogo(campeonato, 3, FaseClassificatoria, grupo, 48, DateTime.Now, "", grupoX[1], grupoX[2]);





            InsertJogo(campeonato, 4, FaseOitavasFinal, 49, DateTime.Now, "49", "1A", "2B", "A", 1, "B", 2);
            InsertJogo(campeonato, 4, FaseOitavasFinal, 50, DateTime.Now, "50", "1C", "2D", "C", 1, "D", 2);
            InsertJogo(campeonato, 4, FaseOitavasFinal, 53, DateTime.Now, "53", "1E", "2F", "E", 1, "F", 2);
            InsertJogo(campeonato, 4, FaseOitavasFinal, 54, DateTime.Now, "54", "1G", "2H", "G", 1, "H", 2);

            InsertJogo(campeonato, 4, FaseOitavasFinal, 51, DateTime.Now, "51", "1B", "2A", "B", 1, "A", 2);
            InsertJogo(campeonato, 4, FaseOitavasFinal, 52, DateTime.Now, "52", "1D", "2C", "D", 1, "C", 2);
            InsertJogo(campeonato, 4, FaseOitavasFinal, 55, DateTime.Now, "55", "1F", "2E", "F", 1, "E", 2);
            InsertJogo(campeonato, 4, FaseOitavasFinal, 56, DateTime.Now, "56", "1H", "2G", "H", 1, "G", 2);


            InsertJogo(campeonato, 5, FaseQuartasFinal, DateTime.Now, "57", "Vencedor do Jogo 49", "Vencedor do Jogo 50", 49, 1, 50, 1);
            InsertJogo(campeonato, 5, FaseQuartasFinal, DateTime.Now, "58", "Vencedor do Jogo 53", "Vencedor do Jogo 54", 53, 1, 54, 1);
            InsertJogo(campeonato, 5, FaseQuartasFinal, DateTime.Now, "59", "Vencedor do Jogo 51", "Vencedor do Jogo 52", 51, 1, 52, 1);
            InsertJogo(campeonato, 5, FaseQuartasFinal, DateTime.Now, "60", "Vencedor do Jogo 55", "Vencedor do Jogo 56", 55, 1, 56, 1);


            InsertJogo(campeonato, 6, FaseSemiFinal, DateTime.Now, "61", "Vencedor do Jogo 57", "Vencedor do Jogo 58", 57, 1, 58, 1);
            InsertJogo(campeonato, 6, FaseSemiFinal, DateTime.Now, "62", "Vencedor do Jogo 59", "Vencedor do Jogo 60", 59, 1, 60, 1);

            InsertJogo(campeonato, 7, FaseFinal, DateTime.Now, "64", "Vencedor do Jogo 61", "Vencedor do Jogo 62", 61, 1, 62, 1);
            InsertJogo(campeonato, 7, FaseFinal, DateTime.Now, "63", "Perdedor do Jogo 61", "Perdedor do Jogo 62", 61, 0, 62, 0);



            // ********************* Inserindo o Bolão *************************
            Business.Boloes.Support.Bolao bolao = new Business.Boloes.Support.Bolao(_currentUser, _nomeBolao);
            Assert.IsFalse(bolao.Load());
            bolao.ApostasApenasAntes = true;
            bolao.Campeonato = campeonato;
            bolao.TaxaParticipacao = 20;
            Assert.IsTrue(bolao.Insert());

            Assert.IsTrue(InsertBolaoPremio(bolao, 1, "Campeão", "Green", "White"));
            Assert.IsTrue(InsertBolaoPremio(bolao, 2, "Vice-Campeão", "Yellow", "White"));


            Business.Boloes.Support.ApostaExtra apostaExtra = new Business.Boloes.Support.ApostaExtra(_currentUser);
            apostaExtra.Bolao = bolao;
            apostaExtra.Descricao = "Campeão";
            apostaExtra.Posicao = 1;
            apostaExtra.Titulo = "Campeão";
            apostaExtra.TotalPontos = 50;
            apostaExtra.Insert();

            apostaExtra.Descricao = "Vice-Campeão";
            apostaExtra.Posicao = 2;
            apostaExtra.Titulo = "Vice-Campeão";
            apostaExtra.TotalPontos = 30;
            apostaExtra.Insert();

            apostaExtra.Descricao = "Terceiro Lugar";
            apostaExtra.Posicao = 3;
            apostaExtra.Titulo = "Terceiro Lugar";
            apostaExtra.TotalPontos = 20;
            apostaExtra.Insert();

            apostaExtra.Descricao = "Quarto Lugar";
            apostaExtra.Posicao = 4;
            apostaExtra.Titulo = "Quarto Lugar";
            apostaExtra.TotalPontos = 20;
            apostaExtra.Insert();


            int res = _db.ExecuteNonQuery(CommandType.Text, "INSERT INTO BOloesCriteriosPontosTimes (NomeBolao, NomeTime, Multiplo) VALUES (@NomeBolao, @Time, @Valor)", false, _currentUser,
                _db.Parameters.Create("NomeBolao", DbType.String, _nomeBolao),
                _db.Parameters.Create("Time", DbType.String, "Brasil"),
                _db.Parameters.Create("Valor", DbType.Int32, 2));

            Assert.AreEqual(1, res);



            Assert.IsTrue(InsertBolaoPontos(bolao, 1, 2));
            Assert.IsTrue(InsertBolaoPontos(bolao, 2, 0));
            Assert.IsTrue(InsertBolaoPontos(bolao, 3, 0));
            Assert.IsTrue(InsertBolaoPontos(bolao, 4, 0));
            Assert.IsTrue(InsertBolaoPontos(bolao, 5, 0));
            Assert.IsTrue(InsertBolaoPontos(bolao, 6, 0));
            Assert.IsTrue(InsertBolaoPontos(bolao, 7, 0));
            Assert.IsTrue(InsertBolaoPontos(bolao, 8, 3));
            Assert.IsTrue(InsertBolaoPontos(bolao, 9, 0));
            Assert.IsTrue(InsertBolaoPontos(bolao, 10, 0));
            Assert.IsTrue(InsertBolaoPontos(bolao, 11, 0));
            Assert.IsTrue(InsertBolaoPontos(bolao, 12, 0));
            Assert.IsTrue(InsertBolaoPontos(bolao, 13, 0));
            Assert.IsTrue(InsertBolaoPontos(bolao, 14, -2));
            Assert.IsTrue(InsertBolaoPontos(bolao, 15, 1));
            Assert.IsTrue(InsertBolaoPontos(bolao, 16, 1));
            Assert.IsTrue(InsertBolaoPontos(bolao, 17, 5));


            Assert.IsTrue(InsertBolaoPontuacao(bolao, 0, "Erro", "White", "Red"));
            Assert.IsTrue(InsertBolaoPontuacao(bolao, 1, "Gols", "Black", "Cyan"));
            Assert.IsTrue(InsertBolaoPontuacao(bolao, 2, "Gols - Brasil", "Black", "Cyan"));
            Assert.IsTrue(InsertBolaoPontuacao(bolao, 3, "Vencedor", "Black", "Gray"));
            Assert.IsTrue(InsertBolaoPontuacao(bolao, 4, "Vencedor + Gols", "Black", "Blue"));
            Assert.IsTrue(InsertBolaoPontuacao(bolao, 5, "Empate", "Black", "Yellow"));
            Assert.IsTrue(InsertBolaoPontuacao(bolao, 6, "Vencedor - Brasil", "Black", "Gray"));
            Assert.IsTrue(InsertBolaoPontuacao(bolao, 8, "Venc+Gols+Br", "Black", "Blue"));
            Assert.IsTrue(InsertBolaoPontuacao(bolao, 10, "Cheio", "White", "Green"));
            Assert.IsTrue(InsertBolaoPontuacao(bolao, 20, "Cheio - Brasil", "White", "Green"));



            bolao.Campeonato = campeonato;

            Assert.IsTrue(InserUser(bolao, "XX_0_0", 0, 0));
            Assert.IsTrue(InserUser(bolao, "XX_1_0", 1, 0));
            Assert.IsTrue(InserUser(bolao, "XX_0_1", 0, 1));
            Assert.IsTrue(InserUser(bolao, "XX_1_1", 1, 1));
            Assert.IsTrue(InserUser(bolao, "XX_2_0", 2, 0));
            Assert.IsTrue(InserUser(bolao, "XX_0_2", 0, 2));
            Assert.IsTrue(InserUser(bolao, "XX_2_1", 2, 1));
            Assert.IsTrue(InserUser(bolao, "XX_1_2", 1, 2));
            Assert.IsTrue(InserUser(bolao, "XX_2_2", 2, 2));
            Assert.IsTrue(InserUser(bolao, "XX_3_0", 3, 0));
            Assert.IsTrue(InserUser(bolao, "XX_3_1", 3, 1));
            Assert.IsTrue(InserUser(bolao, "XX_3_2", 3, 2));
            Assert.IsTrue(InserUser(bolao, "XX_0_3", 0, 3));
            Assert.IsTrue(InserUser(bolao, "XX_1_3", 1, 3));
            Assert.IsTrue(InserUser(bolao, "XX_2_3", 2, 3));
            Assert.IsTrue(InserUser(bolao, "XX_3_3", 3, 3));

            Business.Campeonatos.Support.Jogo jogoRes = new Business.Campeonatos.Support.Jogo(_currentUser);


            IList<Framework.DataServices.Model.EntityBaseData> jogos = campeonato.LoadJogos(1, null, null, DateTime.MinValue, DateTime.MinValue, null);

            int count1 = 0, count2 = 0;//, count1dir = 1, count2dir = 0;
            foreach (Model.Campeonatos.Jogo jogo in jogos)
            {
                jogoRes.Copy(jogo);

                jogoRes.InsertResult(count1, count2, 0, 0);


                if (count1 == count2)
                {
                    if (count1 <= 4)
                    {
                        count1++;
                    }
                    else
                    {
                        count1 = 0;
                        count2 = 0;
                    }
                }
                else
                {
                    count2++;
                }


            }
            jogos = campeonato.LoadJogos(2, null, null, DateTime.MinValue, DateTime.MinValue, null);
            foreach (Model.Campeonatos.Jogo jogo in jogos)
            {
                jogoRes.Copy(jogo);
                jogoRes.InsertResult(2, 1, 0, 0);
            }
            jogos = campeonato.LoadJogos(3, null, null, DateTime.MinValue, DateTime.MinValue, null);
            foreach (Model.Campeonatos.Jogo jogo in jogos)
            {
                jogoRes.Copy(jogo);
                jogoRes.InsertResult(1, 3, 0, 0);
            }
            jogos = campeonato.LoadJogos(4, null, null, DateTime.MinValue, DateTime.MinValue, null);
            foreach (Model.Campeonatos.Jogo jogo in jogos)
            {
                jogoRes.Copy(jogo);
                jogoRes.InsertResult(4, 0, 0, 0);
            }
            jogos = campeonato.LoadJogos(5, null, null, DateTime.MinValue, DateTime.MinValue, null);
            foreach (Model.Campeonatos.Jogo jogo in jogos)
            {
                jogoRes.Copy(jogo);
                jogoRes.InsertResult(2, 5, 0, 0);
            }
            jogos = campeonato.LoadJogos(6, null, null, DateTime.MinValue, DateTime.MinValue, null);
            foreach (Model.Campeonatos.Jogo jogo in jogos)
            {
                jogoRes.Copy(jogo);
                jogoRes.InsertResult(6, 5, 0, 0);
            }
            jogos = campeonato.LoadJogos(7, null, null, DateTime.MinValue, DateTime.MinValue, null);
            foreach (Model.Campeonatos.Jogo jogo in jogos)
            {
                jogoRes.Copy(jogo);
                jogoRes.InsertResult(1, 0, 0, 0);
            }




            jogos = campeonato.LoadJogos(0, null, null, DateTime.MinValue, DateTime.MinValue, "PendenteTime1PosGrupo > 0");
            foreach (Model.Campeonatos.Jogo jogo in jogos)
            {
                IList<Model.Campeonatos.CampeonatoClassificacao> grupo1 = 
                    campeonato.LoadClassificacao(new Model.Campeonatos.Fase( FaseClassificatoria), new Model.Campeonatos.Grupo( jogo.PendenteTime1NomeGrupo));


                Assert.IsNotNull(grupo1);
                Assert.AreEqual(4, grupo1.Count);

                for (int c = 0; c < grupo1.Count; c++)
                {
                    if (grupo1[c].Posicao == jogo.PendenteTime1PosGrupo)
                    {
                        Assert.AreEqual(jogo.Time1.Nome, grupo1[c].Time.Nome);
                        break;
                    }
                }


                IList<Model.Campeonatos.CampeonatoClassificacao> grupo2 =
                    campeonato.LoadClassificacao(new Model.Campeonatos.Fase(FaseClassificatoria), new Model.Campeonatos.Grupo(jogo.PendenteTime2NomeGrupo));



                Assert.IsNotNull(grupo2);
                Assert.AreEqual(4, grupo2.Count);

                for (int c = 0; c < grupo2.Count; c++)
                {
                    if (grupo2[c].Posicao == jogo.PendenteTime2PosGrupo)
                    {
                        Assert.AreEqual(jogo.Time2.Nome, grupo2[c].Time.Nome);
                        break;
                    }
                }
            
            
            }


            //Verificando se a chave está sendo montada de forma adequada
            jogos = campeonato.LoadJogos(0, null, null, DateTime.MinValue, DateTime.MinValue, "PendenteTime1JogoId > 0");
            foreach (Model.Campeonatos.Jogo jogo in jogos)
            {

                IList<Framework.DataServices.Model.EntityBaseData> checkJogo1 =
                    campeonato.LoadJogos(0, null, null, DateTime.MinValue, DateTime.MinValue, "idjogo = '" + jogo.PendenteIdTime1 + "'");

                Assert.IsNotNull(checkJogo1);
                Assert.AreEqual(1, checkJogo1.Count);


                IList<Framework.DataServices.Model.EntityBaseData> checkJogo2 =
                    campeonato.LoadJogos(0, null, null, DateTime.MinValue, DateTime.MinValue, "idjogo = '" + jogo.PendenteIdTime2 + "'");


                Assert.IsNotNull(checkJogo2);
                Assert.AreEqual(1, checkJogo2.Count);


                Model.Campeonatos.Jogo jogo1 = ((Model.Campeonatos.Jogo)checkJogo1[0]);
                Model.Campeonatos.Jogo jogo2 = ((Model.Campeonatos.Jogo)checkJogo2[0]);



                if (jogo.PendenteTime1Ganhador)
                {
                    if (jogo1.GolsTime1 >= jogo1.GolsTime2)
                    {
                        Assert.AreEqual(jogo.Time1.Nome, jogo1.Time1.Nome);
                    }
                    else
                    {
                        Assert.AreEqual(jogo.Time1.Nome, jogo1.Time2.Nome);
                    }

                }
                else
                {
                    if (jogo1.GolsTime1 >= jogo1.GolsTime2)
                    {
                        Assert.AreEqual(jogo.Time1.Nome, jogo1.Time2.Nome);
                    }
                    else
                    {
                        Assert.AreEqual(jogo.Time1.Nome, jogo1.Time1.Nome);
                    }

                }



                if (jogo.PendenteTime2Ganhador)
                {
                    if (jogo2.GolsTime1 >= jogo2.GolsTime2)
                    {
                        Assert.AreEqual(jogo.Time2.Nome, jogo2.Time1.Nome);
                    }
                    else
                    {
                        Assert.AreEqual(jogo.Time2.Nome, jogo2.Time2.Nome);
                    }

                }
                else
                {
                    if (jogo2.GolsTime1 >= jogo2.GolsTime2)
                    {
                        Assert.AreEqual(jogo.Time2.Nome, jogo2.Time2.Nome);
                    }
                    else
                    {
                        Assert.AreEqual(jogo.Time2.Nome, jogo2.Time1.Nome);
                    }

                }


            }



            Business.Boloes.Support.ApostaExtra extra = new Business.Boloes.Support.ApostaExtra(_currentUser);

            Business.Boloes.Support.JogoUsuario jogoUsuario = new Business.Boloes.Support.JogoUsuario(_currentUser);


            jogos = campeonato.LoadJogos(0, null, null, DateTime.MinValue, DateTime.MinValue, null);
            foreach (Model.Campeonatos.Jogo jogo in jogos)
            {

                jogoUsuario.Copy(jogo);

                IList<Framework.DataServices.Model.EntityBaseData> listApostas = jogoUsuario.LoadApostasByJogo(bolao, jogo, "Jogos.NomeCampeonato = '" + bolao.Campeonato.Nome + "' AND JogosUsuarios.NomeCampeonato = '" + bolao.Campeonato.Nome + "'");

                foreach (Model.Boloes.JogoUsuario aposta in listApostas)
                {
                    Assert.IsTrue(CheckJogo(jogo, aposta));
                }

            }





        }

        public void InsertUserTests(Business.Boloes.Support.Bolao bolao)
        {

            Assert.IsTrue(InserUser(bolao, "XX_0_0", 0, 0));
            Assert.IsTrue(InserUser(bolao, "XX_1_0", 1, 0));
            Assert.IsTrue(InserUser(bolao, "XX_0_1", 0, 1));
            Assert.IsTrue(InserUser(bolao, "XX_1_1", 1, 1));
            Assert.IsTrue(InserUser(bolao, "XX_2_0", 2, 0));
            Assert.IsTrue(InserUser(bolao, "XX_0_2", 0, 2));
            Assert.IsTrue(InserUser(bolao, "XX_2_1", 2, 1));
            Assert.IsTrue(InserUser(bolao, "XX_1_2", 1, 2));
            Assert.IsTrue(InserUser(bolao, "XX_2_2", 2, 2));
            Assert.IsTrue(InserUser(bolao, "XX_3_0", 3, 0));
            Assert.IsTrue(InserUser(bolao, "XX_3_1", 3, 1));
            Assert.IsTrue(InserUser(bolao, "XX_3_2", 3, 2));
            Assert.IsTrue(InserUser(bolao, "XX_0_3", 0, 3));
            Assert.IsTrue(InserUser(bolao, "XX_1_3", 1, 3));
            Assert.IsTrue(InserUser(bolao, "XX_2_3", 2, 3));
            Assert.IsTrue(InserUser(bolao, "XX_3_3", 3, 3));
        }
        private bool CheckJogo(Model.Campeonatos.Jogo jogo,  Model.Boloes.JogoUsuario jogoUsuario)
        {
            int value = 1;

            if (string.Compare(jogo.Time1.Nome, "Brasil", true) == 0 || string.Compare(jogo.Time2.Nome, "Brasil", true) == 0)            
                value = 2;


            int pontos = 0;

            //Aposta em cheio
            if (jogo.GolsTime1 == jogoUsuario.ApostaTime1 && jogo.GolsTime2 == jogoUsuario.ApostaTime2)
            {
                pontos = 10;
            }
            //Empate
            else if (jogo.GolsTime1 == jogo.GolsTime2 && jogoUsuario.ApostaTime1 == jogoUsuario.ApostaTime2)
            {
                pontos = 5;
            }
            //Time 1 Ganhador
            else if (jogo.GolsTime1 > jogo.GolsTime2 && jogoUsuario.ApostaTime1 > jogoUsuario.ApostaTime2)
               
            {
                pontos = 3;

                if (jogo.GolsTime1 == jogoUsuario.ApostaTime1)
                    pontos++;
                if (jogo.GolsTime2 == jogoUsuario.ApostaTime2)
                    pontos++;
            }
            //Time 2 Ganhador
            else if (jogo.GolsTime1 < jogo.GolsTime2 && jogoUsuario.ApostaTime1 < jogoUsuario.ApostaTime2)
            {
                pontos = 3;

                if (jogo.GolsTime1 == jogoUsuario.ApostaTime1)
                    pontos++;
                if (jogo.GolsTime2 == jogoUsuario.ApostaTime2)
                    pontos++;
            }
            else
            {
                if (jogo.GolsTime1 == jogoUsuario.ApostaTime1)
                    pontos++;
                if (jogo.GolsTime2 == jogoUsuario.ApostaTime2)
                    pontos++;
            }


            pontos *= value;

            Assert.AreEqual(jogoUsuario.Pontos, pontos);


            return true;
        }
        private bool InserUser(Business.Boloes.Support.Bolao bolao, string userName, int aposta1, int aposta2)
        {
            int errorNumber = 0;
            string errorDescription = "";

            Framework.Security.DataAccess.SQLSupport.UserDataDao userDao = new Framework.Security.DataAccess.SQLSupport.UserDataDao();


            //Verificando se o usuário corrente existe
            Framework.Security.DataAccess.SQLSupport.UserManagerDao managerUser = new Framework.Security.DataAccess.SQLSupport.UserManagerDao();
            Framework.Security.Model.UserData user = managerUser.GetUser(_currentUser, userName, false, false, out errorNumber, out errorDescription);
            Assert.AreEqual(0, errorNumber);
            Assert.AreEqual(null, errorDescription);
            Assert.IsNull(user);

            user = new Framework.Security.Model.UserData(_currentUser);
            user.UserName = userName;
            user.Email = userName + "@" + userName + ".com";

            System.Web.Security.MembershipCreateStatus status =
                userDao.CreateUser(_currentUser, user, System.Web.Security.MembershipPasswordFormat.Clear, 
                true, out errorNumber, out errorDescription);


            Assert.IsTrue(bolao.InsertMembro(user));


            Business.Boloes.Support.JogoUsuario jogo = new Business.Boloes.Support.JogoUsuario(_currentUser);
            IList<Framework.DataServices.Model.EntityBaseData> list = jogo.InsertApostasAuto(bolao, userName,
                Model.Boloes.JogoUsuario.TypeAposta.Todos, Model.Boloes.JogoUsuario.TypeAutomatico.Todos,
                DateTime.MinValue, DateTime.MinValue, 0, false, aposta1, aposta2, aposta1, aposta2, null);

            
            
            return true;
        }
        private bool InsertBolaoPontuacao(Business.Boloes.Support.Bolao bolao, int pontos, string titulo, string foreColor, string backColor)
        {
            int res = _db.ExecuteNonQuery(CommandType.Text,
                "INSERT INTO BoloesPontuacao (Pontos, Titulo, ForeColor, BackColor, NomeBolao)	VALUES (@Pontos, @Titulo,@ForeColor,@BackColor, @NomeBolao)", false, _currentUser,
                _db.Parameters.Create("Pontos", DbType.Int32, pontos),
                _db.Parameters.Create("Titulo", DbType.String, titulo),
                _db.Parameters.Create("ForeColor", DbType.String, foreColor),
                _db.Parameters.Create("BackColor", DbType.String, backColor),
                _db.Parameters.Create("NomeBolao", DbType.String, bolao.Nome));


            if (res == 1)
                return true;
            else
                return false;

        }
        private bool InsertBolaoPontos(Business.Boloes.Support.Bolao bolao, int criterioId, int pontos)
        {
            int res = _db.ExecuteNonQuery(CommandType.Text,
                "INSERT INTO BoloesCriteriosPontos (CriterioID, NomeBolao, Pontos) VALUES (@CriterioID, @NomeBolao, @Pontos)", false, _currentUser,
                _db.Parameters.Create("CriterioId", DbType.Int32, criterioId),
                _db.Parameters.Create("NomeBolao", DbType.String, bolao.Nome),
                _db.Parameters.Create("Pontos", DbType.Int32, pontos));

            if (res == 1)
                return true;

            else
                return false;

        }
        private bool InsertBolaoPremio(Business.Boloes.Support.Bolao bolao, int pos, string titulo, string backcolor, string forecolor)
        {
            int res =_db.ExecuteNonQuery(CommandType.Text, "INSERT INTO BoloesPremios (Posicao, NomeBolao, Titulo, BackColor, FOreColor) " +
                " VALUES (@Posicao, @NomeBolao, @Titulo, @BackColor, @ForeColor)", false, _currentUser,
                _db.Parameters.Create("Posicao", DbType.Int32, pos),
                _db.Parameters.Create("NomeBolao", DbType.String, bolao.Nome),
                _db.Parameters.Create("Titulo", DbType.String, titulo),
                _db.Parameters.Create("BackColor", DbType.String, backcolor),
                _db.Parameters.Create("ForeColor", DbType.String, forecolor));

            if (res == 1)
                return true;
            else
                return false;
        }
        private bool InsertCampeonatoPosicao(Business.Campeonatos.Support.Campeonato campeonato, IList<string[]> times)
        {
            int errorNumber =0 ;
            string errorDescription = "";

            char grupo = 'A';


            for (int c = 0; c < times.Count; c++)
            {
                string found = grupo.ToString();

                Assert.AreEqual(1, _db.ExecuteNonQuery(CommandType.Text, "INSERT INTO CampeonatosPosicoes (Posicao,Titulo,NomeCampeonato,BackColor,NomeFase,ForeColor,NomeGrupo) " +
                    "VALUES (@Posicao, @Titulo, @NomeCampeonato, @BackColor, @NomeFase, @ForeColor, @NomeGrupo)", false, _currentUser,
                    _db.Parameters.Create("Posicao", DbType.Int32, 1),
                    _db.Parameters.Create("Titulo", DbType.String, "Classificado"),
                    _db.Parameters.Create("NomeCampeonato", DbType.String, campeonato.Nome),
                    _db.Parameters.Create("BackColor", DbType.String, "Green"),
                    _db.Parameters.Create("NomeFase", DbType.String, FaseClassificatoria),
                    _db.Parameters.Create("ForeColor", DbType.String, "White"),
                    _db.Parameters.Create("NomeGrupo", DbType.String, found)));

                    Assert.AreEqual(0, errorNumber);
                

                Assert.AreEqual(1, _db.ExecuteNonQuery(CommandType.Text, "INSERT INTO CampeonatosPosicoes (Posicao,Titulo,NomeCampeonato,BackColor,NomeFase,ForeColor,NomeGrupo) " +
                    "VALUES (@Posicao, @Titulo, @NomeCampeonato, @BackColor, @NomeFase, @ForeColor, @NomeGrupo)", false, _currentUser,
                    _db.Parameters.Create("Posicao", DbType.Int32, 2),
                    _db.Parameters.Create("Titulo", DbType.String, "Classificado"),
                    _db.Parameters.Create("NomeCampeonato", DbType.String, campeonato.Nome),
                    _db.Parameters.Create("BackColor", DbType.String, "Green"),
                    _db.Parameters.Create("NomeFase", DbType.String, FaseClassificatoria),
                    _db.Parameters.Create("ForeColor", DbType.String, "White"),
                    _db.Parameters.Create("NomeGrupo", DbType.String, found)));

                Assert.AreEqual(0, errorNumber);
                

                grupo = (char)((int)grupo + 1);

            }

            return true;
        }
        private int SearchIdJogo(Business.Campeonatos.Support.Campeonato campeonato, int jogoId)
        {
            object result = _db.ExecuteScalar(CommandType.Text, 
                "SELECT IdJogo FROM Jogos WHERE NomeCampeonato = @NomeCampeonato AND JogoLabel = @JogoLabel", false, _currentUser,
                _db.Parameters.Create("@NomeCampeonato", DbType.String, campeonato.Nome),
                _db.Parameters.Create("@JogoLabel", DbType.String, jogoId.ToString ())
                );

            if (result == null)
                return 0;
            else
                return int.Parse(result.ToString());

        }
        private bool InsertJogo(Business.Campeonatos.Support.Campeonato campeonato, int rodada, string fase, DateTime dataJogo,
            string labelJogo, string descricaoTime1, string descricaoTime2,
            int pendenteTime1JogoId, int pendenteTime1Ganhador, int pendenteTime2JogoId, int pendenteTime2Ganhador)
        {

            int idTime1 = SearchIdJogo(campeonato, pendenteTime1JogoId);
            int idTime2 = SearchIdJogo(campeonato, pendenteTime2JogoId);

            Assert.AreNotEqual(0, idTime1);
            Assert.AreNotEqual(0, idTime2);


            return InsertJogo(campeonato, rodada, fase, 0, DateTime.Now, null, null, labelJogo,
                descricaoTime1, null, 0, idTime1, pendenteTime1Ganhador,
                descricaoTime2, null, 0, idTime2, pendenteTime2Ganhador);


        }
        private bool InsertJogo(Business.Campeonatos.Support.Campeonato campeonato, int rodada, string fase, int jogoId, DateTime dataJogo,
            string labelJogo, string descricaoTime1, string descricaoTime2,
            int pendenteTime1JogoId, int pendenteTime1Ganhador, int pendenteTime2JogoId, int pendenteTime2Ganhador)
        {
            return InsertJogo(campeonato, rodada, fase, jogoId, dataJogo,
                null, null, labelJogo,
                descricaoTime1, null, 0, pendenteTime1JogoId, pendenteTime1Ganhador ,
                descricaoTime2, null, 0, pendenteTime2JogoId, pendenteTime2Ganhador);

        }
        private bool InsertJogo(Business.Campeonatos.Support.Campeonato campeonato, int rodada, string fase, int jogoId, DateTime dataJogo,
            string labelJogo, string descricaoTime1, string descricaoTime2,
            string pendenteTime1NomeGrupo, int pendenteTime1PosGrupo, string pendenteTime2NomeGrupo, int pendenteTime2PosGrupo)
        {
            return InsertJogo(campeonato, rodada, fase, jogoId, dataJogo,
                null, null, labelJogo,
                descricaoTime1, pendenteTime1NomeGrupo, pendenteTime1PosGrupo, 0, 0,
                descricaoTime2, pendenteTime2NomeGrupo, pendenteTime2PosGrupo, 0, 0);

        }
        private bool InsertJogo(Business.Campeonatos.Support.Campeonato campeonato, int rodada, string fase, int jogoId, DateTime dataJogo,
            string local, string titulo, string labelJogo,
            string descricaoTime1, string pendenteTime1NomeGrupo, int pendenteTime1PosGrupo, int pendenteTime1JogoId, int pendenteTime1Ganhador,
            string descricaoTime2, string pendenteTime2NomeGrupo, int pendenteTime2PosGrupo, int pendenteTime2JogoId, int pendenteTime2Ganhador)
        {

            

            
            string query =
            "INSERT INTO Jogos " +
            "    (NomeCampeonato, NomeFase, NomeEstadio, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2," +
            "     Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, " +
            "     PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel, IsValido)" +
            " VALUES " +
            "    (@NomeCampeonato, @NomeFase, @NomeEstadio, @Rodada, @NomeGrupo, @DescricaoTime1, @DescricaoTime2, " +
            "     @Titulo, @PendenteTime1NomeGrupo, @PendenteTime1PosGrupo, @PendenteTime1JogoID, @PendenteTime1Ganhador," +
            "     @PendenteTime2NomeGrupo, @PendenteTime2PosGrupo, @PendenteTime2JogoID, @PendenteTime2Ganhador, @JogoLabel, 0)";


            int res = _db.ExecuteNonQuery(CommandType.Text, query, false, _currentUser,
                _db.Parameters.Create("@NomeCampeonato", DbType.String, campeonato.Nome),
                _db.Parameters.Create("@NomeFase", DbType.String, fase),
                _db.Parameters.Create("@NomeEstadio", DbType.String, string.IsNullOrEmpty(local) ? null : local),
                _db.Parameters.Create("@Rodada", DbType.Int32, rodada),
                _db.Parameters.Create("@NomeGrupo", DbType.String, " "),
                _db.Parameters.Create("@DescricaoTime1", DbType.String, descricaoTime1),
                _db.Parameters.Create("@DescricaoTime2", DbType.String, descricaoTime2),
                _db.Parameters.Create("@Titulo", DbType.String, titulo),
                _db.Parameters.Create("@PendenteTime1NomeGrupo", DbType.String, pendenteTime1NomeGrupo),
                _db.Parameters.Create("@PendenteTime1PosGrupo", DbType.Int32, pendenteTime1PosGrupo),
                _db.Parameters.Create("@PendenteTime1JogoID", DbType.Int32, pendenteTime1JogoId),
                _db.Parameters.Create("@PendenteTime1Ganhador", DbType.Int32, pendenteTime1Ganhador),
                _db.Parameters.Create("@PendenteTime2NomeGrupo", DbType.String, pendenteTime2NomeGrupo),
                _db.Parameters.Create("@PendenteTime2PosGrupo", DbType.String, pendenteTime2PosGrupo),
                _db.Parameters.Create("@PendenteTime2JogoID", DbType.String, pendenteTime2JogoId),
                _db.Parameters.Create("@PendenteTime2Ganhador", DbType.String, pendenteTime2Ganhador),
                _db.Parameters.Create("@JogoLabel", DbType.String, labelJogo));


            if (res == 1)
                return true;
            else
                return false;

        }
        private bool InsertJogo(Business.Campeonatos.Support.Campeonato campeonato, int rodada, string fase, string grupo, int jogoId, DateTime dataJogo, string local, string time1, string time2)
        {
            
            Business.Campeonatos.Support.Jogo jogo = new Business.Campeonatos.Support.Jogo(_currentUser);
            jogo.Campeonato = campeonato;
            jogo.DataJogo = dataJogo;
            if (string.IsNullOrEmpty(local))
                jogo.Estadio = null;
            else
                jogo.Estadio = new Model.DadosBasicos.Estadio(local);
            jogo.Fase = new Model.Campeonatos.Fase(fase);
            jogo.Grupo = new Model.Campeonatos.Grupo(grupo);
            jogo.JogoLabel = jogoId.ToString ();
            jogo.Rodada = rodada;
            jogo.Time1 = new Model.DadosBasicos.Time(time1);
            jogo.Time2 = new Model.DadosBasicos.Time(time2);

            Assert.IsTrue(jogo.Insert());


            return true;
        }
        private bool InsertCampeonatoTimes(Business.Campeonatos.Support.Campeonato campeonato, IList<string[]> times)
        {

            IList<Framework.DataServices.Model.EntityBaseData> list =  campeonato.LoadTimes();


            for (int c = 0; c < times.Count; c++)
            {

                for (int l = 0; l < times[c].Length; l++)
                {
                    Assert.IsFalse(IsTimeExistsInCampeonato(times[c][l], list));


                    Model.DadosBasicos.Time time = new Model.DadosBasicos.Time(times[c][l]);                    
                    Assert.IsTrue(campeonato.InsertTime(time));

                }

            }

            return true;
        }
        private bool IsTimeExistsInCampeonato(string timeSearch, IList<Framework.DataServices.Model.EntityBaseData> list)
        {
            foreach (Model.DadosBasicos.Time time in list)
            {
                if (string.Compare(timeSearch, time.Nome, true) == 0)
                {
                    return true;
                }
            }
            return false;
        }
        private bool InsertTimesGrupos(Business.Campeonatos.Support.Campeonato campeonato, IList<string[]> times)
        {
            int errorNumber = 0;
            string errorDescription = "";
            IList<Framework.DataServices.Model.EntityBaseData> list = campeonato.LoadGrupos();

            Dao.Campeonatos.SQLSupport.Grupo grupoMng = new Dao.Campeonatos.SQLSupport.Grupo();
            


            char grupo = 'A';

            for (int c = 0; c < times.Count; c++)
            {
                string found = grupo.ToString();

                for (int l = 0; l < times[c].Length; l++)
                {
                    Assert.IsTrue( grupoMng.InsertTime(_currentUser, campeonato, new Model.Campeonatos.Grupo(found), new Model.DadosBasicos.Time(times[c][l]), out errorNumber, out errorDescription));        
                    
                }

                grupo = (char)((int)grupo + 1);
            }




            return true;
        }
        private bool IsTimeExistsInGrupo(string grupoSearch, IList<Framework.DataServices.Model.EntityBaseData> list)
        {
            foreach (Model.Campeonatos.Grupo grupo in list)
            {
                if (string.Compare(grupoSearch, grupo.Nome, true) == 0)
                {
                    return true;
                }
            }
            return false;
        }
        private bool InsertTimes(IList<string[]> times)
        {
            for (int c = 0; c < times.Count; c++)
            {

                for (int l = 0; l < times[c].Length; l++)
                {
                    InsertTime(times[c][l]);

                }

            }

            return true;

        }
        private bool InsertTime(string time)
        {
            IDataReader reader = _db.ExecuteReader(CommandType.Text, "SELECT * FROM TIMES WHERE Nome = @Nome", false, _currentUser, false,
                _db.Parameters.Create("@Nome", DbType.String, time));

            try
            {
                if (reader.Read())
                {
                    return false;
                }

            }
            finally
            {
                _db.Close();
            }


            int result = _db.ExecuteNonQuery(CommandType.Text, "INSERT INTO Times (Nome) VALUES (@Nome)", false, _currentUser, false,
                _db.Parameters.Create("@Nome", DbType.String, time));

            if (result == 1)
                return true;
            else
                return false;

        }
        private bool InsertGrupo(Business.Campeonatos.Support.Campeonato campeonato,
            string grupo, IList<Framework.DataServices.Model.EntityBaseData> list)
        {
            Assert.IsFalse(IsGrupoExists(grupo, list));

            Model.Campeonatos.Grupo grupoModel = new Model.Campeonatos.Grupo();
            grupoModel.Nome = grupo;
            grupoModel.Campeonato = new Model.Campeonatos.Campeonato(campeonato.Nome);

            Assert.IsTrue(campeonato.InsertGrupo(grupoModel));

            return true;
        }
        private bool InsertFase(Business.Campeonatos.Support.Campeonato campeonato, 
            string fase, IList<Framework.DataServices.Model.EntityBaseData> list)
        {

            Assert.IsFalse(IsFaseExists(fase, list));

            Model.Campeonatos.Fase faseModel = new Model.Campeonatos.Fase();
            faseModel.Nome = fase;
            faseModel.Campeonato = new Model.Campeonatos.Campeonato(campeonato.Nome);

            Assert.IsTrue(campeonato.InsertFase(faseModel));

            return true;

        }
        private bool IsFaseExists(string faseSearch, IList<Framework.DataServices.Model.EntityBaseData> list)
        {
            foreach (Model.Campeonatos.Fase fase in list)
            {
                if (string.Compare(faseSearch, fase.Nome, true) == 0)
                    return true;
            }

            return false;
        }
        private bool IsGrupoExists(string grupoSearch, IList<Framework.DataServices.Model.EntityBaseData> list)
        {
            foreach (Model.Campeonatos.Grupo grupo in list)
            {
                if (string.Compare(grupoSearch, grupo.Nome, true) == 0)
                    return true;
            }

            return false;
        }

        #endregion
    }
}
