﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTProject.Models
{
    public interface IAccountRepository
    {
        public bool IsValidLogin(String username, String password);
    }
}