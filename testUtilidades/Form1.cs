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

namespace testUtilidades
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 FormArchivos = new Form2();
            FormArchivos.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 FormColecciones = new Form3();
            FormColecciones.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 FormCadenas = new Form4();
            FormCadenas.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 FormConversionTipos = new Form5();
            FormConversionTipos.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form6 FormDatos = new Form6();
            FormDatos.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form7 FormFechas = new Form7();
            FormFechas.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form8 FormHash = new Form8();
            FormHash.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form9 FormMate = new Form9();
            FormMate.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form10 FormNumAleatorios = new Form10();
            FormNumAleatorios.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form10 FormObjetos = new Form10();
            FormObjetos.ShowDialog();
        }
    }
}
