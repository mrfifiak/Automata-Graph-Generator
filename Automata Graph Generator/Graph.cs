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
        private Node _startingState;
        private List<Node> _allStates;

        public Graph()
        {
            _startingState = null;
            _allStates = new List<Node>();
        }

        public Node StartingState { get => _startingState; set => _startingState = value; }
        protected List<Node> AllStates { get => _allStates; set => _allStates = value; }
        #endregion

        #region Methods

        abstract public bool AddState(string name, bool accepted, string previousStateName, char previousTransition, Dictionary<char, Node> transitions = null);
        abstract public bool AddStartState(string name, bool accepted);



        #endregion
    }

    class DFAGraph : Graph
    {
        public override bool AddStartState(string name, bool accepted)
        {
            if (StartingState == null)
            {

                StartingState = new Node(name, accepted, true);
                AllStates.Add(StartingState);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Adds a state to the graph.
        /// </summary>
        /// <param name="name">Name of the state.</param>
        /// <param name="accepted">Defines if the state is accepted.</param>
        /// <param name="previousStateName">Name of one of the states that has the transition to the new state.</param>
        /// <param name="previousTransition">Symbol under which the automata goes from previousState to the new state.</param>
        /// <param name="transitions">Transitions from the new state ['symbol', "nextStateName"].</param>
        /// <returns>False - no such previousState
        /// True - all good</returns>
        public override bool AddState(string name, bool accepted, string previousStateName, char previousTransition, Dictionary<char, Node> transitions = null)
        {
            if (!AllStates.Where(n => n.Name == name).Any())
            {
                Node newNode = new Node(name, accepted, false, transitions);
            }
            return false;
            
        }
    }
}
