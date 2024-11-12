using LM.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Data
{
    public class EmployeeDataManager
    {
        private readonly DbConnectionHelper _dbConnectionHelper;
        public EmployeeDataManager()
        {
            _dbConnectionHelper = new DbConnectionHelper();
        }


        public List<EmployeesModel> GetAllEmployees(int empId)
        {
            List<EmployeesModel> employees = new List<EmployeesModel>();
            using (SqlConnection connection = _dbConnectionHelper.CreateConnection())
            {
                connection.Open();

                String Query = @"Select E.empId,E.firstName,E.lastName, E.emailAddress, E.birthDate ,E.city,E.createdAt,E.updatedAt ,E.userId,E.dptId,D.dptName,D.location,E.costCenterId,C.Name as CostCenterName,E.roleId ,UR.roleName,E.managerId,(select firstName from Employees where Employees.empId=E.managerId) as managerName ,E.orgId ,O.name as orgName from Employees E  Left Join Organisations O on E.orgId=O.orgId  Left Join Departments D on E.dptId=D.dptId  Left Join CostCenters C on E.costCenterId=C.costCenterId  Left Join UserRoles UR on E.roleId=UR.roleId  Where E.empId <>@empId";
                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.Add("@empId", empId);
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    EmployeesModel employee = new EmployeesModel();
                    employee.empId = int.Parse(dataReader["empId"].ToString());
                    employee.firstName = dataReader["firstName"].ToString();
                    employee.lastName = dataReader["lastName"].ToString();
                    employee.emailAddress = dataReader["emailAddress"].ToString();
                    employee.birthDate = DateTime.Parse(dataReader["birthDate"].ToString());
                    employee.city = dataReader["city"].ToString();
                    employee.createdAt = DateTime.Parse(dataReader["createdAt"].ToString());
                    employee.updatedAt = DateTime.Parse(dataReader["updatedAt"].ToString());
                    employee.userId = int.Parse(dataReader["userId"].ToString());
                    employee.dptId = int.Parse(dataReader["dptId"].ToString());
                    employee.costCenterId = int.Parse(dataReader["costCenterId"].ToString());
                    employee.roleId = int.Parse(dataReader["roleId"].ToString());

                    if (!dataReader.IsDBNull(dataReader.GetOrdinal("managerId")))
                    {
                        employee.managerId = int.Parse(dataReader["managerId"].ToString());
                    }
                    else
                    {
                        employee.managerId = null;
                    }
                    employee.orgId = int.Parse(dataReader["orgId"].ToString());

                    employee.dptName = dataReader["dptName"].ToString();
                    employee.location = dataReader["location"].ToString();
                    employee.costCenterName = dataReader["costCenterName"].ToString();
                    employee.roleName = dataReader["roleName"].ToString();
                    employee.managerName = dataReader["managerName"].ToString();
                    employee.orgName = dataReader["orgName"].ToString();

                    employees.Add(employee);
                }

                return employees;
                connection.Close();
            }
            return null;
        }

        public EmployeesModel GetEmployeeById(int empId)
        {
            EmployeesModel employee = new EmployeesModel();
            using (SqlConnection connection = _dbConnectionHelper.CreateConnection())
            {
                connection.Open();

                String Query = @"Select E.empId,E.firstName,E.lastName, E.emailAddress, E.birthDate ,E.city,E.createdAt,E.updatedAt ,E.userId,E.dptId,D.dptName,D.location,E.costCenterId,C.Name as CostCenterName,E.roleId ,UR.roleName,E.managerId,(select firstName from Employees where Employees.empId=E.managerId) as managerName ,E.orgId ,O.name as orgName from Employees E  Left Join Organisations O on E.orgId=O.orgId  Left Join Departments D on E.dptId=D.dptId  Left Join CostCenters C on E.costCenterId=C.costCenterId  Left Join UserRoles UR on E.roleId=UR.roleId  Where E.empId =@empId";
                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.Add("@empId", empId);
                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                   
                    employee.empId = int.Parse(dataReader["empId"].ToString());
                    employee.firstName = dataReader["firstName"].ToString();
                    employee.lastName = dataReader["lastName"].ToString();
                    employee.emailAddress = dataReader["emailAddress"].ToString();
                    employee.birthDate = DateTime.Parse(dataReader["birthDate"].ToString());
                    employee.city = dataReader["city"].ToString();
                    employee.createdAt = DateTime.Parse(dataReader["createdAt"].ToString());
                    employee.updatedAt = DateTime.Parse(dataReader["updatedAt"].ToString());
                    employee.userId = int.Parse(dataReader["userId"].ToString());
                    employee.dptId = int.Parse(dataReader["dptId"].ToString());
                    employee.costCenterId = int.Parse(dataReader["costCenterId"].ToString());
                    employee.roleId = int.Parse(dataReader["roleId"].ToString());
                    if (!dataReader.IsDBNull(dataReader.GetOrdinal("managerId")))
                    {
                        employee.managerId = int.Parse(dataReader["managerId"].ToString());
                    }
                    else
                    {
                        employee.managerId = null;
                    }
                    employee.orgId = int.Parse(dataReader["orgId"].ToString());
                    employee.dptName = dataReader["dptName"].ToString();
                    employee.location = dataReader["location"].ToString();
                    employee.costCenterName = dataReader["costCenterName"].ToString();
                    employee.roleName = dataReader["roleName"].ToString();
                    employee.managerName = dataReader["managerName"].ToString();
                    employee.orgName = dataReader["orgName"].ToString();
                    return employee;
                  
                }
                connection.Close();
            }
            return null;
        }

        public EmployeesModel GetByUserId(int userId)
        {
            EmployeesModel employee = new EmployeesModel();
            using (SqlConnection connection = _dbConnectionHelper.CreateConnection())
            {
                connection.Open();

                String Query = @"Select E.empId,E.firstName,E.lastName, E.emailAddress, E.birthDate ,E.city,E.createdAt,E.updatedAt ,E.userId,E.dptId,D.dptName,D.location,E.costCenterId,C.Name as CostCenterName,E.roleId ,UR.roleName,E.managerId,(select firstName from Employees where Employees.empId=E.managerId) as managerName ,E.orgId ,O.name as orgName from Employees E  Left Join Organisations O on E.orgId=O.orgId  Left Join Departments D on E.dptId=D.dptId  Left Join CostCenters C on E.costCenterId=C.costCenterId  Left Join UserRoles UR on E.roleId=UR.roleId  Where E.userId =@userId";
                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.Add("@userId", userId);
                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {

                    employee.empId = int.Parse(dataReader["empId"].ToString());
                    employee.firstName = dataReader["firstName"].ToString();
                    employee.lastName = dataReader["lastName"].ToString();
                    employee.emailAddress = dataReader["emailAddress"].ToString();
                    employee.birthDate = DateTime.Parse(dataReader["birthDate"].ToString());
                    employee.city = dataReader["city"].ToString();
                    employee.createdAt = DateTime.Parse(dataReader["createdAt"].ToString());
                    employee.updatedAt = DateTime.Parse(dataReader["updatedAt"].ToString());
                    employee.userId = int.Parse(dataReader["userId"].ToString());
                    employee.dptId = int.Parse(dataReader["dptId"].ToString());
                    employee.costCenterId = int.Parse(dataReader["costCenterId"].ToString());
                    employee.roleId = int.Parse(dataReader["roleId"].ToString());
                    if (!dataReader.IsDBNull(dataReader.GetOrdinal("managerId")))
                    {
                        employee.managerId = int.Parse(dataReader["managerId"].ToString());
                    }
                    else
                    {
                        employee.managerId = null;
                    }
                    employee.orgId = int.Parse(dataReader["orgId"].ToString());
                    employee.dptName = dataReader["dptName"].ToString();
                    employee.location = dataReader["location"].ToString();
                    employee.costCenterName = dataReader["costCenterName"].ToString();
                    employee.roleName = dataReader["roleName"].ToString();
                    employee.managerName = dataReader["managerName"].ToString();
                    employee.orgName = dataReader["orgName"].ToString();
                    return employee;

                }
                connection.Close();
            }
            return null;
        }



        public List<EmployeesModel> GetAllByManagerId(int managerId)
        {
            List<EmployeesModel> employees = new List<EmployeesModel>();
            using (SqlConnection connection = _dbConnectionHelper.CreateConnection())
            {
                connection.Open();

                String Query = @"Select E.empId,E.firstName,E.lastName, E.emailAddress, E.birthDate ,E.city,E.createdAt,E.updatedAt ,E.userId,E.dptId,D.dptName,D.location,E.costCenterId,C.Name as CostCenterName,E.roleId ,UR.roleName,E.managerId,(select firstName from Employees where Employees.empId=E.managerId) as managerName ,E.orgId ,O.name as orgName from Employees E  Left Join Organisations O on E.orgId=O.orgId  Left Join Departments D on E.dptId=D.dptId  Left Join CostCenters C on E.costCenterId=C.costCenterId  Left Join UserRoles UR on E.roleId=UR.roleId  Where E.managerId =@managerId";
                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.Add("@managerId", managerId);
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    EmployeesModel employee = new EmployeesModel();
                    employee.empId = int.Parse(dataReader["empId"].ToString());
                    employee.firstName = dataReader["firstName"].ToString();
                    employee.lastName = dataReader["lastName"].ToString();
                    employee.emailAddress = dataReader["emailAddress"].ToString();
                    employee.birthDate = DateTime.Parse(dataReader["birthDate"].ToString());
                    employee.city = dataReader["city"].ToString();
                    employee.createdAt = DateTime.Parse(dataReader["createdAt"].ToString());
                    employee.updatedAt = DateTime.Parse(dataReader["updatedAt"].ToString());
                    employee.userId = int.Parse(dataReader["userId"].ToString());
                    employee.dptId = int.Parse(dataReader["dptId"].ToString());
                    employee.costCenterId = int.Parse(dataReader["costCenterId"].ToString());
                    employee.roleId = int.Parse(dataReader["roleId"].ToString());

                    if (!dataReader.IsDBNull(dataReader.GetOrdinal("managerId")))
                    {
                        employee.managerId = int.Parse(dataReader["managerId"].ToString());
                    }
                    else
                    {
                        employee.managerId = null;
                    }
                    employee.orgId = int.Parse(dataReader["orgId"].ToString());

                    employee.dptName = dataReader["dptName"].ToString();
                    employee.location = dataReader["location"].ToString();
                    employee.costCenterName = dataReader["costCenterName"].ToString();
                    employee.roleName = dataReader["roleName"].ToString();
                    employee.managerName = dataReader["managerName"].ToString();
                    employee.orgName = dataReader["orgName"].ToString();

                    employees.Add(employee);
                }

                return employees;
                connection.Close();
            }
            return null;
        }

        //Add Employee
        public EmployeesModel AddEmployee(EmployeesModel employee)
        {

            using (SqlConnection connection = _dbConnectionHelper.CreateConnection())
            {
                connection.Open();

                String Query = "insert into Employees (firstName,lastName,emailAddress,birthDate,city,createdAt,updatedAt,userId,dptId,costCenterId,roleId,managerId,orgId ) values (@firstName,@lastName,@emailAddress,@birthDate,@city,@createdAt,@updatedAt,@userId,@dptId,@costCenterId,@roleId,@managerId,@orgId);select scope_identity()";
                SqlCommand command = new SqlCommand(Query, connection);

                command.Parameters.Add("@firstName", employee.firstName);
                command.Parameters.Add("@lastName", employee.lastName);
                command.Parameters.Add("@emailAddress", employee.emailAddress);
                command.Parameters.Add("@birthDate", employee.birthDate);
                command.Parameters.Add("@city", employee.city);
                command.Parameters.Add("@createdAt", employee.createdAt);
                command.Parameters.Add("@updatedAt", employee.updatedAt);
                command.Parameters.Add("@userId", employee.userId);
                command.Parameters.Add("@dptId", employee.dptId);
                command.Parameters.Add("@costCenterId", employee.costCenterId);
                command.Parameters.Add("@roleId", employee.roleId);
                command.Parameters.Add("@managerId", employee.managerId);
                command.Parameters.Add("@orgId", employee.orgId);
                employee.empId = int.Parse(command.ExecuteScalar().ToString());
                if (employee.empId > 0)
                {
                    return GetEmployeeById(employee.empId);
                }

                connection.Close();
            }
            return null;

        }

        //update Employee
        public EmployeesModel UpdateEmployee(int empId, EmployeesModel employee)
        {
            using (SqlConnection connection = _dbConnectionHelper.CreateConnection())
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                EmployeesModel oldEmployee = GetEmployeeById(empId);
                String Query ="";
                int flag = 0;
                if (!String.Equals(oldEmployee.firstName, employee.firstName))
                {
                    Query = "update Employees  set firstName=@firstName where empId=@empId;";
                    command.CommandText = Query;
                    command.Parameters.AddWithValue("@firstName", employee.firstName);
                    command.Parameters.AddWithValue("@empId", empId);
                    command.ExecuteNonQuery();
                    flag = 1;
                }
                if (!String.Equals(oldEmployee.lastName, employee.lastName))
                {
                    Query = "update Employees  set lastName=@lastName where empId=@empId;";
                    command.CommandText = Query;
                    command.Parameters.AddWithValue("@lastName", employee.lastName);
                    command.Parameters.AddWithValue("@empId", empId);
                    command.ExecuteNonQuery();
                    flag = 1;
                }
                if (!String.Equals(oldEmployee.emailAddress, employee.emailAddress))
                {
                    Query = "update Employees  set emailAddress=@emailAddress where empId=@empId;";
                    command.CommandText = Query;
                    command.Parameters.AddWithValue("@emailAddress", employee.emailAddress);
                    command.Parameters.AddWithValue("@empId", empId);
                    command.ExecuteNonQuery();
                    flag = 1;
                }

                if ( DateTime.Compare( oldEmployee.birthDate, employee.birthDate)!=0 )
                {
                    Query = "update Employees  set birthDate=@birthDate where empId=@empId;";
                    command.CommandText = Query;
                    command.Parameters.AddWithValue("@birthDate", employee.birthDate);
                    command.Parameters.AddWithValue("@empId", empId);
                    command.ExecuteNonQuery();
                    flag = 1;
                }

                if (!String.Equals(oldEmployee.city, employee.city))
                {
                    Query = "update Employees  set city=@city where empId=@empId;";
                    command.CommandText = Query;
                    command.Parameters.AddWithValue("@city", employee.city);
                    command.Parameters.AddWithValue("@empId", empId);
                    command.ExecuteNonQuery();
                    flag = 1;
                }
                if (oldEmployee.dptId != employee.dptId)
                {
                    Query = "update Employees  set dptId=@dptId where empId=@empId;";
                    command.CommandText = Query;
                    command.Parameters.AddWithValue("@dptId", employee.dptId);
                    command.Parameters.AddWithValue("@empId", empId);
                    command.ExecuteNonQuery();
                    flag = 1;
                }

                if (oldEmployee.costCenterId != employee.costCenterId)
                {
                    Query = "update Employees  set costCenterId=@costCenterId where empId=@empId;";
                    command.CommandText = Query;
                    command.Parameters.AddWithValue("@costCenterId", employee.costCenterId);
                    command.Parameters.AddWithValue("@empId", empId);
                    command.ExecuteNonQuery();
                    flag = 1;
                }
                if (oldEmployee.roleId != employee.roleId)
                {
                    Query = "update Employees  set roleId=@roleId where empId=@empId;";
                    command.CommandText = Query;
                    command.Parameters.AddWithValue("@roleId", employee.roleId);
                    command.Parameters.AddWithValue("@empId", empId);
                    command.ExecuteNonQuery();
                    flag = 1;
                }
                if (oldEmployee.managerId != employee.managerId)
                {
                    Query = "update Employees  set managerId=@managerId where empId=@empId;";
                    command.CommandText = Query;
                    command.Parameters.AddWithValue("@managerId", employee.managerId);
                    command.Parameters.AddWithValue("@empId", empId);
                    command.ExecuteNonQuery();
                    flag = 1;
                }

                if (flag==1)
                {
                    Query = "update Employees  set updatedAt=@updatedAt where empId=@Id;";
                    command.CommandText = Query;
                    command.Parameters.AddWithValue("@updatedAt", employee.updatedAt);
                    command.Parameters.AddWithValue("@Id", empId);
                    command.ExecuteNonQuery();
                    flag = 1;
                }
                return GetEmployeeById(empId);
                connection.Close();

            }

            return null;

        }


    }

}
