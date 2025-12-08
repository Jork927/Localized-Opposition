using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("Level Select");
        Debug.Log("Player pressed button 'Start', loading scene 'Tutorial'");
    }

    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Player pressed button 'Quit', ending the application");
    }
}