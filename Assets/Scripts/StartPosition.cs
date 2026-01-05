using UnityEngine;

public class StartPosition : MonoBehaviour
{
    public static bool doReload = true;

    private void Awake()
    {
        if ( doReload)
        {
            Movement.Lastpos = transform.position;
        }
    }
}
