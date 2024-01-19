using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player settings")]
    public float PlayerMovementSpeed;
    public float PlayerJumpingPower;
    public float PlayerSpeedLimit;
    [HideInInspector] public Rigidbody2D Rb2D;
    private BoxCollider2D _bc2D;

    //Coyote time//
    private float _coyoteTime = 0.2f;
    private float _coyoteTimeCounter;

    //Jump buffer//
    private float _jumpBufferTime = 0.2f;
    private float _jumpBufferCounter;

    //Ground check//
    [SerializeField] private LayerMask CanJump;
    void Start()
    {
        Rb2D = GetComponent<Rigidbody2D>();
        _bc2D = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        Movement();
        Jump();
    }
    private void Movement()
    {
        if (Rb2D.velocity.x <= PlayerSpeedLimit)
        {
            Rb2D.AddForce(transform.right * PlayerMovementSpeed * Time.deltaTime);
        }
    }
    private void Jump()
    {
        if (isGrounded())
        {
            _coyoteTimeCounter = _coyoteTime;
        }
        else
        {
            _coyoteTimeCounter -= Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _jumpBufferCounter = _jumpBufferTime;
        }
        else
        {
            _jumpBufferCounter -= Time.deltaTime;
        }
        if (_coyoteTimeCounter > 0f && _jumpBufferCounter > 0f)
        {
            Rb2D.velocity = new Vector2(Rb2D.velocity.x, PlayerJumpingPower);
            _jumpBufferCounter = 0f;
        }
        if (Input.GetButtonUp("Jump") && Rb2D.velocity.y > 0f)
        {
            Rb2D.velocity = new Vector2(Rb2D.velocity.x, Rb2D.velocity.y * 0.5f);
            _coyoteTimeCounter = 0f;
        }
    }
    public bool isGrounded()
    {
        var bounds = _bc2D.bounds;
        return Physics2D.BoxCast(bounds.center, bounds.size, 0f, Vector2.down, 0.2f, CanJump);
    }
}
