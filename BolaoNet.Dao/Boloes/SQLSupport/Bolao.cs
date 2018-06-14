using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BolaoNet.Dao.Boloes.SQLSupport
{
    public class Bolao: Framework.DataServices.ItemPaging , IDaoBolao
    {
        //#region Constants
        //public new const string TableName = "Boloes";
        //public const string TableLinkToUsers = "BoloesMembros";
        //#endregion

        #region Constructors/Destructors
        public Bolao()
            : base (Util.Bolao.TableName)
        {
        }

        public Bolao(string connectionName)
            : base(connectionName, Util.Bolao.TableName)
        {
        }

        public Bolao(string connectionName, string connectionString, string providerName)
            : base(connectionName, connectionString, providerName, Util.Bolao.TableName)
        {
        }    
        
        #endregion

        #region Methods

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
        //    string nome = "";

        //    if (row.Table.Columns.Contains("Nome") && !Convert.IsDBNull(row["Nome"]))
        //    {
        //        nome = Convert.ToString(row["Nome"]);
        //    }

        //    Model.Boloes.Bolao entry = new Model.Boloes.Bolao(nome);
        //    entry.LoadDataRow(row);

        //    if (row.Table.Columns.Contains("NomeCampeonato") && !Convert.IsDBNull(row["NomeCampeonato"]))
        //    {
        //        entry.Campeonato = new BolaoNet.Model.Campeonatos.Campeonato(Convert.ToString(row["NomeCampeonato"]));
        //    }
        //    if (row.Table.Columns.Contains("Descricao") && !Convert.IsDBNull(row["Descricao"]))
        //    {
        //        entry.Descricao = Convert.ToString(row["Descricao"]);
        //    }
        //    if (row.Table.Columns.Contains("TaxaParticipacao") && !Convert.IsDBNull(row["TaxaParticipacao"]))
        //    {
        //        entry.TaxaParticipacao = Convert.ToDecimal(row["TaxaParticipacao"]);
        //    }
        //    if (row.Table.Columns.Contains("Foto") && !Convert.IsDBNull(row["Foto"]))
        //    {
        //        //entry.Foto = Convert.ToDecimal(row["Foto"]);
        //    }
        //    if (row.Table.Columns.Contains("Publico") && !Convert.IsDBNull(row["Publico"]))
        //    {
        //        entry.Publico = Convert.ToBoolean(row["Publico"]);
        //    }
        //    if (row.Table.Columns.Contains("ForumAtivado") && !Convert.IsDBNull(row["ForumAtivado"]))
        //    {
        //        entry.ForumAtivado = Convert.ToBoolean(row["ForumAtivado"]);
        //    }
        //    if (row.Table.Columns.Contains("PermitirMsgAnonimos") && !Convert.IsDBNull(row["PermitirMsgAnonimos"]))
        //    {
        //        entry.PermitirMsgAnonimos = Convert.ToBoolean(row["PermitirMsgAnonimos"]);
        //    }
        //    if (row.Table.Columns.Contains("DataInicio") && !Convert.IsDBNull(row["DataInicio"]))
        //    {
        //        entry.DataInicio = Convert.ToDateTime(row["DataInicio"]);
        //    }
        //    if (row.Table.Columns.Contains("Pais") && !Convert.IsDBNull(row["Pais"]))
        //    {
        //        entry.Pais = Convert.ToString(row["Pais"]);
        //    }
        //    if (row.Table.Columns.Contains("Estado") && !Convert.IsDBNull(row["Estado"]))
        //    {
        //        entry.Estado = Convert.ToString(row["Estado"]);
        //    }
        //    if (row.Table.Columns.Contains("Cidade") && !Convert.IsDBNull(row["Cidade"]))
        //    {
        //        entry.Cidade = Convert.ToString(row["Cidade"]);
        //    }
        //    if (row.Table.Columns.Contains("ApostasApenasAntes") && !Convert.IsDBNull(row["ApostasApenasAntes"]))
        //    {
        //        entry.ApostasApenasAntes = Convert.ToBoolean(row["ApostasApenasAntes"]);
        //    }
        //    if (row.Table.Columns.Contains("HorasLimiteAposta") && !Convert.IsDBNull(row["HorasLimiteAposta"]))
        //    {
        //        entry.HorasLimiteAposta = Convert.ToInt32(row["HorasLimiteAposta"]);
        //    }
        //    if (row.Table.Columns.Contains("IsIniciado") && !Convert.IsDBNull(row["IsIniciado"]))
        //    {
        //        entry.IsIniciado = Convert.ToBoolean(row["IsIniciado"]);
        //    }
        //    if (row.Table.Columns.Contains("IniciadoBy") && !Convert.IsDBNull(row["IniciadoBy"]))
        //    {
        //        entry.IniciadoBy = Convert.ToString(row["IniciadoBy"]);
        //    }
        //    if (row.Table.Columns.Contains("DataIniciado") && !Convert.IsDBNull(row["DataIniciado"]))
        //    {
        //        entry.DataIniciado = Convert.ToDateTime(row["DataIniciado"]);
        //    }




        //    return entry;

        //}

        //public static IList<Model.Boloes.BolaoMembros> ConvertUserPontosToList(DataTable table)
        //{
        //    IList<Model.Boloes.BolaoMembros> list = new List<Model.Boloes.BolaoMembros>();

        //    foreach (DataRow row in table.Rows)
        //    {
        //        list.Add(ConvertUserPontosToObject(row));
        //    }

        //    return list;
        //}
        //public static Model.Boloes.BolaoMembros ConvertUserPontosToObject(DataRow row)
        //{
        //    string nome = "";

        //    if (row.Table.Columns.Contains("UserName") && !Convert.IsDBNull(row["UserName"]))
        //    {
        //        nome = Convert.ToString(row["UserName"]);
        //    }

        //    Model.Boloes.BolaoMembros entry = new Model.Boloes.BolaoMembros(nome);


        //    if (row.Table.Columns.Contains("Posicao") && !Convert.IsDBNull(row["Posicao"]))
        //    {
        //        entry.Posicao = Convert.ToInt32(row["Posicao"]);
        //    }
        //    if (row.Table.Columns.Contains("LastPosicao") && !Convert.IsDBNull(row["LastPosicao"]))
        //    {
        //        entry.LastPosicao = Convert.ToInt32(row["LastPosicao"]);
        //    }


           
        //    if (row.Table.Columns.Contains("totalPontos") && !Convert.IsDBNull(row["totalPontos"]))
        //    {
        //        entry.TotalPontos = Convert.ToInt32(row["totalPontos"]);
        //    }
        //    if (row.Table.Columns.Contains("totalEmpate") && !Convert.IsDBNull(row["totalEmpate"]))
        //    {
        //        entry.TotalEmpate = Convert.ToInt32(row["totalEmpate"]);
        //    }
        //    if (row.Table.Columns.Contains("totalVitoria") && !Convert.IsDBNull(row["totalVitoria"]))
        //    {
        //        entry.TotalVitoria = Convert.ToInt32(row["totalVitoria"]);
        //    }
        //    if (row.Table.Columns.Contains("totalGolsGanhador") && !Convert.IsDBNull(row["totalGolsGanhador"]))
        //    {
        //        entry.TotalGolsGanhador = Convert.ToInt32(row["totalGolsGanhador"]);
        //    }
        //    if (row.Table.Columns.Contains("totalGolsPerdedor") && !Convert.IsDBNull(row["totalGolsPerdedor"]))
        //    {
        //        entry.TotalGolsPerdedor = Convert.ToInt32(row["totalGolsPerdedor"]);
        //    }
        //    if (row.Table.Columns.Contains("totalResultTime1") && !Convert.IsDBNull(row["totalResultTime1"]))
        //    {
        //        entry.TotalResultTime1 = Convert.ToInt32(row["totalResultTime1"]);
        //    }
        //    if (row.Table.Columns.Contains("totalResultTime2") && !Convert.IsDBNull(row["totalResultTime2"]))
        //    {
        //        entry.TotalResultTime2 = Convert.ToInt32(row["totalResultTime2"]);
        //    }
        //    if (row.Table.Columns.Contains("totalVDE") && !Convert.IsDBNull(row["totalVDE"]))
        //    {
        //        entry.TotalVDE = Convert.ToInt32(row["totalVDE"]);
        //    }
        //    if (row.Table.Columns.Contains("totalErro") && !Convert.IsDBNull(row["totalErro"]))
        //    {
        //        entry.TotalErro = Convert.ToInt32(row["totalErro"]);
        //    }
        //    if (row.Table.Columns.Contains("totalGolsGanhadorFora") && !Convert.IsDBNull(row["totalGolsGanhadorFora"]))
        //    {
        //        entry.TotalGolsGanhadorFora = Convert.ToInt32(row["totalGolsGanhadorFora"]);
        //    }
            
        //    if (row.Table.Columns.Contains("totalGolsGanhadorDentro") && !Convert.IsDBNull(row["totalGolsGanhadorDentro"]))
        //    {
        //        entry.TotalGolsGanhadorDentro = Convert.ToInt32(row["totalGolsGanhadorDentro"]);
        //    }
        //    if (row.Table.Columns.Contains("totalPerdedorFora") && !Convert.IsDBNull(row["totalPerdedorFora"]))
        //    {
        //        entry.TotalPerdedorFora = Convert.ToInt32(row["totalPerdedorFora"]);
        //    }
        //    if (row.Table.Columns.Contains("totalPerdedorDentro") && !Convert.IsDBNull(row["totalPerdedorDentro"]))
        //    {
        //        entry.TotalPerdedorDentro = Convert.ToInt32(row["totalPerdedorDentro"]);
        //    }
        //    if (row.Table.Columns.Contains("totalGolsEmpate") && !Convert.IsDBNull(row["totalGolsEmpate"]))
        //    {
        //        entry.TotalGolsEmpate = Convert.ToInt32(row["totalGolsEmpate"]);
        //    }
        //    if (row.Table.Columns.Contains("totalGolsTime1") && !Convert.IsDBNull(row["totalGolsTime1"]))
        //    {
        //        entry.TotalGolsTime1 = Convert.ToInt32(row["totalGolsTime1"]);
        //    }
        //    if (row.Table.Columns.Contains("totalGolsTime2") && !Convert.IsDBNull(row["totalGolsTime2"]))
        //    {
        //        entry.TotalGolsTime2 = Convert.ToInt32(row["totalGolsTime2"]);
        //    }
             
        //    if (row.Table.Columns.Contains("totalPlacarCheio") && !Convert.IsDBNull(row["totalPlacarCheio"]))
        //    {
        //        entry.TotalPlacarCheio = Convert.ToInt32(row["totalPlacarCheio"]);
        //    }
            


        //    return entry;

        //}

        //public static IList<Framework.DataServices.Model.EntityBaseData> ConvertToPremioList(DataTable table)
        //{
        //    IList<Framework.DataServices.Model.EntityBaseData> list = new List<Framework.DataServices.Model.EntityBaseData>();

        //    foreach (DataRow row in table.Rows)
        //    {
        //        list.Add(ConvertToPremioObject(row));
        //    }

        //    return list;
        //}
        //public static Framework.DataServices.Model.EntityBaseData ConvertToPremioObject(DataRow row)
        //{
        //    string nomeBolao = "";
        //    int posicao = 0;

        //    if (row.Table.Columns.Contains("NomeBolao") && !Convert.IsDBNull(row["NomeBolao"]))
        //    {
        //        nomeBolao = Convert.ToString(row["NomeBolao"]);
        //    }
        //    if (row.Table.Columns.Contains("Posicao") && !Convert.IsDBNull(row["Posicao"]))
        //    {
        //        posicao = Convert.ToInt32(row["Posicao"]);
        //    }

        //    Model.Boloes.BolaoPremio entry = new BolaoNet.Model.Boloes.BolaoPremio (nomeBolao, posicao);
        //    entry.LoadDataRow(row);


        //    if (row.Table.Columns.Contains("Titulo") && !Convert.IsDBNull(row["Titulo"]))
        //    {
        //        entry.Titulo = Convert.ToString(row["Titulo"]);
        //    }
        //    if (row.Table.Columns.Contains("BackColor") && !Convert.IsDBNull(row["BackColor"]))
        //    {
        //        entry.BackColor = System.Drawing.Color.FromName(Convert.ToString(row["BackColor"]));
        //    }
        //    if (row.Table.Columns.Contains("ForeColor") && !Convert.IsDBNull(row["ForeColor"]))
        //    {
        //        entry.ForeColor = System.Drawing.Color.FromName(Convert.ToString(row["ForeColor"]));
        //    }


        //    return entry;

        //}

        //public static IList<Framework.DataServices.Model.EntityBaseData> ConvertToRequestList(DataTable table)
        //{
        //    IList<Framework.DataServices.Model.EntityBaseData> list = new List<Framework.DataServices.Model.EntityBaseData>();

        //    foreach (DataRow row in table.Rows)
        //    {
        //        list.Add(ConvertToRequestObject(row));
        //    }

        //    return list;
        //}
        //public static Framework.DataServices.Model.EntityBaseData ConvertToRequestObject(DataRow row)
        //{
        //    string nomeBolao = "";
        //    int requestID = 0;

        //    if (row.Table.Columns.Contains("NomeBolao") && !Convert.IsDBNull(row["NomeBolao"]))
        //    {
        //        nomeBolao = Convert.ToString(row["NomeBolao"]);
        //    }
        //    if (row.Table.Columns.Contains("RequestID") && !Convert.IsDBNull(row["RequestID"]))
        //    {
        //        requestID = Convert.ToInt32(row["RequestID"]);
        //    }

        //    Model.Boloes.BolaoRequest entry = new BolaoNet.Model.Boloes.BolaoRequest(requestID, nomeBolao);
        //    entry.LoadDataRow(row);


        //    if (row.Table.Columns.Contains("RequestedBy") && !Convert.IsDBNull(row["RequestedBy"]))
        //    {
        //        entry.RequestedBy = Convert.ToString(row["RequestedBy"]);
        //    }
        //    if (row.Table.Columns.Contains("RequestedDate") && !Convert.IsDBNull(row["RequestedDate"]))
        //    {
        //        entry.RequestedDate = Convert.ToDateTime(Convert.ToString(row["RequestedDate"]));
        //    }
        //    if (row.Table.Columns.Contains("Owner") && !Convert.IsDBNull(row["Owner"]))
        //    {
        //        entry.Owner = Convert.ToString(Convert.ToString(row["Owner"]));
        //    }
        //    if (row.Table.Columns.Contains("StatusRequestID") && !Convert.IsDBNull(row["StatusRequestID"]))
        //    {
        //        entry.StatusRequestID= (Model.Boloes.BolaoRequest.Status)
        //            Convert.ToInt32(Convert.ToString(row["StatusRequestID"]));
        //    }
        //    if (row.Table.Columns.Contains("AnsweredBy") && !Convert.IsDBNull(row["AnsweredBy"]))
        //    {
        //        entry.AnsweredBy = Convert.ToString(Convert.ToString(row["AnsweredBy"]));
        //    }
        //    if (row.Table.Columns.Contains("AnsweredDate") && !Convert.IsDBNull(row["AnsweredDate"]))
        //    {
        //        entry.AnsweredDate = Convert.ToDateTime(Convert.ToString(row["AnsweredDate"]));
        //    }
        //    if (row.Table.Columns.Contains("Descricao") && !Convert.IsDBNull(row["Descricao"]))
        //    {
        //        entry.Descricao = Convert.ToString(Convert.ToString(row["Descricao"]));
        //    }


        //    return entry;

        //}


        //public static IList<Framework.DataServices.Model.EntityBaseData> ConvertToCriteriosPontosList(DataTable table)
        //{
        //    IList<Framework.DataServices.Model.EntityBaseData> list = new List<Framework.DataServices.Model.EntityBaseData>();

        //    foreach (DataRow row in table.Rows)
        //    {
        //        list.Add(ConvertToCriteriosPontosObject(row));
        //    }

        //    return list;
        //}
        //public static Framework.DataServices.Model.EntityBaseData ConvertToCriteriosPontosObject(DataRow row)
        //{
        //    string nomeBolao = "";
        //    int criterioID = 0;

        //    if (row.Table.Columns.Contains("NomeBolao") && !Convert.IsDBNull(row["NomeBolao"]))
        //    {
        //        nomeBolao = Convert.ToString(row["NomeBolao"]);
        //    }
        //    if (row.Table.Columns.Contains("CriterioID") && !Convert.IsDBNull(row["CriterioID"]))
        //    {
        //        criterioID = Convert.ToInt32(row["CriterioID"]);
        //    }

        //    Model.Boloes.BolaoCriterioPontos entry = new BolaoNet.Model.Boloes.BolaoCriterioPontos(nomeBolao, (Model.Boloes.BolaoCriterioPontos.CriteriosID)criterioID);
        //    entry.LoadDataRow(row);


        //    if (row.Table.Columns.Contains("Pontos") && !Convert.IsDBNull(row["Pontos"]))
        //    {
        //        entry.Pontos = Convert.ToInt32(row["Pontos"]);
        //    }
        //    if (row.Table.Columns.Contains("Descricao") && !Convert.IsDBNull(row["Descricao"]))
        //    {
        //        entry.Descricao = Convert.ToString(row["Descricao"]);
        //    }

        //    if (row.Table.Columns.Contains("NomeTime") && !Convert.IsDBNull(row["NomeTime"]))
        //    {
        //        entry.Time = new BolaoNet.Model.DadosBasicos.Time (Convert.ToString(row["NomeTime"]));
        //    }
        //    if (row.Table.Columns.Contains("MultiploTime") && !Convert.IsDBNull(row["MultiploTime"]))
        //    {
        //        entry.MultiploTime = Convert.ToInt32(row["MultiploTime"]);
        //    }

        //    return entry;

        //}


        //public static IList<Framework.DataServices.Model.EntityBaseData> ConvertToCriteriosPontosTimesList(DataTable table)
        //{
        //    IList<Framework.DataServices.Model.EntityBaseData> list = new List<Framework.DataServices.Model.EntityBaseData>();

        //    foreach (DataRow row in table.Rows)
        //    {
        //        list.Add(ConvertToCriteriosPontosTimesObject(row));
        //    }

        //    return list;
        //}
        //public static Framework.DataServices.Model.EntityBaseData ConvertToCriteriosPontosTimesObject(DataRow row)
        //{
        //    string nomeBolao = "";
        //    string nomeTime = "";

        //    if (row.Table.Columns.Contains("NomeBolao") && !Convert.IsDBNull(row["NomeBolao"]))
        //    {
        //        nomeBolao = Convert.ToString(row["NomeBolao"]);
        //    }
        //    if (row.Table.Columns.Contains("NomeTime") && !Convert.IsDBNull(row["NomeTime"]))
        //    {
        //        nomeTime = Convert.ToString(row["NomeTime"]);
        //    }

        //    Model.Boloes.BolaoCriterioPontosTimes entry = 
        //        new BolaoNet.Model.Boloes.BolaoCriterioPontosTimes(nomeBolao, nomeTime);
        //    entry.LoadDataRow(row);


        //    if (row.Table.Columns.Contains("Multiplo") && !Convert.IsDBNull(row["Multiplo"]))
        //    {
        //        entry.MultiploTime = Convert.ToInt32(row["Multiplo"]);
        //    }

        //    return entry;

        //}

        #endregion

        #region IDaoBase Members

        public Framework.DataServices.Model.EntityBaseData Load(string currentUser, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.Boloes.Bolao entryData = (Model.Boloes.Bolao)entry;


            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, base._commandSelect, true, currentUser,
                base.Parameters.Create("@Nome", DbType.String, entryData.Nome), 
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null) 
                );

            int rowsFound = Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value);

            if (rowsFound == 0)
                return null;
                //throw new Exception("There is no item found in database with this ID.");


            return Util.Bolao.ConvertToObject(table.Rows[0]);
        }
        public bool Insert(string currentUser, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.Boloes.Bolao entryData = (Model.Boloes.Bolao)entry;

            base.ExecuteNonQuery(CommandType.StoredProcedure, base._commandInsert, true, currentUser,
                base.Parameters.Create("@Nome", DbType.String, entryData.Nome),
                base.Parameters.Create("@NomeCampeonato", DbType.String, entryData.Campeonato.Nome),                
                base.Parameters.Create("@Descricao", DbType.String, entryData.Descricao),
                base.Parameters.Create("@TaxaParticipacao", DbType.Decimal, entryData.TaxaParticipacao),
                base.Parameters.Create("@Foto", DbType.AnsiString, entryData.Foto),
                base.Parameters.Create("@Publico", DbType.Boolean, entryData.Publico),
                base.Parameters.Create("@ForumAtivado", DbType.Boolean, entryData.ForumAtivado),
                base.Parameters.Create("@PermitirMsgAnonimos", DbType.Boolean, entryData.PermitirMsgAnonimos),
                base.Parameters.Create("@DataInicio", DbType.DateTime, entryData.DataInicio),
                base.Parameters.Create("@Pais", DbType.String, entryData.Pais),
                base.Parameters.Create("@Estado", DbType.String, entryData.Estado),
                base.Parameters.Create("@Cidade", DbType.String, entryData.Cidade),
                base.Parameters.Create("@ApostasApenasAntes", DbType.Boolean, entryData.ApostasApenasAntes),
                base.Parameters.Create("@HorasLimiteAposta", DbType.Int32, entryData.HorasLimiteAposta),
                base.Parameters.Create("@IsIniciado", DbType.Boolean, entryData.IsIniciado),
                base.Parameters.Create("@IniciadoBy", DbType.String, entryData.IniciadoBy),
                base.Parameters.Create("@DataIniciado", DbType.DateTime, entryData.DataIniciado),                
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            
            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) == 1 ? true : false;
        }
        public bool Update(string currentUser, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.Boloes.Bolao entryData = (Model.Boloes.Bolao)entry;

            base.ExecuteNonQuery(CommandType.StoredProcedure, base._commandUpdate, true, currentUser,
                base.Parameters.Create("@Nome", DbType.String, entryData.Nome),
                base.Parameters.Create("@NomeCampeonato", DbType.String, entryData.Campeonato.Nome),
                base.Parameters.Create("@Descricao", DbType.String, entryData.Descricao),
                base.Parameters.Create("@TaxaParticipacao", DbType.Decimal, entryData.TaxaParticipacao),
                base.Parameters.Create("@Foto", DbType.AnsiString, entryData.Foto),
                base.Parameters.Create("@Publico", DbType.Boolean, entryData.Publico),
                base.Parameters.Create("@ForumAtivado", DbType.Boolean, entryData.ForumAtivado),
                base.Parameters.Create("@PermitirMsgAnonimos", DbType.Boolean, entryData.PermitirMsgAnonimos),
                base.Parameters.Create("@DataInicio", DbType.DateTime, entryData.DataInicio),
                base.Parameters.Create("@Pais", DbType.String, entryData.Pais),
                base.Parameters.Create("@Estado", DbType.String, entryData.Estado),
                base.Parameters.Create("@Cidade", DbType.String, entryData.Cidade),
                base.Parameters.Create("@ApostasApenasAntes", DbType.Boolean, entryData.ApostasApenasAntes),
                base.Parameters.Create("@HorasLimiteAposta", DbType.Int32, entryData.HorasLimiteAposta),
                base.Parameters.Create("@IsIniciado", DbType.Boolean, entryData.IsIniciado),
                base.Parameters.Create("@IniciadoBy", DbType.String, entryData.IniciadoBy == "-" ? null : entryData.IniciadoBy),
                base.Parameters.Create("@DataIniciado", DbType.DateTime, entryData.DataIniciado),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );


            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) >= 1 ? true : false;
        }
        public bool Delete(string currentUser, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.Boloes.Bolao entryData = (Model.Boloes.Bolao)entry;

            base.ExecuteNonQuery(CommandType.StoredProcedure, base._commandDelete, true, currentUser,
                base.Parameters.Create("@Nome", DbType.String, entryData.Nome),
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

            return Util.Bolao.ConvertToList(table);

        }
        public IList<Framework.DataServices.Model.EntityBaseData> SelectPage(string currentUser, string condition, string order, int pageNumber, int pageSize, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            return Util.Bolao.ConvertToList(
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

            return Util.Bolao.ConvertToList(table);
        }


        public IList<Framework.DataServices.Model.EntityBaseData> SelectAllEnabled(string currentUser, string condition, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            string conditionAux = condition;

            if (!string.IsNullOrEmpty(conditionAux))
            {
                conditionAux += " AND ";
            }
            else
            {
                conditionAux = "(IsIniciado = 0) OR (IsIniciado = 1 AND ApostasApenasAntes = 0)";
            }


            return SelectAll(currentUser, conditionAux, out errorNumber, out errorDescription);

        }
        


        public IList<Framework.DataServices.Model.EntityBaseData> LoadBoloes(string currentUser, Framework.Security.Model.UserData usuario, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;


            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, "sp_BoloesMembros_All", true, currentUser,
                base.Parameters.Create("@UserName", DbType.String, usuario.UserName),                
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            return Util.Bolao.ConvertToList(table);
        }
        public IList<Framework.DataServices.Model.EntityBaseData> LoadMembros(string currentUser, BolaoNet.Model.Boloes.Bolao bolao, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            

            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, "sp_BoloesMembros_Load", true, currentUser,
                base.Parameters.Create("@NomeBolao", DbType.String, bolao.Nome),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            IList<Framework.DataServices.Model.EntityBaseData> list =
                new List<Framework.DataServices.Model.EntityBaseData>();


            foreach (DataRow row in table.Rows)
            {
                list.Add(Framework.Security.DataAccess.Convertion.UserData.ConvertToModel(row));
            }

            return list;
            
        }
        public bool InsertMembro(string currentUser, BolaoNet.Model.Boloes.Bolao bolao, Framework.Security.Model.UserData usuario, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;


            base.ExecuteNonQuery(CommandType.StoredProcedure, "sp_BoloesMembros_Add", true, currentUser,
                base.Parameters.Create("@NomeBolao", DbType.String, bolao.Nome),
                base.Parameters.Create("@UserName", DbType.String, usuario.UserName),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );


            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) == 1 ? true : false;
       
        }
        public bool DeleteMembro(string currentUser, BolaoNet.Model.Boloes.Bolao bolao, Framework.Security.Model.UserData usuario, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;


            base.ExecuteNonQuery(CommandType.StoredProcedure, "sp_BoloesMembros_Del", true, currentUser,
                base.Parameters.Create("@NomeBolao", DbType.String, bolao.Nome),
                base.Parameters.Create("@UserName", DbType.String, usuario.UserName),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );


            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) >= 1 ? true : false;


        }
        public bool ClearMembros(string currentUser, BolaoNet.Model.Boloes.Bolao bolao, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            

            base.ExecuteNonQuery(CommandType.StoredProcedure, "sp_BoloesMembros_Clear", true, currentUser,
                base.Parameters.Create("@NomeBolao", DbType.String, bolao.Nome),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );


            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) >= 0 ? true : false;


        }

        public IList<BolaoNet.Model.Boloes.BolaoMembros> LoadClassificacao(string currentUser, BolaoNet.Model.Boloes.Bolao bolao, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, "sp_BoloesMembrosPontos_Classificacao", true, currentUser,
                base.Parameters.Create("@NomeBolao", DbType.String, bolao.Nome),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            return Util.BolaoMembros.ConvertUserPontosToList(table);
        }
        public bool IsUserInBolao(string currentUser, Framework.Security.Model.UserData usuario, BolaoNet.Model.Boloes.Bolao bolao, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;



            base.ExecuteNonQuery(CommandType.StoredProcedure, "sp_Boloes_UsersInBolao", true, currentUser,
                base.Parameters.Create("@NomeBolao", DbType.String, bolao.Nome),
                base.Parameters.Create("@UserName", DbType.String, usuario.UserName),                
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );


            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) == 1 ? true : false;

        }
        public IList<BolaoNet.Model.Boloes.BolaoMembros> LoadClassificacaoRodada(string currentUser, BolaoNet.Model.Boloes.Bolao bolao, BolaoNet.Model.Campeonatos.Fase fase, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, "sp_BoloesMembrosPontos_LoadClassificacao", true, currentUser,
                base.Parameters.Create("@NomeBolao", DbType.String, bolao.Nome),
                base.Parameters.Create("@NomeFase", DbType.String, fase.Nome),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            return Util.BolaoMembros.ConvertUserPontosToList(table);
        }

        public IList<Model.Boloes.BolaoMembros> LoadClassificacaoGrupo(string currentUser, Model.Boloes.Bolao bolao, Framework.Security.Model.UserData usuario, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, "sp_BoloesMembrosGrupos_Classificacao", true, currentUser,
                base.Parameters.Create("@NomeBolao", DbType.String, bolao.Nome),
                base.Parameters.Create("@UserName", DbType.String, usuario.UserName),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            return Util.BolaoMembros.ConvertUserPontosToList(table);
        }
        public bool InsertGrupoMembro(string currentUser, Model.Boloes.Bolao bolao, Framework.Security.Model.UserData usuario, Model.Boloes.BolaoMembros usuarioSelecionado, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;



            base.ExecuteNonQuery(CommandType.StoredProcedure, "sp_BoloesMembrosGrupos_IN", true, currentUser,
                base.Parameters.Create("@NomeBolao", DbType.String, bolao.Nome),
                base.Parameters.Create("@UserName", DbType.String, usuario.UserName),
                base.Parameters.Create("@UserNameSelecionado", DbType.String, usuarioSelecionado.UserName),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );


            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) == 1 ? true : false;
        }
        public bool DeleteGrupoMembro(string currentUser, Model.Boloes.Bolao bolao, Framework.Security.Model.UserData usuario, Model.Boloes.BolaoMembros usuarioSelecionado, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;



            base.ExecuteNonQuery(CommandType.StoredProcedure, "sp_BoloesMembrosGrupos_DE", true, currentUser,
                base.Parameters.Create("@NomeBolao", DbType.String, bolao.Nome),
                base.Parameters.Create("@UserName", DbType.String, usuario.UserName),
                base.Parameters.Create("@UserNameSelecionado", DbType.String, usuarioSelecionado.UserName),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );


            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) == 1 ? true : false;
        }



        #endregion

        #region IDaoBolaoPremio Members

        public IList<Framework.DataServices.Model.EntityBaseData> SelectPremios(string currentUser, BolaoNet.Model.Boloes.Bolao bolao, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;



            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, "sp_BoloesPremios_LoadAll", true, currentUser,
                base.Parameters.Create("@NomeBolao", DbType.String, bolao.Nome),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            int rowsFound = Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value);

            errorDescription = base.ExecutionStatus.ErrorDescription;
            errorNumber = base.ExecutionStatus.ErrorNumber;


            return Util.BolaoPremio.ConvertToPremioList(table);
        }

        #endregion

        #region IDaoBolaoRequests Members

        public bool BolaoParticipar(string currentUser, BolaoNet.Model.Boloes.BolaoRequest request, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            base.ExecuteNonQuery(CommandType.StoredProcedure, "sp_BoloesRequests_AddNew", true, currentUser,
                base.Parameters.Create("@NomeBolao", DbType.String, request.Bolao.Nome),
                base.Parameters.Create("@Owner", DbType.String, request.Owner),                
                base.Parameters.Create("@StatusRequestID", DbType.Int32, (int)request.StatusRequestID),                
                base.Parameters.Create("@RequestedBy", DbType.String, request.RequestedBy),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            errorNumber = base.ExecutionStatus.ErrorNumber;
            errorDescription = base.ExecutionStatus.ErrorDescription;

            request.RequestID =Convert.ToInt32( base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value);


            return request.RequestID > 0 ? true : false;
        }

        public bool BolaoChangeStatus(string currentUser, BolaoNet.Model.Boloes.BolaoRequest request, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            base.ExecuteNonQuery(CommandType.StoredProcedure, "sp_BoloesRequests_ChangeStatus", true, currentUser,
                base.Parameters.Create("@RequestID", DbType.Int32, request.RequestID),
                base.Parameters.Create("@NomeBolao", DbType.String, request.Bolao.Nome),
                base.Parameters.Create("@AnsweredBy", DbType.String, request.AnsweredBy),
                base.Parameters.Create("@StatusRequestID", DbType.Int32, (int)request.StatusRequestID),
                base.Parameters.Create("@Descricao", DbType.String, request.Descricao),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            errorNumber = base.ExecutionStatus.ErrorNumber;
            errorDescription = base.ExecutionStatus.ErrorDescription;

            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) == 1 ? true : false;
        }


        public IList<Framework.DataServices.Model.EntityBaseData> SelectRequestsAll(string currentUser, string condition, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, "sp_BoloesRequests_All", true, currentUser,
                base.Parameters.Create("@Condition", DbType.String, condition),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            errorNumber = base.ExecutionStatus.ErrorNumber;
            errorDescription = base.ExecutionStatus.ErrorDescription;

            return Util.BolaoRequest.ConvertToRequestList(table);
        }
        public IList<Framework.DataServices.Model.EntityBaseData> SelectRequestsAll(string currentUser, BolaoNet.Model.Boloes.Bolao bolao, string condition, out int errorNumber, out string errorDescription)
        {
            string newCondition = condition;

            if (!string.IsNullOrEmpty(newCondition))
                newCondition += " AND BoloesRequests.NomeBolao = '" + bolao.Nome + "'";
            else
                newCondition = "BoloesRequests.NomeBolao = '" + bolao.Nome + "'";

            return SelectRequestsAll(currentUser, newCondition, out errorNumber, out errorDescription);
        }
        public IList<Framework.DataServices.Model.EntityBaseData> SelectRequestsPendentes(string currentUser, BolaoNet.Model.Boloes.Bolao bolao, string condition, out int errorNumber, out string errorDescription)
        {
            return SelectRequestsAll(currentUser, bolao,"(BoloesRequests.AnsweredBy IS NULL OR BoloesRequests.AnsweredDate IS NULL) ",                                                     
                                                    //"AND (BoloesRequests.StatusRequestID <> " + (int)Model.Boloes.BolaoRequest.Status.Convidado + ")",
                                                    out errorNumber, out errorDescription);
        }

        #endregion

        #region IDaoBolaoCriteriosPontos Members

        public IList<Framework.DataServices.Model.EntityBaseData> LoadCriteriosPontos(string currentUser, BolaoNet.Model.Boloes.Bolao bolao, string condition, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, "sp_BoloesCriteriosPontos_All", true, currentUser,
                base.Parameters.Create("@NomeBolao", DbType.String, bolao.Nome),
                base.Parameters.Create("@Condition", DbType.String, condition),                
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            errorNumber = base.ExecutionStatus.ErrorNumber;
            errorDescription = base.ExecutionStatus.ErrorDescription;

            return Util.BolaoCriterioPontos.ConvertToCriteriosPontosList(table);
        }

        public bool UpdateCriterioPontos(string currentUser, BolaoNet.Model.Boloes.BolaoCriterioPontos entry, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            
            base.ExecuteNonQuery(CommandType.StoredProcedure, "sp_BoloesCriteriosPontos_UP", true, currentUser,
                 base.Parameters.Create("@NomeBolao", DbType.String, entry.Bolao.Nome),
                 base.Parameters.Create("@Pontos", DbType.String, entry.Pontos),                 
                 base.Parameters.Create("@Descricao", DbType.String, entry.Descricao),
                 base.Parameters.Create("@CriterioID", DbType.Int32, (int)entry.CriterioID),
                 //base.Parameters.Create("@NomeTime", DbType.String, entry.Time.Nome),
                 //base.Parameters.Create("@MultiploTime", DbType.Int32, entry.MultiploTime),                             
                 base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );


            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) >= 1 ? true : false;
        }

        #endregion

        #region IDaoBolaoCriteriosPontosTimes Members

        public IList<Framework.DataServices.Model.EntityBaseData> LoadCriteriosPontosTimes(string currentUser, BolaoNet.Model.Boloes.Bolao bolao, string condition, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, "sp_BoloesCriteriosPontosTimes_All", true, currentUser,
                base.Parameters.Create("@NomeBolao", DbType.String, bolao.Nome),
                base.Parameters.Create("@Condition", DbType.String, condition),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            errorNumber = base.ExecutionStatus.ErrorNumber;
            errorDescription = base.ExecutionStatus.ErrorDescription;

            return Util.BolaoCriterioPontosTimes.ConvertToCriteriosPontosTimesList(table);
        }

        public bool UpdateCriterioPontosTimes(string currentUser, BolaoNet.Model.Boloes.BolaoCriterioPontosTimes entry, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;


            base.ExecuteNonQuery(CommandType.StoredProcedure, "sp_BoloesCriteriosPontosTimes_UP", true, currentUser,
                 base.Parameters.Create("@NomeBolao", DbType.String, entry.Bolao.Nome),
                 base.Parameters.Create("@NomeTime", DbType.String, entry.Time.Nome),
                 base.Parameters.Create("@Multiplo", DbType.String, entry.MultiploTime),
                //base.Parameters.Create("@NomeTime", DbType.String, entry.Time.Nome),
                //base.Parameters.Create("@MultiploTime", DbType.Int32, entry.MultiploTime),                             
                 base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );


            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) >= 1 ? true : false;
        }

        #endregion

        #region IDaoBolao Members


        public bool Iniciar(string currentUser,string iniciadoBy, Model.Boloes.Bolao bolao, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;


            base.ExecuteNonQuery(CommandType.StoredProcedure, "sp_Boloes_Iniciar", true, currentUser,
                 base.Parameters.Create("@IniciadoBy", DbType.String, iniciadoBy),
                 base.Parameters.Create("@NomeBolao", DbType.String, bolao.Nome),
                 base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            errorDescription = base.ExecutionStatus.ErrorDescription;
            errorNumber = base.ExecutionStatus.ErrorNumber;


            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) >= 1 ? true : false;
        }
        public bool Aguardar(string currentUser, Model.Boloes.Bolao bolao, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;


            base.ExecuteNonQuery(CommandType.StoredProcedure, "sp_Boloes_Aguardar", true, currentUser,
                 base.Parameters.Create("@NomeBolao", DbType.String, bolao.Nome),
                 base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            errorDescription = base.ExecutionStatus.ErrorDescription;
            errorNumber = base.ExecutionStatus.ErrorNumber;


            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) >= 1 ? true : false;
        
        }
        public IList<Framework.DataServices.Model.EntityBaseData> LoadApostasRestantes(string currentUser, BolaoNet.Model.Boloes.Bolao bolao, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;



            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, "sp_BoloesMembros_LoadApostasRestantes", true, currentUser,
                base.Parameters.Create("@NomeBolao", DbType.String, bolao.Nome),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            int rowsFound = Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value);

            errorDescription = base.ExecutionStatus.ErrorDescription;
            errorNumber = base.ExecutionStatus.ErrorNumber;


            return Util.ApostasRestantesUser.ConvertToList(table);
        }

        #endregion

        #region IDaoBoloesPontuacao Members

        public IList<Framework.DataServices.Model.EntityBaseData> SelectPontuacao(string currentUser, BolaoNet.Model.Boloes.Bolao bolao, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;



            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, "sp_BoloesPontuacao_LoadAll", true, currentUser,
                base.Parameters.Create("@NomeBolao", DbType.String, bolao.Nome),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            int rowsFound = Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value);

            errorDescription = base.ExecutionStatus.ErrorDescription;
            errorNumber = base.ExecutionStatus.ErrorNumber;


            return Util.BoloesPontuacao.ConvertToList(table);
        }

        #endregion

        #region Reports Members


        public IList<BolaoNet.Model.Boloes.Reports.UserPontosData> LoadAllPontosDataByUser(string currentUser, BolaoNet.Model.Boloes.Bolao bolao, Framework.Security.Model.UserData usuario, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, "sp_BoloesMembrosPontos_Date", true, currentUser,
                base.Parameters.Create("@NomeBolao", DbType.String, bolao.Nome),
                base.Parameters.Create("@UserName", DbType.String, usuario.UserName),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            return Util.UserPontosData.ConvertUserPontosToList(table);
        }

        #endregion

        #region IDaoBolao Members


        public IList<BolaoNet.Model.Boloes.Reports.UserClassificacaoRodada> LoadHistoricoClassificacao(string currentUser, BolaoNet.Model.Boloes.Bolao bolao, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, "sp_BoloesMembrosPontos_HistClassificacao", true, currentUser,
                base.Parameters.Create("@NomeBolao", DbType.String, bolao.Nome),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            return Util.BolaoUserClassificacao.ConvertUserPontosToList(table);
        }

        #endregion
    }
}
