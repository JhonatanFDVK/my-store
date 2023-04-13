using mystore.Entities;
using mystore.Entities.Enums;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter cliente data:");

        Console.Write("Name: ");
        string nameClient = Console.ReadLine();
        Console.Write("Email: ");
        string emailClient = Console.ReadLine();
        Console.Write("Birth date (DD/MM/YYYY): ");
        DateTime birthDateClient = DateTime.Parse(Console.ReadLine());

        Client client = new Client(nameClient, emailClient, birthDateClient);

        Console.WriteLine("\nEnter order data:");

        Console.Write("Status: ");
        OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

        Order order = new Order(DateTime.Now, status, client);

        Console.Write("\nHow many items to this order? ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine($"Enter #{i} item data:");
            Console.Write("Product name: ");
            string productName = Console.ReadLine();
            Console.Write("Product price: ");
            double productPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            Product product = new Product(productName, productPrice);
            OrderItem orderItem = new OrderItem(quantity, productPrice, product);

            order.AddItem(orderItem);
        }

        Console.WriteLine(order);
    }
}