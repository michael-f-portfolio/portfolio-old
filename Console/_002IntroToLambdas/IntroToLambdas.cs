using System;
using System.Collections.Generic;

namespace ConsoleApplication._002IntroToLambdas
{
    public static class IntroToLambdas
    {
        public static void Execute()
        {
            var input = new List<int> { 7, 20, 4 };

            var output = FilterList(input, item =>
            {
                Console.WriteLine($"Do you want to add {item}?");

                var response = Console.ReadLine();

                if (response == "yes")
                    return true;

                return false;

                //return item < 10;
            });

            foreach (var item in output)
            {
                Console.WriteLine(item);
            }


            //ForEach(input, (item, index) => Console.WriteLine(item + " : " + index));
        }

        static void ForEach<TType>(List<TType> items, Action<TType, int> doStuff)
        {
            var index = 0;

            foreach (var item in items)
            {
                doStuff(item, index);

                index++;
            }
        }

        static List<TElement> FilterList<TElement>(List<TElement> items, Func<TElement, bool> predicate)
        {
            var output = new List<TElement>();
            foreach (var item in items)
            {
                if (predicate(item))
                {
                    output.Add(item);
                }
            }

            return output;
        }

    }
}