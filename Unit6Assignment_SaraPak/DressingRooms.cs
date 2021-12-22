using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Unit6Assignment_SaraPak
{
    class DressingRooms
    {
        int rooms;
        Semaphore semaphore;
        long waitTimer;
        long runTimer;

        public DressingRooms()
        {
            rooms = 3;
            semaphore = new Semaphore(rooms, rooms);
        }
        public DressingRooms(int r)
        {
            rooms = r;
            //set the semaphore object
            semaphore = new Semaphore(rooms, rooms);
        }
        public async Task RequestRoom(Customer C)
        {
            Stopwatch stopWatch = new Stopwatch();
            //waiting thread
            Console.WriteLine("Customer is Waiting");

            //start the timer
            stopWatch.Start();
            semaphore.WaitOne();

            //stop the wait timer
            stopWatch.Stop();

            //get the time elapse for waiting
            waitTimer += stopWatch.ElapsedTicks;

            int roomWaitTime = GetRandomNumber(1, 3);
            //start the timer
            stopWatch.Start();
            Thread.Sleep((roomWaitTime * C.getNumberOfItems()));
            //stop the wait timer
            stopWatch.Stop();
            //get the elapsed run time
            runTimer += stopWatch.ElapsedTicks;

            Console.WriteLine("Customer finished trying on items in room");
            semaphore.Release();
        }
        public long getWaitTime()
        {
            return waitTimer;
        }
        public long getRunTime()
        {
            return runTimer;
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
