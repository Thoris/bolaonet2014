using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Configuration;

namespace BolaoNet.Business.Excel
{
    public class TemplateExcelBase : ExcelBase, ITemplateExcelBase
    {

        #region Variables
        protected string _currentLogin;
        protected Dao.Excel.ITemplateExcelBase _daoTemplate;
        #endregion

        #region Constructors/Destructors
        public TemplateExcelBase(string currentLogin, string file)
            : base (file)
        {
            _currentLogin = currentLogin;
            _daoTemplate = new Dao.Excel.TemplateExcelBase();
        }
        #endregion

        #region Methods
        public Model.Boloes.JogoUsuario SetValue(Model.Campeonatos.Jogo jogo, Model.Boloes.JogoUsuario Apostas)
        {
            Model.Boloes.JogoUsuario entry = new BolaoNet.Model.Boloes.JogoUsuario();
            entry.Copy(jogo);
            entry.ApostaTime1 = Apostas.ApostaTime1;
            entry.ApostaTime2 = Apostas.ApostaTime2;


            entry.Time1 = Apostas.Time1;
            entry.Time2 = Apostas.Time2;

            return entry;
        }
        #endregion


        #region ITemplateExcelBase Members

        public bool SaveUserFile(Model.Boloes.Bolao bolao, Model.Campeonatos.Campeonato campeonato, Framework.Security.Model.UserData user)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");

            if (campeonato == null)
                throw new ArgumentException("campeonato");

            if (user == null)
                throw new ArgumentException("user");

            #region Buscando os jogos cadastrados do bolão
            //Loading jogos stored
            Business.Campeonatos.Support.Campeonato businessCampeonato = 
                new Business.Campeonatos.Support.Campeonato(_currentLogin, campeonato);

            IList<Framework.DataServices.Model.EntityBaseData> listJogos = 
                businessCampeonato.LoadJogos(0, null, null, DateTime.MinValue, DateTime.MinValue, null);


            if (listJogos.Count != 64)
                throw new Exception("Não existem a quantidade determinada de jogos cadastradas no banco");
            #endregion

            #region Buscando os dados do arquivo Excel
            //Loading jogos from Excel file
            List<Model.Boloes.JogoUsuario> jogosUsuario = new List<BolaoNet.Model.Boloes.JogoUsuario>();
            jogosUsuario = _daoTemplate.LoadJogosUsuario(_dao.CreateConnection(_file));

            if (jogosUsuario.Count != 64)
                throw new Exception("Não existem a quantidade de apostas cadastradas no excel.");



            List<Model.Boloes.JogoUsuario> result = new List<BolaoNet.Model.Boloes.JogoUsuario>();


            //Setting apostas dos usuários into jogos
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[0], jogosUsuario[0]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[1], jogosUsuario[1]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[2], jogosUsuario[7]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[3], jogosUsuario[6]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[4], jogosUsuario[12]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[5], jogosUsuario[13]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[6], jogosUsuario[19]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[7], jogosUsuario[18]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[8], jogosUsuario[24]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[9], jogosUsuario[25]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[10], jogosUsuario[30]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[11], jogosUsuario[31]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[12], jogosUsuario[36]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[13], jogosUsuario[37]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[14], jogosUsuario[42]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[15], jogosUsuario[43]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[16], jogosUsuario[2]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[17], jogosUsuario[9]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[18], jogosUsuario[8]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[19], jogosUsuario[3]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[20], jogosUsuario[20]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[21], jogosUsuario[14]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[22], jogosUsuario[15]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[23], jogosUsuario[26]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[24], jogosUsuario[21]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[25], jogosUsuario[27]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[26], jogosUsuario[32]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[27], jogosUsuario[33]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[28], jogosUsuario[38]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[29], jogosUsuario[39]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[30], jogosUsuario[44]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[31], jogosUsuario[45]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[32], jogosUsuario[4]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[33], jogosUsuario[5]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[34], jogosUsuario[10]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[35], jogosUsuario[11]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[36], jogosUsuario[16]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[37], jogosUsuario[17]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[38], jogosUsuario[22]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[39], jogosUsuario[23]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[40], jogosUsuario[34]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[41], jogosUsuario[35]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[42], jogosUsuario[28]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[43], jogosUsuario[29]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[44], jogosUsuario[40]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[45], jogosUsuario[41]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[46], jogosUsuario[46]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[47], jogosUsuario[47]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[48], jogosUsuario[48]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[49], jogosUsuario[49]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[50], jogosUsuario[51]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[51], jogosUsuario[50]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[52], jogosUsuario[52]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[53], jogosUsuario[53]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[54], jogosUsuario[54]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[55], jogosUsuario[55]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[56], jogosUsuario[57]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[57], jogosUsuario[56]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[58], jogosUsuario[58]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[59], jogosUsuario[59]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[60], jogosUsuario[60]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[61], jogosUsuario[61]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[62], jogosUsuario[62]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[63], jogosUsuario[63]));
            #endregion

            #region Criando o usuário
            Framework.Security.Business.UserDataService userBusiness = new Framework.Security.Business.UserDataService(_currentLogin, user);            
            System.Web.Security.MembershipCreateStatus status = userBusiness.CreateUser();

            switch (status)
            {
                case MembershipCreateStatus.DuplicateEmail:
                    throw new Exception ("O email especificado já existe cadastrado para um usuário, por favor, entre com outro email.");
                case MembershipCreateStatus.DuplicateProviderUserKey:
                    throw new Exception("O usuário já existe no banco de dados, por favor, entre com outro.");
                case MembershipCreateStatus.DuplicateUserName:
                    throw new Exception("O login do usuário já existe no banco de dados, por favor, entre com outro login.");
                case MembershipCreateStatus.InvalidAnswer:
                    throw new Exception("Resposta inválida, por favor entre com uma resposta que atenda aos requisitos de segurança.");
                case MembershipCreateStatus.InvalidEmail:
                    throw new Exception("Formato de email incorreto.");
                case MembershipCreateStatus.InvalidPassword:
                    throw new Exception("Senha inválida, por favor entre com uma senha que atenda aos requisitos de segurança.");
                case MembershipCreateStatus.InvalidProviderUserKey:
                    throw new Exception("Chave do usuário inválida.");
                case MembershipCreateStatus.InvalidQuestion:
                    throw new Exception("Pergunta inválida, por favor entre com uma pergunta que atenda aos requisitos de segurança.");
                case MembershipCreateStatus.InvalidUserName:
                    throw new Exception("Usuário inválido.");
                case MembershipCreateStatus.ProviderError:
                    throw new Exception("Erro de provider.");
                case MembershipCreateStatus.UserRejected:
                    throw new Exception("Usuário rejeitado.");
                case MembershipCreateStatus.Success:
                    break;
            }

            if (!userBusiness.UpdateUser())
                throw new Exception("Erro ao atualizar o usuário.");


            #endregion

            Business.Boloes.Support.Bolao bolaoBusiness = new BolaoNet.Business.Boloes.Support.Bolao(_currentLogin, bolao.Nome);


            #region Adicionando as Roles para o usuário
            string rolesToAdd = ConfigurationManager.AppSettings["RolesToAddAtConfirmation"];

            if (rolesToAdd != null)
            {
                string[] roles = rolesToAdd.Split(new char[] { '|' });

                System.Web.Security.Roles.AddUserToRoles(user.UserName, roles);
            }
            #endregion


            #region Adicionando o usuário no bolão determinado

            bool insertedMember = bolaoBusiness.InsertMembro(user);

            if (!insertedMember)
                throw new Exception("Não foi possível inserir o usuário no bolão " + bolao.Nome);

            #endregion


            #region Inserindo jogos do usuário

            foreach (Model.Boloes.JogoUsuario jogoUsuario in result)
            {
                Business.Boloes.Support.JogoUsuario apostaUsuario = new BolaoNet.Business.Boloes.Support.JogoUsuario(_currentLogin, jogoUsuario);
                apostaUsuario.UserName = user.UserName;
                apostaUsuario.Bolao = bolao;
                apostaUsuario.Time1 = jogoUsuario.Time1;
                apostaUsuario.Time2 = jogoUsuario.Time2;
                apostaUsuario.Insert();
            }


            #endregion


            #region Inserindo apostas extras

            string[] extras = new string[4];

            //Primeiro Lugar           
            if (result[63].ApostaTime1 > result[63].ApostaTime2)
            {
                extras[0] = result[63].Time1.Nome;
                extras[1] = result[63].Time2.Nome;
            }
            else
            {
                extras[0] = result[63].Time2.Nome;
                extras[1] = result[63].Time1.Nome;
            }

            //Terceiro Lugar
            if (result[62].ApostaTime1 > result[62].ApostaTime2)
            {
                extras[2] = result[62].Time1.Nome;
                extras[3] = result[62].Time2.Nome;
            }
            else
            {
                extras[2] = result[62].Time2.Nome;
                extras[3] = result[62].Time1.Nome;
            }

            for (int c = 0; c < 4; c++)
            {
                if (string.Compare(extras[c], "Suiça") == 0)
                {
                    extras[c] = "Suíça";
                }
            }


            //Primeiro lugar
            Business.Boloes.Support.ApostaExtraUsuario businessExtra = 
                new BolaoNet.Business.Boloes.Support.ApostaExtraUsuario(_currentLogin, 1, bolao.Nome, user.UserName);
            businessExtra.NomeTime = extras[0];
            businessExtra.Insert();

            //Segundo Lugar
            businessExtra =  new BolaoNet.Business.Boloes.Support.ApostaExtraUsuario(_currentLogin, 2, bolao.Nome, user.UserName);
            businessExtra.NomeTime = extras[1];
            businessExtra.Insert();

            //Terceiro Lugar
            businessExtra = new BolaoNet.Business.Boloes.Support.ApostaExtraUsuario(_currentLogin, 3, bolao.Nome, user.UserName);
            businessExtra.NomeTime = extras[2];
            businessExtra.Insert();

            //Quarto Lugar
            businessExtra = new BolaoNet.Business.Boloes.Support.ApostaExtraUsuario(_currentLogin, 4, bolao.Nome, user.UserName);
            businessExtra.NomeTime = extras[3];
            businessExtra.Insert();

            #endregion





            return true;
        }
        public bool SaveExisitingUserFile(BolaoNet.Model.Boloes.Bolao bolao, BolaoNet.Model.Campeonatos.Campeonato campeonato, Framework.Security.Model.UserData user)
        {


            if (bolao == null)
                throw new ArgumentException("bolao");

            if (campeonato == null)
                throw new ArgumentException("campeonato");

            if (user == null)
                throw new ArgumentException("user");




            #region Buscando os jogos cadastrados do bolão
            //Loading jogos stored
            Business.Campeonatos.Support.Campeonato businessCampeonato =
                new Business.Campeonatos.Support.Campeonato(_currentLogin, campeonato);

            IList<Framework.DataServices.Model.EntityBaseData> listJogos =
                businessCampeonato.LoadJogos(0, null, null, DateTime.MinValue, DateTime.MinValue, null);


            if (listJogos.Count != 64)
                throw new Exception("Não existem a quantidade determinada de jogos cadastradas no banco");
            #endregion

            #region Buscando os dados do arquivo Excel
            //Loading jogos from Excel file
            List<Model.Boloes.JogoUsuario> jogosUsuario = new List<BolaoNet.Model.Boloes.JogoUsuario>();
            jogosUsuario = _daoTemplate.LoadJogosUsuario(_dao.CreateConnection(_file));

            if (jogosUsuario.Count != 64)
                throw new Exception("Não existem a quantidade de apostas cadastradas no excel.");



            List<Model.Boloes.JogoUsuario> result = new List<BolaoNet.Model.Boloes.JogoUsuario>();


            //Setting apostas dos usuários into jogos
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[0], jogosUsuario[0]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[1], jogosUsuario[1]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[2], jogosUsuario[7]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[3], jogosUsuario[6]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[4], jogosUsuario[12]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[5], jogosUsuario[13]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[6], jogosUsuario[19]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[7], jogosUsuario[18]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[8], jogosUsuario[24]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[9], jogosUsuario[25]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[10], jogosUsuario[30]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[11], jogosUsuario[31]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[12], jogosUsuario[36]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[13], jogosUsuario[37]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[14], jogosUsuario[42]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[15], jogosUsuario[43]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[16], jogosUsuario[2]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[17], jogosUsuario[9]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[18], jogosUsuario[8]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[19], jogosUsuario[3]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[20], jogosUsuario[20]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[21], jogosUsuario[14]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[22], jogosUsuario[15]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[23], jogosUsuario[26]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[24], jogosUsuario[21]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[25], jogosUsuario[27]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[26], jogosUsuario[32]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[27], jogosUsuario[33]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[28], jogosUsuario[38]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[29], jogosUsuario[39]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[30], jogosUsuario[44]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[31], jogosUsuario[45]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[32], jogosUsuario[4]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[33], jogosUsuario[5]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[34], jogosUsuario[10]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[35], jogosUsuario[11]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[36], jogosUsuario[16]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[37], jogosUsuario[17]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[38], jogosUsuario[22]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[39], jogosUsuario[23]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[40], jogosUsuario[34]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[41], jogosUsuario[35]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[42], jogosUsuario[28]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[43], jogosUsuario[29]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[44], jogosUsuario[40]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[45], jogosUsuario[41]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[46], jogosUsuario[46]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[47], jogosUsuario[47]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[48], jogosUsuario[48]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[49], jogosUsuario[49]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[50], jogosUsuario[51]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[51], jogosUsuario[50]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[52], jogosUsuario[52]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[53], jogosUsuario[53]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[54], jogosUsuario[54]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[55], jogosUsuario[55]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[56], jogosUsuario[57]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[57], jogosUsuario[56]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[58], jogosUsuario[58]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[59], jogosUsuario[59]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[60], jogosUsuario[60]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[61], jogosUsuario[61]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[62], jogosUsuario[62]));
            result.Add(SetValue((Model.Campeonatos.Jogo)listJogos[63], jogosUsuario[63]));
            #endregion





            #region Inserindo jogos do usuário

            foreach (Model.Boloes.JogoUsuario jogoUsuario in result)
            {
                Business.Boloes.Support.JogoUsuario apostaUsuario = new BolaoNet.Business.Boloes.Support.JogoUsuario(_currentLogin, jogoUsuario);
                apostaUsuario.UserName = user.UserName;
                apostaUsuario.Bolao = bolao;
                apostaUsuario.Time1 = jogoUsuario.Time1;
                apostaUsuario.Time2 = jogoUsuario.Time2;
                apostaUsuario.Insert();
            }


            #endregion


            #region Inserindo apostas extras

            string[] extras = new string[4];

            //Primeiro Lugar           
            if (result[63].ApostaTime1 > result[63].ApostaTime2)
            {
                extras[0] = result[63].Time1.Nome;
                extras[1] = result[63].Time2.Nome;
            }
            else
            {
                extras[0] = result[63].Time2.Nome;
                extras[1] = result[63].Time1.Nome;
            }

            //Terceiro Lugar
            if (result[62].ApostaTime1 > result[62].ApostaTime2)
            {
                extras[2] = result[62].Time1.Nome;
                extras[3] = result[62].Time2.Nome;
            }
            else
            {
                extras[2] = result[62].Time2.Nome;
                extras[3] = result[62].Time1.Nome;
            }

            for (int c = 0; c < 4; c++)
            {
                if (string.Compare(extras[c], "Suiça") == 0)
                {
                    extras[c] = "Suíça";
                }
            }


            //Primeiro lugar
            Business.Boloes.Support.ApostaExtraUsuario businessExtra =
                new BolaoNet.Business.Boloes.Support.ApostaExtraUsuario(_currentLogin, 1, bolao.Nome, user.UserName);
            businessExtra.NomeTime = extras[0];
            businessExtra.Insert();

            //Segundo Lugar
            businessExtra = new BolaoNet.Business.Boloes.Support.ApostaExtraUsuario(_currentLogin, 2, bolao.Nome, user.UserName);
            businessExtra.NomeTime = extras[1];
            businessExtra.Insert();

            //Terceiro Lugar
            businessExtra = new BolaoNet.Business.Boloes.Support.ApostaExtraUsuario(_currentLogin, 3, bolao.Nome, user.UserName);
            businessExtra.NomeTime = extras[2];
            businessExtra.Insert();

            //Quarto Lugar
            businessExtra = new BolaoNet.Business.Boloes.Support.ApostaExtraUsuario(_currentLogin, 4, bolao.Nome, user.UserName);
            businessExtra.NomeTime = extras[3];
            businessExtra.Insert();

            #endregion


           


            return true;
        }

        #endregion
    }
}
