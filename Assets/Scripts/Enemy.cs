using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class Enemy : MonoBehaviour
{
    public string scene;
    public string UniqueID;
    public static List<string> defeatedEnemies = new();
    public Item drop;

    private void Awake()
    {
        if (defeatedEnemies.Contains(UniqueID))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartPosition.doReload = false;
            defeatedEnemies.Add(UniqueID);

            if (drop != null)
            {
                FindFirstObjectByType<InventoryManager>().Additem(drop);

            }

            UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
        }
    }
}
