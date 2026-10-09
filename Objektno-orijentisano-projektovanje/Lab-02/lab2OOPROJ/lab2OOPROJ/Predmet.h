#include <string>

using namespace std;

class Predmet
{
private:
    string naziv;
    int espb;

public:
    Predmet(string n, int e);

    string getNaziv() const;
    int getESPB() const;

    ~Predmet();
};

