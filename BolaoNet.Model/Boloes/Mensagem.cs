using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Model.Boloes
{
    [Serializable]
    public class Mensagem : Framework.DataServices.Model.EntityBaseData
    {
        #region Variables
        private long _messageID;
        private Model.Boloes.Bolao _bolao = new Bolao();
        private string _fromUser;
        private string _toUser;
        private bool _private;
        private DateTime _creationDate;
        private string _title;
        private string _message;
        private int _totalRead;
        private long _answeredMessageID;
        private string _fromFullName;
        #endregion

        #region Properties
        public string FromFullName
        {
            get { return _fromFullName; }
            set { _fromFullName = value; }
        }
        public long AnsweredMessageID
        {
            get { return _answeredMessageID; }
            set { _answeredMessageID = value; }
        }
        public int TotalRead
        {
            get { return _totalRead; }
            set { _totalRead = value; }
        }        
        public long MessageID
        {
            get { return _messageID; }
            set { _messageID = value; }
        }
        public Model.Boloes.Bolao Bolao
        {
            get { return _bolao; }
            set { _bolao = value; }
        }
        public string FromUser
        {
            get { return _fromUser; }
            set { _fromUser = value; }
        }
        public string ToUser
        {
            get { return _toUser; }
            set { _toUser = value; }
        }
        public bool Private
        {
            get { return _private; }
            set { _private = value; }
        }
        public DateTime CreationDate
        {
            get { return _creationDate; }
            set { _creationDate = value; }
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        #endregion

        #region Constructors/Destructors
        public Mensagem()
        {
        }
        public Mensagem(long messageID, string fromUser, string nomeBolao)
        {
            _messageID = messageID;
            _fromUser = fromUser;
            _bolao = new Bolao(nomeBolao);
        }
        #endregion

        #region Methods
        public void Copy(Model.Boloes.Mensagem entry)
        {
            _answeredMessageID = entry._answeredMessageID;
            _bolao = entry._bolao;
            _fromUser = entry._fromUser;
            _message = entry._message;
            _messageID = entry._messageID;
            _private = entry._private;
            _title = entry._title;
            _totalRead = entry._totalRead;
            _toUser = entry._toUser;
            _fromFullName = entry._fromFullName;
            base.Copy(entry);
        }
        #endregion
    }
}
