using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject platform;


    internal Vector3 firstPos;


    private float size;

	
	void Start ()
    {
        firstPos = platform.transform.position;
        size = platform.transform.localScale.x;
	}


    internal void Spawn(Vector3 pos)
    {
        pos.x += size + 2;
        Instantiate(platform, pos, Quaternion.identity);
    }
}
