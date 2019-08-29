using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnumeracaoComposicao.Entities.Enum;
using EnumeracaoComposicao.Entities;

namespace EnumeracaoComposicao
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Enter client data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Brith data (DD/MM/YYYY): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter order data: ");
            Console.Write("Status: ");
            //OrderStatus status = Enum.Parse <OrderStatus>(Console.ReadLine());// core
            Enum.TryParse<OrderStatus>(Console.ReadLine(), out OrderStatus status); //.Net

            Client client = new Client(name, email, date);
            Order order = new Order(DateTime.Now, status, client);

            Console.Write("How many items to this order: ");
            int n = int.Parse(Console.ReadLine());

            for(int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter item #{i} data: ");
                Console.Write("Product name: ");
                string prodname = Console.ReadLine();
                Console.Write("Produto price: ");
                double price = double.Parse(Console.ReadLine());

                Product product = new Product(prodname, price);

                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());                

                OrderItem orderItem = new OrderItem(quantity, price, product);
                order.AddItem(orderItem);
            }

            Console.WriteLine();
            Console.WriteLine("ORDER SUMMARY:");
            Console.WriteLine(order);
            Console.ReadLine();
        }
    }
}
