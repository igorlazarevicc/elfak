#pragma once
#include "Konstante.h"
#include "Strategija.h"
#include <vector>

class Igrac {
private:
    std::vector<std::vector<char>> beleske;
    Strategija1 s1;
    Strategija2 s2;
    Strategija3 s3;
    int trenutna = 1;
    Koordinata p1, p2;

public:
    Igrac(int s, int v);
    Koordinata zatraziPotez(int s, int v);
    void zabeleziIshod(Koordinata k, RezultatGadjanja rez);

    
    void prikaziBeleske() const;
};