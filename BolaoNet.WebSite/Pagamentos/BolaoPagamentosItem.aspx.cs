using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Collections.Generic;

namespace BolaoNet.WebSite.Pagamentos
{
    public partial class BolaoPagamentosItem : BolaoUserBasePage
    {
        #region Properties
        
        private Model.Boloes.Pagamento Pagamento
        {
            get { return (Model.Boloes.Pagamento)ViewState["entry"]; }
            set { ViewState["entry"] = value; }
        }
        #endregion

        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindUsers();



                //Changing the mode view
                ChangeMode (Business.Util.Mode.GetAction(Request.QueryString["mode"]));


                if (Request.QueryString["DataPagamento"] != null)
                {
                    DateTime date = Convert.ToDateTime(Request.QueryString["DataPagamento"]);

                    Model.Boloes.Pagamento entry = new BolaoNet.Model.Boloes.Pagamento(
                        CurrentBolao.Nome, Request["UserName"].ToString(), date);

                    Business.Boloes.Support.Pagamento business = new BolaoNet.Business.Boloes.Support.Pagamento(base.UserName);
                    business.Copy(entry);

                    business.Load();

                    entry = (Model.Boloes.Pagamento)business;

                    //Pagamento = entry;
                    //ViewState["entry"] = Pagamento;

                    ShowPagamento(entry);
                }
            }
        }
        #endregion

        #region Methods
        
        private void ChangeMode(Business.Util.ActionMode mode)
        {
            switch (mode)
            {
                case BolaoNet.Business.Util.ActionMode.Insert:

                    this.cboUser.Enabled = true;
                    this.txtDataPagamento.Enabled = true;
                    this.txtDescricao.Enabled = true;
                    this.txtValor.Enabled = true;
                    this.cboTipoPagamento.Enabled = true;

                    this.lblBolao.Text = CurrentBolao.Nome;


                    break;

                case BolaoNet.Business.Util.ActionMode.Delete:

                    this.cboUser.Enabled = false;
                    this.txtDataPagamento.Enabled = false;
                    this.txtDescricao.Enabled = false;
                    this.txtValor.Enabled = false;
                    this.cboTipoPagamento.Enabled = false;

                    break;

                case BolaoNet.Business.Util.ActionMode.Edit:

                    this.cboUser.Enabled = false;
                    this.txtDataPagamento.Enabled = false;
                    this.txtDescricao.Enabled = true;
                    this.txtValor.Enabled = true;
                    this.cboTipoPagamento.Enabled = true;


                    break;

                case BolaoNet.Business.Util.ActionMode.View:

                    this.cboUser.Enabled = false;
                    this.txtDataPagamento.Enabled = false;
                    this.txtDescricao.Enabled = false;
                    this.txtValor.Enabled = false;
                    this.cboTipoPagamento.Enabled = false;

                    break;
            }

        }
        private void BindUsers()
        {
            Business.Boloes.Support.Bolao membros = new BolaoNet.Business.Boloes.Support.Bolao(base.UserName, CurrentBolao.Nome);
            IList<Framework.DataServices.Model.EntityBaseData> users = membros.LoadMembros();

            this.cboUser.Items.Add("<Escolha>");
            foreach (Framework.Security.Model.UserData user in users)
            {
                this.cboUser.Items.Add(user.UserName);
            }
        }
        private void ShowPagamento(Model.Boloes.Pagamento entry)
        {
            this.lblBolao.Text = entry.Bolao.Nome;
            this.cboUser.SelectedValue = entry.UserName;
            this.txtDataPagamento.Text = entry.DataPagamento.ToString("dd/MM/yyyy");
            this.txtDescricao.Text = entry.Descricao;
            this.txtValor.Text = entry.Valor.ToString();
            this.cboTipoPagamento.SelectedValue = ((int)entry.TipoPagamento).ToString ();


            
            if (this.lblBolao.Text.Length == 0)
                this.lblBolao.Text = CurrentBolao.Nome;

        }

        private Model.Boloes.Pagamento GetPagamento()
        {
            Model.Boloes.Pagamento entry = Pagamento;

            if (entry == null)
            {
                entry = new BolaoNet.Model.Boloes.Pagamento();
                entry.Bolao = new BolaoNet.Model.Boloes.Bolao(this.lblBolao.Text);
                entry.UserName = this.cboUser.Text;
            }

            entry.TipoPagamento = (BolaoNet.Model.Boloes.Pagamento.Tipo)Convert.ToInt16(this.cboTipoPagamento.SelectedValue);
            entry.DataPagamento = Convert.ToDateTime(this.txtDataPagamento.Text);
            entry.Descricao = this.txtDescricao.Text;
            entry.Valor = Convert.ToDecimal(this.txtValor.Text);

            return entry;


        }

        private void Save()
        {
            Validate("UpdateItem");

            if (!IsValid)
                return;



            Business.Boloes.Support.Pagamento business = new BolaoNet.Business.Boloes.Support.Pagamento(base.UserName);
            business.Copy(GetPagamento());


            if (Business.Util.Mode.GetAction(Request.QueryString["mode"]) == BolaoNet.Business.Util.ActionMode.Insert)
            {
                if (business.Insert())
                {
                    base.ShowMessages("Pagamento inserido com sucesso.");
                }
                else
                {
                    base.ShowErrors("Erro ao inserir o pagamento.");
                }
            }
            else
            {
                if (business.Update ())
                {
                    base.ShowMessages("Pagamento atualizado com sucesso.");
                }
                else
                {
                    base.ShowErrors("Erro ao realizar update do pagamento.");
                }
            }


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
                    Save();
                    break;

                case WebSite.Controls.MenuManager.MenuTools.AddNew:

                    break;

                case WebSite.Controls.MenuManager.MenuTools.Return:
                    Response.Redirect("~/Pagamentos/BolaoPagamentos.aspx");
                    break;

                case WebSite.Controls.MenuManager.MenuTools.Delete:

                    break;

                
                default:
                    break;
            }
        }
        protected void cvUser_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (this.cboUser.SelectedIndex == 0)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }
        protected void cvTipo_ServerValidate(object source, ServerValidateEventArgs args)
        {

            if (this.cboTipoPagamento.SelectedIndex == 0)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }
        #endregion

    }
}
