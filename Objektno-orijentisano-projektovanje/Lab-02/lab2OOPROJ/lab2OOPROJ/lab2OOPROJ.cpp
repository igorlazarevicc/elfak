#include "Fakultet.h"
#include "Odsek.h"
#include "Student.h"
#include "Ispit.h"
#include "Predmet.h"
#include <iostream>

using namespace std;

int main()
{
    Fakultet* f = Fakultet::getInstance("ELFAK", "1962");
    Odsek o1("ISIT", f);
    Student s1("123/21", "1111111111111", "2021-10-01", &o1);
    Predmet p1("Matematika",6);
    Predmet p2("Programiranje", 8);
    
    s1.dodajPredmet(&p1);
    s1.dodajPredmet(&p2);

    o1.dodajStudenta(&s1);
    s1.ispisi();

    cout << "Ukupno ESPB: " << s1.ukupnoESPB() << endl;
    cout << endl;
    cout << endl;

    Ispit i(&p2, &s1,"Junski", "20.05.2026.", 7);
    i.Ispisi();
    std::cout << endl;
    std::cout << endl;
    return 0;
}