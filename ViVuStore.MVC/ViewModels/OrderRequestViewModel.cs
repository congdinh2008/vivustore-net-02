namespace ViVuStore.MVC.ViewModels;

public class OrderRequestViewModel
{
    public required DateTime OrderDate { get; set; }

    public required string ShippedAddress { get; set; }

    public DateTime ExpectedShippedDate { get; set; }

    public required string PhoneNumber { get; set; }

    public List<ProductInOrder> Products { get; set; }
}

public class ProductInOrder
{
    public Guid ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal Discount { get; set; }
}