//using LM.Core.CommonUtils;
//using LM.Core.DTO;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace LM.Core.Validators
//{
//    public static class LoginValidator
//    {
//        public static ActionResult<Users> ValidateLogin(LoginDto loginDto)
//        {
//            ActionResult<Users> result = new ActionResult<Users>();

//            if (Common.IsNullOrDefault<string>(loginDto.UserName))
//            {
//                result.ErrorList.Add("UserName cannot be a null or Empty Value ");
//            }
//            if (Common.IsNullOrDefault<string>(loginDto.Password))
//            {
//                result.ErrorList.Add("Password cannot be a null or Empty Value ");
//            }

//            return result;
//        }
    
//    }
//}
