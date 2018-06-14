using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Business.Boloes
{
    public interface IBusinessMensagens : IBusinessBase
    {
        bool AddMessage();
        IList<Framework.DataServices.Model.EntityBaseData> LoadMessagesUser(Framework.Security.Model.UserData user, Model.Boloes.Bolao bolao);
        
    }
}
