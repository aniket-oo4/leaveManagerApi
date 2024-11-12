using LM.Core.CommonUtils;
using LM.Core.DTO;
using LM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Core.Validators
{
    public static class EmployeeValidator
    {
        

        public static ActionResult<Employees> ValidatePost(Employees employee)
        {
            ActionResult<Employees> result = new ActionResult<Employees>();

            EmployeeDataManager _employeeDataManager = new EmployeeDataManager();


            if (Common.IsNullOrDefault<string>(employee.firstName))
            {
                result.ErrorList.Add("firstName cannot be a null or Empty Value ");
            }

            if (Common.IsNullOrDefault<string>(employee.lastName))
            {
                result.ErrorList.Add("lastName cannot be a null or Empty Value ");
            }
            if (Common.IsNullOrDefault<string>(employee.emailAddress))
            {
                result.ErrorList.Add("emailAddress cannot be a null or Empty Value ");
            }
            if (Common.IsNullOrDefault<DateTime>(employee.birthDate))
            {
                result.ErrorList.Add("birthDate cannot be a null or Empty Value ");
            }
            if (Common.IsNullOrDefault<string>(employee.city))
            {
                result.ErrorList.Add("city cannot be a null or Empty Value ");
            }
            if (Common.IsNullOrDefault<int>(employee.userId))
            {
                result.ErrorList.Add("userId cannot be a null or Empty Value ");
            }
            else
            {
                if (_employeeDataManager.GetByUserId(employee.userId) != null)
                {
                    result.ErrorList.Add("Employee already exist for userId :" + employee.userId);
                }
            }
            if (Common.IsNullOrDefault<int>(employee.dptId))
            {
                result.ErrorList.Add("dptId cannot be a null or Empty Value ");
            }
            if (Common.IsNullOrDefault<int>(employee.costCenterId))
            {
                result.ErrorList.Add("costCenterId cannot be a null or Empty Value ");
            }
            if (Common.IsNullOrDefault<int>(employee.roleId))
            {
                result.ErrorList.Add("roleId cannot be a null or Empty Value ");
            }
            if (Common.IsNullOrDefault<Nullable<int>>(employee.managerId))
            {
                result.ErrorList.Add("managerId cannot be a null or Empty Value ");
            }
            else 
            {
                if (_employeeDataManager.GetEmployeeById(Convert.ToInt32(employee.managerId)) == null)
                {
                    result.ErrorList.Add("Not Such Manager Exisist for Id :: "+employee.managerId);
                }
                else if (_employeeDataManager.GetEmployeeById(Convert.ToInt32(employee.managerId)).roleId != 3)
                {
                    result.ErrorList.Add("The Employee with id:: " + employee.managerId +"that you want to assign is not a Manager ");
                }
            }
            if (Common.IsNullOrDefault<int>(employee.orgId))
            {
                result.ErrorList.Add("orgId cannot be a null or Empty Value ");
            }



            return result;
        }
    }
}
