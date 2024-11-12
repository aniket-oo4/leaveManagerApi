using LM.Core.DTO;
using LM.Data;
using LM.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Core.OrgManager
{
    public class OrgManager
    {

          private readonly OrgDataManager _orgDataManager;

          public OrgManager()
        {
            _orgDataManager = new OrgDataManager();
        }



          public ActionResult<List<PublicHolidays>> GetAllPublicHolidays(int orgId)
          {
              ActionResult<List<PublicHolidays>> result = new ActionResult<List<PublicHolidays>>();

              List<PublicHolidays> publicHolidays = new List<PublicHolidays>();
              List<PublicHolidaysModel> publicHolidaysModels = _orgDataManager.GetAllPublicHolidays(orgId);

              if (publicHolidaysModels.Count != 0)
              {
                  foreach (var holiday in publicHolidaysModels)
                  {
                      publicHolidays.Add(holiday.ToEntity());
                  }
                  result.Data = publicHolidays;
                  result.IsSuccess = true;
                  result.resultCount = publicHolidays.Count;
                  result.totalRecords = publicHolidays.Count;
                  result.Message = "OK";
              }
              else
              {
                  result.IsSuccess = false;
                  result.ErrorList.Add("Not Any holidays  Records Found For orgId " + orgId + "");
                  result.Message = "Failed";
              }
              return result;
          }
          public ActionResult<List<Departments>> GetAllDepartments(int orgId)
          {
              ActionResult<List<Departments>> result = new ActionResult<List<Departments>>();

              List<Departments> departments = new List<Departments>();
              List<DepartmentsModel> departmentsModels = _orgDataManager.GetAllDepartments(orgId);

              if (departmentsModels.Count != 0)
              {
                  foreach (var department in departmentsModels)
                  {
                      departments.Add(department.ToEntity());
                  }
                  result.Data = departments;
                  result.IsSuccess = true;
                  result.resultCount = departments.Count;
                  result.totalRecords = departments.Count;
                  result.Message = "OK";
              }
              else
              {
                  result.IsSuccess = false;
                  result.ErrorList.Add("Not Any Department  Records Found For orgId " + orgId + "");
                  result.Message = "Failed";
              }
              return result;
          }
          public ActionResult<List<CostCenters>> GetAllCostCenters(int orgId)
          {
              ActionResult<List<CostCenters>> result = new ActionResult<List<CostCenters>>();

              List<CostCenters> costCenters = new List<CostCenters>();
              List<CostCentersModel> costCentersModels = _orgDataManager.GetAllCostCenters(orgId);

              if (costCentersModels.Count != 0)
              {
                  foreach (var costCenter in costCentersModels)
                  {
                      costCenters.Add(costCenter.ToEntity());
                  }
                  result.Data = costCenters;
                  result.IsSuccess = true;
                  result.resultCount = costCenters.Count;
                  result.totalRecords = costCenters.Count;
                  result.Message = "OK";
              }
              else
              {
                  result.IsSuccess = false;
                  result.ErrorList.Add("Not Any Department  Records Found For orgId " + orgId + "");
                  result.Message = "Failed";
              }
              return result;
          }
    
    
    
    
    }
}
