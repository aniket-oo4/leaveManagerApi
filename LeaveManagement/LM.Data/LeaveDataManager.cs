using LM.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LM.Data
{
    public class LeaveDataManager
    {
        private readonly DbConnectionHelper _dbConnectionHelper;
        public LeaveDataManager()
        {
            _dbConnectionHelper = new DbConnectionHelper();
        }

        /*
         * 
         * using (SqlConnection connection =_dbConnectionHelper.CreateConnection()){
                connection.Open();


                connection.Close();
            }
         * 
         * */

        //Get All Applications
        public List<LeaveApplicationsModel> GetAllLeaveApplications()
        {
            List<LeaveApplicationsModel> leaveApplications = new List<LeaveApplicationsModel>();
            using (SqlConnection connection = _dbConnectionHelper.CreateConnection())
            {
                connection.Open();
                SqlCommand command;
                const string Query = "SELECT LA.leaveId,LA.empId,E.firstName,lastName ,LT.leaveTypeId,Lt.leaveType As LeaveType,Format(LA.ApplicationDate,'dd MMMM yyyy') AS ApplicationDate,Format(LA.leaveDateFrom,'dd MMM yyyy') AS  StartDate,Format(LA.leaveDateTo,'dd MMM yyyy') AS EndDate ,LA.remark , S.statusId, s.statusName As Status ,La.totalLeaves   TotalLeaves , Format(LA.updatedDate,'dd MMM yyyy') AS UpdatedDate FROM LeaveApplications LA left Join LeaveTypes LT  On La.leaveTypeId=Lt.leaveTypeId Left Join ApplicationStatus S  On  La.statusId=S.statusId Left Join Employees E on LA.empId = E.empId ";
                command = new SqlCommand(Query, connection);
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {

                    LeaveApplicationsModel leaveApplication = new LeaveApplicationsModel();
                    leaveApplication.leaveId = int.Parse(dataReader["leaveId"].ToString());
                    leaveApplication.empId = int.Parse(dataReader["empId"].ToString());
                    leaveApplication.firstName = dataReader["firstName"].ToString();
                    leaveApplication.lastName = dataReader["lastName"].ToString();
                    leaveApplication.leaveTypeId = int.Parse(dataReader["leaveTypeId"].ToString());
                    leaveApplication.leaveType = dataReader["leaveType"].ToString();
                    leaveApplication.totalLeaves = int.Parse(dataReader["TotalLeaves"].ToString());
                    leaveApplication.applicationDate = Convert.ToDateTime(dataReader["ApplicationDate"]);
                    leaveApplication.leaveDateFrom = Convert.ToDateTime(dataReader["startDate"]);
                    leaveApplication.leaveDateTo = Convert.ToDateTime(dataReader["endDate"]);
                    leaveApplication.remark = dataReader["remark"].ToString();
                    leaveApplication.statusId = int.Parse(dataReader["statusId"].ToString());
                    leaveApplication.statusName = dataReader["Status"].ToString();
                    leaveApplication.updatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]);
                    leaveApplications.Add(leaveApplication);
                }
                connection.Close();
                return leaveApplications;
            }
            return null;
        }


        //By Employee
        public List<LeaveApplicationsModel> GetLeaveApplicationsByEmployee(int EmpID)
        {
            List<LeaveApplicationsModel> leaveApplications = new List<LeaveApplicationsModel>();
            using (SqlConnection connection = _dbConnectionHelper.CreateConnection())
            {
                connection.Open();
                SqlCommand command;
                const string Query = "SELECT LA.leaveId,LA.empId,E.firstName,lastName ,LT.leaveTypeId,Lt.leaveType As LeaveType,Format(LA.ApplicationDate,'dd MMMM yyyy') AS ApplicationDate,Format(LA.leaveDateFrom,'dd MMM yyyy') AS  StartDate,Format(LA.leaveDateTo,'dd MMM yyyy') AS EndDate ,LA.remark , S.statusId, s.statusName As Status ,La.totalLeaves   TotalLeaves , Format(LA.updatedDate,'dd MMM yyyy') AS UpdatedDate FROM LeaveApplications LA left Join LeaveTypes LT  On La.leaveTypeId=Lt.leaveTypeId Left Join ApplicationStatus S  On  La.statusId=S.statusId Left Join Employees E on LA.empId = E.empId Where La.empId=@empId;";
                command = new SqlCommand(Query, connection);
                command.Parameters.Add("@empId", EmpID);
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {

                    LeaveApplicationsModel leaveApplication = new LeaveApplicationsModel();
                    leaveApplication.leaveId = int.Parse(dataReader["leaveId"].ToString());
                    leaveApplication.empId = int.Parse(dataReader["empId"].ToString());
                    leaveApplication.firstName = dataReader["firstName"].ToString();
                    leaveApplication.lastName = dataReader["lastName"].ToString();
                    leaveApplication.leaveTypeId = int.Parse(dataReader["leaveTypeId"].ToString());
                    leaveApplication.leaveType = dataReader["leaveType"].ToString();
                    leaveApplication.totalLeaves = int.Parse(dataReader["TotalLeaves"].ToString());
                    leaveApplication.applicationDate = Convert.ToDateTime(dataReader["ApplicationDate"]);
                    leaveApplication.leaveDateFrom = Convert.ToDateTime(dataReader["startDate"]);
                    leaveApplication.leaveDateTo = Convert.ToDateTime(dataReader["endDate"]);
                    leaveApplication.remark = dataReader["remark"].ToString();
                    leaveApplication.statusId = int.Parse(dataReader["statusId"].ToString());
                    leaveApplication.statusName = dataReader["Status"].ToString();
                    leaveApplication.updatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]);

                    leaveApplications.Add(leaveApplication);
                }
                return leaveApplications;
                connection.Close();
            }
            return null;
        }

        //By Manager
        public List<LeaveApplicationsModel> GetLeaveApplicationsByManager(int managerId)
        {
            List<LeaveApplicationsModel> leaveApplications = new List<LeaveApplicationsModel>();
            using (SqlConnection connection = _dbConnectionHelper.CreateConnection())
            {
                connection.Open();
                SqlCommand command;
                const string Query = "SELECT LA.leaveId,LA.empId,E.firstName,lastName ,LT.leaveTypeId,Lt.leaveType As LeaveType,Format(LA.ApplicationDate,'dd MMMM yyyy') AS ApplicationDate,Format(LA.leaveDateFrom,'dd MMM yyyy') AS  StartDate,Format(LA.leaveDateTo,'dd MMM yyyy') AS EndDate ,LA.remark , S.statusId, s.statusName As Status ,La.totalLeaves   TotalLeaves , Format(LA.updatedDate,'dd MMM yyyy') AS UpdatedDate FROM LeaveApplications LA left Join LeaveTypes LT  On La.leaveTypeId=Lt.leaveTypeId Left Join ApplicationStatus S  On  La.statusId=S.statusId Left Join Employees E on LA.empId = E.empId Where E.managerId=@managerId;";
                command = new SqlCommand(Query, connection);
                command.Parameters.Add("@managerId", managerId);
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {

                    LeaveApplicationsModel leaveApplication = new LeaveApplicationsModel();
                    leaveApplication.leaveId = int.Parse(dataReader["leaveId"].ToString());
                    leaveApplication.empId = int.Parse(dataReader["empId"].ToString());
                    leaveApplication.firstName = dataReader["firstName"].ToString();
                    leaveApplication.lastName = dataReader["lastName"].ToString();
                    leaveApplication.leaveTypeId = int.Parse(dataReader["leaveTypeId"].ToString());
                    leaveApplication.leaveType = dataReader["leaveType"].ToString();
                    leaveApplication.totalLeaves = int.Parse(dataReader["TotalLeaves"].ToString());
                    leaveApplication.applicationDate = Convert.ToDateTime(dataReader["ApplicationDate"]);
                    leaveApplication.leaveDateFrom = Convert.ToDateTime(dataReader["startDate"]);
                    leaveApplication.leaveDateTo = Convert.ToDateTime(dataReader["endDate"]);
                    leaveApplication.remark = dataReader["remark"].ToString();
                    leaveApplication.statusId = int.Parse(dataReader["statusId"].ToString());
                    leaveApplication.statusName = dataReader["Status"].ToString();
                    leaveApplication.updatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]);

                    leaveApplications.Add(leaveApplication);
                }
                connection.Close();
                return leaveApplications;
            }
            return null;
        }



        //ByLeaveId
        public LeaveApplicationsModel GetLeaveApplicationByLeaveId(int leaveId)
        {
            LeaveApplicationsModel leaveApplication = new LeaveApplicationsModel();
            using (SqlConnection connection = _dbConnectionHelper.CreateConnection())
            {
                connection.Open();
                SqlCommand command;
                const string Query = "SELECT LA.leaveId,LA.empId,E.firstName,lastName ,LT.leaveTypeId,Lt.leaveType As LeaveType,Format(LA.ApplicationDate,'dd MMMM yyyy') AS ApplicationDate,Format(LA.leaveDateFrom,'dd MMM yyyy') AS  StartDate,Format(LA.leaveDateTo,'dd MMM yyyy') AS EndDate ,LA.remark , S.statusId, s.statusName As Status ,La.totalLeaves   TotalLeaves , Format(LA.updatedDate,'dd MMM yyyy') AS UpdatedDate FROM LeaveApplications LA left Join LeaveTypes LT  On La.leaveTypeId=Lt.leaveTypeId Left Join ApplicationStatus S  On  La.statusId=S.statusId Left Join Employees E on LA.empId = E.empId Where LA.leaveId=@leaveId;";
                command = new SqlCommand(Query, connection);
                command.Parameters.Add("@leaveId", leaveId);
                SqlDataReader dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    leaveApplication.leaveId = int.Parse(dataReader["leaveId"].ToString());
                    leaveApplication.empId = int.Parse(dataReader["empId"].ToString());
                    leaveApplication.firstName = dataReader["firstName"].ToString();
                    leaveApplication.lastName = dataReader["lastName"].ToString();
                    leaveApplication.leaveTypeId = int.Parse(dataReader["leaveTypeId"].ToString());
                    leaveApplication.leaveType = dataReader["leaveType"].ToString();
                    leaveApplication.totalLeaves = int.Parse(dataReader["TotalLeaves"].ToString());
                    leaveApplication.applicationDate = Convert.ToDateTime(dataReader["ApplicationDate"]);
                    leaveApplication.leaveDateFrom = Convert.ToDateTime(dataReader["startDate"]);
                    leaveApplication.leaveDateTo = Convert.ToDateTime(dataReader["endDate"]);
                    leaveApplication.remark = dataReader["remark"].ToString();
                    leaveApplication.statusId = int.Parse(dataReader["statusId"].ToString());
                    leaveApplication.statusName = dataReader["Status"].ToString();
                    leaveApplication.updatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]);

                    return leaveApplication;
                }
                connection.Close();

            }
            return null;
        }



        //Add Application 
        public LeaveApplicationsModel AddApplication(LeaveApplicationsModel leaveApplication)
        {

            using (SqlConnection connection = _dbConnectionHelper.CreateConnection())
            {
                connection.Open();

                String Query = "INSERT INTO LeaveApplications (leaveTypeId, leaveDateFrom, leaveDateTo, remark, statusId, applicationDate, updatedDate, empId,totalLeaves) VALUES (@leaveTypeId, @leaveDateFrom, @leaveDateTo, @remark, @statusId, @applicationDate, @updatedDate, @empId,@totalLeaves);select scope_identity()";
                SqlCommand command = new SqlCommand(Query, connection);

                command.Parameters.Add("@leaveTypeId", leaveApplication.leaveTypeId);
                command.Parameters.Add("@leaveDateFrom", leaveApplication.leaveDateFrom);
                command.Parameters.Add("@leaveDateTo", leaveApplication.leaveDateTo);
                command.Parameters.Add("@remark", leaveApplication.remark);
                command.Parameters.Add("@statusId", leaveApplication.statusId);
                command.Parameters.Add("@applicationDate", leaveApplication.applicationDate);
                command.Parameters.Add("@updatedDate", leaveApplication.updatedDate);
                command.Parameters.Add("@empId", leaveApplication.empId);
                command.Parameters.Add("@totalLeaves", leaveApplication.totalLeaves);
                leaveApplication.leaveId = int.Parse(command.ExecuteScalar().ToString());

                string temp = @"update LeaveBalances set currentBalance =currentBalance-@totalLeaves where empId=@empId and leaveTypeId=@leaveTypeId";
                        command = new SqlCommand(temp, connection);
                        command.Parameters.Add("@totalLeaves", leaveApplication.totalLeaves);
                        command.Parameters.Add("@empId", leaveApplication.empId);
                        command.Parameters.Add("@leaveTypeId", leaveApplication.leaveTypeId);
                        command.ExecuteNonQuery();
                    
                connection.Close();
            }
            return GetLeaveApplicationByLeaveId(leaveApplication.leaveId);

        }



        //update Leave Application 
        public LeaveApplicationsModel UpdateApplication(int leaveId, LeaveApplicationsModel leaveApplication)
        {
            using (SqlConnection connection = _dbConnectionHelper.CreateConnection())
            {
                connection.Open();
                SqlCommand command;


                LeaveApplicationsModel oldLeave = GetLeaveApplicationByLeaveId(leaveId);
                string temp = "";

                if (oldLeave.leaveTypeId == leaveApplication.leaveTypeId)
                {
                    if (oldLeave.totalLeaves < leaveApplication.totalLeaves)
                    {
                        temp = @"update LeaveBalances set currentBalance =currentBalance-@totalLeaves where empId=@empId and leaveTypeId=@leaveTypeId";
                        command = new SqlCommand(temp, connection);
                        command.Parameters.Add("@totalLeaves", leaveApplication.totalLeaves - oldLeave.totalLeaves);
                        command.Parameters.Add("@empId", leaveApplication.empId);
                        command.Parameters.Add("@leaveTypeId", leaveApplication.leaveTypeId);
                        command.ExecuteNonQuery();

                    }
                    else if (oldLeave.totalLeaves > leaveApplication.totalLeaves)
                    {
                        temp = @"update LeaveBalances set currentBalance =currentBalance+@totalLeaves where empId=@empId and leaveTypeId=@leaveTypeId";
                        command = new SqlCommand(temp, connection);
                        command.Parameters.Add("@totalLeaves", leaveApplication.totalLeaves - oldLeave.totalLeaves);
                        command.Parameters.Add("@empId", leaveApplication.empId);
                        command.Parameters.Add("@leaveTypeId", leaveApplication.leaveTypeId);
                        command.ExecuteNonQuery();
                    }
                }
                else
                {

                    temp = @"update LeaveBalances set currentBalance =currentBalance-@totalLeaves where empId=@empId and leaveTypeId=@leaveTypeId";
                    command = new SqlCommand(temp, connection);
                    command.Parameters.Add("@totalLeaves", leaveApplication.totalLeaves);
                    command.Parameters.Add("@empId", leaveApplication.empId);
                    command.Parameters.Add("@leaveTypeId", leaveApplication.leaveTypeId);
                    command.ExecuteNonQuery();


                    temp = @"update LeaveBalances set currentBalance =currentBalance+@totalLeaves where empId=@empId and leaveTypeId=@leaveTypeId";
                    command = new SqlCommand(temp, connection);
                    command.Parameters.Add("@totalLeaves", oldLeave.totalLeaves);
                    command.Parameters.Add("@empId", leaveApplication.empId);
                    command.Parameters.Add("@leaveTypeId", oldLeave.leaveTypeId);
                    command.ExecuteNonQuery();

                }

                ////status
                //if (oldLeave.statusId != leaveApplication.statusId && oldLeave.statusId == 1)
                //{
                //    if (leaveApplication.statusId == 3) //approved then only reduce the current balance 
                //    {
                //        temp = @"update LeaveBalances set currentBalance =currentBalance-@totalLeaves where empId=@empId and leaveTypeId=@leaveTypeId";
                //        command = new SqlCommand(temp, connection);
                //        command.Parameters.Add("@totalLeaves", oldLeave.totalLeaves);
                //        command.Parameters.Add("@empId", leaveApplication.empId);
                //        command.Parameters.Add("@leaveTypeId", oldLeave.leaveTypeId);
                //        command.ExecuteNonQuery();
                //    }
                //    if (leaveApplication.statusId == 2 || leaveApplication.statusId == 4)  //cancelled or declined   a
                //    {
                //        temp = @"update LeaveBalances set currentBalance =currentBalance+@totalLeaves where empId=@empId and leaveTypeId=@leaveTypeId";
                //        command = new SqlCommand(temp, connection);
                //        command.Parameters.Add("@totalLeaves", oldLeave.totalLeaves);
                //        command.Parameters.Add("@empId", leaveApplication.empId);
                //        command.Parameters.Add("@leaveTypeId", oldLeave.leaveTypeId);
                //        command.ExecuteNonQuery();
                //    }

                //}

                String Query = "update LeaveApplications  set  leaveTypeId=@leaveTypeId,leaveDateFrom=@leaveDateFrom,leaveDateTo=@leaveDateTo,remark=@remark,updatedDate=@updatedDate,totalLeaves=@totalLeaves where leaveId=@leaveId";
                command = new SqlCommand(Query, connection);

                command.Parameters.Add("@leaveTypeId", leaveApplication.leaveTypeId);
                command.Parameters.Add("@leaveDateFrom", leaveApplication.leaveDateFrom);
                command.Parameters.Add("@leaveDateTo", leaveApplication.leaveDateTo);
                command.Parameters.Add("@remark", leaveApplication.remark);
                //command.Parameters.Add("@statusId", leaveApplication.statusId);
                command.Parameters.Add("@updatedDate", leaveApplication.updatedDate);
                command.Parameters.Add("@totalLeaves", leaveApplication.totalLeaves);
                command.Parameters.Add("@leaveId", leaveId);
                command.ExecuteScalar();
                return GetLeaveApplicationByLeaveId(leaveId);
                connection.Close();

            }

            return null;

        }

        //update Leave Application Status 
        public LeaveApplicationsModel UpdateApplicationStatus(int leaveId, int updatedStatusId)
        {
            using (SqlConnection connection = _dbConnectionHelper.CreateConnection())
            {
                connection.Open();
                SqlCommand command;
                if (this.CheckStatusId(updatedStatusId))
                {
                    LeaveApplicationsModel leaveApplication = this.GetLeaveApplicationByLeaveId(leaveId); //getting for old status 
                    if (leaveApplication != null)
                    {
                        ////status
                        if (leaveApplication.statusId == 1)
                        {
                            string temp = "";
                            //if (updatedStatusId == 3) //approved then only reduce the current balance  
                            //{
                            //    temp = @"update LeaveBalances set currentBalance =currentBalance-@totalLeaves where empId=@empId and leaveTypeId=@leaveTypeId";
                            //    command = new SqlCommand(temp, connection);
                            //    command.Parameters.Add("@totalLeaves", oldLeave.totalLeaves);
                            //    command.Parameters.Add("@empId", leaveApplication.empId);
                            //    command.Parameters.Add("@leaveTypeId", oldLeave.leaveTypeId);
                            //    command.ExecuteNonQuery();
                            //}
                            if (updatedStatusId == 2 || updatedStatusId == 4)  //cancelled or declined   a
                            {
                                temp = @"update LeaveBalances set currentBalance =currentBalance+@totalLeaves where empId=@empId and leaveTypeId=@leaveTypeId";
                                command = new SqlCommand(temp, connection);
                                command.Parameters.Add("@totalLeaves", leaveApplication.totalLeaves);
                                command.Parameters.Add("@empId", leaveApplication.empId);
                                command.Parameters.Add("@leaveTypeId", leaveApplication.leaveTypeId);
                                command.ExecuteNonQuery();
                            }

                            String Query = "update LeaveApplications set statusId=@statusId,updatedDate=GETDATE() where leaveId =@leaveId;";
                            command = new SqlCommand(Query, connection);
                            command.Parameters.Add("@statusId", updatedStatusId);
                            command.Parameters.Add("@leaveId", leaveId);
                            command.ExecuteScalar();
                            return this.GetLeaveApplicationByLeaveId(leaveId);

                        }
                    }

                }
                connection.Close();

            }
            return null;
        }


        //GetLb Of Specific Type
        public int GetLB(int emp_id, int leaveTypeId)
        {
            int LB;
            using (SqlConnection connection = _dbConnectionHelper.CreateConnection())
            {
                connection.Open();
                string query = "SELECT currentBalance FROM LeaveBalances where empId=@emp_id and leaveTypeId=@leaveTypeId; ";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@emp_id", emp_id);
                command.Parameters.Add("@leaveTypeId", leaveTypeId);
                LB = int.Parse(command.ExecuteScalar().ToString());
            }
            return LB;
        }

        //GetAll Leave Balances 
        public List<LeaveBalancesModel> GetLeaveBalances(int empId)
        {

            List<LeaveBalancesModel> leaveBalancesModels = new List<LeaveBalancesModel>();
            using (SqlConnection connection = _dbConnectionHelper.CreateConnection())
            {
                connection.Open();
                SqlCommand command;
                const string Query = @"select leaveBalanceId,empId, LT.leaveTypeId, LT.LeaveType,LeaveBalances.openingBalance ,currentBalance from LeaveBalances 
Join LeaveTypes Lt on LeaveBalances.leaveTypeId =Lt.leaveTypeId
where empId=@empId";
                command = new SqlCommand(Query, connection);
                command.Parameters.Add("@empId", empId);
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {

                    LeaveBalancesModel leaveBalancesModel = new LeaveBalancesModel();
                    leaveBalancesModel.leaveBalanceId = int.Parse(dataReader["leaveBalanceId"].ToString());
                    leaveBalancesModel.empId = int.Parse(dataReader["empId"].ToString());
                    leaveBalancesModel.leaveTypeId = int.Parse(dataReader["leaveTypeId"].ToString());
                    leaveBalancesModel.leaveType = dataReader["LeaveType"].ToString();
                    leaveBalancesModel.openingBalance = int.Parse(dataReader["openingBalance"].ToString());
                    leaveBalancesModel.currentBalance = int.Parse(dataReader["currentBalance"].ToString());

                    leaveBalancesModels.Add(leaveBalancesModel);
                }
                connection.Close();
                return leaveBalancesModels;
            }
            return null;
        }


        //LeaveTypes:------
        //GetAll Leave Types 
        public List<LeaveTypesModel> GetLeaveTypes()
        {

            List<LeaveTypesModel> leaveTypesModels = new List<LeaveTypesModel>();
            using (SqlConnection connection = _dbConnectionHelper.CreateConnection())
            {
                connection.Open();
                SqlCommand command;
                const string Query = @"select leaveTypeId,leaveType,createdAt,updatedAt,createdBy,updatedBy from leaveTypes";
                command = new SqlCommand(Query, connection);
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {

                    LeaveTypesModel leaveTypeModel = new LeaveTypesModel();
                    leaveTypeModel.leaveTypeId = int.Parse(dataReader["leaveTypeId"].ToString());
                    leaveTypeModel.leaveType = dataReader["LeaveType"].ToString();

                    leaveTypeModel.createdAt = Convert.ToDateTime(dataReader["createdAt"]);
                    leaveTypeModel.updatedAt = Convert.ToDateTime(dataReader["updatedAt"]);

                    leaveTypeModel.createdBy = int.Parse(dataReader["createdBy"].ToString());
                    leaveTypeModel.updatedBy = int.Parse(dataReader["updatedBy"].ToString());

                    leaveTypesModels.Add(leaveTypeModel);
                }
                connection.Close();
                return leaveTypesModels;
            }
            return null;
        }

        //Get Leave Type by id 
        public LeaveTypesModel GetLeaveTypeById(int leaveTypeId)
        {

            LeaveTypesModel leaveTypeModel = new LeaveTypesModel();
            using (SqlConnection connection = _dbConnectionHelper.CreateConnection())
            {
                connection.Open();
                SqlCommand command;
                const string Query = @"select leaveTypeId,leaveType,createdAt,updatedAt,createdBy,updatedBy from leaveTypes where leaveTypeId=@leaveTypeId";
                command = new SqlCommand(Query, connection);
                command.Parameters.Add("@leaveTypeId",leaveTypeId);
                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {

                    
                    leaveTypeModel.leaveTypeId = int.Parse(dataReader["leaveTypeId"].ToString());
                    leaveTypeModel.leaveType = dataReader["LeaveType"].ToString();

                    leaveTypeModel.createdAt = Convert.ToDateTime(dataReader["createdAt"]);
                    leaveTypeModel.updatedAt = Convert.ToDateTime(dataReader["updatedAt"]);

                    leaveTypeModel.createdBy = int.Parse(dataReader["createdBy"].ToString());
                    leaveTypeModel.updatedBy = int.Parse(dataReader["updatedBy"].ToString());

                   
                }
                connection.Close();
                return leaveTypeModel;
            }
            return null;
        }


        //Add LeaveType
        public LeaveTypesModel AddLeaveType(LeaveTypesModel leaveType)
        {
            using (SqlConnection connection = _dbConnectionHelper.CreateConnection())
            {
                connection.Open();
                String Query = "insert into LeaveTypes (leaveType,createdAt,updatedAt,createdBy,updatedBy ) values (@leaveType,@createdAt,@updatedAt,@createdBy,@updatedBy);select scope_identity()";
                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.Add("@leaveType", leaveType.leaveType);
                command.Parameters.Add("@createdAt", leaveType.createdAt);
                command.Parameters.Add("@updatedAt", leaveType.updatedAt);
                command.Parameters.Add("@createdBy", leaveType.createdBy);
                command.Parameters.Add("@updatedBy", leaveType.updatedBy);
                leaveType.leaveTypeId = int.Parse(command.ExecuteScalar().ToString());
                connection.Close();
            }
            return GetLeaveTypeById(leaveType.leaveTypeId);
        }




        // Validations 

        public bool IsLeaveExist(int leave_id)
        {
            int returnvalue;
            using (SqlConnection connection = _dbConnectionHelper.CreateConnection())
            {
                connection.Open();
                string query = "select count(leaveID) from LeaveApplications where leaveId=@leaveId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@leaveId", leave_id);
                returnvalue = int.Parse(command.ExecuteScalar().ToString());
            }
            return returnvalue > 0 ? true : false;
        }
        
        public bool IsEmpExist(int emp_id)
        {
            int returnvalue;
            using (SqlConnection connection = _dbConnectionHelper.CreateConnection())
            {
                connection.Open();
                string query = "select count (empID) from Employees where empId=@emp_id ";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@emp_id", emp_id);
                returnvalue = int.Parse(command.ExecuteScalar().ToString());
            }
            return returnvalue > 0 ? true : false;
        }
        public bool IsOverlap(int emp_id, DateTime fromDate, DateTime ToDate)
        {
            int returnvalue;
            using (SqlConnection connection = _dbConnectionHelper.CreateConnection())
            {
                connection.Open();
                //string query = "select count(*) from leaves where emp_id= @emp_id and leave_dateTo >@leave_dateFrom";
                //string query = "select count(*) from leaves where emp_id= @emp_id and leave_dateFrom>=@leave_dateFrom and leave_dateFrom<=@leave_dateTo  and leave_dateTo>=@leave_dateFrom and leave_dateTo<=@leave_dateTo   ";
                string Query = @"select count(*) from LeaveApplications where empId=@empId and leaveDateFrom>=@leaveDateFrom and leaveDateFrom<=@leaveDateTo  or leaveDateTo>=@leaveDateFrom and leaveDateTo<=@leaveDateTo ;";
                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.Add("@leaveDateFrom", fromDate);
                command.Parameters.Add("@leaveDateTo", ToDate);
                command.Parameters.Add("@empId", emp_id);
                returnvalue = int.Parse(command.ExecuteScalar().ToString());
            }
            return returnvalue > 0 ? true : false;
        }
        public bool CheckStatusId(int statusId)
        {
            int returnvalue;
            using (SqlConnection connection = _dbConnectionHelper.CreateConnection())
            {
                connection.Open();
                string Query = @"select count(*) from  ApplicationStatus where statusId=@statusId";
                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.Add("@statusId", statusId);
                returnvalue = int.Parse(command.ExecuteScalar().ToString());
            }
            return returnvalue > 0 ? true : false;
        }
        public bool CheckLeaveType(int leaveTypeId)
        {
            int returnvalue;
            using (SqlConnection connection = _dbConnectionHelper.CreateConnection())
            {
                connection.Open();
                string Query = @"select count(*) from  leaveTypes  where leaveTypeId=@leaveTypeId";
                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.Add("@leaveTypeId", leaveTypeId);
                returnvalue = int.Parse(command.ExecuteScalar().ToString());
            }
            return returnvalue > 0 ? true : false;
        }

    }
}
