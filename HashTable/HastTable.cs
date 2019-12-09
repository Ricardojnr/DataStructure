using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{

    public class HashTable

    {
        private class Entry
        {
            public int Key;
            public string Value;

            public Entry(int key, string value)
            {
                this.Key = key;
                this.Value = value;
            }
        }

        private List<Entry>[] entries = new List<Entry>[5];

        public void Add(int key, string value)
        {

            int index = Hash(key);
            if (entries[index] == null)
                entries[index] = new List<Entry>();
            else
            {
                Entry entry = LocateEntryPerKey(key);
                if (entry != null)
                {
                    entry.Value = value;
                    return;
                }
            }
            entries[index].Add(new Entry(key, value));
        }
        public string Get(int key)
        {
            Entry entry = LocateEntryPerKey(key);
            if (entry != null)
            {
                return entry.Value;
            }
            return string.Empty;
        }
        public void Remove(int key)
        {
            var index = Hash(key);
            foreach (var entry in entries[index])
            {
                if (entry.Key == key)
                {
                    entries[index].Remove(entry);
                    return;
                }
            }
        }

        private Entry LocateEntryPerKey(int key)
        {
            int index = Hash(key);
            foreach (var entry in entries[index])
            {
                if (entry.Key == key)
                    return entry;
            }
            return null;
        }

        private int Hash(int key)
        {
            return key % entries.Length;
        }

    }


}
