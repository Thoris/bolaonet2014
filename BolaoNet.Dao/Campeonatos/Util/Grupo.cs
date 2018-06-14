using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BolaoNet.Dao.Campeonatos.Util
{
    public sealed class Grupo
    {
        #region Constants
        public new const string TableName = "CampeonatosGrupos";
        public const string TableLinkToTimes = "CampeonatosGruposTimes";
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
            string nome = "";

            if (row.Table.Columns.Contains("Nome") && !Convert.IsDBNull(row["Nome"]))
            {
                nome = Convert.ToString(row["Nome"]);
            }

            Model.Campeonatos.Grupo entry = new Model.Campeonatos.Grupo(nome);
            entry.LoadDataRow(row);



            if (row.Table.Columns.Contains("Descricao") && !Convert.IsDBNull(row["Descricao"]))
            {
                entry.Descricao = Convert.ToString(row["Descricao"]);
            }



            return entry;

        }

        #endregion

    }
}
