using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChengeButton : MonoBehaviour {

    [SerializeField]
    private Button musicButton;
    [SerializeField]
    private Sprite musicButtonImageOn;
    [SerializeField]
    private Sprite musicButtonImageOff;

    void Update()
    {
        if (!MusicManager.instance.isPlay)
        {
            musicButton.GetComponent<Image>().sprite = musicButtonImageOff;
        }
        else
        {
            musicButton.GetComponent<Image>().sprite = musicButtonImageOn;
        }
    }

}
