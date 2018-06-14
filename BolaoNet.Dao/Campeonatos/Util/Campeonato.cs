using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BolaoNet.Dao.Campeonatos.Util
{
    public sealed class Campeonato
    {
        #region Constants
        public new const string TableName = "Campeonatos";
        public const string TableLinkToTimes = "CampeonatosTimes";
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

            Model.Campeonatos.Campeonato campeonato = new Model.Campeonatos.Campeonato(nome);
            campeonato.LoadDataRow(row);


            if (row.Table.Columns.Contains("IsClube") && !Convert.IsDBNull(row["IsClube"]))
            {
                campeonato.IsClube = Convert.ToBoolean(row["IsClube"]);
            }
            if (row.Table.Columns.Contains("Descricao") && !Convert.IsDBNull(row["Descricao"]))
            {
                campeonato.Descricao = Convert.ToString(row["Descricao"]);
            }

            return campeonato;

        }

        #endregion
    }
}
