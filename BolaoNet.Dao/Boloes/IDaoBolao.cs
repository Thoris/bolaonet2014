using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Dao.Boloes
{
    public interface IDaoBolao : IDaoBase, IDaoBolaoPremio, IDaoBolaoRequests, IDaoBolaoCriteriosPontos, IDaoBolaoCriteriosPontosTimes, IDaoBoloesPontuacao
    {
        //IList<Framework.DataServices.Model.EntityBaseData> SelectAllByCampeonato(string currentUser, Model.Campeonatos.Campeonato campeonato, out int errorNumber, out string errorDescription);

        IList<Framework.DataServices.Model.EntityBaseData> SelectAllEnabled(string currentUser, string condition, out int errorNumber, out string errorDescription);

        bool Iniciar(string currentUser, string iniciadoBy, Model.Boloes.Bolao bolao, out int errorNumber, out string errorDescription);
        bool Aguardar(string currentUser, Model.Boloes.Bolao bolao, out int errorNumber, out string errorDescription);

        #region Membros


        IList<Framework.DataServices.Model.EntityBaseData> LoadBoloes(string currentUser, Framework.Security.Model.UserData usuario, out int errorNumber, out string errorDescription);
        IList<Framework.DataServices.Model.EntityBaseData> LoadMembros(string currentUser, Model.Boloes.Bolao bolao, out int errorNumber, out string errorDescription);
        bool InsertMembro(string currentUser, Model.Boloes.Bolao bolao, Framework.Security.Model.UserData usuario, out int errorNumber, out string errorDescription);
        bool DeleteMembro(string currentUser, Model.Boloes.Bolao bolao, Framework.Security.Model.UserData usuario, out int errorNumber, out string errorDescription);
        bool ClearMembros(string currentUser, Model.Boloes.Bolao bolao, out int errorNumber, out string errorDescription);

        IList<Framework.DataServices.Model.EntityBaseData> LoadApostasRestantes(string currentUser, Model.Boloes.Bolao bolao, out int errorNumber, out string errorDescription);


        #endregion

        #region Users
        IList<Model.Boloes.BolaoMembros> LoadClassificacao(string currentUser, Model.Boloes.Bolao bolao, out int errorNumber, out string errorDescription);
        IList<Model.Boloes.BolaoMembros> LoadClassificacaoRodada(string currentUser, Model.Boloes.Bolao bolao, Model.Campeonatos.Fase fase, out int errorNumber, out string errorDescription);


        bool IsUserInBolao(string currentUser, Framework.Security.Model.UserData usuario, Model.Boloes.Bolao bolao, out int errorNumber, out string errorDescription);
        IList<Model.Boloes.Reports.UserPontosData> LoadAllPontosDataByUser(string currentUser, Model.Boloes.Bolao bolao, Framework.Security.Model.UserData usuario, out int errorNumber, out string errorDescription);
        IList<Model.Boloes.Reports.UserClassificacaoRodada> LoadHistoricoClassificacao(string currentUser, Model.Boloes.Bolao bolao, out int errorNumber, out string errorDescription);


        IList<Model.Boloes.BolaoMembros> LoadClassificacaoGrupo(string currentUser, Model.Boloes.Bolao bolao, Framework.Security.Model.UserData usuario, out int errorNumber, out string errorDescription);
        bool InsertGrupoMembro(string currentUser, Model.Boloes.Bolao bolao, Framework.Security.Model.UserData usuario, Model.Boloes.BolaoMembros usuarioSelecionado, out int errorNumber, out string errorDescription);
        bool DeleteGrupoMembro(string currentUser, Model.Boloes.Bolao bolao, Framework.Security.Model.UserData usuario, Model.Boloes.BolaoMembros usuarioSelecionado, out int errorNumber, out string errorDescription);
        
        #endregion



    }
}
