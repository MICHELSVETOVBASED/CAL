using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
namespace CalTechnology.Data.Models;

public class Order{
    [BindNever] public int Id{ get; set; }

    [Display(Name = "Type your name")]
    [StringLength(50)]
    [Required(ErrorMessage = "Name is required")]
    public string name{ get; set; }

    [Display(Name = "Surname")]
    [StringLength(50)]
    [Required(ErrorMessage = "Surname is required")]
    public string surname{ get; set; }

    [Display(Name = "Adress")]
    [StringLength(100)]
    [Required(ErrorMessage = "Address is required")]
    public string adress{ get; set; }

    [Display(Name = "Phone number")]
    [DataType(DataType.PhoneNumber)]
    [StringLength(20)]
    [Required(ErrorMessage = "Phone number is required")]
    public string phone{ get; set; }

    [Display(Name = "Email")]
    [DataType(DataType.EmailAddress)]
    [StringLength(50)]
    [Required(ErrorMessage = "Email is required")]
    public string email{ get; set; }

    [BindNever]
    [ScaffoldColumn(false)] 
    public DateTime orderTime { get; set; }

    [BindNever]
    public List<OrderDetail> orderDetails { get; set; } = new List<OrderDetail>();
}
