using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BolaoNet.Dao.Boloes.SQLSupport
{
    public class ApostaExtraUsuario : Framework.DataServices.ItemPaging, IDaoApostaExtraUsuario
    {
        //#region Constants
        //public new const string TableName = "ApostasExtrasUsuarios";
        //#endregion

        #region Constructors/Destructors
        public ApostaExtraUsuario()
            : base (Util.ApostaExtraUsuario.TableName)
        {
        }

        public ApostaExtraUsuario(string connectionName)
            : base(connectionName, Util.ApostaExtraUsuario.TableName)
        {
        }

        public ApostaExtraUsuario(string connectionName, string connectionString, string providerName)
            : base(connectionName, connectionString, providerName, Util.ApostaExtraUsuario.TableName)
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
        //    int posicao = 0;
        //    string userName = "";
        //    string nomeBolao = "";


        //    if (row.Table.Columns.Contains("Posicao") && !Convert.IsDBNull(row["Posicao"]))
        //    {
        //        posicao = Convert.ToInt32(row["Posicao"]);
        //    }
        //    if (row.Table.Columns.Contains("UserName") && !Convert.IsDBNull(row["UserName"]))
        //    {
        //        userName = Convert.ToString(row["UserName"]);
        //    }
        //    if (row.Table.Columns.Contains("NomeBolao") && !Convert.IsDBNull(row["NomeBolao"]))
        //    {
        //        nomeBolao = Convert.ToString(row["NomeBolao"]);
        //    }

        //    Model.Boloes.ApostaExtraUsuario entry = new Model.Boloes.ApostaExtraUsuario(posicao,nomeBolao,userName);
        //    entry.LoadDataRow(row);

        //    if (row.Table.Columns.Contains("Titulo") && !Convert.IsDBNull(row["Titulo"]))
        //    {
        //        entry.Titulo = Convert.ToString(row["Titulo"]);                
        //    }
        //    if (row.Table.Columns.Contains("Descricao") && !Convert.IsDBNull(row["Descricao"]))
        //    {
        //        entry.Descricao = Convert.ToString(row["Descricao"]);
        //    }
        //    if (row.Table.Columns.Contains("TotalPontos") && !Convert.IsDBNull(row["TotalPontos"]))
        //    {
        //        entry.TotalPontos = Convert.ToInt32(row["TotalPontos"]);
        //    }
        //    if (row.Table.Columns.Contains("IsValido") && !Convert.IsDBNull(row["IsValido"]))
        //    {
        //        entry.IsValido = Convert.ToBoolean(row["IsValido"]);
        //    }
        //    if (row.Table.Columns.Contains("DataValidacao") && !Convert.IsDBNull(row["DataValidacao"]))
        //    {
        //        entry.DataValidacao = Convert.ToDateTime(row["DataValidacao"]);
        //    }
        //    if (row.Table.Columns.Contains("ValidadoBy") && !Convert.IsDBNull(row["ValidadoBy"]))
        //    {
        //        entry.ValidadoBy = Convert.ToString(row["ValidadoBy"]);
        //    }
        //    if (row.Table.Columns.Contains("NomeTimeValidado") && !Convert.IsDBNull(row["NomeTimeValidado"]))
        //    {
        //        entry.NomeTimeValidado = Convert.ToString(row["NomeTimeValidado"]);
        //    }
        //    if (row.Table.Columns.Contains("DataAposta") && !Convert.IsDBNull(row["DataAposta"]))
        //    {
        //        entry.DataAposta = Convert.ToDateTime(row["DataAposta"]);
        //    }
        //    if (row.Table.Columns.Contains("Pontos") && !Convert.IsDBNull(row["Pontos"]))
        //    {
        //        entry.Pontos = Convert.ToInt32(row["Pontos"]);
        //    }
        //    if (row.Table.Columns.Contains("NomeTime") && !Convert.IsDBNull(row["NomeTime"]))
        //    {
        //        entry.NomeTime = Convert.ToString(row["NomeTime"]);
        //    }
        //    if (row.Table.Columns.Contains("IsApostaValida") && !Convert.IsDBNull(row["IsApostaValida"]))
        //    {
        //        entry.IsApostaValida = Convert.ToBoolean(row["IsApostaValida"]);
        //    }
            


        //    return entry;

        //}
        //#endregion

        #region IDaoApostaExtraUsuario Members

        public IList<Framework.DataServices.Model.EntityBaseData> SelectByUser(string currentUser, Model.Boloes.Bolao bolao, string userName, string condition, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            string conditionUser = condition;

            if (string.IsNullOrEmpty(conditionUser))
            {
                conditionUser = " ApostasExtras.NomeBolao = '" + bolao.Nome + "'";
            }
            else
            {
                conditionUser = " AND ApostasExtras.NomeBolao = '" + bolao.Nome + "'";
            }


            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, base._commandSelectAll, true, currentUser,
                base.Parameters.Create("@UserName", DbType.String, userName),                
                base.Parameters.Create("@Condition", DbType.String, conditionUser),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            errorNumber = base.ExecutionStatus.ErrorNumber;
            errorDescription = base.ExecutionStatus.ErrorDescription;

            return Util.ApostaExtraUsuario.ConvertToList(table);
        }


        public IList<Framework.DataServices.Model.EntityBaseData> SelectByPosicao(string currentUser, BolaoNet.Model.Boloes.Bolao bolao, int posicao, string condition, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            string conditionUser = condition;

            if (string.IsNullOrEmpty(conditionUser))
            {
                conditionUser = " ApostasExtras.Posicao = " + posicao + " AND ApostasExtras.NomeBolao = '" + bolao.Nome + "'";
            }
            else
            {
                conditionUser = " AND ApostasExtras.Posicao = " + posicao + " AND ApostasExtras.NomeBolao = '" + bolao.Nome + "'";
            }


            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, base._commandSelectAll, true, currentUser,
                base.Parameters.Create("@UserName", DbType.String, null),
                base.Parameters.Create("@Condition", DbType.String, conditionUser),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            errorNumber = base.ExecutionStatus.ErrorNumber;
            errorDescription = base.ExecutionStatus.ErrorDescription;

            return Util.ApostaExtraUsuario.ConvertToList(table);
        }

        #endregion

        #region IDaoBase Members

        public Framework.DataServices.Model.EntityBaseData Load(string currentUser, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.Boloes.ApostaExtraUsuario entryData = (Model.Boloes.ApostaExtraUsuario)entry;


            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, base._commandSelect, true, currentUser,
                base.Parameters.Create("@Posicao", DbType.Int32, entryData.Posicao),
                base.Parameters.Create("@UserName", DbType.Int32, entryData.UserName),
                base.Parameters.Create("@NomeBolao", DbType.Int32, entryData.Bolao.Nome),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            int rowsFound = Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value);

            if (rowsFound == 0)
                return null;
            //throw new Exception("There is no item found in database with this ID.");


            errorNumber = base.ExecutionStatus.ErrorNumber;
            errorDescription = base.ExecutionStatus.ErrorDescription;


            return Util.ApostaExtraUsuario.ConvertToObject(table.Rows[0]);
        }
        public bool Insert(string currentUser, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.Boloes.ApostaExtraUsuario entryData = (Model.Boloes.ApostaExtraUsuario)entry;

            base.ExecuteNonQuery(CommandType.StoredProcedure, base._commandInsert, true, currentUser,
                base.Parameters.Create("@Posicao", DbType.Int32, entryData.Posicao),
                base.Parameters.Create("@UserName", DbType.String, entryData.UserName),
                base.Parameters.Create("@NomeBolao", DbType.String, entryData.Bolao.Nome),
                base.Parameters.Create("@NomeTime", DbType.String, entryData.NomeTime),
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

            return Insert(currentUser, entry, out errorNumber, out errorDescription);
        }
        public bool Delete(string currentUser, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.Boloes.ApostaExtraUsuario entryData = (Model.Boloes.ApostaExtraUsuario)entry;

            base.ExecuteNonQuery(CommandType.StoredProcedure, base._commandDelete, true, currentUser,
                base.Parameters.Create("@Posicao", DbType.Int32, entryData.Posicao),
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

            return Util.ApostaExtraUsuario.ConvertToList(table);
        }
        public IList<Framework.DataServices.Model.EntityBaseData> SelectPage(string currentUser, string condition, string order, int pageNumber, int pageSize, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            return Util.ApostaExtraUsuario.ConvertToList(
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

            return Util.ApostaExtraUsuario.ConvertToList(table);
        }

        #endregion

    }
}
