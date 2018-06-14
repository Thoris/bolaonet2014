using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Business.Boloes
{
    public interface IBusinessPagamento : IBusinessBase
    {
        IList<Framework.DataServices.Model.EntityBaseData> SelectAllByBolao(Model.Boloes.Bolao bolao, string condition);
        
    }
}
