using UnityEngine;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    public Slider Slider;
    public AudioSource AudioSource;
    public Button ButtonImage;
    public Sprite[] VolumeImage;
    private float originalVol;

    private void Start()
    {
        AudioSource.volume = Slider.value;
        ButtonImage.GetComponent<Button>();
    }
    public void VolumeChange()
    {
        AudioSource.volume = Slider.value;
        if (Slider.value >= 0.001f)
        {
            ButtonImage.GetComponent<Image>().sprite = VolumeImage[1];
        }
        else
        {
            ButtonImage.GetComponent<Image>().sprite = VolumeImage[0];
        }
    }
    public void MuteandUnmuteButton()
    {
        if(Slider.value >= 0.001f)
        {
            originalVol = Slider.value;
            Slider.value = 0f;
            ButtonImage.GetComponent<Image>().sprite = VolumeImage[0];
        }
        else
        {
            Slider.value = originalVol;
            ButtonImage.GetComponent<Image>().sprite = VolumeImage[1];
        }
    }
    public void VolumeUp()
    {
        Slider.value += 0.05f;
    }
    public void VolumeDown()
    {
        Slider.value -= 0.05f;
    }
}
