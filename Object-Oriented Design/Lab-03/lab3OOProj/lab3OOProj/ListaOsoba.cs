using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace lab3OOProj
{
    class ListaOsoba
    {
        private static ListaOsoba instance;
        public BindingList<Osoba> Osobe { get; set; }
        private ListaOsoba()
        {
            Osobe = new BindingList<Osoba>();
        }

        public static ListaOsoba Instance
        {
            get
            {
                if (instance == null)
                    instance = new ListaOsoba();

                return instance;
            }
        }

        public void SortirajPoImenu()
        {
            var sortirano = Osobe.OrderBy(x => x.ime).ToList();
            OsveziListu(sortirano);
        }

        public void SortirajPoPrezimenu()
        {
            var sortirano = Osobe.OrderBy(x => x.prezime).ToList();
            OsveziListu(sortirano);
        }

        public void SortirajPoDatumu()
        {
            var sortirano = Osobe.OrderBy(x => x.datumRodjenja).ToList();
            OsveziListu(sortirano);
        }

        private void OsveziListu(List<Osoba> novaLista)
        {
            Osobe.Clear();
            foreach (var osoba in novaLista)
            {
                Osobe.Add(osoba);
            }
        }
    }
}
