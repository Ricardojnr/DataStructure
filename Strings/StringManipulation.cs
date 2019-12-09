using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DataStructure
{
    public static class StringManipulation
    {

        public static int FindString(string word)
        {
            if (word == null)
                return 0;

            HashSet<char> DictVowels = new HashSet<char>();

            DictVowels.Add('a');
            DictVowels.Add('e');
            DictVowels.Add('i');
            DictVowels.Add('o');
            DictVowels.Add('u');


            int total = 0;
            foreach (var letter in word.ToLower())
                if (DictVowels.Contains(letter))
                    total++;

            return total;
        }
        public static string Reverse(string word)
        {
            if (string.IsNullOrEmpty(word))
                return "";

            StringBuilder finalWord = new StringBuilder();
            Stack<char> stringStack = new Stack<char>();
            foreach (var letter in word)
            {
                stringStack.Push(letter);
            }
            while (stringStack.Count != 0)
            {
                finalWord.Append(stringStack.Pop());
            }
            return finalWord.ToString();
        }
        public static string ReverseWords(string phrase)
        {
            if (string.IsNullOrWhiteSpace(phrase) || string.IsNullOrEmpty(phrase))
                return "";

            string[] words = phrase.Trim().Split(" ");
            Array.Reverse(words);
            return string.Join(" ", words);

            // StringBuilder finalWord = new StringBuilder();

            // Stack<string> StackPhrases  = new Stack<string>();
            // foreach (var word in words)
            //     StackPhrases.Push(word);


            // while(StackPhrases.Count != 0)
            // {
            //     finalWord.Append(StackPhrases.Pop() + " ");
            // }

            //return finalWord.ToString().Trim();
        }
        public static bool IsRotation(string word, string rotate)
        {
            string newString = word + word;

            return newString.Contains(rotate);
        }
        public static string RemoveDuplicate(string word)
        {
            StringBuilder newString = new StringBuilder();
            HashSet<char> hash = new HashSet<char>();

            foreach (var item in word)
            {
                if (!hash.Contains(item))
                {
                    hash.Add(item);
                    newString.Append(item);
                }
            }

            return newString.ToString();
        }

        public static string Capitalize(string phrase)
        {
            if (phrase.Trim().Length == 0)
                return "";

            var outputRegex = Regex.Replace(phrase, " +", " ").Trim();

            string[] words = outputRegex
                .Split(" ");

            for (int i = 0; i < words.Length; i++)
                words[i] = words[i].Substring(0, 1).ToUpper()
                        + words[i].Substring(1).ToLower();

            return string.Join(" ", words);
        }
        public static bool Anagram(string value1, string value2)
        {
            int ENGLISH_APH = 26;
            int[] frequencies = new int[ENGLISH_APH];

            value1 = value1.ToLower();
            for (int i = 0; i < value1.Length; i++)
                frequencies[value1[i]-'a']++;

            value2 = value2.ToLower();
            for (int i = 0; i < value2.Length; i++)
            {
                var index = value2[i] - 'a';
                if (frequencies[index] == 0)
                    return false;
                
                frequencies[index]--;
            }
            return true;
        }
    }
}
