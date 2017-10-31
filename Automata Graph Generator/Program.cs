﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automata_Graph_Generator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            */


            DataTable transitionTable = new DataTable();

            DFAGraph dfa = new DFAGraph();
            dfa.Alphabet.Add('a');
            dfa.Alphabet.Add('b');
            dfa.AddStartState("A", true);
            dfa.AddState("B", true, "A", 'a');
            dfa.AddState("C", false, "B", 'b');
            dfa.AddState("D", false, "B", 'd');
            dfa.AddTransition("A", "C", 'b');
            dfa.AddTransition("A", "C", 'h');

            DataTable dt = dfa.ToDataTable();

            Console.WriteLine("TEST ENDS...");
        }
    }
}
