using System;
using System.ComponentModel.DataAnnotations;

public class ContractDetailsForPostDto
{
    public string CustomerName { get; set; }

    [DataType(DataType.Date)]
    public DateTime SaleDate { get; set; }

    public Country CustomerCountry { get; set; }

    [DataType(DataType.Date)]
    public DateTime DOB { get; set; }

    public string CustomerGender { get; set; }


}