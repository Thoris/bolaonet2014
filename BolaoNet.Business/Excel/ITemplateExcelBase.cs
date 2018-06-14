using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Business.Excel
{
    public interface ITemplateExcelBase
    {
        bool SaveUserFile(Model.Boloes.Bolao bolao, Model.Campeonatos.Campeonato campeonato, Framework.Security.Model.UserData user);
        bool SaveExisitingUserFile(Model.Boloes.Bolao bolao, Model.Campeonatos.Campeonato campeonato, Framework.Security.Model.UserData user);
    }
}
