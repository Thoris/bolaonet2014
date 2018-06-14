using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BolaoNet.Dao.Boloes.Util
{
    public sealed class Mensagem
    {
        #region Constants
        public const string TableName = "Mensagens";
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
            string nomeBolao = "";
            string fromUser = "";
            long messageID = 0;



            if (row.Table.Columns.Contains("MessageID") && !Convert.IsDBNull(row["MessageID"]))
            {
                messageID = Convert.ToInt64(row["MessageID"]);
            }
            if (row.Table.Columns.Contains("NomeBolao") && !Convert.IsDBNull(row["NomeBolao"]))
            {
                nomeBolao = Convert.ToString(row["NomeBolao"]);
            }

            if (row.Table.Columns.Contains("FromUser") && !Convert.IsDBNull(row["FromUser"]))
            {
                fromUser = Convert.ToString(row["FromUser"]);
            }

            Model.Boloes.Mensagem entry = new BolaoNet.Model.Boloes.Mensagem(messageID, fromUser, nomeBolao);
            entry.LoadDataRow(row);


            if (row.Table.Columns.Contains("CreationDate") && !Convert.IsDBNull(row["CreationDate"]))
            {
                entry.CreationDate = Convert.ToDateTime(row["CreationDate"]);
            }

            if (row.Table.Columns.Contains("Private") && !Convert.IsDBNull(row["Private"]))
            {
                entry.Private = Convert.ToBoolean(row["Private"]);
            }
            if (row.Table.Columns.Contains("ToUser") && !Convert.IsDBNull(row["ToUser"]))
            {
                entry.ToUser = Convert.ToString(row["ToUser"]);
            }
            if (row.Table.Columns.Contains("Title") && !Convert.IsDBNull(row["Title"]))
            {
                entry.Title = Convert.ToString(row["Title"]);
            }
            if (row.Table.Columns.Contains("Message") && !Convert.IsDBNull(row["Message"]))
            {
                entry.Message = Convert.ToString(row["Message"]);
            }
            if (row.Table.Columns.Contains("TotalRead") && !Convert.IsDBNull(row["TotalRead"]))
            {
                entry.TotalRead = Convert.ToInt32(row["TotalRead"]);
            }
            if (row.Table.Columns.Contains("AnsweredMessageID") && !Convert.IsDBNull(row["AnsweredMessageID"]))
            {
                entry.AnsweredMessageID = Convert.ToInt64(row["AnsweredMessageID"]);
            }
            if (row.Table.Columns.Contains("FullName") && !Convert.IsDBNull(row["FullName"]))
            {
                entry.FromFullName = Convert.ToString(row["FullName"]);
            }


            return entry;

        }
        #endregion
    }
}
