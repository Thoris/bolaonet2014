using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Business.Campeonatos
{
    public interface IBusinessJogo : IBusinessBase
    {
        bool InsertResult(int gols1, int gols2, int penaltis1, int penaltis2);
        bool RemoveResult();
        IList<Framework.DataServices.Model.EntityBaseData> SelectAllByPeriod(Model.Campeonatos.Campeonato campeonato, int rodada, DateTime dataInicial, DateTime dataFinal, string time, string fase, string grupo, string condition, string order);
        bool InsertWithAllData(bool isClube, Framework.DataServices.Model.EntityBaseData entry);
        IList<Framework.DataServices.Model.EntityBaseData> SelectGoleadas(Model.Campeonatos.Campeonato campeonato, int maxGols, string condition, string order);



        IList<Framework.DataServices.Model.EntityBaseData> LoadNextJogos(Model.Campeonatos.Campeonato campeonato, int totalJogos);
        IList<Framework.DataServices.Model.EntityBaseData> LoadFinishedJogos(Model.Campeonatos.Campeonato campeonato, int totalJogos);

        int NextJogo(Model.Campeonatos.Campeonato campeonato);

    }
}
