using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Framework.UI.Web.Controls.GridView.Columns
{
    public class DeleteTemplateField : ITemplate
    {
        #region ITemplate Members

        public void InstantiateIn(Control container)
        {
            ImageButton img = new ImageButton();
            img.ID = "delete";
            img.CausesValidation = false;
            img.CommandName = "Delete";
            img.ImageUrl = "~/Images/delete.gif";
            img.OnClientClick = "return confirm(\"" + Resource.deleteTemplateButtonQuestion + "\");";
            img.ToolTip = Resource.deleteTemplateButtonToolTip;
            img.DataBinding += new EventHandler(this.BindLabel);
            img.Click += new ImageClickEventHandler(this.imageClick);


            container.Controls.Add(img);
        }

        private void imageClick(object sender, ImageClickEventArgs e)
        {
            //throw new Exception(((ImageButton)sender).CommandArgument);
        }


        private void BindLabel(Object sender, EventArgs e)
        {
            // Get the Label control to bind the value. The Label control
            // is contained in the object that raised the DataBinding 
            // event (the sender parameter).
            ImageButton l = (ImageButton)sender;

            // Get the GridViewRow object that contains the Label control. 
            GridViewRow row = (GridViewRow)l.NamingContainer;

            // Get the field value from the GridViewRow object and 
            // assign it to the Text property of the Label control.
            //l.CommandArgument = DataBinder.Eval(row.DataItem, "ID").ToString();
        }

        #endregion
    }
}
