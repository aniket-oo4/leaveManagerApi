using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LM.Data.Models
{
    public class ProcessMasterModel
    {
        public int processMasterId { get; set; }
        public string applicationType { get; set; }
        public int processId { get; set; }
    }
}