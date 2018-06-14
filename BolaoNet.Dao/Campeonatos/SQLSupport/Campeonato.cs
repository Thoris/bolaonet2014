using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BolaoNet.Dao.Campeonatos.SQLSupport
{
    public class Campeonato : Framework.DataServices.ItemPaging, IDaoCampeonato
    {
        //#region Constants
        //public new const string TableName = "Campeonatos";
        //public const string TableLinkToTimes = "CampeonatosTimes";
        //#endregion

        #region Constructors/Destructors
        public Campeonato()
            : base (Util.Campeonato.TableName)
        {
        }

        public Campeonato(string connectionName)
            : base(connectionName, Util.Campeonato.TableName)
        {
        }

        public Campeonato(string connectionName, string connectionString, string providerName)
            : base(connectionName, connectionString, providerName, Util.Campeonato.TableName)
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

        //    Model.Campeonatos.Campeonato campeonato = new Model.Campeonatos.Campeonato(nome);
        //    campeonato.LoadDataRow(row);


        //    if (row.Table.Columns.Contains("IsClube") && !Convert.IsDBNull(row["IsClube"]))
        //    {
        //        campeonato.IsClube = Convert.ToBoolean(row["IsClube"]);
        //    }
        //    if (row.Table.Columns.Contains("Descricao") && !Convert.IsDBNull(row["Descricao"]))
        //    {
        //        campeonato.Descricao = Convert.ToString(row["Descricao"]);
        //    }

        //    return campeonato;

        //}



        //public static IList<Model.Campeonatos.CampeonatoClassificacao> ConvertToClassificacaoList(DataTable table)
        //{
        //    IList<Model.Campeonatos.CampeonatoClassificacao> list = new List<Model.Campeonatos.CampeonatoClassificacao>();

        //    foreach (DataRow row in table.Rows)
        //    {
        //        list.Add(ConvertToClassificacaoObject(row));
        //    }

        //    return list;
        //}
        //public static Model.Campeonatos.CampeonatoClassificacao ConvertToClassificacaoObject(DataRow row)
        //{

        //    Model.Campeonatos.CampeonatoClassificacao entry = new Model.Campeonatos.CampeonatoClassificacao();


        //    if (row.Table.Columns.Contains("NomeCampeonato") && !Convert.IsDBNull(row["NomeCampeonato"]))
        //    {
        //        entry.Campeonato = new Model.Campeonatos.Campeonato(Convert.ToString(row["NomeCampeonato"]));
        //    }

        //    if (row.Table.Columns.Contains("NomeFase") && !Convert.IsDBNull(row["NomeFase"]))
        //    {
        //        entry.Fase = new Model.Campeonatos.Fase(Convert.ToString(row["NomeFase"]));
        //    }
        //    if (row.Table.Columns.Contains("NomeTime") && !Convert.IsDBNull(row["NomeTime"]))
        //    {
        //        entry.Time = new Model.DadosBasicos.Time (Convert.ToString(row["NomeTime"]));
        //    }
        //    if (row.Table.Columns.Contains("NomeGrupo") && !Convert.IsDBNull(row["NomeGrupo"]))
        //    {
        //        entry.Grupo = new Model.Campeonatos.Grupo(Convert.ToString(row["NomeGrupo"]));
        //    }

        //    if (row.Table.Columns.Contains("TotalVitorias") && !Convert.IsDBNull(row["TotalVitorias"]))
        //    {
        //        entry.TotalVitorias = Convert.ToInt32(row["TotalVitorias"]);
        //    }
        //    if (row.Table.Columns.Contains("TotalDerrotas") && !Convert.IsDBNull(row["TotalDerrotas"]))
        //    {
        //        entry.TotalDerrotas = Convert.ToInt32(row["TotalDerrotas"]);
        //    }
        //    if (row.Table.Columns.Contains("TotalEmpates") && !Convert.IsDBNull(row["TotalEmpates"]))
        //    {
        //        entry.TotalEmpates = Convert.ToInt32(row["TotalEmpates"]);
        //    }
        //    if (row.Table.Columns.Contains("TotalGolsContra") && !Convert.IsDBNull(row["TotalGolsContra"]))
        //    {
        //        entry.TotalGolsContra = Convert.ToInt32(row["TotalGolsContra"]);
        //    }
        //    if (row.Table.Columns.Contains("TotalGolsPro") && !Convert.IsDBNull(row["TotalGolsPro"]))
        //    {
        //        entry.TotalGolsPro = Convert.ToInt32(row["TotalGolsPro"]);
        //    }
        //    if (row.Table.Columns.Contains("TotalPontos") && !Convert.IsDBNull(row["TotalPontos"]))
        //    {
        //        entry.TotalPontos = Convert.ToInt32(row["TotalPontos"]);
        //    }
        //    if (row.Table.Columns.Contains("Saldo") && !Convert.IsDBNull(row["Saldo"]))
        //    {
        //        entry.Saldo = Convert.ToInt32(row["Saldo"]);
        //    }
        //    if (row.Table.Columns.Contains("Jogos") && !Convert.IsDBNull(row["Jogos"]))
        //    {
        //        entry.Jogos = Convert.ToInt32(row["Jogos"]);
        //    }
        //    if (row.Table.Columns.Contains("Posicao") && !Convert.IsDBNull(row["Posicao"]))
        //    {
        //        entry.Posicao = Convert.ToInt32(row["Posicao"]);
        //    }
        //    if (row.Table.Columns.Contains("LastPosicao") && !Convert.IsDBNull(row["LastPosicao"]))
        //    {
        //        entry.LastPosicao = Convert.ToInt32(row["LastPosicao"]);
        //    }

        //    entry.LoadDataRow(row);



        //    return entry;

        //}



        //public static IList<Framework.DataServices.Model.EntityBaseData> ConvertToPosicaoList(DataTable table)
        //{
        //    IList<Framework.DataServices.Model.EntityBaseData> list = new List<Framework.DataServices.Model.EntityBaseData>();

        //    foreach (DataRow row in table.Rows)
        //    {
        //        list.Add(ConvertToPosicaoObject(row));
        //    }

        //    return list;
        //}
        //public static Framework.DataServices.Model.EntityBaseData ConvertToPosicaoObject(DataRow row)
        //{
        //    string nomeCampeonato = "";
        //    string nomeFase = "";
        //    string nomeGrupo = "";
        //    int posicao = 0;

        //    if (row.Table.Columns.Contains("NomeCampeonato") && !Convert.IsDBNull(row["NomeCampeonato"]))
        //    {
        //        nomeCampeonato = Convert.ToString(row["NomeCampeonato"]);
        //    }
        //    if (row.Table.Columns.Contains("NomeFase") && !Convert.IsDBNull(row["NomeFase"]))
        //    {
        //        nomeFase = Convert.ToString(row["NomeFase"]);
        //    }
        //    if (row.Table.Columns.Contains("NomeGrupo") && !Convert.IsDBNull(row["NomeGrupo"]))
        //    {
        //        nomeGrupo = Convert.ToString(row["NomeGrupo"]);
        //    }
        //    if (row.Table.Columns.Contains("Posicao") && !Convert.IsDBNull(row["Posicao"]))
        //    {
        //        posicao = Convert.ToInt32(row["Posicao"]);
        //    }

        //    Model.Campeonatos.CampeonatoPosicao campeonatoPosicao = new Model.Campeonatos.CampeonatoPosicao
        //        (nomeCampeonato, nomeFase, nomeGrupo, posicao);
        //    campeonatoPosicao.LoadDataRow(row);


        //    if (row.Table.Columns.Contains("Titulo") && !Convert.IsDBNull(row["Titulo"]))
        //    {
        //        campeonatoPosicao.Titulo = Convert.ToString(row["Titulo"]);
        //    }
        //    if (row.Table.Columns.Contains("BackColor") && !Convert.IsDBNull(row["BackColor"]))
        //    {
        //        campeonatoPosicao.BackColor = System.Drawing.Color.FromName(Convert.ToString(row["BackColor"]));
        //    }
        //    if (row.Table.Columns.Contains("ForeColor") && !Convert.IsDBNull(row["ForeColor"]))
        //    {
        //        campeonatoPosicao.ForeColor = System.Drawing.Color.FromName(Convert.ToString(row["ForeColor"]));
        //    }


        //    return campeonatoPosicao;

        //}



        //public static IList<Model.Campeonatos.CampeonatoRecord> ConvertToRecordList(DataTable table)
        //{
        //    IList<Model.Campeonatos.CampeonatoRecord> list = new List<Model.Campeonatos.CampeonatoRecord>();

        //    foreach (DataRow row in table.Rows)
        //    {
        //        Model.Campeonatos.CampeonatoRecord entry = ConvertToRecordObject(row);

        //        entry.Posicao = list.Count + 1;
        //        list.Add(entry);
        //    }

        //    return list;
        //}
        //public static Model.Campeonatos.CampeonatoRecord ConvertToRecordObject(DataRow row)
        //{
        //    string nomeTime = "";

        //    if (row.Table.Columns.Contains("NomeTime") && !Convert.IsDBNull(row["NomeTime"]))
        //    {
        //        nomeTime = Convert.ToString(row["NomeTime"]);
        //    }

        //    Model.Campeonatos.CampeonatoRecord entry = new BolaoNet.Model.Campeonatos.CampeonatoRecord(nomeTime);
        //    entry.LoadDataRow(row);


        //    if (row.Table.Columns.Contains("Vitoria") && !Convert.IsDBNull(row["Vitoria"]))
        //    {
        //        entry.Vitorias = Convert.ToInt32(row["Vitoria"]);
        //    }
        //    if (row.Table.Columns.Contains("Derrota") && !Convert.IsDBNull(row["Derrota"]))
        //    {
        //        entry.Derrotas = Convert.ToInt32(row["Derrota"]);
        //    }
        //    if (row.Table.Columns.Contains("Empate") && !Convert.IsDBNull(row["Empate"]))
        //    {
        //        entry.Empates = Convert.ToInt32(row["Empate"]);
        //    }

        //    return entry;

        //}


        //public static IList<Model.Campeonatos.Reports.GolsFrequencia> ConvertToGolsFrequenciaList(DataTable table)
        //{
        //    IList<Model.Campeonatos.Reports.GolsFrequencia> list = new List<Model.Campeonatos.Reports.GolsFrequencia>();

        //    foreach (DataRow row in table.Rows)
        //    {
        //        Model.Campeonatos.Reports.GolsFrequencia entry = ConvertToGolsFrequenciaObject(row);

        //        list.Add(entry);
        //    }

        //    return list;
        //}
        //public static Model.Campeonatos.Reports.GolsFrequencia ConvertToGolsFrequenciaObject(DataRow row)
        //{


        //    Model.Campeonatos.Reports.GolsFrequencia entry = new Model.Campeonatos.Reports.GolsFrequencia ();
        //    entry.LoadDataRow(row);


        //    if (row.Table.Columns.Contains("Gols1") && !Convert.IsDBNull(row["Gols1"]))
        //    {
        //        entry.Gols1 = Convert.ToInt32(row["Gols1"]);
        //    }
        //    if (row.Table.Columns.Contains("Gols2") && !Convert.IsDBNull(row["Gols2"]))
        //    {
        //        entry.Gols2 = Convert.ToInt32(row["Gols2"]);
        //    }
        //    if (row.Table.Columns.Contains("Total") && !Convert.IsDBNull(row["Total"]))
        //    {
        //        entry.Total = Convert.ToInt32(row["Total"]);
        //    }
            

        //    return entry;

        //}



        //public static IList<Model.Campeonatos.Reports.TimeRodadas> ConvertToTimesRodadasList(DataTable table)
        //{
        //    IList<Model.Campeonatos.Reports.TimeRodadas> list = new List<Model.Campeonatos.Reports.TimeRodadas>();

        //    foreach (DataRow row in table.Rows)
        //    {
        //        Model.Campeonatos.Reports.TimeRodadas entry = ConvertToTimesRodadasObject(row);

        //        list.Add(entry);
        //    }

        //    return list;
        //}
        //public static Model.Campeonatos.Reports.TimeRodadas ConvertToTimesRodadasObject(DataRow row)
        //{


        //    Model.Campeonatos.Reports.TimeRodadas entry = new Model.Campeonatos.Reports.TimeRodadas();
        //    //entry.LoadDataRow(row);


        //    if (row.Table.Columns.Contains("Rodada") && !Convert.IsDBNull(row["Rodada"]))
        //    {
        //        entry.Rodada = Convert.ToInt32(row["Rodada"]);
        //    }
        //    if (row.Table.Columns.Contains("Posicao") && !Convert.IsDBNull(row["Posicao"]))
        //    {
        //        entry.Posicao = Convert.ToInt32(row["Posicao"]);
        //    }

        //    return entry;

        //}


        #endregion

        #region Times Methods

        public IList<Framework.DataServices.Model.EntityBaseData> LoadTimes(string currentUser, Model.Campeonatos.Campeonato entry, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.Campeonatos.Campeonato entryData = (Model.Campeonatos.Campeonato)entry;


            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, "sp_CampeonatosTimes_Load", true, currentUser,
                base.Parameters.Create("@NomeCampeonato", DbType.String, entryData.Nome),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            return Dao.DadosBasicos.Util.Time.ConvertToList(table);
        }
        public bool InsertTime(string currentUser, Model.Campeonatos.Campeonato campeonato, Model.DadosBasicos.Time time, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.Campeonatos.Campeonato entryCampeonato = (Model.Campeonatos.Campeonato)campeonato;
            Model.DadosBasicos.Time entryTime = (Model.DadosBasicos.Time)time;


            base.ExecuteNonQuery(CommandType.StoredProcedure, "sp_CampeonatosTimes_Add", true, currentUser,
                base.Parameters.Create("@NomeCampeonato", DbType.String, entryCampeonato.Nome),
                base.Parameters.Create("@NomeTime", DbType.String, entryTime.Nome),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );


            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) == 1 ? true : false;
       

        }
        public bool DeleteTime(string currentUser, Model.Campeonatos.Campeonato campeonato, Model.DadosBasicos.Time time, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.Campeonatos.Campeonato entryCampeonato = (Model.Campeonatos.Campeonato)campeonato;
            Model.DadosBasicos.Time entryTime = (Model.DadosBasicos.Time)time;


            base.ExecuteNonQuery(CommandType.StoredProcedure, "sp_CampeonatosTimes_Del", true, currentUser,
                base.Parameters.Create("@NomeCampeonato", DbType.String, entryCampeonato.Nome),
                base.Parameters.Create("@NomeTime", DbType.String, entryTime.Nome),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );


            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) >= 1 ? true : false;


        }
        public bool ClearTimes(string currentUser, Model.Campeonatos.Campeonato campeonato, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.Campeonatos.Campeonato entryCampeonato = (Model.Campeonatos.Campeonato)campeonato;
        

            base.ExecuteNonQuery(CommandType.StoredProcedure, "sp_CampeonatosTimes_Clear", true, currentUser,
                base.Parameters.Create("@NomeCampeonato", DbType.String, entryCampeonato.Nome),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );


            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) >= 0 ? true : false;


        }

        #endregion

        #region Grupos Methods

        public IList<Framework.DataServices.Model.EntityBaseData> LoadGrupos(string currentUser, Model.Campeonatos.Campeonato entry, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.Campeonatos.Campeonato entryData = (Model.Campeonatos.Campeonato)entry;


            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, "sp_CampeonatosGrupos_Load", true, currentUser,
                base.Parameters.Create("@NomeCampeonato", DbType.String, entryData.Nome),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            return Dao.Campeonatos.Util.Grupo.ConvertToList(table);
        }
        public bool InsertGrupo(string currentUser, Model.Campeonatos.Campeonato campeonato, Model.Campeonatos.Grupo grupo, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.Campeonatos.Campeonato entryCampeonato = (Model.Campeonatos.Campeonato)campeonato;
            Model.Campeonatos.Grupo entryGrupo = (Model.Campeonatos.Grupo)grupo;


            base.ExecuteNonQuery(CommandType.StoredProcedure, "sp_CampeonatosGrupos_Add", true, currentUser,
                base.Parameters.Create("@NomeCampeonato", DbType.String, entryCampeonato.Nome),
                base.Parameters.Create("@NomeGrupo", DbType.String, entryGrupo.Nome),
                base.Parameters.Create("@Descricao", DbType.String, entryGrupo.Descricao),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );


            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) == 1 ? true : false;


        }
        public bool DeleteGrupo(string currentUser, Model.Campeonatos.Campeonato campeonato, Model.Campeonatos.Grupo grupo, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.Campeonatos.Campeonato entryCampeonato = (Model.Campeonatos.Campeonato)campeonato;
            Model.Campeonatos.Grupo entryGrupo = (Model.Campeonatos.Grupo)grupo;


            base.ExecuteNonQuery(CommandType.StoredProcedure, "sp_CampeonatosGrupos_Del", true, currentUser,
                base.Parameters.Create("@NomeCampeonato", DbType.String, entryCampeonato.Nome),
                base.Parameters.Create("@NomeGrupo", DbType.String, entryGrupo.Nome),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );


            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) >= 1 ? true : false;


        }
        public bool ClearGrupos(string currentUser, Model.Campeonatos.Campeonato campeonato, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.Campeonatos.Campeonato entryCampeonato = (Model.Campeonatos.Campeonato)campeonato;


            base.ExecuteNonQuery(CommandType.StoredProcedure, "sp_CampeonatosGrupos_Clear", true, currentUser,
                base.Parameters.Create("@NomeCampeonato", DbType.String, entryCampeonato.Nome),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );


            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) >= 0 ? true : false;


        }
        public bool UpdateGrupo(string currentUser, Model.Campeonatos.Campeonato campeonato, Model.Campeonatos.Grupo grupo, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.Campeonatos.Campeonato entryCampeonato = (Model.Campeonatos.Campeonato)campeonato;
            Model.Campeonatos.Grupo entryGrupo = (Model.Campeonatos.Grupo)grupo;


            base.ExecuteNonQuery(CommandType.StoredProcedure, "sp_CampeonatosGrupos_Update", true, currentUser,
                base.Parameters.Create("@NomeCampeonato", DbType.String, entryCampeonato.Nome),
                base.Parameters.Create("@NomeGrupo", DbType.String, entryGrupo.Nome),
                base.Parameters.Create("@Descricao", DbType.String, entryGrupo.Descricao),                
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );


            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) == 1 ? true : false;


        }
        
        #endregion

        #region Fases Members

        public IList<Framework.DataServices.Model.EntityBaseData> LoadFases(string currentUser, BolaoNet.Model.Campeonatos.Campeonato entry, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.Campeonatos.Campeonato entryData = (Model.Campeonatos.Campeonato)entry;


            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, "sp_CampeonatosFases_Load", true, currentUser,
                base.Parameters.Create("@NomeCampeonato", DbType.String, entryData.Nome),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            return Dao.Campeonatos.Util.Fase.ConvertToList(table);
        }
        public bool InsertFase(string currentUser, BolaoNet.Model.Campeonatos.Campeonato campeonato, BolaoNet.Model.Campeonatos.Fase fase, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.Campeonatos.Campeonato entryCampeonato = (Model.Campeonatos.Campeonato)campeonato;
            Model.Campeonatos.Fase entryFase = (Model.Campeonatos.Fase)fase ;


            base.ExecuteNonQuery(CommandType.StoredProcedure, "sp_CampeonatosFases_Add", true, currentUser,
                base.Parameters.Create("@NomeCampeonato", DbType.String, entryCampeonato.Nome),
                base.Parameters.Create("@NomeFase", DbType.String, entryFase.Nome),
                base.Parameters.Create("@Descricao", DbType.String, entryFase.Descricao),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );


            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) == 1 ? true : false;
        }
        public bool DeleteFase(string currentUser, BolaoNet.Model.Campeonatos.Campeonato campeonato, BolaoNet.Model.Campeonatos.Fase fase, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.Campeonatos.Campeonato entryCampeonato = (Model.Campeonatos.Campeonato)campeonato;
            Model.Campeonatos.Fase entryFase = (Model.Campeonatos.Fase)fase;


            base.ExecuteNonQuery(CommandType.StoredProcedure, "sp_CampeonatosFases_Del", true, currentUser,
                base.Parameters.Create("@NomeCampeonato", DbType.String, entryCampeonato.Nome),
                base.Parameters.Create("@NomeFase", DbType.String, entryFase.Nome),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );


            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) >= 1 ? true : false;
        }
        public bool ClearFases(string currentUser, BolaoNet.Model.Campeonatos.Campeonato campeonato, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.Campeonatos.Campeonato entryCampeonato = (Model.Campeonatos.Campeonato)campeonato;


            base.ExecuteNonQuery(CommandType.StoredProcedure, "sp_CampeonatosFases_Clear", true, currentUser,
                base.Parameters.Create("@NomeCampeonato", DbType.String, entryCampeonato.Nome),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );


            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) >= 0 ? true : false;
        }
        public bool UpdateFase(string currentUser, BolaoNet.Model.Campeonatos.Campeonato campeonato, BolaoNet.Model.Campeonatos.Fase fase, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.Campeonatos.Campeonato entryCampeonato = (Model.Campeonatos.Campeonato)campeonato;
            Model.Campeonatos.Fase entryFase = (Model.Campeonatos.Fase)fase;


            base.ExecuteNonQuery(CommandType.StoredProcedure, "sp_CampeonatosFases_Update", true, currentUser,
                base.Parameters.Create("@NomeCampeonato", DbType.String, entryCampeonato.Nome),
                base.Parameters.Create("@NomeFase", DbType.String, entryFase.Nome),
                base.Parameters.Create("@Descricao", DbType.String, entryFase.Descricao),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );


            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) == 1 ? true : false;

        }

        #endregion

        #region IDaoBase Members

        public Framework.DataServices.Model.EntityBaseData Load(string currentUser, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.Campeonatos.Campeonato entryData = (Model.Campeonatos.Campeonato)entry;


            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, base._commandSelect, true, currentUser,
                base.Parameters.Create("@Nome", DbType.String, entryData.Nome), 
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null) 
                );

            int rowsFound = Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value);

            if (rowsFound == 0)
                return null;
                //throw new Exception("There is no item found in database with this ID.");


            return Util.Campeonato.ConvertToObject(table.Rows[0]);
        }
        public bool Insert(string currentUser, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.Campeonatos.Campeonato entryData = (Model.Campeonatos.Campeonato)entry;

            base.ExecuteNonQuery(CommandType.StoredProcedure, base._commandInsert, true, currentUser,
                base.Parameters.Create("@Nome", DbType.String, entryData.Nome),
                base.Parameters.Create("@IsClube", DbType.Boolean, entryData.IsClube),
                base.Parameters.Create("@Descricao", DbType.String, entryData.Descricao),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            
            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) == 1 ? true : false;
        }
        public bool Update(string currentUser, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.Campeonatos.Campeonato entryData = (Model.Campeonatos.Campeonato)entry;

            base.ExecuteNonQuery(CommandType.StoredProcedure, base._commandUpdate, true, currentUser,
                base.Parameters.Create("@Nome", DbType.String, entryData.Nome),
                base.Parameters.Create("@IsClube", DbType.Boolean, entryData.IsClube),
                base.Parameters.Create("@Descricao", DbType.String, entryData.Descricao),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );


            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) >= 1 ? true : false;
        }
        public bool Delete(string currentUser, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.Campeonatos.Campeonato entryData = (Model.Campeonatos.Campeonato)entry;

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

            return Util.Campeonato.ConvertToList(table);

        }
        public IList<Framework.DataServices.Model.EntityBaseData> SelectPage(string currentUser, string condition, string order, int pageNumber, int pageSize, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            return Util.Campeonato.ConvertToList(
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

            return Util.Campeonato.ConvertToList(table);
        }

        #endregion

        #region IDaoCampeonato Members

        public IList<int> LoadRodadas(string currentUser, BolaoNet.Model.Campeonatos.Campeonato campeonato, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            IList<int> list = new List<int>();

            try
            {
                System.Data.Common.DbDataReader reader = (System.Data.Common.DbDataReader)base.ExecuteReader(
                    CommandType.StoredProcedure, "sp_Campeonatos_LoadRodadas", true, currentUser, false,
                    base.Parameters.Create("@Nome", DbType.String, campeonato.Nome),
                    base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                    );

                while (reader.Read())
                {
                    if (!Convert.IsDBNull(reader[0]))
                    {
                        list.Add(Convert.ToInt32(reader[0]));
                    }
                }
            }
            finally
            {
                base.Close();
            }
            return list;
        }
        public IList<BolaoNet.Model.Campeonatos.CampeonatoClassificacao> LoadClassificacao(string currentUser, BolaoNet.Model.Campeonatos.Campeonato campeonato, BolaoNet.Model.Campeonatos.Fase fase, BolaoNet.Model.Campeonatos.Grupo grupo, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, "sp_CampeonatosClassificacao_LoadClassificacao", true, currentUser,
                base.Parameters.Create("@NomeCampeonato", DbType.String, campeonato.Nome),
                base.Parameters.Create("@NomeFase", DbType.String, fase.Nome),
                base.Parameters.Create("@NomeGrupo", DbType.String, grupo == null ? null : grupo.Nome),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            return Util.CampeonatoClassificacao.ConvertToClassificacaoList(table);
        }
        public IList<Framework.DataServices.Model.EntityBaseData> LoadJogos(string currentUser, int rodada, Model.Campeonatos.Fase fase, Model.Campeonatos.Grupo grupo, BolaoNet.Model.Campeonatos.Campeonato campeonato, DateTime dataInicial, DateTime dataFinal, string condition, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, "sp_Campeonatos_LoadJogos", true, currentUser,
                base.Parameters.Create("@NomeCampeonato", DbType.String, campeonato.Nome),
                base.Parameters.Create("@Rodada", DbType.String, rodada),
                base.Parameters.Create("@NomeFase", DbType.String, fase == null ? null : fase.Nome),
                base.Parameters.Create("@NomeGrupo", DbType.String, grupo == null ? null : grupo.Nome),
                base.Parameters.Create("@DataInicial", DbType.DateTime, dataInicial ),
                base.Parameters.Create("@DataFinal", DbType.DateTime, dataFinal),
                base.Parameters.Create("@Condition", DbType.String, condition),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            return (IList<Framework.DataServices.Model.EntityBaseData>)Dao.Campeonatos.Util.Jogo.ConvertToList(table);
        }




        #endregion

        #region IDaoCampeonatoPosicoes Members

        public IList<Framework.DataServices.Model.EntityBaseData> SelectPosicoes(string currentUser, Model.Campeonatos.Campeonato campeonato, Model.Campeonatos.Fase fase, Model.Campeonatos.Grupo grupo, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;



            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, "sp_CampeonatosPosicoes_LoadAll", true, currentUser,
                base.Parameters.Create("@NomeCampeonato", DbType.String, campeonato.Nome),
                base.Parameters.Create("@NomeFase", DbType.String, fase.Nome),
                base.Parameters.Create("@NomeGrupo", DbType.String, grupo.Nome),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            int rowsFound = Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value);

            errorDescription = base.ExecutionStatus.ErrorDescription;
            errorNumber = base.ExecutionStatus.ErrorNumber;

            
            return Util.CampeonatoPosicao.ConvertToPosicaoList(table);
        }

        #endregion

        #region IDaoCampeonatoRecordTime Members

        public bool LoadRecordPlacar(string currentUser, Model.Campeonatos.Campeonato entry, RecordTipoPesquisa tipo, out IList<Model.Campeonatos.CampeonatoRecord> general,out  IList<Model.Campeonatos.CampeonatoRecord> dentro,out IList<Model.Campeonatos.CampeonatoRecord> fora, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;


            DataSet dsResult = base.ExecuteDataSet (CommandType.StoredProcedure, "sp_CampeonatosRecords", true, currentUser,
                base.Parameters.Create("@NomeCampeonato", DbType.String, entry.Nome),
                base.Parameters.Create("@TipoPesquisa", DbType.Int16, (int)tipo),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );


            general = Util.CampeonatoRecord.ConvertToRecordList(dsResult.Tables[0]);
            dentro = Util.CampeonatoRecord.ConvertToRecordList(dsResult.Tables[1]);
            fora = Util.CampeonatoRecord.ConvertToRecordList(dsResult.Tables[2]);


            int rowsFound = Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value);

            errorDescription = base.ExecutionStatus.ErrorDescription;
            errorNumber = base.ExecutionStatus.ErrorNumber;


            return true;


        }

        public bool LoadRecordJogosGols(string currentUser, Model.Campeonatos.Campeonato entry, Model.DadosBasicos.Time time, bool getRecord,  out Model.Campeonatos.CampeonatoRecord general, out Model.Campeonatos.CampeonatoRecord dentro, out Model.Campeonatos.CampeonatoRecord fora, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;


            base.ExecuteNonQuery(CommandType.StoredProcedure, "sp_CampeonatosRecordTimeRecordJogosGols", true, currentUser,
                base.Parameters.Create("@NomeCampeonato", DbType.String, entry.Nome),
                base.Parameters.Create("@NomeTime", DbType.String, time.Nome),
                base.Parameters.Create("@GetRecord", DbType.Boolean, getRecord),                
                base.Parameters.Create("@JogosSemMarcar", DbType.Int32, ParameterDirection.Output, null),
                base.Parameters.Create("@JogosSemMarcarDentro", DbType.Int32, ParameterDirection.Output, null),
                base.Parameters.Create("@JogosSemMarcarFora", DbType.Int32, ParameterDirection.Output, null),
                base.Parameters.Create("@JogosSemLevar", DbType.Int32, ParameterDirection.Output, null),
                base.Parameters.Create("@JogosSemLevarDentro", DbType.Int32, ParameterDirection.Output, null),
                base.Parameters.Create("@JogosSemLevarFora", DbType.Int32, ParameterDirection.Output, null),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            int rowsFound = Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value);

            errorDescription = base.ExecutionStatus.ErrorDescription;
            errorNumber = base.ExecutionStatus.ErrorNumber;


            general = new BolaoNet.Model.Campeonatos.CampeonatoRecord(time.Nome);
            fora = new BolaoNet.Model.Campeonatos.CampeonatoRecord(time.Nome);
            dentro = new BolaoNet.Model.Campeonatos.CampeonatoRecord(time.Nome);
            
            general.JogosSemLevar = Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@JogosSemLevar"]);
            fora.JogosSemLevar = Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@JogosSemLevarFora"]);
            dentro.JogosSemLevar = Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@JogosSemLevarDentro"]);


            general.JogosSemMarcar = Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@JogosSemMarcar"]);
            fora.JogosSemMarcar = Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@JogosSemMarcarFora"]);
            dentro.JogosSemMarcar = Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@JogosSemMarcarDentro"]);

            return true;

        }
        


        

        #endregion

        #region IDaoCampeonatoReports Members

        public IList<BolaoNet.Model.Campeonatos.Reports.GolsFrequencia> LoadGolsFrequencia(string currentUser, BolaoNet.Model.Campeonatos.Campeonato campeonato, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;



            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, "sp_CampeonatosRecordGolsFrequencia", true, currentUser,
                base.Parameters.Create("@NomeCampeonato", DbType.String, campeonato.Nome),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );


            int rowsFound = Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value);

            errorDescription = base.ExecutionStatus.ErrorDescription;
            errorNumber = base.ExecutionStatus.ErrorNumber;


            return Util.GolsFrequencia.ConvertToGolsFrequenciaList(table);
        }



        public IList<BolaoNet.Model.Campeonatos.Reports.TimeRodadas>  LoadTimesRodadas(string currentUser, BolaoNet.Model.Campeonatos.Campeonato campeonato, BolaoNet.Model.Campeonatos.Fase fase, BolaoNet.Model.Campeonatos.Grupo grupo, Model.DadosBasicos.Time time, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;



            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, "sp_CampeonatosTimeClassificacaoRodadas", true, currentUser,
                base.Parameters.Create("@NomeCampeonato", DbType.String, campeonato.Nome),
                base.Parameters.Create("@NomeFase", DbType.String, fase.Nome),
                base.Parameters.Create("@NomeGrupo", DbType.String, grupo.Nome),           
                base.Parameters.Create("@NomeTime", DbType.String, time.Nome),                
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );


            int rowsFound = Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value);

            errorDescription = base.ExecutionStatus.ErrorDescription;
            errorNumber = base.ExecutionStatus.ErrorNumber;


            return Util.TimeRodadas.ConvertToTimesRodadasList(table);
        }

        #endregion

        #region IDaoCampeonatoHistorico Members

        public IList<Framework.DataServices.Model.EntityBaseData> LoadHistorico(string currentUser, BolaoNet.Model.Campeonatos.Campeonato entry, string condition, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;



            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, "sp_CampeonatosHistorico_Load", true, currentUser,
                base.Parameters.Create("@NomeCampeonato", DbType.String, entry.Nome),
                base.Parameters.Create("@Condition", DbType.String, condition),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );


            int rowsFound = Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value);

            errorDescription = base.ExecutionStatus.ErrorDescription;
            errorNumber = base.ExecutionStatus.ErrorNumber;


            return Util.CampeonatoHistorico.ConvertToList(table);
        }

        #endregion
    }
}
