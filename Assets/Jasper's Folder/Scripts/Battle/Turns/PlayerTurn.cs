using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
    BattleManager battleManager;
    float lastTurnTime = -0.1f;

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
        Debug.Log("Player chose to Fight!");
        battleManager.EndPlayerTurn();
    }
}