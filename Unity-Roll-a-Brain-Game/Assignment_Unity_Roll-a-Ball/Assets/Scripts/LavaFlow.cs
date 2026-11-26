using UnityEngine;

public class LavaFlow : MonoBehaviour

{
    public float speedx = 0.01f;
    public float speedy = 0.0f;
    private Material mat;
    private Vector4 uvOffset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Renderer rend = GetComponent<Renderer>();
        mat = rend.material;
        if (!mat.HasProperty("_UvOffset"))
        {
            Debug.LogError("Wronger Shader - Lava Flow");
            return;
        }
        uvOffset = mat.GetVector("_UvOffset");
        Debug.Log("Initial _UvOffset: " + uvOffset);
    }

    // Update is called once per frame
    void Update()
    {
        uvOffset.x += speedx * Time.deltaTime;
        uvOffset.y += speedy * Time.deltaTime;
        mat.SetVector("_UvOffset", uvOffset);
    }
}
