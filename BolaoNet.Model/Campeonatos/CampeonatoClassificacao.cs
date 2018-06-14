using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Model.Campeonatos
{
    [Serializable]
    public class CampeonatoClassificacao : Pontuacao
    {
        #region Variables
        private Model.Campeonatos.Campeonato _campeonato = new Campeonato();
        private Model.Campeonatos.Fase _fase = new Fase();
        private Model.Campeonatos.Grupo _grupo = new Grupo();
        private Model.DadosBasicos.Time _time = new Model.DadosBasicos.Time();
        private int _posicao;
        private int _lastPosicao;
        #endregion

        #region Properties
        public Model.Campeonatos.Campeonato Campeonato
        {
            get { return _campeonato; }
            set { _campeonato = value; }
        }
        public Model.Campeonatos.Fase Fase
        {
            get { return _fase; }
            set { _fase = value; }
        }
        public Model.Campeonatos.Grupo Grupo
        {
            get { return _grupo; }
            set { _grupo = value; }
        }
        public Model.DadosBasicos.Time Time
        {
            get { return _time; }
            set { _time = value; }
        }
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
        #endregion

        #region Constructors/Destructors
        public CampeonatoClassificacao()
        {

        }
        #endregion
    }
}
