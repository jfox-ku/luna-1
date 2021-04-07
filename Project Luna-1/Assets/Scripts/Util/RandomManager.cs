using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RandomManager 
{

    public static int Dice9Roll() {
        int rand = Random.Range(1,10);
        return rand;

    }

    public static int MappedRoll() {
        return Mapping(Dice9Roll());
    }

    public static int Mapping(int k) {
        switch (k) {
            case 1: return 0;
            case 2: return 1;
            case 3: return 1;
            case 4: return 2;
            case 5: return 2;
            case 6: return 2;
            case 7: return 3;
            case 8: return 3;
            case 9: return 4;

        }
        return 0;
    }
}
