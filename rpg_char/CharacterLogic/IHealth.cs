using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rpg_char
{
    public interface IHealth
    {
        int MaxHP { get; }
        int CurrentHP { get; }
        void TakeDamage(int amount);
        void Heal(int amount);
        bool IsAlive { get; }
    }
}