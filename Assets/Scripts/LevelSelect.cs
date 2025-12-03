using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public void TutorialButton()
    {
        SceneManager.LoadScene("1Tutorial");
    }

    public void GroundButton()
    {
        SceneManager.LoadScene("2Ground");
    }

    public void BasementButton()
    {
        SceneManager.LoadScene("3Basement");
    }

    public void LabButton()
    {
        SceneManager.LoadScene("4Lab");
    }

    public void ServersButton()
    {
        SceneManager.LoadScene("5Servers");
    }
}
