using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Dao.Boloes
{
    public interface IDaoMensagens : IDaoBase
    {
        bool AddMessage(string currentUser, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription);


        IList<Framework.DataServices.Model.EntityBaseData> LoadMessagesUser(string currentUser, Framework.Security.Model.UserData user, Model.Boloes.Bolao bolao, out int errorNumber, out string errorDescription);
    }
}
