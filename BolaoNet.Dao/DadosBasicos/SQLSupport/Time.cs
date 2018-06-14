using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BolaoNet.Dao.DadosBasicos.SQLSupport
{
    public class Time : Framework.DataServices.ItemPaging , IDaoBase
    {
        //#region Constants
        //public new const string TableName = "Times";
        //#endregion

        #region Constructors/Destructors
        public Time()
            : base (Util.Time.TableName)
        {
        }

        public Time(string connectionName)
            : base(connectionName, Util.Time.TableName)
        {
        }

        public Time(string connectionName, string connectionString, string providerName)
            : base(connectionName, connectionString, providerName, Util.Time.TableName)
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

        //    if (row.Table.Columns.Contains("NomeTime") && !Convert.IsDBNull(row["NomeTime"]))
        //    {
        //        nome = Convert.ToString(row["NomeTime"]);
        //    }

        //    Model.DadosBasicos.Time time = new BolaoNet.Model.DadosBasicos.Time(nome);
        //    time.LoadDataRow(row);


        //    if (row.Table.Columns.Contains("IsClube") && !Convert.IsDBNull(row["IsClube"]))
        //    {
        //        time.IsClube = Convert.ToBoolean(row["IsClube"]);
        //    }
        //    //if (row.Table.Columns.Contains("Escudo") && !Convert.IsDBNull(row["Escudo"]))
        //    //{
        //    //    time.Escudo = Convert.ToString(row["Escudo"]);
        //    //}
        //    if (row.Table.Columns.Contains("Fundacao") && !Convert.IsDBNull(row["Fundacao"]))
        //    {
        //        time.Fundacao = Convert.ToDateTime(row["Fundacao"]);
        //    }
        //    if (row.Table.Columns.Contains("Site") && !Convert.IsDBNull(row["Site"]))
        //    {
        //        time.Site = Convert.ToString(row["Site"]);
        //    }
        //    if (row.Table.Columns.Contains("Pais") && !Convert.IsDBNull(row["Pais"]))
        //    {
        //        time.Pais = Convert.ToString(row["Pais"]);
        //    }
        //    if (row.Table.Columns.Contains("Estado") && !Convert.IsDBNull(row["Estado"]))
        //    {
        //        time.Estado = Convert.ToString(row["Estado"]);
        //    }
        //    if (row.Table.Columns.Contains("Cidade") && !Convert.IsDBNull(row["Cidade"]))
        //    {
        //        time.Cidade = Convert.ToString(row["Cidade"]);
        //    }
        //    if (row.Table.Columns.Contains("Descricao") && !Convert.IsDBNull(row["Descricao"]))
        //    {
        //        time.Descricao = Convert.ToString(row["Descricao"]);
        //    }
        //    if (row.Table.Columns.Contains("NomeMascote") && !Convert.IsDBNull(row["NomeMascote"]))
        //    {
        //        time.NomeMascote = Convert.ToString(row["NomeMascote"]);
        //    }
        //    //if (row.Table.Columns.Contains("Mascote") && !Convert.IsDBNull(row["Mascote"]))
        //    //{
        //    //    time.Mascote = Convert.ToString(row["Mascote"]);
        //    //}
            

        //    return time;

        //}


        //#endregion

        #region IDaoBase Members

        public Framework.DataServices.Model.EntityBaseData Load(string currentUser, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.DadosBasicos.Time entryData = (Model.DadosBasicos.Time)entry;


            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, base._commandSelect, true, currentUser,
                base.Parameters.Create("@Nome", DbType.String, entryData.Nome), 
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null) 
                );

            int rowsFound = Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value);

            if (rowsFound == 0)
                return null;
                //throw new Exception("There is no item found in database with this ID.");


            return Util.Time.ConvertToObject(table.Rows[0]);
        }
        public bool Insert(string currentUser, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.DadosBasicos.Time entryData = (Model.DadosBasicos.Time)entry;

            base.ExecuteNonQuery(CommandType.StoredProcedure, base._commandInsert, true, currentUser,
                base.Parameters.Create("@Nome", DbType.String, entryData.Nome),
                base.Parameters.Create("@IsClube", DbType.Boolean, entryData.IsClube),
                base.Parameters.Create("@Escudo", DbType.AnsiString, entryData.Escudo),
                base.Parameters.Create("@DataFundacao", DbType.DateTime, entryData.Fundacao),
                base.Parameters.Create("@Site", DbType.String, entryData.Site),
                base.Parameters.Create("@Pais", DbType.String, entryData.Pais),
                base.Parameters.Create("@Estado", DbType.String, entryData.Estado),
                base.Parameters.Create("@Cidade", DbType.String, entryData.Cidade),
                base.Parameters.Create("@Descricao", DbType.String, entryData.Descricao),
                base.Parameters.Create("@NomeMascote", DbType.String, entryData.NomeMascote),
                base.Parameters.Create("@Mascote", DbType.AnsiString, entryData.Mascote),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            
            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) == 1 ? true : false;
        }
        public bool Update(string currentUser, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.DadosBasicos.Time entryData = (Model.DadosBasicos.Time)entry;

            base.ExecuteNonQuery(CommandType.StoredProcedure, base._commandUpdate, true, currentUser,
                base.Parameters.Create("@Nome", DbType.String, entryData.Nome),
                base.Parameters.Create("@IsClube", DbType.Boolean, entryData.IsClube),
                base.Parameters.Create("@Escudo", DbType.AnsiString, entryData.Escudo),
                base.Parameters.Create("@DataFundacao", DbType.DateTime, entryData.Fundacao),
                base.Parameters.Create("@Site", DbType.String, entryData.Site),
                base.Parameters.Create("@Pais", DbType.String, entryData.Pais),
                base.Parameters.Create("@Estado", DbType.String, entryData.Estado),
                base.Parameters.Create("@Cidade", DbType.String, entryData.Cidade),
                base.Parameters.Create("@Descricao", DbType.String, entryData.Descricao),
                base.Parameters.Create("@NomeMascote", DbType.String, entryData.NomeMascote),
                base.Parameters.Create("@Mascote", DbType.AnsiString, entryData.Mascote),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );


            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) >= 1 ? true : false;
        }
        public bool Delete(string currentUser, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.DadosBasicos.Time entryData = (Model.DadosBasicos.Time)entry;

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

            return Util.Time.ConvertToList(table);

        }
        public IList<Framework.DataServices.Model.EntityBaseData> SelectPage(string currentUser, string condition, string order, int pageNumber, int pageSize, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            return Util.Time.ConvertToList(
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

            return Util.Time.ConvertToList(table);
        }


        #endregion
    }
}
