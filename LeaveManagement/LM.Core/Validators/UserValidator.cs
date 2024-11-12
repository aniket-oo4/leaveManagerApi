using LM.Core.CommonUtils;
using LM.Core.DTO;
using LM.Data;
using LM.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Core.Validators
{
    public static class UserValidator
    {

        public static ActionResult<Users> ValidatePost(Users user)
        {
            ActionResult<Users> result = new ActionResult<Users>();
            UserDataManager _userDataManager = new UserDataManager();
            if (Common.IsNullOrDefault<string>(user.userName) || user.userName.Length==0)
            {
                result.ErrorList.Add("userName cannot be a null or Empty Value ");
            }
            if (Common.IsNullOrDefault<string>(user.password) || user.password.Length == 0)
            {
                result.ErrorList.Add("password cannot be a null or Empty Value ");
            }
            if (_userDataManager.IsUserNameExist(user.userName))
            {
                result.ErrorList.Add("User with UserName  " + user.userName + "already Exist !!");
            }
            return result;
        }

        public static ActionResult<Users> checkUserExistById(int userId)
        {
            ActionResult<Users> result = new ActionResult<Users>();
            UserDataManager _userDataManager = new UserDataManager();
          
            if (!_userDataManager.IsUserIdExist(userId))
            {
                result.ErrorList.Add("User with UserId  " + userId + "Not Exist !!");
            }
            return result;
        }


        public static ActionResult<Users> ValidateBeforeLogin(LoginDto login)
        {
            ActionResult<Users> result = new ActionResult<Users>();
            UserDataManager _userDataManager = new UserDataManager();
            EmployeeDataManager _employeeDataManager = new EmployeeDataManager();
            Users DbUser = null;
            if (Common.IsNullOrDefault<string>(login.UserName) || login.UserName.Length == 0)
            {
                result.ErrorList.Add("userName cannot be a null or Empty Value ");
            }
            else
            {
                DbUser = _userDataManager.GetUserByUserName(login.UserName) == null ? null : _userDataManager.GetUserByUserName(login.UserName).ToEntity();

                if (Common.IsNullOrDefault<Users>(DbUser))
                {
                    result.ErrorList.Add("No Such User Found With UserName : " + login.UserName + "");
                }
            }

            if (Common.IsNullOrDefault<string>(login.Password) || login.Password.Length == 0)
            {
                result.ErrorList.Add("Password cannot be a null or Empty Value ");
            }


            result.Data = DbUser;
            return result;
        }


        public static ActionResult<Users> ValidateAfterLogin(Users DbUser)
        {
            ActionResult<Users> result = new ActionResult<Users>();
            UserDataManager _userDataManager = new UserDataManager();
            EmployeeDataManager _employeeDataManager = new EmployeeDataManager();

            if (DbUser.isActive != true)
            {
                result.ErrorList.Add(" User With UserName : " + DbUser.userName + " Is Not Active !!");
            }
            if (_employeeDataManager.GetByUserId(DbUser.userId) == null)
            {
                result.ErrorList.Add("This User Profile Not matched with any Employee !!");
            }
            result.Data = DbUser;
            return result;
        }

    }
}
