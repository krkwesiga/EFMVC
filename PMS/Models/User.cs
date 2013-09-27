using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PMS.Models
{

  public class User
  {
    [Key]
    public int UserId { get; set; }

    [Required(ErrorMessage = "User Name is required")]
    [Display(Name = "User Name")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "First Name is required")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last Name is required")]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Email Address is required")]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email Address")]
    public string EmailAddress { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [NotMapped]
    public string Password { get; set; }

    [Required(ErrorMessage = "Confirm Password is required")]
    [Compare("Password")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }

    [ScaffoldColumn(false)]
    public string SavedBy { get; set; }

    [ScaffoldColumn(false)]
    public DateTime SavedDate { get; set; }

    public User()
    {
      SavedDate = System.DateTime.Now;
    }
  }
}