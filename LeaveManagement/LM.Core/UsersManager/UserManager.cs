using LM.Core.DTO;
using LM.Core.Validators;
using LM.Data;
using LM.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LM.Core.UsersManager
{
   public  class UserManager
    {
       private readonly UserDataManager _userDataManager;
       public UserManager()
        {
            _userDataManager = new UserDataManager();
        }


       public ActionResult<Users> Login(LoginDto loginDto)
       {




           ActionResult<Users> result = new ActionResult<Users>();

           result = UserValidator.ValidateBeforeLogin(loginDto);
           if (result.ErrorList.Count > 0)
           {
               result.IsSuccess = false;
               result.totalRecords = 0;
               result.resultCount = 0;
               result.Message = "Invalid";
               return result;
           }


           if (result.Data != null && PasswordAuthenticator.VerifyPassword(loginDto.Password, result.Data.password))
           {

               result = UserValidator.ValidateAfterLogin(result.Data);
               if (result.ErrorList.Count > 0)
               {
                   result.IsSuccess = false;
                   result.totalRecords = 0;
                   result.resultCount = 0;
                   result.Message = "Invalid";
                   return result;
               }

               result.IsSuccess = true;
               result.Message = "Logined SuccessFully";
               result.resultCount = 1;
               result.totalRecords = 1;
               return result;
           }
           else
           {
               result.IsSuccess = false;
               result.ErrorList.Add("Invalid Password !!  please Enter Valid Password ");
               result.totalRecords = 0;
               result.resultCount = 0;
               result.Message = "Invalid";
          
           }

           return result; // Invalid credentials
       }



       public ActionResult<Users> GetUserByName(string userName)
       {
           ActionResult<Users> result = new ActionResult<Users>();

           UsersModel userModel = _userDataManager.GetUserByUserName(userName);

           if (userModel != null)
           {
               result.Data = userModel.ToEntity();
               result.IsSuccess = true;
               result.resultCount = 1;
               result.totalRecords = 1;
               result.Message = "OK";
           }
           else
           {
               result.IsSuccess = false;
               result.resultCount = 0;
               result.totalRecords = 0;
               result.ErrorList.Add("Not Any Records Found For userName " + userName + "");
               result.Message = "Failed";
           }
           return result;


       }

       public ActionResult<Users> GetUserByUserId(int userId)
       {
           ActionResult<Users> result = new ActionResult<Users>();

           UsersModel userModel = _userDataManager.GetUserByUserId(userId);

           if (userModel != null)
           {
               result.Data = userModel.ToEntity();
               result.IsSuccess = true;
               result.resultCount = 1;
               result.totalRecords = 1;
               result.Message = "OK";
           }
           else
           {
               result.IsSuccess = false;
               result.resultCount = 0;
               result.totalRecords = 0;
               result.ErrorList.Add("Not Any Records Found For userId " + userId + "");
               result.Message = "Failed";
           }
           return result;
       }

       public ActionResult<Users> AddUser(int createdByEmpId, Users user)
       {
           ActionResult<Users> result = new ActionResult<Users>();

           user.createdAt = DateTime.Now;
           user.updatedAt = DateTime.Now;
           user.isActive = true;
           user.createdBy = createdByEmpId;
           user.updatedBy = createdByEmpId;

           result = UserValidator.ValidatePost(user);
           if (result.ErrorList.Count > 0)
           {
               result.IsSuccess = false;
               result.totalRecords = 0;
               result.resultCount = 0;
               result.Message = "Invalid";
               return result;
           }
           user.password = EncryptionService.EncryptPassword(user.password); 

           UsersModel userModel = _userDataManager.AddUser(user.ToModel());
           if (userModel != null)
           {
               result.Data = userModel.ToEntity();
               result.IsSuccess = true;
               result.resultCount = 1;
               result.totalRecords = 1;
               result.Message = "OK";
           }
           else
           {
               result.IsSuccess = false;
               result.ErrorList.Add("User not added in a System ");
               result.Message = "Failed";
           }
           return result;
       }

       public ActionResult<Users> UpdateUser(int userId, Users user)
       {
           ActionResult<Users> result = new ActionResult<Users>();
           user.updatedAt = DateTime.Now;

           result = UserValidator.checkUserExistById(userId);
           if (result.ErrorList.Count > 0)
           {
               result.IsSuccess = false;
               result.totalRecords = 0;
               result.resultCount = 0;
               result.Message = "Invalid";
               return result;
           }


           UsersModel userModel = _userDataManager.UpdateUser(userId, user.ToModel());

           if (userModel != null)
           {
               result.Data = userModel.ToEntity();
               result.IsSuccess = true;
               result.resultCount = 1;
               result.totalRecords = 1;
               result.Message = "OK";
           }
           else
           {
               result.IsSuccess = false;
               result.ErrorList.Add("Not Any Records Found For userId " + userId + " hence Update Failed");
               result.Message = "Failed";
           }
           return result;
       }

       public ActionResult<Users> UpdateUserActiveStatus(int userId, int updatedStatus)
       {
           ActionResult<Users> result = new ActionResult<Users>();
           result = UserValidator.checkUserExistById(userId);
           if (result.ErrorList.Count > 0)
           {
               result.IsSuccess = false;
               result.totalRecords = 0;
               result.resultCount = 0;
               result.Message = "Invalid";
               return result;
           }


           UsersModel userModel = _userDataManager.updateActiveStatus(userId, updatedStatus);

           if (userModel != null)
           {
               result.Data = userModel.ToEntity();
               result.IsSuccess = true;
               result.resultCount = 1;
               result.totalRecords = 1;
               result.Message = "OK";
           }
           else
           {
               result.IsSuccess = false;
               result.ErrorList.Add("Not Any Records Found For userId " + userId + " hence Update Failed");
               result.Message = "Failed";
           }
           return result;
       }

       public ActionResult<Users> UpdatePassword(int userId, string newPassword)
       {
           ActionResult<Users> result = null;
          string encryptedPassword =EncryptionService.EncryptPassword(newPassword);

          result = UserValidator.checkUserExistById(userId);
          if (result.ErrorList.Count > 0)
          {
              result.IsSuccess = false;
              result.totalRecords = 0;
              result.resultCount = 0;
              result.Message = "Invalid";
              return result;
          }
          UsersModel userModel = _userDataManager.UpdatePasword(userId, encryptedPassword);
          if (userModel != null)
          {
              result.Data = userModel.ToEntity();
              result.IsSuccess = true;
              result.resultCount = 1;
              result.totalRecords = 1;
              result.Message = "OK";
          }
          else
          {
              result.IsSuccess = false;
              result.ErrorList.Add("Not Any Records Found For userId " + userId + " hence Update Failed");
              result.Message = "Failed";
          }          
           
          return  result;
       }
    
   
   }
}
