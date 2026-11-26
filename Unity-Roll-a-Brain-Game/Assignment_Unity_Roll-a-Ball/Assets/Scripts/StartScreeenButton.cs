using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreeenButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    // Update is called once per frame
    public void ExitGame()
    {
        Debug.Log("Exit Game pressed from startscreenbutton");
    }

#if UNITY_EDITOR
    public void ExitGameEditor()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
#else
        Application.Quit();
#endif
}
