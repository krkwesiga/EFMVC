using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMS.Models
{
  public enum UserStatus
  {
    [Display(Description = "Active")]
    Active = 1,

    [Display(Description = "Not Active")]
    NotActive = 2

  }
}