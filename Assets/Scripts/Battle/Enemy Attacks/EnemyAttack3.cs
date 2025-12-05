using UnityEngine;

public class EnemyAttack3 : MonoBehaviour
{
    BattleManager battleManager;

    void Start()
    {
        battleManager = GameObject.Find("Battle Manager").GetComponent<BattleManager>();
    }

    public void Attack()
    {
        switch (battleManager.turnTime)
        {
            case 1:
                Debug.Log("The FitnessGram Pacer Test is a multi-stage aerobic capacity test");
            break;

            case 2:
                Debug.Log("that progressively gets more difficult as it continues.");
            break;

            case 3:
                Debug.Log("Line up at the start.");
            break;

            case 4:
                battleManager.EndEnemyTurn();
            break;
        }
    }
}
