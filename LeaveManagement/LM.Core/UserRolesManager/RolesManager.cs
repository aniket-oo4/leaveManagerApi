using LM.Core.DTO;
using LM.Data;
using LM.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Core.UserRolesManager
{
    public class RolesManager
    {
      private readonly RolesDataManager _rolesDataManager;
      public RolesManager()
        {
            _rolesDataManager = new RolesDataManager();
        }


        public ActionResult<List<UserRoles>> GetAllRoles()
        {
            ActionResult<List<UserRoles>> result = new ActionResult<List<UserRoles>>();
            List<UserRoles> roles = new List<UserRoles>();
            List<UserRolesModel> rolesModels = _rolesDataManager.GetAllRoles();
            if (rolesModels.Count != 0)
            {
                foreach (var role in rolesModels)
                {
                    roles.Add(role.ToEntity());
                }
                result.Data = roles;
                result.IsSuccess = true;
                result.resultCount = roles.Count;
                result.totalRecords = roles.Count;
                result.Message = "OK";
            }
            else
            {
                result.IsSuccess = false;
                result.ErrorList.Add("Not Any Records Found");
                result.Message = "Failed";
            }
            return result;
        }


    }
}
