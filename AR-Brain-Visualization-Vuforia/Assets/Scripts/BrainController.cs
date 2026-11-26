using UnityEngine;
using UnityEngine.InputSystem;

public class BrainController : MonoBehaviour
{
    [Header("Keyboard Rotation")]
    public float rotationSpeed = 80f;

    [Header("Target-Triggered Pulse")]
    public float pulseSpeed = 2f;
    public float pulseAmount = 0.25f;

    private Vector3 originalScale;
    private bool isPulsing;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        HandleKeyboardRotation();
        HandlePulse();
    }

    private void HandleKeyboardRotation()
    {
        if (Keyboard.current == null)
            return;

        if (Keyboard.current.leftArrowKey.isPressed)
        {
            transform.Rotate(
                0f,
                rotationSpeed * Time.deltaTime,
                0f,
                Space.Self
            );
        }

        if (Keyboard.current.rightArrowKey.isPressed)
        {
            transform.Rotate(
                0f,
                -rotationSpeed * Time.deltaTime,
                0f,
                Space.Self
            );
        }
    }

    private void HandlePulse()
    {
        if (!isPulsing)
            return;

        float multiplier =
            1f + Mathf.Sin(Time.time * pulseSpeed) * pulseAmount;

        transform.localScale = originalScale * multiplier;
    }

    public void StartPulsing()
    {
        isPulsing = true;
    }

    public void StopPulsing()
    {
        isPulsing = false;
        transform.localScale = originalScale;
    }
}