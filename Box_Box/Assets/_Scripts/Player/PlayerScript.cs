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
        if (Input.GetKey(KeyCode.UpArrow) && isGrounded())
        {
            _rb2D.velocity = new Vector2(_rb2D.velocity.x, playerJumpPower);
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
