#include "Igrac.h"
#include <iostream>

using namespace std;

Igrac::Igrac(int s, int v) : beleske(v, vector<char>(s, '~')) {}

Koordinata Igrac::zatraziPotez(int s, int v) 
{
    Koordinata k;
    int pokušaji = 0;
    do {
        if (trenutna == 1) k = s1.generisiPotez(s, v);
        else if (trenutna == 2) k = s2.generisiPotez(s, v);
        else k = s3.generisiPotez(s, v);

        pokušaji++;
        if (pokušaji > 100) trenutna = 1; // Sigurnosni ventil

    } while (k.x < 0 || k.x >= s || k.y < 0 || k.y >= v || beleske[k.y][k.x] != '~');

    return k;
}

void Igrac::zabeleziIshod(Koordinata k, RezultatGadjanja rez) 
{
    if (k.x >= 0 && k.x < 10 && k.y >= 0 && k.y < 10) 
    {
        beleske[k.y][k.x] = (rez != RezultatGadjanja::PROMASAJ) ? 'X' : '.';
    }

    if (trenutna == 1) 
    {
        s1.obradiIshod(rez);
        if (s1.jeCiljOstvaren()) { p1 = k; s2.inicijalizuj(p1); trenutna = 2; }
    }
    else if (trenutna == 2) 
    {
        s2.obradiIshod(rez);
        if (s2.jeCiljOstvaren()) { p2 = k; s3.inicijalizuj(p1, p2); trenutna = 3; }
        else {
            // Ako je Strategija 2 iscrpela okolinu bez uspeha, vrati na nasumicnu
        }
    }
    else if (trenutna == 3) 
    {
        s3.obradiIshod(rez);
        if (s3.jeCiljOstvaren()) { trenutna = 1; }
    }
}

void Igrac::prikaziBeleske() const 
{
    cout << "\n   0 1 2 3 4 5 6 7 8 9" << endl;
    for (int y = 0; y < (int)beleske.size(); y++) {
        cout << y << "  ";
        for (int x = 0; x < (int)beleske[y].size(); x++) {
            cout << beleske[y][x] << " ";
        }
        cout << std::endl;
    }
}