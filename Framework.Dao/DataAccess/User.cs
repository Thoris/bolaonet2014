using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Framework.DataServices;

namespace Framework.Dao.DataAccess
{
    public class User : ItemPaging
    {
        

        #region Variables
        #endregion

        #region Constructors/Destructors
        public User()
            : base(Constants.DefaultTableUsers)
        {
            
        }
        
        public User(string connectionName)
            : base(connectionName, Constants.DefaultTableUsers)
        {
        }

        public User(string connectionName, string connectionString, string providerName)
            : base(connectionName, connectionString, providerName, Constants.DefaultTableUsers)
        { 
        }


        #endregion

        #region Methods

        //public Business.Object.User Select(string currentLogin, string login, out int errorNumber, out string errorDescription)
        //{
        //    errorNumber = 0;
        //    errorDescription = string.Empty;

        //    if (string.IsNullOrEmpty(login))
        //        throw new ArgumentNullException("login");
                

        //    DataTable table = base.ExecuteFill(_commandType, _commandSelect,
        //        false, currentLogin,
        //        base.Parameters.Create("login", DbType.String, login));


        //    if (table.Rows.Count == 0)
        //        throw new Exception("User not found.");


        //    Business.Object.User user = new Framework.Dao.Business.Object.User();
        //    user.LoadFromRow(table.Rows[0]);

            

        //    return user;
        //}


        public bool Delete(string currentLogin, string login, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = string.Empty;

            if (string.IsNullOrEmpty(login))
                throw new ArgumentNullException("login");


            int result = base.ExecuteNonQuery (_commandType, _commandDelete,
                true, currentLogin, 
                base.Parameters.Create ("login", DbType.String, login));


            return result == 0 ? false : true;
        }
        #endregion
    }
}
