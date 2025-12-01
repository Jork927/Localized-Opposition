using UnityEditor.SearchService;
using UnityEngine;

using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class Triggerbox : MonoBehaviour
{
    public UnityEvent onEnter;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("Level Select");
    }
}
