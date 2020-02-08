using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApocalypticWorld.Classes
{
    abstract class LivingThings
    {
        private event Action<LivingThings> HasDied;

        private int remainingHealth;

        private int attackPower;

        private int position;

        private bool isAlive;

        public string Name { get; set; }

        public LivingThingsType Type { get; set; }

        public int Health 
        { 
            get { return remainingHealth; } 
            set 
            { 
                try
                {
                    remainingHealth = value;
                    CheckDeathStatus();
                }
                catch (Exception)
                {
                    Console.WriteLine(Helper.EM_INT_FORMAT_EXCEPTION);
                }
            } 
        }

        public int AttackPower 
        {
            get { return attackPower; } 
            set
            {
                try
                {
                    attackPower = value;
                }
                catch (Exception)
                {
                    Console.WriteLine(Helper.EM_INT_FORMAT_EXCEPTION);
                }
            }
        }

        public int Position
        {
            get { return position; }
            set
            {
                try
                {
                    position = value;
                }
                catch (Exception)
                {
                    Console.WriteLine(Helper.EM_INT_FORMAT_EXCEPTION);
                }
            }
        }

        public bool IsAlive { get { return isAlive; } }

        public LivingThings(Action<LivingThings> deathEvent)
        {
            isAlive = true;
            HasDied += deathEvent;
        }

        public void Hit(LivingThings fighter1, LivingThings fighter2)
        {
            int roundCount = CalculateRoundCount(fighter1, fighter2);
            fighter1.Health -= fighter2.AttackPower * roundCount;
            fighter2.Health -= fighter1.AttackPower * roundCount;
            WriteLastStatus(fighter1, fighter2);
        }

        private void WriteLastStatus(LivingThings fighter1, LivingThings fighter2)
        {
            LivingThings aliveOne = fighter1.IsAlive ? fighter1 : fighter2;
            LivingThings deadOne = fighter1.IsAlive ? fighter2 : fighter1;
            Console.WriteLine($"{aliveOne.Name} defeated {deadOne.Name} with {aliveOne.Health} HP remaining.");
        }

        private int CalculateRoundCount(LivingThings fighter1, LivingThings fighter2)
        {
            int roundCount1 = (fighter2.Health % fighter1.AttackPower == 0) ? fighter2.Health / fighter1.AttackPower :
                (fighter2.Health / fighter1.AttackPower) + 1;

            int roundCount2 = (fighter1.Health % fighter2.AttackPower == 0) ? fighter1.Health / fighter2.AttackPower :
                (fighter1.Health / fighter2.AttackPower) + 1;

            if (roundCount1 <= roundCount2)
                return roundCount1;
            else
                return roundCount2;
        }

        private void CheckDeathStatus()
        {
            if (remainingHealth <= 0)
            {
                remainingHealth = 0;
                isAlive = false;
                HasDied?.Invoke(this);
            }
        }
    }
}
