using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("yuhhhhhhh");
    }
}