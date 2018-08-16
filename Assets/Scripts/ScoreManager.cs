using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    internal int score;
    internal int highScore;


    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

	
	void Start ()
    {
        score = 0;
        PlayerPrefs.SetInt("score", score - 1);
	}
	
	
	void Update ()
    {		
        PlayerPrefs.SetInt("score", score - 1);
    }


    internal void IncrementScore()
    {
        score += 1;
    }


    internal void StopScore()
    {
        PlayerPrefs.SetInt("score", score - 1);

        if (PlayerPrefs.HasKey("bestScore"))
        {
            if(score - 1 > PlayerPrefs.GetInt("bestScore"))
            {
                PlayerPrefs.SetInt("bestScore", score - 1);
            }
        }
        else
        {
            PlayerPrefs.SetInt("bestScore", score - 1);
        }
    }


    internal void Reset()
    {
        score = 0;
        PlayerPrefs.SetInt("score", score - 1);
    }
}
