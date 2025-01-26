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
namespace LeaveManagement.Controllers.LeaveApplicationsApi
{
      [Authorize(Roles = "admin,manager,user")]
    public class LeaveApplicationsApiController : ApiController
    {
        private readonly LeaveManager _leaveManager;

        public LeaveApplicationsApiController()
        {
            _leaveManager = new LeaveManager();
        }

      


        // GET 

           [Authorize(Roles = "admin")]
         [Route("api/LeaveApplicationsApi/GetAll")]
        [HttpGet]
        public ActionResult<List<LeaveApplications>> Get()
       {
           var result = _leaveManager.GetAllLeaveApplications();
           return result;
       }

           //api/leaves?start=1&size=10s
              [Authorize(Roles = "admin")]
              [Route("api/LeaveApplicationsApi/FetchOnScroll")]
           public ActionResult<List<LeaveApplications>> Get([FromUri]int start, [FromUri]int size)
           {
               ActionResult<List<LeaveApplications>> oAllApplications = _leaveManager.GetAllLeaveApplications();
               ActionResult<List<LeaveApplications>> oGroupedData = new ActionResult<List<LeaveApplications>>();

               oGroupedData.Data = new List<LeaveApplications>();
               if (start != 0)
               {
                   start *= 10;
               }
               else
               {
                   start = 0;
               }
               size = start + size;
               if (size > oAllApplications.Data.Count)
               {
                   size -= (start + size) - oAllApplications.Data.Count;
                   size = start + size;
               }
               if (oAllApplications.Data.Count > 0)
               {
                   for (int i = start; i < size; i++)
                   {
                       oGroupedData.Data.Add(oAllApplications.Data[i]);
                   }
               }
               else
               {
                   oGroupedData.IsSuccess = false;
                   oGroupedData.ErrorList.Add("Not Any Records Found !!");
                   oGroupedData.Message = "Failure";
                   oGroupedData.httpStatusCode = HttpStatusCode.NotFound;
               }
               oGroupedData.resultCount = oGroupedData.Data.Count;
               oGroupedData.totalRecords = oAllApplications.Data.Count;
               if (oGroupedData.resultCount > 0)
               {
                   oGroupedData.IsSuccess = true;
                   oGroupedData.Message = "Success";
                   oGroupedData.httpStatusCode = HttpStatusCode.OK;
               }
               else
               {
                   oGroupedData.IsSuccess = false;
                   oGroupedData.Message = "Falure";
                   oGroupedData.httpStatusCode = HttpStatusCode.NoContent;
               }
               return oGroupedData;
           }


        // GET 
        [Route("api/LeaveApplicationsApi/GetByEmp/{id}")]
        [HttpGet]
         public ActionResult<List<LeaveApplications>> GetByEmpId(int id)
       {
           var result = _leaveManager.GetLeaveApplicationsByEmployee(id);
           return result;
       }

        // GET 
        [Route("api/LeaveApplicationsApi/GetById/{id}")]
        [HttpGet]
        public ActionResult<LeaveApplications> GetByLeaveId(int id)
        {
            var result = _leaveManager.GetLeaveApplicationById(id);           
            return result;
        }

        // GET 
          [Authorize(Roles = "manager,admin")]
        [Route("api/LeaveApplicationsApi/GetByManagerId/{id}")]
        [HttpGet]
        public ActionResult<List<LeaveApplications>> GetByManagerId(int id)
        {
            var result = _leaveManager.GetLeaveApplicationsByManagerId(id);
            return result;
        }

        

       // POST 
        [Route("api/LeaveApplicationsApi/AddLeave")]
        [HttpPost]
        public ActionResult<LeaveApplications> Post([FromBody]LM.Core.DTO.LeaveApplications leaveApplication)
       {
           try
           {
               if (leaveApplication == null)
               {
                   ActionResult<LeaveApplications> result = new ActionResult<LeaveApplications>();
                   result.IsSuccess = false; 
                   result.ErrorList.Add("You AreTrying to insert  null Values !! Null Values are not allowed");
                   result.Message = "Failed";
                   return result;
               }
               return _leaveManager.AddApplication(leaveApplication);
           }
           catch (MyException<LeaveApplications> e)
           {
               return e.result;
           }


       }

       // PUT 
        [HttpPut]
         [Route("api/LeaveApplicationsApi/UpdateApplication/{leaveId}")]
        public ActionResult<LeaveApplications> Put( int leaveId ,[FromBody]LeaveApplications leaveApplication)
       {
           try
           {
               if (leaveApplication == null)
               {
                   ActionResult<LeaveApplications> result = new ActionResult<LeaveApplications>();
                   result.IsSuccess = false;
                   result.ErrorList.Add("You AreTrying to insert  null Values !! Null Values are not allowed");
                   result.Message = "Failed";
                   return result;
               }
               return _leaveManager.UpdateApplication(leaveId, leaveApplication);
           }
           catch (MyException<LeaveApplications> e)
           {
               return e.result;
           }
       }


        [HttpPut]
        [Route("api/LeaveApplicationsApi/UpdateApplicationStatus/{leaveId}/status/{updatedStatusId}")]
        public ActionResult<LeaveApplications> UpdateApplicationStatus([FromUri ]int leaveId,[FromUri] int updatedStatusId)
        {
            try
            {
                if (leaveId == 0 || updatedStatusId == 0)
                {
                    ActionResult<LeaveApplications> result = new ActionResult<LeaveApplications>();
                    result.IsSuccess = false;
                    result.ErrorList.Add("You AreTrying to insert  null Values !! Null Values are not allowed");
                    result.Message = "Failed";
                    return result;
                }
                return _leaveManager.UpdateApplicationStatus(leaveId, updatedStatusId);
            }
            catch (MyException<LeaveApplications> e)
            {
                return e.result;
            }
        }


       // DELETE 
       public void Delete(int id)
       {
       }




       //// GET 
       [Route("api/LeaveApplicationsApi/GetLeaveBalance/{empId}")]
       [HttpGet]
       public ActionResult<List<LeaveBalances>> Get(int empId)
       {
           var result = _leaveManager.GetLeaveBalanceByEmployee(empId);
           return result;
       }

       //// GET 
       [Route("api/LeaveApplicationsApi/GetLeaveTypes")]
       [HttpGet]
       public ActionResult<List<LeaveTypes>> GetLeaveTypes()
       {
           var result = _leaveManager.GetLeaveTypes();
           return result;
       }

       // POST 
            [Authorize(Roles = "admin")]
          [Route("api/LeaveApplicationsApi/AddLeaveType/{addedByEmpId}")]
          [HttpPost]
       public ActionResult<LeaveTypes> Post( int addedByEmpId,[FromBody]LeaveTypes leaveType)
       {
           try
           {
               if (leaveType == null)
               {
                   ActionResult<LeaveTypes> result = new ActionResult<LeaveTypes>();
                   result.IsSuccess = false;
                   result.ErrorList.Add("You AreTrying to insert  null Values !! Null Values are not allowed");
                   result.Message = "Failed";
                   return result;
               }
               return _leaveManager.AddLeaveType(addedByEmpId, leaveType);
           }
           catch (MyException<LeaveTypes> e)
           {
               return e.result;
           }


       }
 
      


    }
}
