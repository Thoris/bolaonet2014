using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Business.Boloes
{
    public interface IBusinessJogoUsuario : IBusinessBase
    {
        IList<Framework.DataServices.Model.EntityBaseData> SelectAllByPeriod(Model.Boloes.Bolao bolao, string userName, int rodada, DateTime dataInicial, DateTime dataFinal, string time, string fase, string grupo, string condition);

        long SelectCountByPeriodo(Model.Boloes.Bolao bolao, string userName, int rodada, DateTime dataInicial, DateTime dataFinal, Model.Boloes.JogoUsuario.TypeAposta typeAposta, Model.Boloes.JogoUsuario.TypeAutomatico typeAutomatico, string condition);
        IList<Framework.DataServices.Model.EntityBaseData> LoadApostasByJogo(BolaoNet.Model.Boloes.Bolao bolao, BolaoNet.Model.Campeonatos.Jogo jogo, string condition);
        long LoadApostasCountByJogo(BolaoNet.Model.Boloes.Bolao bolao, BolaoNet.Model.Campeonatos.Jogo jogo, string condition);
        IList<Framework.DataServices.Model.EntityBaseData> InsertApostasAuto(Model.Boloes.Bolao bolao, string userName, Model.Boloes.JogoUsuario.TypeAposta typeAposta, Model.Boloes.JogoUsuario.TypeAutomatico typeAutomatico, DateTime dataInicial, DateTime dataFinal, int rodada, bool random, int time1, int time2, int randomInicial, int randomFinal, string nomeTime);
        IList<BolaoNet.Model.Campeonatos.CampeonatoClassificacao> LoadClassificacao(BolaoNet.Model.Boloes.Bolao bolao, BolaoNet.Model.Campeonatos.Fase fase, BolaoNet.Model.Campeonatos.Grupo grupo, Framework.Security.Model.UserData user);
        IList<Framework.DataServices.Model.EntityBaseData> LoadAcertosDificeis(Model.Boloes.Bolao bolao, int totalPessoas);
        IList<Framework.DataServices.Model.EntityBaseData> LoadSemAcertos(Model.Boloes.Bolao bolao);


        void CorrecaoEliminatorias(Model.Boloes.Bolao bolao, string userName);

        Model.Boloes.JogoUsuario LoadSocialNetwork(Model.Boloes.Bolao bolao, string userName, Model.Campeonatos.Jogo jogo);
        bool UpdateFacebook(Model.Boloes.Bolao bolao, string userName, Model.Campeonatos.Jogo jogo);


        IList<Framework.DataServices.Model.EntityBaseData> LoadProximasApostas(string userName);
        IList<Framework.DataServices.Model.EntityBaseData> LoadPontosObtidos(string userName);
    
    }
}
