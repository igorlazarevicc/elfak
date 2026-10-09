#pragma once
#define ISPIT_H

#include <string>

// Unapred deklaracije klasa
class Student;
class Predmet;

class Ispit 
{
private:

    Predmet* predmet;   
    Student* student;   
    std::string datum;  
    std::string rok;
    int ocena;          

public:
    // Konstruktor
    Ispit(Predmet* p, Student* s, const std::string r, const std::string& d, int oc);
    ~Ispit();

    // Getteri
    Predmet* getPredmet() const;
    Student* getStudent() const;
    std::string getDatum() const;
    //int getOcena() const;
    void Ispisi();
};
