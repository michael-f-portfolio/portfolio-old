using System;
using System.Collections.Generic;
using System.Linq;
using AmpLib.TCG.Board;
using AmpLib.TCG.Cards.Heros;
using AmpLib.TCG.ConsoleOutput;
using AmpLib.TCG.Mechanics;
using AmpLib.TCG.Mechanics.Generators;


namespace AmpLib
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            var mage = HeroGenerator.GenerateMage();

            Draw.FirstDraw(mage);

            Draw.DrawCards(mage);
            Draw.DrawCards(mage, 3);

            Console.WriteLine(mage);
        }
    }
}
