using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automata_Graph_Generator
{
    class Node
    {
        string _name;
        bool _isAccepted;
        bool _isStart;
        Dictionary<char, Node> _transitions;

        public string Name { get => _name; set => _name = value; }
        public bool IsAccepted { get => _isAccepted; set => _isAccepted = value; }
        public bool IsStart { get => _isStart; set => _isStart = value; }
        internal Dictionary<char, Node> Transitions { get => _transitions; set => _transitions = value; }
    }
}
