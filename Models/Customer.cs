using System;
using System.ComponentModel.DataAnnotations;

public class Customer
{
    [Key]
    public int CustomerId { get; set; }

    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }

    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Date Of Birth is required")]
    public DateTime DateOfBirth { get; set; }

    [Required(ErrorMessage = "Gender is required")]
    public Gender Gender { get; set; }

    public string Address { get; set; }

    [Required(ErrorMessage = "Country is required")]
    public Country Country { get; set; }


}