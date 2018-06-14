using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BolaoNet.PdfDefault
{
    class Program
    {
        static void Main(string[] args)
        {

            //Business.Excel.TemplateExcelBase excel = new BolaoNet.Business.Excel.TemplateExcelBase(null, @"..\..\..\Utils\Default.xls");
            //excel.SaveUserFile(new BolaoNet.Model.Boloes.Bolao ("Copa do Mundo 2010"),
            //    new BolaoNet.Model.Campeonatos.Campeonato ("Copa do Mundo 2010"), 
            //    new Framework.Security.Model.UserData("ExcelFileTest22"));


            //return;



            using (FileStream fs = new FileStream("C:\\temp\\mynew.pdf", FileMode.Create))
            {


                
                Business.PDF.Support.CopaMundoPdfCreator pdf = new BolaoNet.Business.PDF.Support.CopaMundoPdfCreator(null);



                List<Framework.Security.Model.UserData> users = new List<Framework.Security.Model.UserData>();
                users.Add(new Framework.Security.Model.UserData("thoris"));
                users.Add(new Framework.Security.Model.UserData("thoris2"));
                users.Add(new Framework.Security.Model.UserData("teste"));



                //pdf.CreateApostasUsers(fs,
                //    @"C:\Thoris\PROJS\BolaoNet\BolaoNet.WebSite\Images\database\",
                //    new BolaoNet.Model.Boloes.Bolao("Copa do Mundo 2010"),
                //    users);




                //pdf.CreateApostasUser(fs, @"C:\Thoris\PROJS\BolaoNet\BolaoNet.WebSite\Images\database\",
                //    new BolaoNet.Model.Boloes.Bolao("Copa do Mundo 2010"),
                //    new Framework.Security.Model.UserData("thoris"));


                pdf.CreateApostasPontosUser(fs, @"C:\Thoris\PROJS\BolaoNet\BolaoNet.WebSite\Images\database\",
                    new BolaoNet.Model.Boloes.Bolao("Copa do Mundo 2010"),
                    new Framework.Security.Model.UserData("Thoris"));

                  




                System.Diagnostics.Process.Start("c:\\mynew.pdf");
            }
        }
    }
}
