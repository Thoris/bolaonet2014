using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Dao.Boloes
{
    public interface IDaoBolaoRegras : IDaoBase
    {
        IList<Framework.DataServices.Model.EntityBaseData> SelectAllFromBolao(string currentUser, Model.Boloes.Bolao bolao, string condition, out int errorNumber, out string errorDescription);
        
    }
}
