using UnityEngine;

public class EnemyAttackExample : MonoBehaviour
{
    BattleManager battleManager;
    EnemyAttacks attacks;
    float lastTurnTime = -0.1f;

    void Start()
    {
        battleManager = GameObject.Find("Battle Manager").GetComponent<BattleManager>();
        attacks = GetComponent<EnemyAttacks>();
    }

    public void Attack()
    {
        if (battleManager.turnTime != lastTurnTime)
        {
            lastTurnTime = battleManager.turnTime;

            switch (battleManager.turnTime)
            {
                case 0:
                    Debug.Log("RANDOM BULLS*** GO!!!\n-Moon Knight");
                    battleManager.playerObject.transform.position = new Vector2(0, 0);
                    battleManager.bulletBox.transform.rotation = Quaternion.Euler(0, 0, 0);
                    break;

                case 1f:
                    attacks.NewHomingBullet(new Vector2(-3, 3), 5f, 20);
                    break;

                case 1.5f:
                    attacks.NewHomingBullet(new Vector2(3, 3), 5f, 20);
                    break;

                case 2f:
                    attacks.NewHomingBullet(new Vector2(3, -3), 5f, 20);
                    break;

                case 2.5f:
                    attacks.NewHomingBullet(new Vector2(-3, -3), 5f, 20);
                    break;

                case 3f:
                    attacks.NewHomingBullet(new Vector2(-3, 3), 5f, 20);
                    break;

                case 3.5f:
                    attacks.NewHomingBullet(new Vector2(3, 3), 5f, 20);
                    break;

                case 4f:
                    attacks.NewHomingBullet(new Vector2(3, -3), 5f, 20);
                    break;

                case 4.5f:
                    attacks.NewHomingBullet(new Vector2(-3, -3), 5f, 20);
                    break;

                case 5f:
                    attacks.NewHomingBullet(new Vector2(-3, 3), 5f, 20);
                    break;

                case 7:
                    battleManager.EndEnemyTurn();
                    break;
            }
        }
    }
}
