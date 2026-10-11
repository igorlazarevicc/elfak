#pragma once
#include "Konstante.h"
#include <vector>
#include <string>

using namespace std;

class More 
{
    int sirina, visina;
    vector<vector<TipPolja>> mapa; // "matrica", tj vektor vektora 

public:
    More(int s, int v);
    void ucitajOstrvaIzFajla(string putanja);
    TipPolja proveriPolje(int x, int y) const;
};