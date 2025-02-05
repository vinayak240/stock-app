﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.Entities
{
    public class User
    {
        public int ID { get; set; }
        
        public string Username { get; set; }

        public string Password { get; set; }

        public string UserType { get; set; }

        public string Email { get; set; }

        public bool Confirmed  { get; set; }
    }
}
