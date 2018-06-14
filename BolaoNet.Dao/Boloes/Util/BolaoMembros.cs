using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BolaoNet.Dao.Boloes.Util
{
    public sealed class BolaoMembros
    {
        #region Methods

        public static IList<Model.Boloes.BolaoMembros> ConvertUserPontosToList(DataTable table)
        {
            IList<Model.Boloes.BolaoMembros> list = new List<Model.Boloes.BolaoMembros>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(ConvertUserPontosToObject(row));
            }

            return list;
        }
        public static Model.Boloes.BolaoMembros ConvertUserPontosToObject(DataRow row)
        {
            string nome = "";

            if (row.Table.Columns.Contains("UserName") && !Convert.IsDBNull(row["UserName"]))
            {
                nome = Convert.ToString(row["UserName"]);
            }

            Model.Boloes.BolaoMembros entry = new Model.Boloes.BolaoMembros(nome);

            if (row.Table.Columns.Contains("FullName") && !Convert.IsDBNull(row["FullName"]))
            {
                entry.FullName = Convert.ToString(row["FullName"]);
            }
            if (row.Table.Columns.Contains("Posicao") && !Convert.IsDBNull(row["Posicao"]))
            {
                entry.Posicao = Convert.ToInt32(row["Posicao"]);
            }
            if (row.Table.Columns.Contains("LastPosicao") && !Convert.IsDBNull(row["LastPosicao"]))
            {
                entry.LastPosicao = Convert.ToInt32(row["LastPosicao"]);
            }



            if (row.Table.Columns.Contains("totalPontos") && !Convert.IsDBNull(row["totalPontos"]))
            {
                entry.TotalPontos = Convert.ToInt32(row["totalPontos"]);
            }
            if (row.Table.Columns.Contains("totalEmpate") && !Convert.IsDBNull(row["totalEmpate"]))
            {
                entry.TotalEmpate = Convert.ToInt32(row["totalEmpate"]);
            }
            if (row.Table.Columns.Contains("totalVitoria") && !Convert.IsDBNull(row["totalVitoria"]))
            {
                entry.TotalVitoria = Convert.ToInt32(row["totalVitoria"]);
            }
            if (row.Table.Columns.Contains("totalGolsGanhador") && !Convert.IsDBNull(row["totalGolsGanhador"]))
            {
                entry.TotalGolsGanhador = Convert.ToInt32(row["totalGolsGanhador"]);
            }
            if (row.Table.Columns.Contains("totalGolsPerdedor") && !Convert.IsDBNull(row["totalGolsPerdedor"]))
            {
                entry.TotalGolsPerdedor = Convert.ToInt32(row["totalGolsPerdedor"]);
            }
            if (row.Table.Columns.Contains("totalResultTime1") && !Convert.IsDBNull(row["totalResultTime1"]))
            {
                entry.TotalResultTime1 = Convert.ToInt32(row["totalResultTime1"]);
            }
            if (row.Table.Columns.Contains("totalResultTime2") && !Convert.IsDBNull(row["totalResultTime2"]))
            {
                entry.TotalResultTime2 = Convert.ToInt32(row["totalResultTime2"]);
            }
            if (row.Table.Columns.Contains("totalVDE") && !Convert.IsDBNull(row["totalVDE"]))
            {
                entry.TotalVDE = Convert.ToInt32(row["totalVDE"]);
            }
            if (row.Table.Columns.Contains("totalErro") && !Convert.IsDBNull(row["totalErro"]))
            {
                entry.TotalErro = Convert.ToInt32(row["totalErro"]);
            }
            if (row.Table.Columns.Contains("totalGolsGanhadorFora") && !Convert.IsDBNull(row["totalGolsGanhadorFora"]))
            {
                entry.TotalGolsGanhadorFora = Convert.ToInt32(row["totalGolsGanhadorFora"]);
            }

            if (row.Table.Columns.Contains("totalGolsGanhadorDentro") && !Convert.IsDBNull(row["totalGolsGanhadorDentro"]))
            {
                entry.TotalGolsGanhadorDentro = Convert.ToInt32(row["totalGolsGanhadorDentro"]);
            }
            if (row.Table.Columns.Contains("totalPerdedorFora") && !Convert.IsDBNull(row["totalPerdedorFora"]))
            {
                entry.TotalPerdedorFora = Convert.ToInt32(row["totalPerdedorFora"]);
            }
            if (row.Table.Columns.Contains("totalPerdedorDentro") && !Convert.IsDBNull(row["totalPerdedorDentro"]))
            {
                entry.TotalPerdedorDentro = Convert.ToInt32(row["totalPerdedorDentro"]);
            }
            if (row.Table.Columns.Contains("totalGolsEmpate") && !Convert.IsDBNull(row["totalGolsEmpate"]))
            {
                entry.TotalGolsEmpate = Convert.ToInt32(row["totalGolsEmpate"]);
            }
            if (row.Table.Columns.Contains("totalGolsTime1") && !Convert.IsDBNull(row["totalGolsTime1"]))
            {
                entry.TotalGolsTime1 = Convert.ToInt32(row["totalGolsTime1"]);
            }
            if (row.Table.Columns.Contains("totalGolsTime2") && !Convert.IsDBNull(row["totalGolsTime2"]))
            {
                entry.TotalGolsTime2 = Convert.ToInt32(row["totalGolsTime2"]);
            }

            if (row.Table.Columns.Contains("totalPlacarCheio") && !Convert.IsDBNull(row["totalPlacarCheio"]))
            {
                entry.TotalPlacarCheio = Convert.ToInt32(row["totalPlacarCheio"]);
            }
            if (row.Table.Columns.Contains("totalApostaExtra") && !Convert.IsDBNull(row["totalApostaExtra"]))
            {
                entry.TotalApostaExtra = Convert.ToInt32(row["totalApostaExtra"]);
            }


            return entry;

        }
        #endregion
    }
}
