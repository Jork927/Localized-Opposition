using UnityEngine;

public class EnemyAttack1 : MonoBehaviour
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
                Debug.Log("badaboom");
            break;

            case 2:
                Debug.Log("badabing");
            break;

            case 3:
                Debug.Log("KABLOOEY");
            break;

            case 4:
                battleManager.EndEnemyTurn();
            break;
        }
    }
}
