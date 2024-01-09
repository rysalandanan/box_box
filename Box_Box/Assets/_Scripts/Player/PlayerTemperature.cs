using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerTemperature : MonoBehaviour
{
    [Header("Reference script: PlayerScript")]
    public PlayerScript playerScript;
    [Header("Player Temperature Settings")]
    public TextMeshProUGUI tempText;
    public float Temp;
    [SerializeField] private float TempIncreaseRate;
    [SerializeField] private float TempDecreaseRate;
    [SerializeField] private float ObstacleDamage;
    public float OriginalTemp;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        OriginalTemp = Temp;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if(playerScript.isGrounded() && playerScript._rb2D.velocity.x >= 0.01f)
        {
            Temp = Temp + TempIncreaseRate * Time.deltaTime;
        }
        else
        {
            Temp = Temp - TempDecreaseRate * Time.deltaTime;
        }
        Temp = Temp / 100 * 100;
        tempText.text = "Temperature: " + string.Format("{0:#.00} %", Temp);
        tempText.color = Color.green;
    }
    private void  OnTriggerEnter2D (Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            Temp = Temp + ObstacleDamage;
            StartCoroutine(PlayerHit());
        }
    }
    private IEnumerator PlayerHit()
    {
        var OriginalColor = spriteRenderer.color;
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.15f);
        spriteRenderer.color = OriginalColor;
    }
}
