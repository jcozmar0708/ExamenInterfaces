using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen
{
    public partial class Form2 : Form
    {
        private DataGridViewCellCollection filaTraida;

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(ref DataGridViewCellCollection fila)
        {
            InitializeComponent();

            this.textBox1.Text = fila[0].Value.ToString();
            this.textBox2.Text = fila[1].Value.ToString();
            this.textBox3.Text = fila[2].Value.ToString();
            this.textBox4.Text = fila[3].Value.ToString();
            this.textBox5.Text = fila[4].Value.ToString();
            this.textBox6.Text = fila[5].Value.ToString();
            this.textBox7.Text = fila[6].Value.ToString();
            this.textBox8.Text = fila[7].Value.ToString();
            this.textBox9.Text = fila[8].Value.ToString();
            this.textBox10.Text = fila[9].Value.ToString();

            filaTraida = fila;
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            filaTraida[0].Value = this.textBox1.Text;
            filaTraida[1].Value = this.textBox2.Text;
            filaTraida[2].Value = this.textBox3.Text;
            filaTraida[3].Value = this.textBox4.Text;
            filaTraida[4].Value = this.textBox5.Text;
            filaTraida[5].Value = this.textBox6.Text;
            filaTraida[6].Value = this.textBox7.Text;
            filaTraida[7].Value = this.textBox8.Text;
            filaTraida[8].Value = this.textBox9.Text;
            filaTraida[9].Value = this.textBox10.Text;
            this.Close();
        }
    }
}
