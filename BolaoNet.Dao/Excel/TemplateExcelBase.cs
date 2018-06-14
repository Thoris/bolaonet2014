using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.OleDb;

namespace BolaoNet.Dao.Excel
{
    public class TemplateExcelBase : ExcelBase, ITemplateExcelBase
    {
        #region Constructors/Destructors
        public TemplateExcelBase()
        {
        }
        #endregion

        #region Methods
        public List<Model.Boloes.JogoUsuario> ConvertToList(DataTable table)
        {
            List<Model.Boloes.JogoUsuario> list = new List<Model.Boloes.JogoUsuario>();

            foreach (DataRow row in table.Rows)
            {
                Model.Boloes.JogoUsuario dataObject = ConvertToObject(row);

                if (dataObject != null)
                    list.Add(dataObject);
            }

            return list;

        }
        public Model.Boloes.JogoUsuario ConvertToObject(DataRow row)
        {
            Model.Boloes.JogoUsuario model = new BolaoNet.Model.Boloes.JogoUsuario();




            

            if (!Convert.IsDBNull(row[2]) && !Convert.IsDBNull (row[8]))
            {
                if (!Convert.IsDBNull(row[0]))
                    model.DataJogo = Convert.ToDateTime(row[0].ToString());

                if (!Convert.IsDBNull(row[1]))
                {
                    DateTime hourJogo = Convert.ToDateTime(row[1].ToString());

                    DateTime dateJogo = model.DataJogo;
                    model.DataJogo = new DateTime(dateJogo.Year, dateJogo.Month, dateJogo.Day,
                        hourJogo.Hour, hourJogo.Minute, hourJogo.Second);
                }
            }
            else
                return null;

            if (!Convert.IsDBNull(row[2]))
                model.Time1 = new BolaoNet.Model.DadosBasicos.Time(Convert.ToString(row[2]));

            if (!Convert.IsDBNull(row[4]))
                model.ApostaTime1 = Convert.ToInt32 (row[4]);

            if (!Convert.IsDBNull(row[6]))
                model.ApostaTime2 = Convert.ToInt32(row[6]);

            if (!Convert.IsDBNull(row[8]))
                model.Time2 = new BolaoNet.Model.DadosBasicos.Time(Convert.ToString(row[8]));

            if (!Convert.IsDBNull(row[9]))
                model.Estadio = new BolaoNet.Model.DadosBasicos.Estadio (Convert.ToString(row[9]));

            return model;
        }
        #endregion

        #region ITemplateExcelBase Members

        public List<BolaoNet.Model.Boloes.JogoUsuario> LoadJogosUsuario(OleDbConnection connection)
        {
            List<Model.Boloes.JogoUsuario> list = new List<Model.Boloes.JogoUsuario>();

            DataTable table = base.LoadSheet(connection, null, "Tabela", null);

            return ConvertToList (table);
        }

        #endregion
    }
}
