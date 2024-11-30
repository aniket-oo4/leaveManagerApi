using LeaveManagement.Auth;
using LM.Core;
using LM.Core.DTO;
using LM.Core.UsersManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace LeaveManagement.Controllers.UsersApi
{
    [DisableCors]
    public class UsersController : ApiController
    {
        private readonly UserManager _userManager;
        UsersController()
        {
           _userManager = new UserManager();
        }

        [HttpPost]
        [DisableCors]
        [Route("api/users/login")]
        public async Task<ActionResult<Users>> Login(LoginDto loginDto)
        {
            UserManager _userManager = new UserManager();
            ActionResult<Users> result = new ActionResult<Users>();
           
            if (loginDto == null)
            {
                result.IsSuccess = false;
                result.ErrorList.Add("You AreTrying to insert  null Values !! Null Values are not allowed");
                result.Message = "Failed";
                result.totalRecords = 0;
                result.resultCount = 0;
                return result;
            }

            result = _userManager.Login(loginDto);

            //  JWT token generated
            //string token = "", url;
            //url = "http://localhost:57686/api/tokenGenerator/";
            //token = await TokenManager.GetToken(url, result.Data);
            //result.Message = token;
            return result;
        }




        // GET 
         [Route("api/users/GetById/{userId}")]
        public ActionResult<Users> GetById(int userId)
        {
            var result = _userManager.GetUserByUserId(userId);
            return result;
        }

        

        // GET 
        [Route("api/users/GetByUserName/{userName}")]
        public ActionResult<Users> GetByUserName(string userName)
        {
            var result = _userManager.GetUserByName(userName);
            return result;
        }


        [Authorize(Roles = "user,manager,admin")]
        [HttpPut]
        [Route("api/users/updatePassword/{userId}")]
        public ActionResult<Users> UpdatePassword(int userId ,[FromBody]string password)
        {
            
            ActionResult<Users> result = new ActionResult<Users>();
            result = _userManager.UpdatePassword(userId, password);

            if (result.Data == null)
            {
                result.IsSuccess = false;
                result.resultCount = 0;
                result.totalRecords = 0;
                result.Message = "Pass not updated ";
                //result.ErrorList.Add(@"Not Any Record Found for userId " +userId + "");
                return result;
            }
            result.IsSuccess = true;
            result.resultCount = 1;
            result.totalRecords = 1;
            result.Message = "Password Updated SuccessFully ";
            return result;
        }

        //Post
        [Authorize(Roles = "admin")]
        [HttpPost]
        [Route("api/users/AddUser/{createdByEmpId}")]
        public ActionResult<Users> Post(int createdByEmpId, [FromBody]Users user)
        {
            try
            {
                if (user == null)
                {
                    ActionResult<Users> result = new ActionResult<Users>();
                    result.IsSuccess = false;
                    result.ErrorList.Add("You AreTrying to insert  null Values !! Null Values are not allowed");
                    result.Message = "Failed";
                    return result;
                }
                return _userManager.AddUser(createdByEmpId, user);
            }
            catch (MyException<Users> e)
            {
                return e.result;
            }
        }

        //Put 
        [Authorize(Roles = "user,manager,admin")]
        [HttpPut]
        [Route("api/users/Update/{userId}")]
        public ActionResult<Users> Put(int userId, [FromBody]Users user)
        {
            var result = _userManager.UpdateUser(userId, user);
            return result;
        }

        // Put 
        [Authorize(Roles = "admin")]
        [HttpPut]
        [Route("api/users/updateActiveStatus/{userId}/status/{updatedStatus}")]
        public ActionResult<Users> updateactiveStatus(int userId, int updatedStatus)
        {
            var result = _userManager.UpdateUserActiveStatus(userId, updatedStatus);
            return result;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }


    }
}
