using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BolaoNet.Dao.Boloes.Util
{
    public sealed class BolaoRegras
    {
        #region Constants
        public new const string TableName = "BoloesRegras";
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
            int regraID = 0;

            if (row.Table.Columns.Contains("NomeBolao") && !Convert.IsDBNull(row["NomeBolao"]))
            {
                nomeBolao = Convert.ToString(row["NomeBolao"]);
            }
            if (row.Table.Columns.Contains("RegraID") && !Convert.IsDBNull(row["RegraID"]))
            {
                regraID = Convert.ToInt32(row["RegraID"]);
            }

            Model.Boloes.Regra entry = new BolaoNet.Model.Boloes.Regra(regraID, nomeBolao);
            entry.LoadDataRow(row);


            if (row.Table.Columns.Contains("Description") && !Convert.IsDBNull(row["Description"]))
            {
                entry.Description = Convert.ToString(row["Description"]);
            }

            return entry;

        }
        #endregion
    }
}
