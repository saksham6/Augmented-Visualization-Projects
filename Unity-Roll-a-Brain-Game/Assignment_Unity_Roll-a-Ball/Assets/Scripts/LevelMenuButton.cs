using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenuButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void TryAgain()
    {
        Debug.Log("Try Again pressed");
        Scene CurrentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(CurrentScene.name);
    }

    // Update is called once per frame
    public void ExitToStart()
    {
        Debug.Log("Exit to Start pressed");
        SceneManager.LoadScene("StartScreen");
    }
}
