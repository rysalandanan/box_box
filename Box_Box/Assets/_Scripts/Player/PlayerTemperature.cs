using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerTemperature : MonoBehaviour
{
    [Header("Reference script: PlayerScript")]
    public PlayerMovement PlayerScript;
    [Header("Player Temperature Settings")]
    public TextMeshProUGUI TemperatureUIText;
    [SerializeField] public float PlayerTemp;
  
    public float TemperatureIncreaseRate;
    public float TemperatureDecreaseRate;
    public float TemperatureDamage;
    [HideInInspector] public float DefaultPlayerTemperature;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        DefaultPlayerTemperature = PlayerTemp;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if(PlayerScript.isGrounded() && PlayerScript.Rb2D.velocity.x >= 0.01f)
        {
            PlayerTemp += TemperatureIncreaseRate * Time.deltaTime;
        }
        else
        {
            PlayerTemp -= TemperatureDecreaseRate * Time.deltaTime;
        }
        PlayerTemp = PlayerTemp / 100 * 100;
        TemperatureUIText.text = "Temperature: " + string.Format("{0:#.00} %", PlayerTemp);
        TemperatureUIText.color = Color.green;
    }
    private void  OnTriggerEnter2D (Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            PlayerTemp = PlayerTemp + TemperatureDamage;
            StartCoroutine(PlayerHit());
        }
    }
    private IEnumerator PlayerHit()
    {
        var OriginalColor = spriteRenderer.color;
        spriteRenderer.color = Color.black;
        yield return new WaitForSeconds(0.15f);
        spriteRenderer.color = OriginalColor;
    }
}
