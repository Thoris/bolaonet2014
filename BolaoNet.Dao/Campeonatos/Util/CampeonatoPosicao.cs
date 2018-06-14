using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BolaoNet.Dao.Campeonatos.Util
{
    public sealed class CampeonatoPosicao
    {
        #region Methods

        public static IList<Framework.DataServices.Model.EntityBaseData> ConvertToPosicaoList(DataTable table)
        {
            IList<Framework.DataServices.Model.EntityBaseData> list = new List<Framework.DataServices.Model.EntityBaseData>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(ConvertToPosicaoObject(row));
            }

            return list;
        }
        public static Framework.DataServices.Model.EntityBaseData ConvertToPosicaoObject(DataRow row)
        {
            string nomeCampeonato = "";
            string nomeFase = "";
            string nomeGrupo = "";
            int posicao = 0;

            if (row.Table.Columns.Contains("NomeCampeonato") && !Convert.IsDBNull(row["NomeCampeonato"]))
            {
                nomeCampeonato = Convert.ToString(row["NomeCampeonato"]);
            }
            if (row.Table.Columns.Contains("NomeFase") && !Convert.IsDBNull(row["NomeFase"]))
            {
                nomeFase = Convert.ToString(row["NomeFase"]);
            }
            if (row.Table.Columns.Contains("NomeGrupo") && !Convert.IsDBNull(row["NomeGrupo"]))
            {
                nomeGrupo = Convert.ToString(row["NomeGrupo"]);
            }
            if (row.Table.Columns.Contains("Posicao") && !Convert.IsDBNull(row["Posicao"]))
            {
                posicao = Convert.ToInt32(row["Posicao"]);
            }

            Model.Campeonatos.CampeonatoPosicao campeonatoPosicao = new Model.Campeonatos.CampeonatoPosicao
                (nomeCampeonato, nomeFase, nomeGrupo, posicao);
            campeonatoPosicao.LoadDataRow(row);


            if (row.Table.Columns.Contains("Titulo") && !Convert.IsDBNull(row["Titulo"]))
            {
                campeonatoPosicao.Titulo = Convert.ToString(row["Titulo"]);
            }
            if (row.Table.Columns.Contains("BackColor") && !Convert.IsDBNull(row["BackColor"]))
            {
                campeonatoPosicao.BackColor = System.Drawing.Color.FromName(Convert.ToString(row["BackColor"]));
            }
            if (row.Table.Columns.Contains("ForeColor") && !Convert.IsDBNull(row["ForeColor"]))
            {
                campeonatoPosicao.ForeColor = System.Drawing.Color.FromName(Convert.ToString(row["ForeColor"]));
            }


            return campeonatoPosicao;

        }

        #endregion
    }
}
