using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BolaoNet.Dao.DadosBasicos.SQLSupport
{
    public class Estadio: Framework.DataServices.ItemPaging , IDaoBase
    {
        //#region Constants
        //public new const string TableName = "Estadios";
        //#endregion

        #region Constructors/Destructors
        public Estadio()
            : base (Util.Estadio.TableName)
        {
        }

        public Estadio(string connectionName)
            : base(connectionName, Util.Estadio.TableName)
        {
        }

        public Estadio(string connectionName, string connectionString, string providerName)
            : base(connectionName, connectionString, providerName, Util.Estadio.TableName)
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

        //    Model.DadosBasicos.Estadio entry = new BolaoNet.Model.DadosBasicos.Estadio(nome);
        //    entry.LoadDataRow(row);

        //    if (row.Table.Columns.Contains("NomeTime") && !Convert.IsDBNull(row["NomeTime"]))
        //    {
        //        entry.Time = new BolaoNet.Model.DadosBasicos.Time(Convert.ToString(row["NomeTime"]));
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
        //    //if (row.Table.Columns.Contains("Foto") && !Convert.IsDBNull(row["Foto"]))
        //    //{
        //    //    entry.Foto = Convert.ToString(row["Foto"]);
        //    //}
        //    if (row.Table.Columns.Contains("Capacidade") && !Convert.IsDBNull(row["Capacidade"]))
        //    {
        //        entry.Capacidade = Convert.ToInt64(row["Capacidade"]);
        //    }
        //    if (row.Table.Columns.Contains("Descricao") && !Convert.IsDBNull(row["Descricao"]))
        //    {
        //        entry.Descricao = Convert.ToString(row["Descricao"]);
        //    }



        //    return entry;

        //}


        //#endregion

        #region IDaoBase Members

        public Framework.DataServices.Model.EntityBaseData Load(string currentUser, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.DadosBasicos.Estadio entryData = (Model.DadosBasicos.Estadio)entry;


            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, base._commandSelect, true, currentUser,
                base.Parameters.Create("@Nome", DbType.String, entryData.Nome), 
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null) 
                );

            int rowsFound = Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value);

            if (rowsFound == 0)
                return null;
                //throw new Exception("There is no item found in database with this ID.");


            return Util.Estadio.ConvertToObject(table.Rows[0]);
        }
        public bool Insert(string currentUser, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.DadosBasicos.Estadio entryData = (Model.DadosBasicos.Estadio)entry;

            base.ExecuteNonQuery(CommandType.StoredProcedure, base._commandInsert, true, currentUser,
                base.Parameters.Create("@Nome", DbType.String, entryData.Nome),
                base.Parameters.Create("@NomeTime", DbType.String, entryData.Time == null ? null : entryData.Time.Nome),
                base.Parameters.Create("@Pais", DbType.String, entryData.Pais),
                base.Parameters.Create("@Estado", DbType.String, entryData.Estado),
                base.Parameters.Create("@Cidade", DbType.String, entryData.Cidade),
                base.Parameters.Create("@Foto", DbType.AnsiString, entryData.Foto),
                base.Parameters.Create("@Capacidade", DbType.Int64, entryData.Capacidade),
                base.Parameters.Create("@Descricao", DbType.String, entryData.Descricao),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            
            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) == 1 ? true : false;
        }
        public bool Update(string currentUser, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.DadosBasicos.Estadio entryData = (Model.DadosBasicos.Estadio)entry;

            base.ExecuteNonQuery(CommandType.StoredProcedure, base._commandUpdate, true, currentUser,
                 base.Parameters.Create("@Nome", DbType.String, entryData.Nome),
                base.Parameters.Create("@NomeTime", DbType.String, entryData.Time == null ? null : entryData.Time.Nome),
                base.Parameters.Create("@Pais", DbType.String, entryData.Pais),
                base.Parameters.Create("@Estado", DbType.String, entryData.Estado),
                base.Parameters.Create("@Cidade", DbType.String, entryData.Cidade),
                base.Parameters.Create("@Foto", DbType.AnsiString, entryData.Foto),
                base.Parameters.Create("@Capacidade", DbType.Int64, entryData.Capacidade),
                base.Parameters.Create("@Descricao", DbType.String, entryData.Descricao),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );


            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) >= 1 ? true : false;
        }
        public bool Delete(string currentUser, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.DadosBasicos.Estadio entryData = (Model.DadosBasicos.Estadio)entry;

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

            return Util.Estadio.ConvertToList(table);

        }
        public IList<Framework.DataServices.Model.EntityBaseData> SelectPage(string currentUser, string condition, string order, int pageNumber, int pageSize, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            return Util.Estadio.ConvertToList(
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

            return Util.Estadio.ConvertToList(table);
        }


        #endregion
    }
}
