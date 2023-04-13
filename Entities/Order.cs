using mystore.Entities.Enums;
using System.Text;

namespace mystore.Entities
{
    internal class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order() { }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }

        public double Total()
        {
            double total = 0;

            foreach (OrderItem item in Items)
            {
                total += item.SubTotal();
            }

            return total;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("ORDER SUMMARY:");
            sb.Append("Order moment: ");
            sb.Append(Moment);
            sb.AppendLine();
            sb.Append("Order status: ");
            sb.Append(Status);
            sb.AppendLine();
            sb.Append("Client: ");
            sb.Append(Client.Name);
            sb.Append(Client.BithDate);
            sb.Append(" - ");
            sb.Append(Client.Email);

            sb.AppendLine("Order items:");

            foreach (OrderItem item in Items)
            {
                sb.Append(
                    item.Product.Name + ", " + 
                    item.Product.Price + 
                    ", Quantity: " + item.Quantity + 
                    ", Subtotal: " + item.SubTotal());
            }

            return sb.ToString();

        }
    }
}
