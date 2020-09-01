using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public int leftScore, rightScore;
    
    public static ScoreScript S;

    void Awake() {
        S = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        ResetScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int scorer)
    {
        if (scorer == 0) leftScore++; 
        if (scorer == 1) rightScore++;
        
        Debug.Log(leftScore + " : " + rightScore);
    }

    public void ResetScore()
    {
        leftScore = 0;
        rightScore = 0;
        
    }
}
