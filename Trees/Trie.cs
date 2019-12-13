using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructure
{
    public class Trie
    {
        private Node _root = new Node(' ');

        private class Node
        {
            public char Value { get; set; }
            private Dictionary<char, Node> _children = new Dictionary<char, Node>();
            public bool _isEndOfWord { get; set; }
            
            public Node[] getChildren => _children.Select(z => z.Value).ToArray();

            public Node(char value)
            {
                this.Value = value;
            }
            public bool HasChild(char ch)
            {
                return _children.ContainsKey(ch);
            }
            public void AddChild(char ch)
            {
                _children.Add(ch, new Node(ch));
            }
            public Node GetChild(char ch)
            {
                return _children[ch];
            }
            public bool HasChildren()
            {
                return _children.Count > 0;
            }

            public void RemoveChild(char ch)
            {
                _children.Remove(ch);
            }
        }

        public void Insert(string word)
        {
            if (string.IsNullOrEmpty(word))
                throw new Exception();

            Node current = _root;
            foreach (var ch in word)
            {
                if (!current.HasChild(ch))
                    current.AddChild(ch);

                current = current.GetChild(ch);
            }
            current._isEndOfWord = true;
        }
        public bool Contains(string word)
        {
            Node current = _root;

            foreach (var letter in word)
            {
                if (!current.HasChild(letter))
                    return false;

                current = current.GetChild(letter);
            }
            return current._isEndOfWord;
        }
        public bool ContaisRecursive(string word)
        {
            return ContaisRecursive(_root, word, 0);
        }
        private bool ContaisRecursive(Node current, string word, int index)
        {
            if (index == word.Length)
                return current._isEndOfWord;

            var letter = word[index];

            if (!current.HasChild(letter))
                return false;

            return ContaisRecursive(
                            current.GetChild(letter),
                            word,
                            index + 1);

        }
        public void Traverse()
        {
            Traverse(_root);
        }
        private void Traverse(Node root)
        {
            //comment Pre-Order Traverse.
            //Console.WriteLine(root.value);            
            foreach (var child in root.getChildren)
            {
                Traverse(child);
                //comment Post-Order Traverse.
                Console.WriteLine(child.Value);
            }

        }
        public void Delete(string word)
        {
            Delete(_root, word, 0);
        }
        private void Delete(Node root, string word, int index)
        {
            if (index == word.Length)
            {
                root._isEndOfWord = false;
                return;
            }

            var ch = word[index];
            var child = root.GetChild(ch);

            if (child == null)
                return;

            Delete(child, word, index + 1);

            if (!child.HasChildren() && !child._isEndOfWord)
                root.RemoveChild(ch);
            //Console.WriteLine(ch);
        }

        public List<string> FindAutoCompletion(string prefix)
        {
            List<string> words = new List<string>();
            var lastNode = FindLastNodeOf(prefix);
            FindWords(lastNode, prefix, words);
            return words;

        }
        private void FindWords(Node root, string prefix, List<string> words)
        {
            if (root == null)
                return;

            if (root._isEndOfWord)
                words.Add(prefix);

            foreach (var child in root.getChildren)
            {
                FindWords(child, prefix + child.Value, words);
            }
        }
        private Node FindLastNodeOf(string prefix)
        {
            if (prefix == null)
                return null;

            var current = _root;
            foreach (var ch in prefix.ToCharArray())
            {
                var child = current.GetChild(ch);
                if (child == null)
                    return null;
                current = child;
            }
            return current;
        }
        public static string LongestCommonPrefix(string[] words)
        {
            if (words == null)
                return "";
            var trie = new Trie();
            foreach (var word in words)
                trie.Insert(word);

            var prefix = new StringBuilder();

            var maxChars = GetShortest(words).Length;
            var current = trie._root;
            while(prefix.Length < maxChars)
            {
                var children = current.getChildren;
                if (children.Length != 1)
                    break;
                current = children[0];
                prefix.Append(current.Value);
            }
            return prefix.ToString();
        }
        private static string GetShortest(string[] words) 
        {
            if (words == null || words.Length == 0)
                return "";
            var shortest = words[0];
            
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length < shortest.Length)
                    shortest = words[i];
            }
            return shortest;
        }  
    }
}
