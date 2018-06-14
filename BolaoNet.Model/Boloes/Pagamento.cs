using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Model.Boloes
{
    [Serializable]
    public class Pagamento : Framework.DataServices.Model.EntityBaseData
    {
        #region Enumerations
        public enum Tipo
        {
            Dinheiro = 1,
            Cheque = 2,
            Deposito = 3,

        }
        #endregion

        #region Variables   
        private Bolao _bolao = new Bolao();
        private string _userName;
        private Tipo _tipoPagamento = Tipo.Dinheiro;
        private DateTime _dataPagamento;

        private decimal _valor;
        private string _descricao;
        #endregion

        #region Properties
        public Bolao Bolao
        {
            get { return _bolao; }
            set { _bolao = value; }
        }
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        public DateTime DataPagamento
        {
            get { return _dataPagamento; }
            set { _dataPagamento = value; }
        }
        public Tipo TipoPagamento
        {
            get { return _tipoPagamento; }
            set { _tipoPagamento = value; }
        }
        public decimal Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }
        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }
        #endregion

        #region Constructors/Destructors
        public Pagamento()
        {

        }
        public Pagamento(string nomeBolao, string userName, DateTime dataPagamento)
        {
            _bolao = new Bolao(nomeBolao);
            _userName = userName;
            _dataPagamento = dataPagamento;            
        }
        #endregion

        #region Methods
        public void Copy(Pagamento entry)
        {
            _bolao = entry._bolao;
            _dataPagamento = entry._dataPagamento;
            _descricao = entry._descricao;
            _tipoPagamento = entry._tipoPagamento;
            _userName = entry._userName;
            _valor = entry._valor;


            base.Copy(entry);
        }
        #endregion


    }
}
