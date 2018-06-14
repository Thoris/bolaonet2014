using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BolaoNet.Dao.Boloes.Util
{
    public sealed class BolaoRequest
    {
        #region Methods
        public static IList<Framework.DataServices.Model.EntityBaseData> ConvertToRequestList(DataTable table)
        {
            IList<Framework.DataServices.Model.EntityBaseData> list = new List<Framework.DataServices.Model.EntityBaseData>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(ConvertToRequestObject(row));
            }

            return list;
        }
        public static Framework.DataServices.Model.EntityBaseData ConvertToRequestObject(DataRow row)
        {
            string nomeBolao = "";
            int requestID = 0;

            if (row.Table.Columns.Contains("NomeBolao") && !Convert.IsDBNull(row["NomeBolao"]))
            {
                nomeBolao = Convert.ToString(row["NomeBolao"]);
            }
            if (row.Table.Columns.Contains("RequestID") && !Convert.IsDBNull(row["RequestID"]))
            {
                requestID = Convert.ToInt32(row["RequestID"]);
            }

            Model.Boloes.BolaoRequest entry = new BolaoNet.Model.Boloes.BolaoRequest(requestID, nomeBolao);
            entry.LoadDataRow(row);


            if (row.Table.Columns.Contains("RequestedBy") && !Convert.IsDBNull(row["RequestedBy"]))
            {
                entry.RequestedBy = Convert.ToString(row["RequestedBy"]);
            }
            if (row.Table.Columns.Contains("RequestedDate") && !Convert.IsDBNull(row["RequestedDate"]))
            {
                entry.RequestedDate = Convert.ToDateTime(Convert.ToString(row["RequestedDate"]));
            }
            if (row.Table.Columns.Contains("Owner") && !Convert.IsDBNull(row["Owner"]))
            {
                entry.Owner = Convert.ToString(Convert.ToString(row["Owner"]));
            }
            if (row.Table.Columns.Contains("StatusRequestID") && !Convert.IsDBNull(row["StatusRequestID"]))
            {
                entry.StatusRequestID = (Model.Boloes.BolaoRequest.Status)
                    Convert.ToInt32(Convert.ToString(row["StatusRequestID"]));
            }
            if (row.Table.Columns.Contains("AnsweredBy") && !Convert.IsDBNull(row["AnsweredBy"]))
            {
                entry.AnsweredBy = Convert.ToString(Convert.ToString(row["AnsweredBy"]));
            }
            if (row.Table.Columns.Contains("AnsweredDate") && !Convert.IsDBNull(row["AnsweredDate"]))
            {
                entry.AnsweredDate = Convert.ToDateTime(Convert.ToString(row["AnsweredDate"]));
            }
            if (row.Table.Columns.Contains("Descricao") && !Convert.IsDBNull(row["Descricao"]))
            {
                entry.Descricao = Convert.ToString(Convert.ToString(row["Descricao"]));
            }


            return entry;

        }
        #endregion
    }
}
