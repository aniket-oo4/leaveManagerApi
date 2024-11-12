using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LM.Data.Models
{
    public class LeaveBalancesModel
    {
        public int leaveBalanceId { get; set; }
        public int empId { get; set; }
        public int leaveTypeId { get; set; }
        public decimal openingBalance { get; set; }
        public decimal currentBalance { get; set; }

        //
        public string leaveType { get; set; }

    }
}