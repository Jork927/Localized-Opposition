using Unity.VisualScripting;
using UnityEngine;

public class BasicAttack7 : MonoBehaviour
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
                    MakeMoreBullets();
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
                    MakeMoreBullets();
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
                    MakeMoreBullets();
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
                    MakeMoreBullets();
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
                    MakeMoreBullets();
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
        attacks.NewBullet(new Vector2(-1.5f, 4), 1, 0, -3, 20);
        attacks.NewBullet(new Vector2(1.5f, -4), 1, 0, 3, 20);
    }

    void MakeMoreBullets()
    {
        attacks.NewBullet(new Vector2(-0.5f, 4), 1.5f, 0, -3, 20);
        attacks.NewBullet(new Vector2(0.5f, -4), 1.5f, 0, 3, 20);
    }
}