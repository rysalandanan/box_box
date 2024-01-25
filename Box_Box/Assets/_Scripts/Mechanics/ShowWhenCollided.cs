using UnityEngine;

public class ShowWhenCollided : MonoBehaviour
{
    public GameObject GameEnd;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameEnd.SetActive(true);
        }
    }
}
