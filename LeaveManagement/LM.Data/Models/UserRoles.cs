using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LM.Data.Models
{
    public class UserRolesModel
    {

        public int roleId { get; set; }
        public string roleName { get; set; }
        public System.DateTime createdAt { get; set; }
        public System.DateTime updatedAt { get; set; }
        public Nullable<int> createdBy { get; set; }
        public Nullable<int> updatedBy { get; set; }

        public string  createdByName { get; set; }
        public string updatedByName { get; set; }
    
    }
}