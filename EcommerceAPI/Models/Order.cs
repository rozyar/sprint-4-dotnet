namespace EcommerceAPI.Models;

public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; } 
    public User User { get; set; } 

    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public string Status { get; set; } 

    public List<OrderItem> OrderItems { get; set; } 
    public decimal TotalAmount { get; set; } 
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

