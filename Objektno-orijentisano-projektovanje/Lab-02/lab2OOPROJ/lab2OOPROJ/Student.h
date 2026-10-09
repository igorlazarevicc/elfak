#include <string>
#include <vector>
using namespace std;

class Odsek;
class Predmet;

class Student
{
private:
    string brojIndeksa;
    string jmbg;
    string datumUpisa;
    Odsek* odsek;
    vector<Predmet*> predmeti;

public:
    Student(string bi, string j, string du, Odsek* o);

    void dodajPredmet(Predmet* p);
    void ukloniPredmet(string naziv);
    int ukupnoESPB() const;
    string getIndeks() const;
    void ispisi() const;

    ~Student();
};

