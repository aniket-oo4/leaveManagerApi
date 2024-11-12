﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LM.Core.DTO
{
    public class Process
    {
        public int processId { get; set; }
        public string processName { get; set; }
        public System.DateTime createdAt { get; set; }
        public System.DateTime updatedAt { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    
    }
}