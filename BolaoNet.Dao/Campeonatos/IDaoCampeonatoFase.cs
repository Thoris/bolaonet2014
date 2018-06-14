using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Dao.Campeonatos
{
    public interface IDaoCampeonatoFase
    {
        IList<Framework.DataServices.Model.EntityBaseData> LoadFases(string currentUser, Model.Campeonatos.Campeonato entry, out int errorNumber, out string errorDescription);
        bool InsertFase(string currentUser, Model.Campeonatos.Campeonato campeonato, Model.Campeonatos.Fase fase, out int errorNumber, out string errorDescription);
        bool DeleteFase(string currentUser, Model.Campeonatos.Campeonato campeonato, Model.Campeonatos.Fase fase, out int errorNumber, out string errorDescription);
        bool ClearFases(string currentUser, Model.Campeonatos.Campeonato campeonato, out int errorNumber, out string errorDescription);
        bool UpdateFase(string currentUser, Model.Campeonatos.Campeonato campeonato, Model.Campeonatos.Fase fase, out int errorNumber, out string errorDescription);

    }
}
