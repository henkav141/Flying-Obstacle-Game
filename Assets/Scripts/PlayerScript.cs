using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    public Vector2 JumpForce = new Vector3(0.0f, 200.0f, 0.0f);
    public int Lives = 5;
    public int Score;
    public static int OldScore;
    public Text ScoreText;
    public Text LivesText;
    public Text HighScoreText;
    public Text GoalText;
    public Text EndText;
    bool counter;



    // Use this for initialization
    void Start()
    {
        GoalText.text = String.Empty;
        EndText.text = String.Empty;
        HighScoreText.text = "Highscore: " + OldScore;
        LivesText.text = "Lives: " + Lives;
        counter = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().AddForce(JumpForce);
        }
        PlayerControl();
        if (counter == true)
        {
            SetScoreText();
        }

        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        Lives--;
        setLivesText();
        if (Lives == 0)
        {
            if (Score > OldScore)
            {
                OldScore = Score;
                HighScoreText.text = "Highscore: " + OldScore;
            }
            else
            {
                HighScoreText.text = "Highscore: " + OldScore;
            }
            SceneManager.LoadScene(0);
        }
        if (collision.gameObject.tag == "goal")
        {
            counter = false;
            showGoalText();
        }
    }

    public void SetScoreText()
    {
        ScoreText.text = "Score: " + Score++;
    }

    public void setLivesText()
    {
        LivesText.text = "Lives: " + Lives;

    }

    private void PlayerControl()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.forward * 7);
        else if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.forward * -7);
    }

    public void showGoalText()
    {
        GoalText.text = "You completed the game!";
        EndText.text = "Press 'R' to play again," + "\n" + " Press 'Esc' to quit";

    }
}
