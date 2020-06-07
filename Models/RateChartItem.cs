
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class RateChartItem
{
    [Key]
    public long RateId { get; set; }


    public int PlanId { get; set; }

    [ForeignKey("PlanId")]
    public CoveragePlanItem CoveragePlan { get; set; }

    [Required(ErrorMessage = "Gender is required")]
    public string Gender { get; set; }

    [Required(ErrorMessage = "Cutoff Age is required")]
    public int CuttoffAge { get; set; }

    [Required(ErrorMessage = "Net Price is required")]
    public int NetPrice { get; set; }

}