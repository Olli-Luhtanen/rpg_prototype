using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rpg_char
{
    public class JsonSaveManager : IStorageManager
    {
        public void Save(Character character,string path)
        {

        }

        public Character Load(string path) 
        {
            Character value = new Character();
            return value;
        }
    }
}