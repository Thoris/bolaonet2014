using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BolaoNet.Dao.Boloes.Util
{
    public sealed class ApostaExtra
    {
        #region Constants
        public const string TableName = "ApostasExtras";
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
            string nomeBolao = "";
            int posicao = 0;



            if (row.Table.Columns.Contains("Posicao") && !Convert.IsDBNull(row["Posicao"]))
            {
                posicao = Convert.ToInt32(row["Posicao"]);
            }
            if (row.Table.Columns.Contains("NomeBolao") && !Convert.IsDBNull(row["NomeBolao"]))
            {
                nomeBolao = Convert.ToString(row["NomeBolao"]);
            }

            Model.Boloes.ApostaExtra entry = new BolaoNet.Model.Boloes.ApostaExtra (posicao, nomeBolao);
            entry.LoadDataRow(row);

            if (row.Table.Columns.Contains("Titulo") && !Convert.IsDBNull(row["Titulo"]))
            {
                entry.Titulo = Convert.ToString(row["Titulo"]);
            }
            if (row.Table.Columns.Contains("Descricao") && !Convert.IsDBNull(row["Descricao"]))
            {
                entry.Descricao = Convert.ToString(row["Descricao"]);
            }
            if (row.Table.Columns.Contains("TotalPontos") && !Convert.IsDBNull(row["TotalPontos"]))
            {
                entry.TotalPontos = Convert.ToInt32(row["TotalPontos"]);
            }
            if (row.Table.Columns.Contains("IsValido") && !Convert.IsDBNull(row["IsValido"]))
            {
                entry.IsValido = Convert.ToBoolean(row["IsValido"]);
            }
            if (row.Table.Columns.Contains("DataValidacao") && !Convert.IsDBNull(row["DataValidacao"]))
            {
                entry.DataValidacao = Convert.ToDateTime(row["DataValidacao"]);
            }
            if (row.Table.Columns.Contains("ValidadoBy") && !Convert.IsDBNull(row["ValidadoBy"]))
            {
                entry.ValidadoBy = Convert.ToString(row["ValidadoBy"]);
            }
            if (row.Table.Columns.Contains("NomeTimeValidado") && !Convert.IsDBNull(row["NomeTimeValidado"]))
            {
                entry.NomeTimeValidado = Convert.ToString(row["NomeTimeValidado"]);
            }


            return entry;

        }
        #endregion
    }
}
