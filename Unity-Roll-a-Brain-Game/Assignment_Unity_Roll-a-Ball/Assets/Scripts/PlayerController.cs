using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public TextMeshProUGUI countText;
    public float speed = 0;
    private int count; 
    public GameObject winTextObject;
    public int NumberofPickUps;
    private SceneController sceneController;
    public float fallLimit = -5f;
    public GameObject loseMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        count = 0;
        rb = GetComponent<Rigidbody>();
        //SetCountText();
        winTextObject.SetActive(false);
        NumberofPickUps = GameObject.FindGameObjectsWithTag("PickUp").Length;
        sceneController = FindObjectOfType<SceneController>();
        SetCountText();
        if (loseMenu != null)
        {
            loseMenu.SetActive(false);
        }

    }

    private void OnMove(InputValue movementValue)
    {
        
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY );
        rb.AddForce(movement * speed);
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (NumberofPickUps > 0 && count >= NumberofPickUps)
        {
            winTextObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Win!";
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
            }   
        if (sceneController != null) 
            {
                sceneController.LoadNextLevelwithDelay();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Lava"))
        {
            Destroy(gameObject);
            winTextObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
            if (loseMenu != null)
        {
            loseMenu.SetActive(true);
        }
        }
    }


    void OnExit(InputValue value)
    {
        if (value.isPressed)
        {
            Debug.Log("Esc Pressed- Exit");
            Application.Quit();
        }
    }


    public void OnButtonPressed()
    {
        Debug.Log("Menu Button Pressed. Go too menu");
        if (sceneController != null)
        {
            sceneController.LoadStartScreen();
        }
        
    }

    void Update()
    {
        if (transform.position.y < fallLimit)
        {
            Destroy(gameObject);
            winTextObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
        }
    }

}   


