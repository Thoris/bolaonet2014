using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Dao.Boloes
{
    public interface IDaoBolaoRequests
    {
        bool BolaoParticipar(string currentUser, Model.Boloes.BolaoRequest request, out int errorNumber, out string errorDescription);
        bool BolaoChangeStatus(string currentUser, Model.Boloes.BolaoRequest request, out int errorNumber, out string errorDescription);
        IList<Framework.DataServices.Model.EntityBaseData> SelectRequestsAll(string currentUser, string condition, out int errorNumber, out string errorDescription);
        IList<Framework.DataServices.Model.EntityBaseData> SelectRequestsAll(string currentUser, Model.Boloes.Bolao bolao, string condition, out int errorNumber, out string errorDescription);


        IList<Framework.DataServices.Model.EntityBaseData> SelectRequestsPendentes(string currentUser, Model.Boloes.Bolao bolao, string condition, out int errorNumber, out string errorDescription);
        

    }
}
