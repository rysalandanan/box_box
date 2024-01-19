using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [Header("Reference Script: Player Temperature")]
    public PlayerTemperature PlayerTemperature;

    [Header("Reference Script: Player Script")]
    public PlayerMovement PlayerMovement;

    private Vector2 _respawnPoint;

    [Header("Death screen")]
    public GameObject _deathScreen;
    void Start()
    {
        _respawnPoint = transform.position;
    }
    private void Update()
    {
        if(PlayerTemperature.PlayerTemp >=100)
        {
            _deathScreen.SetActive(true);
        }
        Respawn();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Fall_Detector"))
        {
            _deathScreen.SetActive(true);
        }
    }
    private void Respawn()
    {
        if (_deathScreen.activeInHierarchy && Input.anyKey)
        {
            transform.position = _respawnPoint;
            PlayerMovement.Rb2D.velocity = Vector2.zero;
            PlayerTemperature.PlayerTemp = PlayerTemperature.DefaultPlayerTemperature;
            _deathScreen.SetActive(false);
        }
    }

}
