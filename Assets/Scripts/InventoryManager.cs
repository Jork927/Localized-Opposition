using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Item[] startingItems;
    private static Item[] savedItems = new Item[31];

    public InventoryItem inventoryItemPrefab;

    public InventorySlot[] inventorySlots;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0; i < startingItems.Length; ++i)
        {
            if (!startingItems[i])
                continue;

            var GO = Instantiate(inventoryItemPrefab, inventorySlots[i].transform);
            GO.InitialiseItem(startingItems[i]);
        }
    }

    private void OnDestroy()
    {
        for (int i = 0; i < inventorySlots.Length; ++i)
        {
            savedItems[i]= inventorySlots[i].transform.childCount > 0 ? inventorySlots[i].transform.GetChild(0).GetComponent<InventoryItem>().item : null;
        }
    }
}
