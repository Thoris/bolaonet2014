using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace BolaoNet.WebSite
{
    public partial class DBConnectionTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Business.Boloes.Support.Bolao bolao = new BolaoNet.Business.Boloes.Support.Bolao("thoris", "Copa do Mundo 2010");
            bolao.LoadAllPontosDataByUser(new Framework.Security.Model.UserData("Thoris"));



            this.lblSqlServerCnnStr.Text = System.Configuration.ConfigurationManager.ConnectionStrings["DBProvider"].ConnectionString;
        }

        protected void btnTestSqlServer_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(this.lblSqlServerCnnStr.Text);

            try
            {
                connection.Open();
                connection.Close();

                this.lblStatusSql.Text = "Conexão estabelecida com sucesso.";
            }
            catch (Exception ex)
            {
                this.lblStatusSql.Text = "Erro ao se conectar no banco. " + ex.Message;
            }
        }

        protected void btnLoadFactories_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable table = System.Data.Common.DbProviderFactories.GetFactoryClasses();

                this.GridView1.DataSource = table;
                this.GridView1.DataBind();

                this.lblStatusFactories.Text = "Factories carregados com sucesso.";
            }
            catch (Exception ex)
            {
                this.lblStatusFactories.Text = "Erro ao carregar os factories. " + ex.Message;
            }
        }

        protected void btnTestConnection_Click(object sender, EventArgs e)
        {
            try
            {

                Framework.DataServices.CommonDatabase db = new Framework.DataServices.CommonDatabase("DBProvider");
                db.Open();
                db.Close();

                this.lblStatusCommon.Text = "Conexão estabelecida com sucesso.";
            }
            catch (Exception ex)
            {
                this.lblStatusCommon.Text = "Erro ao estabelecer a conexão." + ex.Message;
            }
        }

        protected void btnTestWithSqlServer_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBProvider"].ConnectionString);
                SqlCommand command = new SqlCommand(this.lblSelect.Text, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable table = new DataTable();

                adapter.Fill(table);

                this.GridView2.DataSource = table;
                this.GridView2.DataBind();

                this.lblStatusSelectSql.Text = "Select executado com exito.";


            }
            catch (Exception ex)
            {
                this.lblStatusSelectSql.Text = "Erro ao executar o select." + ex.Message;

            }
        }

        protected void btnTestCommon_Click(object sender, EventArgs e)
        {
            try
            {
             
                DataTable table = new DataTable();

                Framework.DataServices.CommonDatabase db = new Framework.DataServices.CommonDatabase("DBProvider");
                table = db.ExecuteFill(CommandType.Text, this.lblSelect.Text, false, "Thoris");


                this.GridView3.DataSource = table;
                this.GridView3.DataBind();

                this.lblStatusSelectCommon.Text = "Select executado com exito.";


            }
            catch (Exception ex)
            {
                this.lblStatusSelectCommon.Text = "Erro ao executar o select." + ex.Message;

            }

        }

        protected void btnTestInserCommand_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnTestInsertCommon_Click(object sender, EventArgs e)
        {
            try
            {
                Framework.DataServices.CommonDatabase db = new Framework.DataServices.CommonDatabase("DBProvider");
                db.ExecuteNonQuery(CommandType.Text, "INSERT INTO Users (UserName) VALUES ('XXXXYYYY')", false, "thoris");

            }
            catch (Exception ex)
            {
                this.lblStatusIUDCommon.Text = "Erro ao inserir o registro. " + ex.Message;
                return;
            }

            try
            {
                Framework.DataServices.CommonDatabase db = new Framework.DataServices.CommonDatabase("DBProvider");
                db.ExecuteNonQuery(CommandType.Text, "UPDATE Users SET CreatedBy = 'test' WHERE UserName ='XXXXYYYY'", false, "thoris");

            }
            catch (Exception ex)
            {
                this.lblStatusIUDCommon.Text = "Erro ao atualizar o registro. " + ex.Message;
                return;
            }


            try
            {
                Framework.DataServices.CommonDatabase db = new Framework.DataServices.CommonDatabase("DBProvider");
                db.ExecuteNonQuery(CommandType.Text, "DELETE FROM Users WHERE UserName ='XXXXYYYY'", false, "thoris");

                this.lblStatusIUDCommon.Text = "Dados atualizados com sucesso.";
            }
            catch (Exception ex)
            {
                this.lblStatusIUDCommon.Text = "Erro ao excluir o registro. " + ex.Message;
                return;
            }
        }

        protected void btnLoadUsers_Click(object sender, EventArgs e)
        {
            try
            {
                int total = 0;

                this.GridView4.DataSource = Membership.Provider.GetAllUsers(0, 10, out total);
                this.GridView4.DataBind();
            }
            catch (Exception ex)
            {
                this.lblStatusProviderUser.Text = "Erro ao atualizar os dados do provider. " + ex.Message + ". " + ex.StackTrace;
            }
        }
    }
}
