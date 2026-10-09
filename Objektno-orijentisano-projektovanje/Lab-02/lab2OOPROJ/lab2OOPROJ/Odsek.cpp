#include "Odsek.h"
#include "Student.h"
#include "Fakultet.h"

Odsek::Odsek(string n, Fakultet* f) : naziv(n), fakultet(f) {}
void Odsek::dodajStudenta(Student* s) { studenti.push_back(s); }
Odsek::~Odsek() {}