using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Dao.Boloes
{
    public interface IDaoBoloesPontuacao
    {
        IList<Framework.DataServices.Model.EntityBaseData> SelectPontuacao(string currentUser, Model.Boloes.Bolao bolao, out int errorNumber, out string errorDescription);
        
    }
}
