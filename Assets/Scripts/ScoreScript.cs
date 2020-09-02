using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public int leftScore, rightScore;
    public Text p1_score, p2_score;

    public int winningScore;
    
    public static ScoreScript S;

    void Awake() {
        S = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        ResetScore();
    }

    public void UpdateScore(int scorer)
    {
        if (scorer == 0)
        {
            leftScore++;
            p1_score.text = leftScore.ToString();
        }

        if (scorer == 1)
        {
            rightScore++;
            p2_score.text = rightScore.ToString();
        }
        
        Debug.Log(leftScore + " : " + rightScore);
    }

    public void ResetScore()
    {
        leftScore = 0;
        rightScore = 0;
        
    }
}
