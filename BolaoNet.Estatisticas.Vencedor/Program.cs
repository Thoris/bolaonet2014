using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Estatisticas.Vencedor
{
    class Program
    {
        static void Main(string[] args)
        {
            int gols1 =0 , gols2 = 3, ganhador = 0;
            if (args != null && args.Length == 3)
            {
                gols1 = int.Parse(args[0]);
                gols2 = int.Parse(args[1]);
                ganhador = int.Parse(args[2]);
            }


            Calculation calc = new Calculation(gols1, gols2, ganhador);
            calc.Run("Copa do Mundo 2014");
        }
    }
}
