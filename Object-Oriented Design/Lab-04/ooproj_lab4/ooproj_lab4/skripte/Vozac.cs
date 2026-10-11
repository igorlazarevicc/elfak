using System;
using System.Collections.Generic;

namespace ooproj_lab4
{
    public class Vozac
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojDozvole { get; set; }
        public string MestoIzdavanja { get; set; }
        public DateTime DatumRodjenja { get; set; }

        public DateTime DozvolaOd { get; set; }
        public DateTime DozvolaDo { get; set; }

        public string Slika { get; set; }

        public List<Kategorija> Kategorije { get; set; }
        public List<Zabrana> Zabrane { get; set; }

        public Vozac()
        {
            Kategorije = new List<Kategorija>();
            Zabrane = new List<Zabrana>();
        }
    }
}