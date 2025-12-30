using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float speed = 0.1f; 
    private Renderer render;

    void Start()
    {
        render = GetComponent<Renderer>();
    }

    void Update()
    {
        float offset = Time.time * speed;
        render.material.mainTextureOffset = new Vector2(offset, 0);
    }
}