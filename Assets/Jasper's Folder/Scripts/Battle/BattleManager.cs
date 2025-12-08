using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class BattleManager : MonoBehaviour
{
    // References
    [Header("Turn Scripts")]
    MonoBehaviour playerTurnScript; // The player turn script
    EnemyAttackLibrary enemyAttackLibrary; // The enemy attack library

    // Battle dependancies
    [Header("Battle Dependancies")]
    public string turnState = "Player Turn"; // Whose turn is it?
    public bool turnActive = true; // Is a turn currently active?
    float turnTimeReal = 0; // How long the current turn has been active?
    public float turnTime; // Rounded turn time for use in other scripts
    MonoBehaviour enemyAttack; // The attack script used during the enemy's turn

    // Debug
    [Header("Debug")]
    TextMeshProUGUI debugText; // Debug text UI element

    void Start()
    {
        // Get references
        debugText = GameObject.Find("Debug Text").GetComponent<TextMeshProUGUI>();
        playerTurnScript = GameObject.Find("Player Turn Script").GetComponent<PlayerTurn>();
        enemyAttackLibrary = GameObject.Find("Enemy Turn Scripts").GetComponent<EnemyAttackLibrary>();

        StartPlayerTurn();
    }

    public void StartPlayerTurn()
    {
        // Reset turn dependencies
        turnState = "Player Turn";
        turnActive = true;
        turnTimeReal = 0;

        Debug.Log("Player turn started. Executing script: " + playerTurnScript.GetType().Name);
    }

    public void EndPlayerTurn()
    {
        turnActive = false;

        Debug.Log("Player turn ended.");

        StartEnemyTurn();
    }

    public void StartEnemyTurn()
    {
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
        turnActive = false;

        Debug.Log("Enemy turn ended.");

        StartPlayerTurn();
    }

    void Update()
    {
        // Update turn time if a turn is active
        if (turnActive)
        {
            turnTimeReal += Time.deltaTime; // Update real turn time
            turnTime = Mathf.Round(turnTimeReal * 10) / 10; // Round to 1 decimal place

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
        }

        // Update debug text
        debugText.text = "Turn State: " + turnState + "\n" +
                         "Turn Active: " + turnActive + "\n" +
                         "Turn Time: " + turnTime + "s\n" +
                         "Current Script: " + (turnState == "Player Turn" ? playerTurnScript.GetType().Name : enemyAttack.GetType().Name);
    }
}
