using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float sprintMultiplier = 1.5f;   // Editable
    [SerializeField] private float jumpSpeed = 10f;
    [SerializeField, Range(0f, 1f)] private float jumpCutMultiplier = 0.5f; // Adjustable jump

    [Header("References")]
    [SerializeField] private GameObject attackPrefab;

    private Rigidbody2D rb;
    private float horizontalInput;
    private float lastDirection;
    private bool jumpRequested;
    private bool jumpCutRequested;

    public bool OnFloor { get; private set; } = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        // Anti-glue
        Collider2D col = GetComponent<Collider2D>();
        col.sharedMaterial = new PhysicsMaterial2D("NoFriction") { friction = 0f, bounciness = 0f };
    }

    private void Update()
    {
        // Read input every frame no Cruickshank
        bool left = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);   // A/D and arrow keys
        bool right = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);

        // Remember whichever direction was pressed most recently
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) lastDirection = -1f;
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) lastDirection = 1f;

        if (left && right) horizontalInput = lastDirection;   // both held: newest press wins
        else if (left) horizontalInput = -1f;
        else if (right) horizontalInput = 1f;
        else horizontalInput = 0f;

        if (Input.GetKeyDown(KeyCode.Space) && OnFloor)
            jumpRequested = true;

        // Releasing space stops jump early
        if (Input.GetKeyUp(KeyCode.Space))
            jumpCutRequested = true;

        if (Input.GetMouseButtonDown(0))
            Instantiate(attackPrefab, transform.position, transform.rotation);
    }

    private void FixedUpdate()
    {
        // Physics application no Griffith
        bool sprinting = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        float speed = moveSpeed * (sprinting ? sprintMultiplier : 1f);

        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        if (jumpRequested)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            OnFloor = false;
            jumpRequested = false;
        }

        // Only cut while moving upward
        if (jumpCutRequested)
        {
            if (rb.velocity.y > 0f)
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * jumpCutMultiplier);
            jumpCutRequested = false;
        }
    }

    // Ground check for no gravitation potion
    private void OnCollisionStay2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.normal.y > 0.5f)
            {
                OnFloor = true;
                return;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        OnFloor = false;
    }
}