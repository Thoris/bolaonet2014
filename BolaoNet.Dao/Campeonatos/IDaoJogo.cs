using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Dao.Campeonatos
{
    public interface IDaoJogo : IDaoBase
    {
        bool InsertResult(string currentUser, int gols1, int gols2, int penaltis1, int penaltis2, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription);
        bool RemoveResult(string currentUser, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription);
        IList<Framework.DataServices.Model.EntityBaseData> SelectAllByPeriod(string currentUser, int rodada, Model.Campeonatos.Campeonato campeonato, DateTime dataInicial, DateTime dataFinal, string time, string fase, string grupo, string condition, string order, out int errorNumber, out string errorDescription);
        IList<Framework.DataServices.Model.EntityBaseData> SelectJogosByTime(string currentUser, Model.Campeonatos.Campeonato campeonato, Model.DadosBasicos.Time time, string condition, string order, out int errorNumber, out string errorDescription);
        bool InsertWithAllData(string currentUser, bool isClube, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription);
        IList<Framework.DataServices.Model.EntityBaseData> SelectGoleadas(string currentUser, Model.Campeonatos.Campeonato campeonato, int maxGols, string condition, string order,  out int errorNumber, out string errorDescription);
        IList<Framework.DataServices.Model.EntityBaseData> LoadNextJogos(string currentUser, Model.Campeonatos.Campeonato campeonato, int totalJogos, out int errorNumber, out string errorDescription);
        IList<Framework.DataServices.Model.EntityBaseData> LoadFinishedJogos(string currentUser, Model.Campeonatos.Campeonato campeonato, int totalJogos, out int errorNumber, out string errorDescription);
        int NextJogo(string currentUser, Model.Campeonatos.Campeonato campeonato, out int errorNumber, out string errorDescription);
    
    }
}
