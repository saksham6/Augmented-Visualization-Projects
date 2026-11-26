using UnityEngine;

public class VolumeViewerController : MonoBehaviour
{
    [Header("Main Objects")]
    public GameObject volumeObject;
    public GameObject axialSlice;
    public GameObject coronalSlice;
    public GameObject sagittalSlice;
    public GameObject crossSectionPlane;

    [Header("Slice Control")]
    public float sliceRange = 100f;

    private GameObject currentSlice;
    private Vector3 axialStartPos;
    private Vector3 coronalStartPos;
    private Vector3 sagittalStartPos;

    private float sliceValue = 0f;

    void Start()
    {
        if (axialSlice != null) axialStartPos = axialSlice.transform.localPosition;
        if (coronalSlice != null) coronalStartPos = coronalSlice.transform.localPosition;
        if (sagittalSlice != null) sagittalStartPos = sagittalSlice.transform.localPosition;

        ShowAxialSlice();
    }

    void OnGUI()
    {
    GUI.skin.label.fontSize = 24;
    GUI.skin.button.fontSize = 22;
    GUI.skin.box.fontSize = 24;
    GUI.skin.horizontalSlider.fixedHeight = 30;
    GUI.skin.horizontalSliderThumb.fixedHeight = 35;
    GUI.skin.horizontalSliderThumb.fixedWidth = 25;

    GUILayout.BeginArea(new Rect(30, 30, 420, 430), GUI.skin.box);

    GUILayout.Label("Volume Rendering Viewer");

    GUILayout.Space(10);

    if (GUILayout.Button("Toggle 3D Volume", GUILayout.Height(50)))
    {
        ToggleVolume();
    }

    GUILayout.Space(15);

    if (GUILayout.Button("Toggle Cross-Section Plane", GUILayout.Height(50)))
    {
        ToggleCrossSectionPlane();
    }



    if (GUILayout.Button("Axial Slice", GUILayout.Height(50)))
    {
        ShowAxialSlice();
    }

    if (GUILayout.Button("Coronal Slice", GUILayout.Height(50)))
    {
        ShowCoronalSlice();
    }

    if (GUILayout.Button("Sagittal Slice", GUILayout.Height(50)))
    {
        ShowSagittalSlice();
    }

    GUILayout.Space(15);

    GUILayout.Label("Move Current Slice");

    float newSliceValue = GUILayout.HorizontalSlider(
        sliceValue,
        -sliceRange,
        sliceRange,
        GUILayout.Height(40)
    );

    if (Mathf.Abs(newSliceValue - sliceValue) > 0.001f)
    {
        sliceValue = newSliceValue;
        UpdateSlicePosition();
    }

    GUILayout.Space(10);

    if (GUILayout.Button("Reset Slice Position", GUILayout.Height(50)))
    {
        sliceValue = 0f;
        UpdateSlicePosition();
    }

    GUILayout.EndArea();
    }



    public void ToggleVolume()
    {
        if (volumeObject != null)
        {
            volumeObject.SetActive(!volumeObject.activeSelf);
        }
    }

    public void ShowAxialSlice()
    {
        SetActiveSlice(axialSlice);
    }

    public void ShowCoronalSlice()
    {
        SetActiveSlice(coronalSlice);
    }

    public void ShowSagittalSlice()
    {
        SetActiveSlice(sagittalSlice);
    }

    private void SetActiveSlice(GameObject selectedSlice)
    {
        if (axialSlice != null) axialSlice.SetActive(false);
        if (coronalSlice != null) coronalSlice.SetActive(false);
        if (sagittalSlice != null) sagittalSlice.SetActive(false);

        currentSlice = selectedSlice;

        if (currentSlice != null)
        {
            currentSlice.SetActive(true);
            sliceValue = 0f;
            UpdateSlicePosition();
        }
    }

    private void UpdateSlicePosition()
    {
        if (currentSlice == null) return;

        if (currentSlice == axialSlice)
        {
            currentSlice.transform.localPosition = axialStartPos + currentSlice.transform.forward * sliceValue;
        }
        else if (currentSlice == coronalSlice)
        {
            currentSlice.transform.localPosition = coronalStartPos + currentSlice.transform.forward * sliceValue;
        }
        else if (currentSlice == sagittalSlice)
        {
            currentSlice.transform.localPosition = sagittalStartPos + currentSlice.transform.forward * sliceValue;
        }
        SyncCrossSectionWithCurrentSlice();
    }


    public void ToggleCrossSectionPlane()
    {
        if (crossSectionPlane != null)
        {
            crossSectionPlane.SetActive(!crossSectionPlane.activeSelf);
            SyncCrossSectionWithCurrentSlice();
        }
    }

    private void SyncCrossSectionWithCurrentSlice()
    {
        if (crossSectionPlane == null || currentSlice == null) return;

        crossSectionPlane.transform.position = currentSlice.transform.position;
        crossSectionPlane.transform.rotation = currentSlice.transform.rotation;
    }
}