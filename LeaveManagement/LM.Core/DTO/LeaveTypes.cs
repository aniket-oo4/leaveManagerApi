using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LM.Core.DTO
{
    public class LeaveTypes
    {
        public int leaveTypeId { get; set; }
        public string leaveType { get; set; }
        public System.DateTime createdAt { get; set; }
        public System.DateTime updatedAt { get; set; }
        public int createdBy { get; set; }
        public int updatedBy { get; set; }
    }
}