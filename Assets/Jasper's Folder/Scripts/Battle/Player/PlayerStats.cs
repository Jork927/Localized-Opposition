using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Player Stats
    [Header("Player Stats")]
    public bool active;
    public int health;
    public int maxHealth;
    public bool invincible;
    public float invincibilityTime;
    float timeInvincible;
    public int minAttackDamage;
    public int maxAttackDamage;

    public Color normalColor;
    public Color hurtColor;
    SpriteRenderer sr;

    // Sounds
    [Header("Sounds")]
    AudioSource audioSrc;
    public AudioClip meow;
    public AudioClip hurtMeow;
    public AudioClip hurtHit;

    void Start()
    {
        timeInvincible = 0;
        sr = GetComponentInChildren<SpriteRenderer>();
        audioSrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (active)
        {
            if (health <= 0)
            {
                health = 0;

                if (active)
                {
                    audioSrc.PlayOneShot(hurtHit);
                }

                active = false;
                Debug.Log("Player Defeated");

                BattleManager battleManager = GameObject.Find("Battle Manager").GetComponent<BattleManager>();
                battleManager.KillPlayer();
            }

            if (health > maxHealth)
            {
                health = maxHealth;
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

                sr.color = Color.Lerp(hurtColor, normalColor, timeInvincible / invincibilityTime);
            }
            else
            {
                timeInvincible = 0;
                sr.color = normalColor;
            }
        }
    }

    public void Damage(int amount)
    {
        if (!invincible)
        {
            audioSrc.PlayOneShot(hurtMeow);
            audioSrc.pitch = Random.Range(1, 2f);

            health -= amount;
            invincible = true;
        }
    }
}
