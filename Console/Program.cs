using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ConsoleApplication._002IntroToLambdas;
using ConsoleApplication._003IntroToLinq;
using ConsoleApplication._004DelegatesAndEvents;

namespace ConsoleApplication
{
    

    public class Program
    {
        

       

        

        public static void Main()
        {
            int videoNum = 3;

            switch (videoNum)
            {
                case 1:
                    Console.WriteLine("There is no video 1");
                    break;
                case 2:
                    IntroToLambdas.Execute();
                    break;
                case 3: 
                    IntroToLinq.Execute();
                    break;
                case 4:
                    DelegatesAndEvents.Execute();
                    break;
               
            }

            Console.ReadKey();
        }

    }
}
