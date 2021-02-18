using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//PURPOSE:Managing Buttons in Title/GameScene
//USAGE: Place in scenes to control buttons
public class ButtonManager : MonoBehaviour
{
    public GameObject optionsPanel;
   
    // Start is called before the first frame update
    void Start()
    {
        optionsPanel.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayGame()//go to game scene
    {
        SceneManager.LoadScene("GameScene");
    }
    public void Options()//open up tions panel
    {
        optionsPanel.SetActive(true);
    }
    public void BackToTitle()//from whatever things youre looking at go back to the title screen
    {
        optionsPanel.SetActive(false);
    }
    public void LevelTwo()
    {
        SceneManager.LoadScene("LevelTwo");
    }
}
