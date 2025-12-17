using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
    string turnState;

    BattleManager battleManager;
    float lastTurnTime = -0.1f;

    public GameObject inventory;

    void Start()
    {
        battleManager = GameObject.Find("Battle Manager").GetComponent<BattleManager>();
    }

    public void Turn()
    {
        if (battleManager.turnTime != lastTurnTime)
        {
            lastTurnTime = battleManager.turnTime;

            switch (battleManager.turnTime)
            {
                
            }
        }
    }

    public void Fight()
    {
        turnState = "Fight";
        battleManager.buttons.SetActive(false);
        battleManager.attackBox.SetActive(true);
        Debug.Log("Player chose to Fight!");
    }

    public void Item()
    {
        turnState = "Item";
        battleManager.buttons.SetActive(false);
        Debug.Log("Player chose to use an Item!");
        inventory.SetActive(true);
    }
}