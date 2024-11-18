using LM.Core.DTO;
using LM.Core.Validators;
using LM.Data;
using LM.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Core.EmployeeManagers
{
   public  class EmployeeManager
    {
       private readonly EmployeeDataManager _employeeDataManager;
      public  EmployeeManager()
       {
           _employeeDataManager = new EmployeeDataManager();

       }


      public ActionResult<List<Employees>> GetAllEmployees(int orgId)
      {
          ActionResult<List<Employees>> result = new ActionResult<List<Employees>>();
          List<Employees> employeeList = new List<Employees>();
          List<EmployeesModel> employeesModels = _employeeDataManager.GetAllEmployees(orgId);

          if (employeesModels.Count != 0)
          {
              foreach (var employeeModel in employeesModels)
              {
                  employeeList.Add(employeeModel.ToEntity());
              }
              result.Data = employeeList;
              result.IsSuccess = true;
              result.resultCount = employeeList.Count;
              result.totalRecords = employeeList.Count;
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

    public ActionResult<Employees> GetEmployeeById(int empId)
    {
        ActionResult<Employees> result = new ActionResult<Employees>();

        EmployeesModel employeeModel = _employeeDataManager.GetEmployeeById(empId);

        if (employeeModel!=null)
        {
            result.Data = employeeModel.ToEntity();
            result.IsSuccess = true;
            result.resultCount = 1;
            result.totalRecords = 1;
            result.Message = "OK";
        }
        else
        {
            result.IsSuccess = false;
            result.ErrorList.Add("Not Any Records Found For EmpId " + empId + "");
            result.Message = "Failed";
        }
        return result;
    }

    public ActionResult<Employees> GetByUserId(int userId)
    {
        ActionResult<Employees> result = new ActionResult<Employees>();

        EmployeesModel employeeModel = _employeeDataManager.GetByUserId(userId);

        if (employeeModel != null)
        {
            result.Data = employeeModel.ToEntity();
            result.IsSuccess = true;
            result.resultCount = 1;
            result.totalRecords = 1;
            result.Message = "OK";
        }
        else
        {
            result.IsSuccess = false;
            result.ErrorList.Add("Not Any Records Found For UserId " + userId + "");
            result.Message = "Failed";
        }
        return result;
    }


    public ActionResult<List<Employees>> GetByManagerId(int managerId)
    {
        ActionResult<List<Employees>> result = new ActionResult<List<Employees>>();
        List<Employees> employeeList = new List<Employees>();
        List<EmployeesModel> employeesModels = _employeeDataManager.GetAllByManagerId(managerId);

        if (employeesModels.Count != 0)
        {
            foreach (var employeeModel in employeesModels)
            {
                employeeList.Add(employeeModel.ToEntity());
            }
            result.Data = employeeList;
            result.IsSuccess = true;
            result.resultCount = employeeList.Count;
            result.totalRecords = employeeList.Count;
            result.Message = "OK";
        }
        else
        {
            result.IsSuccess = false;
            result.ErrorList.Add("Not Any Records Found for employees Who's Manager id :"+managerId+"");
            result.Message = "Failed";
        }
        return result;

    }


    public ActionResult<Employees> AddEmployee(Employees employee)
    {
        ActionResult<Employees> result = new ActionResult<Employees>();

        employee.createdAt = DateTime.Now;
        employee.updatedAt = DateTime.Now;

        result = EmployeeValidator.ValidatePost(employee);
        if (result.ErrorList.Count > 0)
        {
            result.IsSuccess = false;
            result.totalRecords = 0;
            result.resultCount = 0;
            result.Message = "Invalid";
            return result;
        }


        EmployeesModel employeeModel = _employeeDataManager.AddEmployee(employee.ToModel());
        if (employeeModel != null)
        {
            result.Data = employeeModel.ToEntity();
            result.IsSuccess = true;
            result.Message = "OK";
        }
        else
        {
            result.IsSuccess = false;
            result.ErrorList.Add("Employee not added in a System ");
            result.Message = "Failed";
        }
        return result;
    }


    public ActionResult<Employees> UpdateEmployee(int empId,Employees employee)
    {
        ActionResult<Employees> result = new ActionResult<Employees>();
        employee.updatedAt = DateTime.Now;
        EmployeesModel employeeModel = _employeeDataManager.UpdateEmployee(empId,employee.ToModel());

        if (employeeModel != null)
        {
            result.Data = employeeModel.ToEntity();
            result.IsSuccess = true;
            result.resultCount = 1;
            result.totalRecords = 1;
            result.Message = "OK";
        }
        else
        {
            result.IsSuccess = false;
            result.ErrorList.Add("Not Any Records Found For EmpId " + empId + " hence Update Failed");
            result.Message = "Failed";
        }
        return result;
    }


    }
}
