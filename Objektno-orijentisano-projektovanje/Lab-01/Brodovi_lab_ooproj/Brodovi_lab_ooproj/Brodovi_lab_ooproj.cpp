#include "More.h"
#include "Brod.h"
#include "Igrac.h"
#include <iostream>
#include <vector>
#include <ctime>
#include <fstream>
using namespace std;

// Funkcija za krajnji prikaz stvarnog stanja 
void prikaziStvarnoStanje(const More& m, const vector<Brod>& b) {
    cout << "\nKRAJ IGRE! STVARNI IZGLED MORA I BRODOVA:\n";
    for (int y = 0; y < 10; y++) {
        cout << y << "  ";
        for (int x = 0; x < 10; x++) {
            bool jeBrod = false;
            for (const auto& br : b) {
                if (br.zauzimaPolje(x, y)) jeBrod = true;
            }

            if (m.proveriPolje(x, y) == TipPolja::OSTRVO) cout << "0 ";
            else if (jeBrod) cout << "B ";
            else cout << "~ ";
        }
        cout << "\n";
    }
}

int main() 
{
    srand((unsigned int)time(NULL));

    // Ucitavanje mora 
    More more(10, 10);
    more.ucitajOstrvaIzFajla("more.txt");

    // Ucitavanje svih 6 brodova iz fajla [cite: 16]
    vector<Brod> brodovi;
    ifstream f("brodovi.txt");
    int duzina, x, y;
    while (f >> duzina) 
    {
        vector<Koordinata> k;
        for (int i = 0; i < duzina; i++) 
        {
            if (f >> x >> y) k.push_back(Koordinata{ x, y });
        }
        brodovi.push_back(Brod(k));
    }
    f.close();

    Igrac igrac(10, 10);
    size_t potopljeni = 0;

    // Igra traje dok se ne potopi svih 6 brodova
    while (potopljeni < brodovi.size()) 
    {
        Koordinata p = igrac.zatraziPotez(10, 10);

        // Ako udari u ostrvo, to je automatski promasaj za igraca 
        if (more.proveriPolje(p.x, p.y) == TipPolja::OSTRVO) {
            igrac.zabeleziIshod(p, RezultatGadjanja::PROMASAJ);
            continue;
        }

        RezultatGadjanja rez = RezultatGadjanja::PROMASAJ;
        for (auto& b : brodovi) 
        {
            rez = b.primiUdarac(p.x, p.y);
            if (rez == RezultatGadjanja::POTOPLJEN)  potopljeni++;
            if (rez != RezultatGadjanja::PROMASAJ) break;
        }

        igrac.zabeleziIshod(p, rez);

        // Ispis nakon svakog poteza 
        cout << "\nPotez: (" << p.x << "," << p.y << ") - Potopljeno: "
            << potopljeni << "/" << brodovi.size() << "\n";
        igrac.prikaziBeleske();
    }

    prikaziStvarnoStanje(more, brodovi); 
    
    return 0;
}