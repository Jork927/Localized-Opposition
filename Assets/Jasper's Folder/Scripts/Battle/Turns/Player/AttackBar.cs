using Unity.Cinemachine;
using UnityEngine;

public class AttackBar : MonoBehaviour
{
    public BattleManager battleManager;
    public GameObject bar;
    Vector2 barStartPosition;
    public float barSpeed;
    bool hitLandable;
    bool hitLanded;
    float timer;
    PlayerStats stats;
    MittensAnimation mittensAnimation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        battleManager = GameObject.Find("Battle Manager").GetComponent<BattleManager>();
        barStartPosition = bar.transform.parent.localPosition;
        hitLanded = false;
        hitLandable = false;
        timer = 0;
        stats = battleManager.playerObject.GetComponent<PlayerStats>();
        mittensAnimation = GameObject.Find("MITTENS Portrait").GetComponent<MittensAnimation>();
    }

    void OnEnable()
    {
        bar.transform.localPosition = barStartPosition;
        bar.transform.Translate(-2.38f, 0, 0);
        hitLanded = false;
        hitLandable = false;
        timer = 0;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Battle Attack Bar"))
        {
            hitLandable = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Battle Attack Bar"))
        {
            hitLandable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // invert bar color rapidly
        bar.GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time * 10, 1));

        timer += Time.deltaTime;

        if (!hitLanded)
        {
            if (timer >= 0.5f)
            {
                bar.transform.Translate(Vector3.right * barSpeed * Time.deltaTime);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    hitLanded = true;
                    timer = 0;

                    if (hitLandable)
                    {
                        Debug.Log("Successful Hit!");
                        battleManager.enemyHealth -= Random.Range(stats.minAttackDamage, stats.maxAttackDamage);
                        mittensAnimation.PlayAnimation("Attack");
                    }
                    else
                    {
                        Debug.Log("Missed!");
                    }
                } 
            }
        }
        else
        {
            if (timer >= 1)
            {
                battleManager.EndPlayerTurn();
            }
        }
    }
}
