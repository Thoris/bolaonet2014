using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Business.Users
{
    public interface IBusinessUser 
    {
        IList<Model.Users.UserBoloes> LoadBoloes();
        IList<Model.Users.UserPagamentos> LoadPagamentos();

        IList<Framework.DataServices.Model.EntityBaseData> LoadMensagens();
    }
}
