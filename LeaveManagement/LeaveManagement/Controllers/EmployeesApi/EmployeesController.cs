using LM.Core;
using LM.Core.DTO;
using LM.Core.EmployeeManagers;
using LM.Core.UsersManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
namespace LeaveManagement.Controllers.EmployeesApi
{
     [Authorize(Roles = "admin,manager,user")]
    public class EmployeesController : ApiController
    {

       private readonly EmployeeManager _employeeManager;

       public EmployeesController()
        {
            _employeeManager = new EmployeeManager();
        }


        // GET 
          [Authorize(Roles = "admin")]
        [Route("api/Employees/GetAll/{empId}")]
        public ActionResult<List<Employees>> Get(int empId)
        {
            var result = _employeeManager.GetAllEmployees(empId);
            return result;
        }

        // GET 
        [Route("api/Employees/GetByEmpId/{empId}")]
        public ActionResult<Employees> GetById(int empId)
        {
            var result = _employeeManager.GetEmployeeById(empId);
            return result;
        }

        // GET 
        [Route("api/Employees/GetByUserId/{userId}")]
        public ActionResult<Employees> GetByUserId(int userId)
        {
            var result = _employeeManager.GetByUserId(userId);
            return result;
        }


        // GET 
          [Authorize(Roles = "manager,admin")]
        [Route("api/Employees/GetByManagerId/{managerId}")]
        public ActionResult<List<Employees>> GetByManagerId(int managerId)
        {
            var result = _employeeManager.GetByManagerId(managerId);
            return result;
        }


        // POST 
          [Authorize(Roles = "admin")]
         [Route("api/Employees/AddEmployee")]
        public ActionResult<Employees> Post([FromBody]Employees employee)
        {
            try
            {
                if (employee == null)
                {
                    ActionResult<Employees> result = new ActionResult<Employees>();
                    result.IsSuccess = false;
                    result.ErrorList.Add("You AreTrying to insert  null Values !! Null Values are not allowed");
                    result.Message = "Failed";
                    return result;
                }
                return _employeeManager.AddEmployee(employee);
            }
            catch (MyException<Employees> e)
            {
                return e.result;
            }


        }


        //Put 
        [HttpPut]
        [Route("api/Employees/Update/{empId}")]
        public ActionResult<Employees> Put(int empId, [FromBody]Employees employee)
        {
            var result = _employeeManager.UpdateEmployee(empId,employee);
            return result;
        }


    }
}
