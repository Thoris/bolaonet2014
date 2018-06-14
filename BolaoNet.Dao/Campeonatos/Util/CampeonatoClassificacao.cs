using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BolaoNet.Dao.Campeonatos.Util
{
    public sealed class CampeonatoClassificacao
    {
        #region Methods

        public static IList<Model.Campeonatos.CampeonatoClassificacao> ConvertToClassificacaoList(DataTable table)
        {
            IList<Model.Campeonatos.CampeonatoClassificacao> list = new List<Model.Campeonatos.CampeonatoClassificacao>();

            int pos = 1;

            foreach (DataRow row in table.Rows)
            {
                list.Add(ConvertToClassificacaoObject(row));

                //if (list[pos - 1].Posicao == 0)
                //    list[pos - 1].Posicao = pos;

                pos++;
            }

            return list;
        }
        public static Model.Campeonatos.CampeonatoClassificacao ConvertToClassificacaoObject(DataRow row)
        {

            Model.Campeonatos.CampeonatoClassificacao entry = new Model.Campeonatos.CampeonatoClassificacao();


            if (row.Table.Columns.Contains("NomeCampeonato") && !Convert.IsDBNull(row["NomeCampeonato"]))
            {
                entry.Campeonato = new Model.Campeonatos.Campeonato(Convert.ToString(row["NomeCampeonato"]));
            }

            if (row.Table.Columns.Contains("NomeFase") && !Convert.IsDBNull(row["NomeFase"]))
            {
                entry.Fase = new Model.Campeonatos.Fase(Convert.ToString(row["NomeFase"]));
            }
            if (row.Table.Columns.Contains("NomeTime") && !Convert.IsDBNull(row["NomeTime"]))
            {
                entry.Time = new Model.DadosBasicos.Time(Convert.ToString(row["NomeTime"]));
            }
            if (row.Table.Columns.Contains("NomeGrupo") && !Convert.IsDBNull(row["NomeGrupo"]))
            {
                entry.Grupo = new Model.Campeonatos.Grupo(Convert.ToString(row["NomeGrupo"]));
            }

            if (row.Table.Columns.Contains("TotalVitorias") && !Convert.IsDBNull(row["TotalVitorias"]))
            {
                entry.TotalVitorias = Convert.ToInt32(row["TotalVitorias"]);
            }
            if (row.Table.Columns.Contains("TotalDerrotas") && !Convert.IsDBNull(row["TotalDerrotas"]))
            {
                entry.TotalDerrotas = Convert.ToInt32(row["TotalDerrotas"]);
            }
            if (row.Table.Columns.Contains("TotalEmpates") && !Convert.IsDBNull(row["TotalEmpates"]))
            {
                entry.TotalEmpates = Convert.ToInt32(row["TotalEmpates"]);
            }
            if (row.Table.Columns.Contains("TotalGolsContra") && !Convert.IsDBNull(row["TotalGolsContra"]))
            {
                entry.TotalGolsContra = Convert.ToInt32(row["TotalGolsContra"]);
            }
            if (row.Table.Columns.Contains("TotalGolsPro") && !Convert.IsDBNull(row["TotalGolsPro"]))
            {
                entry.TotalGolsPro = Convert.ToInt32(row["TotalGolsPro"]);
            }
            if (row.Table.Columns.Contains("TotalPontos") && !Convert.IsDBNull(row["TotalPontos"]))
            {
                entry.TotalPontos = Convert.ToInt32(row["TotalPontos"]);
            }
            if (row.Table.Columns.Contains("Saldo") && !Convert.IsDBNull(row["Saldo"]))
            {
                entry.Saldo = Convert.ToInt32(row["Saldo"]);
            }
            if (row.Table.Columns.Contains("Jogos") && !Convert.IsDBNull(row["Jogos"]))
            {
                entry.Jogos = Convert.ToInt32(row["Jogos"]);
            }
            if (row.Table.Columns.Contains("Posicao") && !Convert.IsDBNull(row["Posicao"]))
            {
                entry.Posicao = Convert.ToInt32(row["Posicao"]);
            }
            if (row.Table.Columns.Contains("LastPosicao") && !Convert.IsDBNull(row["LastPosicao"]))
            {
                entry.LastPosicao = Convert.ToInt32(row["LastPosicao"]);
            }

            entry.LoadDataRow(row);



            return entry;

        }

        #endregion
    }
}
