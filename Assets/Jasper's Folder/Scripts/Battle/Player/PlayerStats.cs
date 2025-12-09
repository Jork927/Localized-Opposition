using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Player Stats
    [Header("Player Stats")]
    public bool active;
    public int health;
    public bool invincible;
    public float invincibilityTime;
    float timeInvincible;

    private void Start()
    {
        timeInvincible = 0;
    }

    void Update()
    {
        if (active)
        {
            switch (health
            )
            {
                case <= 0:
                    health = 0;
                    active = false;
                    Debug.Log("Player Defeated");
                    break;

                case > 100:
                    health = 100;
                    break;
            }

            // Invincibility
            if (invincible)
            {
                timeInvincible += Time.deltaTime;

                if (timeInvincible >= invincibilityTime)
                {
                    timeInvincible = 0;
                    invincible = false;
                }
            }
        }
    }
}
