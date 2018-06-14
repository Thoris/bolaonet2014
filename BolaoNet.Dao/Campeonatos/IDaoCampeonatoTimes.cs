using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Dao.Campeonatos
{
    public interface IDaoCampeonatoTimes
    {
        IList<Framework.DataServices.Model.EntityBaseData> LoadTimes(string currentUser, Model.Campeonatos.Campeonato entry, out int errorNumber, out string errorDescription);
        bool InsertTime(string currentUser, Model.Campeonatos.Campeonato campeonato, Model.DadosBasicos.Time time, out int errorNumber, out string errorDescription);
        bool DeleteTime(string currentUser, Model.Campeonatos.Campeonato campeonato, Model.DadosBasicos.Time time, out int errorNumber, out string errorDescription);
        bool ClearTimes(string currentUser, Model.Campeonatos.Campeonato campeonato, out int errorNumber, out string errorDescription);

    }
}
