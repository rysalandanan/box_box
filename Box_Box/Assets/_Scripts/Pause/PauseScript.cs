using System.Collections;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject deathScreen;
    public GameObject settingsMenu;
    private Animator animator;
    private void Start()
    {
        animator = transform.Find("Pause Menu").GetComponent<Animator>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !pauseMenu.activeInHierarchy)
        {
            if(!deathScreen.activeInHierarchy)
            {
                PauseGame();
            }
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && pauseMenu.activeInHierarchy)
        {
            if (settingsMenu.activeInHierarchy)
            {
                CloseSettings();
            }
            else
            {
                UnpauseGame();
            }
        }
    }
    private void PauseGame()
    {
        pauseMenu.SetActive(true);
        animator.SetTrigger("Open");
    }
    public void UnpauseGame()
    {
        animator.SetTrigger("Close");
        animator.ResetTrigger("Open");
        StartCoroutine(ClosePauseMenu());
    }
    private IEnumerator ClosePauseMenu()
    {
        animator.SetTrigger("Close");
        yield return new WaitForSecondsRealtime(0.5f);
        animator.ResetTrigger("Close");
        pauseMenu.SetActive(false);
    }
    public void OpenSettings()
    {
        settingsMenu.SetActive(true);
    }
    public void CloseSettings()
    {
        settingsMenu.SetActive(false);
    }
}
