using UnityEngine;

public class EnemyAttackExample : MonoBehaviour
{
    BattleManager battleManager;
    float lastTurnTime = -0.1f;

    public GameObject triBullet;

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
                    Debug.Log("RANDOM BULLS*** GO!!!\n-Moon Knight");
                    break;

                case 1f:
                    Instantiate(triBullet, new Vector3(-3, 3, 0), Quaternion.identity);
                    break;

                case 1.25f:
                    Instantiate(triBullet, new Vector3(3, 3, 0), Quaternion.identity);
                    break;

                case 1.5f:
                    Instantiate(triBullet, new Vector3(3, -3, 0), Quaternion.identity);
                    break;

                case 1.75f:
                    Instantiate(triBullet, new Vector3(-3, -3, 0), Quaternion.identity);
                    break;

                case 2f:
                    Instantiate(triBullet, new Vector3(-3, 3, 0), Quaternion.identity);
                    break;

                case 2.25f:
                    Instantiate(triBullet, new Vector3(3, 3, 0), Quaternion.identity);
                    break;

                case 2.5f:
                    Instantiate(triBullet, new Vector3(3, -3, 0), Quaternion.identity);
                    break;

                case 2.75f:
                    Instantiate(triBullet, new Vector3(-3, -3, 0), Quaternion.identity);
                    break;

                case 3f:
                    Instantiate(triBullet, new Vector3(-3, 3, 0), Quaternion.identity);
                    break;

                case 3.25f:
                    Instantiate(triBullet, new Vector3(3, 3, 0), Quaternion.identity);
                    break;

                case 3.5f:
                    Instantiate(triBullet, new Vector3(3, -3, 0), Quaternion.identity);
                    break;

                case 3.75f:
                    Instantiate(triBullet, new Vector3(-3, -3, 0), Quaternion.identity);
                    break;

                case 4f:
                    Instantiate(triBullet, new Vector3(-3, 3, 0), Quaternion.identity);
                    break;

                case 4.25f:
                    Instantiate(triBullet, new Vector3(3, 3, 0), Quaternion.identity);
                    break;

                case 4.5f:
                    Instantiate(triBullet, new Vector3(3, -3, 0), Quaternion.identity);
                    break;

                case 4.75f:
                    Instantiate(triBullet, new Vector3(-3, -3, 0), Quaternion.identity);
                    break;

                case 5f:
                    Instantiate(triBullet, new Vector3(-3, 3, 0), Quaternion.identity);
                    break;

                case 6:
                    battleManager.EndEnemyTurn();
                    break;
            }
        }
    }
}
