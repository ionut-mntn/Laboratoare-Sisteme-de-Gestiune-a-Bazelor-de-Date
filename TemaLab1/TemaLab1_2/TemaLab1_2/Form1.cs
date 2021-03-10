using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemaLab1_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            insertButton.Enabled = false;
            updateButton.Enabled = false;
            deleteButton.Enabled = false;
        }

        // am redenumit butoanele dupa ce am generat event-urile.. de asta numele astea sunt ambiguue

        private void button1_Click(object sender, EventArgs e)  // insertButton
        {

        }

        private void button2_Click(object sender, EventArgs e)  // deleteButton
        {

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {

        }

        /*
        private void button1_Click_1(object sender, EventArgs e)
        {

        }
        */
    }
}
