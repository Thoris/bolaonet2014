using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BolaoNet.Dao.Boloes.SQLSupport
{
    public class Pagamento : Framework.DataServices.ItemPaging, IDaoPagamento
    {
        #region Constants
        public new const string TableName = "Pagamentos";
        #endregion

        #region Constructors/Destructors
        public Pagamento()
            : base(TableName)
        {
        }

        public Pagamento(string connectionName)
            : base(connectionName, TableName)
        {
        }

        public Pagamento(string connectionName, string connectionString, string providerName)
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
        public static Framework.DataServices.Model.EntityBaseData ConvertToObject(DataRow row)
        {
            string userName = "";
            string nomeBolao = "";
            DateTime dataPagamento = DateTime.MinValue;


            if (row.Table.Columns.Contains("DataPagamento") && !Convert.IsDBNull(row["DataPagamento"]))
            {
                dataPagamento = Convert.ToDateTime(row["DataPagamento"]);
            }
            if (row.Table.Columns.Contains("UserName") && !Convert.IsDBNull(row["UserName"]))
            {
                userName = Convert.ToString(row["UserName"]);
            }
            if (row.Table.Columns.Contains("NomeBolao") && !Convert.IsDBNull(row["NomeBolao"]))
            {
                nomeBolao = Convert.ToString(row["NomeBolao"]);
            }
            if (row.Table.Columns.Contains("NomeBolao") && !Convert.IsDBNull(row["NomeBolao"]))
            {
                nomeBolao = Convert.ToString(row["NomeBolao"]);
            }

            Model.Boloes.Pagamento entry = new BolaoNet.Model.Boloes.Pagamento(nomeBolao, userName, dataPagamento);
            entry.LoadDataRow(row);

            if (row.Table.Columns.Contains("Valor") && !Convert.IsDBNull(row["Valor"]))
            {
                entry.Valor = Convert.ToDecimal(row["Valor"]);
            }
            if (row.Table.Columns.Contains("Descricao") && !Convert.IsDBNull(row["Descricao"]))
            {
                entry.Descricao = Convert.ToString(row["Descricao"]);
            }
            if (row.Table.Columns.Contains("TipoPagamento") && !Convert.IsDBNull(row["TipoPagamento"]))
            {
                entry.TipoPagamento = (Model.Boloes.Pagamento.Tipo)Convert.ToInt32(row["TipoPagamento"]);
            }

            return entry;

        }
        #endregion


        #region IDaoBase Members

        public Framework.DataServices.Model.EntityBaseData Load(string currentUser, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.Boloes.Pagamento entryData = (Model.Boloes.Pagamento)entry;


            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, base._commandSelect, true, currentUser,
                base.Parameters.Create("@DataPagamento", DbType.DateTime, entryData.DataPagamento),
                base.Parameters.Create("@UserName", DbType.String, entryData.UserName),
                base.Parameters.Create("@NomeBolao", DbType.String, entryData.Bolao.Nome),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            int rowsFound = Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value);

            if (rowsFound == 0)
                return null;
            //throw new Exception("There is no item found in database with this ID.");


            errorNumber = base.ExecutionStatus.ErrorNumber;
            errorDescription = base.ExecutionStatus.ErrorDescription;


            return ConvertToObject(table.Rows[0]);
        }
        public bool Insert(string currentUser, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.Boloes.Pagamento entryData = (Model.Boloes.Pagamento)entry;

            base.ExecuteNonQuery(CommandType.StoredProcedure, base._commandInsert, true, currentUser,
                base.Parameters.Create("@DataPagamento", DbType.DateTime, entryData.DataPagamento),
                base.Parameters.Create("@UserName", DbType.String, entryData.UserName),
                base.Parameters.Create("@NomeBolao", DbType.String, entryData.Bolao.Nome),
                base.Parameters.Create("@TipoPagamento", DbType.Int32, (int)entryData.TipoPagamento),
                base.Parameters.Create("@Valor", DbType.Decimal, entryData.Valor),
                base.Parameters.Create("@Descricao", DbType.String, entryData.Descricao),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            errorNumber = base.ExecutionStatus.ErrorNumber;
            errorDescription = base.ExecutionStatus.ErrorDescription;


            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) == 1 ? true : false;

        }
        public bool Update(string currentUser, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.Boloes.Pagamento entryData = (Model.Boloes.Pagamento)entry;

            base.ExecuteNonQuery(CommandType.StoredProcedure, base._commandUpdate, true, currentUser,
                base.Parameters.Create("@DataPagamento", DbType.DateTime, entryData.DataPagamento),
                base.Parameters.Create("@UserName", DbType.String, entryData.UserName),
                base.Parameters.Create("@NomeBolao", DbType.String, entryData.Bolao.Nome),
                base.Parameters.Create("@TipoPagamento", DbType.Int32, (int)entryData.TipoPagamento),
                base.Parameters.Create("@Valor", DbType.Decimal, entryData.Valor),
                base.Parameters.Create("@Descricao", DbType.String, entryData.Descricao),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            errorNumber = base.ExecutionStatus.ErrorNumber;
            errorDescription = base.ExecutionStatus.ErrorDescription;


            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) == 1 ? true : false;

        }
        public bool Delete(string currentUser, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.Boloes.Pagamento entryData = (Model.Boloes.Pagamento)entry;

            base.ExecuteNonQuery(CommandType.StoredProcedure, base._commandDelete, true, currentUser,
                base.Parameters.Create("@DataPagamento", DbType.DateTime, entryData.DataPagamento),
                base.Parameters.Create("@UserName", DbType.String, entryData.UserName),
                base.Parameters.Create("@NomeBolao", DbType.String, entryData.Bolao.Nome),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            errorNumber = base.ExecutionStatus.ErrorNumber;
            errorDescription = base.ExecutionStatus.ErrorDescription;


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

            errorNumber = base.ExecutionStatus.ErrorNumber;
            errorDescription = base.ExecutionStatus.ErrorDescription;

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



        public IList<Framework.DataServices.Model.EntityBaseData> SelectAllByBolao(string currentUser, BolaoNet.Model.Boloes.Bolao bolao, string condition, out int errorNumber, out string errorDescription)
        {
            string newCondition = condition;

            if (!string.IsNullOrEmpty(newCondition))
                newCondition += " AND NomeBolao = '" + bolao.Nome + "'";
            else
                newCondition = "NomeBolao = '" + bolao.Nome + "'";

            return SelectAll(currentUser, newCondition, out errorNumber, out errorDescription);
        }

        #endregion
    }
}
