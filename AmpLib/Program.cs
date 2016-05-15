using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmpLib.MessingAround.TCG.Cards.Minions;
using AmpLib.MessingAround.TCG.Views;

namespace AmpLib
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var babyDuck = new BabyDuck();
            var babySquid = new BabySquid();

            babyDuck.AttackMinion(babySquid);

            Console.WriteLine(babyDuck + "\n");
            Console.WriteLine(babySquid + "\n");

            Console.WriteLine(CardTemplates.Card);

            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
