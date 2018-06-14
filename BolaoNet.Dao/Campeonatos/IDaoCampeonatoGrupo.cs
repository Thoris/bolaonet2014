using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Dao.Campeonatos
{
    public interface IDaoCampeonatoGrupo
    {
        IList<Framework.DataServices.Model.EntityBaseData> LoadGrupos(string currentUser, Model.Campeonatos.Campeonato entry, out int errorNumber, out string errorDescription);
        bool InsertGrupo(string currentUser, Model.Campeonatos.Campeonato campeonato, Model.Campeonatos.Grupo grupo, out int errorNumber, out string errorDescription);
        bool DeleteGrupo(string currentUser, Model.Campeonatos.Campeonato campeonato, Model.Campeonatos.Grupo grupo, out int errorNumber, out string errorDescription);
        bool ClearGrupos(string currentUser, Model.Campeonatos.Campeonato campeonato, out int errorNumber, out string errorDescription);
        bool UpdateGrupo(string currentUser, Model.Campeonatos.Campeonato campeonato, Model.Campeonatos.Grupo grupo, out int errorNumber, out string errorDescription);

    }
}
