using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BolaoNet.Model.Boloes
{
    [Serializable]
    public class BoloesPontuacao : DadosBasicos.HighLightItem
    {
        #region Variables
        private Model.Boloes.Bolao _bolao = null;
        #endregion

        #region Properties
        public Model.Boloes.Bolao Bolao
        {
            get { return _bolao; }
            set { _bolao = value; }
        }
        
        #endregion

        #region Constructors/Destructors
        public BoloesPontuacao()
        {
        }
        public BoloesPontuacao(string nomeBolao, int posicao)
            : base (posicao)
        {
            if (string.IsNullOrEmpty(nomeBolao))
                throw new ArgumentNullException("nomeBolao");
            
            _bolao = new BolaoNet.Model.Boloes.Bolao(nomeBolao);

        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return base.ToString();
        }

        public void Copy(BoloesPontuacao entry)
        {
            base.Copy((Model.DadosBasicos.HighLightItem)entry);
            _bolao = entry._bolao;          
        }

        #endregion
    }
}
