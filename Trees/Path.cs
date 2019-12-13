using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    public class Path
    {
        private List<string> _nodes = new List<string>();
        
        public void Add(string node)
        {
            _nodes.Add(node);
        }
    }
}
