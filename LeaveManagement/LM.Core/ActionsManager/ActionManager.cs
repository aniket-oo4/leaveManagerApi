using LM.Core.DTO;
using LM.Data;
using LM.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Core.ActionsManager
{
   public  class ActionManager
    {

       private readonly ActionDataManager _acionDataManager;

       public ActionManager()
        {
            _acionDataManager = new ActionDataManager();
        }

       public ActionResult<List<ActionMaster>> GetActionsByRole(int roleId)
       {
           ActionResult<List<ActionMaster>> result = new ActionResult<List<ActionMaster>>();

           List<ActionMaster> actions = new List<ActionMaster>();
           List<ActionMasterModel> actionModels = _acionDataManager.GetActionsByRole(roleId);

           if (actionModels.Count != 0)
           {
               foreach (var action in actionModels)
               {
                   actions.Add(action.ToEntity());
               }

               result.Data = actions;
               result.IsSuccess = true;
               result.resultCount = actions.Count;
               result.totalRecords = actions.Count;
               result.Message = "OK";
           }
           else
           {
               result.IsSuccess = false;
               result.ErrorList.Add("Not Any Records Found For Role Id  " + roleId + "");
               result.Message = "Failed";
           }
           return result;
       }


    }
}
