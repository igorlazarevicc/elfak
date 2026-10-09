#include "Brod.h"
#include <algorithm>

using namespace std;


Brod::Brod(std::vector<Koordinata> k) : polja(k) 
{
    pogodjena.assign(polja.size(), false);
}
bool Brod::zauzimaPolje(int x, int y) const 
{
    for (const auto& k : polja) if (k.x == x && k.y == y) return true;
    return false;
}
RezultatGadjanja Brod::primiUdarac(int x, int y)
{
    for (size_t i = 0; i < polja.size(); ++i) {
        if (polja[i].x == x && polja[i].y == y) {
            pogodjena[i] = true;
            return jePotopljen() ? RezultatGadjanja::POTOPLJEN : RezultatGadjanja::POGODAK;
        }
    }
    return RezultatGadjanja::PROMASAJ;
}
bool Brod::jePotopljen() const 
{
    return std::all_of(pogodjena.begin(), pogodjena.end(), [](bool b) { return b; });
}