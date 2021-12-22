using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Unit6Assignment_SaraPak
{
    class Scenario
    {
        static Customer cust;
        static int items = 0;
        static int numberOfItems;
        static int controlItemNumber;

        public Scenario(int r, int c)
        {
            Console.WriteLine(r + " dressing rooms " + " for " + c + " customers.");

            controlItemNumber = 0;
            numberOfItems = 0;
        }
        static void Main(string[] args)
        {
            //ClothingItems = 0 will indicate the use of a random number.
            //ClothingItems = 1 - 20 will allow for load testing by forcing a specific number of items.
            Console.Write("What ClothingItems value do you want? (0 = random)");
            controlItemNumber = Int32.Parse(Console.ReadLine());

            //set the number of customers
            Console.Write("How many customers do you want? ");
            int numberOfCustomers = Int32.Parse(Console.ReadLine());
            Console.WriteLine("There are " + numberOfCustomers + " total customers.");

            //set the number of dressing rooms
            Console.Write("How many dressing rooms do you want? ");
            int totalRooms = Int32.Parse(Console.ReadLine());

            //start the scenario for testing
            Scenario s = new Scenario(totalRooms, numberOfCustomers);

            //create the dressing rooms object with number of rooms
            DressingRooms dr = new DressingRooms(totalRooms);

            List<Task> tasks = new List<Task>();

            //loop through the customers and create threads
            for (int i = 0; i < numberOfCustomers; i++)
            {
                //create the customer object
                cust = new Customer(controlItemNumber);

                //get the number of items
                numberOfItems = cust.getNumberOfItems();

                //track total number of items
                items += numberOfItems;

                //start async request room
                tasks.Add(Task.Factory.StartNew(async () =>
                {
                    await dr.RequestRoom(cust);
                }));
            }
            Task.WaitAll(tasks.ToArray());

            Console.WriteLine("Average run time in milliseconds {0} ", dr.getRunTime() / numberOfCustomers);
            Console.WriteLine("Average wait time in milliseconds {0} ", dr.getWaitTime() / numberOfCustomers);
            Console.WriteLine("Total customer is {0}", numberOfCustomers);
            int averageItemsPerCustomer = items / numberOfCustomers;

            Console.WriteLine("Average number of items was: " + averageItemsPerCustomer);
            Console.Read();
        }
    }
}
