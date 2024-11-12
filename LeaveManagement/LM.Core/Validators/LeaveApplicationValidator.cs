using LM.Core.CommonUtils;
using LM.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Core.Validators
{
    public partial class LeaveApplicationValidator
    {
        public static ActionResult<LeaveApplications> ValidatePost(LeaveApplications leaveApplication)
        {
            ActionResult<LeaveApplications> result = new ActionResult<LeaveApplications>();
            LM.Data.LeaveDataManager _leaveDataManager = new Data.LeaveDataManager();

            if (Common.IsNullOrDefault<DateTime>(leaveApplication.leaveDateFrom))
            {
                result.ErrorList.Add("Leave Date From  cannot be Null or empty !!");
            }
            else 
            {
                if (LeaveApplicationValidator.IsPastDated(leaveApplication.leaveDateFrom))
                {
                    result.ErrorList.Add("leaves cannot be applied for past dates !!");
                }
                else
                {
                    result = LeaveApplicationValidator.ValidateApplication(leaveApplication);
                    if (_leaveDataManager.IsOverlap(leaveApplication.empId, leaveApplication.leaveDateFrom, leaveApplication.leaveDateTo))
                    {
                        result.ErrorList.Add("Leaves Cannot be overLapped  !!");
                    }
                }
            }
            return result;
        }
        public static ActionResult<LeaveApplications> ValidatePut(int leaveId, LeaveApplications leaveApplication)
        {
            ActionResult<LeaveApplications> result = new ActionResult<LeaveApplications>();
            LM.Data.LeaveDataManager _leaveDataManager = new Data.LeaveDataManager();
            if (_leaveDataManager.IsLeaveExist(leaveId))
            {
                result = ValidateApplication(leaveApplication);


                LeaveApplications oldLeave = _leaveDataManager.GetLeaveApplicationByLeaveId(leaveId).ToEntity();
                if (!(leaveApplication.leaveDateFrom == oldLeave.leaveDateFrom && leaveApplication.leaveDateTo == oldLeave.leaveDateTo))
                {
                    if (_leaveDataManager.IsOverlap(leaveApplication.empId, leaveApplication.leaveDateFrom, leaveApplication.leaveDateTo))
                    {
                        result.ErrorList.Add("Leaves Cannot be overLapped  !!");
                    }
                }
                if (oldLeave.statusId != 1)
                {
                    result.ErrorList.Add("Only pending Leave applications allowed to Update  !!");
                }
            }
            else
            {
                result.ErrorList.Add("Not any Record found for LeaveId :" + leaveId + "!!");
            }
            //if (!_leaveDataManager.CheckStatusId(leaveApplication.statusId))
            //{
            //    result.ErrorList.Add("The  Status Your are trying to update not Valid ");
            //}

            return result;
        }

        public static ActionResult<LeaveApplications> ValidateUpdatedStatus(int leaveId, int updatedStatusId)
        {
            ActionResult<LeaveApplications> result = new ActionResult<LeaveApplications>();
            LM.Data.LeaveDataManager _leaveDataManager = new Data.LeaveDataManager();

            if (_leaveDataManager.IsLeaveExist(leaveId))
            {
                if (_leaveDataManager.CheckStatusId(updatedStatusId))
                {
                    result.IsSuccess = true;
             
                }
                else
                {
                    result.IsSuccess = false;
                    result.ErrorList.Add("The Status You are trying to update is Not Valid !!!");
                }

                LeaveApplications leaveApplication = _leaveDataManager.GetLeaveApplicationByLeaveId(leaveId).ToEntity(); //for checking status is 1 Pending 
                if (leaveApplication.statusId!= 1)
                {
                    if (leaveApplication.statusId == 2)
                    {
                        result.ErrorList.Add("Only Pending Applications are allowed to Update The Current Application is Already  Cancelled !!");
                    }
                    else if (leaveApplication.statusId == 3)
                    {
                        result.ErrorList.Add("Only Pending Applications are allowed to Update The Current Application is Already  Approved !!");
                    }
                    else if (leaveApplication.statusId == 4)
                    {
                        result.ErrorList.Add("Only Pending Applications are allowed to Update The Current Application is Already  Declined  !!");
                    }
                    else
                    {
                        result.ErrorList.Add("Only Pending Applications are allowed to Update The Current Application is NotAllowed to Update  !!");
                    }
                }
            }
            else
            {
                result.IsSuccess = false;
                result.ErrorList.Add("Not any Record found for LeaveId :" + leaveId + "!!");
            }
            
            return result;
        }



        public static ActionResult<LeaveApplications> ValidateApplication(LeaveApplications leaveApplication)
        {
            ActionResult<LeaveApplications> result = new ActionResult<LeaveApplications>();
            LM.Data.LeaveDataManager _leaveDataManager = new Data.LeaveDataManager();


            if (string.IsNullOrEmpty(leaveApplication.remark))
            {
                result.ErrorList.Add("remark cannot be a null  value !!");
            }

            if (Common.IsNullOrDefault<DateTime>(leaveApplication.leaveDateFrom) || Common.IsNullOrDefault<DateTime>(leaveApplication.leaveDateTo))
            {
                result.ErrorList.Add("leavedate from and leave date to must be filled !!:");
            }
            else
            {
                if (LeaveApplicationValidator.IsNotInLimit(leaveApplication.leaveDateFrom, leaveApplication.leaveDateTo))
                    result.ErrorList.Add("leave application cannot be for more than 5 days Your Application Is For :" + (leaveApplication.leaveDateTo - leaveApplication.leaveDateFrom).TotalDays + " Days ");

                if (!LeaveApplicationValidator.IsValidFormat(leaveApplication.leaveDateFrom, leaveApplication.leaveDateTo))
                    result.ErrorList.Add("Leave from date must be equal to or less than leave to date !!");
            }
          
            
            if (0 == leaveApplication.leaveTypeId)
            {
                result.ErrorList.Add("leaveType  cannot be a null  value !!");

            }
            else if (!_leaveDataManager.CheckLeaveType(leaveApplication.leaveTypeId))
            {
                result.ErrorList.Add("Invalid Leave Type : this Leave Type not supported by system !!");
            }
            else
            {

                if (!LeaveApplicationValidator.IsWithinLB(leaveApplication))
                {
                    result.ErrorList.Add("Total No of LeaveDays  must be equal to or less than leave Balance  !!");
                }
            }
            return result;
        }


        static bool IsPastDated(DateTime leaveDateFrom)
        {
            if (leaveDateFrom.Date < DateTime.Now.Date)
                return true;
            return false;
        }
        static bool IsValidFormat(DateTime leaveDateFrom, DateTime leaveDateTo)
        {
            if (leaveDateFrom <= leaveDateTo)
                return true;
            return false;
        }
        static bool IsNotInLimit(DateTime leaveDateFrom, DateTime leaveDateTo)
        {
            if ((leaveDateTo - leaveDateFrom).TotalDays > 5) // .TotalDays Returns the Number of days 
                return true;
            return false;
        }
        static bool IsWithinLB(LeaveApplications leaveApplication)
        {
            LM.Data.LeaveDataManager _leaveDataManager = new Data.LeaveDataManager();

            if ((leaveApplication.leaveDateTo - leaveApplication.leaveDateFrom).TotalDays > _leaveDataManager.GetLB(leaveApplication.empId, leaveApplication.leaveTypeId)) // .TotalDays Returns the Number of days 
                return false;
            return true;
        }


        public static ActionResult<LeaveTypes> ValidateLeaveType(LeaveTypes leaveType)
        {
            ActionResult<LeaveTypes> result = new ActionResult<LeaveTypes>();

            if(CommonUtils.Common.IsNullOrDefault<string>(leaveType.leaveType)){
                result.ErrorList.Add("Leave Type cannot be a null or Empty Value ");
            }
            return result;

        }


    }
}
