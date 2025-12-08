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

    public void Heal()
    {

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