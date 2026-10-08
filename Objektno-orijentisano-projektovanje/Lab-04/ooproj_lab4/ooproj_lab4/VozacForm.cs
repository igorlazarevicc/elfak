using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ooproj_lab4
{
    public partial class VozacForm : Form
    {
        private string putanjaSlike = "";
        private Vozac trenutniVozac = null;
        private bool izmena = false;

        public VozacForm()
        {
            InitializeComponent();

            trenutniVozac = new Vozac();

            if (trenutniVozac.Kategorije == null)
                trenutniVozac.Kategorije = new List<Kategorija>();

            if (trenutniVozac.Zabrane == null)
                trenutniVozac.Zabrane = new List<Zabrana>();
        }

        public VozacForm(Vozac v)
        {
            InitializeComponent();

            trenutniVozac = v;
            izmena = true;

            txtIme.Text = v.Ime;
            txtPrezime.Text = v.Prezime;
            txtBrojDozvole.Text = v.BrojDozvole;
            txtMestoIzdavanja.Text = v.MestoIzdavanja;

            datumRodjenjaPicker.Value = v.DatumRodjenja;
            dozvolaOdpicker.Value = v.DozvolaOd;
            dozvolaDoPicker.Value = v.DozvolaDo;

            putanjaSlike = v.Slika;

            if (!string.IsNullOrEmpty(v.Slika))
                pictureBox1.Image = Image.FromFile(v.Slika);
        }

        private void VozacForm_Load(object sender, EventArgs e)
        {
  
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            dataKategorija.DataSource = null;
            dataKategorija.DataSource = trenutniVozac.Kategorije;

            dataZabrana.DataSource = null;
            dataZabrana.DataSource = trenutniVozac.Zabrane;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (txtIme.Text == "" ||
                txtPrezime.Text == "" ||
                txtBrojDozvole.Text == "" ||
                txtMestoIzdavanja.Text == "" ||
                putanjaSlike == "")
            {
                MessageBox.Show("Morate popuniti sva polja.");
                return;
            }

            if (!izmena)
            {
                Vozac v = new Vozac();

                v.Ime = txtIme.Text;
                v.Prezime = txtPrezime.Text;
                v.BrojDozvole = txtBrojDozvole.Text;
                v.DatumRodjenja = datumRodjenjaPicker.Value;
                v.MestoIzdavanja = txtMestoIzdavanja.Text;
                v.Slika = putanjaSlike;
                v.DozvolaOd = dozvolaOdpicker.Value;
                v.DozvolaDo = dozvolaDoPicker.Value;

                Baza.Vozaci.Add(v);
            }
            else
            {
                trenutniVozac.Ime = txtIme.Text;
                trenutniVozac.Prezime = txtPrezime.Text;
                trenutniVozac.BrojDozvole = txtBrojDozvole.Text;
                trenutniVozac.DatumRodjenja = datumRodjenjaPicker.Value;
                trenutniVozac.MestoIzdavanja = txtMestoIzdavanja.Text;
                trenutniVozac.DozvolaOd = dozvolaOdpicker.Value;
                trenutniVozac.DozvolaDo = dozvolaDoPicker.Value;
                trenutniVozac.Slika = putanjaSlike;
            }

            MessageBox.Show("Vozač uspešno sačuvan.");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                putanjaSlike = ofd.FileName;
                pictureBox1.Image = Image.FromFile(putanjaSlike);

                MessageBox.Show("Slika dodata.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KategorijaForm f = new KategorijaForm();

            if (f.ShowDialog() == DialogResult.OK)
            {
                trenutniVozac.Kategorije.Add(f.NovaKategorija);

                dataKategorija.DataSource = null;
                dataKategorija.DataSource = trenutniVozac.Kategorije;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataKategorija.CurrentRow == null) return;

            Kategorija k = (Kategorija)dataKategorija.CurrentRow.DataBoundItem;

            trenutniVozac.Kategorije.Remove(k);

            dataKategorija.DataSource = null;
            dataKategorija.DataSource = trenutniVozac.Kategorije;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ZabranaForm f = new ZabranaForm(trenutniVozac);

            if (f.ShowDialog() == DialogResult.OK)
            {
                if (trenutniVozac.Zabrane == null)
                    trenutniVozac.Zabrane = new List<Zabrana>();

                trenutniVozac.Zabrane.Add(f.NovaZabrana);

                dataZabrana.DataSource = null;
                dataZabrana.DataSource = trenutniVozac.Zabrane;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataZabrana.CurrentRow == null)
                return;

            Zabrana z = (Zabrana)dataZabrana.CurrentRow.DataBoundItem;

            trenutniVozac.Zabrane.Remove(z);

            dataZabrana.DataSource = null;
            dataZabrana.DataSource = trenutniVozac.Zabrane;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VozacForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show(
                "Da li želite da zatvorite aplikaciju?",
                "Potvrda",
                MessageBoxButtons.YesNo);

            if (r == DialogResult.No)
                e.Cancel = true;
        }

        private void txtIme_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtIme_TextChanged(object sender, EventArgs e)
        {

        }
    }
}