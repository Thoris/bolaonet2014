using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Business.Util
{
    public enum ActionMode
    {
        Insert = 1,
        Edit = 2,
        Delete = 3,
        View = 4,
    }

    public sealed class Mode
    {
        public static ActionMode GetAction(string mode)
        {
            if (string.IsNullOrEmpty(mode))            
                return ActionMode.View;

            int modeItem = Convert.ToInt32(mode);

            return (ActionMode)modeItem;

        }
    }
}
