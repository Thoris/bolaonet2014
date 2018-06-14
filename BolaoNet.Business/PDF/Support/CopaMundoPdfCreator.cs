using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;

namespace BolaoNet.Business.PDF.Support
{
    public class CopaMundoPdfCreator : PdfCreator
    {
        #region Variables
        private string _currentLogin = null;
        private Business.Boloes.IBusinessJogoUsuario _businessJogoUsuario;
        private Business.Boloes.IBusinessApostaExtraUsuario _businessApostaExtra;
        private Business.Campeonatos.IBusinessJogo _businessJogo;
        private Business.Boloes.IBusinessBolao _businessBolao;
        #endregion

        #region Constructors/Destructors
        public CopaMundoPdfCreator(string currentLogin)
        {
            _currentLogin = currentLogin;

            _businessApostaExtra = new Business.Boloes.Support.ApostaExtraUsuario(_currentLogin);
            _businessJogoUsuario = new Business.Boloes.Support.JogoUsuario(_currentLogin);
            _businessJogo = new Business.Campeonatos.Support.Jogo(_currentLogin);
            _businessBolao = new Business.Boloes.Support.Bolao(_currentLogin);
        }
        #endregion

        #region Methods

        public void GenerateApostasUsuarios(Stream outputStream, Document document, string imagePath, Model.Boloes.Bolao bolao, List<Framework.Security.Model.UserData> users)
        {
            PdfWriter writer = PdfWriter.GetInstance(document, outputStream);

            // we Add a Footer that will show up on PAGE 1
            HeaderFooter footer = new HeaderFooter(new Phrase("Página: "), true);
            footer.Border = Rectangle.NO_BORDER;
            document.Footer = footer;

            // we Add a Header that will show up on PAGE 2
            HeaderFooter header = new HeaderFooter(new Phrase(bolao.Nome), false);
            document.Header = header;


            document.Open();


            foreach (Framework.Security.Model.UserData user in users)
            {


                document.NewPage();

                //Buscando as apostas auxiliares do usuário
                IList<Framework.DataServices.Model.EntityBaseData> listExtra = _businessApostaExtra.SelectByUser(bolao, user.UserName, null);

                //Buscando as apostas dos jogos do usuário
                IList<Framework.DataServices.Model.EntityBaseData> list = _businessJogoUsuario.SelectAllByPeriod(
                    bolao, user.UserName, 0, DateTime.MinValue, DateTime.MinValue, null, null, null, null);



                //Criando a página com a lista dos dados
                base.CreatePage(false,false,0,0, writer, imagePath, user, list, listExtra);

            }

            document.Close();
        }
        public void GenerateApostasUser(Stream outputStream, Document document, string imagePath, Model.Boloes.Bolao bolao, Framework.Security.Model.UserData user)
        {
           

            PdfWriter writer = PdfWriter.GetInstance(document, outputStream);

            // we Add a Footer that will show up on PAGE 1
            HeaderFooter footer = new HeaderFooter(new Phrase("Página: "), true);
            footer.Border = Rectangle.NO_BORDER;
            document.Footer = footer;

            // we Add a Header that will show up on PAGE 2
            HeaderFooter header = new HeaderFooter(new Phrase(bolao.Nome), false);
            document.Header = header;


            document.Open();

            document.NewPage();



            //Buscando as apostas auxiliares do usuário
            IList<Framework.DataServices.Model.EntityBaseData> listExtra = _businessApostaExtra.SelectByUser(bolao, user.UserName, null);

            //Buscando as apostas dos jogos do usuário
            IList<Framework.DataServices.Model.EntityBaseData> list = _businessJogoUsuario.SelectAllByPeriod(
                bolao, user.UserName, 0, DateTime.MinValue, DateTime.MinValue, null, null, null, null);



            //Criando a página com a lista dos dados
            base.CreatePage(false, false, 0,0, writer, imagePath, user, list, listExtra);

            document.Close();

        }

        public void CreateApostasUsers(Stream outputStream, string imagePath, Model.Boloes.Bolao bolao, List<Framework.Security.Model.UserData> users)
        {

            Document document = new Document(PageSize.A4);


            GenerateApostasUsuarios(outputStream, document, imagePath, bolao, users);

        }
        public void CreateApostasUser(Stream outputStream, string imagePath, Model.Boloes.Bolao bolao, Framework.Security.Model.UserData user)
        {

            Document document = new Document(PageSize.A4);


            GenerateApostasUser(outputStream, document, imagePath, bolao, user);




                //Document document = new Document(PageSize.A4);

                //PdfWriter writer = PdfWriter.GetInstance(document, outputStream);

                //// we Add a Footer that will show up on PAGE 1
                //HeaderFooter footer = new HeaderFooter(new Phrase("Página: "), true);
                //footer.Border = Rectangle.NO_BORDER;
                //document.Footer = footer;

                //// we Add a Header that will show up on PAGE 2
                //HeaderFooter header = new HeaderFooter(new Phrase(bolao.Nome), false);
                //document.Header = header;


                //document.Open();

                //document.NewPage();

                ////Buscando as apostas auxiliares do usuário
                //IList<Framework.DataServices.Model.EntityBaseData> listExtra = _businessApostaExtra.SelectByUser(bolao, user.UserName, null);

                ////Buscando as apostas dos jogos do usuário
                //IList<Framework.DataServices.Model.EntityBaseData> list = _businessJogoUsuario.SelectAllByPeriod(
                //    bolao, user.UserName, 0, DateTime.MinValue, DateTime.MinValue, null, null, null, null);



                ////Criando a página com a lista dos dados
                //base.CreatePage(writer, imagePath, user, list, listExtra);

                //document.NewPage();

                //document.Add(new Phrase("Teste"));


                ////Fechando o documento
                //document.Close();




        }


        public void CreateApostasPontosUser(Stream outputStream, string imagePath, Model.Boloes.Bolao bolao, Framework.Security.Model.UserData user)
        {
            Document document = new Document(PageSize.A4);

            GenerateApostasPontosUser(outputStream, document, imagePath, bolao, user);
        }
        public void GenerateApostasPontosUser(Stream outputStream, Document document, string imagePath, Model.Boloes.Bolao bolao, Framework.Security.Model.UserData user)
        {
            PdfWriter writer = PdfWriter.GetInstance(document, outputStream);

            // we Add a Footer that will show up on PAGE 1
            HeaderFooter footer = new HeaderFooter(new Phrase("Página: "), true);
            footer.Border = Rectangle.NO_BORDER;
            document.Footer = footer;

            // we Add a Header that will show up on PAGE 2
            HeaderFooter header = new HeaderFooter(new Phrase(bolao.Nome), false);
            document.Header = header;


            document.Open();

            document.NewPage();



            //Buscando as apostas auxiliares do usuário
            IList<Framework.DataServices.Model.EntityBaseData> listExtra = _businessApostaExtra.SelectByUser(bolao, user.UserName, null);

            //Buscando as apostas dos jogos do usuário
            IList<Framework.DataServices.Model.EntityBaseData> list = _businessJogoUsuario.SelectAllByPeriod(
                bolao, user.UserName, 0, DateTime.MinValue, DateTime.MinValue, null, null, null, null);



            //Criando a página com a lista dos dados
            base.CreatePagePontos(false, writer, imagePath, user, list, listExtra);

            document.Close();
        }

        public void CreateJogos(Stream outputStream, string imagePath, Model.Campeonatos.Campeonato campeonato)
        {
            Document document = new Document(PageSize.A4);

            PdfWriter writer = PdfWriter.GetInstance(document, outputStream);

            // we Add a Footer that will show up on PAGE 1
            HeaderFooter footer = new HeaderFooter(new Phrase("Página: "), true);
            footer.Border = Rectangle.NO_BORDER;
            document.Footer = footer;

            // we Add a Header that will show up on PAGE 2
            HeaderFooter header = new HeaderFooter(new Phrase(campeonato.Nome), false);
            document.Header = header;


            document.Open();

            document.NewPage();



            //Buscando as apostas auxiliares do usuário
            IList<Framework.DataServices.Model.EntityBaseData> listExtra = new List<Framework.DataServices.Model.EntityBaseData>();//_businessApostaExtra.SelectByUser(bolao, user.UserName, null);


            IList<Framework.DataServices.Model.EntityBaseData> listAux = _businessJogo.SelectAllByPeriod(
                campeonato, 0, DateTime.MinValue, DateTime.MaxValue, null, null, null, null, null);


            IList<Framework.DataServices.Model.EntityBaseData> list = new List<Framework.DataServices.Model.EntityBaseData>();

            foreach (Model.Campeonatos.Jogo jogo in listAux)
            {
                Model.Boloes.JogoUsuario jogoUsr = new Model.Boloes.JogoUsuario();
                jogoUsr.ApostaTime1 = jogo.GolsTime1;
                jogoUsr.ApostaTime2 = jogo.GolsTime2;
                jogoUsr.Campeonato = jogo.Campeonato;
                jogoUsr.DataJogo = jogo.DataJogo;
                jogoUsr.DescricaoTime1 = jogo.DescricaoTime1;
                jogoUsr.DescricaoTime2 = jogo.DescricaoTime2;
                jogoUsr.Estadio = jogo.Estadio;
                jogoUsr.Fase = jogo.Fase;
                jogoUsr.GolsTime1 = jogo.GolsTime1;
                jogoUsr.GolsTime2 = jogo.GolsTime2;
                jogoUsr.Grupo = jogo.Grupo;
                jogoUsr.IDJogo = jogo.IDJogo;
                jogoUsr.JogoLabel = jogo.JogoLabel;
                jogoUsr.PenaltisTime1 = jogo.PenaltisTime1;
                jogoUsr.PenaltisTime2 = jogo.PenaltisTime2;
                jogoUsr.Rodada = jogo.Rodada;
                jogoUsr.Time1 = jogo.Time1;
                jogoUsr.Time2 = jogo.Time2;
                jogoUsr.Titulo = jogo.Titulo;
                jogoUsr.PartidaValida = jogo.PartidaValida;
                jogoUsr.Valido = jogo.PartidaValida;
                list.Add(jogoUsr);

            }


            ////Buscando as apostas dos jogos do usuário
            //IList<Framework.DataServices.Model.EntityBaseData> list = _businessJogoUsuario.SelectAllByPeriod(
            //    bolao, user.UserName, 0, DateTime.MinValue, DateTime.MinValue, null, null, null, null);



            //Criando a página com a lista dos dados
            base.CreatePage(true, false,0,0, writer, imagePath, null, list, listExtra);

            document.Close();

        }





        public void CreateApostasUsersFim(Stream outputStream, string imagePath, Model.Campeonatos.Campeonato campeonato, Model.Boloes.Bolao bolao, List<Framework.Security.Model.UserData> users)
        {

            Document document = new Document(PageSize.A4);

            

            GenerateApostasUsuariosFim(outputStream, document, imagePath, campeonato, bolao, users);

        }
        public void GenerateApostasUsuariosFim(Stream outputStream, Document document, string imagePath, Model.Campeonatos.Campeonato campeonato, Model.Boloes.Bolao bolao, List<Framework.Security.Model.UserData> users)
        {
            PdfWriter writer = PdfWriter.GetInstance(document, outputStream);

            // we Add a Footer that will show up on PAGE 1
            HeaderFooter footer = new HeaderFooter(new Phrase("Página: "), true);
            footer.Border = Rectangle.NO_BORDER;
            document.Footer = footer;

            // we Add a Header that will show up on PAGE 2
            HeaderFooter header = new HeaderFooter(new Phrase("Bolão: " + bolao.Nome), false);
            document.Header = header;

            document.Open();

            







            document.NewPage();

            _businessBolao = new Business.Boloes.Support.Bolao(_currentLogin, bolao.Nome);
            IList<Model.Boloes.BolaoMembros> classificacao = _businessBolao.LoadClassificacao(0);
            IList<Framework.DataServices.Model.EntityBaseData> listPosicoes = _businessBolao.SelectPremios();


            PdfPTable titulo = new PdfPTable(1);
            PdfPCell cell = new PdfPCell(new Phrase("Classificação", new Font(Font.HELVETICA, 12f, Font.BOLD, Color.BLACK)));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_CENTER;
            cell.BackgroundColor = Color.YELLOW;
            titulo.AddCell(cell);
            titulo.TotalWidth = 250;
            titulo.WriteSelectedRows(0, -1, 175, 790, writer.DirectContent);


            int max = 55;
            PdfPTable class1 = base.CreateClassificacao(writer, imagePath, 0, max, classificacao, listPosicoes);


            if (classificacao.Count >= max)
            {

                class1.WriteSelectedRows(0, -1, 30, 765, writer.DirectContent);
                PdfPTable class2 = base.CreateClassificacao(writer, imagePath, max, max * 2, classificacao, listPosicoes);

                class2.WriteSelectedRows(0, -1, 315, 765, writer.DirectContent);
            }
            else
            {
                class1.TotalWidth = 535;
                class1.WriteSelectedRows(0, -1, 30, 765, writer.DirectContent);

            }


            PdfPTable legendas = new PdfPTable(1);
            cell = new PdfPCell(new Phrase(
                "Pontos = Total de Pontos, E = Total de Empates, VDE = Total de Vitórias/Derrotas/Empates, GT1 = Total de Gols do time 1, GT2 = Total de Gols do time 2, C = Acertos em cheio, EX = Pontuação extra." 
                , new Font(Font.HELVETICA, 7f, Font.NORMAL, Color.BLACK)));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_TOP;
            legendas.AddCell(cell);
            legendas.TotalWidth = 550;
            legendas.WriteSelectedRows(0, -1, 23, 70, writer.DirectContent);





            document.NewPage();

            IList<Framework.DataServices.Model.EntityBaseData> listExtra1 = new List<Framework.DataServices.Model.EntityBaseData>();//_businessApostaExtra.SelectByUser(bolao, user.UserName, null);
            IList<Framework.DataServices.Model.EntityBaseData> listAux = _businessJogo.SelectAllByPeriod(
                campeonato, 0, DateTime.MinValue, DateTime.MaxValue, null, null, null, null, null);
            IList<Framework.DataServices.Model.EntityBaseData> listJogos = new List<Framework.DataServices.Model.EntityBaseData>();
            foreach (Model.Campeonatos.Jogo jogo in listAux)
            {
                Model.Boloes.JogoUsuario jogoUsr = new Model.Boloes.JogoUsuario();
                jogoUsr.ApostaTime1 = jogo.GolsTime1;
                jogoUsr.ApostaTime2 = jogo.GolsTime2;
                jogoUsr.Campeonato = jogo.Campeonato;
                jogoUsr.DataJogo = jogo.DataJogo;
                jogoUsr.DescricaoTime1 = jogo.DescricaoTime1;
                jogoUsr.DescricaoTime2 = jogo.DescricaoTime2;
                jogoUsr.Estadio = jogo.Estadio;
                jogoUsr.Fase = jogo.Fase;
                jogoUsr.GolsTime1 = jogo.GolsTime1;
                jogoUsr.GolsTime2 = jogo.GolsTime2;
                jogoUsr.Grupo = jogo.Grupo;
                jogoUsr.IDJogo = jogo.IDJogo;
                jogoUsr.JogoLabel = jogo.JogoLabel;
                jogoUsr.PenaltisTime1 = jogo.PenaltisTime1;
                jogoUsr.PenaltisTime2 = jogo.PenaltisTime2;
                jogoUsr.Rodada = jogo.Rodada;
                jogoUsr.Time1 = jogo.Time1;
                jogoUsr.Time2 = jogo.Time2;
                jogoUsr.Titulo = jogo.Titulo;
                listJogos.Add(jogoUsr);


                //Campão e vice
                if (jogo.PendenteIdTime1 > 0 && jogo.PendenteIdTime1 > 0 &&
                    jogo.PendenteTime1Ganhador && jogo.PendenteTime2Ganhador && jogo.PartidaValida
                    && string.Compare (jogo.Fase.Nome, "Final", true)== 0)
                {
                    string timeGanhador;
                    string timePerdedor;

                    if (jogo.GolsTime1 >= jogo.GolsTime2)
                    {
                        timeGanhador = jogo.Time1.Nome;
                        timePerdedor = jogo.Time2.Nome;
                    }
                    else
                    {
                        timeGanhador = jogo.Time2.Nome;
                        timePerdedor = jogo.Time1.Nome;
                    
                    }


                    Model.Boloes.ApostaExtraUsuario extra = new Model.Boloes.ApostaExtraUsuario(1, jogoUsr.Bolao.Nome, "");
                    extra.NomeTime= timeGanhador;
                    extra.Posicao = 1;
                    extra.Titulo = "Campeão";
                    listExtra1.Add(extra);

                    extra = new Model.Boloes.ApostaExtraUsuario(2, jogoUsr.Bolao.Nome, "");
                    extra.NomeTime= timePerdedor;
                    extra.Posicao = 2;
                    extra.Titulo = "Vice Campeão";
                    listExtra1.Add(extra);
                }


                //Terceiro e quarto
                if (jogo.PendenteIdTime1 > 0 && jogo.PendenteIdTime1 > 0 &&
                    !jogo.PendenteTime1Ganhador && !jogo.PendenteTime2Ganhador && jogo.PartidaValida
                    && string.Compare(jogo.Fase.Nome, "Final", true) == 0)
                {
                    string timeGanhador;
                    string timePerdedor;

                    if (jogo.GolsTime1 >= jogo.GolsTime2)
                    {
                        timeGanhador = jogo.Time1.Nome;
                        timePerdedor = jogo.Time2.Nome;
                    }
                    else
                    {
                        timeGanhador = jogo.Time2.Nome;
                        timePerdedor = jogo.Time1.Nome;

                    }


                    Model.Boloes.ApostaExtraUsuario extra = new Model.Boloes.ApostaExtraUsuario(3, jogoUsr.Bolao.Nome, "");
                    extra.NomeTime = timeGanhador;
                    extra.Posicao = 3;
                    extra.Titulo = "Terceiro";
                    listExtra1.Add(extra);

                    extra = new Model.Boloes.ApostaExtraUsuario(4, jogoUsr.Bolao.Nome, "");
                    extra.NomeTime = timePerdedor;
                    extra.Posicao = 4;
                    extra.Titulo = "Quarto";
                    listExtra1.Add(extra);
                }



            }
            //Criando a página com a lista dos dados
            base.CreatePage(false, false, 0,0,writer, imagePath, null, listJogos, listExtra1);










            foreach (Framework.Security.Model.UserData user in users)
            {


                document.NewPage();

                //Buscando as apostas auxiliares do usuário
                IList<Framework.DataServices.Model.EntityBaseData> listExtra = _businessApostaExtra.SelectByUser(bolao, user.UserName, null);

                //Buscando as apostas dos jogos do usuário
                IList<Framework.DataServices.Model.EntityBaseData> list = _businessJogoUsuario.SelectAllByPeriod(
                    bolao, user.UserName, 0, DateTime.MinValue, DateTime.MinValue, null, null, null, null);



                int posicao = 0;
                int pontos = 0;
                for (int c = 0; c < classificacao.Count; c++)
                {
                    if (string.Compare(classificacao[c].UserName, user.UserName, true) == 0)
                    {
                        posicao = classificacao[c].Posicao;
                        pontos = classificacao[c].TotalPontos;
                        break;
                    }
                }
                    


                //Criando a página com a lista dos dados
                base.CreatePage(false, true, posicao, pontos, writer, imagePath, user, list, listExtra);

            }

            document.Close();
        }
        
        
        #endregion
    }
}
