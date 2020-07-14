using GenericBackgroundWorker.Test;
using System;
using System.Collections.Generic;

namespace GenericBackgroundWorker.Implementation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var inputList = new List<string>
            {
                "Test String : 1",
                "Test String : 2",
                "Test String : 3"
            };
            var worker = new BackgroundWorkerImpl(inputList);
            worker.StartWorker();


            while (worker.IsWorkerBusy)
            {

            }

            Console.ReadKey();
        }
    }
}
