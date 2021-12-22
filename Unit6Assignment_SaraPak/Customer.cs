using System;

namespace Unit6Assignment_SaraPak
{
    class Customer
    {
        int NumberOfItems;
        public Customer()
        {
            NumberOfItems = 6;
        }
        public Customer(int items)
        {
            int ClothingItems = items;
            if (ClothingItems == 0)
            {
                NumberOfItems = GetRandomNumber(1, 20);
            }
            else
            {
                NumberOfItems = ClothingItems;
            }
        }
        //return the number of items
        public int getNumberOfItems()
        {
            return NumberOfItems;
        }
        //random number methods
        private static readonly Random getRandom = new Random();
        public static int GetRandomNumber(int min, int max)
        {
            lock (getRandom)
            {
                return getRandom.Next(min, max);
            }
        }
    }
}
