using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BolaoNet.Dao.DadosBasicos.Util
{
    public sealed class Time
    {
        #region Constants
        public new const string TableName = "Times";
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

            if (row.Table.Columns.Contains("NomeTime") && !Convert.IsDBNull(row["NomeTime"]))
            {
                nome = Convert.ToString(row["NomeTime"]);
            }

            Model.DadosBasicos.Time time = new BolaoNet.Model.DadosBasicos.Time(nome);
            time.LoadDataRow(row);


            if (row.Table.Columns.Contains("IsClube") && !Convert.IsDBNull(row["IsClube"]))
            {
                time.IsClube = Convert.ToBoolean(row["IsClube"]);
            }
            //if (row.Table.Columns.Contains("Escudo") && !Convert.IsDBNull(row["Escudo"]))
            //{
            //    time.Escudo = Convert.ToString(row["Escudo"]);
            //}
            if (row.Table.Columns.Contains("Fundacao") && !Convert.IsDBNull(row["Fundacao"]))
            {
                time.Fundacao = Convert.ToDateTime(row["Fundacao"]);
            }
            if (row.Table.Columns.Contains("Site") && !Convert.IsDBNull(row["Site"]))
            {
                time.Site = Convert.ToString(row["Site"]);
            }
            if (row.Table.Columns.Contains("Pais") && !Convert.IsDBNull(row["Pais"]))
            {
                time.Pais = Convert.ToString(row["Pais"]);
            }
            if (row.Table.Columns.Contains("Estado") && !Convert.IsDBNull(row["Estado"]))
            {
                time.Estado = Convert.ToString(row["Estado"]);
            }
            if (row.Table.Columns.Contains("Cidade") && !Convert.IsDBNull(row["Cidade"]))
            {
                time.Cidade = Convert.ToString(row["Cidade"]);
            }
            if (row.Table.Columns.Contains("Descricao") && !Convert.IsDBNull(row["Descricao"]))
            {
                time.Descricao = Convert.ToString(row["Descricao"]);
            }
            if (row.Table.Columns.Contains("NomeMascote") && !Convert.IsDBNull(row["NomeMascote"]))
            {
                time.NomeMascote = Convert.ToString(row["NomeMascote"]);
            }
            //if (row.Table.Columns.Contains("Mascote") && !Convert.IsDBNull(row["Mascote"]))
            //{
            //    time.Mascote = Convert.ToString(row["Mascote"]);
            //}


            return time;

        }


        #endregion
    }
}
