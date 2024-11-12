using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LM.Core.DTO
{
    public class Employees
    {
        public int empId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string emailAddress { get; set; }
        public System.DateTime birthDate { get; set; }
        public string city { get; set; }
        public System.DateTime createdAt { get; set; }
        public System.DateTime updatedAt { get; set; }
        public int userId { get; set; }
        public int dptId { get; set; }
        public int costCenterId { get; set; }
        public int roleId { get; set; }
        public Nullable<int> managerId { get; set; }
        public int orgId { get; set; }


        //
        public string dptName { get; set; }
        public string location { get; set; }
        public string costCenterName { get; set; }
        public string roleName { get; set; }
        public string managerName { get; set; }
        public string orgName { get; set; }
    }
}