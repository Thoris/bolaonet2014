using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Business.Boloes
{
    public interface IBusinessRegras : IBusinessBase
    {
        IList<Framework.DataServices.Model.EntityBaseData> SelectAllFromBolao(Model.Boloes.Bolao bolao, string condition);
        

    }
}
