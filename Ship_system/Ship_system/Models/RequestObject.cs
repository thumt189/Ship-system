using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ship_system.Models
{
    public class RequestObject
    {
        // Login
        public string username { get; set; }
        public string password { get; set; }
        
        // Register
        public string email { get; set; }
    }
}