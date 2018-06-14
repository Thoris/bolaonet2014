using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Dao.Campeonatos
{
    public interface IGrupo 
    {

 

        #region Grupos

        IList<Framework.DataServices.Model.EntityBaseData> LoadTimes(string currentUser, Model.Campeonatos.Campeonato campeonato, Model.Campeonatos.Grupo grupo, out int errorNumber, out string errorDescription);
        bool InsertTime(string currentUser, Model.Campeonatos.Campeonato campeonato, Model.Campeonatos.Grupo grupo, Model.DadosBasicos.Time time, out int errorNumber, out string errorDescription);
        bool DeleteTime(string currentUser, Model.Campeonatos.Campeonato campeonato, Model.Campeonatos.Grupo grupo, Model.DadosBasicos.Time time, out int errorNumber, out string errorDescription);
        bool ClearTimes(string currentUser, Model.Campeonatos.Campeonato campeonato, Model.Campeonatos.Grupo grupo, out int errorNumber, out string errorDescription);

        #endregion
    }
}
