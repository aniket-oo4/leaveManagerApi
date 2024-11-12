using LM.Core.CommonUtils;
using LM.Core.DTO;
using LM.Core.Validators;
using LM.Data;
using LM.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LM.Core
{
    public class LeaveManager
    {

        private readonly LeaveDataManager _leaveDataManager;
        
        public LeaveManager()
        {
            _leaveDataManager = new LeaveDataManager();
        }

        public ActionResult<List<LeaveApplications>> GetAllLeaveApplications()
        {
            ActionResult<List<LeaveApplications>> result = new ActionResult<List<LeaveApplications>>();

            List<LeaveApplications> leaveApplications = new List<LeaveApplications>();
            List<LeaveApplicationsModel> leaveApplicationModels = _leaveDataManager.GetAllLeaveApplications();


            if (leaveApplicationModels.Count!=0)
            {
                foreach (var leaveapplicationModel in leaveApplicationModels)
                {
                    leaveApplications.Add(leaveapplicationModel.ToEntity());
                }
                result.Data = leaveApplications;
                result.IsSuccess = true;
                result.resultCount = leaveApplications.Count;
                result.totalRecords = leaveApplications.Count;
                result.Message = "OK";
                result.httpStatusCode = HttpStatusCode.OK;
            }
            else
            {
                result.IsSuccess = false;
                result.ErrorList.Add("Not Any Records Found");
                result.Message = "Failed";
                result.httpStatusCode = HttpStatusCode.NoContent;
            }
            return result;
        }

        public ActionResult<List<LeaveApplications>> GetLeaveApplicationsByEmployee( int EmpId)
        {
            ActionResult<List<LeaveApplications>> result = new ActionResult<List<LeaveApplications>>();

            List<LeaveApplications> leaveApplications = new List<LeaveApplications>();
            List<LeaveApplicationsModel> leaveApplicationModels = _leaveDataManager.GetLeaveApplicationsByEmployee(EmpId);

            if (leaveApplicationModels.Count!=0)
            {
                foreach (var leaveapplicationModel in leaveApplicationModels)
                {
                    leaveApplications.Add(leaveapplicationModel.ToEntity());
                }

                result.Data = leaveApplications;
                result.IsSuccess = true;
                result.resultCount = leaveApplications.Count;
                result.totalRecords = leaveApplications.Count;
                result.Message = "OK";
            }
            else
            {
                result.IsSuccess = false;
                result.ErrorList.Add("Not Any Records Found For EmpId " + EmpId + "");
                result.Message = "Failed";
            }
            return result;
        }

        public ActionResult<List<LeaveApplications>> GetLeaveApplicationsByManagerId(int managerId)
        {
            ActionResult<List<LeaveApplications>> result = new ActionResult<List<LeaveApplications>>();

            List<LeaveApplications> leaveApplications = new List<LeaveApplications>();
            List<LeaveApplicationsModel> leaveApplicationModels = _leaveDataManager.GetLeaveApplicationsByManager(managerId);


            if (leaveApplicationModels.Count!=0)
            {
                foreach (var leaveapplicationModel in leaveApplicationModels)
                {
                    leaveApplications.Add(leaveapplicationModel.ToEntity());
                }
                result.Data = leaveApplications;
                result.IsSuccess = true;
                result.Message = "OK";
                result.resultCount = leaveApplications.Count;
                result.totalRecords = leaveApplications.Count;
            }
            else
            {
                result.IsSuccess = false;
                result.ErrorList.Add("not any record Found For Employee who' managerId was :"+managerId+" ");
                result.Message = "Failed";
            }
            return result;
        }
        //By ID
        public ActionResult<LeaveApplications> GetLeaveApplicationById(int leaveId)
        {
            ActionResult<LeaveApplications> result = new ActionResult<LeaveApplications>();

           LeaveApplications leaveApplication = new LeaveApplications();
            LeaveApplicationsModel leaveApplicationModel = _leaveDataManager.GetLeaveApplicationByLeaveId(leaveId);


           


            if (leaveApplicationModel != null)
            {
                leaveApplication = leaveApplicationModel.ToEntity();
                result.Data = leaveApplication;
                result.IsSuccess = true;
                result.resultCount = 1;
                result.Message = "OK";
            }
            else
            {
                result.IsSuccess = false;
                result.ErrorList.Add("Not  any Leave Application Found for Id : " + leaveId + "");
                result.resultCount = 0;
                result.Message = "Failed";
            }
            return result;
        }
        
        //addApplication
        public ActionResult<LeaveApplications> AddApplication(LeaveApplications leaveApplication)
        {
            ActionResult<LeaveApplications> result = new ActionResult<LeaveApplications>();
            leaveApplication.totalLeaves = Common.CalculateTotalDays(leaveApplication.leaveDateFrom,leaveApplication.leaveDateTo);
            leaveApplication.applicationDate = DateTime.Now;
            leaveApplication.updatedDate = DateTime.Now;
            leaveApplication.statusId = 1;
            //validation 
            result = LeaveApplicationValidator.ValidatePost(leaveApplication);
            if (result.ErrorList.Count > 0)
            {
                result.IsSuccess = false;
                result.totalRecords = 0;
                result.resultCount = 0;
                result.Message = "Invalid";
                return result;
            }


            LeaveApplicationsModel leavemodel = _leaveDataManager.AddApplication(leaveApplication.ToModel());
            if (leavemodel != null)
            {
                result.Data = leavemodel.ToEntity();
                result.IsSuccess = true;
                result.Message = "OK";
            }
            else
            {
                result.IsSuccess = false;
                result.Message = "Failed";
            }
            return result;
        }

        //update Application 
        public ActionResult<LeaveApplications> UpdateApplication(int leaveId, LeaveApplications leaveApplication)
        {
            ActionResult<LeaveApplications> result = new ActionResult<LeaveApplications>();
            leaveApplication.totalLeaves = Common.CalculateTotalDays(leaveApplication.leaveDateFrom, leaveApplication.leaveDateTo);
            leaveApplication.updatedDate = DateTime.Now;

            //validation 
            result = LeaveApplicationValidator.ValidatePut(leaveId, leaveApplication);
            if (result.ErrorList.Count > 0)
            {
                result.IsSuccess = false;
                result.totalRecords = 0;
                result.resultCount = 0;
                result.Message = "Invalid";
                return result;
            }


            LeaveApplicationsModel leavemodel = _leaveDataManager.UpdateApplication(leaveId, leaveApplication.ToModel());
            if (leavemodel != null)
            {
                result.Data = leavemodel.ToEntity();
                result.IsSuccess = true;
                result.resultCount = 1;
                result.totalRecords = 1;
                result.Message = "Updated SuccessFully ";
            }
            else
            {
                result.IsSuccess = false;
                result.ErrorList.Add("SomeThing Went wrong !! Not Found  ");
                result.Message = "Not Updated";
            }
            return result;
        }


        //update Applicaion Status 
        public ActionResult<LeaveApplications> UpdateApplicationStatus(int leaveId,int updatedStatusId)
        {
            ActionResult<LeaveApplications> result = new ActionResult<LeaveApplications>();

            //validation 
            result = LeaveApplicationValidator.ValidateUpdatedStatus(leaveId, updatedStatusId);
            if (result.ErrorList.Count > 0)
            {
                result.IsSuccess = false;
                result.totalRecords = 0;
                result.resultCount = 0;
                result.Message = "Invalid";
                return result;
            }


            LeaveApplicationsModel leavemodel = _leaveDataManager.UpdateApplicationStatus(leaveId, updatedStatusId);
            if (leavemodel != null)
            {
                result.Data = leavemodel.ToEntity();
                result.IsSuccess = true;
                result.resultCount = 1;
                result.totalRecords = 1;
                result.Message = "Status Updated SuccessFully ";
            }
            else
            {
                result.IsSuccess = false;
                result.ErrorList.Add("SomeThing Went wrong !! Not Found  ");
                result.Message = "Status sNot Updated";
            }
            return result;
        }



        //getLB
        public ActionResult<List<LeaveBalances>> GetLeaveBalanceByEmployee(int EmpId)
        {
            ActionResult<List<LeaveBalances>> result = new ActionResult<List<LeaveBalances>>();

            List<LeaveBalances> leaveBalances = new List<LeaveBalances>();
            List<LeaveBalancesModel> leaveBalancesModels = _leaveDataManager.GetLeaveBalances(EmpId);

            if (leaveBalancesModels.Count != 0)
            {
                foreach (var leaveBalance in leaveBalancesModels)
                {
                    leaveBalances.Add(leaveBalance.ToEntity());
                }

                result.Data = leaveBalances;
                result.IsSuccess = true;
                result.resultCount = leaveBalances.Count;
                result.totalRecords = leaveBalances.Count;
                result.Message = "OK";
            }
            else
            {
                result.IsSuccess = false;
                result.ErrorList.Add("Not Any Records Found For EmpId " + EmpId + "");
                result.Message = "Failed";
            }
            return result;
        }

        //LeaveTypes
        public ActionResult<List<LeaveTypes>> GetLeaveTypes()
        {
            ActionResult<List<LeaveTypes>> result = new ActionResult<List<LeaveTypes>>();

            List<LeaveTypes> leaveTypes = new List<LeaveTypes>();
            List<LeaveTypesModel> leaveTypeModels = _leaveDataManager.GetLeaveTypes();

            if (leaveTypeModels.Count != 0)
            {
                foreach (var leaveType in leaveTypeModels)
                {
                    leaveTypes.Add(leaveType.ToEntity());
                }

                result.Data = leaveTypes;
                result.IsSuccess = true;
                result.resultCount = leaveTypes.Count;
                result.totalRecords = leaveTypes.Count;
                result.Message = "OK";
            }
            else
            {
                result.IsSuccess = false;
                result.ErrorList.Add("Not Any Records Found ");
                result.Message = "Failed";
            }
            return result;
        }

        //addApplication
        public ActionResult<LeaveTypes> AddLeaveType(int addedByEmpId,LeaveTypes leaveType)
        {
            ActionResult<LeaveTypes> result = new ActionResult<LeaveTypes>();
            leaveType.createdAt = DateTime.Now;
            leaveType.updatedAt = DateTime.Now;
            leaveType.createdBy = addedByEmpId;
            leaveType.updatedBy = addedByEmpId;

            result = LeaveApplicationValidator.ValidateLeaveType(leaveType);
            if (result.ErrorList.Count > 0)
            {
                result.IsSuccess = false;
                result.totalRecords = 0;
                result.resultCount = 0;
                result.Message = "Invalid";
                return result;
            }


            LeaveTypesModel leaveTypemodel = _leaveDataManager.AddLeaveType(leaveType.ToModel());
            if (leaveTypemodel != null)
            {
                result.Data = leaveTypemodel.ToEntity();
                result.IsSuccess = true;
                result.totalRecords = 1;
                result.resultCount = 1;
                result.Message = "Added Successfully";
            }
            else
            {
                result.IsSuccess = false;
                result.Message = "Failed";
            }
            return result;
        }



    }
}
