#pragma once
#include "Konstante.h"

class Strategija 
{
protected:
    bool ostvarenCilj = false;

public:
    virtual ~Strategija() {}
    virtual Koordinata generisiPotez(int s, int v) = 0;
    virtual void obradiIshod(RezultatGadjanja rez) = 0;
    bool jeCiljOstvaren() const { return ostvarenCilj; }
    virtual void reset() { ostvarenCilj = false; }
};

class Strategija1 : public Strategija 
{
public:
    Koordinata generisiPotez(int s, int v) override;
    void obradiIshod(RezultatGadjanja rez) override;
};

class Strategija2 : public Strategija 
{
    Koordinata baza;
    int smer = 0;
public:
    void inicijalizuj(Koordinata k);
    Koordinata generisiPotez(int s, int v) override;
    void obradiIshod(RezultatGadjanja rez) override;
};

class Strategija3 : public Strategija 
{
    Koordinata k1, k2;
public:
    void inicijalizuj(Koordinata a, Koordinata b);
    Koordinata generisiPotez(int s, int v) override;
    void obradiIshod(RezultatGadjanja rez) override;
};