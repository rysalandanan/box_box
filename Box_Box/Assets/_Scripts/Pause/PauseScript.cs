using System.Collections;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject DeathScreen;
    public GameObject SettingsMenu;
    private Animator _animator;
    [SerializeField] private AudioSource _openPauseMenuSFX;
    [SerializeField] private AudioSource _closePauseMenuSFX;
    [SerializeField] private AudioSource _openSettingsMenuSFX;
    [SerializeField] private AudioSource _closeSettingsMenuSFX;
    private void Start()
    {
        _animator = PauseMenu.GetComponent<Animator>(); 
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !PauseMenu.activeInHierarchy)
        {
            if(!DeathScreen.activeInHierarchy)
            {
                PauseGame();
            }
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && PauseMenu.activeInHierarchy)
        {
            if (SettingsMenu.activeInHierarchy)
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
        _openPauseMenuSFX.Play();
        PauseMenu.SetActive(true);
        _animator.SetTrigger("Open");
    }
    public void UnpauseGame()
    {
        _closePauseMenuSFX.Play();
        _animator.SetTrigger("Close");
        _animator.ResetTrigger("Open");
        StartCoroutine(ClosePauseMenu());
    }
    private IEnumerator ClosePauseMenu()
    {
        _animator.SetTrigger("Close");
        yield return new WaitForSecondsRealtime(0.5f);
        _animator.ResetTrigger("Close");
        PauseMenu.SetActive(false);
    }
    public void OpenSettings()
    {
        _openSettingsMenuSFX.Play();
        SettingsMenu.SetActive(true);
    }
    public void CloseSettings()
    {
        _closeSettingsMenuSFX.Play(); 
        SettingsMenu.SetActive(false);
    }
}
