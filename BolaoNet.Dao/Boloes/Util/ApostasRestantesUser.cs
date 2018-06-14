using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;

namespace BolaoNet.Dao.Boloes.Util
{
    public sealed class ApostasRestantesUser
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

            string userName = null;

            if (row.Table.Columns.Contains("UserName") && !Convert.IsDBNull(row["UserName"]))
            {
                userName = Convert.ToString(row["UserName"]);
            }


            Model.Boloes.ApostasRestantesUser entry = new BolaoNet.Model.Boloes.ApostasRestantesUser(userName);
            
            Framework.Security.Model.UserData user = Framework.Security.DataAccess.Convertion.UserData.ConvertToModel(row);
            entry.Copy((Framework.Security.Model.UserData)user);


            if (row.Table.Columns.Contains("Restantes") && !Convert.IsDBNull(row["Restantes"]))
            {
                entry.ApostasRestantes = Convert.ToInt32(row["Restantes"]);
            }

            if (row.Table.Columns.Contains("Pago") && !Convert.IsDBNull(row["Pago"]))
            {
                entry.PagamentoRestante = Convert.ToDecimal(row["Pago"]);
            }



            return entry;

        }
        #endregion
    }
}
