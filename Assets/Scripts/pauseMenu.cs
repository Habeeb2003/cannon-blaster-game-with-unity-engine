using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class pauseMenu : MonoBehaviour
{
    public GameObject pauseMenuCanvas;
    private bool open = true;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenuCanvas.gameObject.SetActive(false);
    }

    public void PauseGame()
    {
        if (Time.timeScale == 1)
        {
            pauseMenuCanvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void ResumeGame()
    {
        if (Time.timeScale == 0)
        {
            StartCoroutine(BtnAnimWait("resume"));
        }
    }

    public void RestartGame()
    {
        StartCoroutine(BtnAnimWait("restart"));
    }

    public IEnumerator BtnAnimWait(string command)
    {
        switch (command)
        {
            case "resume":
                Time.timeScale = 1;
                EventSystem.current.currentSelectedGameObject.gameObject.GetComponent<Animator>().SetTrigger("click");
                yield return new WaitForSeconds(0.36f);
                pauseMenuCanvas.gameObject.GetComponent<Animator>().SetTrigger("resume");
                pauseMenuCanvas.gameObject.SetActive(false);
                break;
            case "restart":
                Time.timeScale = 1;
                EventSystem.current.currentSelectedGameObject.gameObject.GetComponent<Animator>().SetTrigger("click");
                yield return new WaitForSeconds(0.33f);
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                ScoreManager.score = 0;
                break;
            default:
                break;
        }
    }
}
