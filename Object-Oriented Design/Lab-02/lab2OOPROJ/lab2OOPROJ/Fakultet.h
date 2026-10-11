#include <string>
using namespace std;

class Odsek;
class Student;

class Fakultet
{
private:
    string naziv;
    string datumOsnivanja;
    static Fakultet* instance;
    Fakultet(string n, string d);
    
public:
    static Fakultet* getInstance(string n = "ELFAK", string d = "1960");
    void upisiStudenta(Student* s, Odsek* o);
    void ispisi();

    ~Fakultet();
};
