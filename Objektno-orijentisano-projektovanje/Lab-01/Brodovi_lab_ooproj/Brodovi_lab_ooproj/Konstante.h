#pragma once

enum class TipPolja { VODA, OSTRVO, BROD };
enum class RezultatGadjanja { PROMASAJ, POGODAK, POTOPLJEN };

struct Koordinata {
    int x, y;
    bool operator==(const Koordinata& other) const { return x == other.x && y == other.y; }
};