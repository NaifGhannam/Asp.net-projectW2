using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

public class Order
{
    public int Id { get; set; }

    [Required(ErrorMessage = "User ID is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "User ID must be greater than 0.")]
    public int UserId { get; set; }

    [Required(ErrorMessage = "Order Date is required.")]
    public DateTime OrderDate { get; set; }

    public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
