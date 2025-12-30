using UnityEngine;

public class FishingController : MonoBehaviour
{
    [Header("Boat Settings")]
    public float moveSpeed = 5f;
    public float xLimit = 8f;
    [Header("Hook Settings")]
    public Transform hookOrigin;
    public Transform hookObject;
    public float hookSpeed = 3f;
    public float maxDepth = -4f;

    private LineRenderer lineRenderer;
    private Quaternion initialHookRotation = Quaternion.identity;
    private bool isFacingRight = true; 

    void Start()
    {
        lineRenderer = hookObject.GetComponent<LineRenderer>();
        if (lineRenderer == null) 
            lineRenderer = hookObject.gameObject.AddComponent<LineRenderer>();
        
        lineRenderer.positionCount = 2;
        lineRenderer.useWorldSpace = true;
    }

    void Update()
    {
        HandleMovement();
        HandleHook();
        DrawRope();
    }

    void HandleMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");


        Vector3 movement = new Vector3(horizontal * moveSpeed * Time.deltaTime, 0, 0);
        transform.position += movement;


        float clampedX = Mathf.Clamp(transform.position.x, -xLimit, xLimit);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
        if (horizontal > 0 && !isFacingRight) 
        {
            FlipShip(true);
        }
        else if (horizontal < 0 && isFacingRight) 
        {
            FlipShip(false);
        }
    }

    void FlipShip(bool faceRight)
    {
        isFacingRight = faceRight;
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

       
        Vector3 scale = transform.localScale;
        scale.x = faceRight ? Mathf.Abs(scale.x) : -Mathf.Abs(scale.x);
        transform.localScale = scale;
        
     
    }

    void HandleHook()
    {
       
        if (Input.GetMouseButton(0))
        {
            hookObject.position += Vector3.down * hookSpeed * Time.deltaTime;
            if (hookObject.position.y < maxDepth)
                hookObject.position = new Vector3(hookObject.position.x, maxDepth, hookObject.position.z);
        }
        else
        {hookObject.position = Vector3.MoveTowards(hookObject.position, hookOrigin.position, hookSpeed * Time.deltaTime);}
        hookObject.position = new Vector3(hookOrigin.position.x, hookObject.position.y, hookObject.position.z);
        hookObject.rotation = initialHookRotation;
    }

    void DrawRope()
    {
        lineRenderer.SetPosition(0, hookOrigin.position);
        lineRenderer.SetPosition(1, hookObject.position);
    }
}