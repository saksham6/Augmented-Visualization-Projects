using UnityEngine;

public class BrainTiltColor : MonoBehaviour
{
    public Transform imageTarget;
    public Renderer brainRenderer;

    public Color normalColor = Color.white;
    public Color tiltedColor = Color.red;

    public float tiltThreshold = 25f;

    void Update()
    {
        if (imageTarget == null || brainRenderer == null)
            return;

        float tiltX = Mathf.Abs(imageTarget.eulerAngles.x);
        float tiltZ = Mathf.Abs(imageTarget.eulerAngles.z);

        bool isTilted =
            (tiltX > tiltThreshold && tiltX < 360f - tiltThreshold) ||
            (tiltZ > tiltThreshold && tiltZ < 360f - tiltThreshold);

        brainRenderer.material.color =
            isTilted ? tiltedColor : normalColor;
    }
}