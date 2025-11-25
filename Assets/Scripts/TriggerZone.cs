using UnityEngine;
using UnityEngine.Events;

public class TriggerZone : MonoBehaviour
{
    public UnityEvent onEnter;
    public UnityEvent onExit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        onEnter.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        onExit.Invoke();
    }
}
