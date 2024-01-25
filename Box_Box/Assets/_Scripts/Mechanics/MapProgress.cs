using UnityEngine;
using UnityEngine.UI;

public class MapProgress : MonoBehaviour
{
    [Header("Slider")]
    public Slider ProgressSlider;
    [Header("Target Object: Player")]
    public Transform Player;
    private void Update()
    {
        ProgressSlider.value = Player.transform.position.x;
    }
}
