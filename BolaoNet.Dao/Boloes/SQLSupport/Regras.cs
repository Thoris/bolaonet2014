using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BolaoNet.Dao.Boloes.SQLSupport
{
    public class Regras : Framework.DataServices.ItemPaging, IDaoBolaoRegras
    {
  

        #region Constructors/Destructors
        public Regras()
            : base (Util.BolaoRegras.TableName)
        {
        }

        public Regras(string connectionName)
            : base(connectionName, Util.BolaoRegras.TableName)
        {
        }

        public Regras(string connectionName, string connectionString, string providerName)
            : base(connectionName, connectionString, providerName, Util.BolaoRegras.TableName)
        {
        }    
        
        #endregion

        #region IDaoBase Members
        public Framework.DataServices.Model.EntityBaseData Load(string currentUser, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.Boloes.Regra entryData = (Model.Boloes.Regra)entry;


            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, base._commandSelect, true, currentUser,
                base.Parameters.Create("@RegraID", DbType.Int64, entryData.RegraID),
                base.Parameters.Create("@NomeBolao", DbType.String, entryData.Bolao.Nome),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            int rowsFound = Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value);

            if (rowsFound == 0)
                return null;
            //throw new Exception("There is no item found in database with this ID.");

            errorNumber = base.ExecutionStatus.ErrorNumber;
            errorDescription = base.ExecutionStatus.ErrorDescription;



            return Util.BolaoRegras.ConvertToObject(table.Rows[0]);
        }
        public bool Insert(string currentUser, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.Boloes.Regra entryData = (Model.Boloes.Regra)entry;

            base.ExecuteNonQuery(CommandType.StoredProcedure, base._commandInsert, true, currentUser,
                //base.Parameters.Create("@MessageID", DbType.Int64, entryData.MessageID),
                base.Parameters.Create("@NomeBolao", DbType.String, entryData.Bolao.Nome),
                base.Parameters.Create("@Description", DbType.String, entryData.Description),
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

            Model.Boloes.Regra entryData = (Model.Boloes.Regra)entry;

            base.ExecuteNonQuery(CommandType.StoredProcedure, base._commandInsert, true, currentUser,
                base.Parameters.Create("@RegraID", DbType.Int64, entryData.RegraID),
                base.Parameters.Create("@NomeBolao", DbType.String, entryData.Bolao.Nome),
                base.Parameters.Create("@Description", DbType.String, entryData.Description),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );


            errorNumber = base.ExecutionStatus.ErrorNumber;
            errorDescription = base.ExecutionStatus.ErrorDescription;


            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) >= 1 ? true : false;
        }
        public bool Delete(string currentUser, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.Boloes.Regra entryData = (Model.Boloes.Regra)entry;

            base.ExecuteNonQuery(CommandType.StoredProcedure, base._commandDelete, true, currentUser,
                base.Parameters.Create("@RegraID", DbType.Int64, entryData.RegraID),
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

            return Util.BolaoRegras.ConvertToList(table);
        }
        public IList<Framework.DataServices.Model.EntityBaseData> SelectPage(string currentUser, string condition, string order, int pageNumber, int pageSize, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            return Util.BolaoRegras.ConvertToList(
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

            return Util.BolaoRegras.ConvertToList(table);
        }
        
        #endregion

        #region IDaoBolaoRegras Members

        public IList<Framework.DataServices.Model.EntityBaseData> SelectAllFromBolao(string currentUser, Model.Boloes.Bolao bolao, string condition, out int errorNumber, out string errorDescription)
        {
            string conditionCurrent = condition;

            if (!string.IsNullOrEmpty(conditionCurrent))
                conditionCurrent += " AND ";
            else
                conditionCurrent = "";

            conditionCurrent += " BoloesRegras.NomeBolao = '" + bolao.Nome + "'";

            return SelectAll(currentUser, conditionCurrent, out errorNumber, out errorDescription);

        }

        #endregion
    }
}
