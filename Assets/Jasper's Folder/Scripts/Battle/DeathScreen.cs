using UnityEditor.SearchService;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    // References
    [Header("References")]
    public AudioSource audioSrc;
    public AudioClip deathSound;
    public GameObject flashBang;
    public GameObject deathText;
    public GameObject retryButton;
    public GameObject retryText;

    float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSrc.PlayOneShot(deathSound);
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // fade flashbang image out over 1 second its an image component on canvas object
        flashBang.GetComponent<UnityEngine.UI.Image>().color = new Color(1, 1, 1, Mathf.Clamp01(1 - timer));

        if (timer >= 2.5)
        {
            if (!deathText.activeSelf)
            {
                audioSrc.Play();
                deathText.SetActive(true);
            }
        }

        if (timer >= 5)
        {
            if (!retryButton.activeSelf)
            {
                retryButton.SetActive(true);
            }

            retryText.GetComponent<TMPro.TextMeshProUGUI>().color = new Color(0.5f, 0, 0, Mathf.Clamp01(timer - 5));
        }
    }

    public void RestartBattle()
    {
        Debug.Log("big penis");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
