using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BolaoNet.Dao.Users.Util
{
    public sealed class UserBoloes
    {
        #region Methods
        public static IList<Model.Users.UserBoloes> ConvertUserBoloesToList(DataTable table)
        {
            IList<Model.Users.UserBoloes> list = new List<Model.Users.UserBoloes>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(ConvertUserBoloesToObject(row));
            }

            return list;
        }
        public static Model.Users.UserBoloes ConvertUserBoloesToObject(DataRow row)
        {

            Model.Users.UserBoloes entry = new Model.Users.UserBoloes();

            if (row.Table.Columns.Contains("NomeBolao") && !Convert.IsDBNull(row["NomeBolao"]))
            {
                entry.Bolao = new Model.Boloes.Bolao(Convert.ToString(row["NomeBolao"]));
            }

            if (row.Table.Columns.Contains("NomeCampeonato") && !Convert.IsDBNull(row["NomeCampeonato"]))
            {
                entry.Bolao.Campeonato = new Model.Campeonatos.Campeonato(Convert.ToString(row["Nomecampeonato"]));
            }

            if (row.Table.Columns.Contains("Position") && !Convert.IsDBNull(row["Position"]))
            {
                entry.Position = Convert.ToInt32(row["Position"]);
            }

            if (row.Table.Columns.Contains("Membros") && !Convert.IsDBNull(row["Membros"]))
            {
                entry.Membros = Convert.ToInt32(row["Membros"]);
            }

            if (row.Table.Columns.Contains("ApostasRestantes") && !Convert.IsDBNull(row["ApostasRestantes"]))
            {
                entry.ApostasRestantes = Convert.ToInt32(row["ApostasRestantes"]);
            }

            entry.LoadDataRow(row);

            return entry;

        }
        #endregion

    }
}
