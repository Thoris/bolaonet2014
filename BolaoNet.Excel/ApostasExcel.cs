using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using NPOI;

namespace BolaoNet.Excel
{
    public class ApostasExcel
    {
        #region Variables
        private string _fileName;
        private string _currentLogin;
        #endregion

        #region Constructors/Destructors
        public ApostasExcel(string currentLogin, string file)
        {
            _fileName = file;
            _currentLogin = currentLogin;
        }
        #endregion

        #region Methods
        public void CreateFile(Model.Campeonatos.Campeonato campeonato, Model.Boloes.Bolao bolao)
        {
            if (System.IO.File.Exists(_fileName))
                System.IO.File.Delete(_fileName);



            //FileStream stream = new FileStream(_fileName, FileMode.Create, FileAccess.Write);
            //NPOI.HSSF.UserModel.HSSFWorkbook wb = new NPOI.HSSF.UserModel.HSSFWorkbook(stream);

            NPOI.SS.UserModel.Workbook wb = new NPOI.HSSF.UserModel.HSSFWorkbook();


            NPOI.SS.UserModel.Sheet sheetJogos = wb.CreateSheet("Jogos-Grupo");

            Business.Campeonatos.Support.Campeonato camp = new Business.Campeonatos.Support.Campeonato(_currentLogin, campeonato);
            IList<Framework.DataServices.Model.EntityBaseData> jogos = camp.LoadJogos(0, null, null, DateTime.MinValue, DateTime.MinValue, null);


            IList<Framework.DataServices.Model.EntityBaseData> grupos = camp.LoadGrupos();

            int count = 0;
            int line = 0;
            foreach (Model.Campeonatos.Grupo grupo in grupos)
            {
                if (!string.IsNullOrEmpty(grupo.Nome.Trim()))
                {
                    NPOI.SS.UserModel.Row row = sheetJogos.CreateRow(count++);
                    NPOI.SS.UserModel.Cell grupoCell = row.CreateCell(0);
                    grupoCell.SetCellValue("Grupo " + grupo.Nome);


                    line = 0;
                    row = sheetJogos.CreateRow(count++);
                    row.CreateCell(line++).SetCellValue("Jogo");
                    row.CreateCell(line++).SetCellValue("Data/Hora");
                    row.CreateCell(line++).SetCellValue("Local");
                    row.CreateCell(line++).SetCellValue("Time");
                    row.CreateCell(line++).SetCellValue("Gols");
                    row.CreateCell(line++).SetCellValue("");
                    row.CreateCell(line++).SetCellValue("");
                    row.CreateCell(line++).SetCellValue("x");
                    row.CreateCell(line++).SetCellValue("");
                    row.CreateCell(line++).SetCellValue("");
                    row.CreateCell(line++).SetCellValue("Gols");
                    row.CreateCell(line++).SetCellValue("Time");
                    row.CreateCell(line++).SetCellValue("");


                    foreach (Model.Campeonatos.Jogo jogo in jogos)
                    {
                        if (string.Compare(jogo.Grupo.Nome, grupo.Nome, true) == 0)
                        {
                            line = 0;
                            row = sheetJogos.CreateRow(count++);
                            row.CreateCell(line++).SetCellValue(jogo.JogoLabel);
                            row.CreateCell(line++).SetCellValue(jogo.DataJogo.ToString("dd/MM/yy HH:mm"));
                            row.CreateCell(line++).SetCellValue(jogo.Estadio.ToString());
                            row.CreateCell(line++).SetCellValue(jogo.Time1.Nome);
                            if (jogo.PartidaValida)
                                row.CreateCell(line++).SetCellValue(jogo.GolsTime1);
                            else
                                row.CreateCell(line++).SetCellValue("");
                            row.CreateCell(line++).SetCellValue("");

                            row.CreateCell(line++).SetCellValue("");
                            row.CreateCell(line++).SetCellValue("x");

                            row.CreateCell(line++).SetCellValue("");
                            row.CreateCell(line++).SetCellValue("");
                            
                            if (jogo.PartidaValida)
                                row.CreateCell(line++).SetCellValue(jogo.GolsTime2);
                            else
                                row.CreateCell(line++).SetCellValue("");
                            row.CreateCell(line++).SetCellValue(jogo.Time2.Nome);
                            row.CreateCell(line++).SetCellValue("");
                        }
                    }

                    sheetJogos.CreateRow(count++);
                }

            }


            sheetJogos.CreateRow(count++);
            CreateFase(sheetJogos, "Oitavas de Final", ref count, jogos);
            sheetJogos.CreateRow(count++);
            CreateFase(sheetJogos, "Quartas de Final", ref count, jogos);
            sheetJogos.CreateRow(count++);
            CreateFase(sheetJogos, "Semi Finais", ref count, jogos);
            sheetJogos.CreateRow(count++);
            CreateFase(sheetJogos, "Final", ref count, jogos);


            Business.Boloes.Support.Bolao bolaoBO = new Business.Boloes.Support.Bolao(_currentLogin, bolao.Nome);

            IList<Framework.DataServices.Model.EntityBaseData> users = bolaoBO.LoadMembros();

            foreach (Framework.Security.Model.UserData user in users)
            {
                CreateUser(wb, user.UserName, bolaoBO);
            }
            


            wb.Write(new FileStream(_fileName, FileMode.Create));


        }
        private void CreateFase(NPOI.SS.UserModel.Sheet sheet, string fase, ref int count, IList<Framework.DataServices.Model.EntityBaseData> list)
        {
            
            NPOI.SS.UserModel.Row rowJogo = sheet.CreateRow(count++);
            NPOI.SS.UserModel.Cell grupoCellJogo = rowJogo.CreateCell(0);
            grupoCellJogo.SetCellValue(fase);

            int line = 0;
            rowJogo = sheet.CreateRow(count++);
            rowJogo.CreateCell(line++).SetCellValue("Jogo");
            rowJogo.CreateCell(line++).SetCellValue("Data/Hora");
            rowJogo.CreateCell(line++).SetCellValue("Local");
            rowJogo.CreateCell(line++).SetCellValue("Time");
            rowJogo.CreateCell(line++).SetCellValue("Gols");
            rowJogo.CreateCell(line++).SetCellValue("Penal");

            rowJogo.CreateCell(line++).SetCellValue("");
            rowJogo.CreateCell(line++).SetCellValue("x");
            rowJogo.CreateCell(line++).SetCellValue("");

            rowJogo.CreateCell(line++).SetCellValue("Penal");
            rowJogo.CreateCell(line++).SetCellValue("Gols");
            rowJogo.CreateCell(line++).SetCellValue("Time");
            rowJogo.CreateCell(line++).SetCellValue("");


            foreach (Model.Campeonatos.Jogo jogo in list)
            {
                if (string.Compare(jogo.Fase.Nome, fase, true) == 0)
                {
                    line = 0;
                    rowJogo = sheet.CreateRow(count++);
                    rowJogo.CreateCell(line++).SetCellValue(jogo.JogoLabel);
                    rowJogo.CreateCell(line++).SetCellValue(jogo.DataJogo.ToString("dd/MM/yy HH:mm"));
                    rowJogo.CreateCell(line++).SetCellValue(jogo.Estadio.ToString());
                    rowJogo.CreateCell(line++).SetCellValue(jogo.Time1.Nome);
                    if (jogo.PartidaValida)
                        rowJogo.CreateCell(line++).SetCellValue(jogo.GolsTime1);
                    else
                        rowJogo.CreateCell(line++).SetCellValue("");


                    if (jogo.PartidaValida && jogo.GolsTime1 == jogo.GolsTime2)
                        rowJogo.CreateCell(line++).SetCellValue(jogo.PenaltisTime1);
                    else
                        rowJogo.CreateCell(line++).SetCellValue("");

                    rowJogo.CreateCell(line++).SetCellValue("");

                    rowJogo.CreateCell(line++).SetCellValue("x");

                    rowJogo.CreateCell(line++).SetCellValue("");

                    if (jogo.PartidaValida && jogo.GolsTime1 == jogo.GolsTime2)
                        rowJogo.CreateCell(line++).SetCellValue(jogo.PenaltisTime2);
                    else
                        rowJogo.CreateCell(line++).SetCellValue("");

                    if (jogo.PartidaValida)
                        rowJogo.CreateCell(line++).SetCellValue(jogo.GolsTime2);
                    else
                        rowJogo.CreateCell(line++).SetCellValue("");
                    rowJogo.CreateCell(line++).SetCellValue(jogo.Time2.Nome);
                    rowJogo.CreateCell(line++).SetCellValue("");


                    NPOI.SS.UserModel.Row rowFase = sheet.CreateRow(count++);
                    rowFase.CreateCell(3).SetCellValue(jogo.DescricaoTime1);




                    rowFase.CreateCell(11).SetCellValue(jogo.DescricaoTime2);


                
                }
            }


        }

        private void CreateUser(NPOI.SS.UserModel.Workbook wb, string user, Business.Boloes.Support.Bolao bolao)
        {
            NPOI.SS.UserModel.Sheet newSheet= wb.CloneSheet(0);

            Business.Boloes.Support.JogoUsuario jogo = new Business.Boloes.Support.JogoUsuario(_currentLogin);
            jogo.Bolao = bolao;
            IList<Framework.DataServices.Model.EntityBaseData> jogos = 
                jogo.SelectAllByPeriod(bolao, user, 0, DateTime.MinValue, DateTime.MinValue, null, null, null, null);


            foreach (Model.Boloes.JogoUsuario jogoUser in jogos)
            {

            }

             

        }

        private NPOI.SS.UserModel.Row GetRow(NPOI.SS.UserModel.Sheet sheet, int line)
        {
            NPOI.SS.UserModel.Row row = sheet.GetRow(line);

            if (row == null)
                row = sheet.CreateRow(line);

            return row;
        }
        private NPOI.SS.UserModel.Cell GetCell(NPOI.SS.UserModel.Sheet sheet, int line, int col)
        {
            NPOI.SS.UserModel.Row row = GetRow(sheet, line);

            NPOI.SS.UserModel.Cell cell = row.GetCell(col);

            if (cell == null)
                cell = row.CreateCell(col);

            return cell;
        }
        private void SetValue(NPOI.SS.UserModel.Sheet sheet, int line, int col, string value)
        {
            NPOI.SS.UserModel.Cell cell = GetCell(sheet, line, col);

            cell.SetCellValue(value);
        }
        private void SetValue(NPOI.SS.UserModel.Sheet sheet, int line, int col, int value)
        {
            NPOI.SS.UserModel.Cell cell = GetCell(sheet, line, col);

            cell.SetCellValue(value);
        }

        

        //private void SaveJogoGrupoLeft(NPOI.SS.UserModel.Sheet sheet, int line, int col, Model.Campeonatos.Jogo jogo)
        //{

        //    SetValue(sheet, line, col, jogo.JogoLabel);
        //    SetValue(sheet, line, col + 1, "");
        //    SetValue(sheet, line, col + 2, jogo.DataJogo.ToString("dd/MM HH:mm"));

        //    SetValue(sheet, line + 1, col + 2, jogo.Estadio.Nome);
        //    SetValue(sheet, line + 2, col, jogo.PendenteTime1PosGrupo + jogo.PendenteTime1NomeGrupo);
        //    SetValue(sheet, line + 2, col + 1, "");
        //    SetValue(sheet, line + 2, col + 2, jogo.Time1.Nome);
 

        //    SetValue(sheet, line + 3, col, jogo.PendenteTime2PosGrupo + jogo.PendenteTime2NomeGrupo);
        //    SetValue(sheet, line + 3, col + 1, "");
        //    SetValue(sheet, line + 3, col + 2, jogo.Time2.Nome);
 
        //}
        //private void SaveJogoGrupoRight(NPOI.SS.UserModel.Sheet sheet, int line, int col, Model.Campeonatos.Jogo jogo)
        //{

        //    SetValue(sheet, line, col, jogo.JogoLabel);
        //    SetValue(sheet, line, col + 1, "");
        //    SetValue(sheet, line, col + 2, jogo.DataJogo.ToString("dd/MM HH:mm"));

        //    SetValue(sheet, line + 1, col + 2, jogo.Estadio.Nome);
        //    SetValue(sheet, line + 2, col, jogo.PendenteTime1PosGrupo + jogo.PendenteTime1NomeGrupo);
        //    SetValue(sheet, line + 2, col + 1, "");
        //    SetValue(sheet, line + 2, col + 2, jogo.Time1.Nome);


        //    SetValue(sheet, line + 3, col, jogo.PendenteTime2PosGrupo + jogo.PendenteTime2NomeGrupo);
        //    SetValue(sheet, line + 3, col + 1, "");
        //    SetValue(sheet, line + 3, col + 2, jogo.Time2.Nome);

        //}
        //private Model.Campeonatos.Jogo SearchJogo(IList<Framework.DataServices.Model.EntityBaseData> list, string id)
        //{
        //    foreach (Model.Campeonatos.Jogo jogo in list)
        //    {
        //        if (string.Compare(jogo.JogoLabel, id, true) == 0)
        //            return jogo;
        //    }

        //    return null;
        //}

        #endregion
    }
}
