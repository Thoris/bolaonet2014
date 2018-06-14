using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BolaoNet.Model.Campeonatos
{
    [Serializable]
    public class CampeonatoPosicao : DadosBasicos.HighLightItem
    {
        #region Variables
        private Model.Campeonatos.Campeonato _campeonato = null;
        private Model.Campeonatos.Fase _fase = null;
        private Model.Campeonatos.Grupo _grupo = null;
        

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
        #endregion

        #region Constructors/Destructors
        public CampeonatoPosicao()
        {
        }
        public CampeonatoPosicao(string nomeCampeonato, string nomeFase, string nomeGrupo, int posicao)
            : base (posicao)
        {
            if (string.IsNullOrEmpty(nomeCampeonato))
                throw new ArgumentNullException("nomeCampeonato");
            if (string.IsNullOrEmpty(nomeFase))
                throw new ArgumentNullException("nomeFase");
            if (string.IsNullOrEmpty(nomeGrupo))
                throw new ArgumentNullException("nomeGrupo");

            _campeonato = new Campeonato(nomeCampeonato);
            _fase = new Fase(nomeFase);
            _grupo = new Grupo(nomeGrupo);


        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return base.ToString();
        }

        public void Copy(Model.Campeonatos.CampeonatoPosicao entry)
        {
            base.Copy((Model.DadosBasicos.HighLightItem)entry);
            _campeonato = entry._campeonato;
            _fase = entry._fase;
            _grupo = entry._grupo;            
        }

        #endregion
    }
}
