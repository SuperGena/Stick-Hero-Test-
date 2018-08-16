using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetings : MonoBehaviour
{
    [SerializeField]
    private GameObject landCheck;


    internal bool isGameOver;
    internal bool isGround;
    internal float trigger;

    private bool isReady;
    private float distToGround = 5f;
    private Vector3 gameOverPosition;


    void Start ()
    {
        isGameOver = false;
        trigger = 0;
        isReady = true;
	}


	void Update ()
    {

        if (!CheckIsGrounded())
        {
            Debug.Log("CheckIsGrounded " + CheckIsGrounded());
            isGameOver = true;
            
        }
        else
        {
            isGameOver = false;
        }

        if (!UiManager.instance.isStart)
        {
            GetComponent<Rigidbody>().useGravity = false;
        }
        else
        {
            GetComponent<Rigidbody>().useGravity = true;
        }
       
        if (isGameOver)
        {
            if (isReady)
            {
                Debug.Log("isReady  " + isReady);

                gameOverPosition = transform.position;
                gameOverPosition.z = -1;
                transform.position = gameOverPosition;
            }

            isReady = false;

            if (trigger == 10)
            {
                GameManager.instance.StopGame();
                Camera.main.GetComponent<CameraFollow>().isGameOver = true;
            }
            trigger++;
        }
        else
        {
            gameOverPosition = transform.position;
            gameOverPosition.z = 0;
            transform.position = gameOverPosition;
        }
    }


    private bool CheckIsGrounded()
    {
        isGround = Physics.Raycast(landCheck.transform.position, -Vector3.up, distToGround);
        Debug.DrawRay(landCheck.transform.position, -Vector3.up, Color.red);
        
        return isGround;
    }


    void OnCollisionEnter(Collision col)
    {
        if (col.transform.parent.tag == "LandObject")
        {
            trigger = 1;
            isGameOver = false;
        }
    }
}
