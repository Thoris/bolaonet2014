using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BolaoNet.Dao.Boloes.SQLSupport
{
    public class ApostaExtra : Framework.DataServices.ItemPaging, IDaoApostaExtra
    {
        
        #region Constructors/Destructors
        public ApostaExtra()
            : base (Util.ApostaExtra.TableName)
        {
        }

        public ApostaExtra(string connectionName)
            : base(connectionName, Util.ApostaExtra.TableName)
        {
        }

        public ApostaExtra(string connectionName, string connectionString, string providerName)
            : base(connectionName, connectionString, providerName, Util.ApostaExtra.TableName)
        {
        }    
        
        #endregion

        #region IDaoBase Members
        public Framework.DataServices.Model.EntityBaseData Load(string currentUser, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.Boloes.ApostaExtra entryData = (Model.Boloes.ApostaExtra)entry;


            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, base._commandSelect, true, currentUser,
                base.Parameters.Create("@Posicao", DbType.Int64, entryData.Posicao),
                base.Parameters.Create("@NomeBolao", DbType.String, entryData.Bolao.Nome),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            int rowsFound = Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value);

            if (rowsFound == 0)
                return null;
            //throw new Exception("There is no item found in database with this ID.");

            errorNumber = base.ExecutionStatus.ErrorNumber;
            errorDescription = base.ExecutionStatus.ErrorDescription;



            return Util.ApostaExtra.ConvertToObject(table.Rows[0]);
        }
        public bool Insert(string currentUser, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.Boloes.ApostaExtra entryData = (Model.Boloes.ApostaExtra)entry;

            base.ExecuteNonQuery(CommandType.StoredProcedure, base._commandInsert, true, currentUser,
                base.Parameters.Create("@Posicao", DbType.Int64, entryData.Posicao),
                base.Parameters.Create("@NomeBolao", DbType.String, entryData.Bolao.Nome),
                base.Parameters.Create("@Titulo", DbType.String, entryData.Titulo),
                base.Parameters.Create("@Descricao", DbType.String, entryData.Descricao),
                base.Parameters.Create("@TotalPontos", DbType.Int32, entryData.TotalPontos),
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

            Model.Boloes.ApostaExtra entryData = (Model.Boloes.ApostaExtra)entry;

            base.ExecuteNonQuery(CommandType.StoredProcedure, base._commandInsert, true, currentUser,
                base.Parameters.Create("@Posicao", DbType.Int64, entryData.Posicao),
                base.Parameters.Create("@NomeBolao", DbType.String, entryData.Bolao.Nome),
                base.Parameters.Create("@Titulo", DbType.String, entryData.Titulo),
                base.Parameters.Create("@Descricao", DbType.String, entryData.Descricao),
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

            Model.Boloes.ApostaExtra entryData = (Model.Boloes.ApostaExtra)entry;

            base.ExecuteNonQuery(CommandType.StoredProcedure, base._commandDelete, true, currentUser,
                base.Parameters.Create("@Posicao", DbType.Int64, entryData.Posicao),
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

            return Util.ApostaExtra.ConvertToList(table);
        }
        public IList<Framework.DataServices.Model.EntityBaseData> SelectPage(string currentUser, string condition, string order, int pageNumber, int pageSize, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            return Util.ApostaExtra.ConvertToList(
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

            return Util.ApostaExtra.ConvertToList(table);
        }
        
        #endregion

        #region IDaoApostaExtra Members

        public bool InsertResult(string currentUser, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.Boloes.ApostaExtra entryData = (Model.Boloes.ApostaExtra)entry;

            base.ExecuteNonQuery(CommandType.StoredProcedure, "sp_ApostasExtras_InsertResult", true, currentUser,
                base.Parameters.Create("@Posicao", DbType.Int64, entryData.Posicao),
                base.Parameters.Create("@NomeBolao", DbType.String, entryData.Bolao.Nome),
                base.Parameters.Create("@NomeTime", DbType.String, entryData.NomeTimeValidado),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            errorNumber = base.ExecutionStatus.ErrorNumber;
            errorDescription = base.ExecutionStatus.ErrorDescription;

            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) >= 1 ? true : false;
 
        }

        #endregion
    }
}
