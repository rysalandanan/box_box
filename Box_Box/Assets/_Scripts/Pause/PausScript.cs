using System.Collections;
using UnityEditor;
using UnityEngine;

public class PausScript : MonoBehaviour
{
    public GameObject pauseMenu;
    private Animator animator;

    private void Start()
    {
        pauseMenu.SetActive(false);
        animator = transform.Find("Pause Menu").GetComponent<Animator>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !pauseMenu.activeInHierarchy)
        {
            PauseGame();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && pauseMenu.activeInHierarchy)
        {
            UnpauseGame();
        }
    }
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        animator.SetTrigger("Open");
    }
    private void UnpauseGame()
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
}
