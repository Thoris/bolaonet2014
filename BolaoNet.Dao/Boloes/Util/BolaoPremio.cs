using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BolaoNet.Dao.Boloes.Util
{
    public class BolaoPremio
    {
        #region Methods
        public static IList<Framework.DataServices.Model.EntityBaseData> ConvertToPremioList(DataTable table)
        {
            IList<Framework.DataServices.Model.EntityBaseData> list = new List<Framework.DataServices.Model.EntityBaseData>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(ConvertToPremioObject(row));
            }

            return list;
        }
        public static Framework.DataServices.Model.EntityBaseData ConvertToPremioObject(DataRow row)
        {
            string nomeBolao = "";
            int posicao = 0;

            if (row.Table.Columns.Contains("NomeBolao") && !Convert.IsDBNull(row["NomeBolao"]))
            {
                nomeBolao = Convert.ToString(row["NomeBolao"]);
            }
            if (row.Table.Columns.Contains("Posicao") && !Convert.IsDBNull(row["Posicao"]))
            {
                posicao = Convert.ToInt32(row["Posicao"]);
            }

            Model.Boloes.BolaoPremio entry = new BolaoNet.Model.Boloes.BolaoPremio(nomeBolao, posicao);
            entry.LoadDataRow(row);


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
