using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SydneyHotel
{
    class Program
    {
        class ReservationDetail
        {
            public string customerName { get; set; }
            public int nights { get; set; }
            public string roomService { get; set; }
            public double totalPrice { get; set; }

        }
        // calulation of room services
        
        static double Price(int night, string isRoomService)
        {
            double price = 0;
            if (night <= 3)
                price = 100 * night;
            else if (night <= 10)
                price = 80.5 * night;
            else
                price = 75.3 * night;
            //roomservice should be checked to lower yes
            if (isRoomService.ToLower() == "yes")
                return price + price * 0.1;
            else
                return price;

        }
        static void Main(string[] args)
        {
            Console.WriteLine(".................Welcome to Sydney Hotel...............");
            Console.Write("\nEnter no. of Customer: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n--------------------------------------------------------------------\n");

            List<ReservationDetail> reservations = new List<ReservationDetail>();


            for (int i = 0; i < n; i++)
            {
                // Create a new reservation object
                var detail = new ReservationDetail();

                Console.Write("Enter customer name: ");
                detail.customerName = Console.ReadLine();

                Console.Write("Enter the number of nights: ");
                detail.nights = Convert.ToInt32(Console.ReadLine());

                while (detail.nights <= 0 || detail.nights > 20)
                {
                    Console.Write("Number of nights must be between 1 and 20. Enter again: ");
                    detail.nights = Convert.ToInt32(Console.ReadLine());
                }

                Console.Write("Enter yes/no to indicate whether you want room service: ");
                detail.roomService = Console.ReadLine();

                // ✅ Calculate total price
                detail.totalPrice = Price(detail.nights, detail.roomService);

                Console.WriteLine($"The total price from {detail.customerName} is ${detail.totalPrice}");
                Console.WriteLine("\n--------------------------------------------------------------------");

                // Add to the list
                reservations.Add(detail);

            }

            var sorted = reservations.OrderBy(r => r.totalPrice).ToList();
            var minrd = sorted.First();
            var maxrd = sorted.Last();

            Console.WriteLine("\n\t\t\t\tSummary of reservation");
            Console.WriteLine("--------------------------------------------------------------------\n");
            Console.WriteLine("Name\t\tNumber of nights\t\tRoom service\t\tCharge");
            Console.WriteLine($"{minrd.customerName}\t\t\t{minrd.nights}\t\t\t{minrd.roomService}\t\t\t{minrd.totalPrice}");
            Console.WriteLine($"{maxrd.customerName}\t\t{maxrd.nights}\t\t\t{maxrd.roomService}\t\t\t{maxrd.totalPrice}");
            Console.WriteLine("\n--------------------------------------------------------------------\n");
            Console.WriteLine($"The customer spending most is {maxrd.customerName} ${maxrd.totalPrice}");
            Console.WriteLine($"The customer spending least is {minrd.customerName} ${minrd.totalPrice}");
            Console.WriteLine($"Press any ket to continue....");
            Console.ReadLine();

        }
    }
}
