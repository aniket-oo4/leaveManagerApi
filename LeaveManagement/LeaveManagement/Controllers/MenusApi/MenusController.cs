using LM.Core;
using LM.Core.DTO;
using LM.Core.MenuManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
namespace LeaveManagement.Controllers.MenusApi
{
    [Authorize(Roles = "admin,manager,user")]
    public class MenusController : ApiController
    {

         private readonly MenuManager _menuManager;

         public MenusController()
        {
            _menuManager = new MenuManager();
        }


        // GET 
        [Authorize(Roles = "admin")]
        [Route("api/menus/GetAll")]
        public ActionResult<List<Menus>> Get()
        {
            var result = _menuManager.GetAllMenus();
            return result;
        }

        // GET 
        [Route("api/menus/GetByRole/{roleId}")]
        public ActionResult<List<Menus>> GetByRole(int roleId)
        {
            var result = _menuManager.GetMenuByRole(roleId);
            return result;
        }


        // POST 
        [Authorize(Roles = "admin")]
        [HttpPost]
        [Route("api/menus/AddMenu")]
        public ActionResult<Menus> Post( [FromBody]Menus menu)
        {
            try
            {
                if (menu == null)
                {
                    ActionResult<Menus> result = new ActionResult<Menus>();
                    result.IsSuccess = false;
                    result.ErrorList.Add("You AreTrying to insert  null Values !! Null Values are not allowed");
                    result.Message = "Failed";
                    return result;
                }
                return _menuManager.AddMenu(menu);
            }
            catch (MyException<Menus> e)
            {
                return e.result;
            }
        }

        // POST 
        [Authorize(Roles = "admin")]
        [HttpPost]
        [Route("api/menus/AssignMenu")]
        public ActionResult<MenuAccessMaster> Post([FromBody]MenuAccessMaster acccessMaster)
        {
            try
            {
                if (acccessMaster == null)
                {
                    ActionResult<MenuAccessMaster> result = new ActionResult<MenuAccessMaster>();
                    result.IsSuccess = false;
                    result.ErrorList.Add("You AreTrying to insert  null Values !! Null Values are not allowed");
                    result.Message = "Failed";
                    return result;
                }
                return _menuManager.AddMenuToRole(acccessMaster);
            }
            catch (MyException<MenuAccessMaster> e)
            {
                return e.result;
            }
        }
    
    
    }
}
