using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ContractItem
{
    [Key]
    public int ContractId { get; set; }

    [Required(ErrorMessage = "Customer Id is required")]
    public int CustomerId { get; set; }

    [ForeignKey("CustomerId")]
    public Customer Customer { get; set; }

    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Sale Date is required")]
    public DateTime SaleDate { get; set; }

    [Required(ErrorMessage = "Coverage Id is required")]
    public int CoverageId { get; set; }

    [ForeignKey("CoverageId")]
    public CoveragePlanItem CoveragePlan { get; set; }

    [Required(ErrorMessage = "Net Price is required")]
    public double NetPrice { get; set; }
}