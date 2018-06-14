using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Profile;

namespace BolaoNet.Model.Providers
{
    public class ProfileCommon : System.Web.Profile.ProfileBase
    {
        #region Properties
        [SettingsAllowAnonymous(false)]
        public virtual string Campeonato
        {
            get
            {
                return (string)(base.GetPropertyValue("Campeonato"));
            }
            set
            {
                base.SetPropertyValue("Campeonato", value);
            }

        }
        #endregion
    }
}
