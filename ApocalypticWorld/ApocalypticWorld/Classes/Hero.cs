using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApocalypticWorld.Classes
{
    class Hero : LivingThings
    {
        private event Action<Hero> HeroReachedTheTarget;

        private bool isReached;

        private int currentPosition;

        private int targetDistance;

        public int TargetDistance
        {
            get { return targetDistance; }
            set
            {
                try
                {
                    targetDistance = value;
                }
                catch (Exception)
                {
                    Console.WriteLine(Helper.EM_INT_FORMAT_EXCEPTION);
                }
            }
        }

        public LivingThingsType Type { get { return LivingThingsType.Hero; } }

        public bool IsReached { get { return isReached; } }

        public Hero(Action<LivingThings> deathAction, Action<Hero> reachAction) : base(deathAction)
        {
            isReached = false;
            HeroReachedTheTarget += reachAction;
            Name = Helper.C_HERO;
        }

        public void Move(int position)
        {
            currentPosition = position;
            CheckPositionStatus();
        }

        private void CheckPositionStatus()
        {
            if (currentPosition >= TargetDistance)
            {
                isReached = true;
                HeroReachedTheTarget?.Invoke(this);
            }
            else
            {
                Position = currentPosition;
            }
        }

        public Hero ShallowCopy()
        {
            return (Hero)this.MemberwiseClone();
        }
    }
}
