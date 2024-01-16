using UnityEngine;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    public Slider slider;
    public AudioSource audioSource;
    public Button volButton;
    public Sprite[] VolumeImage;
    private float originalVol;

    private void Start()
    {
        slider.value = 1f;
        volButton.GetComponent<Button>();
    }
    public void VolumeChange()
    {
        audioSource.volume = slider.value;
        if (slider.value >= 0.001f)
        {
            volButton.GetComponent<Image>().sprite = VolumeImage[1];
        }
        else
        {
            volButton.GetComponent<Image>().sprite = VolumeImage[0];
        }
    }
    public void MuteandUnmuteButton()
    {
        if(slider.value >= 0.001f)
        {
            //mute
            originalVol = slider.value;
            slider.value = 0f;
            volButton.GetComponent<Image>().sprite = VolumeImage[0];
        }
        else
        {
            slider.value = originalVol;
            volButton.GetComponent<Image>().sprite = VolumeImage[1];
        }
    }
    public void VolumeUp()
    {
        slider.value += 0.05f;
    }
    public void VolumeDown()
    {
        slider.value -= 0.05f;
    }
}
