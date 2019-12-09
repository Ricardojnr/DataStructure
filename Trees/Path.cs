using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    public class Path
    {
        private List<string> nodes = new List<string>();
        
        public void Add(string node)
        {
            nodes.Add(node);
        }
    }
}
