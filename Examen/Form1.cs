using System.Data;
using System.Data.SqlClient;

namespace Examen
{
    public partial class Form1 : Form
    {

        // No puedo hacerlo con localhost ya que tuve que hacer 2 instancias de SQL Server, por eso tengo que usar DAM2-de24f4\\MSSQLSERVER2
        private string stringConexion = "Server=DAM2-de24f4\\MSSQLSERVER2;Database=Examen;Trusted_Connection=True;";
        DataTable dt = new DataTable();
        private int indice = 0;
        public Form1()
        {
            InitializeComponent();
            Estilos estilo = new Estilos(this.dgvPage1);
            estilo.formatoCelda();
            estilo.formatoFilasAlternas();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conexion();
        }

        private void conexion()
        {
            string sql = "SELECT * FROM Clientes";
            SqlConnection cnx = new SqlConnection(stringConexion);
            try
            {
                cnx.Open();
                SqlCommand command = new SqlCommand(sql, cnx);
                SqlDataReader dataReader = command.ExecuteReader();
                dt.Load(dataReader);
                this.dgvPage1.DataSource = dt;
                this.dgvPage3.DataSource = dt;
                this.dgvPage4.DataSource = dt;
                command.Dispose();
                cnx.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show("No se puede realizar la conexion");
            }
        }

        private void page3()
        {
            if (this.tabControl1.SelectedIndex == 1)
            {
                this.textBox1.Text = this.dgvPage3.CurrentRow.Cells[0].Value.ToString();
                this.textBox2.Text = this.dgvPage3.CurrentRow.Cells[1].Value.ToString();
                this.textBox3.Text = this.dgvPage3.CurrentRow.Cells[2].Value.ToString();
                this.textBox4.Text = this.dgvPage3.CurrentRow.Cells[3].Value.ToString();
                this.textBox5.Text = this.dgvPage3.CurrentRow.Cells[4].Value.ToString();
                this.textBox6.Text = this.dgvPage3.CurrentRow.Cells[5].Value.ToString();
                this.textBox7.Text = this.dgvPage3.CurrentRow.Cells[6].Value.ToString();
                this.textBox8.Text = this.dgvPage3.CurrentRow.Cells[7].Value.ToString();
                this.textBox9.Text = this.dgvPage3.CurrentRow.Cells[8].Value.ToString();
                this.textBox10.Text = this.dgvPage3.CurrentRow.Cells[9].Value.ToString();
            }
        }

        private void page4()
        {
            rellenarComboBox();
        }

        private void rellenarComboBox()
        {
            List<string> list = new List<string>();

            for (int i = 0; i < this.dgvPage1.RowCount - 2; i++)
            {
                string valor = this.dgvPage4[6, i].Value.ToString();

                if (!list.Contains(valor))
                {
                    list.Add(valor);
                }
            }

            foreach (string valor in list)
            {
                this.comboBox1.Items.Add(valor);
            }
        }

        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvPage1.Columns[e.ColumnIndex].Name == "Baja")
            {
                if (e.Value != null)
                {
                    if (e.Value.ToString().Equals("False"))
                    {
                        e.CellStyle.BackColor = Color.Red;
                    }
                }
            }
        }

        private void dgv_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewCellCollection datosFila = dgvPage1.CurrentRow.Cells;

            Form2 fm = new Form2(ref datosFila);

            fm.Show();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            page3();
            page4();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            indice = 0;
            this.dgvPage3.CurrentCell = this.dgvPage3[0, indice];
            page3();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (indice > 0)
            {
                indice--;
                this.dgvPage3.CurrentCell = this.dgvPage3[0, indice];
                page3();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (indice < this.dgvPage3.RowCount - 2)
            {
                indice++;
                this.dgvPage3.CurrentCell = this.dgvPage3[0, indice];
                page3();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            indice = this.dgvPage3.RowCount - 2;
            this.dgvPage3.CurrentCell = this.dgvPage3[0, indice];
            page3();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox1.Text != null)
            {
                string filtro = string.Format("convert([{0}], System.String) LIKE '{1}%'", "Poblacion", this.comboBox1.Text.Trim());
                dt.DefaultView.RowFilter = filtro;
                this.dgvPage4.DataSource = dt;
            }
        }
    }
}
