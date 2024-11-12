using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LM.Data.Models
{
    public class LeaveApplicationsModel
    {
        public int leaveId { get; set; }
        public int leaveTypeId { get; set; }
        public System.DateTime leaveDateFrom { get; set; }
        public System.DateTime leaveDateTo { get; set; }
        public string remark { get; set; }
        public int statusId { get; set; }
        public System.DateTime applicationDate { get; set; }
        public System.DateTime updatedDate { get; set; }
        public Nullable<int> totalLeaves { get; set; }
        public int empId { get; set; }

        //
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string statusName { get; set; }
        public string leaveType { get; set; }
       
    }
}