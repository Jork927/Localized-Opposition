using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Scriptable Objects/Item")]
public class Item : ScriptableObject
{
    [Header("Only UI")]
    public bool stackable = true;

    [Header("Both")]
    public Sprite image;

    public UnityEvent onUse;

    public int healingAmount;

    public void Heal()
    {
        // Heal the player
        PlayerStats stats = FindFirstObjectByType<PlayerStats>(FindObjectsInactive.Include);
        stats.health += healingAmount;

        // End the player's turn if in battle
        GameObject obj = GameObject.Find("Battle Manager");

        if (obj != null)
        {
            BattleManager battleManager = obj.GetComponent<BattleManager>();

            battleManager.EndPlayerTurn();
        }
    }
}

public enum  ItemType
{
    BuildingBlock,
    Tool
}

public enum  ActionType
{
    Dig,
    Mine
}