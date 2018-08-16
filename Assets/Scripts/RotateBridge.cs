using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBridge : MonoBehaviour
{   
    [SerializeField]
    private float smooth = 5f;
    [SerializeField]
    private GameObject bridgeToRotate;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject land;


    private bool isGoodToGo;
    private bool isGameStart;
    private float playerWight;
    private IEnumerator coroutine;
    private float titleAngle = 90;


    public Transform target;


    void Start ()
    {
        coroutine = Spin();
        player = GameObject.Find("Player");
        playerWight = player.transform.localScale.x;
    }


    void Update()
    {
        

        if (isGameStart)
        {

            if (Input.GetMouseButtonUp(0))
            {
                StartCoroutine(coroutine);
                isGoodToGo = true;

            }
            if (isGoodToGo)
            {
                Move();
            }

        }
        isGameStart = UiManager.instance.isStart;

    }


    void Move()
    {
        player.transform.position = Vector3.MoveTowards(player.transform.position, target.position + Vector3.right * playerWight / 2, Time.deltaTime * target.transform.localScale.x * 2);
        if (player.transform.position.x >= target.position.x)
            Destroy(land);
    }


    private IEnumerator Spin()
    {
        Vector3 to = new Vector3(0, 180, titleAngle);

        bridgeToRotate.transform.eulerAngles = Vector3.Lerp(bridgeToRotate.transform.rotation.eulerAngles, to, Time.deltaTime * smooth);

        yield return new WaitForSeconds(.1f);
    }
}
