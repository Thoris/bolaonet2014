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
using System.Collections.Generic;

namespace BolaoNet.WebSite.Boloes.Admin
{
    public partial class BolaoCarregarExcel : BolaoUserBasePage
    {
        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Business.Boloes.Support.Bolao business = new BolaoNet.Business.Boloes.Support.Bolao(base.UserName, CurrentBolao.Nome);
                IList<Framework.DataServices.Model.EntityBaseData> list = business.LoadMembros();


                DropDownList cboUsers = (DropDownList)this.MultiViewType.FindControl("cboUsers");

                cboUsers.DataSource = list;
                cboUsers.DataBind();



                business.Load();

                if (business.IsIniciado && business.ApostasApenasAntes)
                {
                    this.btnSalvarExisting.Enabled = false;
                    this.btnSalvarNew.Enabled = false;
                }
                else
                {
                    this.btnSalvarExisting.Enabled = true;
                    this.btnSalvarNew.Enabled = true;
                }

            }
        }
        #endregion

        #region Methods
        private Framework.Security.Model.UserData GetUserData()
        {
            Framework.Security.Model.UserData user = new Framework.Security.Model.UserData();

            user.UserName = this.txtUserName.Text;
            user.Password = this.txtSenha.Text;
            user.Email = this.txtEmail.Text;
            user.FullName = this.txtNome.Text;


            return user;


        }
        #endregion

        #region Events
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            this.ctlMenuTools.ButtonClick += new CommandEventHandler(ctlMenuTools_ButtonClick);
            this.ctlNavigateHomeControl.ButtonClick += new CommandEventHandler(ctlNavigateHomeControl_ButtonClick);

        }
        private void ctlNavigateHomeControl_ButtonClick(object sender, CommandEventArgs e)
        {
            base.NavigateHome();
        }
        private void ctlMenuTools_ButtonClick(object sender, CommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case WebSite.Controls.MenuManager.MenuTools.Save:
                    //Save();
                    break;

                default:
                    break;
            }
        }
        protected void rdoList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.rdoList.Items[0].Selected)
            {
                this.MultiViewType.ActiveViewIndex = 0;
            }
            else
            {
                this.MultiViewType.ActiveViewIndex = 1;
            }
        }

        protected void btnSalvarNew_Click(object sender, EventArgs e)
        {
            if (!IsValid)
                return;

            if (!this.FileUploadNewUser.HasFile)
            {
                ShowErrors("É necessário selecionar um arquivo para atualização.");
                return;
            }

            if (!this.FileUploadNewUser.FileName.ToLower().EndsWith(".xls"))
            {
                ShowErrors("O arquivo selecionado não é um formato de excel e não pode ser atualizado.");
                return;
            }

            //Buscando os dados do usuário
            Framework.Security.Model.UserData user = GetUserData ();


            string newFile = Server.MapPath("~/ExcelFiles/" + user.UserName + ".xls");

            if (System.IO.File.Exists(newFile))
                System.IO.File.Delete(newFile);


            //Salvando o arquivo
            this.FileUploadNewUser.SaveAs(newFile);
  
            //Criando o objeto para ser lido e armazenado
            Business.Excel.ITemplateExcelBase excelBusiness = new Business.Excel.TemplateExcelBase(base.UserName, newFile);

            try
            {
                if (excelBusiness.SaveUserFile(CurrentBolao, CurrentCampeonato, user))
                {
                    ShowMessages("Apostas do excel armazenada com sucesso para o usuário " + user.UserName);
                }
                else
                {
                    ShowErrors("Não foi possível armazenar os dados do usuário.");
                }
            }
            catch (Exception ex)
            {
                ShowErrors(ex.Message);
            }

        }

        protected void btnSalvarExisting_Click(object sender, EventArgs e)
        {
            if (!IsValid)
                return;

            if (!this.FileUploadExisting.HasFile)
            {
                ShowErrors("É necessário selecionar um arquivo para atualização.");
                return;
            }

            if (!this.FileUploadExisting.FileName.ToLower().EndsWith(".xls"))
            {
                ShowErrors("O arquivo selecionado não é um formato de excel e não pode ser atualizado.");
                return;
            }

            //Buscando os dados do usuário
            Framework.Security.Model.UserData user = new Framework.Security.Model.UserData(this.cboUsers.Text);


            string newFile = Server.MapPath("~/ExcelFiles/" + user.UserName + ".xls");

            if (System.IO.File.Exists(newFile))
                System.IO.File.Delete(newFile);


            //Salvando o arquivo
            this.FileUploadExisting.SaveAs(newFile);

            //Criando o objeto para ser lido e armazenado
            Business.Excel.ITemplateExcelBase excelBusiness = new Business.Excel.TemplateExcelBase(base.UserName, newFile);

            if (excelBusiness.SaveExisitingUserFile(CurrentBolao, CurrentCampeonato, user))
            {
                ShowMessages("Apostas do excel armazenada com sucesso para o usuário " + user.UserName);
            }
            else
            {
                ShowErrors("Não foi possível armazenar os dados do usuário.");
            }



        }
        #endregion

        protected void cvArquivoNew_ServerValidate(object source, ServerValidateEventArgs args)
        {

        }


    }
}
