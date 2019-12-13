
using C5;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    public class WeightedGraph
    {
        private Dictionary<string, Node> _nodes = new Dictionary<string, Node>();
        private class Node
        {
            public string label { get; private set; }
            public List<Edge> Edges = new List<Edge>();

            public Node(string label)
            {
                this.label = label;
            }

            public void AddEdge(Node to, int weight)
            {
                Edges.Add(new Edge(this, to, weight));
            }
        }
        private class Edge
        {
            public Node from { get; private set; }
            public Node to { get; private set; }
            public int weight { get; private set; }

            public Edge(Node from, Node to, int weight)
            {
                this.from = from;
                this.to = to;
                this.weight = weight;
            }
        }

        private class NodeEntry : IComparable<NodeEntry>
        {
            public Node node { get; private set; }
            public int priority { get; private set; }
            public NodeEntry(Node node, int priority)
            {
                this.node = node;
                this.priority = priority;
            }

            public int CompareTo(NodeEntry other)
            {
                return priority.CompareTo(other.priority);
            }
        }
        public void AddNode(string label)
        {
            Node node = new Node(label);
            if (!_nodes.ContainsKey(label) && !_nodes.ContainsValue(node))
                _nodes.Add(label, new Node(label));
        }

        public void AddEdge(string from, string to, int weight)
        {

            Node fromNode = _nodes[from];
            if (fromNode == null)
                throw new Exception();

            Node toNode = _nodes[to];
            if (toNode == null)
                throw new Exception();

            fromNode.AddEdge(toNode, weight);
            toNode.AddEdge(fromNode, weight);
        }

        public Path GetShortestPath(string from, string to)
        {
            var fromNode = _nodes[from];
            var toNode = _nodes[to];
            Dictionary<Node, int> distances = new Dictionary<Node, int>();

            foreach (var node in _nodes.Values)
                distances.Add(node, int.MaxValue);

            distances[fromNode] = 0;

            IntervalHeap<NodeEntry> queue = new C5.IntervalHeap<NodeEntry>();
            queue.Add(new NodeEntry(fromNode, 0));

            Dictionary<Node, Node> previousNode = new Dictionary<Node, Node>();

            System.Collections.Generic.HashSet<Node> visited = new System.Collections.Generic.HashSet<Node>();
            while (queue.Count != 0)
            {
                var current = queue.DeleteMin().node;
                visited.Add(current);

                foreach (var edge in current.Edges)
                {
                    if (visited.Contains(edge.to))
                        continue;

                    var newDistance = distances[current] + edge.weight;
                    if (newDistance < distances[edge.to])
                    {
                        distances[edge.to] = newDistance;
                        previousNode.Add(edge.to, current);
                        queue.Add(new NodeEntry(edge.to, newDistance));
                    }
                }
            }
            return BuildPath(previousNode, toNode);
        }
        private Path BuildPath(Dictionary<Node, Node> previousNode, Node toNode)
        {
            Stack<Node> stack = new Stack<Node>();
            stack.Push(toNode);
            var previous = previousNode[toNode];

            while (previous != null)
            {
                stack.Push(previous);
                previous = previousNode[previous];
            }
            var path = new Path();
            while (stack.Count != 0)
                path.Add(stack.Pop().label);
            
            return path;
        }
    }
}
