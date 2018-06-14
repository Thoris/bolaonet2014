using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BolaoNet.Dao.Boloes.Util
{
    public sealed class BolaoUserClassificacao
    {
        #region Methods

        public static IList<Model.Boloes.Reports.UserClassificacaoRodada> ConvertUserPontosToList(DataTable table)
        {
            IList<Model.Boloes.Reports.UserClassificacaoRodada> list = new List<Model.Boloes.Reports.UserClassificacaoRodada>();

            int posicao = 0;
            int lastRodada = 0;
            int lastPosicao = 1;
            int lastPontos = 0;
            Model.Boloes.Reports.UserClassificacaoRodada modelRodada = null;

            foreach (DataRow row in table.Rows)
            {
                posicao++;

                //Criando a entrada de dados
                Model.Boloes.Reports.UserClassificacao entry = ConvertUserPontosToObject(row);
                
                //Se encontrou outra rodada
                if (entry.Rodada != lastRodada)
                {
                    posicao = 1;
                    lastPontos = 0;
                    lastRodada = entry.Rodada;


                    modelRodada = new BolaoNet.Model.Boloes.Reports.UserClassificacaoRodada(lastRodada);
                    list.Add(modelRodada);

                }

                
                //Se o usuário tem a mesma quantidade de pontos do usuário anterior
                if (lastPontos == entry.Pontos)
                {
                    entry.Posicao = lastPosicao;
                }
                else
                {
                    entry.Posicao = posicao;
                    lastPosicao = posicao;
                }

                lastPontos = entry.Pontos;


                modelRodada.Membros.Add(entry);


                
            }

            return list;
        }
        public static Model.Boloes.Reports.UserClassificacao ConvertUserPontosToObject(DataRow row)
        {

            Model.Boloes.Reports.UserClassificacao entry = new BolaoNet.Model.Boloes.Reports.UserClassificacao();

            if (row.Table.Columns.Contains("UserName") && !Convert.IsDBNull(row["UserName"]))
            {
                entry.UserName = Convert.ToString(row["UserName"]);
            }

            if (row.Table.Columns.Contains("Rodada") && !Convert.IsDBNull(row["Rodada"]))
            {
                entry.Rodada = Convert.ToInt32(row["Rodada"]);
            }

            if (row.Table.Columns.Contains("Pontos") && !Convert.IsDBNull(row["Pontos"]))
            {
                entry.Pontos = Convert.ToInt32(row["Pontos"]);
            }
            return entry;

        }
        #endregion
    }
}
