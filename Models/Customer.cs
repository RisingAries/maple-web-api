using System;
using System.ComponentModel.DataAnnotations;

public class Customer
{
    public long Id { get; set; }
    public string Name { get; set; }

    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }

    public string Gender { get; set; }

    public string Address { get; set; }

    public Country Country { get; set; }


}