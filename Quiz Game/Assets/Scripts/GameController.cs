using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{   
    [SerializeField]            //Button variables
    private Button option1;
    private Button option2;
    private Button option3;
    private Button option4;
    
    [SerializeField]                    //Text of the buttons
    private TextMeshProUGUI op1Text;
    private TextMeshProUGUI op2Text;
    private TextMeshProUGUI op3Text;
    private TextMeshProUGUI op4Text;
    private TextMeshProUGUI questionDisplayText;     //question text
    private TextMeshProUGUI scoreDisplayText;        //Score text
    private TextMeshProUGUI timeRemainingDisplayText;    //Time Remaining Text
    private TextMeshProUGUI questionNumberText;      //Question number text


    public static float playerScore = 0;        // float to calculate score
    public int questionIndex = 0;               // question number index
    
    public jsonController jsonController;       //reference to jsoncontroller script
    public static float timeRemaining = 60;     //float to countdown timer
    public static bool isRoundActive;           // bool to check if game is playing
    public GameUI gameUI;                       // reference to gameui script
    

    // Start is called before the first frame update
    void Start()
    {
        op1Text = option1.GetComponentInChildren<TextMeshProUGUI>();        //Get reference of the text of the buttons
        op2Text = option2.GetComponentInChildren<TextMeshProUGUI>();
        op3Text = option3.GetComponentInChildren<TextMeshProUGUI>();
        op4Text = option4.GetComponentInChildren<TextMeshProUGUI>();
        jsonController = FindObjectOfType<jsonController>();                // Find object with jsoncontroller script

        
       
       

    }

    // Update is called once per frame
    void Update()
    {
       
        if (isRoundActive)                                              // if round is active
        {
           
            timeRemaining -= Time.deltaTime;                            //run countdown timer by reducing 1 in every second
            UpdateTimeRemainingDisplay();

            //if time is 0 or less end round
            if (timeRemaining <= 0f)                                    // when timer reaches 0, game is stopped
            {
                EndRound();
            }
        }

        scoreDisplayText.text = "Score: " + playerScore;                //score is updated in every frame.
    }

    private void UpdateTimeRemainingDisplay()                           //function to display timer
    {
        timeRemainingDisplayText.text = "Time: " + Mathf.Round(timeRemaining).ToString();
    }

    public void EndRound()                                              //function to end game
    {
        isRoundActive = false;
        gameUI.GameOver();

    }

    IEnumerator initialise()                                        //initialise the questions at first
    {
        yield return new WaitForSeconds(5);                         //since it takes time for jsoncontroller to retrieve data, a delay is given

         
        ChangeQuestion();                                           //call function to initialise question
        
    }

    public void StartGame()                                         //function to start the game 
    {
        gameUI.StartGame();
        StartCoroutine(initialise());
    }

    public void Option1()                                           //option 1 button
    {
        int index = 0;                                              // index of option 1 button is set as 0
        if(index == jsonController.myObject.qanda[questionIndex].correctOptionIndex)        //it is compared with correctoptionindex to check if answer is correct
        {
            playerScore += 10;                                      //if this option is correct, player score added by 10
        }
        if (questionIndex < jsonController.myObject.qanda.Length)   //if limit of questions is not reached
        {
            questionIndex++;                                        // increment question index
            ChangeQuestion();                                       //  change current question to next
        }
        else
        {
            EndRound();                                             //if limit is reached then end game
        }

        
    }
    public void Option2()                                           // button for option 2 with same functionalities
    {
        int index = 1;
        if (index == jsonController.myObject.qanda[questionIndex].correctOptionIndex)
        {
            playerScore += 10;
        }
        if (questionIndex < jsonController.myObject.qanda.Length)
        {
            questionIndex++;
            ChangeQuestion();
        }
        else
        {
            EndRound();
        }

        
    }
    public void Option3()                                       // button for option 3 with same functionalities
    {
        int index = 2;
        if (index == jsonController.myObject.qanda[questionIndex].correctOptionIndex)
        {
            playerScore += 10;
        }
        if (questionIndex < jsonController.myObject.qanda.Length)
        {
            questionIndex++;
            ChangeQuestion();
        }
        else
        {
            EndRound();
        }

        
    }
    public void Option4()                                   // button for option 4 with same functionalities
    {
        int index = 3;
        if (index == jsonController.myObject.qanda[questionIndex].correctOptionIndex)
        {
            playerScore += 10;
        }
        if (questionIndex < jsonController.myObject.qanda.Length)
        {
            questionIndex++;
            ChangeQuestion();
        }
        else
        {
            EndRound();
        }

        
    }

    public void ChangeQuestion()                    //function to change question
    {
        if (questionIndex == jsonController.myObject.qanda.Length)      //if limit of questions is reached
        {
            EndRound();                               // end game
        }   
        else
        {
            questionDisplayText.text = jsonController.myObject.qanda[questionIndex].question;       //else change the text
            questionNumberText.text = (questionIndex + 1).ToString();
            ChangeOptions();        // call function to change options text also
        }
    }

    public void ChangeOptions()     //function to change the text of the buttons to the next options
    {   
        
        op1Text.text = jsonController.myObject.qanda[questionIndex].options[0];
        op2Text.text = jsonController.myObject.qanda[questionIndex].options[1];
        op3Text.text = jsonController.myObject.qanda[questionIndex].options[2];
        op4Text.text = jsonController.myObject.qanda[questionIndex].options[3];
    }
}
