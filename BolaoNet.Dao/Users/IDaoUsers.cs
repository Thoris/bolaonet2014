using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Dao.Users
{
    public interface IDaoUsers
    {
        IList<Model.Users.UserBoloes> LoadBoloes(string currentUser, string userName, out int errorNumber, out string errorDescription);
        IList<Model.Users.UserPagamentos> LoadPagamentos(string currentUser, string userName, out int errorNumber, out string errorDescription);

        IList<Framework.DataServices.Model.EntityBaseData> LoadMensagens(string currentUser, string userName, out int errorNumber, out string errorDescription); 
    
    }
}
