using LM.Core;
using LM.Core.DTO;
using LM.Core.UserRolesManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
namespace LeaveManagement.Controllers.UserRolesApi
{
    [Authorize(Roles = "manager,admin,user")]
    public class UserRolesController : ApiController
    {
        private readonly RolesManager _roleManager;
        UserRolesController()
        {
            _roleManager = new RolesManager();
        }

        // GET 
         [Authorize(Roles = "admin")]
        [Route("api/UserRoles/GetAll")]
        public ActionResult<List<UserRoles>> Get()
        {
            var result = _roleManager.GetAllRoles();
            return result;
        }

    }
}
