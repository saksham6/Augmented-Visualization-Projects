using UnityEngine;
using UnityEngine.InputSystem;

public class BrainKeyboardControl : MonoBehaviour
{
    public float rotationSpeed = 90f;
    public float scaleSpeed = 0.005f;

    void Update()
    {
        if (Keyboard.current == null)
            return;

        if (Keyboard.current.leftArrowKey.isPressed)
        {
            transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
        }

        if (Keyboard.current.rightArrowKey.isPressed)
        {
            transform.Rotate(0f, -rotationSpeed * Time.deltaTime, 0f);
        }

        if (Keyboard.current.upArrowKey.isPressed)
        {
            transform.localScale += Vector3.one * scaleSpeed * Time.deltaTime;
        }

        if (Keyboard.current.downArrowKey.isPressed)
        {
            Vector3 newScale =
                transform.localScale - Vector3.one * scaleSpeed * Time.deltaTime;

            if (newScale.x > 0.001f)
            {
                transform.localScale = newScale;
            }
        }
    }
}