using LM.Core;
using LM.Core.DTO;
using LM.Core.ActionsManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
namespace LeaveManagement.Controllers.ActionsApi
{
     [Authorize(Roles = "admin,manager,user")]
    public class ActionsController : ApiController
    {

         private readonly ActionManager _actionManager;

         public ActionsController()
        {
            _actionManager = new ActionManager();
        }


        // GET 
        [Route("api/actions/GetByRole/{roleId}")]
        public ActionResult<List<ActionMaster>> GetByRole(int roleId)
        {
            var result = _actionManager.GetActionsByRole(roleId);
            return result;
        }


    }
}
