using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BolaoNet.Tests.Copa
{


    public class Execute
    {
        #region Constructors/Destructors
        public Execute()
        {
        }
        #endregion

        #region Methods
        public void Run()
        {




            BolaoTests test = new BolaoTests();


            //Business.Boloes.Support.Bolao bolao = new Business.Boloes.Support.Bolao("Admin", "Copa do Mundo 2014");
            //bolao.Campeonato = new Model.Campeonatos.Campeonato("Copa do Mundo 2014");


            //test.InsertUserTests(bolao);


            //test.Init();
            //test.TestFull();






            //string bolao = "BCM2014";


            //List<Framework.Security.Model.UserData> users = new List<Framework.Security.Model.UserData>();

            //IList<Framework.DataServices.Model.EntityBaseData> list = new Business.Boloes.Support.Bolao("", bolao).LoadMembros();

            //foreach (Framework.Security.Model.UserData user in list)
            //{
            //    if (!string.IsNullOrEmpty(user.UserName))
            //        users.Add(user);
            //}

            //string file = "teste.pdf";

            //if (System.IO.File.Exists(file))
            //    System.IO.File.Delete(file);

            //using (FileStream fs = new FileStream(file, FileMode.Create))
            //{
            //    Business.PDF.Support.CopaMundoPdfCreator pdf = new BolaoNet.Business.PDF.Support.CopaMundoPdfCreator("");



            //    pdf.CreateApostasUsersFim(fs, @"D:\Thoris\Projetos\BolaoNet\trunk\BolaoNet.WebSite\Images\Database",
            //        new Model.Campeonatos.Campeonato("CM2014"),
            //        new Model.Boloes.Bolao(bolao),
            //        users);


            //    System.Diagnostics.Process.Start(@"D:\Thoris\Projetos\BolaoNet\trunk\BolaoNet.Tests.Copa\bin\Release\teste.pdf");
            //}

            //Excel.ApostasExcel apostas = new Excel.ApostasExcel("", ".\\Test.xls");
            //apostas.CreateFile(new Model.Campeonatos.Campeonato("CM2014"), new Model.Boloes.Bolao ("BCM2014"));








            //BolaoTests test = new BolaoTests();
            //test.Init();
            

            //test.TestFull();

            //test.Cleanup();
        }
        #endregion
    }
}
