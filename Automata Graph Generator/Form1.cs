using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automata_Graph_Generator
{
    public partial class Form1 : Form
    {

        DataTable transitionTable = new DataTable();

        public Form1()
        {
            InitializeComponent();

            transitionTable.Columns.Add("asd", typeof(int));
            transitionTable.Columns.Add("aaaaaaaaaaaa", typeof(string));

            transitionTable.Rows.Add(2, "asdsdaaaa");
            transitionTable.Rows.Add(22, "p[pppppppppp");

            dataGridView1.DataSource = transitionTable;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
