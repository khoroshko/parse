﻿using Parse.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Parse
{
    public class ParseContext : DbContext
    {
        public DbSet<CpvProduct> CpvProducts { get; set; }
    }
}