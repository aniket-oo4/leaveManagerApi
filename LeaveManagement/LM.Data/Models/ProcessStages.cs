using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LM.Data.Models
{
    public class ProcessStagesModel
    {
        public Nullable<int> nextStageId { get; set; }
        public int stageId { get; set; }
        public string stageName { get; set; }
        public string stageStatus { get; set; }
        public int performedByRoleId { get; set; }
        public int processId { get; set; }
    }
}