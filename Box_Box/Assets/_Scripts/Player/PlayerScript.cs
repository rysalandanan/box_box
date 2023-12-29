using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Player settings")]
    public float playerSpeed;
    public float playerJumpPower;

    private Rigidbody2D _rb2D;
    private BoxCollider2D _bc2D;
    private TrailRenderer _tr;

    private Vector2 RespawnPoint;

    [Header("Death screen")]
    public GameObject deathScreen;

    //Coyote time//
    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    //Jump buffer//
    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

    [SerializeField] private LayerMask canJump;
    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _bc2D = GetComponent<BoxCollider2D>();
        _tr = GameObject.Find("Trail").GetComponent<TrailRenderer>();
        RespawnPoint = transform.position;
    }
    void Update()
    {
        PlayerMovement();
        PlayerJump();
        PlayerRespawn();
    }
    private void PlayerMovement()
    {
        transform.position += transform.right * playerSpeed * Time.deltaTime;
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
            _rb2D.velocity = new Vector2(_rb2D.velocity.x,playerJumpPower);
            jumpBufferCounter = 0f;
        }
        if (Input.GetButtonUp("Jump") && _rb2D.velocity.y > 0f)
        {
            _rb2D.velocity = new Vector2(_rb2D.velocity.x, _rb2D.velocity.y * 0.5f);
            coyoteTimeCounter = 0f;
        }
    }
    private bool isGrounded()
    {
        var bounds = _bc2D.bounds;
        return Physics2D.BoxCast(bounds.center, bounds.size, 0f, Vector2.down, 0.2f, canJump);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Fall_Detector"))
        {
            deathScreen.SetActive(true);
        }
    }
    private void PlayerRespawn()
    {
        if(deathScreen.activeInHierarchy && Input.anyKey)
        {
            _tr.emitting = false;
            transform.position = RespawnPoint;
            deathScreen.SetActive(false);
            _tr.emitting = true;
        }
    }
}
