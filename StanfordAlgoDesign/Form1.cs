using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StanfordAlgoDesign
{
    public partial class Form1 : Form
    {
        MergeSort mergeSort;
        public Form1()
        {
            InitializeComponent();
            mergeSort = new MergeSort(this);
        }

        private void run_Click(object sender, EventArgs e)
        {
            mergeSort.run(inputBox.Text);
        }
    }
}
