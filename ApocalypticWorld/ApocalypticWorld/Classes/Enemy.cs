using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApocalypticWorld.Classes
{
    class Enemy : LivingThings
    {
        public LivingThingsType Type { get { return LivingThingsType.Enemy; } }

        public Enemy(Action<LivingThings> deathEvent) : base(deathEvent)
        {
        }

        public Enemy ShallowCopy()
        {
            return (Enemy) this.MemberwiseClone();
        }
    }
}
