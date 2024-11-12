using LM.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Data
{
   public  class OrgDataManager
    {
       private readonly DbConnectionHelper _dbConnectionHelper;
       public OrgDataManager()
        {
            _dbConnectionHelper = new DbConnectionHelper();
        }



       
       public List<PublicHolidaysModel> GetAllPublicHolidays(int orgId)
       {
           List<PublicHolidaysModel> publicHolidays = new List<PublicHolidaysModel>();
           using (SqlConnection connection = _dbConnectionHelper.CreateConnection())
           {
               connection.Open();
               SqlCommand command;
               const string Query = "select  holidayId,holidayDate, holidayInfo ,orgId from PublicHolidays  where orgId=@orgId;";
               command = new SqlCommand(Query, connection);
               command.Parameters.Add("@orgId", orgId);
               SqlDataReader dataReader = command.ExecuteReader();
               while (dataReader.Read())
               {

                   PublicHolidaysModel holiday = new PublicHolidaysModel();
                   holiday.holidayId = int.Parse(dataReader["holidayId"].ToString());
                   holiday.holidayDate = Convert.ToDateTime(dataReader["holidayDate"]);
                   holiday.holidayInfo = dataReader["holidayInfo"].ToString();
                   holiday.orgId = int.Parse(dataReader["orgId"].ToString());


                   publicHolidays.Add(holiday);
               }
               return publicHolidays;
               connection.Close();
           }
           return null;
       }

      
       public List<DepartmentsModel> GetAllDepartments(int orgId)
       {
           List<DepartmentsModel> departments = new List<DepartmentsModel>();
           using (SqlConnection connection = _dbConnectionHelper.CreateConnection())
           {
               connection.Open();
               SqlCommand command;
               const string Query = "select dptId,dptName,location,orgId from Departments where orgId=@orgId;";
               command = new SqlCommand(Query, connection);
               command.Parameters.Add("@orgId", orgId);
               SqlDataReader dataReader = command.ExecuteReader();
               while (dataReader.Read())
               {

                   DepartmentsModel department = new DepartmentsModel();
                   department.dptId = int.Parse(dataReader["dptId"].ToString());
                   department.dptName = dataReader["dptName"].ToString();
                   department.location = dataReader["location"].ToString();
                   department.orgId = int.Parse(dataReader["orgId"].ToString());


                   departments.Add(department);
               }
               return departments;
               connection.Close();
           }
           return null;
       }

       public List<CostCentersModel> GetAllCostCenters(int orgId)
       {
           List<CostCentersModel> costCenters = new List<CostCentersModel>();
           using (SqlConnection connection = _dbConnectionHelper.CreateConnection())
           {
               connection.Open();
               SqlCommand command;
               const string Query = "select  costCenterId ,Name, orgId  from CostCenters where orgId=@orgId;";
               command = new SqlCommand(Query, connection);
               command.Parameters.Add("@orgId", orgId);
               SqlDataReader dataReader = command.ExecuteReader();
               while (dataReader.Read())
               {
                   CostCentersModel costCenter = new CostCentersModel();
                   costCenter.costCenterId = int.Parse(dataReader["costCenterId"].ToString());
                   costCenter.costCenterName = dataReader["Name"].ToString();
                   costCenter.orgId = int.Parse(dataReader["orgId"].ToString());
                   costCenters.Add(costCenter);
               }
               return costCenters;
               connection.Close();
           }
           return null;
       }



    }
}
