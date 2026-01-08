using Unity.VisualScripting;
using UnityEngine;

public class BasicAttack6 : MonoBehaviour
{
    BattleManager battleManager;
    EnemyAttacks attacks;
    float lastTurnTime = -0.1f;

    int side;
    static int lastSide = -1;

    float x;
    float y;
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
                    MakeBullets();
                    break;

                case 0.25f:
                    MakeBullets();
                    break;

                case 0.5f:
                    MakeBullets();
                    break;

                case 0.75f:
                    MakeBullets();
                    break;

                case 1f:
                    MakeBullets();
                    MakeHomingBullets();
                    break;

                case 1.25f:
                    MakeBullets();
                    break;

                case 1.5f:
                    MakeBullets();
                    break;

                case 1.75f:
                    MakeBullets();
                    break;

                case 2f:
                    MakeBullets();
                    MakeHomingBullets();
                    break;

                case 2.25f:
                    MakeBullets();
                    break;

                case 2.5f:
                    MakeBullets();
                    break;

                case 2.75f:
                    MakeBullets();
                    break;

                case 3f:
                    MakeBullets();
                    MakeHomingBullets();
                    break;

                case 3.25f:
                    MakeBullets();
                    break;

                case 3.5f:
                    MakeBullets();
                    break;

                case 3.75f:
                    MakeBullets();
                    break;

                case 4f:
                    MakeBullets();
                    MakeHomingBullets();
                    break;

                case 4.25f:
                    MakeBullets();
                    break;

                case 4.5f:
                    MakeBullets();
                    break;

                case 4.75f:
                    MakeBullets();
                    break;

                case 5f:
                    MakeBullets();
                    MakeHomingBullets();
                    break;

                case 5.25f:
                    MakeBullets();
                    break;

                case 5.5f:
                    MakeBullets();
                    break;

                case 5.75f:
                    MakeBullets();
                    break;

                case 6f:
                    MakeBullets();
                    break;

                case 6.25f:
                    MakeBullets();
                    break;

                case 6.5f:
                    MakeBullets();
                    break;

                case 6.75f:
                    MakeBullets();
                    break;

                case 7f:
                    MakeBullets();
                    break;

                case 7.25f:
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
        attacks.NewBullet(new Vector2(-4, -1.5f), 1, 3, 0, 20);
        attacks.NewBullet(new Vector2(4, 1.5f), 1, -3, 0, 20);
    }

    void MakeHomingBullets()
    {
        do
        {
            side = Random.Range(1, 5);
        } while (side == lastSide);
        lastSide = side;

        switch (side)
        {
            case 1:
                x = Random.Range(-4f, 4f);
                y = 4;
                break;

            case 2:
                x = Random.Range(-4f, 4f);
                y = -4;
                break;

            case 3:
                x = -4;
                y = Random.Range(-4f, 4f);
                break;

            case 4:
                x = 4;
                y = Random.Range(-4f, 4f);
                break;
        }

        attacks.NewHomingBullet(new Vector2(x, y), bulletSpeed, 20);
    }
}
