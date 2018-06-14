using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Framework.DataServices
{
    public interface IPagingDatabase
    {
        DataTable GetPage(string procedurePaging,
            string fields, string from, string where, string order, int pageNumber, int pageSize,
            bool defaultParameters, string currentUser,
            out int errorNumber, out string errorDescription);


        int GetCount(string procedurePaging,
            string from, string where, int pageNumber, int pageSize,
            bool defaultParameters, string currentUser,
            out int errorNumber, out string errorDescription);

    }
}
