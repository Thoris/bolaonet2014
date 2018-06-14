using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Dao.Campeonatos
{
    public interface IDaoCampeonatoPosicoes 
    {
        IList<Framework.DataServices.Model.EntityBaseData> SelectPosicoes(string currentUser, Model.Campeonatos.Campeonato campeonato, Model.Campeonatos.Fase fase, Model.Campeonatos.Grupo grupo, out int errorNumber, out string errorDescription);
        
    }
}
