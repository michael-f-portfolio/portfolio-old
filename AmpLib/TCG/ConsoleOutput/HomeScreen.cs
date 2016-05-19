using System;

namespace AmpLib.TCG.ConsoleOutput
{
    public static class HomeScreen
    {
        /// <summary>
        /// Displays the homescreen to the user.
        /// </summary>
        /// <returns>An int containing the selection the user has made.</returns>
        public static int ShowHomeScreen()
        {
            Console.WriteLine("======== AmpLib TCG ========");
            Console.WriteLine("Please select a character:");
            Console.WriteLine("1. Mage");
            Console.WriteLine("2. Not Yet Implemented");
            Console.WriteLine("3. Okay then");
            Console.WriteLine("4. Quit");

            return int.Parse(Console.ReadKey().ToString());
        }

        
    }
}