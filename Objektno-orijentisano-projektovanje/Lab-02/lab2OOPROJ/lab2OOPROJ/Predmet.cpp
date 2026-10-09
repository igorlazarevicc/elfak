#include "Predmet.h"

Predmet::Predmet(string n, int e) : naziv(n), espb(e) {}
string Predmet::getNaziv() const { return naziv; }
int Predmet::getESPB() const { return espb; }
Predmet::~Predmet() {}