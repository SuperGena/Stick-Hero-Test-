using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;


    [SerializeField]
    private GameObject startGamePanel;
    [SerializeField]
    private GameObject endGamePanel;
    [SerializeField]
    private GameObject gameScorePanel;
    [SerializeField]
    private Text score;
    [SerializeField]
    private Text endScore;
    [SerializeField]
    private Text bestScore;


    private bool isActive;


    internal bool isStart;
    internal bool isGameOver;


    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

	
	void Start ()
    {
        isActive = false;
        isGameOver = false;
    }
	
	
	void Update ()
    {
		score.text = PlayerPrefs.GetInt("score").ToString();
    }


    public void ShowScore()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
    }


    public void StartGame()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        
        startGamePanel.SetActive(false);
        gameScorePanel.SetActive(true);

        isStart = true;
        isGameOver = false;
    }


    public void EndGame()
    {
        isActive = true;
        isGameOver = true;
        endScore.text = PlayerPrefs.GetInt("score").ToString();
        bestScore.text = PlayerPrefs.GetInt("bestScore").ToString();

        endGamePanel.SetActive(isActive);
        gameScorePanel.SetActive(false);

        GameManager.instance.gameOver = true;

    }


    public void ResetGame()
    {
        isActive = false;
        isGameOver = false;
        endGamePanel.SetActive(isActive);

        GameManager.instance.ResetGame();
    }
}
