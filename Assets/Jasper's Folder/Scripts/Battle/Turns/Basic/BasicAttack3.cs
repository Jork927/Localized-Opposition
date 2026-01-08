using Unity.VisualScripting;
using UnityEngine;

public class BasicAttack3 : MonoBehaviour
{
    BattleManager battleManager;
    EnemyAttacks attacks;
    float lastTurnTime = -0.1f;

    int side;
    static int lastSide = -1;

    int y;
    public float bulletScale;
    public float bulletSpeed;
    float bulletSpeedReal;

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
                    battleManager.playerObject.transform.position = new Vector2(0, 0);
                    battleManager.bulletBox.transform.rotation = Quaternion.Euler(0, 0, 0);
                    break;

                case 1f:
                    MakeBullets();
                    break;

                case 1.33f:
                    MakeBullets();
                    break;

                case 1.66f:
                    MakeBullets();
                    break;

                case 2f:
                    MakeBullets();
                    break;

                case 2.33f:
                    MakeBullets();
                    break;

                case 2.66f:
                    MakeBullets();
                    break;

                case 3f:
                    MakeBullets();
                    break;

                case 3.33f:
                    MakeBullets();
                    break;

                case 3.66f:
                    MakeBullets();
                    break;

                case 4f:
                    MakeBullets();
                    break;

                case 4.33f:
                    MakeBullets();
                    break;

                case 4.66f:
                    MakeBullets();
                    break;

                case 5f:
                    MakeBullets();
                    break;

                case 7.5f:
                    battleManager.EndEnemyTurn();
                    break;
            }
        }
    }

    void MakeBullets()
    {
        do
        {
            side = Random.Range(1, 3);
        } while (side == lastSide);
        lastSide = side;

        switch (side)
        {
            case 1:
                y = -4;
                bulletSpeedReal = bulletSpeed;
                break;

            case 2:
                y = 4;
                bulletSpeedReal = -bulletSpeed;
                break;
        }

        attacks.NewBullet(new Vector2(Random.Range(-2f, 2f), y), bulletScale, 0, bulletSpeedReal, 20);
    }
}
