public class OrderItem
{
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set;}
    public float UnitPrice { get; set; }

    // Represents a single item in an order, storing the price at time of purchase.
    public OrderItem(string productName, int quantity, float unitPrice)
    {
        ProductName = productName;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }

    // Calculates the total cost of this item (quantity x unit price).
    public float Subtotal => Quantity * UnitPrice;
}

public class Order
{
    public int OrderId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public List<OrderItem> Items { get; set; }

    // Represents a customer order containing one or more items.
    public Order(int orderId, string customerName)
    {
        OrderId = orderId;
        CustomerName = customerName;
        Items = new List<OrderItem>();
    }

    // Calculates the final price of the order.
    // Applies a 10% discount if the total exceeds 500 euros.
    public float CalculateFinalPrice()
    {
        float total = Items.Sum(item => item.Subtotal);

        if(total > 500)
        {
            total *= 0.90f;
        }

        return total;
    }
    
    // Finds and returns the name of the customer who has spent
    // the most money across all their orders combined.
    public static string GetTopSpendingCustomer(List<Order> orders)
    {
        return orders
            .GroupBy(o => o.CustomerName)
            .Select(group => new
            {
                CustomerName = group.Key,
                TotalSpent = group.Sum(o => o.CalculateFinalPrice())
            })
            .OrderByDescending(c => c.TotalSpent)
            .First()
            .CustomerName;
    }

    // Returns a dictionary of all products and their total quantity sold,
    // sorted from most to least popular.
    public static Dictionary<string, int> GetPopularProducts(List<Order> orders)
    {
        return orders
            .SelectMany(o => o.Items)
            .GroupBy(item => item.ProductName)
            .ToDictionary(
                group => group.Key,
                group => group.Sum(item => item.Quantity)
            )
            .OrderByDescending(kvp => kvp.Value)
            .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
    }
}

class Program
{
    static void Main(string[] args)
    {
        //test data
        Order order1 = new Order(1, "Alice");
        order1.Items.Add(new OrderItem("Laptop", 1, 800f));
        order1.Items.Add(new OrderItem("Mouse", 2, 25f));

        Order order2 = new Order(2, "Bob");
        order2.Items.Add(new OrderItem("Phone", 1, 300f));
        order2.Items.Add(new OrderItem("Case", 1, 20f));

        Order order3 = new Order(3, "Alice");
        order3.Items.Add(new OrderItem("Monitor", 1, 400f));

        Order order4 = new Order(4, "Bob");
        order4.Items.Add(new OrderItem("Laptop", 2, 800f));
        order4.Items.Add(new OrderItem("Mouse", 1, 25f));

        List<Order> allOrders = new List<Order> { order1, order2, order3, order4 };

        Console.WriteLine("Order Prices:");
        foreach (var order in allOrders)
            Console.WriteLine($"Order {order.OrderId} ({order.CustomerName}): {order.CalculateFinalPrice():C}");

        Console.WriteLine("\nTop Spending Customer");
        string topCustomer = Order.GetTopSpendingCustomer(allOrders);
        Console.WriteLine($"Top spender: {topCustomer}");

        Console.WriteLine("\nPopular Products:");
        var products = Order.GetPopularProducts(allOrders);
        foreach (var kvp in products)
            Console.WriteLine($"{kvp.Key}: {kvp.Value} units sold");
    }
}