using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Dao.Boloes
{
    public interface IDaoApostaExtraUsuario : IDaoBase
    {
        IList<Framework.DataServices.Model.EntityBaseData> SelectByUser(string currentUser, Model.Boloes.Bolao bolao, string userName, string condition, out int errorNumber, out string errorDescription);
        IList<Framework.DataServices.Model.EntityBaseData> SelectByPosicao(string currentUser, Model.Boloes.Bolao bolao, int posicao, string condition, out int errorNumber, out string errorDescription);

        
    }
}
