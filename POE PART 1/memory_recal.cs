using System;
using System.Collections.Generic;
using System.IO;

namespace POE_PART_1
{
    public class memory_recal
    {
        private string path;

        // Constructor
        public memory_recal()
        {
            string full_path = AppDomain.CurrentDomain.BaseDirectory;
            string new_path = full_path.Replace("bin\\Debug\\", "");
            path = Path.Combine(new_path, "memory.txt");

            // Ensure the memory.txt file exists
            if (!File.Exists(path))
            {
                using (File.CreateText(path)) { }
            }
        }

        // Method to store or update a memory
        public void StoreMemory(string key, string value)
        {
            List<string> memory_stored = LoadMemoryFromFile();

            bool found = false;
            for (int i = 0; i < memory_stored.Count; i++)
            {
                if (memory_stored[i].StartsWith(key + ":"))
                {
                    memory_stored[i] = key + ":" + value;
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                memory_stored.Add(key + ":" + value);
            }

            File.WriteAllLines(path, memory_stored);
        }

        // Method to retrieve/display a stored memory by key
        public string DisplayMemory(string key)
        {
            List<string> memory_stored = LoadMemoryFromFile();
            foreach (var line in memory_stored)
            {
                if (line.StartsWith(key + ":"))
                {
                    return line.Substring(key.Length + 1); // Return the value
                }
            }
            return null; // Key not found
        }

        // Method to load the contents of the memory file
        private List<string> LoadMemoryFromFile()
        {
            return new List<string>(File.ReadAllLines(path));
        }
    }
}
