using UnityEngine;

public class EnemyAttack2 : MonoBehaviour
{
    BattleManager battleManager;

    void Start()
    {
        battleManager = GameObject.Find("Battle Manager").GetComponent<BattleManager>();
    }

    /*
     * ok buddy so what youre gonna do is
     * make a variable that resets every time the turn does something, to avoid it doing it a million times at once
     * 
     * ex.
     * 
     * canDoThing = true;
     * 
     * if (canDoThing)
     * {
     *  do thing
     *  canDoThing = false;
     * }
     * 
    */

    public void Attack()
    {
        switch (battleManager.turnTime)
        {
            case 1:
                Debug.Log("whar");
                break;

            case 2:
                Debug.Log("WHTAS HAPENINGG");
                break;

            case 3:
                Debug.Log("HELP");
            break;

            case 4:
                battleManager.EndEnemyTurn();
            break;
        }
    }
}
