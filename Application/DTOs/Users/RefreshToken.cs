﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Users
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public bool IsExperied => DateTime.Now >= Expires;
        public DateTime Created { get; set; }
        public string CreatedById { get; set; }
        public DateTime? Revoked { get; set; }
        public string RevokedById { get; set; }
        public string RevokedByToken { get; set; }
        public bool IsActive => Revoked == null && !IsExperied;
    }
}
