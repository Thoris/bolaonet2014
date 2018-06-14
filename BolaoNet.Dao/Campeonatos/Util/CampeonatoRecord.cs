using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BolaoNet.Dao.Campeonatos.Util
{
    public sealed class CampeonatoRecord
    {
        #region Methods
        public static IList<Model.Campeonatos.CampeonatoRecord> ConvertToRecordList(DataTable table)
        {
            IList<Model.Campeonatos.CampeonatoRecord> list = new List<Model.Campeonatos.CampeonatoRecord>();

            foreach (DataRow row in table.Rows)
            {
                Model.Campeonatos.CampeonatoRecord entry = ConvertToRecordObject(row);

                entry.Posicao = list.Count + 1;
                list.Add(entry);
            }

            return list;
        }
        public static Model.Campeonatos.CampeonatoRecord ConvertToRecordObject(DataRow row)
        {
            string nomeTime = "";

            if (row.Table.Columns.Contains("NomeTime") && !Convert.IsDBNull(row["NomeTime"]))
            {
                nomeTime = Convert.ToString(row["NomeTime"]);
            }

            Model.Campeonatos.CampeonatoRecord entry = new BolaoNet.Model.Campeonatos.CampeonatoRecord(nomeTime);
            entry.LoadDataRow(row);


            if (row.Table.Columns.Contains("Vitoria") && !Convert.IsDBNull(row["Vitoria"]))
            {
                entry.Vitorias = Convert.ToInt32(row["Vitoria"]);
            }
            if (row.Table.Columns.Contains("Derrota") && !Convert.IsDBNull(row["Derrota"]))
            {
                entry.Derrotas = Convert.ToInt32(row["Derrota"]);
            }
            if (row.Table.Columns.Contains("Empate") && !Convert.IsDBNull(row["Empate"]))
            {
                entry.Empates = Convert.ToInt32(row["Empate"]);
            }

            return entry;

        }

        #endregion
    }
}
