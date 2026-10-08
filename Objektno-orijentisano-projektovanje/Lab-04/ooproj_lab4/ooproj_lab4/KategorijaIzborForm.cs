using System;
using System.Windows.Forms;

namespace ooproj_lab4
{
    public partial class KategorijaIzborForm : Form
    {
        public string IzabranaKategorija { get; set; }

        public KategorijaIzborForm()
        {
            InitializeComponent();
        }

        private void KategorijaIzborForm_Load(object sender, EventArgs e)
        {
            comboKategorija.Items.Clear();

            comboKategorija.Items.Add("A");
            comboKategorija.Items.Add("B");
            comboKategorija.Items.Add("C");
            comboKategorija.Items.Add("D");
            comboKategorija.Items.Add("BE");
            comboKategorija.Items.Add("CE");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboKategorija.SelectedItem == null)
            {
                MessageBox.Show("Izaberi kategoriju.");
                return;
            }

            IzabranaKategorija = comboKategorija.SelectedItem.ToString();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}