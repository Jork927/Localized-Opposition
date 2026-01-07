using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class BattleManager : MonoBehaviour
{
    // References
    [Header("References")]
    public GameObject buttons;
    public GameObject playerObject;
    public GameObject bulletBox;
    public GameObject attackBox;
    public GameObject inventory;
    public GameObject playerHealthbar;
    public GameObject enemyNameObject;
    public GameObject enemyHealthbar;
    MonoBehaviour playerTurnScript; // The player turn script
    EnemyAttackLibrary enemyAttackLibrary; // The enemy attack library
    public GameObject deathScreen;
    public GameObject battleObject;

    // Enemy Stats
    [Header("Enemy Stats")]
    public string enemyName;
    public int enemyHealth;
    public int enemyMaxHealth;

    // Battle dependancies
    [Header("Battle Dependancies")]
    public string turnState = "Player Turn"; // Whose turn is it?
    public bool turnActive = true; // Is a turn currently active?
    float turnTimeReal = 0; // How long the current turn has been active?
    public float turnTime; // Rounded turn time for use in other scripts
    MonoBehaviour enemyAttack; // The attack script used during the enemy's turn

    // Music
    [Header("Music")]
    public AudioClip battleMusic; // Battle music clip
    AudioSource audioSrc; // Audio source for playing music

    void Start()
    {
        // Get references
        playerTurnScript = GameObject.Find("Player Turn Script").GetComponent<PlayerTurn>();
        enemyAttackLibrary = GameObject.Find("Enemy Turn Scripts").GetComponent<EnemyAttackLibrary>();
        audioSrc = GetComponent<AudioSource>();
        audioSrc.clip = battleMusic;
        audioSrc.Play();

        StartPlayerTurn();
    }

    public void StartPlayerTurn()
    {
        buttons.SetActive(true);

        // Reset turn dependencies
        turnState = "Player Turn";
        turnActive = true;
        turnTimeReal = 0;

        Debug.Log("Player turn started. Executing script: " + playerTurnScript.GetType().Name);
    }

    public void EndPlayerTurn()
    {
        buttons.SetActive(false);
        attackBox.SetActive(false);
        inventory.SetActive(false);

        turnActive = false;

        Debug.Log("Player turn ended.");

        StartEnemyTurn();
    }

    public void StartEnemyTurn()
    {
        playerObject.SetActive(true);
        bulletBox.SetActive(true);

        // Reset turn dependencies
        turnState = "Enemy Turn";
        turnActive = true;
        turnTimeReal = 0;

        // Select a random attack
        enemyAttack = enemyAttackLibrary.enemyAttackScripts[Random.Range(0, enemyAttackLibrary.enemyAttackScripts.Length)];

        Debug.Log("Enemy turn started. Executing script: " + enemyAttack.GetType().Name);
    }

    public void EndEnemyTurn()
    {
        playerObject.SetActive(false);
        bulletBox.SetActive(false);
        DestroyBullets();

        turnActive = false;

        Debug.Log("Enemy turn ended.");

        StartPlayerTurn();
    }

    public void DestroyBullets()
    {
        // Find all objects with the tag "Battle Bullet" and destroy them
        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag("Battle Bullet");

        // Destroy each object
        foreach (GameObject obj in objectsToDestroy)
        {
            Destroy(obj);
        }
    }

    public void KillPlayer()
    {
        deathScreen.SetActive(true);
        battleObject.SetActive(false);
    }

    void Update()
    {
        // Update turn time if a turn is active
        if (turnActive)
        {
            turnTimeReal += Time.deltaTime; // Update real turn time
            turnTime = Mathf.Round(turnTimeReal * 100) / 100; // Round turn time to 2 decimal places

            // Execute the appropriate turn script
            switch (turnState)
            {
                case "Player Turn":
                    playerTurnScript.Invoke("Turn", 0);
                    break;

                case "Enemy Turn":
                    enemyAttack.Invoke("Attack", 0);
                    break;

                default:
                    Debug.LogWarning("Unknown turn state: " + turnState);
                    break;
            }
            if (enemyHealth <= 0)
            {
                Debug.Log("Enemy defeated!");
                SceneManager.LoadScene("Level Select");
            }
        }

        // scale the healthbar for the player which is a rect transform with a width of 400
        RectTransform playerHealthbarRect = playerHealthbar.GetComponent<RectTransform>();
        PlayerStats playerStats = playerObject.GetComponent<PlayerStats>();
        float playerHealthPercent = (float)playerStats.health / playerStats.maxHealth;
        playerHealthbarRect.sizeDelta = new Vector2(400 * playerHealthPercent, playerHealthbarRect.sizeDelta.y);
        // scale the healthbar for the enemy which is a rect transform with a width of 400
        RectTransform enemyHealthbarRect = enemyHealthbar.GetComponent<RectTransform>();
        float enemyHealthPercent = (float)enemyHealth / enemyMaxHealth;
        enemyHealthbarRect.sizeDelta = new Vector2(400 * enemyHealthPercent, enemyHealthbarRect.sizeDelta.y);
        // update enemy name text
        enemyNameObject.GetComponent<TextMeshProUGUI>().text = enemyName;
    }
}
