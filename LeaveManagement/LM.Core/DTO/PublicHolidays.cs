﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LM.Core.DTO
{
    public class PublicHolidays
    {
        public int holidayId { get; set; }
        public System.DateTime holidayDate { get; set; }
        public string holidayInfo { get; set; }
        public int orgId { get; set; }
    }
}