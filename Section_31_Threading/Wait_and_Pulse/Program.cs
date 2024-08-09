﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace Wait_and_Pulse
{
    static class Shared
    {
        //Lock object to be used by both Producer and Consumer
        public static object LockObject = new object();

        //Buffer to store int data values
        public static Queue<int> Buffer = new Queue<int>();
        
        //maximum capacity of the buffer (queue)
        public const int BufferCapacity = 5;

        public static void Print()
        {
            //O/P: Buffer: 1,2,3,4,5
            Console.WriteLine("Buffer: ");
            foreach (int item in Buffer)
            {
                Console.WriteLine($"{item}, ");
            }
            Console.WriteLine();
        }
    }

    class Producer
    {
        //Thread Method
        public void Produce()
        {
            Console.WriteLine($"Producer: Generating Data");
            //actual Code goes on
            Console.WriteLine("Production Completed");
        }
    }

    class Consumer
    {
        //Thread Method
        public void Consume()
        {
            Console.WriteLine($"Consumer: Consumer Started");
            //actual Code goes on
            Console.WriteLine("Consumption Completed");
        }
    }

    class Program
    {
        static void Main()
        {
            //create objects of Producer and Consumer types
            Producer producer = new Producer();
            Consumer consumer = new Consumer();

            //create objects of Thread class

            //internally creates object of ThreadStart
            Thread producerThread = new Thread(producer.Produce)
            {
                Name = "Producer Thread"
            };
            Thread consumerThread = new Thread(consumer.Consume)
            {
                Name = "Consumer Thread"
            };

            //Start thread
            producerThread.Start();
            consumerThread.Start();

            //Join (main thread will wait for the following thread)
            producerThread.Join();
            consumerThread.Join();

            Console.ReadKey();
        }
    }
}
