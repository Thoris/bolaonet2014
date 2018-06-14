using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Model.Boloes
{
    [Serializable]
    public class BolaoRequest : Framework.DataServices.Model.EntityBaseData
    {
        #region Enumeration
        public enum Status
        {
            Participar = 1,
            Retirar = 2,
            Aprovado = 3,
            Rejeitado =4 ,
            Removido = 5,
            Mantido = 6,
            Convidado = 7,
        }
        #endregion

        #region Variables
        private int _requestID;
        private Bolao _bolao = new Bolao();
        private string _requestedBy;
        private DateTime _requestedDate;
        private string _owner;
        private Status _statusRequestID;
        private string _answeredBy;
        private DateTime _answeredDate;
        private string _descricao;
        #endregion

        #region Properties
        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }
        public DateTime AnsweredDate
        {
            get { return _answeredDate; }
            set { _answeredDate = value; }
        }
        public string AnsweredBy
        {
            get { return _answeredBy; }
            set { _answeredBy = value; }
        }
        public Status StatusRequestID
        {
            get { return _statusRequestID; }
            set { _statusRequestID = value; }
        }
        public string Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }
        public DateTime RequestedDate
        {
            get { return _requestedDate; }
            set { _requestedDate = value; }
        }
        public string RequestedBy
        {
            get { return _requestedBy; }
            set { _requestedBy = value; }
        }
        public int RequestID
        {
            get { return _requestID; }
            set { _requestID = value; }
        }
        public Bolao Bolao
        {
            get { return _bolao; }
            set { _bolao = value; }
        }

        #endregion

        #region Constructors/Destructors
        public BolaoRequest()
        {

        }
        public BolaoRequest(int requestID, string nomeBolao)
        {
            _requestID = requestID;
            _bolao = new Bolao(nomeBolao);
        }
        #endregion

        #region Methods
        public void Copy(BolaoRequest entry)
        {
            _answeredBy = entry._answeredBy;
            _answeredDate = entry._answeredDate;
            _bolao = entry._bolao;
            _descricao = entry._descricao;
            _owner = entry._owner;
            _requestedBy = entry._requestedBy;
            _requestedDate = entry._requestedDate;
            _requestID = entry._requestID;
            _statusRequestID = entry._statusRequestID;

            
            base.Copy(entry);
        }
        #endregion
    }
}
