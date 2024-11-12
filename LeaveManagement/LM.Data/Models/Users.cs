using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LM.Data.Models
{
    public class UsersModel
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public bool isActive { get; set; }
        public System.DateTime createdAt { get; set; }
        public System.DateTime updatedAt { get; set; }
        public Nullable<int> createdBy { get; set; }
        public Nullable<int> updatedBy { get; set; }

        //
        public string roleName { get; set; }
    }
}