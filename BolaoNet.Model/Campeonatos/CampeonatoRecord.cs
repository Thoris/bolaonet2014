using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Model.Campeonatos
{

    [Serializable]
    public class CampeonatoRecord : Framework.DataServices.Model.EntityBaseData
    {
        #region Variables
        private int _posicao = 0;
        private int _vitorias = 0;
        private int _derrotas = 0;
        private int _empates = 0;
        private int _jogos = 0;
        private int _jogosSemMarcar = 0;
        private int _jogosSemLevar = 0;
        private Model.DadosBasicos.Time _time = new BolaoNet.Model.DadosBasicos.Time();
        #endregion

        #region Properties
        public int JogosSemMarcar
        {
            get { return _jogosSemMarcar; }
            set { _jogosSemMarcar = value; }
        }
        public int JogosSemLevar
        {
            get { return _jogosSemLevar; }
            set { _jogosSemLevar = value; }
        }
        public int Posicao
        {
            get { return _posicao; }
            set { _posicao = value; }
        }
        public int Vitorias
        {
            get { return _vitorias; }
            set { _vitorias = value; }
        }
        public int Derrotas
        {
            get { return _derrotas; }
            set { _derrotas = value; }
        }
        public int Empates
        {
            get { return _empates; }
            set { _empates = value; }
        }
        public int Jogos
        {
            get 
            {
                if (_jogos == 0)
                    return _vitorias + _derrotas + _empates;
                else
                    return _jogos;
            }
            set
            {
                _jogos = value;
            }
        }
        public Model.DadosBasicos.Time Time
        {
            get { return _time; }
            set { _time = value; }
        }
        #endregion

        #region Constructors/Destructors
        public CampeonatoRecord()
        {
        }
        public CampeonatoRecord(string nomeTime)
        {
            _time = new BolaoNet.Model.DadosBasicos.Time(nomeTime);
        }
        #endregion
    }
}
