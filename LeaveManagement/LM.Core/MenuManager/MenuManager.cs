using LM.Core.DTO;
using LM.Core.Validators;
using LM.Data;
using LM.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Core.MenuManager
{
   public class MenuManager
    {
       private readonly MenuDataManager _menuDataManager;

       public MenuManager()
        {
            _menuDataManager = new MenuDataManager();
        }

       public ActionResult<List<Menus>> GetAllMenus()
       {
           ActionResult<List<Menus>> result = new ActionResult<List<Menus>>();

           List<Menus> menus = new List<Menus>();
           List<MenusModel> menusModels = _menuDataManager.GetAllMenus();


           if (menusModels.Count != 0)
           {
               foreach (var menu in menusModels)
               {
                   menus.Add(menu.ToEntity());
               }
               result.Data = menus;
               result.IsSuccess = true;
               result.resultCount = menus.Count;
               result.totalRecords = menus.Count;
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

       public ActionResult<List<Menus>> GetMenuByRole(int roleId)
       {
           ActionResult<List<Menus>> result = new ActionResult<List<Menus>>();

           List<Menus> menus = new List<Menus>();
           List<MenusModel> menusModels = _menuDataManager.GetMenusByRole(roleId);

           if (menusModels.Count != 0)
           {
               foreach (var menu in menusModels)
               {
                   menus.Add(menu.ToEntity());
               }

               result.Data = menus;
               result.IsSuccess = true;
               result.resultCount = menus.Count;
               result.totalRecords = menus.Count;
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


       //
       //addApplication
       public ActionResult<Menus> AddMenu( Menus menu)
       {
           ActionResult<Menus> result = new ActionResult<Menus>();

           result = MenuValidator.ValidatePost(menu);
           if (result.ErrorList.Count > 0)
           {
               result.IsSuccess = false;
               result.totalRecords = 0;
               result.resultCount = 0;
               result.Message = "Invalid";
               return result;
           }


           MenusModel menumodel = _menuDataManager.AddMenu(menu.ToModel());
           if (menumodel != null)
           {
               result.Data = menumodel.ToEntity();
               result.IsSuccess = true;
               result.totalRecords = 1;
               result.resultCount = 1;
               result.Message = "Added Successfully";
           }
           else
           {
               result.IsSuccess = false;
               result.Message = "Failed";
           }
           return result;
       }


       public ActionResult<MenuAccessMaster> AddMenuToRole(MenuAccessMaster accessMaster)
       {
           ActionResult<MenuAccessMaster> result = new ActionResult<MenuAccessMaster>();


           MenuAccessMasterModel accessMastermodel = _menuDataManager.AddMenuToRole(accessMaster.ToModel());
           if (accessMastermodel != null)
           {
               result.Data = accessMastermodel.ToEntity();
               result.IsSuccess = true;
               result.totalRecords = 1;
               result.resultCount = 1;
               result.Message = "Menus Assigned Successfully";
           }
           else
           {
               result.IsSuccess = false;
               result.Message = "Failed";
           }
           return result;
       }


    }
}
