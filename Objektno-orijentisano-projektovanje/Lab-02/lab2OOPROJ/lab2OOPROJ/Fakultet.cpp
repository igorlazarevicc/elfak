#include "Fakultet.h"
#include "Odsek.h"
#include "Student.h"
#include <iostream>

using namespace std;

Fakultet* Fakultet::instance = nullptr;
Fakultet::Fakultet(string n, string d) : naziv(n), datumOsnivanja(d) {}

Fakultet* Fakultet::getInstance(string n, string d)
{
	if (!instance) instance = new Fakultet(n, d);
	return instance;
}

void Fakultet::upisiStudenta(Student* s, Odsek* o)
{
	o->dodajStudenta(s);
}

void Fakultet::ispisi()
{
	cout << "Fakultet: " << naziv << endl;
}

Fakultet::~Fakultet() {}