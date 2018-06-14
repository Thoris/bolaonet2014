using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Dao.Campeonatos
{
    public interface IDaoCampeonatoReports
    {
        IList<Model.Campeonatos.Reports.GolsFrequencia> LoadGolsFrequencia(string currentUser, Model.Campeonatos.Campeonato campeonato, out int errorNumber, out string errorDescription);

        IList<Model.Campeonatos.Reports.TimeRodadas> LoadTimesRodadas(string currentUser, Model.Campeonatos.Campeonato campeonato, Model.Campeonatos.Fase fase, Model.Campeonatos.Grupo grupo, Model.DadosBasicos.Time time, out int errorNumber, out string errorDescription);



    }
}
