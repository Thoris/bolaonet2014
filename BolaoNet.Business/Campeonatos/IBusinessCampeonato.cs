using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Business.Campeonatos
{
    interface IBusinessCampeonato : IBusinessBase
    {
        bool InsertTime(Model.DadosBasicos.Time time);
        bool DeleteTime(Model.DadosBasicos.Time time);
        IList<Framework.DataServices.Model.EntityBaseData> LoadTimes();
        bool ClearTimes();
        

        bool InsertGrupo(Model.Campeonatos.Grupo grupo);
        bool DeleteGrupo(Model.Campeonatos.Grupo grupo);
        IList<Framework.DataServices.Model.EntityBaseData> LoadGrupos();
        bool ClearGrupos();
        bool UpdateGrupo(Model.Campeonatos.Grupo grupo);


        bool InsertFase(Model.Campeonatos.Fase grupo);
        bool DeleteFase(Model.Campeonatos.Fase grupo);
        IList<Framework.DataServices.Model.EntityBaseData> LoadFases();
        bool ClearFases();
        bool UpdateFase(Model.Campeonatos.Fase fase);


        IList<int> LoadRodadas();


        IList<Model.Campeonatos.CampeonatoClassificacao> LoadClassificacao(Model.Campeonatos.Fase fase, Model.Campeonatos.Grupo grupo);

        IList<Framework.DataServices.Model.EntityBaseData> LoadJogos(int rodada, Model.Campeonatos.Fase fase, Model.Campeonatos.Grupo grupo, DateTime dataInicial, DateTime dataFinal, string condition);



        bool LoadCampeonato(bool isClube, string file);


        IList<Framework.DataServices.Model.EntityBaseData> SelectPosicoes(Model.Campeonatos.Fase fase, Model.Campeonatos.Grupo grupo);




        bool LoadRecordPlacar(Dao.Campeonatos.RecordTipoPesquisa tipo,out IList<Model.Campeonatos.CampeonatoRecord> general,out IList<Model.Campeonatos.CampeonatoRecord> dentro,out IList<Model.Campeonatos.CampeonatoRecord> fora);
        bool LoadRecordJogosGols(Model.Campeonatos.Campeonato entry, Model.DadosBasicos.Time time, bool getRecord, out Model.Campeonatos.CampeonatoRecord general, out Model.Campeonatos.CampeonatoRecord dentro, out Model.Campeonatos.CampeonatoRecord fora);



        IList<Model.Campeonatos.Reports.GolsFrequencia> LoadGolsFrequencia(Model.Campeonatos.Campeonato campeonato);

        IList<Model.Campeonatos.Reports.TimeRodadas> LoadTimesRodadas(Model.Campeonatos.Fase fase, Model.Campeonatos.Grupo grupo, Model.DadosBasicos.Time time);


        IList<Framework.DataServices.Model.EntityBaseData> LoadHistorico(string condition);
        
        


    }
}
