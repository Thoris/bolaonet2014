using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Business.Boloes
{
    public interface IBusinessBolao : IBusinessBase
    {
        IList<Model.Boloes.BolaoMembros> LoadClassificacao(int rodada);




        IList<Framework.DataServices.Model.EntityBaseData> SelectAllEnabled(string condition);


        IList<Framework.DataServices.Model.EntityBaseData> LoadBoloes(Framework.Security.Model.UserData usuario);
        IList<Framework.DataServices.Model.EntityBaseData> LoadMembros();
        bool InsertMembro(Framework.Security.Model.UserData usuario);
        bool DeleteMembro(Framework.Security.Model.UserData usuario);
        bool ClearMembros();

        IList<Framework.DataServices.Model.EntityBaseData> LoadApostasRestantes();


        IList<Framework.DataServices.Model.EntityBaseData> SelectPremios();


        bool BolaoParticipar(Model.Boloes.BolaoRequest request);
        bool BolaoChangeStatus(Model.Boloes.BolaoRequest request);
        bool BolaoAceitar(Model.Boloes.BolaoRequest request);

        IList<Framework.DataServices.Model.EntityBaseData> SelectRequestsAll(string condition);
        IList<Framework.DataServices.Model.EntityBaseData> SelectRequestsAllByBolao(string condition);
        IList<Framework.DataServices.Model.EntityBaseData> SelectRequestsPendentesByBolao(string condition);


        bool IsUserInBolao(Framework.Security.Model.UserData usuario);






        IList<Framework.DataServices.Model.EntityBaseData> LoadCriteriosPontos(string condition);
        bool UpdateCriterioPontos(Model.Boloes.BolaoCriterioPontos entry);

        IList<Framework.DataServices.Model.EntityBaseData> LoadCriteriosPontosTimes(string condition);
        bool UpdateCriterioPontosTimes(Model.Boloes.BolaoCriterioPontosTimes entry);


        bool Iniciar();
        bool Aguardar();


        IList<Framework.DataServices.Model.EntityBaseData> SelectPontuacao();

        IList<Model.Boloes.Reports.UserPontosData> LoadAllPontosDataByUser(Framework.Security.Model.UserData usuario);

        IList<Model.Boloes.Reports.UserClassificacaoRodada> LoadHistoricoClassificacao();


        IList<Model.Boloes.BolaoMembros> LoadClassificacaoGrupo(Framework.Security.Model.UserData usuario);
        bool InsertGrupoMembro(Framework.Security.Model.UserData usuario, Model.Boloes.BolaoMembros usuarioSelecionado);
        bool DeleteGrupoMembro(Framework.Security.Model.UserData usuario, Model.Boloes.BolaoMembros usuarioSelecionado);
        

    }
}
