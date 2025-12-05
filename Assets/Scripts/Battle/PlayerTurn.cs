using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
    BattleManager battleManager;

    void Start()
    {
        battleManager = GameObject.Find("Battle Manager").GetComponent<BattleManager>();
    }

    public void Turn()
    {
        switch (battleManager.turnTime)
        {
            case 1:
                Debug.Log("i am player turn script cuz i am player turn scripting");
            break;

            case 2:
                battleManager.EndPlayerTurn();
            break;
        }
    }
}
