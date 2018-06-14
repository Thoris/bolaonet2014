using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web;
using System.Web.UI;


namespace Framework.UI.Web.Controls.GridView.Columns
{
    class GridViewEditButtonTemplate : ITemplate
    {
        private DataControlRowType templateType;
        private string columnName;
        private string dataType;

        public GridViewEditButtonTemplate(DataControlRowType type,  string colname, string DataType)
        {
            templateType = type;
            columnName = colname;
            dataType = DataType;
        }



        public void InstantiateIn(System.Web.UI.Control container)
        {
            DataControlFieldCell hc = null;

            switch (templateType)
            {
                case DataControlRowType.Header:
                    // build the header for this column
                    Literal lc = new Literal();
                    lc.Text = "<b>" + BreakCamelCase(columnName) + "</b>";
                    container.Controls.Add(lc);
                    break;
                case DataControlRowType.DataRow:
                    // build one row in this column
                    Label l = new Label();
                    switch (dataType)
                    {
                        case "DateTime":
                            l.CssClass = "ReportNoWrap";
                            break;
                        case "Double":
                            hc = (DataControlFieldCell)container;
                            hc.CssClass = l.CssClass = "ReportNoWrapRightJustify";
                            break;
                        case "Int16":
                        case "Int32":
                            hc = (DataControlFieldCell)container;
                            hc.CssClass = l.CssClass = "ReportNoWrapRightJustify";
                            break;
                        case "String":
                            l.CssClass = "ReportNoWrap";
                            break;
                    }
                    // register an event handler to perform the data binding
                    l.DataBinding += new EventHandler(this.l_DataBinding);
                    container.Controls.Add(l);
                    break;
                default:
                    break;
            }
        }

        private void l_DataBinding(Object sender, EventArgs e)
        {
            // get the control that raised this event
            Label l = (Label)sender;
            // get the containing row
            GridViewRow row = (GridViewRow)l.NamingContainer;
            // get the raw data value and make it pretty
            string RawValue =
                DataBinder.Eval(row.DataItem, columnName).ToString();
            switch (dataType)
            {
                case "DateTime":
                    l.Text = String.Format("{0:d}", DateTime.Parse(RawValue));
                    break;
                case "Double":
                    l.Text = String.Format("{0:###,###,##0.00}",
                        Double.Parse(RawValue));
                    break;
                case "Int16":
                case "Int32":
                    l.Text = RawValue;
                    break;
                case "String":
                    l.Text = RawValue;
                    break;
            }
        }

        // helper method to convert CamelCaseString to Camel Case String
        // by inserting spaces
        private string BreakCamelCase(string CamelString)
        {
            string output = string.Empty;
            bool SpaceAdded = true;

            for (int i = 0; i < CamelString.Length; i++)
            {
                if (CamelString.Substring(i, 1) ==
                    CamelString.Substring(i, 1).ToLower())
                {
                    output += CamelString.Substring(i, 1);
                    SpaceAdded = false;
                }
                else
                {
                    if (!SpaceAdded)
                    {
                        output += " ";
                        output += CamelString.Substring(i, 1);
                        SpaceAdded = true;
                    }
                    else
                        output += CamelString.Substring(i, 1);
                }
            }

            return output;
        }


    }
}
