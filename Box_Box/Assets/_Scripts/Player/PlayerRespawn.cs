using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [Header("Reference Script: Player Temperature")]
    public PlayerTemperature playerTemperature;

    private Vector2 respawnPoint;

    [Header("Death screen")]
    public GameObject _deathScreen;
    void Start()
    {
        respawnPoint = transform.position;
    }
    private void Update()
    {
        if(playerTemperature.Temp >=100)
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
        if (_deathScreen.activeInHierarchy && Input.GetKey(KeyCode.Space))
        {
            transform.position = respawnPoint;
            playerTemperature.Temp = playerTemperature.OriginalTemp;
            _deathScreen.SetActive(false);
        }
    }

}
