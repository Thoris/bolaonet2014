using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Dao.Boloes
{
    public interface IDaoApostaExtra : IDaoBase
    {
        bool InsertResult(string currentUser, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription);
        
    }
}
