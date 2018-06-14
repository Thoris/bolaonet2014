using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BolaoNet.Dao.DadosBasicos.Util
{
    public sealed class Estadio
    {
        #region Constants
        public new const string TableName = "Estadios";
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

            Model.DadosBasicos.Estadio entry = new BolaoNet.Model.DadosBasicos.Estadio(nome);
            entry.LoadDataRow(row);

            if (row.Table.Columns.Contains("NomeTime") && !Convert.IsDBNull(row["NomeTime"]))
            {
                entry.Time = new BolaoNet.Model.DadosBasicos.Time(Convert.ToString(row["NomeTime"]));
            }
            if (row.Table.Columns.Contains("Pais") && !Convert.IsDBNull(row["Pais"]))
            {
                entry.Pais = Convert.ToString(row["Pais"]);
            }
            if (row.Table.Columns.Contains("Estado") && !Convert.IsDBNull(row["Estado"]))
            {
                entry.Estado = Convert.ToString(row["Estado"]);
            }
            if (row.Table.Columns.Contains("Cidade") && !Convert.IsDBNull(row["Cidade"]))
            {
                entry.Cidade = Convert.ToString(row["Cidade"]);
            }
            //if (row.Table.Columns.Contains("Foto") && !Convert.IsDBNull(row["Foto"]))
            //{
            //    entry.Foto = Convert.ToString(row["Foto"]);
            //}
            if (row.Table.Columns.Contains("Capacidade") && !Convert.IsDBNull(row["Capacidade"]))
            {
                entry.Capacidade = Convert.ToInt64(row["Capacidade"]);
            }
            if (row.Table.Columns.Contains("Descricao") && !Convert.IsDBNull(row["Descricao"]))
            {
                entry.Descricao = Convert.ToString(row["Descricao"]);
            }



            return entry;

        }


        #endregion
    }
}
