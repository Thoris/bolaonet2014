using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Model.Boloes
{
    [Serializable]
    public class Pontuacao : Framework.DataServices.Model.EntityBaseData
    {
        #region Variables
        private int _totalPontos;
        private int _totalEmpate;
        private int _totalVitoria;
        private int _totalGolsGanhador;
        private int _totalGolsPerdedor;
        private int _totalResultTime1;
        private int _totalResultTime2;
        private int _totalVDE;
        private int _totalErro;
        private int _totalGolsGanhadorFora;
        private int _totalGolsGanhadorDentro;
        private int _totalPerdedorFora;
        private int _totalPerdedorDentro;
        private int _totalGolsEmpate;
        private int _totalGolsTime1;
        private int _totalGolsTime2;
        private int _totalPlacarCheio;
        private int _totalDerrota;
        private int _totalApostaExtra;
        #endregion

        #region Properties
        public int TotalApostaExtra
        {
            get { return _totalApostaExtra; }
            set { _totalApostaExtra = value; }
        }
        public int TotalPontos
        {
            get { return _totalPontos; }
            set { _totalPontos = value; }
        }
        public int TotalEmpate
        {
            get { return _totalEmpate; }
            set { _totalEmpate = value; }
        }
        public int TotalVitoria
        {
            get { return _totalVitoria; }
            set { _totalVitoria = value; }
        }
        public int TotalDerrota
        {
            get { return _totalDerrota; }
            set { _totalDerrota = value; }
        }
        public int TotalGolsGanhador
        {
            get { return _totalGolsGanhador; }
            set { _totalGolsGanhador = value; }
        }
        public int TotalGolsPerdedor
        {
            get { return _totalGolsPerdedor; }
            set { _totalGolsPerdedor = value; }
        }
        public int TotalResultTime1
        {
            get { return _totalResultTime1; }
            set { _totalResultTime1 = value; }
        }
        public int TotalResultTime2
        {
            get { return _totalResultTime2; }
            set { _totalResultTime2 = value; }
        }
        public int TotalVDE
        {
            get { return _totalVDE; }
            set { _totalVDE = value; }
        }
        public int TotalErro
        {
            get { return _totalErro; }
            set { _totalErro = value; }
        }
        public int TotalGolsGanhadorFora
        {
            get { return _totalGolsGanhadorFora; }
            set { _totalGolsGanhadorFora = value; }
        }
        public int TotalGolsGanhadorDentro
        {
            get { return _totalGolsGanhadorDentro; }
            set { _totalGolsGanhadorDentro = value; }
        }
        public int TotalPerdedorFora
        {
            get { return _totalPerdedorFora; }
            set { _totalPerdedorFora = value; }
        }
        public int TotalPerdedorDentro
        {
            get { return _totalPerdedorDentro; }
            set { _totalPerdedorDentro = value; }
        }
        public int TotalGolsEmpate
        {
            get { return _totalGolsEmpate; }
            set { _totalGolsEmpate = value; }
        }
        public int TotalGolsTime1
        {
            get { return _totalGolsTime1; }
            set { _totalGolsTime1 = value; }
        }
        public int TotalGolsTime2
        {
            get { return _totalGolsTime2; }
            set { _totalGolsTime2 = value; }
        }
        public int TotalPlacarCheio
        {
            get { return _totalPlacarCheio; }
            set { _totalPlacarCheio = value; }
        }
        #endregion

        #region Constructors/Destructors
        public Pontuacao()
        {
        }
        #endregion
    }
}
