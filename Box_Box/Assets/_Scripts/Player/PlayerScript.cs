using System.Collections;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Player settings")]
    public float playerSpeed;
    public float playerJumpPower;
    public float playerSpeedLimit;

    public Rigidbody2D _rb2D;
    private BoxCollider2D _bc2D;

    //Coyote time//
    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    //Jump buffer//
    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

    //Ground check//
    [SerializeField] private LayerMask canJump;
    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _bc2D = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        PlayerMovement();
        PlayerJump();
    }
    private void PlayerMovement()
    {
        if (_rb2D.velocity.x <= playerSpeedLimit)
        {
            _rb2D.AddForce(transform.right * playerSpeed * Time.deltaTime);
        }
    }
    private void PlayerJump()
    {
        if (isGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }
        if (coyoteTimeCounter > 0f && jumpBufferCounter > 0f)
        {
            _rb2D.velocity = new Vector2(_rb2D.velocity.x, playerJumpPower);
            jumpBufferCounter = 0f;
        }
        if (Input.GetButtonUp("Jump") && _rb2D.velocity.y > 0f)
        {
            _rb2D.velocity = new Vector2(_rb2D.velocity.x, _rb2D.velocity.y * 0.5f);
            coyoteTimeCounter = 0f;
        }
    }
    public bool isGrounded()
    {
        var bounds = _bc2D.bounds;
        return Physics2D.BoxCast(bounds.center, bounds.size, 0f, Vector2.down, 0.2f, canJump);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Jump_Pad"))
        {
            StartCoroutine(UseJumpPad());
        }
        if(collision.gameObject.CompareTag("Fan_Pad"))
        {
            _rb2D.velocity = new Vector2(playerJumpPower * 5, _rb2D.velocity.x);
        }
    }
    private IEnumerator UseJumpPad()
    {
        yield return new WaitForSeconds(0.15f);
        _rb2D.velocity = new Vector2(_rb2D.velocity.x, playerJumpPower * 5);
    }
}
