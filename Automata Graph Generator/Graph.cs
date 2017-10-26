using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automata_Graph_Generator
{
    abstract class Graph
    {
        #region Fields and Properties
        protected Node _startingState;
        private List<Node> _allStates;

        public Node StartingState { get => _startingState; set => _startingState = value; }
        protected List<Node> AllStates { get => _allStates; set => _allStates = value; }
        #endregion

        #region Methods

        abstract public bool AddState(string name, bool accepted, string previousStateName, char previousTransition, Dictionary<char, Node> transitions = null);
        abstract public bool AddStartState(string name, bool accepted);



        #endregion
    }
}
