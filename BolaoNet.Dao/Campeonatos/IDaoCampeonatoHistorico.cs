using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Dao.Campeonatos
{
    public interface IDaoCampeonatoHistorico
    {
        IList<Framework.DataServices.Model.EntityBaseData> LoadHistorico(string currentUser, Model.Campeonatos.Campeonato entry, string condition, out int errorNumber, out string errorDescription);
        
    }
}
