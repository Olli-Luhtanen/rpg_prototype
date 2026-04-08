using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace rpg_char
{
    public class JsonSaveManager : IStorageManager
    {
        private readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        public void Save(Character character, string path)
        {
            string json = JsonSerializer.Serialize(character, _options);
            File.WriteAllText(path, json);
        }

        public Character Load(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"Save file not found: {path}");

            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<Character>(json, _options)
                ?? throw new InvalidOperationException("Failed to deserialize character.");
        }
    }
}