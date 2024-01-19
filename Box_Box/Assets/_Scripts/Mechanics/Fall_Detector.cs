using UnityEngine;

public class Fall_Detector : MonoBehaviour
{
    public Transform TargetObject;

    private void Update()
    {
        transform.position = new Vector2 (TargetObject.transform.position.x, transform.position.y);
    }
}
