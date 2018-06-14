using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BolaoNet.Dao.Users.Util
{
    public sealed class UserPagamentos
    {
        #region Methods
        public static IList<Model.Users.UserPagamentos> ConvertUserPagamentosToList(DataTable table)
        {
            IList<Model.Users.UserPagamentos> list = new List<Model.Users.UserPagamentos>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(ConvertUserPagamentosToObject(row));
            }

            return list;
        }
        public static Model.Users.UserPagamentos ConvertUserPagamentosToObject(DataRow row)
        {

            Model.Users.UserPagamentos entry = new Model.Users.UserPagamentos();

            if (row.Table.Columns.Contains("NomeBolao") && !Convert.IsDBNull(row["NomeBolao"]))
            {
                entry.Bolao = new Model.Boloes.Bolao(Convert.ToString(row["NomeBolao"]));
            }

            if (row.Table.Columns.Contains("Valor") && !Convert.IsDBNull(row["Valor"]))
            {
                entry.Valor = Convert.ToDecimal(row["Valor"]);
            }

            if (row.Table.Columns.Contains("TaxaParticipacao") && !Convert.IsDBNull(row["TaxaParticipacao"]))
            {
                entry.Total = Convert.ToDecimal(row["TaxaParticipacao"]);
            }

            if (row.Table.Columns.Contains("DataInicio") && !Convert.IsDBNull(row["DataInicio"]))
            {
                entry.DataInicio = Convert.ToDateTime(row["DataInicio"]);
            }

            entry.LoadDataRow(row);

            return entry;

        }
        #endregion
    }
}
