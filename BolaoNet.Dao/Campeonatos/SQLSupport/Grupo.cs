using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BolaoNet.Dao.Campeonatos.SQLSupport
{
    public class Grupo : Framework.DataServices.ItemPaging, IGrupo 
    {
        //#region Constants
        //public new const string TableName = "CampeonatosGrupos";
        //public const string TableLinkToTimes = "CampeonatosGruposTimes";
        //#endregion

        #region Constructors/Destructors
        public Grupo()
            : base (Util.Grupo.TableName)
        {
        }

        public Grupo(string connectionName)
            : base(connectionName, Util.Grupo.TableName)
        {
        }

        public Grupo(string connectionName, string connectionString, string providerName)
            : base(connectionName, connectionString, providerName, Util.Grupo.TableName)
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
        //    string nome = "";

        //    if (row.Table.Columns.Contains("Nome") && !Convert.IsDBNull(row["Nome"]))
        //    {
        //        nome = Convert.ToString(row["Nome"]);
        //    }

        //    Model.Campeonatos.Grupo entry = new Model.Campeonatos.Grupo(nome);
        //    entry.LoadDataRow(row);


         
        //    if (row.Table.Columns.Contains("Descricao") && !Convert.IsDBNull(row["Descricao"]))
        //    {
        //        entry.Descricao = Convert.ToString(row["Descricao"]);
        //    }

                 

        //    return entry;

        //}

        //#endregion

        #region IGrupo Members


        public IList<Framework.DataServices.Model.EntityBaseData> LoadTimes(string currentUser, Model.Campeonatos.Campeonato campeonato, Model.Campeonatos.Grupo grupo, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            

            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, "sp_CampeonatosGruposTimes_Load", true, currentUser,
                base.Parameters.Create("@NomeCampeonato", DbType.String, campeonato.Nome),
                base.Parameters.Create("@NomeGrupo", DbType.String, grupo.Nome),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            return Dao.DadosBasicos.Util.Time.ConvertToList(table);
        }
        public bool InsertTime(string currentUser, Model.Campeonatos.Campeonato campeonato, Model.Campeonatos.Grupo grupo, Model.DadosBasicos.Time time, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            
            base.ExecuteNonQuery(CommandType.StoredProcedure, "sp_CampeonatosGruposTimes_Add", true, currentUser,
                base.Parameters.Create("@NomeCampeonato", DbType.String, campeonato.Nome),
                base.Parameters.Create("@NomeGrupo", DbType.String, grupo.Nome),
                base.Parameters.Create("@NomeTime", DbType.String, time.Nome),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );


            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) == 1 ? true : false;


        }
        public bool DeleteTime(string currentUser, Model.Campeonatos.Campeonato campeonato, Model.Campeonatos.Grupo grupo, Model.DadosBasicos.Time time, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            
            base.ExecuteNonQuery(CommandType.StoredProcedure, "sp_CampeonatosGruposTimes_Del", true, currentUser,
                base.Parameters.Create("@NomeCampeonato", DbType.String, campeonato.Nome),
                base.Parameters.Create("@NomeGrupo", DbType.String, grupo.Nome),
                base.Parameters.Create("@NomeTime", DbType.String, time.Nome),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );


            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) >= 1 ? true : false;


        }
        public bool ClearTimes(string currentUser, Model.Campeonatos.Campeonato campeonato, Model.Campeonatos.Grupo grupo, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            

            base.ExecuteNonQuery(CommandType.StoredProcedure, "sp_CampeonatosGruposTimes_Clear", true, currentUser,
                base.Parameters.Create("@NomeCampeonato", DbType.String, campeonato.Nome),
                base.Parameters.Create("@NomeGrupo", DbType.String, grupo.Nome),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );


            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) >= 0 ? true : false;


        }

        #endregion
    }
}
