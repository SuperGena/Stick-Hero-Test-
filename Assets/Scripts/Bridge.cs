using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{

    [SerializeField]
    private GameObject bridgeObj;


    private int trigger;
    private bool isGameStart;


    void Start ()
    {
        trigger = 0;
	}


	void Update ()
    {

        if (isGameStart)        
            MakeABridge();
        isGameStart = UiManager.instance.isStart;

    }


    void MakeABridge()
    {
        if (Input.GetMouseButton(0))
        {
            if(trigger == 0)
            {
                bridgeObj.transform.localScale += new Vector3(0, 1f * 5f, 0);
                bridgeObj.transform.position += new Vector3(0, 0.005f * 5f, 0);
            }
            
        }
        if (Input.GetMouseButtonUp(0))
        {
            trigger++;
        }
    }
}
