using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    private IEnumerator coroutine;


    void Start()
    {
        coroutine = Move();
    }


    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            StartCoroutine(coroutine);
        }
    }


    private IEnumerator Move()
    {
        //for(int i = 0; i < bridgeDistance; i++) 
        //transform.position = new Vector3(Mathf.Lerp(transform.position.x, bridgeDistance, 20), transform.position.y, transform.position.z);

        yield return new WaitForSeconds(1f);
    }
}
