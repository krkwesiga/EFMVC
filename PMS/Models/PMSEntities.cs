﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PMS.Models
{
  public class PMSEntities : DbContext
  {
    public DbSet<User> Users { get; set; }
    public DbSet<CashRequisition> CashRequisitions { get; set; }
    public DbSet<Project> Projects { get; set; }
  }
}