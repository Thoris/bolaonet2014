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

namespace BolaoNet.WebSite.Controls.Views
{
    public partial class StatusRowInfo : System.Web.UI.UserControl
    {
        #region Properties
        public Framework.DataServices.Model.EntityBaseData Entry
        {
            get { return (Framework.DataServices.Model.EntityBaseData)ViewState["Entry"]; }
            set
            {
                if (ViewState["Entry"] != value && value != null)
                {
                    ShowStatus(value);
                }


                ViewState["Entry"] = value; 


            }
        }
        #endregion

        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Entry != null)
                ShowStatus(Entry);


        }
        #endregion

        #region Methods
        public void ShowStatus(Framework.DataServices.Model.EntityBaseData entry)
        {


            this.lblActiveFlag.Text = entry.ActiveFlag.ToString();


            if (string.IsNullOrEmpty(entry.CreatedBy))
                this.lblCreatedBy.Text = "-";
            else
                this.lblCreatedBy.Text = entry.CreatedBy;

            if (entry.CreatedDate == DateTime.MinValue)
                this.lblCreatedDate.Text = "-";
            else            
                this.lblCreatedDate.Text = entry.CreatedDate.ToString("dd/MM/yyyy HH:mm:ss");

            if (string.IsNullOrEmpty(entry.ModifiedBy))
                this.lblModifiedBy.Text = "-";
            else
                this.lblModifiedBy.Text = entry.ModifiedBy;

            if (entry.ModifiedDate == DateTime.MinValue)
                this.lblModifiedDate.Text = "-";
            else            
                this.lblModifiedDate.Text = entry.ModifiedDate.ToString("dd/MM/yyyy HH:mm:ss");

            

        }


        #endregion
    }
}