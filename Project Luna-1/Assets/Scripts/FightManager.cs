using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    //Placeholder for testing
    public FighterScript P_Luna;
    public FighterScript P_Belua;
    private Fight currentFight;

    private static FightManager p_instance;
    public FightManager Instance {
        get {
            if (p_instance == null) {
                p_instance = FindObjectOfType<FightManager>();
            }
            return p_instance;
        }

    }

    private void Start() {
        currentFight = new Fight(P_Luna,P_Belua);
        currentFight.StartFight();

    }




    //Just 2 fighters for now
    public class Fight {
        private FighterScript P_Luna;
        private FighterScript P_Belua;

        public Fight(FighterScript player, FighterScript enemy) {
            P_Luna = player;
            P_Belua = enemy;

        }

        public void StartFight() {
            P_Luna.StartAttack();
            P_Belua.StartAttack();
        }


    }



    
}
