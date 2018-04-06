public class Product
{
public Product(string name, decimal price)
{
Name = name;
Price = price;
}
public string Name
{
get;
private set;
}
public decimal Price
{
get;
private set;
}
}

//-----------------------------------------------------------------

public class Customer
{
public Customer(int id, string name)
{
ID = id;
Name = name;
_orders = new List<Order>();
}
public int ID
{
get;
private set;
}
public string Name
{
get;
private set;
}
public IEnumerable<Order> Orders
{
get { return _orders; }
}
public void AddOrder(Order order)
{
_orders.Add(order);
}
private ICollection<Order> _orders;
}

//-----------------------------------------------------------------

public class Order
{
public Order(string code, Customer customer)
{
Code = code;
Customer = customer;
OrderLines = new List<Product>();
}
public string Code
{
get;
private set;
}
public Customer Customer
{
get;
private set;
}
public IEnumerable<Product> OrderLines
{
get;
private set;
}
public void AddOrderLine(Product product)
{
_orderLines.Add(product);
}
private ICollection<Product> _orderLines;
}