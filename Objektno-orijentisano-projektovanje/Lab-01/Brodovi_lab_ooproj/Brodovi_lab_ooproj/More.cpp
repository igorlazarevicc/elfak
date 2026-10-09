#include "More.h"
#include <fstream>

using namespace std;


More::More(int s, int v) : sirina(s), visina(v), mapa(v, std::vector<TipPolja>(s, TipPolja::VODA)) {}

void More::ucitajOstrvaIzFajla(string putanja) 
{
    ifstream f(putanja);
    int val;
    for (int y = 0; y < visina; y++) 
    {
        for (int x = 0; x < sirina; x++) 
        {
            if (f >> val && val == 1) mapa[y][x] = TipPolja::OSTRVO;
        }
    }
}
TipPolja More::proveriPolje(int x, int y) const 
{
    if (x < 0 || x >= sirina || y < 0 || y >= visina) return TipPolja::OSTRVO;
    return mapa[y][x];
}