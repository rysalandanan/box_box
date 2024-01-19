using UnityEngine;

public class Fan_PadsScript : MonoBehaviour
{
    public float PushPower;
    public bool isVerticalPad;
    public bool isHorizontalPad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector2 VerticalImpulse = new Vector2(0,PushPower);
        Vector2 HorizontalImpulse = new Vector2(PushPower,0);
        if(collision.gameObject.CompareTag("Player"))
        {
            if(isVerticalPad)
            {
                collision.attachedRigidbody.AddForce(VerticalImpulse, ForceMode2D.Impulse);
            }
            else if(isHorizontalPad)
            {
                collision.attachedRigidbody.AddForce(HorizontalImpulse, ForceMode2D.Impulse);
            }
        }
    }
}
