using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rpg_char
{
    public interface IItem
    {
        string Name();
        string Description();
        float Weight();
        int Value();
    }
}