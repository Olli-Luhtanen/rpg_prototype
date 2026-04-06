using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rpg_char
{
    [Flags]
    public enum WeaponProperty
    {
        None = 0, 
        TwoHanded = 1 << 0, //Takes up both hand slots, Cannot be used with a shield or another weapon in the off-hand.
        Versatile = 1 << 1, //Can be used with one or two hands. The damage die changes to the one specified in the versatile property.
        Finesse = 1 << 2,   //You are able to use your choice of STR or DEX for attack rolls.
        Thrown = 1 << 3,    //Weapon can be thrown effectively as an attack.
        Ranged = 1 << 4,    //The weapon is a ranged weapon.
        Reach = 1 << 5,     //The weapon has an extended reach for melee attacks.
    }
}