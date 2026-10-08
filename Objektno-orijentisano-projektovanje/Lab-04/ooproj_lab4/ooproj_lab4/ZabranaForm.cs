using System;
using System.Windows.Forms;

namespace ooproj_lab4
{
    public partial class ZabranaForm : Form
    {
        public Zabrana NovaZabrana { get; set; }

        private Vozac trenutniVozac;
        private string izabranaKategorija = "";

        public ZabranaForm(Vozac v)
        {
            InitializeComponent();
            trenutniVozac = v;
        }

        private void ZabranaForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (izabranaKategorija == "")
            {
                MessageBox.Show("Izaberite kategoriju.");
                return;
            }

            if (dateTimePicker1.Value > dateTimePicker2.Value)
            {
                MessageBox.Show("Neispravan period.");
                return;
            }

            Zabrana z = new Zabrana();

            z.Kategorija = izabranaKategorija;
            z.Od = dateTimePicker1.Value;
            z.Do = dateTimePicker2.Value;

            NovaZabrana = z;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            KategorijaIzborForm izbor = new KategorijaIzborForm();

            if (izbor.ShowDialog() == DialogResult.OK)
            {
                izabranaKategorija = izbor.IzabranaKategorija;

                MessageBox.Show("Izabrana kategorija: " + izabranaKategorija);
            }
        }

        private void ZabranaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show(
                "Zatvaranje forme?",
                "Potvrda",
                MessageBoxButtons.YesNo);

            if (r == DialogResult.No)
                e.Cancel = true;
        }
    }
}