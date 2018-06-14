using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BolaoNet.Dao.Boloes.Util
{
    public sealed class Bolao
    {
        #region Constants
        public new const string TableName = "Boloes";
        public const string TableLinkToUsers = "BoloesMembros";
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

            Model.Boloes.Bolao entry = new Model.Boloes.Bolao(nome);
            entry.LoadDataRow(row);

            if (row.Table.Columns.Contains("NomeCampeonato") && !Convert.IsDBNull(row["NomeCampeonato"]))
            {
                entry.Campeonato = new BolaoNet.Model.Campeonatos.Campeonato(Convert.ToString(row["NomeCampeonato"]));
            }
            if (row.Table.Columns.Contains("Descricao") && !Convert.IsDBNull(row["Descricao"]))
            {
                entry.Descricao = Convert.ToString(row["Descricao"]);
            }
            if (row.Table.Columns.Contains("TaxaParticipacao") && !Convert.IsDBNull(row["TaxaParticipacao"]))
            {
                entry.TaxaParticipacao = Convert.ToDecimal(row["TaxaParticipacao"]);
            }
            if (row.Table.Columns.Contains("Foto") && !Convert.IsDBNull(row["Foto"]))
            {
                //entry.Foto = Convert.ToDecimal(row["Foto"]);
            }
            if (row.Table.Columns.Contains("Publico") && !Convert.IsDBNull(row["Publico"]))
            {
                entry.Publico = Convert.ToBoolean(row["Publico"]);
            }
            if (row.Table.Columns.Contains("ForumAtivado") && !Convert.IsDBNull(row["ForumAtivado"]))
            {
                entry.ForumAtivado = Convert.ToBoolean(row["ForumAtivado"]);
            }
            if (row.Table.Columns.Contains("PermitirMsgAnonimos") && !Convert.IsDBNull(row["PermitirMsgAnonimos"]))
            {
                entry.PermitirMsgAnonimos = Convert.ToBoolean(row["PermitirMsgAnonimos"]);
            }
            if (row.Table.Columns.Contains("DataInicio") && !Convert.IsDBNull(row["DataInicio"]))
            {
                entry.DataInicio = Convert.ToDateTime(row["DataInicio"]);
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
            if (row.Table.Columns.Contains("ApostasApenasAntes") && !Convert.IsDBNull(row["ApostasApenasAntes"]))
            {
                entry.ApostasApenasAntes = Convert.ToBoolean(row["ApostasApenasAntes"]);
            }
            if (row.Table.Columns.Contains("HorasLimiteAposta") && !Convert.IsDBNull(row["HorasLimiteAposta"]))
            {
                entry.HorasLimiteAposta = Convert.ToInt32(row["HorasLimiteAposta"]);
            }
            if (row.Table.Columns.Contains("IsIniciado") && !Convert.IsDBNull(row["IsIniciado"]))
            {
                entry.IsIniciado = Convert.ToBoolean(row["IsIniciado"]);
            }
            if (row.Table.Columns.Contains("IniciadoBy") && !Convert.IsDBNull(row["IniciadoBy"]))
            {
                entry.IniciadoBy = Convert.ToString(row["IniciadoBy"]);
            }
            if (row.Table.Columns.Contains("DataIniciado") && !Convert.IsDBNull(row["DataIniciado"]))
            {
                entry.DataIniciado = Convert.ToDateTime(row["DataIniciado"]);
            }




            return entry;

        }
        #endregion
    }
}
