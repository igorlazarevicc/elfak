using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ooproj_lab4
{
    public partial class Form1 : Form
    {

        delegate object Kriterijum(Vozac v);
        public Form1()
        {
            InitializeComponent();
        }

        private void OsveziGrid()
        {
            dataGridView1.DataSource = null;

            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;

            dataGridView1.DataSource = Baza.Vozaci;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VozacForm f = new VozacForm();
            f.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();

            f.FormClosed += (s, args) =>
            {
                this.Show();
                OsveziGrid(); // "Load”
            };

            f.Show();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Baza.Vozaci;

            timer1.Interval = 1000;
            timer1.Start();

            if (dataGridView1.Columns["DatumRodjenja"] != null)
                dataGridView1.Columns["DatumRodjenja"].DefaultCellStyle.Format = "dd.MM.yyyy";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Izaberi vozača.");
                return;
            }

            Vozac v = (Vozac)dataGridView1.CurrentRow.DataBoundItem;

            VozacForm f = new VozacForm(v);

            if (f.ShowDialog() == DialogResult.OK)
            {
                OsveziGrid();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Izaberi vozača.");
                return;
            }

            Vozac v = (Vozac)dataGridView1.CurrentRow.DataBoundItem;

            Baza.Vozaci.Remove(v);

            OsveziGrid();

            MessageBox.Show("Vozač obrisan.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Kriterijum k = null;

            if (comboBox1.Text == "Ime")
                k = v => v.Ime;

            else if (comboBox1.Text == "Prezime")
                k = v => v.Prezime;

            else if (comboBox1.Text == "Br. dozvole")
                k = v => v.BrojDozvole;

            Baza.Vozaci = Baza.Vozaci.OrderBy(v => k(v)).ToList();

            OsveziGrid();

            MessageBox.Show("Sortiranje završeno.");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show(
    "Da li želite da zatvorite aplikaciju?",
    "Potvrda",
    MessageBoxButtons.YesNo);

            if (r == DialogResult.No)
                e.Cancel = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("HH:mm:ss dd.MM.yyyy");
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null) return;
            if (dataGridView1.Rows.Count == 0) return;
            if (dataGridView1.CurrentRow == null) return;
            if (dataGridView1.CurrentRow.Index < 0) return;
        }
    }
}
