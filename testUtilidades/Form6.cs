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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool Validated = Datos.ValidateUrl(textBox1.Text);
            if (Validated)
            {
                label3.Text = "La URL es valida";
            }
            else
            {
                label3.Text = "URL invalida";
            }
        }
    }
}
