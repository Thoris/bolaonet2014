using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BolaoNet.Model.DadosBasicos
{
    [Serializable]
    public class HighLightItem : Framework.DataServices.Model.EntityBaseData
    {
        #region Variables
        private int _posicao = 0;
        private string _titulo;
        private Color _backColor;
        private Color _foreColor;


        #endregion

        #region Properties
        public string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }
        public Color ForeColor
        {
            get { return _foreColor; }
            set { _foreColor = value; }
        }
        public Color BackColor
        {
            get { return _backColor; }
            set { _backColor = value; }
        }
        
        public int Posicao
        {
            get { return _posicao; }
            set { _posicao = value; }
        }
        #endregion

        #region Constructors/Destructors
        public HighLightItem()
        {
        }
        public HighLightItem(int posicao)
        {
            if (posicao == 0)
                throw new ArgumentNullException("posicao");

            _posicao = posicao;

        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return base.ToString();
        }

        public void Copy(Model.DadosBasicos.HighLightItem entry)
        {
            _backColor = entry._backColor;
            _foreColor = entry._foreColor;
            _posicao = entry._posicao;
            _titulo = entry._titulo;

        }

        #endregion
    }
}
