using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelSelect : MonoBehaviour
{
    public float unlocked = 1f;

    public void TutorialButton()
    {
        SceneManager.LoadScene("1Tutorial");
        
    }

    public void GroundButton()
    {
        unlocked = 2;
        SceneManager.LoadScene("2Ground");
        
    }

    public void BasementButton()
    {
        if (unlocked >= 2)
        {
         SceneManager.LoadScene("3Basement");
            unlocked = 3;
        }
        else 
        {
            Debug.Log("Level Locked");
        }
    }

    public void LabButton()
    {
        SceneManager.LoadScene("4Lab");
        unlocked = 4;
    }

    public void ServersButton()
    {
        SceneManager.LoadScene("5Servers");
    }
}
