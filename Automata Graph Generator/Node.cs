using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automata_Graph_Generator
{
    class Node
    {
        //TODO: CHANGE NAME TO ‚STATE’
        string _name;
        bool _isAccepted;
        bool _isStart;
        Dictionary<char, Node> _transitions;

        #region Properties
        public string Name { get => _name; set => _name = value; }
        public bool IsAccepted { get => _isAccepted; set => _isAccepted = value; }
        public bool IsStart { get => _isStart; set => _isStart = value; }
        internal Dictionary<char, Node> Transitions { get => _transitions; set => _transitions = value; }

        #endregion

        #region Methods

        public Node(string name, bool isAccepted = false, bool isStart = false, Dictionary<char, Node> transitions = null)
        {
            _name = name;
            _isAccepted = isAccepted;
            _isStart = isStart;
            _transitions = transitions;
            if(_transitions == null)
            {
                _transitions = new Dictionary<char, Node>();
            }
#if DEBUG
            string debug = string.Empty;
            if (isAccepted) debug += "Accepted ";
            if (isStart) debug += "Starting ";
            debug += "Node ";
            if (transitions == null) debug += "with no outgoing transitions ";

            Debug.WriteLine(debug + "constructed."); 
#endif
        }

        public override string ToString()
        {
            return _name;
        }

        internal DataRow ToDataRow(ref DataTable dt)
        {
            DataRow dr = dt.NewRow();

            dr["isAccepted"] = IsAccepted;
            dr["Name"] = Name;
            for (int i = 2; i < dt.Columns.Count; i++)
            {
                char sym = char.Parse(dt.Columns[i].ColumnName);

                // TODO: IF IT'S FALSE, IT'S NOT DFA
                if (Transitions.Where(s => s.Key == sym).Any())
                {
                    dr[i] = Transitions[sym]; 
                }

            }

            return dr;
        }



        #endregion
    }
}
