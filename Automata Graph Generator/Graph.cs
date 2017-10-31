using System;
using System.Collections.Generic;
using System.Data;
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
        private List<char> _alphabet;

        public Graph()
        {
            _startingState = null;
            _allStates = new List<Node>();
            _alphabet = new List<char>();
        }

        public Node StartingState { get => _startingState; set => _startingState = value; }
        protected List<Node> AllStates { get => _allStates; set => _allStates = value; }
        public List<char> Alphabet { get => _alphabet; set => _alphabet = value; }
        #endregion

        #region Methods

        abstract public bool AddState(string name, bool accepted, string previousStateName, char symbol, Dictionary<char, Node> transitions = null);
        abstract public bool AddStartState(string name, bool accepted);
        abstract public bool AddTransition(string fromState, string toState, char symbol);
        abstract public bool GenerateFromTransitionTable(DataTable transTable);
        abstract public DataTable ToDataTable();


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
        /// <param name="symbol">Symbol under which the automata goes from previousState to the new state.</param>
        /// <param name="transitions">Transitions from the new state ['symbol', "nextStateName"].</param>
        /// <returns>False - no such previousState
        /// True - all good</returns>
        public override bool AddState(string name, bool accepted, string previousStateName, char symbol, Dictionary<char, Node> transitions = null)
        {
            
            if (!AllStates.Where(n => n.Name == name).Any() && Alphabet.Exists(s => s == symbol))
            {
                Node prevState = AllStates.Where(n => n.Name == previousStateName).First();
                if (prevState != null)
                {
                    Node newNode = new Node(name, accepted, false, transitions);
                    prevState.Transitions.Add(symbol, newNode);
                    AllStates.Add(newNode);
                    return true; 
                }
            }
            return false;
            
        }
        
        /// <summary>
        /// Adds transition from one existing state to another.
        /// </summary>
        /// <param name="fromState">Statring state.</param>
        /// <param name="toState">Ending state.</param>
        /// <param name="symbol">Symbol under which the transistion happens.</param>
        /// <returns>False - one (or both) of the states nonexistent
        /// True - all good</returns>
        public override bool AddTransition(string fromState, string toState, char symbol)
        {
            Node from = AllStates.Where(n => n.Name == fromState).First();
            Node to = AllStates.Where(n => n.Name == toState).First();

            if(from == null || to == null || !Alphabet.Exists(s => s == symbol))
            {
                return false;
            }

            from.Transitions.Add(symbol, to);

            return true;
        }

        public override bool GenerateFromTransitionTable(DataTable transTable)
        {
            throw new NotImplementedException();
        }

        public override DataTable ToDataTable()
        {
            #region prepping the datatable

            DataTable dt = new DataTable();
            dt.Columns.Add("isAcepted", typeof(bool));
            dt.Columns.Add("Name", typeof(string));
            foreach (var symbol in Alphabet)
            {
                dt.Columns.Add(symbol.ToString(), typeof(string));
            }

            #endregion

            // adding the starting state
            Node adding = AllStates.Where(s => s.IsStart == true).First();
            DataRow newRow = adding.ToDataRow(ref dt);

            throw new NotImplementedException();
        }
    }
}
