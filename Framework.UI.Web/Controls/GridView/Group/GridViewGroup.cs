using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Framework.UI.Web.Controls.GridView.Group
{


    public delegate void GroupEvent(string groupName, object[] values, GridViewRow row);

    /// <summary>
    /// A class that represents a group consisting of a set of columns
    /// </summary>
    public class GridViewGroup
    {
        public string[] Columns;
        public object[] ActualValues;
        public int Quantity;
        public bool Automatic;
        public bool HideGroupColumns;
        public bool IsSupressGroup;
        public bool GenerateAllCellsOnSummaryRow;

        private List<GridViewSummary> mSummaries;

        public List<GridViewSummary> Summaries
        {
            get { return mSummaries; }
        }

        public string Name
        {
            get { return String.Join("+", this.Columns); }
        }

        private GridViewGroup()
        {
            this.ActualValues = null;
            this.Quantity = 0;
            this.IsSupressGroup = false;
            this.mSummaries = new List<GridViewSummary>();
        }

        public GridViewGroup(string[] cols, bool auto, bool hideGroupColumns)
            : this()
        {
            this.Columns = cols;
            this.Automatic = auto;
            this.HideGroupColumns = hideGroupColumns;
        }

        public GridViewGroup(string[] cols, bool isSupress)
            : this(cols, false, false)
        {
            this.IsSupressGroup = isSupress;
        }

        public bool ContainsSummary(GridViewSummary s)
        {
            return mSummaries.Contains(s);
        }

        public void AddSummary(GridViewSummary s)
        {
            if (this.ContainsSummary(s))
            {
                throw new Exception("Summary already exists in this group.");
            }

            if (!s.Validate())
            {
                throw new Exception("Invalid summary.");
            }

            s.Group = this;
            this.mSummaries.Add(s);
        }

        public void Reset()
        {
            this.Quantity = 0;

            foreach (GridViewSummary s in mSummaries)
            {
                s.Reset();
            }
        }

        public void AddValueToSummaries(object dataitem)
        {
            this.Quantity++;

            foreach (GridViewSummary s in mSummaries)
            {
                s.AddValue(DataBinder.Eval(dataitem, s.Column));
            }
        }

        public void CalculateSummaries()
        {
            foreach (GridViewSummary s in mSummaries)
            {
                s.Calculate();
            }
        }
    }

}
