using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Dao.Boloes
{
    public interface IDaoJogoUsuario : IDaoBase
    {
        IList<Framework.DataServices.Model.EntityBaseData> LoadApostas(string currentUser, int rodada, Model.Boloes.Bolao bolao, DateTime dataInicial, DateTime dataFinal, string userName, string time, string fase, string grupo, string condition, out int errorNumber, out string errorDescription);
        long LoadCount(string currentUser, int rodada, Model.Boloes.Bolao bolao, DateTime dataInicial, DateTime dataFinal, string userName, string condition, Model.Boloes.JogoUsuario.TypeAposta typeAposta, Model.Boloes.JogoUsuario.TypeAutomatico typeAutomatico, out int errorNumber, out string errorDescription);
        IList<Framework.DataServices.Model.EntityBaseData> LoadApostasByJogo(string currentUser, BolaoNet.Model.Boloes.Bolao bolao, BolaoNet.Model.Campeonatos.Jogo jogo, string condition, out int errorNumber, out string errorDescription);
        long LoadApostasCountByJogo(string currentUser, BolaoNet.Model.Boloes.Bolao bolao, BolaoNet.Model.Campeonatos.Jogo jogo, string condition, out int errorNumber, out string errorDescription);
        IList<Framework.DataServices.Model.EntityBaseData> InsertApostasAuto(string currentUser, Model.Boloes.Bolao bolao, string userName, Model.Boloes.JogoUsuario.TypeAposta typeAposta, Model.Boloes.JogoUsuario.TypeAutomatico typeAutomatico, DateTime dataInicial, DateTime dataFinal, int rodada, bool random, int time1, int time2, int randomInicial, int randomFinal, string nomeTime, out int errorNumber, out string errorDescription);
        IList<Model.Campeonatos.CampeonatoClassificacao> LoadClassificacao(string currentUser, Model.Boloes.Bolao bolao, Model.Campeonatos.Fase fase, Model.Campeonatos.Grupo grupo, Framework.Security.Model.UserData user, out int errorNumber, out string errorDescription);
        IList<Framework.DataServices.Model.EntityBaseData> LoadAcertosDificeis(string currentUser, Model.Boloes.Bolao bolao, int totalPessoas, out int errorNumber, out string errorDescription);
        IList<Framework.DataServices.Model.EntityBaseData> LoadSemAcertos(string currentUser, Model.Boloes.Bolao bolao, out int errorNumber, out string errorDescription);

        void CorrecaoEliminatorias(string currentUser, Model.Boloes.Bolao bolao, string userName,  out int errorNumber, out string errorDescription);

        IList<Model.Boloes.JogoUsuario> LoadSocialNetwork(string currentUser, Model.Boloes.Bolao bolao, string userName, Model.Campeonatos.Jogo jogo, out int errorNumber, out string errorDescription);
        bool UpdateFacebook(string currentUser, Model.Boloes.Bolao bolao, string userName, Model.Campeonatos.Jogo jogo, out int errorNumber, out string errorDescription);

        IList<Framework.DataServices.Model.EntityBaseData> LoadProximasApostas(string currentUser, string userName, out int errorNumber, out string errorDescription);
        IList<Framework.DataServices.Model.EntityBaseData> LoadPontosObtidos(string currentUser, string userName, out int errorNumber, out string errorDescription);


    }
}
