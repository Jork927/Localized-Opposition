using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D))]
public class ItemInstance : MonoBehaviour
{
    public Item data;

    private SpriteRenderer _sprt;

    private void Awake()
    { 
         _sprt = GetComponent<SpriteRenderer>();
         _sprt.sprite = data.image;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindFirstObjectByType< InventoryManager>().Additem(data);
        Destroy(gameObject);
    }
}