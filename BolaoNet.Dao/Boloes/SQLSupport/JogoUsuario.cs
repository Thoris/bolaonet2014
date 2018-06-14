using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BolaoNet.Dao.Boloes.SQLSupport
{
    public class JogoUsuario : Framework.DataServices.ItemPaging, IDaoJogoUsuario
    {
        #region Constants
        public new const string TableName = "JogosUsuarios";


        #endregion

        #region Constructors/Destructors
        public JogoUsuario()
            : base (TableName)
        {
        }

        public JogoUsuario(string connectionName)
            : base (connectionName, TableName)
        {
        }

        public JogoUsuario(string connectionName, string connectionString, string providerName)
            : base(connectionName, connectionString, providerName, TableName)
        {
        }    
        
        #endregion

        #region Methods
        public static IList<Framework.DataServices.Model.EntityBaseData> ConvertToList(DataTable table)
        {
            IList<Framework.DataServices.Model.EntityBaseData> list = new List<Framework.DataServices.Model.EntityBaseData>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(ConvertToObject(row));
            }

            return list;
        }
        public static Model.Boloes.ApostaPontos ConvertApostasToObject(DataRow row)
        {
            Model.Boloes.ApostaPontos entry = new Model.Boloes.ApostaPontos();

            if (row.Table.Columns.Contains("Pontos") && !Convert.IsDBNull(row["Pontos"]))
            {
                entry.Pontos = Convert.ToInt32(row["Pontos"]);
            }
            if (row.Table.Columns.Contains("IsEmpate") && !Convert.IsDBNull(row["IsEmpate"]))
            {
                entry.IsEmpate = Convert.ToBoolean(row["IsEmpate"]);
            }
            if (row.Table.Columns.Contains("IsVitoria") && !Convert.IsDBNull(row["IsVitoria"]))
            {
                entry.IsVitoria = Convert.ToBoolean(row["IsVitoria"]);
            }
            if (row.Table.Columns.Contains("IsGolsGanhador") && !Convert.IsDBNull(row["IsGolsGanhador"]))
            {
                entry.IsGolsGanhador = Convert.ToBoolean(row["IsGolsGanhador"]);
            }
            if (row.Table.Columns.Contains("IsGolsPerdedor") && !Convert.IsDBNull(row["IsGolsPerdedor"]))
            {
                entry.IsGolsPerdedor = Convert.ToBoolean(row["IsGolsPerdedor"]);
            }
            if (row.Table.Columns.Contains("IsResultTime1") && !Convert.IsDBNull(row["IsResultTime1"]))
            {
                entry.IsResultTime1 = Convert.ToBoolean(row["IsResultTime1"]);
            }
            if (row.Table.Columns.Contains("IsResultTime2") && !Convert.IsDBNull(row["IsResultTime2"]))
            {
                entry.IsResultTime2 = Convert.ToBoolean(row["IsResultTime2"]);
            }
            if (row.Table.Columns.Contains("IsVDE") && !Convert.IsDBNull(row["IsVDE"]))
            {
                entry.IsVDE = Convert.ToBoolean(row["IsVDE"]);
            }
            if (row.Table.Columns.Contains("IsErro") && !Convert.IsDBNull(row["IsErro"]))
            {
                entry.IsErro = Convert.ToBoolean(row["IsErro"]);
            }
            if (row.Table.Columns.Contains("IsGolsGanhadorFora") && !Convert.IsDBNull(row["IsGolsGanhadorFora"]))
            {
                entry.IsGolsGanhadorFora = Convert.ToBoolean(row["IsGolsGanhadorFora"]);
            }
            if (row.Table.Columns.Contains("IsGolsGanhadorDentro") && !Convert.IsDBNull(row["IsGolsGanhadorDentro"]))
            {
                entry.IsGolsGanhadorDentro = Convert.ToBoolean(row["IsGolsGanhadorDentro"]);
            }
            if (row.Table.Columns.Contains("IsGolsPerdedorFora") && !Convert.IsDBNull(row["IsGolsPerdedorFora"]))
            {
                entry.IsGolsPerdedorFora = Convert.ToBoolean(row["IsGolsPerdedorFora"]);
            }
            if (row.Table.Columns.Contains("IsGolsPerdedorDentro") && !Convert.IsDBNull(row["IsGolsPerdedorDentro"]))
            {
                entry.IsGolsPerdedorDentro = Convert.ToBoolean(row["IsGolsPerdedorDentro"]);
            }
            if (row.Table.Columns.Contains("IsGolsEmpate") && !Convert.IsDBNull(row["IsGolsEmpate"]))
            {
                entry.IsGolsEmpate = Convert.ToBoolean(row["IsGolsEmpate"]);
            }
            if (row.Table.Columns.Contains("IsGolsTime1") && !Convert.IsDBNull(row["IsGolsTime1"]))
            {
                entry.IsGolsTime1 = Convert.ToBoolean(row["IsGolsTime1"]);
            }
            if (row.Table.Columns.Contains("IsGolsTime2") && !Convert.IsDBNull(row["IsGolsTime2"]))
            {
                entry.IsGolsTime2 = Convert.ToBoolean(row["IsGolsTime2"]);
            }
            if (row.Table.Columns.Contains("IsPlacarCheio") && !Convert.IsDBNull(row["IsPlacarCheio"]))
            {
                entry.IsPlacarCheio = Convert.ToBoolean(row["IsPlacarCheio"]);
            }
            if (row.Table.Columns.Contains("IsMultiploTime") && !Convert.IsDBNull(row["IsMultiploTime"]))
            {
                entry.IsMultiploTime = Convert.ToBoolean(row["IsMultiploTime"]);
            }

            if (row.Table.Columns.Contains("MultiploTime") && !Convert.IsDBNull(row["MultiploTime"]))
            {
                entry.MultiploTime = Convert.ToInt32(row["MultiploTime"]);
            }
            return entry;
        }

        public static Framework.DataServices.Model.EntityBaseData ConvertToObject(DataRow row)
        {
            long idJogo = 0;
            string userName = string.Empty;
            string nomeBolao = string.Empty;
            string nomeCampeonato = string.Empty;


            Model.Campeonatos.Jogo jogo = (Model.Campeonatos.Jogo)Dao.Campeonatos.Util.Jogo.ConvertToObject(row);

            

            if (row.Table.Columns.Contains("IDJogo") && !Convert.IsDBNull(row["IDJogo"]))
            {
                idJogo = Convert.ToInt64(row["IDJogo"]);
            }
            if (row.Table.Columns.Contains("NomeCampeonato") && !Convert.IsDBNull(row["NomeCampeonato"]))
            {
                nomeCampeonato  = Convert.ToString(row["NomeCampeonato"]);
            }

            if (row.Table.Columns.Contains("IDJogoItem") && !Convert.IsDBNull(row["IDJogoItem"]))
            {
                idJogo = Convert.ToInt64(row["IDJogoItem"]);
            }
            if (row.Table.Columns.Contains("NomeCampeonatoItem") && !Convert.IsDBNull(row["NomeCampeonatoItem"]))
            {
                nomeCampeonato = Convert.ToString(row["NomeCampeonatoItem"]);
            }


            if (row.Table.Columns.Contains("NomeBolao") && !Convert.IsDBNull(row["NomeBolao"]))
            {
                nomeBolao = Convert.ToString(row["NomeBolao"]);
            }
            if (row.Table.Columns.Contains("UserName") && !Convert.IsDBNull(row["UserName"]))
            {
                userName = Convert.ToString(row["UserName"]);
            }
            Model.Boloes.JogoUsuario entry = new BolaoNet.Model.Boloes.JogoUsuario(
                idJogo, nomeCampeonato, nomeBolao, userName);
            entry.LoadDataRow(row);
            entry.Copy(jogo);
            

            if (row.Table.Columns.Contains("DataAposta") && !Convert.IsDBNull(row["DataAposta"]))
            {
                entry.DataAposta = Convert.ToDateTime(row["DataAposta"]);
            }

            if (row.Table.Columns.Contains("Automatico") && !Convert.IsDBNull(row["Automatico"]))
            {
                entry.Automatico = Convert.ToBoolean(row["Automatico"]);
            }
            if (row.Table.Columns.Contains("ApostaTime1") && !Convert.IsDBNull(row["ApostaTime1"]))
            {
                entry.ApostaTime1 = Convert.ToInt32(row["ApostaTime1"]);
            }
            if (row.Table.Columns.Contains("ApostaTime2") && !Convert.IsDBNull(row["ApostaTime2"]))
            {
                entry.ApostaTime2 = Convert.ToInt32(row["ApostaTime2"]);
            }

            if (row.Table.Columns.Contains("NomeTimeResult1") && !Convert.IsDBNull(row["NomeTimeResult1"]))
            {
                entry.NomeTimeResult1 = new Model.DadosBasicos.Time (Convert.ToString(row["NomeTimeResult1"]));
            }


            if (row.Table.Columns.Contains("NomeTimeResult2") && !Convert.IsDBNull(row["NomeTimeResult2"]))
            {
                entry.NomeTimeResult2 = new Model.DadosBasicos.Time(Convert.ToString(row["NomeTimeResult2"]));
            }
            if (row.Table.Columns.Contains("Ganhador") && !Convert.IsDBNull(row["Ganhador"]))
            {
                entry.Ganhador = Convert.ToInt32(row["Ganhador"]);
            }
            if (row.Table.Columns.Contains("DataFacebook") && !Convert.IsDBNull(row["DataFacebook"]))
            {
                entry.DataFacebook = Convert.ToDateTime(row["DataFacebook"]);
            }

            ((Model.Boloes.JogoUsuario)entry).ApostaPontos = ConvertApostasToObject(row);

            return entry;

        }
        #endregion

        #region IDaoBase Members

        public Framework.DataServices.Model.EntityBaseData Load(string currentUser, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.Boloes.JogoUsuario entryData = (Model.Boloes.JogoUsuario)entry;


            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, base._commandSelect, true, currentUser,
                base.Parameters.Create("@IDJogo", DbType.String, entryData.IDJogo),
                base.Parameters.Create("@NomeCampeonato", DbType.String, entryData.Campeonato.Nome),
                base.Parameters.Create("@UserName", DbType.String, entryData.UserName),
                base.Parameters.Create("@NomeBolao", DbType.String, entryData.Bolao.Nome),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            int rowsFound = Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value);

            if (rowsFound == 0)
                return null;
            //throw new Exception("There is no item found in database with this ID.");


            return ConvertToObject(table.Rows[0]);
        }
        public bool Insert(string currentUser, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.Boloes.JogoUsuario entryData = (Model.Boloes.JogoUsuario)entry;

            base.ExecuteNonQuery(CommandType.StoredProcedure, base._commandInsert, true, currentUser,
                base.Parameters.Create("@IDJogo", DbType.String, entryData.IDJogo),
                base.Parameters.Create("@NomeCampeonato", DbType.String, entryData.Campeonato.Nome),
                base.Parameters.Create("@UserName", DbType.String, entryData.UserName),
                base.Parameters.Create("@NomeBolao", DbType.String, entryData.Bolao.Nome),
                base.Parameters.Create("@Automatico", DbType.Boolean, entryData.Automatico),
                base.Parameters.Create("@ApostaTime1", DbType.Int16, entryData.ApostaTime1),
                base.Parameters.Create("@ApostaTime2", DbType.Int16, entryData.ApostaTime2),
                base.Parameters.Create("@Ganhador", DbType.Int16, entryData.Ganhador),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );


            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) == 1 ? true : false;
        }
        public bool Update(string currentUser, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.Boloes.JogoUsuario entryData = (Model.Boloes.JogoUsuario)entry;

            return Insert(currentUser, entryData, out errorNumber, out errorDescription) ;
        }
        public bool Delete(string currentUser, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.Boloes.JogoUsuario entryData = (Model.Boloes.JogoUsuario)entry;

            base.ExecuteNonQuery(CommandType.StoredProcedure, base._commandDelete, true, currentUser,
                base.Parameters.Create("@IDJogo", DbType.String, entryData.IDJogo),
                base.Parameters.Create("@NomeCampeonato", DbType.String, entryData.Campeonato.Nome),
                base.Parameters.Create("@UserName", DbType.String, entryData.UserName),
                base.Parameters.Create("@NomeBolao", DbType.String, entryData.Bolao.Nome),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );


            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) >= 1 ? true : false;
        }
        public IList<Framework.DataServices.Model.EntityBaseData> SelectAll(string currentUser, string condition, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, base._commandSelectAll, true, currentUser,
                base.Parameters.Create("@Condition", DbType.String, condition),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            return ConvertToList(table);
        }
        public IList<Framework.DataServices.Model.EntityBaseData> SelectPage(string currentUser, string condition, string order, int pageNumber, int pageSize, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            return ConvertToList(
                base.GetPage(null, condition, order, pageNumber, pageSize,
                true, currentUser, out errorNumber, out errorDescription));
        }
        public int SelectCount(string currentUser, string condition, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            return base.GetCount(condition,
                true, currentUser,
                out errorNumber, out errorDescription);
        }
        public IList<Framework.DataServices.Model.EntityBaseData> SelectCombo(string currentUser, out int errorNumber, out string errorDescription, params object[] fields)
        {
            errorNumber = 0;
            errorDescription = null;

            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, base._commandSelectCombo, true, currentUser,
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            return ConvertToList(table);
        }
        
        public IList<Framework.DataServices.Model.EntityBaseData> LoadApostas(string currentUser, int rodada, BolaoNet.Model.Boloes.Bolao bolao, DateTime dataInicial, DateTime dataFinal, string userName, string time, string fase, string grupo, string condition, out int errorNumber, out string errorDescription)
        {
            if (string.IsNullOrEmpty(time))
                time = null;
            if (string.IsNullOrEmpty(fase))
                fase = null;
            if (string.IsNullOrEmpty(grupo))
                grupo = null;


            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, "sp_JogosUsuarios_Apostas", true, currentUser,
                 base.Parameters.Create("@UserName", DbType.String, userName),
                 base.Parameters.Create("@NomeBolao", DbType.String, bolao.Nome),
                 base.Parameters.Create("@Rodada", DbType.Int32, rodada),
                 base.Parameters.Create("@DataInicial", DbType.DateTime, dataInicial),
                 base.Parameters.Create("@DataFinal", DbType.DateTime, dataFinal),
                 base.Parameters.Create("@NomeTime", DbType.String, time),
                 base.Parameters.Create("@NomeFase", DbType.String, fase),
                 base.Parameters.Create("@NomeGrupo", DbType.String, grupo),
                 base.Parameters.Create("@Condition", DbType.String, condition),                 
                 base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                 );


            IList<Framework.DataServices.Model.EntityBaseData> list = ConvertToList(table);

            errorNumber = base.ExecutionStatus.ErrorNumber;
            errorDescription = base.ExecutionStatus.ErrorDescription;

            return list;

           
        }
        public long LoadCount(string currentUser, int rodada, BolaoNet.Model.Boloes.Bolao bolao, DateTime dataInicial, DateTime dataFinal, string userName, string condition, BolaoNet.Model.Boloes.JogoUsuario.TypeAposta typeAposta, BolaoNet.Model.Boloes.JogoUsuario.TypeAutomatico typeAutomatico, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;


            base.ExecuteNonQuery(CommandType.StoredProcedure, "sp_Jogos_Count_By_Period", true, currentUser,
               base.Parameters.Create("@UserName", DbType.String, userName),
                base.Parameters.Create("@NomeBolao", DbType.String, bolao.Nome),
                base.Parameters.Create("@TypeAposta", DbType.Int16, (int)typeAposta),
                base.Parameters.Create("@TypeAutomatico", DbType.Int16, (int)typeAutomatico),
                base.Parameters.Create("@DataInicial", DbType.DateTime, dataInicial),
                base.Parameters.Create("@DataFinal", DbType.DateTime, dataFinal),
                base.Parameters.Create("@Rodada", DbType.Int16, (int)rodada),
                base.Parameters.Create("@Condition", DbType.String, condition),
                base.Parameters.Create("@TotalRows", DbType.Int64, ParameterDirection.Output, null),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );


            return Convert.ToInt64(base.ExecutionStatus.Command.Parameters["@TotalRows"].Value);
        }
        public IList<Framework.DataServices.Model.EntityBaseData> LoadApostasByJogo(string currentUser, BolaoNet.Model.Boloes.Bolao bolao, BolaoNet.Model.Campeonatos.Jogo jogo, string condition, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            string conditionCheck = condition;

            if (!string.IsNullOrEmpty(conditionCheck))
            {
                conditionCheck = conditionCheck + " AND Jogos.NomeCampeonato='" + jogo.Campeonato.Nome + "' AND Jogos.IDJogo=" + jogo.IDJogo;
            }
            else
            {
                conditionCheck = "Jogos.NomeCampeonato='" + jogo.Campeonato.Nome + "' AND Jogos.IDJogo=" + jogo.IDJogo;
            }




            return SelectAll(currentUser, conditionCheck, out errorNumber, out errorDescription);

        }
        public long LoadApostasCountByJogo(string currentUser, BolaoNet.Model.Boloes.Bolao bolao, BolaoNet.Model.Campeonatos.Jogo jogo, string condition, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            string conditionCheck = condition;

            if (!string.IsNullOrEmpty(conditionCheck))
            {
                conditionCheck = conditionCheck + " AND Jogos.NomeCampeonato='" + jogo.Campeonato.Nome + "' AND Jogos.IDJogo=" + jogo.IDJogo;
            }

            return SelectCount(currentUser, conditionCheck, out errorNumber, out errorDescription);
        }

        public IList<Framework.DataServices.Model.EntityBaseData> InsertApostasAuto(string currentUser, BolaoNet.Model.Boloes.Bolao bolao, string userName, BolaoNet.Model.Boloes.JogoUsuario.TypeAposta typeAposta, BolaoNet.Model.Boloes.JogoUsuario.TypeAutomatico typeAutomatico, DateTime dataInicial, DateTime dataFinal, int rodada, bool random, int time1, int time2, int randomInicial, int randomFinal, string nomeTime, out int errorNumber, out string errorDescription)
        {
            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, "sp_JogosUsuarios_ApostasAutomatica", true, currentUser,
             base.Parameters.Create("@UserName", DbType.String, userName),
             base.Parameters.Create("@NomeBolao", DbType.String, bolao.Nome),
             base.Parameters.Create("@TipoAutomatico", DbType.Int32, (int)typeAutomatico),
             base.Parameters.Create("@TipoAposta", DbType.Int32, (int)typeAposta ),
             base.Parameters.Create("@Rodada", DbType.Int32, rodada),
             base.Parameters.Create("@DataInicial", DbType.DateTime, dataInicial),
             base.Parameters.Create("@DataFinal", DbType.DateTime, dataFinal),
             base.Parameters.Create("@NomeTime", DbType.String, nomeTime),
             base.Parameters.Create("@GolsTime1", DbType.Int32, time1),
             base.Parameters.Create("@GolsTime2", DbType.Int32, time2),
             base.Parameters.Create("@RandomInicial", DbType.Int32, randomInicial),
             base.Parameters.Create("@RandomFinal", DbType.Int32, randomFinal),
             base.Parameters.Create("@Randomizado", DbType.Boolean, random),
             base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
             );


            IList<Framework.DataServices.Model.EntityBaseData> list = ConvertToList(table);

            errorNumber = base.ExecutionStatus.ErrorNumber;
            errorDescription = base.ExecutionStatus.ErrorDescription;

            return list;
        }


        public IList<BolaoNet.Model.Campeonatos.CampeonatoClassificacao> LoadClassificacao(string currentUser, BolaoNet.Model.Boloes.Bolao bolao, BolaoNet.Model.Campeonatos.Fase fase, BolaoNet.Model.Campeonatos.Grupo grupo, Framework.Security.Model.UserData user, out int errorNumber, out string errorDescription)
        {

            errorNumber = 0;
            errorDescription = null;

            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, "sp_JogosUsuarios_Apostas_Classificacao", true, currentUser,
                base.Parameters.Create("@UserName", DbType.String, user.UserName),
                base.Parameters.Create("@NomeBolao", DbType.String, bolao.Nome),
                base.Parameters.Create("@NomeFase", DbType.String, fase.Nome),
                base.Parameters.Create("@NomeGrupo", DbType.String, grupo.Nome),                
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );


            return Dao.Campeonatos.Util.CampeonatoClassificacao.ConvertToClassificacaoList(table);
        }

        public IList<Framework.DataServices.Model.EntityBaseData> LoadAcertosDificeis(string currentUser, Model.Boloes.Bolao bolao, int totalPessoas, out int errorNumber, out string errorDescription)
        {


            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, "sp_JogosUsuarios_Load_Acertos_Dificeis", true, currentUser,
                 base.Parameters.Create("@NomeBolao", DbType.String, bolao.Nome),
                 base.Parameters.Create("@TotalAcertos", DbType.Int32, totalPessoas),                 
                 base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                 );


            IList<Framework.DataServices.Model.EntityBaseData> list = ConvertToList(table);

            errorNumber = base.ExecutionStatus.ErrorNumber;
            errorDescription = base.ExecutionStatus.ErrorDescription;

            return list;
        }
        
        public void CorrecaoEliminatorias(string currentUser, Model.Boloes.Bolao bolao, string userName, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;


            base.ExecuteNonQuery(CommandType.StoredProcedure, "sp_JogosUsuarios_CorrecaoEliminatorias", true, currentUser,
               base.Parameters.Create("@UserName", DbType.String, userName),
                base.Parameters.Create("@NomeBolao", DbType.String, bolao.Nome),
                base.Parameters.Create("@NomeCampeonato", DbType.String, bolao.Campeonato.Nome),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

        }

        public IList<Model.Boloes.JogoUsuario> LoadSocialNetwork(string currentUser, Model.Boloes.Bolao bolao, string userName, Model.Campeonatos.Jogo jogo, out int errorNumber, out string errorDescription)
        {

            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, "sp_JogosUsuarios_Social_DT", true, currentUser,
                 base.Parameters.Create("@NomeBolao", DbType.String, bolao.Nome),
                 base.Parameters.Create("@Username", DbType.String, userName),
                 base.Parameters.Create("@IdJogo", DbType.Int32, jogo.IDJogo),
                 base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                 );


            IList<Framework.DataServices.Model.EntityBaseData> list = ConvertToList(table);

            IList<Model.Boloes.JogoUsuario> jogos = new List<Model.Boloes.JogoUsuario>();

            foreach (Model.Boloes.JogoUsuario jogoEntry in list)
            {
                jogos.Add(jogoEntry);
            }

            errorNumber = base.ExecutionStatus.ErrorNumber;
            errorDescription = base.ExecutionStatus.ErrorDescription;

            return jogos;
        }

        public bool UpdateFacebook(string currentUser, Model.Boloes.Bolao bolao, string userName, Model.Campeonatos.Jogo jogo, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;


            base.ExecuteNonQuery(CommandType.StoredProcedure, "sp_JogosUsuarios_Social_Facebook_UP", true, currentUser,
                base.Parameters.Create("@UserName", DbType.String, userName),
                base.Parameters.Create("@NomeBolao", DbType.String, bolao.Nome),
                base.Parameters.Create("@IdJogo", DbType.String, jogo.IDJogo),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );


            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) == 1 ? true : false;
        }


        public IList<Framework.DataServices.Model.EntityBaseData> LoadSemAcertos(string currentUser, Model.Boloes.Bolao bolao, out int errorNumber, out string errorDescription)
        {
            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, "sp_JogosUsuarios_Load_Sem_Acertos", true, currentUser,
                base.Parameters.Create("@NomeBolao", DbType.String, bolao.Nome),                
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );


            IList<Framework.DataServices.Model.EntityBaseData> list = ConvertToList(table);

            errorNumber = base.ExecutionStatus.ErrorNumber;
            errorDescription = base.ExecutionStatus.ErrorDescription;

            return list;
        }

        public IList<Framework.DataServices.Model.EntityBaseData> LoadProximasApostas(string currentUser, string userName, out int errorNumber, out string errorDescription)
        {
            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, "sp_JogosUsuarios_ProximosJogosUsuario", true, currentUser,
                base.Parameters.Create("@UserName", DbType.String, userName),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );


            IList<Framework.DataServices.Model.EntityBaseData> list = ConvertToList(table);

            errorNumber = base.ExecutionStatus.ErrorNumber;
            errorDescription = base.ExecutionStatus.ErrorDescription;

            return list;
        }


        public IList<Framework.DataServices.Model.EntityBaseData> LoadPontosObtidos(string currentUser, string userName, out int errorNumber, out string errorDescription)
        {
            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, "sp_JogosUsuarios_PontosObtidos", true, currentUser,
                base.Parameters.Create("@UserName", DbType.String, userName),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );


            IList<Framework.DataServices.Model.EntityBaseData> list = ConvertToList(table);

            errorNumber = base.ExecutionStatus.ErrorNumber;
            errorDescription = base.ExecutionStatus.ErrorDescription;

            return list;
        }

        #endregion
    }
}
