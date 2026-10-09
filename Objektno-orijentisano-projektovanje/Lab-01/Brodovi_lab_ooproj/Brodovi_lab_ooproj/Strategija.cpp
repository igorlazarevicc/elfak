#include "Strategija.h"
#include <cstdlib>

// Strategija 1 - Nasumicna
Koordinata Strategija1::generisiPotez(int s, int v) 
{
    return Koordinata{ rand() % s, rand() % v };
}
void Strategija1::obradiIshod(RezultatGadjanja rez) 
{
    if (rez != RezultatGadjanja::PROMASAJ) ostvarenCilj = true;
}

// Strategija 2 - Okolina
void Strategija2::inicijalizuj(Koordinata k) 
{
    baza = k;       
    smer = 0;
    reset();
}

Koordinata Strategija2::generisiPotez(int s, int v) {
    Koordinata k = baza;
    if (smer == 0) k.x--;
    else if (smer == 1) k.y--;
    else if (smer == 2) k.x++;
    else k.y++;

    // Provera da ne izadje van matrice (0-9)
    if (k.x < 0) k.x = 0; 
    if (k.x >= s) k.x = s - 1;
    if (k.y < 0) k.y = 0; 
    if (k.y >= v) k.y = v - 1;

    return k;
}
void Strategija2::obradiIshod(RezultatGadjanja rez) 
{
    if (rez != RezultatGadjanja::PROMASAJ) ostvarenCilj = true;
    else smer = (smer + 1) % 4; // Ako promasi, rotiraj smer
}

// Strategija 3 - Potapanje
void Strategija3::inicijalizuj(Koordinata a, Koordinata b) 
{
    k1 = a; 
    k2 = b;
    reset();
}
Koordinata Strategija3::generisiPotez(int s, int v) 
{
    Koordinata k;
    if (k1.y == k2.y) 
    {
        int max_x = (k1.x > k2.x) ? k1.x : k2.x;
        k = Koordinata{ max_x + 1, k1.y };
    }
    else 
    {
        int max_y = (k1.y > k2.y) ? k1.y : k2.y;
        k = Koordinata{ k1.x, max_y + 1 };
    }

    // Provera granica
    if (k.x >= s) k.x = s - 1;
    if (k.y >= v) k.y = v - 1;
    return k;
}
void Strategija3::obradiIshod(RezultatGadjanja rez) 
{
    if (rez == RezultatGadjanja::POTOPLJEN) ostvarenCilj = true;
}