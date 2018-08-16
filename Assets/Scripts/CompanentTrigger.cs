using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanentTrigger : MonoBehaviour
{
    [SerializeField]
    private Behaviour[] companentsToDisable;
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private GameObject land;
    [SerializeField]
    private GameObject extraScorePlatform;


    private bool IsTriggered;


    public PlatformSpawner platformSpawner;


    void Start ()
    {
        platformSpawner = GameObject.FindObjectOfType<PlatformSpawner>();
        Player = GameObject.Find("Player");
        DisableCompanents(false);
    }
	
	
	void Update ()
    {
        if (IsTriggered)
        {
            DisableCompanents(true);
        }
        else
        {
            DisableCompanents(false);
        }
	}


    void OnCollisionEnter(Collision col)
    {
        if(transform.parent.tag == "LandObject")
        {
            IsTriggered = true;

            platformSpawner.Spawn(transform.parent.position);

            if (!GameManager.instance.gameOver)
            {
                if((Player.transform.position.x - 0.2f > transform.parent.position.x - 0.9f) && (Player.transform.position.x - 0.2f < transform.parent.position.x + 1f))
                {
                    if ((Player.transform.position.x - 0.2f) > (extraScorePlatform.transform.position.x - 0.068f))
                    {
                        if ((Player.transform.position.x - 0.2f) < (extraScorePlatform.transform.position.x + 0.08f))
                        {
                            ScoreManager.instance.IncrementScore();
                        }
                    }

                    if (Player.transform.position.z < 1)
                    {
                        Vector3 pos = transform.parent.position;
                        pos.y = Player.transform.position.y;
                        Player.transform.position = pos;

                        if (Player.transform.position.x < 1)
                        {
                            Camera.main.GetComponent<CameraFollow>().Reset();
                        }
                        else
                        {
                            Camera.main.GetComponent<CameraFollow>().BeginToFollow(transform.parent.position);
                        }

                        ScoreManager.instance.IncrementScore();
                        UiManager.instance.ShowScore();
                    }
                }
                else
                {
                    GameManager.instance.gameOver = true;
                }
                
            }
            
        }
        else
        {
            IsTriggered = false;
        }
    }


    void OnCollisionExit(Collision col)
    {
        DisableCompanents(false);
        Destroy(land, 6f);        
    }


    void DisableCompanents(bool Disable_Anable)
    {
        for(int i = 0; i < companentsToDisable.Length; i++)
        {
            companentsToDisable[i].enabled = Disable_Anable;
        }
    }
}
