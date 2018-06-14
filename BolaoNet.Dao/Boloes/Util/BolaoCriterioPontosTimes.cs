using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BolaoNet.Dao.Boloes.Util
{
    public sealed class BolaoCriterioPontosTimes
    {
        #region Methods
        public static IList<Framework.DataServices.Model.EntityBaseData> ConvertToCriteriosPontosTimesList(DataTable table)
        {
            IList<Framework.DataServices.Model.EntityBaseData> list = new List<Framework.DataServices.Model.EntityBaseData>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(ConvertToCriteriosPontosTimesObject(row));
            }

            return list;
        }
        public static Framework.DataServices.Model.EntityBaseData ConvertToCriteriosPontosTimesObject(DataRow row)
        {
            string nomeBolao = "";
            string nomeTime = "";

            if (row.Table.Columns.Contains("NomeBolao") && !Convert.IsDBNull(row["NomeBolao"]))
            {
                nomeBolao = Convert.ToString(row["NomeBolao"]);
            }
            if (row.Table.Columns.Contains("NomeTime") && !Convert.IsDBNull(row["NomeTime"]))
            {
                nomeTime = Convert.ToString(row["NomeTime"]);
            }

            Model.Boloes.BolaoCriterioPontosTimes entry =
                new BolaoNet.Model.Boloes.BolaoCriterioPontosTimes(nomeBolao, nomeTime);
            entry.LoadDataRow(row);


            if (row.Table.Columns.Contains("Multiplo") && !Convert.IsDBNull(row["Multiplo"]))
            {
                entry.MultiploTime = Convert.ToInt32(row["Multiplo"]);
            }

            return entry;

        }

        #endregion
    }
}
