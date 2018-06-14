using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BolaoNet.Dao.Campeonatos.SQLSupport
{
    public class Jogo : Framework.DataServices.ItemPaging , IDaoJogo
    {
        //#region Constants
        //public new const string TableName = "Jogos";
        //#endregion

        #region Constructors/Destructors
        public Jogo()
            : base (Util.Jogo.TableName)
        {
        }

        public Jogo(string connectionName)
            : base(connectionName, Util.Jogo.TableName)
        {
        }

        public Jogo(string connectionName, string connectionString, string providerName)
            : base(connectionName, connectionString, providerName, Util.Jogo.TableName)
        {
        }    
        
        #endregion

        //#region Methods

        //public static IList<Framework.DataServices.Model.EntityBaseData> ConvertToList(DataTable table)
        //{
        //    IList<Framework.DataServices.Model.EntityBaseData> list = new List<Framework.DataServices.Model.EntityBaseData>();

        //    foreach (DataRow row in table.Rows)
        //    {
        //        list.Add(ConvertToObject(row));
        //    }

        //    return list;
        //}
        //public static Framework.DataServices.Model.EntityBaseData ConvertToObject(DataRow row)
        //{
        //    long idJogo = 0;

        //    if (row.Table.Columns.Contains("IdJogo") && !Convert.IsDBNull(row["IdJogo"]))
        //    {
        //        idJogo = Convert.ToInt64(row["IdJogo"]);
        //    }

        //    Model.Campeonatos.Jogo jogo = new Model.Campeonatos.Jogo (idJogo);
        //    jogo.LoadDataRow(row);

        //    if (row.Table.Columns.Contains("NomeCampeonato") && !Convert.IsDBNull(row["NomeCampeonato"]))
        //    {
        //        jogo.Campeonato = new Model.Campeonatos.Campeonato(Convert.ToString(row["NomeCampeonato"]));
        //    }
            
        //    if (row.Table.Columns.Contains("NomeFase") && !Convert.IsDBNull(row["NomeFase"]))
        //    {
        //        jogo.Fase = new Model.Campeonatos.Fase (Convert.ToString(row["NomeFase"]));
        //    }

        //    if (row.Table.Columns.Contains("NomeGrupo") && !Convert.IsDBNull(row["NomeGrupo"]))
        //    {
        //        jogo.Grupo = new Model.Campeonatos.Grupo(Convert.ToString(row["NomeGrupo"]));
        //    }

        //    if (row.Table.Columns.Contains("Titulo") && !Convert.IsDBNull(row["Titulo"]))
        //    {
        //        jogo.Titulo = Convert.ToString(row["Titulo"]);
        //    }

        //    if (row.Table.Columns.Contains("NomeTime1") && !Convert.IsDBNull(row["NomeTime1"]))
        //    {
        //        jogo.Time1 = new Model.DadosBasicos.Time(Convert.ToString(row["NomeTime1"]));
        //    }

        //    if (row.Table.Columns.Contains("Gols1") && !Convert.IsDBNull(row["Gols1"]))
        //    {
        //        jogo.GolsTime1 = Convert.ToInt32(row["Gols1"]);
        //    }

        //    if (row.Table.Columns.Contains("Penaltis1") && !Convert.IsDBNull(row["Penaltis1"]))
        //    {
        //        jogo.PenaltisTime1 = Convert.ToInt32(row["Penaltis1"]);
        //    }


        //    if (row.Table.Columns.Contains("DescricaoTime1") && !Convert.IsDBNull(row["DescricaoTime1"]))
        //    {
        //        jogo.DescricaoTime1 = Convert.ToString(row["DescricaoTime1"]);
        //    }

        //    if (row.Table.Columns.Contains("NomeTime2") && !Convert.IsDBNull(row["NomeTime2"]))
        //    {
        //        jogo.Time2 = new Model.DadosBasicos.Time(Convert.ToString(row["NomeTime2"]));
        //    }

        //    if (row.Table.Columns.Contains("Gols2") && !Convert.IsDBNull(row["Gols2"]))
        //    {
        //        jogo.GolsTime2 = Convert.ToInt32(row["Gols2"]);
        //    }

        //    if (row.Table.Columns.Contains("Penaltis2") && !Convert.IsDBNull(row["Penaltis2"]))
        //    {
        //        jogo.PenaltisTime2 = Convert.ToInt32(row["Penaltis2"]);
        //    }

        //    if (row.Table.Columns.Contains("DescricaoTime2") && !Convert.IsDBNull(row["DescricaoTime2"]))
        //    {
        //        jogo.DescricaoTime2 = Convert.ToString(row["DescricaoTime2"]);
        //    }

        //    if (row.Table.Columns.Contains("DataJogo") && !Convert.IsDBNull(row["DataJogo"]))
        //    {
        //        jogo.DataJogo = Convert.ToDateTime(row["DataJogo"]);
        //    }

        //    if (row.Table.Columns.Contains("Rodada") && !Convert.IsDBNull(row["Rodada"]))
        //    {
        //        jogo.Rodada = Convert.ToInt32(row["Rodada"]);
        //    }

        //    if (row.Table.Columns.Contains("IsValido") && !Convert.IsDBNull(row["IsValido"]))
        //    {
        //        jogo.PartidaValida = Convert.ToBoolean(row["IsValido"]);
        //    }

        //    if (row.Table.Columns.Contains("DataValidacao") && !Convert.IsDBNull(row["DataValidacao"]))
        //    {
        //        jogo.DataValidacao = Convert.ToDateTime(row["DataValidacao"]);
        //    }

        //    if (row.Table.Columns.Contains("ValidadoBy") && !Convert.IsDBNull(row["ValidadoBy"]))
        //    {
        //        jogo.ValidadoBy = Convert.ToString(row["ValidadoBy"]);
        //    }

        //    if (row.Table.Columns.Contains("NomeEstadio") && !Convert.IsDBNull(row["NomeEstadio"]))
        //    {
        //        jogo.Estadio = new Model.DadosBasicos.Estadio(Convert.ToString(row["NomeEstadio"]));
        //    }

        //    return jogo;

        //}


        //#endregion

        #region IJogo Members

        public Framework.DataServices.Model.EntityBaseData Load(string currentUser, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.Campeonatos.Jogo entryData = (Model.Campeonatos.Jogo)entry;


            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, base._commandSelect, true, currentUser,
                base.Parameters.Create("@IdJogo", DbType.String, entryData.IDJogo),
                base.Parameters.Create("@NomeCampeonato", DbType.String, entryData.Campeonato.Nome),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null) 
                );

            int rowsFound = Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value);

            if (rowsFound == 0)
                return null;
                //throw new Exception("There is no item found in database with this ID.");


            return Util.Jogo.ConvertToObject(table.Rows[0]);
        }
        public bool Insert(string currentUser, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.Campeonatos.Jogo entryData = (Model.Campeonatos.Jogo)entry;

            base.ExecuteNonQuery(CommandType.StoredProcedure, base._commandInsert, true, currentUser,                
                base.Parameters.Create("NomeFase", DbType.String, entryData.Fase == null ? null : entryData.Fase.Nome),
                base.Parameters.Create("Titulo", DbType.String, entryData.Titulo),
                base.Parameters.Create("NomeCampeonato", DbType.String, entryData.Campeonato.Nome),
                base.Parameters.Create("NomeTime1", DbType.String, entryData.Time1 == null ? null : entryData.Time1.Nome),
                base.Parameters.Create("NomeTime2", DbType.String, entryData.Time2 == null ? null : entryData.Time2.Nome),
                base.Parameters.Create("Gols1", DbType.Int16, entryData.GolsTime1),
                base.Parameters.Create("Gols2", DbType.Int16, entryData.GolsTime2),
                base.Parameters.Create("Penaltis1", DbType.Int16, entryData.PenaltisTime1),
                base.Parameters.Create("Penaltis2", DbType.Int16, entryData.PenaltisTime2),
                base.Parameters.Create("DataJogo", DbType.DateTime, entryData.DataJogo),
                base.Parameters.Create("Rodada", DbType.Int32, entryData.Rodada),
                base.Parameters.Create("IsValido", DbType.Boolean, entryData.PartidaValida),
                base.Parameters.Create("DataValidacao", DbType.DateTime, entryData.DataValidacao),
                base.Parameters.Create("NomeGrupo", DbType.String, entryData.Grupo == null ? null : entryData.Grupo.Nome),
                base.Parameters.Create("ValidadoBy", DbType.String, entryData.ValidadoBy),
                base.Parameters.Create("NomeEstadio", DbType.String, entryData.Estadio == null ? null : entryData.Estadio.Nome),
                base.Parameters.Create("DescricaoTime1", DbType.String, entryData.DescricaoTime1),
                base.Parameters.Create("DescricaoTime2", DbType.String, entryData.DescricaoTime2),
                base.Parameters.Create("JogoLabel", DbType.String, entryData.JogoLabel),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)                
            );


            ((Model.Campeonatos.Jogo)entry).IDJogo = Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value);
            
            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) > 0 ? true : false;
        }
        public bool Update(string currentUser, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.Campeonatos.Jogo entryData = (Model.Campeonatos.Jogo)entry;

            base.ExecuteNonQuery(CommandType.StoredProcedure, base._commandUpdate, true, currentUser,
                base.Parameters.Create("IdJogo", DbType.Int64, entryData.IDJogo),
                base.Parameters.Create("Titulo", DbType.String, entryData.Titulo),                
                base.Parameters.Create("NomeFase", DbType.String, entryData.Fase == null ? null : entryData.Fase.Nome),
                base.Parameters.Create("NomeCampeonato", DbType.String, entryData.Campeonato.Nome),
                base.Parameters.Create("NomeTime1", DbType.String, entryData.Time1 == null ? null : entryData.Time1.Nome),
                base.Parameters.Create("NomeTime2", DbType.String, entryData.Time2 == null ? null : entryData.Time2.Nome),
                base.Parameters.Create("Gols1", DbType.Int16, entryData.GolsTime1),
                base.Parameters.Create("Gols2", DbType.Int16, entryData.GolsTime2),
                base.Parameters.Create("Penaltis1", DbType.Int16, entryData.PenaltisTime1),
                base.Parameters.Create("Penaltis2", DbType.Int16, entryData.PenaltisTime2),
                base.Parameters.Create("DataJogo", DbType.DateTime, entryData.DataJogo),
                base.Parameters.Create("Rodada", DbType.String, entryData.GolsTime1),
                base.Parameters.Create("IsValido", DbType.Boolean, entryData.PartidaValida),
                base.Parameters.Create("DataValidacao", DbType.DateTime, entryData.DataValidacao),
                base.Parameters.Create("NomeGrupo", DbType.String, entryData.Grupo == null ? null : entryData.Grupo.Nome),
                base.Parameters.Create("ValidadoBy", DbType.String, entryData.ValidadoBy),
                base.Parameters.Create("NomeEstadio", DbType.String, entryData.Estadio == null ? null :  entryData.Estadio.Nome),
                base.Parameters.Create("DescricaoTime1", DbType.String, entryData.DescricaoTime1),
                base.Parameters.Create("DescricaoTime2", DbType.String, entryData.DescricaoTime2),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );


            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) >= 1 ? true : false;
        }
        public bool Delete(string currentUser, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.Campeonatos.Jogo entryData = (Model.Campeonatos.Jogo)entry;

            base.ExecuteNonQuery(CommandType.StoredProcedure, base._commandDelete, true, currentUser,
                base.Parameters.Create("@NomeCampeonato", DbType.String, entryData.Campeonato.Nome),
                base.Parameters.Create("@IDJogo", DbType.Int64, entryData.IDJogo),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );


            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) >= 1 ? true : false;
        }
        public IList<Framework.DataServices.Model.EntityBaseData> SelectAll(string currentUser, string condition, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            DataTable table = base.ExecuteFill (CommandType.StoredProcedure, base._commandSelectAll, true, currentUser,
                base.Parameters.Create("@Condition", DbType.String, condition),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            return Util.Jogo.ConvertToList(table);

        }
        public IList<Framework.DataServices.Model.EntityBaseData> SelectPage(string currentUser, string condition, string order, int pageNumber, int pageSize, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            return Util.Jogo.ConvertToList(
                base.GetPage(null, condition, order, pageNumber, pageSize,
                true, currentUser, out errorNumber, out errorDescription));

        }
        public int SelectCount(string currentUser, string condition, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            return base.GetCount (condition, 
                true, currentUser, 
                out errorNumber, out errorDescription );
        }
        public IList<Framework.DataServices.Model.EntityBaseData> SelectCombo(string currentUser, out int errorNumber, out string errorDescription, params object[] fields)
        {
            errorNumber = 0;
            errorDescription = null;

            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, base._commandSelectCombo, true, currentUser,                
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            return Util.Jogo.ConvertToList(table);
        }
        public bool InsertResult(string currentUser,int gols1, int gols2, int penaltis1, int penaltis2, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.Campeonatos.Jogo entryData = (Model.Campeonatos.Jogo)entry;

            base.ExecuteNonQuery(CommandType.StoredProcedure, "sp_Jogos_ResultInsert", true, currentUser,
                base.Parameters.Create("@NomeCampeonato", DbType.String, entryData.Campeonato.Nome),
                base.Parameters.Create("@IDJogo", DbType.Int64, entryData.IDJogo),
                base.Parameters.Create("@Gols1", DbType.Int16, gols1),
                base.Parameters.Create("@Gols2", DbType.Int16, gols2),
                base.Parameters.Create("@Penaltis1", DbType.Int16, penaltis1),
                base.Parameters.Create("@Penaltis2", DbType.Int16, penaltis2),
                base.Parameters.Create("@SetCurrentData", DbType.Boolean, true),                
	            base.Parameters.Create("@ValidadoBy", DbType.String, currentUser),                
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );


            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) == 1 ? true : false;
        }
        public bool RemoveResult(string currentUser, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.Campeonatos.Jogo entryData = (Model.Campeonatos.Jogo)entry;

            base.ExecuteNonQuery(CommandType.StoredProcedure, "sp_Jogos_ResultRemove", true, currentUser,
                base.Parameters.Create("@NomeCampeonato", DbType.String, entryData.Campeonato.Nome),
                base.Parameters.Create("@IDJogo", DbType.Int64, entryData.IDJogo),
                base.Parameters.Create("@ValidoBy", DbType.String, entryData.ValidadoBy),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );


            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) == 1 ? true : false;
        }


        public IList<Framework.DataServices.Model.EntityBaseData> SelectAllByPeriod(string currentUser, int rodada, BolaoNet.Model.Campeonatos.Campeonato campeonato, DateTime dataInicial, DateTime dataFinal, string time, string fase, string grupo, string condition, string order, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            if (string.IsNullOrEmpty(time))
                time = null;
            if (string.IsNullOrEmpty(fase))
                fase = null;
            if (string.IsNullOrEmpty(grupo))
                grupo = null;


            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, "sp_Jogos_SelectByPeriod", true, currentUser,
                base.Parameters.Create("@NomeCampeonato", DbType.String, campeonato.Nome),
                base.Parameters.Create("@Rodada", DbType.Int32, rodada),
                base.Parameters.Create("@DataInicial", DbType.DateTime, dataInicial),
                base.Parameters.Create("@DataFinal", DbType.DateTime, dataFinal),
                base.Parameters.Create("@NomeTime", DbType.String, time),
                base.Parameters.Create("@NomeFase", DbType.String, fase),
                base.Parameters.Create("@NomeGrupo", DbType.String, grupo),
                base.Parameters.Create("@Condition", DbType.String, condition),
                base.Parameters.Create("@Order", DbType.String, order),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            errorNumber = base.ExecutionStatus.ErrorNumber;
            errorDescription = base.ExecutionStatus.ErrorDescription;

            return Util.Jogo.ConvertToList(table);
        }
        public IList<Framework.DataServices.Model.EntityBaseData> SelectJogosByTime(string currentUser, Model.Campeonatos.Campeonato campeonato, Model.DadosBasicos.Time time, string condition, string order,  out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            return SelectAllByPeriod(currentUser, 0, campeonato, DateTime.MinValue, DateTime.MinValue,
                time.Nome, null, null, null, order,
                //"(Jogos.NomeTime1 = '" + time.Nome + "' OR Jogos.NomeTime2 = '" + time.Nome + "')", order,
                out errorNumber, out errorDescription);
                
        }
        public bool InsertWithAllData(string currentUser, bool isClube, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.Campeonatos.Jogo entryData = (Model.Campeonatos.Jogo)entry;

            base.ExecuteNonQuery(CommandType.StoredProcedure, "sp_Jogos_InsertAllData", true, currentUser,
                base.Parameters.Create("NomeFase", DbType.String, entryData.Fase == null ? null : entryData.Fase.Nome),
                base.Parameters.Create("IsClube", DbType.Boolean, isClube ),                
                base.Parameters.Create("Titulo", DbType.String, entryData.Titulo),
                base.Parameters.Create("NomeCampeonato", DbType.String, entryData.Campeonato.Nome),
                base.Parameters.Create("NomeTime1", DbType.String, entryData.Time1 == null ? null : entryData.Time1.Nome),
                base.Parameters.Create("NomeTime2", DbType.String, entryData.Time2 == null ? null : entryData.Time2.Nome),
                base.Parameters.Create("Gols1", DbType.Int16, entryData.GolsTime1),
                base.Parameters.Create("Gols2", DbType.Int16, entryData.GolsTime2),
                base.Parameters.Create("Penaltis1", DbType.Int16, entryData.PenaltisTime1),
                base.Parameters.Create("Penaltis2", DbType.Int16, entryData.PenaltisTime2),
                base.Parameters.Create("DataJogo", DbType.DateTime, entryData.DataJogo),
                base.Parameters.Create("Rodada", DbType.String, entryData.Rodada),
                base.Parameters.Create("IsValido", DbType.Boolean, entryData.PartidaValida),
                base.Parameters.Create("NomeGrupo", DbType.String, entryData.Grupo == null ? null : entryData.Grupo.Nome),
                base.Parameters.Create("NomeEstadio", DbType.String, entryData.Estadio == null ? null : entryData.Estadio.Nome),
                base.Parameters.Create("DescricaoTime1", DbType.String, entryData.DescricaoTime1),
                base.Parameters.Create("DescricaoTime2", DbType.String, entryData.DescricaoTime2),

                base.Parameters.Create("JogoLabel", DbType.String, entryData.JogoLabel),

                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
            );


            ((Model.Campeonatos.Jogo)entry).IDJogo = Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value);

            errorNumber = base.ExecutionStatus.ErrorNumber;
            errorDescription = base.ExecutionStatus.ErrorDescription;

            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) > 0 ? true : false;
        }        
        public IList<Framework.DataServices.Model.EntityBaseData> SelectGoleadas(string currentUser, BolaoNet.Model.Campeonatos.Campeonato campeonato, int maxGols, string condition, string order, out int errorNumber, out string errorDescription)
        {
            string conditionCheck = condition;

            if (!string.IsNullOrEmpty(conditionCheck))
            {
                conditionCheck += " AND ";
            }
            else
            {
                conditionCheck = "";
            }


            conditionCheck += "(Gols1 >= " + maxGols + " OR Gols2 >= " + maxGols + ")";
            


            return SelectAllByPeriod(currentUser, 0, campeonato, DateTime.MinValue, DateTime.MinValue, 
                null, null, null, conditionCheck, 
                "(Jogos.Gols1 + Jogos.Gols2) DESC", out errorNumber, out errorDescription);
        }



        public IList<Framework.DataServices.Model.EntityBaseData> LoadNextJogos(string currentUser, BolaoNet.Model.Campeonatos.Campeonato campeonato, int totalJogos, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, "sp_Campeonatos_LoadNextJogos", true, currentUser,
                base.Parameters.Create("@NomeCampeonato", DbType.String, campeonato.Nome),
                base.Parameters.Create("@TotalJogos", DbType.Int32, totalJogos),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            errorNumber = base.ExecutionStatus.ErrorNumber;
            errorDescription = base.ExecutionStatus.ErrorDescription;

            return Util.Jogo.ConvertToList(table);
        }
        public IList<Framework.DataServices.Model.EntityBaseData> LoadFinishedJogos(string currentUser, BolaoNet.Model.Campeonatos.Campeonato campeonato, int totalJogos, out int errorNumber, out string errorDescription)
        {

            errorNumber = 0;
            errorDescription = null;

            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, "sp_Campeonatos_LoadLastFinishedJogos", true, currentUser,
                base.Parameters.Create("@NomeCampeonato", DbType.String, campeonato.Nome),
                base.Parameters.Create("@TotalJogos", DbType.Int32, totalJogos),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            errorNumber = base.ExecutionStatus.ErrorNumber;
            errorDescription = base.ExecutionStatus.ErrorDescription;

            return Util.Jogo.ConvertToList(table);
        }

        public int NextJogo(string currentUser, Model.Campeonatos.Campeonato campeonato, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            object result = base.ExecuteScalar(CommandType.StoredProcedure, "sp_Jogos_Next_Jogo", true, currentUser,
                base.Parameters.Create("@NomeCampeonato", DbType.String, campeonato==null ? "" : campeonato.Nome),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            if (Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) == 1)
                return Convert.ToInt32(result);

            else
                return 0;            
        }
        #endregion
    }
}
