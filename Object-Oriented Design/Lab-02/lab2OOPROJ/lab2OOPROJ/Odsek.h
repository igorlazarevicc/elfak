#include <string>
#include <vector>
using namespace std;

class Student;
class Fakultet;

class Odsek
{
private:
    string naziv;
    vector<Student*> studenti;
    Fakultet* fakultet;

public:
    Odsek(string n, Fakultet* f);
    void dodajStudenta(Student* s);
    ~Odsek();
};
