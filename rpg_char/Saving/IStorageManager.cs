using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rpg_char
{
    public interface IStorageManager
    {
        void Save(Character character, string path);

        Character Load(string path);
    }
}