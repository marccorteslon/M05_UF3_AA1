using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 12f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    public Transform cameraTransform;
    public float maxCameraOffset = 2f;
    public float cameraMoveSpeed = 7f;

    private Rigidbody2D rb;
    private bool isGrounded;
    private float horizontal;
    private Vector3 targetCameraPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Entrada horizontal
        horizontal = Input.GetAxisRaw("Horizontal");

        // Comprobar si está tocando el suelo
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Salto
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // Flip visual
        if (horizontal > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (horizontal < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        // Cámara sigue al jugador con un offset horizontal
        Vector3 offset = new Vector3(horizontal * maxCameraOffset, 0f, 0f);
        targetCameraPosition = transform.position + offset;
        targetCameraPosition.z = cameraTransform.position.z;

        cameraTransform.position = Vector3.MoveTowards(
            cameraTransform.position,
            targetCameraPosition,
            cameraMoveSpeed * Time.deltaTime
        );
    }

    void FixedUpdate()
    {
        // Movimiento horizontal con física
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
}
