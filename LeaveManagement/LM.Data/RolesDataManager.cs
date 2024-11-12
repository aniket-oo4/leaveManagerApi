using LM.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Data
{
    public  class RolesDataManager
    {

          private readonly DbConnectionHelper _dbConnectionHelper;
          public RolesDataManager()
            {
            _dbConnectionHelper = new DbConnectionHelper();
            }

        //Get All Applications
          public List<UserRolesModel> GetAllRoles()
        {
            List<UserRolesModel> roles = new List<UserRolesModel>();
            using (SqlConnection connection = _dbConnectionHelper.CreateConnection())
            {
                connection.Open();
                SqlCommand command;
                const string Query = "select Ur.roleId,Ur.roleName,UR.createdAt,Ur.updatedAt,Ur.createdBy ,E.firstName as createdByName,Ur.updatedBy,E.firstName as updatedByName from UserRoles  UR left join Employees E on Ur.createdBy=E.empId  ";
                command = new SqlCommand(Query, connection);
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    UserRolesModel role = new UserRolesModel();
                    role.roleId = int.Parse(dataReader["roleId"].ToString());
                    role.roleName = dataReader["roleName"].ToString();
                    role.createdBy = int.Parse(dataReader["createdBy"].ToString());
                    role.createdByName = dataReader["createdByName"].ToString();
                    role.updatedBy = int.Parse(dataReader["updatedBy"].ToString());
                    role.updatedByName = dataReader["updatedByName"].ToString();
                    role.createdAt = Convert.ToDateTime(dataReader["createdAt"]);
                    role.updatedAt = Convert.ToDateTime(dataReader["updatedAt"]);
                    roles.Add(role);
                }
                connection.Close();
                return roles;
            }
            return null;
        }

    }
}
