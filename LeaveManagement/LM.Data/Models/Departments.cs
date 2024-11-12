using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LM.Data.Models
{
    public class DepartmentsModel
    {
        public int dptId { get; set; }
        public string dptName { get; set; }
        public string location { get; set; }
        public int orgId { get; set; }
    
    }
}