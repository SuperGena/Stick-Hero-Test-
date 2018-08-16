using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    [SerializeField]
    private GameObject spawnPlayer;
    [SerializeField]
    private GameObject spawnPlatform;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject platform;


    GameObject[] gameObjects;
    Vector3 pos;


    public bool gameOver;


    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }


	void Start ()
    {
        gameOver = false;
	}
	
	
	void Update ()
    {
        gameObjects = GameObject.FindGameObjectsWithTag("LandObject");

        if (!gameOver)
        {
            MusicManager.instance.Play();
        }
    }


    void DestroyPlatforms()
    {
        if (gameOver)
        {
            for (int i = 0; i < gameObjects.Length; i++)
            {
                Destroy(gameObjects[i]);
            }
        }
    }


    internal void StartGame()
    {
        UiManager.instance.StartGame();
    }


    internal void StopGame()
    {
        gameOver = true;
        ScoreManager.instance.StopScore();
        UiManager.instance.EndGame();
    }


    internal void ResetGame()
    {
        DestroyPlatforms();
        gameOver = false;

        Instantiate(platform);

        pos = player.transform.position;
        pos.z = 0;
        player.transform.position = pos;
        player.transform.position = spawnPlayer.transform.position;
        platform.transform.position = spawnPlatform.transform.position;
        
        ScoreManager.instance.Reset();

        Camera.main.GetComponent<CameraFollow>().isGameOver = false;
        UiManager.instance.isStart = true;

        UiManager.instance.StartGame();
        Camera.main.GetComponent<CameraFollow>().Reset();

    }
}
