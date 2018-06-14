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

namespace BolaoNet.WebSite.Apostas
{
    public partial class BolaoParticipacao : UserBasePage
    {
        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }


            BindMeusBoloes();
            BindBoloesDisponiveis();
        }
        #endregion

        #region Methods
        private void BindBoloesDisponiveis()
        {
            Business.Boloes.Support.Bolao business = new BolaoNet.Business.Boloes.Support.Bolao(base.UserName);

            IList<Framework.DataServices.Model.EntityBaseData> list =
                    business.SelectAllEnabled(null);


            if (ViewState["MeusBoloes"] != null)
            {
                IList<Framework.DataServices.Model.EntityBaseData> meusBoloesList =
                    (IList<Framework.DataServices.Model.EntityBaseData>)ViewState["MeusBoloes"];


                for (int c = 0; c < list.Count; c++)
                {
                    Model.Boloes.Bolao bolaoCorrente = (Model.Boloes.Bolao)list[c];

                    foreach (Model.Boloes.Bolao meuBolao in meusBoloesList)
                    {
                        if (string.Compare(meuBolao.Nome, bolaoCorrente.Nome, true) == 0)
                        {
                            list.RemoveAt(c);
                            c--;
                            break;
                        }
                    }
                }
            }


            this.dtlBolaoDisponiveis.DataSource = list;
            this.dtlBolaoDisponiveis.DataBind();
        }
        private void BindMeusBoloes()
        {
            Business.Boloes.Support.Bolao business = new BolaoNet.Business.Boloes.Support.Bolao(base.UserName);

            IList<Framework.DataServices.Model.EntityBaseData> list =
                    business.LoadBoloes(new Framework.Security.Model.UserData(base.UserName));

            this.dtlBolao.DataSource = list;
            this.dtlBolao.DataBind();

            ViewState["MeusBoloes"] = list;
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
            
        }
        protected void dtlBolao_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            Label lblBolao = (Label)e.Item.FindControl("lblBolao");
            LinkButton lnkRemove = (LinkButton)e.Item.FindControl("lnkRemove");


            Model.Boloes.Bolao bolao = (Model.Boloes.Bolao)e.Item.DataItem;
            Image imgBolao = (Image)e.Item.FindControl("imgBolao");

            imgBolao.ImageUrl = "/Images/Database/Boloes/" + bolao.Nome + ".jpg";
            imgBolao.DescriptionUrl = bolao.Nome;

            lnkRemove.CommandArgument = bolao.Nome;

        }
        protected void dtlBolaoDisponiveis_ItemDataBound(object sender, DataListItemEventArgs e)
        {

            Model.Boloes.Bolao bolao = (Model.Boloes.Bolao)e.Item.DataItem;
            Image imgBolao = (Image)e.Item.FindControl("imgBolao");

            imgBolao.ImageUrl = "/Images/Database/Boloes/" + bolao.Nome + ".jpg";
            imgBolao.DescriptionUrl = bolao.Nome;


            LinkButton lnkAdicionar = (LinkButton)e.Item.FindControl("lnkAdicionar");
            lnkAdicionar.CommandArgument = bolao.Nome;

        }
        protected void lnkRemove_Click(object sender, EventArgs e)
        {
            LinkButton objSender = (LinkButton)sender;

            string nomeBolao = objSender.CommandArgument;


            Business.Boloes.Support.Bolao bolao = new BolaoNet.Business.Boloes.Support.Bolao(base.UserName, nomeBolao);
            if (bolao.DeleteMembro(new Framework.Security.Model.UserData(base.UserName)))
            {
                base.ShowMessages("Você não faz mais parte do bolão " + nomeBolao);
            }
            else
            {
                base.ShowErrors("Erro ao retirar-se do bolão " + nomeBolao);
            }

            BindMeusBoloes();
            BindBoloesDisponiveis();

        }
        protected void lnkAdicionar_Click(object sender, EventArgs e)
        {
            LinkButton objSender = (LinkButton)sender;

            string nomeBolao = objSender.CommandArgument;

            Business.Boloes.Support.Bolao bolao = new BolaoNet.Business.Boloes.Support.Bolao(base.UserName, nomeBolao);

            Model.Boloes.BolaoRequest request = new BolaoNet.Model.Boloes.BolaoRequest();
            request.Bolao = bolao;
            request.RequestedBy = base.UserName;
            request.StatusRequestID = BolaoNet.Model.Boloes.BolaoRequest.Status.Participar;

            if (bolao.BolaoParticipar(request))
            {
                base.ShowMessages("Sua requisição foi enviada para o owner do bolão " + nomeBolao);
            }
            else
            {
                base.ShowMessages("Não foi possível enviar a requisição do bolão " + nomeBolao);
            }

        }
        #endregion

        protected void lnkRemove_Command(object sender, CommandEventArgs e)
        {

        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {

        }

        protected void dtlBolao_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

    }
}
