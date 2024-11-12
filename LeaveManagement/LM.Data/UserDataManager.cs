using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LM.Data.Models;
using System.Data.SqlClient;
namespace LM.Data
{
   public class UserDataManager
    {
       private readonly DbConnectionHelper _dbConnectionHelper;
       public UserDataManager() 
        {
            _dbConnectionHelper = new DbConnectionHelper();
        }



       public UsersModel GetUserByUserName(string userName)
       {
           UsersModel user = null;

           using (var connection = _dbConnectionHelper.CreateConnection())
           {
               connection.Open();
               string Query = "SELECT U.userId, userName, password ,isActive, U.createdAt,U.updatedAt,U.createdby,U.updatedBy ,UR.roleName FROM users U join Employees E on U.userId=E.userId left Join UserRoles Ur on E.roleId =UR.roleId WHERE U.userName = @userName";
               SqlCommand command = new SqlCommand(Query, connection);
               command.Parameters.AddWithValue("@userName", userName);

               using (SqlDataReader dataReader = command.ExecuteReader())
               {
                   if (dataReader.Read())
                   {
                       user = new UsersModel
                       {
                           userId = dataReader.GetInt32(0),
                           userName = dataReader.GetString(1),
                           password = dataReader.GetString(2),
                           isActive = dataReader.GetBoolean(3),
                           createdAt=dataReader.GetDateTime(4),
                           updatedAt = dataReader.GetDateTime(5),
                           createdBy=dataReader.GetInt32(6),
                           updatedBy = dataReader.GetInt32(7),
                           roleName=dataReader.GetString(8)
                       };
                   }
                   connection.Close();
               }
           }

           if (user != null)
           {
               return user;
           }

           return null; // Invalid credentials
       }

       public UsersModel GetUserByUserId(int userId)
       {
           UsersModel user = null;

           using (var connection = _dbConnectionHelper.CreateConnection())
           {
               connection.Open();
               string Query = "SELECT U.userId, userName, password ,isActive, U.createdAt,U.updatedAt,U.createdby,U.updatedBy ,UR.roleName FROM users U join Employees E on U.userId=E.userId left Join UserRoles Ur on E.roleId =UR.roleId WHERE U.userId = @userId";
               SqlCommand command = new SqlCommand(Query, connection);
               command.Parameters.AddWithValue("@userId", userId);

               using (SqlDataReader dataReader = command.ExecuteReader())
               {
                   if (dataReader.Read())
                   {
                       user = new UsersModel
                       {
                           userId = dataReader.GetInt32(0),
                           userName = dataReader.GetString(1),
                           password = dataReader.GetString(2),
                           isActive = dataReader.GetBoolean(3),
                           createdAt = dataReader.GetDateTime(4),
                           updatedAt = dataReader.GetDateTime(5),
                           createdBy = dataReader.GetInt32(6),
                           updatedBy = dataReader.GetInt32(7),
                           roleName = dataReader.GetString(8)
                       };
                   }
                   connection.Close();
               }
           }

           if (user != null)
           {
               return user;
           }

           return null; // Invalid credentials
       }


       //Add User
       public UsersModel AddUser(UsersModel user)
       {

           using (SqlConnection connection = _dbConnectionHelper.CreateConnection())
           {
               connection.Open();

               String Query = "insert into Users  (username ,password,isActive,createdAt,updatedAt,createdBy,updatedBy) values (@username ,@password,@isActive,@createdAt,@updatedAt,@createdBy,@updatedBy);select scope_identity()";
               SqlCommand command = new SqlCommand(Query, connection);

               command.Parameters.Add("@username", user.userName);
               command.Parameters.Add("@password", user.password);
               command.Parameters.Add("@isActive", user.isActive);
               command.Parameters.Add("@createdAt", user.createdAt);
               command.Parameters.Add("@updatedAt", user.updatedAt);
               command.Parameters.Add("@createdBy", user.createdBy);
               command.Parameters.Add("@updatedBy", user.updatedBy);
               
               user.userId = int.Parse(command.ExecuteScalar().ToString());
               if (user.userId > 0)
               {
                   return GetUserByUserId(user.userId);
               }

               connection.Close();
           }
           return null;

       }


       public UsersModel UpdatePasword(int userId, string newPassword)
       {
           using (SqlConnection connection = _dbConnectionHelper.CreateConnection())
           {
               connection.Open();

               String Query = "update Users set password=@password where userId=@userId;select scope_identity()";
               SqlCommand command = new SqlCommand(Query, connection);
               command.Parameters.Add("@password",newPassword);
               command.Parameters.Add("@userId", userId);
                command.ExecuteScalar();
               connection.Close();
           }
           return GetUserByUserId(userId);

       }

       //update Employee
       public UsersModel UpdateUser(int userId, UsersModel user)
       {
           using (SqlConnection connection = _dbConnectionHelper.CreateConnection())
           {
               connection.Open();
               SqlCommand command = connection.CreateCommand();
               UsersModel oldUser = GetUserByUserId(userId);
               String Query = "";
               int flag = 0;
               if (!String.Equals(oldUser.userName, user.userName))
               {
                   Query = "update Users set userName= @userName  where userId=@userId;";
                   command.CommandText = Query;
                   command.Parameters.AddWithValue("@userName", user.userName);
                   command.Parameters.AddWithValue("@userId", userId);
                   command.ExecuteNonQuery();
                   flag = 1;
               }
               if (oldUser.isActive!=user.isActive)
               {
                   Query = "update Users set isActive= @isActive  where userId=;";
                   command.CommandText = Query;
                   command.Parameters.AddWithValue("@isActive", user.isActive);
                   command.Parameters.AddWithValue("@userId", userId);
                   command.ExecuteNonQuery();
                   flag = 1;
               }
              

               if (flag == 1)
               {
                   Query = "update Users  set updatedAt=@updatedAt ,updatedBy=@updatedBy where userId=@Id;";
                   command.CommandText = Query;
                   command.Parameters.AddWithValue("@updatedAt", user.updatedAt);
                   command.Parameters.AddWithValue("@Id", userId);
                   command.Parameters.AddWithValue("@updatedBy", user.updatedBy);
                   command.ExecuteNonQuery();
                   flag = 1;
               }
               return GetUserByUserId(userId);
               connection.Close();
           }

           return null;

       }

       public bool IsUserNameExist(string userName)
       {
           int returnvalue;
           using (SqlConnection connection = _dbConnectionHelper.CreateConnection())
           {
               connection.Open();
               string query = "select count(*) from Users where userName=@userName";
               SqlCommand command = new SqlCommand(query, connection);
               command.Parameters.Add("@userName", userName);
               returnvalue = int.Parse(command.ExecuteScalar().ToString());
           }
           return returnvalue > 0 ? true : false;
       }

       public bool IsUserIdExist(int userId)
       {
           int returnvalue;
           using (SqlConnection connection = _dbConnectionHelper.CreateConnection())
           {
               connection.Open();
               string query = "select count(*) from Users where userId=@userId";
               SqlCommand command = new SqlCommand(query, connection);
               command.Parameters.Add("@userId", userId);
               returnvalue = int.Parse(command.ExecuteScalar().ToString());
           }
           return returnvalue > 0 ? true : false;
       }
        

    }
}
