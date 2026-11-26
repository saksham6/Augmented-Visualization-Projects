using UnityEngine;

public class BrainTargetPulse : MonoBehaviour
{
    public float pulseSpeed = 2f;
    public float pulseAmount = 0.25f;

    private Vector3 originalScale;
    private bool isPulsing;

    void Start()
    {
        originalScale = transform.localScale;
        isPulsing = false;
    }

    void Update()
    {
        if (!isPulsing)
            return;

        float scaleMultiplier =
            1f + Mathf.Sin(Time.time * pulseSpeed) * pulseAmount;

        transform.localScale = originalScale * scaleMultiplier;
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