using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BolaoNet.Dao.Campeonatos.Util
{
    public sealed class GolsFrequencia
    {
        #region Methods
        public static IList<Model.Campeonatos.Reports.GolsFrequencia> ConvertToGolsFrequenciaList(DataTable table)
        {
            IList<Model.Campeonatos.Reports.GolsFrequencia> list = new List<Model.Campeonatos.Reports.GolsFrequencia>();

            foreach (DataRow row in table.Rows)
            {
                Model.Campeonatos.Reports.GolsFrequencia entry = ConvertToGolsFrequenciaObject(row);

                list.Add(entry);
            }

            return list;
        }
        public static Model.Campeonatos.Reports.GolsFrequencia ConvertToGolsFrequenciaObject(DataRow row)
        {


            Model.Campeonatos.Reports.GolsFrequencia entry = new Model.Campeonatos.Reports.GolsFrequencia();
            entry.LoadDataRow(row);


            if (row.Table.Columns.Contains("Gols1") && !Convert.IsDBNull(row["Gols1"]))
            {
                entry.Gols1 = Convert.ToInt32(row["Gols1"]);
            }
            if (row.Table.Columns.Contains("Gols2") && !Convert.IsDBNull(row["Gols2"]))
            {
                entry.Gols2 = Convert.ToInt32(row["Gols2"]);
            }
            if (row.Table.Columns.Contains("Total") && !Convert.IsDBNull(row["Total"]))
            {
                entry.Total = Convert.ToInt32(row["Total"]);
            }


            return entry;

        }
        #endregion
    }
}
