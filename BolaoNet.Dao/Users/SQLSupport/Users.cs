using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace BolaoNet.Dao.Users.SQLSupport
{
    public class Users : Framework.DataServices.ItemPaging, IDaoUsers
    {
        #region Variables
        #endregion

        #region Constructors/Destructors
        public Users()
            : base ("")
        {
        }

        public Users(string connectionName)
            : base (connectionName, "")
        {
        }

        public Users(string connectionName, string connectionString, string providerName)
            : base(connectionName, connectionString, providerName, "")
        {
        } 
        #endregion

        #region Methods
        //public static IList<Model.Users.UserBoloes> ConvertUserBoloesToList(DataTable table)
        //{
        //    IList<Model.Users.UserBoloes> list = new List<Model.Users.UserBoloes>();

        //    foreach (DataRow row in table.Rows)
        //    {
        //        list.Add(ConvertUserBoloesToObject(row));
        //    }

        //    return list;
        //}
        //public static Model.Users.UserBoloes ConvertUserBoloesToObject(DataRow row)
        //{

        //    Model.Users.UserBoloes entry = new Model.Users.UserBoloes();

        //    if (row.Table.Columns.Contains("NomeBolao") && !Convert.IsDBNull(row["NomeBolao"]))
        //    {
        //        entry.Bolao = new Model.Boloes.Bolao (Convert.ToString(row["NomeBolao"]));
        //    }

        //    if (row.Table.Columns.Contains("NomeCampeonato") && !Convert.IsDBNull(row["NomeCampeonato"]))
        //    {
        //        entry.Bolao.Campeonato  = new Model.Campeonatos.Campeonato  (Convert.ToString(row["Nomecampeonato"]));
        //    }

        //    if (row.Table.Columns.Contains("Position") && !Convert.IsDBNull(row["Position"]))
        //    {
        //        entry.Position = Convert.ToInt32(row["Position"]);
        //    }

        //    if (row.Table.Columns.Contains("Membros") && !Convert.IsDBNull(row["Membros"]))
        //    {
        //        entry.Membros = Convert.ToInt32(row["Membros"]);
        //    }

        //    entry.LoadDataRow(row);

        //    return entry;

        //}



        //public static IList<Model.Users.UserPagamentos> ConvertUserPagamentosToList(DataTable table)
        //{
        //    IList<Model.Users.UserPagamentos> list = new List<Model.Users.UserPagamentos>();

        //    foreach (DataRow row in table.Rows)
        //    {
        //        list.Add(ConvertUserPagamentosToObject(row));
        //    }

        //    return list;
        //}
        //public static Model.Users.UserPagamentos ConvertUserPagamentosToObject(DataRow row)
        //{

        //    Model.Users.UserPagamentos entry = new Model.Users.UserPagamentos();

        //    if (row.Table.Columns.Contains("NomeBolao") && !Convert.IsDBNull(row["NomeBolao"]))
        //    {
        //        entry.Bolao = new Model.Boloes.Bolao(Convert.ToString(row["NomeBolao"]));
        //    }

        //    if (row.Table.Columns.Contains("Valor") && !Convert.IsDBNull(row["Valor"]))
        //    {
        //        entry.Valor = Convert.ToDecimal(row["Valor"]);
        //    }

        //    if (row.Table.Columns.Contains("TaxaParticipacao") && !Convert.IsDBNull(row["TaxaParticipacao"]))
        //    {
        //        entry.Total = Convert.ToDecimal(row["TaxaParticipacao"]);
        //    }

        //    if (row.Table.Columns.Contains("DataInicio") && !Convert.IsDBNull(row["DataInicio"]))
        //    {
        //        entry.DataInicio = Convert.ToDateTime(row["DataInicio"]);
        //    }

        //    entry.LoadDataRow(row);

        //    return entry;

        //}


        #endregion

        #region IDaoUsers Members

        public IList<Model.Users.UserBoloes> LoadBoloes(string currentUser, string userName, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;


            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, "sp_Users_Load_Boloes", true, currentUser,
                base.Parameters.Create("@UserName", DbType.String, userName),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );


            return Util.UserBoloes.ConvertUserBoloesToList (table);
        }

        public IList<Model.Users.UserPagamentos> LoadPagamentos(string currentUser, string userName, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;


            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, "sp_Users_Load_Pagamentos", true, currentUser,
                base.Parameters.Create("@UserName", DbType.String, userName),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );


            return Util.UserPagamentos.ConvertUserPagamentosToList(table);
        }

        public IList<Framework.DataServices.Model.EntityBaseData> LoadMensagens(string currentUser, string userName, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;


            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, "sp_Users_Load_Mensagens", true, currentUser,
                base.Parameters.Create("@UserName", DbType.String, userName),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null)
                );


            return Boloes.Util.Mensagem.ConvertToList(table);
        }

        #endregion
    }
}
