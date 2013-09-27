using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PMS.Models;

namespace PMS.ViewModels
{
  public class CashRequisitionActiveProjectsViewModel
  {
    public List<Project> Projects { get; set; }
    public CashRequisition CashRequisitions { get; set; }
    public User User { get; set; }

    public CashRequisitionActiveProjectsViewModel()
    {
      Projects = new List<Project>();
    }

  }
}