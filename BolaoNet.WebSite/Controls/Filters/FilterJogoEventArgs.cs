using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace BolaoNet.WebSite.Controls.Filters
{
    public class FilterJogoEventArgs
    {
        #region Variables
        private int _rodada = 0;
        private DateTime _dataInicial = DateTime.MinValue;
        private DateTime _dataFinal = DateTime.MinValue;
        private string _time = null;
        private string _grupo = null;
        private string _fase = null;
        #endregion

        #region Properties
        public int Rodada
        {
            get { return _rodada; }
        }
        public DateTime DataInicial
        {
            get { return _dataInicial; }
        }
        public DateTime DataFinal
        {
            get { return _dataFinal; }
        }
        public string Time
        {
            get { return _time; }
        }
        public string Fase
        {
            get { return _fase; }
        }
        public string Grupo
        {
            get { return _grupo; }
        }
        #endregion

        #region Constructors/Destructors
        public FilterJogoEventArgs(int rodada, DateTime dataInicial, DateTime dataFinal, string time, string fase, string grupo)
        {
            _rodada = rodada;
            _dataInicial = dataInicial;
            _dataFinal = dataFinal;
            _time = time;
            _grupo = grupo;
            _fase = fase;
        }
        #endregion

    }
}
