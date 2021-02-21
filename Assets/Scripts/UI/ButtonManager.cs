using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//PURPOSE:Managing Buttons in Title/GameScene
//USAGE: Place in scenes to control buttons
public class ButtonManager : MonoBehaviour
{
    public GameObject optionsPanel;
    public GameObject pauseMenuBM;
   
    // Start is called before the first frame update
    void Start()
    {
        optionsPanel.SetActive(false);
        pauseMenuBM.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayGame()//go to game scene
    {
        SceneManager.LoadScene("GameScene");
    }
    public void Options()//open up options panel works for both in game and in title
    {
        optionsPanel.SetActive(true);
       
    }
    public void BackToTitle()//from whatever things youre looking at go back to the title/start screen
    {
        optionsPanel.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("TitleScene");
    }
    public void PauseToMain()//from the pause menu head back to the start screen
    {
        Time.timeScale = 1f;
        optionsPanel.SetActive(false);
        SceneManager.LoadScene("TitleScene");

    }
    public void PauseToOption()
    {
        optionsPanel.SetActive(false);
       
    }
    public void LevelTwo()
    {
        SceneManager.LoadScene("LevelTwo");


    }

    public void LevelThree()
    {
        SceneManager.LoadScene("LevelThree");
    }
}
