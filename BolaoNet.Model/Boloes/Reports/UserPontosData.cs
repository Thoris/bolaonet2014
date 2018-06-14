using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Model.Boloes.Reports
{
    public class UserPontosData : BolaoMembros
    {
        #region Variables
        private DateTime _date;
        #endregion

        #region Properties
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }
        #endregion

        #region Constructors / Destructors
        public UserPontosData(BolaoMembros entry)
        {
            base.Copy(entry);
        }
        public UserPontosData()
            : base ()
        {

        }
        public UserPontosData(string userName)
            : base (userName)
        {

        }
        #endregion

    }
}
