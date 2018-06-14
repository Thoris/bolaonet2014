using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Framework.DataServices
{
    public interface IItemPaging
    {
        string CommandUpdate {get;set;}
        string CommandInsert{get;set;}
        string CommandSelect{get;set;}
        string CommandDelete{get;set;}
        string CommandSelectAll{get;set;}
        string CommandSelectPage{get;set;}
        string CommandSelectCount { get; set; }
        
        string TableName {get;}


        DataTable GetPage(
            string fields, string where, string order, int pageNumber, int pageSize,
            bool defaultParameters, string currentUser,
            out int errorNumber, out string errorDescription);


        int GetCount(
            string where,
            bool defaultParameters, string currentUser,
            out int errorNumber, out string errorDescription);
        
    }
}
