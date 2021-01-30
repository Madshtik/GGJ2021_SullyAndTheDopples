using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject levelSelectPanel;
    public GameObject creditsPanel;

    public void OpenLevelSelectPanel()
    {
        if (!levelSelectPanel.activeInHierarchy)
        {
            levelSelectPanel.SetActive(true);
        }
    }
    
    public void OpenCreditsPanel()
    {
        if (!creditsPanel.activeInHierarchy)
        {
            creditsPanel.SetActive(true);
        }
    }
    
    public void ClosePanel()
    {
        if (levelSelectPanel.activeInHierarchy || creditsPanel.activeInHierarchy)
        {
            levelSelectPanel.SetActive(false);
            creditsPanel.SetActive(false);
        }
    }

    public void PlayLevelOne()//put scene number input once level 1 and 2 are done
    {
        Debug.Log("Loading Level 1");
        SceneManager.LoadScene(1);
    }

    public void PlayLevelOTwo()
    {
        Debug.Log("Loading Level 2");
        //SceneManager.LoadScene();
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }
}
