using System;
using System.Collections.Generic;
using System.Text;

namespace lab3OOProj
{
    public class Osoba
    {
        public string ime { get; set; }
        public string prezime { get; set; }
        public string telefon { get; set; }
        public string adresaStanovanja { get; set; }
        public DateTime datumRodjenja { get; set; }

        public override string ToString()
        {
            return $"Ime: {ime};  Prezime: {prezime};  Telefon: {telefon};  Datum: { datumRodjenja.ToShortDateString()}";
        }
    }
}
