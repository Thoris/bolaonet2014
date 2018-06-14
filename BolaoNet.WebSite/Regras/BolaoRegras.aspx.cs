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

namespace BolaoNet.WebSite.Regras
{
    public partial class BolaoRegras : ApostaBolaoBasePage
    {
        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }

            BindRegras();
        }
        #endregion

        #region Methods
        private void BindRegras()
        {
            Business.Boloes.Support.Regra business = new BolaoNet.Business.Boloes.Support.Regra(base.UserName);
            business.Bolao = CurrentBolao;

            IList<Framework.DataServices.Model.EntityBaseData> list = business.SelectAllFromBolao(CurrentBolao, null);

            this.grdRegras.DataSource = list;
            this.grdRegras.DataBind();
            

        }
        #endregion
    }
}
