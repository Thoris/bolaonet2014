using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Framework.UI.Web.Controls.GridView.Group
{


    public enum SummaryOperation { Sum, Avg, Count, Custom }
    public delegate void CustomSummaryOperation(string column, string groupName, object value);
    public delegate object SummaryResultMethod(string column, string groupName);

    /// <summary>
    /// A class that represents a summary operation defined to a column
    /// </summary>
    public class GridViewSummary
    {
        public string Column;
        public SummaryOperation Operation;
        public CustomSummaryOperation CustomOperation;
        public SummaryResultMethod GetSummaryMethod;
        public GridViewGroup Group;
        public object Value;
        public string FormatString;
        public int Quantity;
        public bool Automatic;
        public bool TreatNullAsZero;


        private GridViewSummary(string col, GridViewGroup grp)
        {
            this.Column = col;
            this.Group = grp;
            this.Value = null;
            this.FormatString = String.Empty;
            this.Quantity = 0;
            this.Automatic = true;
            this.TreatNullAsZero = false;
        }

        public GridViewSummary(string col, SummaryOperation op, GridViewGroup grp)
            : this(col, grp)
        {
            this.Operation = op;
            this.CustomOperation = null;
            this.GetSummaryMethod = null;
        }

        public GridViewSummary(string col, CustomSummaryOperation op, SummaryResultMethod getResult, GridViewGroup grp)
            : this(col, grp)
        {
            this.Operation = SummaryOperation.Custom;
            this.CustomOperation = op;
            this.GetSummaryMethod = getResult;
        }

        public bool Validate()
        {
            if (this.Operation == SummaryOperation.Custom)
            {
                return (this.CustomOperation != null && this.GetSummaryMethod != null);
            }
            else
            {
                return (this.CustomOperation == null && this.GetSummaryMethod == null);
            }
        }

        public void Reset()
        {
            this.Quantity = 0;
            this.Value = null;
        }

        public void AddValue(object newValue)
        {
            // Increment to (later) calc the Avg or for other calcs
            this.Quantity++;

            // Built-in operations
            if (this.Operation == SummaryOperation.Sum || this.Operation == SummaryOperation.Avg)
            {
                if (this.Value == null)
                    this.Value = newValue;
                else
                    this.Value = PerformSum(this.Value, newValue);
            }
            else
            {
                // Custom operation
                if (this.CustomOperation != null)
                {
                    // Call the custom operation
                    if (this.Group != null)
                        this.CustomOperation(this.Column, this.Group.Name, newValue);
                    else
                        this.CustomOperation(this.Column, null, newValue);
                }
            }
        }

        public void Calculate()
        {
            if (this.Operation == SummaryOperation.Avg)
            {
                this.Value = PerformDiv(this.Value, this.Quantity);
            }
            if (this.Operation == SummaryOperation.Count)
            {
                this.Value = this.Quantity;
            }
            else if (this.Operation == SummaryOperation.Custom)
            {
                if (this.GetSummaryMethod != null)
                {
                    this.Value = this.GetSummaryMethod(this.Column, null);
                }
            }
            // if this.Operation == SummaryOperation.Avg
            // this.Value already contains the correct value
        }

        #region Built-in Summary Operations

        private object PerformSum(object a, object b)
        {
            object zero = 0;

            if (a == null)
            {
                if (TreatNullAsZero)
                    a = 0;
                else
                    return null;
            }

            if (b == null)
            {
                if (TreatNullAsZero)
                    b = 0;
                else
                    return null;
            }

            // Convert to proper type before add
            switch (a.GetType().FullName)
            {
                case "System.Int16": return Convert.ToInt16(a) + Convert.ToInt16(b);
                case "System.Int32": return Convert.ToInt32(a) + Convert.ToInt32(b);
                case "System.Int64": return Convert.ToInt64(a) + Convert.ToInt64(b);
                case "System.UInt16": return Convert.ToUInt16(a) + Convert.ToUInt16(b);
                case "System.UInt32": return Convert.ToUInt32(a) + Convert.ToUInt32(b);
                case "System.UInt64": return Convert.ToUInt64(a) + Convert.ToUInt64(b);
                case "System.Single": return Convert.ToSingle(a) + Convert.ToSingle(b);
                case "System.Double": return Convert.ToDouble(a) + Convert.ToDouble(b);
                case "System.Decimal": return Convert.ToDecimal(a) + Convert.ToDecimal(b);
                case "System.Byte": return Convert.ToByte(a) + Convert.ToByte(b);
                case "System.String": return a.ToString() + b.ToString();
            }

            return null;
        }

        private object PerformDiv(object a, int b)
        {
            object zero = 0;

            if (a == null)
            {
                return (TreatNullAsZero ? zero : null);
            }

            // Don't raise an exception, just return null
            if (b == 0)
            {
                return null;
            }

            // Convert to proper type before div
            switch (a.GetType().FullName)
            {
                case "System.Int16": return Convert.ToInt16(a) / b;
                case "System.Int32": return Convert.ToInt32(a) / b;
                case "System.Int64": return Convert.ToInt64(a) / b;
                case "System.UInt16": return Convert.ToUInt16(a) / b;
                case "System.UInt32": return Convert.ToUInt32(a) / b;
                case "System.Single": return Convert.ToSingle(a) / b;
                case "System.Double": return Convert.ToDouble(a) / b;
                case "System.Decimal": return Convert.ToDecimal(a) / b;
                case "System.Byte": return Convert.ToByte(a) / b;
                // Operator '/' cannot be applied to operands of type 'ulong' and 'int'
                //case "System.UInt64": return Convert.ToUInt64(a) / b;
            }

            return null;
        }

        #endregion

    }

}
