using UnityEngine;
using UnityEngine.Serialization;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Combat : MonoBehaviour
{

    public void InitiateCombat()
    {
        SceneManager.LoadSceneAsync("FightScene", LoadSceneMode.Single); //SWITCH TO FIGHT SCENE
            //SET STATS FOR THE FIGHT
            //INITIALIZE ENEMIES AND THE PLAYER
            //ISLAND DECIDES WHAT ENEMIES THERE ARE.
            //Player.CreatePlayer();
        CombatRound(); //INITIATE COMBAT
        
        
    }
    
    public void CombatRound()
    {
        
        //LOOP THAT RUNS UNTIL THE ENEMIES ARE DEAD OR THE PLAYER IS
        //VALID PLAYER INPUTS ARE ITEMS AND FIGHT (SLASH WITH BLADE, SHOOT GUN)
        //PLAYER INPUT FIRST AND THEN RANDOM NUMBER DECIDES WHAT THE ENEMIES DO FOR EACH ENEMY
        //PLAYER HEALTH UPDATES AFTER EACH ENEMY ATTACK AND ENEMY HEALTH UPDATES AFTER PLAYERS TURN
        //WHEN THE COMBAT IS DONE CALL ENDCOMBAT FUNCTION
    }
    
    public void EndCombat()
    {
        //GIVE DROPS BASED ON THE KILLED ENEMIES
        //SEND THE PLAYER BACK TO THE MAP SCENE
        //SEND TO END SCENE IF PLAYER HEALTH IS LESS THAN OR EQUAL TO 0
        Actor.HealthText.text = "";
        
    }
}
