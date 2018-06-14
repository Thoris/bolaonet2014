using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace BolaoNet.Dao.Excel
{
    public interface ITemplateExcelBase
    {
        List<Model.Boloes.JogoUsuario> LoadJogosUsuario(OleDbConnection connection);
    }
}
