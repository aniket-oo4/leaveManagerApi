using LM.Core.CommonUtils;
using LM.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Core.Validators
{
    public static class MenuValidator
    {
        public static ActionResult<Menus> ValidatePost(Menus menu)
        {
            ActionResult<Menus> result = new ActionResult<Menus>();

            if (Common.IsNullOrDefault<string>(menu.menuName))
            {
                result.ErrorList.Add("menuName cannot be a null or Empty Value ");
            }
            if (Common.IsNullOrDefault<string>(menu.url))
            {
                result.ErrorList.Add("url cannot be a null or Empty Value ");
            }
            
            return result;
        }
    

    }
}
