using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BolaoNet.Dao.Campeonatos.Util
{
    public sealed class TimeRodadas
    {
        #region Methods
        public static IList<Model.Campeonatos.Reports.TimeRodadas> ConvertToTimesRodadasList(DataTable table)
        {
            IList<Model.Campeonatos.Reports.TimeRodadas> list = new List<Model.Campeonatos.Reports.TimeRodadas>();

            foreach (DataRow row in table.Rows)
            {
                Model.Campeonatos.Reports.TimeRodadas entry = ConvertToTimesRodadasObject(row);

                list.Add(entry);
            }

            return list;
        }
        public static Model.Campeonatos.Reports.TimeRodadas ConvertToTimesRodadasObject(DataRow row)
        {


            Model.Campeonatos.Reports.TimeRodadas entry = new Model.Campeonatos.Reports.TimeRodadas();
            //entry.LoadDataRow(row);


            if (row.Table.Columns.Contains("Rodada") && !Convert.IsDBNull(row["Rodada"]))
            {
                entry.Rodada = Convert.ToInt32(row["Rodada"]);
            }
            if (row.Table.Columns.Contains("Posicao") && !Convert.IsDBNull(row["Posicao"]))
            {
                entry.Posicao = Convert.ToInt32(row["Posicao"]);
            }

            return entry;

        }
        #endregion
    }
}
