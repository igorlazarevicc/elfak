#include "Ispit.h"
#include "Student.h"
#include "Predmet.h"
#include <iostream>

// Konstruktor sa inicijalizacijom clanova i validacijom ocene
Ispit::Ispit(Predmet* p, Student* s, const std::string r, const std::string& d, int oc): predmet(p), student(s), datum(d), rok(r)
{
    if (oc >= 5 && oc <= 10)
    {
        ocena = oc;
    }
    else 
    {
        ocena = 5; 
    }
}

Ispit::~Ispit()
{
	std::cout << "Destruktor: Ispit iz predmeta '" << predmet->getNaziv() << "' je uklonjen iz evidencije." << std::endl;
}

// Getteri
Predmet* Ispit::getPredmet() const { return predmet; }
Student* Ispit::getStudent() const { return student; }
std::string Ispit::getDatum() const { return datum; }
//int Ispit::getOcena() const { return ocena; }


void Ispit::Ispisi()
{
    if (predmet != nullptr) 
    {
        std::cout << "Predmet: " << predmet->getNaziv() << std::endl;
    }
    else 
    {
        std::cout << "Predmet: Podatak nije dostupan!" << std::endl;
    }

    std::cout << "Datum polaganja: " << datum << std::endl;
    std::cout << "Ocena: " << ocena << std::endl;

    
    std::cout << "Status: " << (ocena > 5 ? "POLOZIO" : "PAO") << std::endl;
    std::cout << "========================================" << std::endl;
}