using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BolaoNet.Dao.Campeonatos.Util
{
    public sealed class CampeonatoHistorico
    {
        #region Constants
        public new const string TableName = "CampeonatosHistorico";
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
            int ano = 0;

            if (row.Table.Columns.Contains("Nome") && !Convert.IsDBNull(row["Nome"]))
            {
                nome = Convert.ToString(row["Nome"]);
            }
            if (row.Table.Columns.Contains("Ano") && !Convert.IsDBNull(row["Ano"]))
            {
                ano = Convert.ToInt32(row["Ano"]);
            }

            Model.Campeonatos.Historico entry = new BolaoNet.Model.Campeonatos.Historico(ano, nome);
            entry.LoadDataRow(row);

            if (row.Table.Columns.Contains("Sede") && !Convert.IsDBNull(row["Sede"]))
            {
                entry.Sede = Convert.ToString(row["Sede"]);
            }
            if (row.Table.Columns.Contains("NomeTimecampeao") && !Convert.IsDBNull(row["NomeTimecampeao"]))
            {
                entry.NomeTimeCampeao = new BolaoNet.Model.DadosBasicos.Time ( Convert.ToString(row["NomeTimecampeao"]));
            }
            if (row.Table.Columns.Contains("NomeTimeVice") && !Convert.IsDBNull(row["NomeTimeVice"]))
            {
                entry.NomeTimeVice = new BolaoNet.Model.DadosBasicos.Time(Convert.ToString(row["NomeTimeVice"]));
            }
            if (row.Table.Columns.Contains("NomeTimeTerceiro") && !Convert.IsDBNull(row["NomeTimeTerceiro"]))
            {
                entry.NomeTimeTerceiro = new BolaoNet.Model.DadosBasicos.Time(Convert.ToString(row["NomeTimeTerceiro"]));
            }

            if (row.Table.Columns.Contains("FinalTime1") && !Convert.IsDBNull(row["FinalTime1"]))
            {
                entry.FinalTime1= Convert.ToInt32(row["FinalTime1"]);
            }
            if (row.Table.Columns.Contains("FinalTime2") && !Convert.IsDBNull(row["FinalTime2"]))
            {
                entry.FinalTime2 = Convert.ToInt32(row["FinalTime2"]);
            }
            if (row.Table.Columns.Contains("FinalPenaltis1") && !Convert.IsDBNull(row["FinalPenaltis1"]))
            {
                entry.FinalPenaltis1 = Convert.ToInt32(row["FinalPenaltis1"]);
            }
            if (row.Table.Columns.Contains("FinalPenaltis2") && !Convert.IsDBNull(row["FinalPenaltis2"]))
            {
                entry.FinalPenaltis2 = Convert.ToInt32(row["FinalPenaltis2"]);
            }


            return entry;

        }

        #endregion
    }
}
