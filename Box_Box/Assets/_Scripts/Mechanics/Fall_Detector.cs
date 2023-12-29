using UnityEngine;

public class Fall_Detector : MonoBehaviour
{
    public Transform targetObject;

    private void Update()
    {
        transform.position = new Vector2 (targetObject.transform.position.x, transform.position.y);
    }
}
