using Unity.VisualScripting;
using UnityEngine;

public class BasicAttack1 : MonoBehaviour
{
    BattleManager battleManager;
    EnemyAttacks attacks;
    float lastTurnTime = -0.1f;

    int side;
    int varient;
    static int lastSide = -1;
    static int lastVariant = -1;

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

                case 2f:
                    MakeBullets();
                    break;

                case 3f:
                    MakeBullets();
                    break;

                case 4f:
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

        do
        {
            varient = Random.Range(1, 6);
        } while (varient == lastVariant);
        lastVariant = varient;

        switch (side)
        {
            case 1:
                y = 4;
                bulletSpeedReal = -bulletSpeed;
                break;

            case 2:
                y = -4;
                bulletSpeedReal = bulletSpeed;
                break;
        }

        switch (varient)
        {
            case 1:
                //attacks.NewBullet(new Vector2(-1.5f, y), bulletScale, 0, bulletSpeedReal, 20);
                attacks.NewBullet(new Vector2(-0.75f, y), bulletScale, 0, bulletSpeedReal, 20);
                attacks.NewBullet(new Vector2(0, y), bulletScale, 0, bulletSpeedReal, 20);
                attacks.NewBullet(new Vector2(0.75f, y), bulletScale, 0, bulletSpeedReal, 20);
                attacks.NewBullet(new Vector2(1.5f, y), bulletScale, 0, bulletSpeedReal, 20);
                break;

            case 2:
                attacks.NewBullet(new Vector2(-1.5f, y), bulletScale, 0, bulletSpeedReal, 20);
                //attacks.NewBullet(new Vector2(-0.75f, y), bulletScale, 0, bulletSpeedReal, 20);
                attacks.NewBullet(new Vector2(0, y), bulletScale, 0, bulletSpeedReal, 20);
                attacks.NewBullet(new Vector2(0.75f, y), bulletScale, 0, bulletSpeedReal, 20);
                attacks.NewBullet(new Vector2(1.5f, y), bulletScale, 0, bulletSpeedReal, 20);
                break;

            case 3:
                attacks.NewBullet(new Vector2(-1.5f, y), bulletScale, 0, bulletSpeedReal, 20);
                attacks.NewBullet(new Vector2(-0.75f, y), bulletScale, 0, bulletSpeedReal, 20);
                //attacks.NewBullet(new Vector2(0, y), bulletScale, 0, bulletSpeedReal, 20);
                attacks.NewBullet(new Vector2(0.75f, y), bulletScale, 0, bulletSpeedReal, 20);
                attacks.NewBullet(new Vector2(1.5f, y), bulletScale, 0, bulletSpeedReal, 20);
                break;

            case 4:
                attacks.NewBullet(new Vector2(-1.5f, y), bulletScale, 0, bulletSpeedReal, 20);
                attacks.NewBullet(new Vector2(-0.75f, y), bulletScale, 0, bulletSpeedReal, 20);
                attacks.NewBullet(new Vector2(0, y), bulletScale, 0, bulletSpeedReal, 20);
                //attacks.NewBullet(new Vector2(0.75f, y), bulletScale, 0, bulletSpeedReal, 20);
                attacks.NewBullet(new Vector2(1.5f, y), bulletScale, 0, bulletSpeedReal, 20);
                break;

            case 5:
                attacks.NewBullet(new Vector2(-1.5f, y), bulletScale, 0, bulletSpeedReal, 20);
                attacks.NewBullet(new Vector2(-0.75f, y), bulletScale, 0, bulletSpeedReal, 20);
                attacks.NewBullet(new Vector2(0, y), bulletScale, 0, bulletSpeedReal, 20);
                //attacks.NewBullet(new Vector2(0.75f, y), bulletScale, 0, bulletSpeedReal, 20);
                attacks.NewBullet(new Vector2(1.5f, y), bulletScale, 0, bulletSpeedReal, 20);
                break;
        }
    }
}
