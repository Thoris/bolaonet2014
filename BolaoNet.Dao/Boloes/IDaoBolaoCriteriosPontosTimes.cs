using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Dao.Boloes
{
    public interface IDaoBolaoCriteriosPontosTimes
    {

        IList<Framework.DataServices.Model.EntityBaseData> LoadCriteriosPontosTimes(string currentUser, Model.Boloes.Bolao bolao, string condition, out int errorNumber, out string errorDescription);
        bool UpdateCriterioPontosTimes(string currentUser, Model.Boloes.BolaoCriterioPontosTimes entry, out int errorNumber, out string errorDescription);
        
    }
}
