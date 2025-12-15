using Unity.Cinemachine;
using UnityEngine;

public class AttackBar : MonoBehaviour
{
    public GameObject bar;
    Vector2 barStartPosition;
    public float barSpeed;
    bool hitLandable;
    bool hitLanded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        barStartPosition = bar.transform.parent.localPosition;
        hitLanded = false;
    }

    void OnEnable()
    {
        bar.transform.localPosition = barStartPosition;
        bar.transform.Translate(-2.38f, 0, 0);
        hitLanded = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Battle Attack Bar"))
        {
            hitLandable = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Battle Attack Bar"))
        {
            hitLandable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // invert bar color rapidly
        bar.GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time * 10, 1));
        if (!hitLanded)
        {
            bar.transform.Translate(Vector3.right * barSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !hitLanded)
        {
            hitLanded = true;
        }
    }
}
