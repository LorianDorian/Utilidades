using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilidades;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace testUtilidades
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            float[] nums = richTextBox1.Lines.Select(float.Parse).ToArray();
            float[] ordered = Colecciones.BubbleSort(nums);
            richTextBox2.Text = string.Join(Environment.NewLine, ordered);
        }

        
    }
}
