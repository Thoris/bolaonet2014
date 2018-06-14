using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Dao.Campeonatos
{
    public interface IDaoCampeonato : IDaoBase, IDaoCampeonatoReports, IDaoCampeonatoFase, IDaoCampeonatoGrupo, IDaoCampeonatoTimes, IDaoCampeonatoPosicoes, IDaoCampeonatoRecordTime, IDaoCampeonatoHistorico
    {
        //#region Times

        //IList<Framework.DataServices.Model.EntityBaseData> LoadTimes(string currentUser, Model.Campeonatos.Campeonato entry, out int errorNumber, out string errorDescription);
        //bool InsertTime(string currentUser, Model.Campeonatos.Campeonato campeonato, Model.DadosBasicos.Time time, out int errorNumber, out string errorDescription);
        //bool DeleteTime(string currentUser, Model.Campeonatos.Campeonato campeonato, Model.DadosBasicos.Time time, out int errorNumber, out string errorDescription);
        //bool ClearTimes(string currentUser, Model.Campeonatos.Campeonato campeonato, out int errorNumber, out string errorDescription);

        //#endregion

        //#region Grupos

        //IList<Framework.DataServices.Model.EntityBaseData> LoadGrupos(string currentUser, Model.Campeonatos.Campeonato entry, out int errorNumber, out string errorDescription);
        //bool InsertGrupo(string currentUser, Model.Campeonatos.Campeonato campeonato, Model.Campeonatos.Grupo grupo, out int errorNumber, out string errorDescription);
        //bool DeleteGrupo(string currentUser, Model.Campeonatos.Campeonato campeonato, Model.Campeonatos.Grupo grupo, out int errorNumber, out string errorDescription);
        //bool ClearGrupos(string currentUser, Model.Campeonatos.Campeonato campeonato, out int errorNumber, out string errorDescription);
        //bool UpdateGrupo(string currentUser, Model.Campeonatos.Campeonato campeonato, Model.Campeonatos.Grupo grupo, out int errorNumber, out string errorDescription);

        //#endregion

        //#region Fases

        //IList<Framework.DataServices.Model.EntityBaseData> LoadFases(string currentUser, Model.Campeonatos.Campeonato entry, out int errorNumber, out string errorDescription);
        //bool InsertFase(string currentUser, Model.Campeonatos.Campeonato campeonato, Model.Campeonatos.Fase fase, out int errorNumber, out string errorDescription);
        //bool DeleteFase(string currentUser, Model.Campeonatos.Campeonato campeonato, Model.Campeonatos.Fase fase, out int errorNumber, out string errorDescription);
        //bool ClearFases(string currentUser, Model.Campeonatos.Campeonato campeonato, out int errorNumber, out string errorDescription);
        //bool UpdateFase(string currentUser, Model.Campeonatos.Campeonato campeonato, Model.Campeonatos.Fase fase, out int errorNumber, out string errorDescription);

        //#endregion

        #region Jogos

        IList<int> LoadRodadas(string currentUser, Model.Campeonatos.Campeonato campeonato, out int errorNumber, out string errorDescription);
        IList<Framework.DataServices.Model.EntityBaseData> LoadJogos(string currentUser, int rodada, Model.Campeonatos.Fase fase, Model.Campeonatos.Grupo grupo, Model.Campeonatos.Campeonato campeonato, DateTime dataInicial, DateTime dataFinal, string condition, out int errorNumber, out string errorDescription);

        #endregion

        #region Classificacao

        IList<Model.Campeonatos.CampeonatoClassificacao> LoadClassificacao(string currentUser, Model.Campeonatos.Campeonato campeonato, Model.Campeonatos.Fase fase, Model.Campeonatos.Grupo grupo, out int errorNumber, out string errorDescription);


        #endregion

        #region Posicoes

        #endregion
    }
}
