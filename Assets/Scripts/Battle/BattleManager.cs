using TMPro;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    // References
    [Header("Turn Scripts")]
    public MonoBehaviour playerTurnScript;
    public MonoBehaviour[] enemyTurnScripts;

    // Battle state variables
    [Header("Battle State")]
    public int turnNumber = 0;
    public string turnState = "Player Turn";
    public bool turnActive = true;
    public float turnTime = 0;

    // Debug
    [Header("Debug")]
    public GameObject debugText;

    void Start()
    {
        
    }

    void Update()
    {
        // Update turn time if the turn is active
        if (turnActive)
        {
            turnTime += Time.deltaTime;

            switch (turnState)
            {
                case "Player Turn":
                    // Handle player turn logic here
                    break;
                case "Enemy Turn":
                    // Handle enemy turn logic here
                    break;
                default:
                    Debug.LogWarning("Unknown turn state: " + turnState);
                    break;
            }
        }

        
        debugText.GetComponent<TextMeshProUGUI>().text = "Turn: " + turnNumber + "\nState: " + turnState + "\nActive: " + turnActive + "\nTime: " + turnTime.ToString("F2");
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
