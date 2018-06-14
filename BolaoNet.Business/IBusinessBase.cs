using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Business
{
    public interface IBusinessBase
    {
        bool Insert();
        bool Update();
        bool Delete();
        bool Load();

        IList<Framework.DataServices.Model.EntityBaseData> SelectAll(string condition);
        IList<Framework.DataServices.Model.EntityBaseData> SelectPage(string condition, string order, int pageNumber, int pageSize);
        int SelectCount(string condition);
        IList<Framework.DataServices.Model.EntityBaseData> SelectCombo(params object [] fields);

        BolaoNet.Dao.IDaoBase DaoBase { get; }
    }
}
