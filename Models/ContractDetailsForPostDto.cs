using System;

public class ContractDetailsForPostDto
{
    public string CustomerName { get; set; }
    public DateTime SaleDate { get; set; }

    public Country CustomerCountry { get; set; }


    public DateTime DOB { get; set; }

    public string CustomerGender { get; set; }


}