using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BolaoNet.Dao.Campeonatos.Util
{
    public sealed class Jogo
    {
        #region Constants
        public new const string TableName = "Jogos";
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
            long idJogo = 0;

            if (row.Table.Columns.Contains("IdJogo") && !Convert.IsDBNull(row["IdJogo"]))
            {
                idJogo = Convert.ToInt64(row["IdJogo"]);
            }

            Model.Campeonatos.Jogo jogo = new Model.Campeonatos.Jogo(idJogo);
            jogo.LoadDataRow(row);

            if (row.Table.Columns.Contains("NomeCampeonato") && !Convert.IsDBNull(row["NomeCampeonato"]))
            {
                jogo.Campeonato = new Model.Campeonatos.Campeonato(Convert.ToString(row["NomeCampeonato"]));
            }

            if (row.Table.Columns.Contains("NomeFase") && !Convert.IsDBNull(row["NomeFase"]))
            {
                jogo.Fase = new Model.Campeonatos.Fase(Convert.ToString(row["NomeFase"]));
            }

            if (row.Table.Columns.Contains("NomeGrupo") && !Convert.IsDBNull(row["NomeGrupo"]))
            {
                jogo.Grupo = new Model.Campeonatos.Grupo(Convert.ToString(row["NomeGrupo"]));
            }

            if (row.Table.Columns.Contains("Titulo") && !Convert.IsDBNull(row["Titulo"]))
            {
                jogo.Titulo = Convert.ToString(row["Titulo"]);
            }

            if (row.Table.Columns.Contains("NomeTime1") && !Convert.IsDBNull(row["NomeTime1"]))
            {
                jogo.Time1 = new Model.DadosBasicos.Time(Convert.ToString(row["NomeTime1"]));
            }

            if (row.Table.Columns.Contains("Gols1") && !Convert.IsDBNull(row["Gols1"]))
            {
                jogo.GolsTime1 = Convert.ToInt32(row["Gols1"]);
            }

            if (row.Table.Columns.Contains("Penaltis1") && !Convert.IsDBNull(row["Penaltis1"]))
            {
                jogo.PenaltisTime1 = Convert.ToInt32(row["Penaltis1"]);
            }


            if (row.Table.Columns.Contains("DescricaoTime1") && !Convert.IsDBNull(row["DescricaoTime1"]))
            {
                jogo.DescricaoTime1 = Convert.ToString(row["DescricaoTime1"]);
            }

            if (row.Table.Columns.Contains("NomeTime2") && !Convert.IsDBNull(row["NomeTime2"]))
            {
                jogo.Time2 = new Model.DadosBasicos.Time(Convert.ToString(row["NomeTime2"]));
            }

            if (row.Table.Columns.Contains("Gols2") && !Convert.IsDBNull(row["Gols2"]))
            {
                jogo.GolsTime2 = Convert.ToInt32(row["Gols2"]);
            }

            if (row.Table.Columns.Contains("Penaltis2") && !Convert.IsDBNull(row["Penaltis2"]))
            {
                jogo.PenaltisTime2 = Convert.ToInt32(row["Penaltis2"]);
            }

            if (row.Table.Columns.Contains("DescricaoTime2") && !Convert.IsDBNull(row["DescricaoTime2"]))
            {
                jogo.DescricaoTime2 = Convert.ToString(row["DescricaoTime2"]);
            }

            if (row.Table.Columns.Contains("DataJogo") && !Convert.IsDBNull(row["DataJogo"]))
            {
                jogo.DataJogo = Convert.ToDateTime(row["DataJogo"]);
            }

            if (row.Table.Columns.Contains("Rodada") && !Convert.IsDBNull(row["Rodada"]))
            {
                jogo.Rodada = Convert.ToInt32(row["Rodada"]);
            }

            if (row.Table.Columns.Contains("IsValido") && !Convert.IsDBNull(row["IsValido"]))
            {
                jogo.PartidaValida = Convert.ToBoolean(row["IsValido"]);
            }

            if (row.Table.Columns.Contains("DataValidacao") && !Convert.IsDBNull(row["DataValidacao"]))
            {
                jogo.DataValidacao = Convert.ToDateTime(row["DataValidacao"]);
            }

            if (row.Table.Columns.Contains("ValidadoBy") && !Convert.IsDBNull(row["ValidadoBy"]))
            {
                jogo.ValidadoBy = Convert.ToString(row["ValidadoBy"]);
            }

            if (row.Table.Columns.Contains("NomeEstadio") && !Convert.IsDBNull(row["NomeEstadio"]))
            {
                jogo.Estadio = new Model.DadosBasicos.Estadio(Convert.ToString(row["NomeEstadio"]));
            }

            if (row.Table.Columns.Contains("JogoLabel") && !Convert.IsDBNull(row["JogoLabel"]))
            {
                jogo.JogoLabel = Convert.ToString(row["JogoLabel"]);
            }



            if (row.Table.Columns.Contains("PendenteTime1JogoID") && !Convert.IsDBNull(row["PendenteTime1JogoID"]))
            {
                jogo.PendenteIdTime1 = Convert.ToInt32(row["PendenteTime1JogoID"]);
            }
            if (row.Table.Columns.Contains("PendenteTime2JogoID") && !Convert.IsDBNull(row["PendenteTime2JogoID"]))
            {
                jogo.PendenteIdTime2 = Convert.ToInt32(row["PendenteTime2JogoID"]);
            }
            if (row.Table.Columns.Contains("PendenteTime1Ganhador") && !Convert.IsDBNull(row["PendenteTime1Ganhador"]))
            {
                jogo.PendenteTime1Ganhador = Convert.ToInt32(row["PendenteTime1Ganhador"])== 1 ? true : false;
            }
            if (row.Table.Columns.Contains("PendenteTime2Ganhador") && !Convert.IsDBNull(row["PendenteTime2Ganhador"]))
            {
                jogo.PendenteTime2Ganhador = Convert.ToInt32(row["PendenteTime2Ganhador"]) == 1 ? true : false;
            }

            if (row.Table.Columns.Contains("PendenteTime1NomeGrupo") && !Convert.IsDBNull(row["PendenteTime1NomeGrupo"]))
            {
                jogo.PendenteTime1NomeGrupo = Convert.ToString(row["PendenteTime1NomeGrupo"]) ;
            }
            if (row.Table.Columns.Contains("PendenteTime2NomeGrupo") && !Convert.IsDBNull(row["PendenteTime2NomeGrupo"]))
            {
                jogo.PendenteTime2NomeGrupo = Convert.ToString(row["PendenteTime2NomeGrupo"]);
            }

            if (row.Table.Columns.Contains("PendenteTime1PosGrupo") && !Convert.IsDBNull(row["PendenteTime1PosGrupo"]))
            {
                jogo.PendenteTime1PosGrupo = Convert.ToInt32(row["PendenteTime1PosGrupo"]);
            }
            if (row.Table.Columns.Contains("PendenteTime2PosGrupo") && !Convert.IsDBNull(row["PendenteTime2PosGrupo"]))
            {
                jogo.PendenteTime2PosGrupo = Convert.ToInt32(row["PendenteTime2PosGrupo"]);
            }


            return jogo;

        }


        #endregion
    }
}
