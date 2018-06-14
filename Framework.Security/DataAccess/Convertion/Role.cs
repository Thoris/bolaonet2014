using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Framework.Security.DataAccess.Convertion
{
    public sealed class Role
    {
        #region Methods
        public static List<Model.Role> ConvertToList(DataTable table)
        {
            List<Model.Role> list = new List<Model.Role>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(ConvertToObject(row));
            }

            return list;
        }
        public static Model.Role ConvertToObject(DataRow row)
        {
            string nome = "";

            if (row.Table.Columns.Contains("RoleName") && !Convert.IsDBNull(row["RoleName"]))
            {
                nome = Convert.ToString(row["RoleName"]);
            }

            Model.Role entry = new Model.Role(nome);
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
