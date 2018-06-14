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

namespace BolaoNet.WebSite.Controls.MenuManager
{
    public partial class MenuTools : System.Web.UI.UserControl
    {
        #region Events/Delegates
        public event CommandEventHandler ButtonClick;
        #endregion

        #region Enumerations/Constants
        public const string AddNew = "AddNew";
        public const string Save = "Save";
        public const string Delete = "Delete";
        public const string Return = "Return";
        public const string Next = "Next";
        public const string SocialFace = "SocialFace";
        #endregion

        #region Variables
        private string _commandArgument;
        #endregion

        #region Properties
        public string CommandArgument
        {
            get
            {
                return _commandArgument;
            }
            set
            {
                _commandArgument = value;
            }
        }
        public bool FaceVisible
        {
            get
            {
                return facebookCell.Visible;
            }
            set
            {
                facebookCell.Visible = value;
            }
        }
        public bool AddVisible
        {
            get
            {
                return addNewCell.Visible;
            }
            set
            {
                addNewCell.Visible = value;
            }
        }
        public bool SaveVisible
        {
            get
            {
                return saveCell.Visible;
            }
            set
            {
                saveCell.Visible = value;
            }
        }
        public bool DeleteVisible
        {
            get
            {
                return deleteCell.Visible;
            }
            set
            {
                deleteCell.Visible = value;
            }
        }
        public bool ReturnVisible
        {
            get
            {
                return returnCell.Visible;
            }
            set
            {
                returnCell.Visible = value;
            }
        }
        public bool NextVisible
        {
            get
            {
                return nextCell.Visible;
            }
            set
            {
                nextCell.Visible = value;
            }
        }
        #endregion

        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected override void OnInit(EventArgs e)
        {

            this.FaceVisible = false;

            base.OnInit(e);
        }
        #endregion

        #region Methods
        public void SetAllVisible()
        {
            AddVisible = true;
            SaveVisible = true;
            ReturnVisible = true;
            DeleteVisible = true;
            NextVisible = true;
            FaceVisible = true;
        }
        #endregion

        #region Events
        protected void Page_PreRender(object sender, EventArgs e)
        {
            lnkAddNew.CommandName = AddNew;
            lnkAddNew.CommandArgument = CommandArgument;
            lnkSave.CommandName = Save;
            lnkSave.CommandArgument = CommandArgument;
            lnkDelete.CommandName = Delete;
            lnkDelete.CommandArgument = CommandArgument;
            lnkReturn.CommandName = Return;
            lnkReturn.CommandArgument = CommandArgument;
            lnkNext.CommandName = Next;
            lnkNext.CommandArgument = CommandArgument;
            lnkSocialFac.CommandName = SocialFace;
            lnkSocialFac.CommandArgument = CommandArgument;

            //FaceVisible = false;
        }
        protected void Button_Click(object sender, CommandEventArgs e)
        {

            if (Page.IsValid && ButtonClick != null)
                ButtonClick(sender, e);
        }
        #endregion
    }
}