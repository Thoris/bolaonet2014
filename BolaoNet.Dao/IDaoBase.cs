using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BolaoNet.Dao
{
    public interface IDaoBase
    {
        //IList<Framework.DataServices.Model.EntityBaseData> ConvertToList(DataTable table);
        //Framework.DataServices.Model.EntityBaseData ConvertToObject(DataRow row);

        Framework.DataServices.Model.EntityBaseData Load(string currentUser, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription);
        bool Insert(string currentUser, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription);
        bool Update(string currentUser, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription);
        bool Delete(string currentUser, Framework.DataServices.Model.EntityBaseData entry, out int errorNumber, out string errorDescription);
        IList<Framework.DataServices.Model.EntityBaseData> SelectAll(string currentUser, string condition, out int errorNumber, out string errorDescription);
        IList<Framework.DataServices.Model.EntityBaseData> SelectPage(string currentUser, string condition, string order, int pageNumber, int pageSize, out int errorNumber, out string errorDescription);
        int SelectCount(string currentUser, string condition, out int errorNumber, out string errorDescription);


        IList<Framework.DataServices.Model.EntityBaseData> SelectCombo(string currentUser, out int errorNumber, out string errorDescription, params object [] fields);
        
        System.Configuration.ConnectionStringSettings ConnectionStringSetting { get;  }

    }

}
