#pragma once
#include "Konstante.h"
#include <vector>
using namespace std;

class Brod 
{
    vector<Koordinata> polja;
    vector<bool> pogodjena;

public:
    Brod(vector<Koordinata> k);
    bool zauzimaPolje(int x, int y) const;
    RezultatGadjanja primiUdarac(int x, int y);
    bool jePotopljen() const;
};