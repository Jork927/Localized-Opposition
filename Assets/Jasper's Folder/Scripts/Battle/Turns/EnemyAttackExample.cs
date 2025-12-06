using UnityEngine;

public class EnemyAttackExample : MonoBehaviour
{
    /* 
     * This is an example enemy attack script.
     * 
     * To create an attack, add cases to the switch statement in the Attack() method.
     * The number in each case corresponds to the turn time in seconds.
     * 
     * For example, this script will print "Hello World!" to the Console on execution.
     * Then, it will end the enemy turn after 3 seconds.
     * 
     * Once you understand how this works, you can copy the code in BlankEnemyAttack script.
     * Then, you can set it up accordingly and add cases to create your own enemy attacks!
     * 
     * Remember to call battleManager.EndEnemyTurn() when you want the enemy's turn to end!
    */

    BattleManager battleManager;
    float lastTurnTime = -0.1f;

    void Start()
    {
        battleManager = GameObject.Find("Battle Manager").GetComponent<BattleManager>();
    }

    public void Attack()
    {
        if (battleManager.turnTime != lastTurnTime)
        {
            lastTurnTime = battleManager.turnTime;

            switch (battleManager.turnTime)
            {
                case 0:
                    Debug.Log("Hello World!");
                    break;

                case 3:
                    battleManager.EndEnemyTurn();
                    break;
            }
        }
    }
}
