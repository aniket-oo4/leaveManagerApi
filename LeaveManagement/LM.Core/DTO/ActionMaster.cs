using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LM.Core.DTO
{
    public class ActionMaster
    {
        public int actionMasterId { get; set; }
        public int roleId { get; set; }
        public int actionId { get; set; }
        public int updatedStatusId { get; set; }

        public string actionName { get; set; }
    }
}