using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructure
{
    public class Graph
    {
        private Dictionary<string, Node> _nodes = new Dictionary<string, Node>();
        private Dictionary<Node, List<Node>> _adjacencyList = new Dictionary<Node, List<Node>>();
        private class Node
        {
            public string label { get; private set; }

            public Node(string label)
            {
                this.label = label;
            }
            public override string ToString()
            {
                return label;
            }
        }
        public void AddNode(string label)
        {
            Node node = new Node(label);
            if (!_nodes.ContainsKey(label) && (!_nodes.ContainsValue(node)))
                _nodes.Add(label, node);

            if (!_adjacencyList.ContainsKey(node))
                _adjacencyList.Add(node, new List<Node>());

        }
        public void AddEdge(string from, string to)
        {
            var fromNode = _nodes[from];
            if (fromNode == null)
                throw new Exception();

            var toNode = _nodes[to];
            if (toNode == null)
                throw new Exception();

            _adjacencyList[fromNode].Add(toNode);
        }
        public void Print()
        {
            foreach (var source in _adjacencyList.Keys)
            {
                var targets = _adjacencyList[source];
                if (targets.Count != 0)
                    Console.WriteLine(source + " is connect to " + targets.ToString());
            }
        }
        public void RemoveNode(string label)
        {
            var node = _nodes[label];
            if (node == null)
                return;

            foreach (var n in _adjacencyList.Keys)
                _adjacencyList[n].Remove(node);

            _adjacencyList.Remove(node);
            _nodes.Remove(label);
        }
        public void RemoveEdge(string from, string to)
        {
            var fromNode = _nodes[from];
            var toNode = _nodes[to];

            if (fromNode == null || toNode == null)
                return;

            _adjacencyList[fromNode].Remove(toNode);
        }
        public void DepthFirst(string root)
        {
            var node = _nodes[root];
            if (node == null)
                return;

            DepthFirst(node, new HashSet<Node>());
        }
        private void DepthFirst(Node root, HashSet<Node> visited)
        {
            Console.WriteLine(root.label);
            visited.Add(root);

            foreach (var node in _adjacencyList[root])
                if (!visited.Contains(node))
                    DepthFirst(node, visited);

        }
        public void DepthFirstRec(string root)
        {
            var node = _nodes[root];
            if (node == null)
                return;

            HashSet<Node> visited = new HashSet<Node>();
            Stack<Node> st = new Stack<Node>();
            st.Push(node);
            while (st.Count != 0)
            {
                var current = st.Pop();

                if (visited.Contains(current))
                    continue;

                Console.WriteLine(current);
                visited.Add(current);

                foreach (var neighbour in _adjacencyList[current])
                    if (visited.Contains(node))
                        st.Push(neighbour);
            }
        }
        public void BreathFirst(string root)
        {
            var node = _nodes[root];
            if (node == null)
                return;

            HashSet<Node> visited = new HashSet<Node>();
            Queue<Node> st = new Queue<Node>();
            st.Enqueue(node);
            while (st.Count != 0)
            {
                var current = st.Dequeue();

                if (visited.Contains(current))
                    continue;

                Console.WriteLine(current);
                visited.Add(current);

                foreach (var neighbour in _adjacencyList[current])
                    if (visited.Contains(node))
                        st.Enqueue(neighbour);
            }
        }
        public List<string> TopologicalSort()
        {
            Stack<Node> stack = new Stack<Node>();
            HashSet<Node> visited = new HashSet<Node>();

            foreach (var node in _nodes.Values)
                TopologialSort(node, visited, stack);

            List<string> Sorted = new List<string>();
            while (stack.Count != 0)
            {
                Sorted.Add(stack.Pop().label);
            }
            return Sorted;
        }
        private void TopologialSort(Node node, HashSet<Node> visited, Stack<Node> stack)
        {
            if (visited.Contains(node))
                return;

            visited.Add(node);

            foreach (var neighbour in _adjacencyList[node])
                TopologialSort(neighbour, visited, stack);

            stack.Push(node);
        }

        public bool HasCycle()
        {
            HashSet<Node> all = new HashSet<Node>();
            all.UnionWith(_nodes.Values);
            HashSet<Node> visiting = new HashSet<Node>();
            HashSet<Node> visited = new HashSet<Node>();

            while (all.Count != 0)
            {
                var current = all.FirstOrDefault();
                if (HasCycle(current, all, visiting, visited))
                    return true;
            }
            return false;
        }

        private bool HasCycle(Node node, HashSet<Node> all, HashSet<Node> visiting,
                            HashSet<Node> visited)
        {
            all.Remove(node);
            visiting.Add(node);
            foreach (var neighbour in _adjacencyList[node])
            {
                if (visited.Contains(neighbour))
                    continue;
                if (visiting.Contains(neighbour))
                    return true;

                var result = HasCycle(neighbour, all, visiting, visited);
                if (result)
                    return true;
            }
            visiting.Remove(node);
            visited.Add(node);
            
            return false;
        }
    }
}
