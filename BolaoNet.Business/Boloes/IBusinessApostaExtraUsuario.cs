using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Business.Boloes
{
    public interface IBusinessApostaExtraUsuario : IBusinessBase
    {
        IList<Framework.DataServices.Model.EntityBaseData> SelectByUser(Model.Boloes.Bolao bolao, string userName, string condition);
        IList<Framework.DataServices.Model.EntityBaseData> SelectByPosicao(Model.Boloes.Bolao bolao, int posicao, string condition);
        
    }
}
