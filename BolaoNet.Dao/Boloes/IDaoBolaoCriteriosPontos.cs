using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Dao.Boloes
{
    public interface IDaoBolaoCriteriosPontos
    {

        IList<Framework.DataServices.Model.EntityBaseData> LoadCriteriosPontos(string currentUser, Model.Boloes.Bolao bolao, string condition, out int errorNumber, out string errorDescription);
        bool UpdateCriterioPontos(string currentUser, Model.Boloes.BolaoCriterioPontos entry, out int errorNumber, out string errorDescription);
        
    }
}
