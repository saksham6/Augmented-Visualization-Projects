using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartAgain()
    {
        Debug.Log("Starting again...");
        SceneManager.LoadScene("StartScreen");
    }

    // Update is called once per frame
    public void ExitGame()
    {
        Debug.Log("Exiting game...");
    

#if UNITY_EDITOR

UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
}
