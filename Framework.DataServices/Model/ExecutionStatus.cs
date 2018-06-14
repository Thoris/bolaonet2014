using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Framework.DataServices.Model
{
    public class ExecutionStatus
    {
        #region Variables
        private string _errorDescription = null;
        private int _errorNumber = 0;
        private string _currentUser = null;
        private DbCommand _command = null;
        #endregion

        #region Properties
        public string ErrorDescription
        {
            get { return _errorDescription; }
        }
        public int ErrorNumber
        {
            get { return _errorNumber; }
        }
        public string CurrentUser
        {
            get { return _currentUser; }
        }
        public DbCommand Command
        {
            get { return _command; }
        }
        #endregion

        #region Constructors/Destructors
        public ExecutionStatus(DbCommand command)
        {
            _command = command;
        }
        public ExecutionStatus(DbCommand command, string currentUser, int errorNumber, string errorDescription)
        {
            _command = command;
            _currentUser = currentUser;
            _errorNumber = errorNumber;
            _errorDescription = errorDescription;
        }
        #endregion

    }
}
