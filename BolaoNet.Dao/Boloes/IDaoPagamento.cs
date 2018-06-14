using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Dao.Boloes
{
    public interface IDaoPagamento : IDaoBase
    {
        IList<Framework.DataServices.Model.EntityBaseData> SelectAllByBolao(string currentUser, Model.Boloes.Bolao bolao, string condition, out int errorNumber, out string errorDescription);
        

    }
}
