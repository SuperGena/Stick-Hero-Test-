using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{    
    [SerializeField]
    private GameObject playerToFollow;
    [SerializeField]
    float lerpRate;


    internal Vector3 camPosition;
    internal Vector3 firstPosition;
    internal bool isGameOver;

    private bool isGameStart;


	void Start ()
    {
        firstPosition = transform.position + Vector3.right * 2f;
        camPosition = transform.position;
        camPosition.x = playerToFollow.transform.position.x + 2;
        isGameOver = false;
	}
	

	void Update ()
    {
        isGameStart = UiManager.instance.isStart;

        if (!isGameOver) 
        {
            if (isGameStart)
            {
                StartCoroutine(Begin(camPosition));
            }
        }
        else
        {
            camPosition = firstPosition;
        }
    }


    internal void BeginToFollow(Vector3 pos)
    {
        camPosition = Vector3.zero;
        camPosition = firstPosition;
        camPosition.x = pos.x + 2;
        transform.position = Vector3.MoveTowards(transform.position, camPosition, Time.deltaTime * 4);
    }


    internal void CameraToPlayer(Vector3 pos)
    {
        Vector3 target = pos;
        target.x = pos.x + 2;
        transform.position = target;
    }


    internal void Reset()
    {
        transform.position = firstPosition;
    }


    private IEnumerator Begin(Vector3 movePos)
    {
        transform.position = Vector3.MoveTowards(transform.position, movePos, Time.deltaTime * 4);

        yield return new WaitForSeconds(1f);
    }
}
