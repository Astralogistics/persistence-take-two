using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    

    public Text highScore;

    // Start is called before the first frame update
    void Start()
    {
        highScore.text = $"Best Score : " + ScoreManager.instance.playerName + " : " + ScoreManager.instance.highScore;
    }

    // Update is called once per frame
    void Update()
    {
        if(ScoreManager.instance.playerName != null)
        {
            highScore.text = $"Best Score : " + ScoreManager.instance.playerName + " : " + ScoreManager.instance.highScore;
        }
    }
}
