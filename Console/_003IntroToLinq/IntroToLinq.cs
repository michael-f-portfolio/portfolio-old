using System;
using System.Linq;

namespace ConsoleApplication._003IntroToLinq
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int Id { get; set; }
    }

    public static class IntroToLinq
    {
        // Deffered Execution
        //
        public static void Execute()
        {
            var people = new[]
            {
                new Person {FirstName = "Nelson", LastName = "LaQuet", Age = 100, Id = 1},
                new Person {FirstName = "asdfsdfNelson", LastName = "LaQsdfsdfasuet", Age = 432, Id = 2},
                new Person {FirstName = "Nelsdfsdfson", LastName = "LaQufsafsfddet", Age = 52, Id = 3},
                new Person {FirstName = "Nelsdfsdfdfson", LastName = "dsadad", Age = 26, Id = 4}
            };

            //var peopleFirstNameOlderThan200 =
            //    from person in people
            //    let fullName = $"{person.FirstName} {person.LastName}"
            //    where fullName == "Nelson LaQuet"
            //    select fullName;

            //var peopleFirstNameOlderThan200 =
            //   from asm in AppDomain.CurrentDomain.GetAssemblies()
            //   where asm.FullName.Contains("dll")
            //   from type in asm.GetTypes()
            //   where type.Namespace == "blegh"
            //   from meth in type.GetMethods()
            //   select meth.Name;

            //var results = people.Where(i => i.Age > 200)
            //                    .Select(i => i.FirstName);

            var stuff = people.ToDictionary(k => k.Id, v => v);

            Console.WriteLine(stuff[1].FirstName == "Nelson");


        }
    }
}