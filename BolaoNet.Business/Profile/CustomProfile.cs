using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Profile;
using System.Text;

namespace BolaoNet.Business.Profile
{
    public class CustomProfile : ProfileBase
    {
        #region Variables
        #endregion

        #region Properties
        public string NomeCampeonato
        {
            set { SetPropertyValue("NomeCampeonato", value); }
            get { return (string)GetPropertyValue("NomeCampeonato"); }
        }
        public string NomeBolao
        {
            set { SetPropertyValue("NomeBolao", value); }
            get { return (string)GetPropertyValue("NomeBolao"); }
        }
        #endregion

        #region Constructors/Destructors
        public CustomProfile()
            : base()
        {
        }
        #endregion

        #region Methods
        /// <summary>
        /// Get the profile of the currently logged-on user.
        /// </summary>      
        public static CustomProfile GetProfile()
        {
            return (CustomProfile)HttpContext.Current.Profile;
        }
        /// <summary>
        /// Gets the profile of a specific user.
        /// </summary>
        /// <param name="userName">The user name of the user whose profile you want to retrieve.</param>      
        public static CustomProfile GetProfile(string userName)
        {
            return (CustomProfile)Create(userName);
        }


        public static ProfileBase GetProfileBase(string userName)
        {
            return (CustomProfile)Create(userName);
        }
        #endregion
    }
}
