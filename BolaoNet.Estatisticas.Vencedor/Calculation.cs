using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace BolaoNet.Estatisticas.Vencedor
{
    public class Calculation
    {
        #region Constants

        private const int PosGols1 = 0;
        private const int PosGols2 = 1;
        private const int PosDesempate = 2;
        private const int PosStartName = 3;
        
        private const int PosLineStart = 4;

        #endregion

        #region Variables

        private int _golsTime1 = 0;
        private int _golsTime2 = 0;
        private int _ganhador = 0;
        
        private ExcelManagement excel = new ExcelManagement();
            
        #endregion

        #region Constructors/Destructors

        public Calculation(int golsTime1, int golsTime2, int ganhador)
        {
            _golsTime1 = golsTime1;
            _golsTime2 = golsTime2;
            _ganhador = ganhador;
        }

        #endregion

        #region Methods

        public void Run(string nomeBolao)
        {
            string currentUserName = "thoris";

            //Criando os dados do excel na memória
            excel.CreateWorksheet("Estatistica");
            

            //Criando as instâncias dos BO
            Business.Boloes.Support.Bolao bolao = new Business.Boloes.Support.Bolao(currentUserName, nomeBolao);
            Business.Campeonatos.Support.Jogo boJogo = new Business.Campeonatos.Support.Jogo(currentUserName);
            Business.Boloes.Support.JogoUsuario boJogosUsuarios = new Business.Boloes.Support.JogoUsuario(currentUserName);
            Business.Boloes.Support.ApostaExtraUsuario boApostaExtra = new Business.Boloes.Support.ApostaExtraUsuario(currentUserName);
            boApostaExtra.Bolao = bolao;
            
            
            //Carregando os dados principais do bolão
            bolao.Load();

            //Indicando qual campeonato é o jogo
            boJogo.Campeonato = bolao.Campeonato;
            boJogosUsuarios.Bolao = bolao;


            //Carregando a classificação
            IList<BolaoNet.Model.Boloes.BolaoMembros> membros =  bolao.LoadClassificacao(0);

            //Buscando o jogo de disputa de 3 e 4
            IList<Framework.DataServices.Model.EntityBaseData> jogosFound = boJogo.SelectAll("NomeFase = 'Final' AND PendenteTime1Ganhador = 0");

            //Identificando o jogo do 3 e 4 lugar
            Model.Campeonatos.Jogo jogoFimPerdedor = ( Model.Campeonatos.Jogo)jogosFound[0];

            //Buscando o 1 e 2 lugar
            jogosFound = boJogo.SelectAll("NomeFase = 'Final' AND PendenteTime1Ganhador = 1");

            //Atribuindo o 1 e 2 lugar
            Model.Campeonatos.Jogo jogoFimCampeao = (Model.Campeonatos.Jogo)jogosFound[0];

            //Buscando as apostas do usuário de disputa de 3 e 4 lugar
            IList<Framework.DataServices.Model.EntityBaseData> listJogos = boJogosUsuarios.LoadApostasByJogo(bolao, jogoFimPerdedor, null);

            //Buscando as apostas extras dos usuários
            IList<Framework.DataServices.Model.EntityBaseData> listApostasExtras = boApostaExtra.SelectAll (null);

            excel.SetValue(PosLineStart - 1, 0, "Gols Time 1");
            excel.SetValue(PosLineStart - 1, 1, "Gols Time 2");
            excel.SetValue(PosLineStart - 1, 2, "Desempate, 0 = Time 1");
                

            for (int c = 0; c < membros.Count; c++)
            {
                excel.SetValue(PosLineStart-1, PosStartName+(c*4), membros[c].UserName);
                excel.SetNumber(PosLineStart - 1, PosStartName + 1 + (c * 4), membros[c].TotalPontos);
                //excel.SetNumber(PosLineStart - 1, PosStartName + 2 + (c * 3), 0);
                
            }


            int currentLine = PosLineStart;
            ApplyLine(currentLine++, _golsTime1, _golsTime2, _ganhador, 3, 4, ref membros, listJogos, listApostasExtras,false);
            


            currentLine += 2;
            listJogos = boJogosUsuarios.LoadApostasByJogo(bolao, jogoFimCampeao, null);

            //Empate
            ApplyLine(currentLine++, 0, 0, 1, 1, 2, ref membros, listJogos, listApostasExtras,true);
            ApplyLine(currentLine++, 0, 0, 2, 1, 2, ref membros, listJogos, listApostasExtras,true);
            ApplyLine(currentLine++, 1, 1, 1, 1, 2, ref membros, listJogos, listApostasExtras,true);
            ApplyLine(currentLine++, 1, 1, 2, 1, 2, ref membros, listJogos, listApostasExtras,true);
            ApplyLine(currentLine++, 2, 2, 1, 1, 2, ref membros, listJogos, listApostasExtras,true);
            ApplyLine(currentLine++, 2, 2, 2, 1, 2, ref membros, listJogos, listApostasExtras,true);
            ApplyLine(currentLine++, 3, 3, 1, 1, 2, ref membros, listJogos, listApostasExtras,true);
            ApplyLine(currentLine++, 3, 3, 2, 1, 2, ref membros, listJogos, listApostasExtras,true);
            ApplyLine(currentLine++, 4, 4, 1, 1, 2, ref membros, listJogos, listApostasExtras, true);
            ApplyLine(currentLine++, 4, 4, 2, 1, 2, ref membros, listJogos, listApostasExtras, true);
            ApplyLine(currentLine++, 5, 5, 1, 1, 2, ref membros, listJogos, listApostasExtras, true);
            ApplyLine(currentLine++, 5, 5, 2, 1, 2, ref membros, listJogos, listApostasExtras, true);

            //Ganhador 2
            ApplyLine(currentLine++, 0, 1, 0, 1, 2, ref membros, listJogos, listApostasExtras,true);
            ApplyLine(currentLine++, 0, 2, 0, 1, 2, ref membros, listJogos, listApostasExtras,true);
            ApplyLine(currentLine++, 0, 3, 0, 1, 2, ref membros, listJogos, listApostasExtras,true);
            ApplyLine(currentLine++, 0, 4, 0, 1, 2, ref membros, listJogos, listApostasExtras,true);
            ApplyLine(currentLine++, 0, 5, 0, 1, 2, ref membros, listJogos, listApostasExtras,true);
            
            ApplyLine(currentLine++, 1, 2, 0, 1, 2, ref membros, listJogos, listApostasExtras,true);
            ApplyLine(currentLine++, 1, 3, 0, 1, 2, ref membros, listJogos, listApostasExtras,true);
            ApplyLine(currentLine++, 1, 4, 0, 1, 2, ref membros, listJogos, listApostasExtras,true);
            ApplyLine(currentLine++, 1, 5, 0, 1, 2, ref membros, listJogos, listApostasExtras,true);
            
            ApplyLine(currentLine++, 2, 3, 0, 1, 2, ref membros, listJogos, listApostasExtras,true);
            ApplyLine(currentLine++, 2, 4, 0, 1, 2, ref membros, listJogos, listApostasExtras,true);
            ApplyLine(currentLine++, 2, 5, 0, 1, 2, ref membros, listJogos, listApostasExtras,true);
            
            ApplyLine(currentLine++, 3, 4, 0, 1, 2, ref membros, listJogos, listApostasExtras,true);
            ApplyLine(currentLine++, 3, 5, 0, 1, 2, ref membros, listJogos, listApostasExtras,true);
            
            ApplyLine(currentLine++, 4, 5, 0, 1, 2, ref membros, listJogos, listApostasExtras,true);

            //Ganhador 1
            ApplyLine(currentLine++, 1, 0, 0, 1, 2, ref membros, listJogos, listApostasExtras,true);
            ApplyLine(currentLine++, 2, 0, 0, 1, 2, ref membros, listJogos, listApostasExtras,true);
            ApplyLine(currentLine++, 3, 0, 0, 1, 2, ref membros, listJogos, listApostasExtras,true);
            ApplyLine(currentLine++, 4, 0, 0, 1, 2, ref membros, listJogos, listApostasExtras,true);
            ApplyLine(currentLine++, 5, 0, 0, 1, 2, ref membros, listJogos, listApostasExtras,true);
            
            ApplyLine(currentLine++, 2, 1, 0, 1, 2, ref membros, listJogos, listApostasExtras,true);
            ApplyLine(currentLine++, 3, 1, 0, 1, 2, ref membros, listJogos, listApostasExtras,true);
            ApplyLine(currentLine++, 4, 1, 0, 1, 2, ref membros, listJogos, listApostasExtras,true);
            ApplyLine(currentLine++, 5, 1, 0, 1, 2, ref membros, listJogos, listApostasExtras,true);
            
            ApplyLine(currentLine++, 3, 2, 0, 1, 2, ref membros, listJogos, listApostasExtras,true);
            ApplyLine(currentLine++, 4, 2, 0, 1, 2, ref membros, listJogos, listApostasExtras,true);
            ApplyLine(currentLine++, 5, 2, 0, 1, 2, ref membros, listJogos, listApostasExtras,true);
            
            ApplyLine(currentLine++, 4, 3, 0, 1, 2, ref membros, listJogos, listApostasExtras,true);
            ApplyLine(currentLine++, 5, 3, 0, 1, 2, ref membros, listJogos, listApostasExtras,true);
            
            ApplyLine(currentLine++, 5, 4, 0, 1, 2, ref membros, listJogos, listApostasExtras,true);


            if (System.IO.File.Exists(".\\Excel.xls"))
                System.IO.File.Delete(".\\Excel.xls");

            excel.SaveFile(".\\Excel.xls");

        }

        private Model.Boloes.JogoUsuario SearchJogoUsuario(IList<Framework.DataServices.Model.EntityBaseData> jogosUsuarios, string usuario)
        {
            foreach (Model.Boloes.JogoUsuario jogo in jogosUsuarios)
            {
                if (string.Compare(usuario, jogo.UserName, true) == 0)
                {
                    return jogo;
                }
            }
            return null;
        }
        private Model.Boloes.ApostaExtraUsuario SearchApostaExtra(IList<Framework.DataServices.Model.EntityBaseData> apostasUsuarios, string usuario, int pos)
        {
            foreach (Model.Boloes.ApostaExtraUsuario aposta in apostasUsuarios)
            {
                if (string.Compare(usuario, aposta.UserName, true) == 0 && aposta.Posicao == pos)
                {
                    return aposta;
                }
            }
            return null;
        }

        private void ApplyLine(int line, int gols1, int gols2, int desempate, int posTime1, int posTime2, ref IList<BolaoNet.Model.Boloes.BolaoMembros> membros, 
            IList<Framework.DataServices.Model.EntityBaseData> jogosUsuarios, IList<Framework.DataServices.Model.EntityBaseData> apostasExtras, bool somaJogo)
        {
            
            int[] pt = new int[membros.Count];
            


            for (int c = 0; c < membros.Count; c++)
            {
                int totalPontos = 0;
                int pontosExtras = 0;
                int multiplo = 1;
                string nomeTime1 = "";
                string nomeTime2 = "";
                int total = membros[c].TotalPontos;
                
                Model.Boloes.JogoUsuario jogo = SearchJogoUsuario(jogosUsuarios, membros[c].UserName);
                Model.Boloes.ApostaExtraUsuario aposta1 = SearchApostaExtra(apostasExtras, membros[c].UserName, posTime1);
                Model.Boloes.ApostaExtraUsuario aposta2 = SearchApostaExtra(apostasExtras, membros[c].UserName, posTime2);


                if (string.Compare(jogo.Time1Classificado.Nome, "Brasil", true) == 0 || string.Compare(jogo.Time2Classificado.Nome, "Brasil", true) == 0)
                {
                    multiplo = 2;
                }

                //Verificando o vencedor válido
                if (gols1 == gols2)
                {
                    if (desempate == 1)
                    {
                        nomeTime1 = jogo.Time1Classificado.Nome;
                        nomeTime2 = jogo.Time2Classificado.Nome;
                    }
                    else
                    {
                        nomeTime1 = jogo.Time2Classificado.Nome;
                        nomeTime2 = jogo.Time1Classificado.Nome;
                    }

                }
                else if (gols1 > gols2)
                {
                    nomeTime1 = jogo.Time1Classificado.Nome;
                    nomeTime2 = jogo.Time2Classificado.Nome;
                }
                else if (gols1 < gols2)
                {
                    nomeTime1 = jogo.Time2Classificado.Nome;
                    nomeTime2 = jogo.Time1Classificado.Nome;
                }

                //Verificando o vencedor da aposta do usuário
                if (string.Compare(aposta1.NomeTime, nomeTime1, true) == 0)
                {
                    pontosExtras += 10;
                }
                if (string.Compare(aposta2.NomeTime, nomeTime2, true) == 0)
                {
                    pontosExtras += 10;
                }
                



                if (jogo.ApostaTime1 == gols1 && jogo.ApostaTime2 == gols2)
                {
                    totalPontos += 10;
                    
                }
                else
                {
                    if (gols1 == jogo.ApostaTime1 || gols2 == jogo.ApostaTime2)
                    {
                        totalPontos += 1;
                    }


                    if (gols1 > gols2 && jogo.ApostaTime1 > jogo.ApostaTime2)
                    {
                        totalPontos += 3;
                    }
                    else if (gols1 < gols2 && jogo.ApostaTime1 < jogo.ApostaTime2)
                    {
                        totalPontos += 3;
                    }
                    else if (gols1 == gols2 && jogo.ApostaTime1 == jogo.ApostaTime2)
                    {
                        totalPontos += 5;
                    }
                }

                if (somaJogo)
                    total += (totalPontos * multiplo) + pontosExtras;
                else
                    total += pontosExtras;

                if (pontosExtras > 0 && !somaJogo)
                {
                    membros[c].TotalPontos += pontosExtras;
                }

                excel.SetNumber(line, PosGols1, gols1);
                excel.SetNumber(line, PosGols2, gols2);
                excel.SetNumber(line, PosDesempate, desempate);


                excel.SetNumber(line, PosStartName + 1 + (c * 4), total);

                //if (somaJogo)                
                //    excel.SetNumber(line, PosStartName + 2 + (c * 4), (totalPontos * multiplo) + pontosExtras);
                //else
                //    excel.SetNumber(line, PosStartName + 2 + (c * 4), pontosExtras);

                excel.SetNumber(line, PosStartName + 2 + (c * 4), (totalPontos * multiplo));
                excel.SetNumber(line, PosStartName + 3 + (c * 4), pontosExtras);
                



                pt[c] = total;
            }

            int currentMax ;
            int posMax = -1;
            int currentPosition = 1;
            int countPosition = 1;

            do
            {
                posMax = -1;
                currentMax = 0;

                currentPosition = countPosition;

                for (int c = 0; c < pt.Length; c++)
                {
                    if (pt[c] > currentMax)
                    {
                        currentMax = pt[c];
                        posMax = c;
                    }
                }
                if (posMax != -1)
                {
                    for (int c = 0; c < pt.Length; c++)
                    {
                        if (currentMax == pt[c])
                        {
                            excel.SetNumber(line, PosStartName + (c * 4), currentPosition);
                            countPosition++;
                
                            pt[c] = 0;

                        }
                    }
                
                }


            } while (posMax != -1);
        }

        private void SetValue(string nomeBolao, int line, string userName, int pontosAtuais)
        {
            Business.Boloes.Support.Bolao business = new Business.Boloes.Support.Bolao("thoris", nomeBolao);


        }

        #endregion
    }
}
