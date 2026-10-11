#include "Student.h"
#include "Predmet.h"
#include "Odsek.h"
#include <iostream>

using namespace std;

Student::Student(string bi, string j, string du, Odsek* o) : brojIndeksa(bi), jmbg(j), datumUpisa(du), odsek(o) {}

void Student::dodajPredmet(Predmet* p)
{
	predmeti.push_back(p);
}

void Student::ukloniPredmet(string naziv)
{
	for (auto it = predmeti.begin(); it != predmeti.end(); ++it)
	{
		if ((*it)->getNaziv() == naziv)
		{
			predmeti.erase(it);
			break;
		}
	}
}

int Student::ukupnoESPB() const
{
	int suma = 0;
	for (auto p : predmeti) 
	{
		suma += p->getESPB();
	}
	return suma;
}

void Student::ispisi() const
{
	cout << "Student " << brojIndeksa << " ESPB: " << ukupnoESPB() << endl;
}

Student::~Student() {}

string Student::getIndeks() const
{
	return brojIndeksa;
}