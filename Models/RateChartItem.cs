
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class RateChartItem
{
    [Key]
    public int RateChartId { get; set; }

    [Required(ErrorMessage = "Plan Id is required")]
    public int PlanId { get; set; }

    [ForeignKey("PlanId")]
    public CoveragePlanItem CoveragePlan { get; set; }

    [Required(ErrorMessage = "Gender is required")]
    public string Gender { get; set; }

    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Date of Birth is required")]
    public DateTime DateOfBirth { get; set; }

    [Required(ErrorMessage = "Net Price is required")]
    public int NetPrice { get; set; }

}