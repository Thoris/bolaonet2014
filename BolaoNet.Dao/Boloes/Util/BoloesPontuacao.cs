using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BolaoNet.Dao.Boloes.Util
{
    public sealed class BoloesPontuacao
    {
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
            string nome = "";

            if (row.Table.Columns.Contains("NomeBolao") && !Convert.IsDBNull(row["NomeBolao"]))
            {
                nome = Convert.ToString(row["NomeBolao"]);
            }

            Model.Boloes.BoloesPontuacao entry = new BolaoNet.Model.Boloes.BoloesPontuacao();
            entry.LoadDataRow(row);


            if (row.Table.Columns.Contains("Pontos") && !Convert.IsDBNull(row["Pontos"]))
            {
                entry.Posicao = Convert.ToInt32(row["Pontos"]);
            }
            if (row.Table.Columns.Contains("Titulo") && !Convert.IsDBNull(row["Titulo"]))
            {
                entry.Titulo = Convert.ToString(row["Titulo"]);
            }
            if (row.Table.Columns.Contains("BackColor") && !Convert.IsDBNull(row["BackColor"]))
            {
                entry.BackColor = System.Drawing.Color.FromName(Convert.ToString(row["BackColor"]));
            }
            if (row.Table.Columns.Contains("ForeColor") && !Convert.IsDBNull(row["ForeColor"]))
            {
                entry.ForeColor = System.Drawing.Color.FromName(Convert.ToString(row["ForeColor"]));
            }

            return entry;

        }
        #endregion
    }
}
