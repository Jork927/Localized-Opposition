using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class BattleManager : MonoBehaviour
{
    // Debug
    [Header("Debug")]
    TextMeshProUGUI debugText;

    // References
    [Header("Turn Scripts")]
    MonoBehaviour playerTurnScript; // The player turn script
    EnemyAttackLibrary enemyAttackLibrary; // The enemy attack library

    // Battle dependancy variables
    [Header("Battle Dependancies")]
    public string turnState = "Player Turn"; // Whose turn is it?
    public bool turnActive = true; // Is a turn currently active?
    float turnTimeReal = 0; // How long the current turn has been active?
    public float turnTime; // Rounded turn time for use in other scripts

    MonoBehaviour enemyAttack; // The attack script used during the enemy's turn

    void Start()
    {
        debugText = GameObject.Find("Debug Text").GetComponent<TextMeshProUGUI>();
        playerTurnScript = GameObject.Find("Player Turn Script").GetComponent<PlayerTurn>();
        enemyAttackLibrary = GameObject.Find("Enemy Turn Scripts").GetComponent<EnemyAttackLibrary>();

        StartPlayerTurn();
    }

    public void StartPlayerTurn()
    {
        turnState = "Player Turn";
        turnActive = true;
        turnTimeReal = 0;

        Debug.Log("Player turn started.");
    }

    public void EndPlayerTurn()
    {
        turnActive = false;

        Debug.Log("Player turn ended.");

        StartEnemyTurn();
    }

    public void StartEnemyTurn()
    {
        turnState = "Enemy Turn";
        turnActive = true;
        turnTimeReal = 0;

        // Select a random attack
        enemyAttack = enemyAttackLibrary.enemyAttackScripts[Random.Range(0, enemyAttackLibrary.enemyAttackScripts.Length)];

        Debug.Log("Enemy turn started. Using attack: " + enemyAttack.GetType().Name);
    }

    public void EndEnemyTurn()
    {
        turnActive = false;

        Debug.Log("Enemy turn ended.");

        StartPlayerTurn();
    }

    void Update()
    {
        // Update turn time if the turn is active
        if (turnActive)
        {
            turnTimeReal += Time.deltaTime;
            turnTime = Mathf.Round(turnTimeReal * 10) / 10; // Round to 1 decimal place

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
        }

        debugText.text = "\nState: " + turnState + "\nActive: " + turnActive + "\nTime: " + turnTime.ToString("F2");
    }

    /* The battle system will work as follows:
     * 
     * Each battle will start on the player's turn.
     * The player must pick between attacking or using an item from their inventory.
     * 
     * If the player chooses to attack, a quicktime event will occur where they must hit a button at the right time to land a successful hit.
     * 
     * If the player chooses to use an item, they can select an item from their inventory to use. This is not limited to healing items.
     * The player can exit their inventory and choose to attack instead if they didn't already use an item on their turn.
     * 
     * After the player has made their choice, the enemy will take their turn.
     * The enemy will always choose to attack the player. When it does, it will choose between one of several randomized attack patterns, similar to Undertale.
     * The player must dodge the enemy's attacks to avoid taking damage.
     * 
     * Once the enemy's attack is over, the turn ends and the player can take their turn again.
     * This continues until either the player or the enemy's health reaches zero.
     */
}
