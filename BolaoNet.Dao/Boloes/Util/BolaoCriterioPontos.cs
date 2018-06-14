using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BolaoNet.Dao.Boloes.Util
{
    public sealed class BolaoCriterioPontos
    {
        #region Methods
        public static IList<Framework.DataServices.Model.EntityBaseData> ConvertToCriteriosPontosList(DataTable table)
        {
            IList<Framework.DataServices.Model.EntityBaseData> list = new List<Framework.DataServices.Model.EntityBaseData>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(ConvertToCriteriosPontosObject(row));
            }

            return list;
        }
        public static Framework.DataServices.Model.EntityBaseData ConvertToCriteriosPontosObject(DataRow row)
        {
            string nomeBolao = "";
            int criterioID = 0;

            if (row.Table.Columns.Contains("NomeBolao") && !Convert.IsDBNull(row["NomeBolao"]))
            {
                nomeBolao = Convert.ToString(row["NomeBolao"]);
            }
            if (row.Table.Columns.Contains("CriterioID") && !Convert.IsDBNull(row["CriterioID"]))
            {
                criterioID = Convert.ToInt32(row["CriterioID"]);
            }

            Model.Boloes.BolaoCriterioPontos entry = new BolaoNet.Model.Boloes.BolaoCriterioPontos(nomeBolao, (Model.Boloes.BolaoCriterioPontos.CriteriosID)criterioID);
            entry.LoadDataRow(row);


            if (row.Table.Columns.Contains("Pontos") && !Convert.IsDBNull(row["Pontos"]))
            {
                entry.Pontos = Convert.ToInt32(row["Pontos"]);
            }
            if (row.Table.Columns.Contains("Descricao") && !Convert.IsDBNull(row["Descricao"]))
            {
                entry.Descricao = Convert.ToString(row["Descricao"]);
            }

            if (row.Table.Columns.Contains("NomeTime") && !Convert.IsDBNull(row["NomeTime"]))
            {
                entry.Time = new BolaoNet.Model.DadosBasicos.Time(Convert.ToString(row["NomeTime"]));
            }
            if (row.Table.Columns.Contains("MultiploTime") && !Convert.IsDBNull(row["MultiploTime"]))
            {
                entry.MultiploTime = Convert.ToInt32(row["MultiploTime"]);
            }

            return entry;

        }

        #endregion
    }
}
