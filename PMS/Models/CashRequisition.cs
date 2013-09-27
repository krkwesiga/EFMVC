using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PMS.Models
{
  public class CashRequisition
  {
    [Key]
    public int CashRequisitionId { get; set; }

    [Required(ErrorMessage = "Amount is required")]
    [DisplayFormat(DataFormatString = "{0:N0}")]
    public decimal Amount { get; set; }

    [Required(ErrorMessage = "Purpose is required")]
    public string Purpose { get; set; }

    [Required(ErrorMessage = "Activity is required")]
    public string Activity { get; set; }

    public int ProjectId { get; set; }
    public virtual Project Project { get; set; }

    [Required]
    [ScaffoldColumn(false)]
    public int UserId { get; set; }
    public virtual User User { get; set; }

    [Required]
    [ScaffoldColumn(false)]
    public string RequisitionStatus { get; set; }

    [Required]
    [ScaffoldColumn(false)]
    public DateTime SavedDate { get; set; }

    [Required]
    [ScaffoldColumn(false)]
    public int DeleteStatus { get; set; }

    [Required,ScaffoldColumn(false)]
    public String FinancialYear { get; set; }

    public CashRequisition()
    {
      SavedDate = System.DateTime.Now;
      DeleteStatus = 0;
      RequisitionStatus = "Pending";
      UserId = 1;
      FinancialYear = "2012-2013";
    }

  }
}