using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PMS.Models
{
  public class Project
  {
    [Key]
    public int ProjectId { get; set; }

    [Required(ErrorMessage = "Project Name is required")]
    public string ProjectName { get; set; }

    [Required(ErrorMessage = "Project Description is required")]
    public string ProjectDescription { get; set; }

    public enum ProjectStatus
    {
      Active = 1,
      NotActive = 2
    }
  }

}