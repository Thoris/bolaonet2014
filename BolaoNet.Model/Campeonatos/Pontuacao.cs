using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Model.Campeonatos
{
    [Serializable]
    public class Pontuacao : Framework.DataServices.Model.EntityBaseData
    {
        #region Variables
        private int _totalVitorias;
        private int _totalDerrotas;
        private int _totalEmpates;
        private int _totalGolsContra;
        private int _totalGolsPro;
        private int _totalPontos;
        private int _jogos;
        private int _saldo;
        #endregion

        #region Properties
        public int TotalVitorias
        {
            get { return _totalVitorias; }
            set { _totalVitorias = value; }
        }
        public int TotalDerrotas
        {
            get { return _totalDerrotas; }
            set { _totalDerrotas = value; }
        }
        public int TotalEmpates
        {
            get { return _totalEmpates; }
            set { _totalEmpates = value; }
        }
        public int TotalGolsContra
        {
            get { return _totalGolsContra; }
            set { _totalGolsContra = value; }
        }
        public int TotalGolsPro
        {
            get { return _totalGolsPro; }
            set { _totalGolsPro = value; }
        }
        public int TotalPontos
        {
            get { return _totalPontos; }
            set { _totalPontos = value; }
        }
        public int Jogos
        {
            get { return _jogos; }
            set { _jogos = value; }
        }
        public int Saldo
        {
            get { return _saldo; }
            set { _saldo = value; }
        }
        public double Aproveitamento
        {
            get 
            {
                if (_jogos == 0)
                    return 0;
                else
                {
                    int totalPontos = _jogos * 3;

                    double result = ((double)_totalPontos / (double)totalPontos) * (double)100;

                    return (int)result;
                }

            }
        }

        #endregion

        #region Constructors/Destructors
        public Pontuacao()
        {
        }
        #endregion
    }
}
