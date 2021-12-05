using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{   
    [SerializeField]
    public TextMeshProUGUI finalScore;

    public GameObject startPanel;
    public GameObject gamePlay;
    public GameObject gameOver;
    public GameObject Load;
    // Start is called before the first frame update
    void Start()
    {
        startPanel.SetActive(true);     //start panel displayed at start, rest is disabled
        gamePlay.SetActive(false);
        gameOver.SetActive(false);
        GameController.isRoundActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()             //function to start game and enable loading image
    {   
        Load.SetActive(true);
        StartCoroutine(LoadGame());

    }

    public void GameOver()          //function to end game
    {
        gamePlay.SetActive(false);
        gameOver.SetActive(true);
        GameController.playerScore += GameController.timeRemaining;     // calculate final score
        finalScore.text = "Final Score: " + Mathf.Round(GameController.playerScore).ToString();     //display final score


    }

    IEnumerator LoadGame()          // subroutine to add delay to start game in order to load the questions
    {
        yield return new WaitForSeconds(5);
        startPanel.SetActive(false);
        gamePlay.SetActive(true);
        GameController.isRoundActive = true;
        Load.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
