using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BolaoNet.Dao.Boloes.SQLSupport
{
    public class Mensagem : Framework.DataServices.ItemPaging, IDaoMensagens
    {
        
      
        #region Constructors/Destructors
        public Mensagem()
            : base (Util.Mensagem.TableName)
        {
        }

        public Mensagem(string connectionName)
            : base(connectionName, Util.Mensagem.TableName)
        {
        }

        public Mensagem(string connectionName, string connectionString, string providerName)
            : base(connectionName, connectionString, providerName, Util.Mensagem.TableName)
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
        //    string nomeBolao = "";
        //    string fromUser = "";
        //    long  messageID = 0;



        //    if (row.Table.Columns.Contains("MessageID") && !Convert.IsDBNull(row["MessageID"]))
        //    {
        //        messageID = Convert.ToInt64(row["MessageID"]);
        //    }
        //    if (row.Table.Columns.Contains("NomeBolao") && !Convert.IsDBNull(row["NomeBolao"]))
        //    {
        //        nomeBolao = Convert.ToString(row["NomeBolao"]);
        //    }

        //    if (row.Table.Columns.Contains("FromUser") && !Convert.IsDBNull(row["FromUser"]))
        //    {
        //        fromUser = Convert.ToString(row["FromUser"]);
        //    }

        //    Model.Boloes.Mensagem entry = new BolaoNet.Model.Boloes.Mensagem (messageID, fromUser, nomeBolao);
        //    entry.LoadDataRow(row);


        //    if (row.Table.Columns.Contains("CreationDate") && !Convert.IsDBNull(row["CreationDate"]))
        //    {
        //        entry.CreationDate = Convert.ToDateTime(row["CreationDate"]);
        //    }

        //    if (row.Table.Columns.Contains("Private") && !Convert.IsDBNull(row["Private"]))
        //    {
        //        entry.Private = Convert.ToBoolean(row["Private"]);
        //    }
        //    if (row.Table.Columns.Contains("ToUser") && !Convert.IsDBNull(row["ToUser"]))
        //    {
        //        entry.ToUser = Convert.ToString(row["ToUser"]);
        //    }
        //    if (row.Table.Columns.Contains("Title") && !Convert.IsDBNull(row["Title"]))
        //    {
        //        entry.Title = Convert.ToString(row["Title"]);
        //    }
        //    if (row.Table.Columns.Contains("Message") && !Convert.IsDBNull(row["Message"]))
        //    {
        //        entry.Message = Convert.ToString(row["Message"]);
        //    }
        //    if (row.Table.Columns.Contains("TotalRead") && !Convert.IsDBNull(row["TotalRead"]))
        //    {
        //        entry.TotalRead = Convert.ToInt32(row["TotalRead"]);
        //    }
        //    if (row.Table.Columns.Contains("AnsweredMessageID") && !Convert.IsDBNull(row["AnsweredMessageID"]))
        //    {
        //        entry.AnsweredMessageID = Convert.ToInt64(row["AnsweredMessageID"]);
        //    }
        //    if (row.Table.Columns.Contains("FromFullName") && !Convert.IsDBNull(row["FromFullName"]))
        //    {
        //        entry.FromFullName = Convert.ToString(row["FromFullName"]);
        //    }


        //    return entry;

        //}
        //#endregion



        #region IDaoBase Members
        public Framework.DataServices.Model.EntityBaseData Load(string currentUser, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.Boloes.Mensagem entryData = (Model.Boloes.Mensagem)entry;


            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, base._commandSelect, true, currentUser,
                base.Parameters.Create("@MessageID", DbType.Int64, entryData.MessageID),
                base.Parameters.Create("@NomeBolao", DbType.String, entryData.Bolao.Nome),
                base.Parameters.Create("@FromUser", DbType.String, entryData.FromUser),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            int rowsFound = Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value);

            if (rowsFound == 0)
                return null;
            //throw new Exception("There is no item found in database with this ID.");

            errorNumber = base.ExecutionStatus.ErrorNumber;
            errorDescription = base.ExecutionStatus.ErrorDescription;



            return Util.Mensagem.ConvertToObject(table.Rows[0]);
        }
        public bool Insert(string currentUser, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.Boloes.Mensagem entryData = (Model.Boloes.Mensagem)entry;

            base.ExecuteNonQuery(CommandType.StoredProcedure, base._commandInsert, true, currentUser,
                //base.Parameters.Create("@MessageID", DbType.Int64, entryData.MessageID),
                base.Parameters.Create("@NomeBolao", DbType.String, entryData.Bolao.Nome),
                base.Parameters.Create("@FromUser", DbType.String, entryData.FromUser),
                base.Parameters.Create("@CreationDate", DbType.DateTime, entryData.CreationDate),
                base.Parameters.Create("@Private", DbType.Boolean, entryData.Private),
                base.Parameters.Create("@ToUser", DbType.String, entryData.ToUser),
                base.Parameters.Create("@Title", DbType.String, entryData.Title),
                base.Parameters.Create("@Message", DbType.String, entryData.Message),
                base.Parameters.Create("@Totalread", DbType.Int32, entryData.TotalRead),
                base.Parameters.Create("@AnsweredMessageID", DbType.Int64, entryData.AnsweredMessageID),
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

            Model.Boloes.Mensagem entryData = (Model.Boloes.Mensagem)entry;

            base.ExecuteNonQuery(CommandType.StoredProcedure, base._commandInsert, true, currentUser,
                base.Parameters.Create("@MessageID", DbType.Int64, entryData.MessageID),
                base.Parameters.Create("@NomeBolao", DbType.String, entryData.Bolao.Nome),
                base.Parameters.Create("@FromUser", DbType.String, entryData.FromUser),
                base.Parameters.Create("@CreationDate", DbType.DateTime, entryData.CreationDate),
                base.Parameters.Create("@Private", DbType.Boolean, entryData.Private),
                base.Parameters.Create("@ToUser", DbType.String, entryData.ToUser),
                base.Parameters.Create("@Title", DbType.String, entryData.Title),
                base.Parameters.Create("@Message", DbType.String, entryData.Message),
                base.Parameters.Create("@Totalread", DbType.Int32, entryData.TotalRead),
                base.Parameters.Create("@AnsweredMessageID", DbType.Int64, entryData.AnsweredMessageID),
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

            Model.Boloes.Mensagem entryData = (Model.Boloes.Mensagem)entry;

            base.ExecuteNonQuery(CommandType.StoredProcedure, base._commandDelete, true, currentUser,
                base.Parameters.Create("@MessageID", DbType.Int64, entryData.MessageID),
                base.Parameters.Create("@NomeBolao", DbType.String, entryData.Bolao.Nome),
                base.Parameters.Create("@ToUser", DbType.String, entryData.ToUser),
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

            return Util.Mensagem.ConvertToList(table);
        }
        public IList<Framework.DataServices.Model.EntityBaseData> SelectPage(string currentUser, string condition, string order, int pageNumber, int pageSize, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            return Util.Mensagem.ConvertToList(
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

            return Util.Mensagem.ConvertToList(table);
        }
        
        #endregion

        #region IDaoMensagens Members

        public bool AddMessage(string currentUser, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            Model.Boloes.Mensagem entryData = (Model.Boloes.Mensagem)entry;

            base.ExecuteNonQuery(CommandType.StoredProcedure, "sp_Mensagens_AddMessage", true, currentUser,
                base.Parameters.Create("@NomeBolao", DbType.String, entryData.Bolao.Nome),
                base.Parameters.Create("@FromUser", DbType.String, entryData.FromUser),
                base.Parameters.Create("@Private", DbType.Boolean, entryData.Private),
                base.Parameters.Create("@ToUser", DbType.String, entryData.ToUser),
                base.Parameters.Create("@Title", DbType.String, entryData.Title),
                base.Parameters.Create("@Message", DbType.String, entryData.Message),
                base.Parameters.Create("@AnsweredMessageID", DbType.Int64, entryData.AnsweredMessageID),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );


            errorNumber = base.ExecutionStatus.ErrorNumber;
            errorDescription = base.ExecutionStatus.ErrorDescription;


            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) >= 1 ? true : false;
        }

        public IList<Framework.DataServices.Model.EntityBaseData> LoadMessagesUser(string currentUser, Framework.Security.Model.UserData user, Model.Boloes.Bolao bolao, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, "sp_Mensagens_User", true, currentUser,
                base.Parameters.Create("@NomeBolao", DbType.String, bolao.Nome),
                base.Parameters.Create("@UserName", DbType.String, user.UserName),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );

            return Util.Mensagem.ConvertToList(table);
        }

        #endregion
    }
}
