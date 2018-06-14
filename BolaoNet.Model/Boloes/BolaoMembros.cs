using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Model.Boloes
{
    [Serializable]
    public class BolaoMembros : Model.Boloes.Pontuacao
    {
        #region Variables
        private string _userName;
        private Model.Boloes.Bolao _bolao = new BolaoNet.Model.Boloes.Bolao();
        private int _posicao;
        private int _lastPosicao;
        private string _fullName;
        #endregion

        #region Properties
        public int Posicao
        {
            get { return _posicao; }
            set { _posicao = value; }
        }
        public int LastPosicao
        {
            get { return _lastPosicao; }
            set { _lastPosicao = value; }
        }
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        public Model.Boloes.Bolao Bolao
        {
            get { return _bolao; }
            set { _bolao = value; }
        }
        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }
        #endregion

        #region Constructors/Destructors
        public BolaoMembros()
        {
        }
        public BolaoMembros(string userName)
        {
            _userName = userName;
        }
        #endregion

        #region Methods
        public void Copy(BolaoMembros entry)
        {
            _userName = entry._userName;
            _posicao = entry._posicao;
            _lastPosicao = entry._lastPosicao;
            _bolao = entry._bolao;
            base.TotalPontos = entry.TotalPontos;
            base.TotalDerrota = entry.TotalDerrota;
            base.TotalEmpate = entry.TotalEmpate;
            base.TotalErro = entry.TotalErro;
            base.TotalGolsEmpate = entry.TotalGolsEmpate;
            base.TotalGolsGanhador = entry.TotalGolsGanhador;
            base.TotalGolsGanhadorDentro = entry.TotalGolsGanhadorDentro;
            base.TotalGolsGanhadorFora = entry.TotalGolsGanhadorFora;
            base.TotalGolsPerdedor = entry.TotalGolsPerdedor;
            base.TotalGolsTime1 = entry.TotalGolsTime1;
            base.TotalGolsTime2 = entry.TotalGolsTime2;
            base.TotalPerdedorDentro = entry.TotalPerdedorDentro;
            base.TotalPerdedorFora = entry.TotalPerdedorFora;
            base.TotalPlacarCheio = entry.TotalPlacarCheio;
            base.TotalPontos = entry.TotalPontos;
            base.TotalResultTime1 = entry.TotalResultTime1;
            base.TotalResultTime2 = entry.TotalResultTime2;
            base.TotalVDE = entry.TotalVDE;
            base.TotalVitoria = entry.TotalVitoria;
            _fullName = entry._fullName;
            
        }
        #endregion
    }
}
