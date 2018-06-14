using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Model.Boloes
{
    [Serializable]
    public class ApostaPontos
    {        
        #region Variables
        private int _pontos;
        private bool _isEmpate;
        private bool _isVitoria;
        private bool _isDerrota;
        private bool _isGolsGanhador;
        private bool _isGolsPerdedor;
        private bool _isResultTime1;
        private bool _isResultTime2;
        private bool _isVDE;
        private bool _isErro;
        private bool _isGolsGanhadorFora;
        private bool _isGolsGanhadorDentro;
        private bool _isGolsPerdedorFora;
        private bool _isGolsPerdedorDentro;
        private bool _isGolsEmpate;
        private bool _isGolsTime1;
        private bool _isGolsTime2;
        private bool _isPlacarCheio;
        private bool _isMultiploTime;
        private int _multiploTime  =1;
        #endregion

        #region Properties
        public int Pontos
        {
            get { return _pontos; }
            set { _pontos = value; }
        }
        public bool IsEmpate
        {
            get { return _isEmpate ; }
            set { _isEmpate = value; }
        }
        public bool IsVitoria
        {
            get { return _isVitoria; }
            set { _isVitoria = value; }
        }
        public bool IsDerrota
        {
            get { return _isDerrota; }
            set { _isDerrota = value; }
        }
        public bool IsGolsGanhador
        {
            get { return _isGolsGanhador; }
            set { _isGolsGanhador = value; }
        }
        public bool IsGolsPerdedor
        {
            get { return _isGolsPerdedor; }
            set { _isGolsPerdedor = value; }
        }
        public bool IsResultTime1
        {
            get { return _isResultTime1; }
            set { _isResultTime1 = value; }
        }
        public bool IsResultTime2
        {
            get { return _isResultTime2; }
            set { _isResultTime2 = value; }
        }
        public bool IsVDE
        {
            get { return _isVDE; }
            set { _isVDE = value; }
        }
        public bool IsErro
        {
            get { return _isErro; }
            set { _isErro = value; }
        }
        public bool IsGolsGanhadorFora
        {
            get { return _isGolsGanhadorFora; }
            set { _isGolsGanhadorFora = value; }
        }
        public bool IsGolsGanhadorDentro
        {
            get { return _isGolsGanhadorDentro; }
            set { _isGolsGanhadorDentro = value; }
        }
        public bool IsGolsPerdedorFora
        {
            get { return _isGolsPerdedorFora; }
            set { _isGolsPerdedorFora = value; }
        }
        public bool IsGolsPerdedorDentro
        {
            get { return _isGolsPerdedorDentro; }
            set { _isGolsPerdedorDentro = value; }
        }
        public bool IsGolsEmpate
        {
            get { return _isGolsEmpate; }
            set { _isGolsEmpate = value; }
        }
        public bool IsGolsTime1
        {
            get { return _isGolsTime1; }
            set { _isGolsTime1 = value; }
        }
        public bool IsGolsTime2
        {
            get { return _isGolsTime2; }
            set { _isGolsTime2 = value; }
        }
        public bool IsPlacarCheio
        {
            get { return _isPlacarCheio; }
            set { _isPlacarCheio = value; }
        }
        public bool IsMultiploTime
        {
            get { return _isMultiploTime; }
            set { _isMultiploTime = value; }
        }
        public int MultiploTime
        {
            get { return _multiploTime; }
            set { _multiploTime = value; }
        }
        #endregion

        #region Constructors/Destructors
        public ApostaPontos()
        {
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return _pontos.ToString();
        }
        #endregion


    }
}
