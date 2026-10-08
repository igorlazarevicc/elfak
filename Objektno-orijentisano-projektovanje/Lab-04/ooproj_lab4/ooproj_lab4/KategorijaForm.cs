using System;
using System.Windows.Forms;

namespace ooproj_lab4
{
    public partial class KategorijaForm : Form
    {
        public Kategorija NovaKategorija { get; set; }

        private string izabranaKategorija = "";

        public KategorijaForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            KategorijaIzborForm izbor = new KategorijaIzborForm();

            if (izbor.ShowDialog() == DialogResult.OK)
            {
                izabranaKategorija = izbor.IzabranaKategorija;
                MessageBox.Show("Izabrano: " + izabranaKategorija);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(izabranaKategorija))
            {
                MessageBox.Show("Izaberi kategoriju!");
                return;
            }

            if (dateTimePicker1.Value > dateTimePicker2.Value)
            {
                MessageBox.Show("Pogrešan datum.");
                return;
            }

            NovaKategorija = new Kategorija
            {
                Naziv = izabranaKategorija,
                DatumOd = dateTimePicker1.Value,
                DatumDo = dateTimePicker2.Value
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}