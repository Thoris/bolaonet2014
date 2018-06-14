using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BolaoNet.Dao.Boloes.Util
{
    public sealed class UserPontosData
    {
        public static IList<Model.Boloes.Reports.UserPontosData> ConvertUserPontosToList(DataTable table)
        {
            IList<Model.Boloes.Reports.UserPontosData> list = new List<Model.Boloes.Reports.UserPontosData>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(ConvertUserPontosToObject(row));
            }

            return list;
        }
        public static Model.Boloes.Reports.UserPontosData ConvertUserPontosToObject(DataRow row)
        {
            Model.Boloes.Reports.UserPontosData entry =
                new BolaoNet.Model.Boloes.Reports.UserPontosData (Dao.Boloes.Util.BolaoMembros.ConvertUserPontosToObject(row));

            if (row.Table.Columns.Contains("DataJogo") && !Convert.IsDBNull(row["DataJogo"]))
            {
                entry.Date = Convert.ToDateTime(row["DataJogo"]);
            }

            return entry;
            
        }
    }
}
