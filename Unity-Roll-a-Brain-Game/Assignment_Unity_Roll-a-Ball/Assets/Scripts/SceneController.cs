using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;
    public float nextLevelDelay = 3f;
    private bool isLoading = false;
    private bool timerActive = false;
    private float currentTime = 0f;
    private TMP_Text timerText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // void Start()
    // {
        
    // }

    void Awake()
    {
        if ( Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
      
    
    void OnDestroy()
    {
        if (Instance == this)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.rKey.wasPressedThisFrame)
        {
            RestartLevel();
        }
        if (timerActive)
        {
            currentTime += Time.deltaTime;
        }
        if (timerText != null)
        {
            int seconds = Mathf.FloorToInt(currentTime);
            timerText.text = "Time: " + seconds + "s";
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)

    {
        FindTimerText();
    }

    void FindTimerText()
    {
        GameObject timerObject = GameObject.Find("TimerText");
        if (timerObject != null)
            {
            timerText = timerObject.GetComponent<TMP_Text>();
            }
            else
            {
                timerText = null;
            }
    }
    public void StartGame()
    {
        if (!isLoading)
        {
            isLoading = true;
            currentTime = 0f;
            timerActive = true;
            // int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            // SceneManager.LoadScene(currentSceneIndex + 1);
            SceneManager.LoadScene("Level1");

            isLoading = false;
        }
    }

    public void StopTimer()
    {
        timerActive = false;
    }

    // public void ExitGame()
    // {
    //     Debug.Log("Exit button pressed");
    // #if UNITY_EDITOR
    //     UnityEditor.EditorApplication.isPlaying = false;
    
    // #else
    //     Application.Quit();
    // #endif
    // }


    public void LoadNextLevelwithDelay()
    {
        if (!isLoading)
        {
            StartCoroutine(LoadNextLevelCoroutine());
        }
    }

    private IEnumerator LoadNextLevelCoroutine()
    {
        isLoading = true;
        yield return new WaitForSeconds(nextLevelDelay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1);
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("No next level found. loading EndScreen screen instead");
            timerActive = false;
            SceneManager.LoadScene("EndScreen");
        }

        isLoading = false;
    }


    public void LoadStartScreen()
    {
        if (!isLoading)
        {
        isLoading = true;
        currentTime = 0f;
        timerActive = false;
        SceneManager.LoadScene("StartScreen");
        isLoading = false;
        }
    }

    
    public void RestartGame()
    {
        if (!isLoading)
        {
            isLoading = true;
            currentTime = 0f;
            timerActive = false;
            SceneManager.LoadScene("StartScreen");
            isLoading = false;
        }
    }

    public void RestartLevel()
    {
        if (!isLoading)
        {
            isLoading = true;
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
            isLoading = false;

        }

    }



    public float GetCurrentTime()
    {
        return currentTime;
    }


    public void ExitGame()
    {
        Debug.Log("Exit button pressed");
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    
    #else
        Application.Quit();
    #endif
    }
}
