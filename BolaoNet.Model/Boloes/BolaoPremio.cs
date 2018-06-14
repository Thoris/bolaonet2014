using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Model.Boloes
{
    [Serializable]
    public class BolaoPremio : DadosBasicos.HighLightItem
    {
        #region Variables
        private Model.Boloes.Bolao _bolao = new Bolao ();

        #endregion

        #region Properties
        public Model.Boloes.Bolao Bolao
        {
            get { return _bolao; }
            set { _bolao = value; }
        }
        
        #endregion

        #region Constructors/Destructors
        public BolaoPremio()
        {
        }
        public BolaoPremio(string nomeBolao, int posicao)
            : base(posicao)
        {
            if (string.IsNullOrEmpty(nomeBolao))
                throw new ArgumentNullException("nomeBolao");

            _bolao = new Bolao(nomeBolao);

        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return base.ToString();
        }

        public void Copy(Model.Boloes.BolaoPremio entry)
        {
            base.Copy((Model.DadosBasicos.HighLightItem)entry);
            _bolao = entry._bolao;
        }

        #endregion
    }
}
