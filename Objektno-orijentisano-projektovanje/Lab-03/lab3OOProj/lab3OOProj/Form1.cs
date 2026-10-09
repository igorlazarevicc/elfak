using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace lab3OOProj
{
    public partial class Form1 : Form
    {

        public delegate void KriterijumSortiranja();
        private Osoba selektovanaOsoba = null;


        public Form1()
        {
            InitializeComponent();
            Text = "Lab 3";
            //dateTimePicker1.CustomFormat = "dd.MM.yyyy";
            groupBox1.Text = "Podaci o osobi";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.DataSource = ListaOsoba.Instance.Osobe;
            DodatneMetode.PopuniComBox(comboBox1);
        }

        private void SamoSlova(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            string pattern = @"^\+381 \d{2} \d{6,7}$";

            if (!Regex.IsMatch(textBox3.Text, pattern))
            {
                MessageBox.Show("Telefon mora biti u formatu:\n+381 11 5659898");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Popunite sva polja!");
                return;
            }
            
            if (selektovanaOsoba == null)
            {
                Osoba o = new Osoba();

                o.ime = textBox1.Text;
                o.prezime = textBox2.Text;
                o.telefon = textBox3.Text;
                o.datumRodjenja = dateTimePicker1.Value;
                o.adresaStanovanja = textBox4.Text;

                ListaOsoba.Instance.Osobe.Insert(0, o);
                MessageBox.Show("Osoba uspesno dodata.");
            }
            else
            {
                selektovanaOsoba.ime = textBox1.Text;
                selektovanaOsoba.prezime =textBox2.Text;
                selektovanaOsoba.telefon =textBox3.Text;
                selektovanaOsoba.adresaStanovanja =textBox4.Text;
                selektovanaOsoba.datumRodjenja =dateTimePicker1.Value;
                listBox1.DataSource = null;
                listBox1.DataSource =ListaOsoba.Instance.Osobe;

                MessageBox.Show("Podaci uspesno izmenjeni.");
                selektovanaOsoba = null;
            }

            DodatneMetode.OcistiPolja(textBox1, textBox2, textBox3, textBox4, dateTimePicker1);
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DodatneMetode.OcistiPolja(textBox1, textBox2, textBox3, textBox4, dateTimePicker1);
            MessageBox.Show("Polja su obrisana!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Izaberite osobu.");
                return;
            }

            ListaOsoba.Instance.Osobe.Remove((Osoba)listBox1.SelectedItem);
            MessageBox.Show("Osoba obrisana.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ListaOsoba.Instance.Osobe.Clear();
            MessageBox.Show("Lista obrisana.");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            KriterijumSortiranja del;

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    del = ListaOsoba.Instance.SortirajPoImenu;
                    break;
                case 1:
                    del = ListaOsoba.Instance.SortirajPoPrezimenu;
                    break;
                default:
                    del = ListaOsoba.Instance.SortirajPoDatumu;
                    break;
            }

            del();
            MessageBox.Show("Lista uspešno sortirana.");
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;

            selektovanaOsoba =(Osoba)listBox1.SelectedItem;
            textBox1.Text =selektovanaOsoba.ime;
            textBox2.Text = selektovanaOsoba.prezime;
            textBox3.Text = selektovanaOsoba.telefon;
            textBox4.Text = selektovanaOsoba.adresaStanovanja;
            dateTimePicker1.Value  = selektovanaOsoba.datumRodjenja;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rezultat = MessageBox.Show("Da li ste sigurni?", "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rezultat == DialogResult.No) e.Cancel = true;
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show(DateTime.Now.TrenutnoVreme());
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                string ime = textBox1.Text.Trim();
                textBox1.Text = char.ToUpper(ime[0]) + ime.Substring(1).ToLower();
            }
        }
    }
}
