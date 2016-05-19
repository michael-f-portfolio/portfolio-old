using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using AmpLib.TCG.Cards;

namespace AmpLib.TCG.Board
{
    public class Hero
    {
        public string Name { get; set; }

        public Health Health { get; set; }
        public Mana Mana { get; set; }
        public Hand Hand { get; set; }
        

        public Hero(string name, int totalHealth, int totalMana)
        {
            Name = name;
            Health = new Health(totalHealth);
            Mana = new Mana(totalMana);
            Hand = new Hand();
        }

        public override string ToString()
        {
            return $"Name: {Name}\nHealth: {Health}\nMana: {Mana}\nHand: {Hand}";
        }

        
    }

    public class Mana
    {
        public int TotalMana { get; set; }
        public int CurrentMana { get; set; }

        public Mana(int totalMana)
        {
            TotalMana = CurrentMana = totalMana;
        }

        public override string ToString()
        {
            return $"Total Mana: {TotalMana}\t Current Mana: {CurrentMana}";
        }
    }

    public class Health
    {
        public int TotalHealth { get; set; }   
        public int CurrentHealth { get; set; }

        public Health(int totalhealth)
        {
            TotalHealth = CurrentHealth = totalhealth;
        }

        public override string ToString()
        {
            return $"Total Health: {TotalHealth}\t Current Health: {CurrentHealth}";
        }
    }

    public class Hand
    {
        public const int MaxHandSize = 10;
        public Card[] HandArray { get; set; }

        public Hand()
        {
            HandArray = new Card[MaxHandSize];
        }

        public override string ToString()
        {
            var str = $"Max Hand Size: {MaxHandSize}";

            foreach (var card in HandArray)
            {
                str += card;
            }

            return str;
        }

        public void FirstDraw()
        {
            
        }

        public void DrawCard()
        {
            
        }

        public void DrawCard(int drawAmount)
        {
            
        }
    }
}