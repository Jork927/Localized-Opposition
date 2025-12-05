using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Endpoint : MonoBehaviour
{

    [SerializeField] private string level;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UnlockNewLevel();
            SceneManager.LoadScene(level);
            //SceneController.Instance.LoadNextLevel();
        }
    }

    void UnlockNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            Debug.Log("scene on " + SceneManager.GetActiveScene().buildIndex);
            Debug.Log("scene unlocked " + PlayerPrefs.GetInt("ReachedIndex"));

            

            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.SetInt("unlockedLevels", SceneManager.GetActiveScene().buildIndex - 1);
            PlayerPrefs.Save();



            Debug.Log("scene on " + SceneManager.GetActiveScene().buildIndex);
            Debug.Log("scene unlocked " + PlayerPrefs.GetInt("ReachedIndex"));
        }
    }

    

}