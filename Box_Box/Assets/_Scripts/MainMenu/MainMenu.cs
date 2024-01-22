using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject HowToPlayPanel;
    public GameObject CreditsPanel;
    public void PlayButton()
    {
        SceneManager.LoadScene("Main");
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void HowToPlayButton()
    {
        HowToPlayPanel.SetActive(true);
    }
    public void CreditsButton()
    {
        CreditsPanel.SetActive(true);
    }
    
}
