using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Som : MonoBehaviour
{
    private bool music = true;
    [SerializeField] private Sprite musicON;
    [SerializeField] private Sprite musicOFF;
    [SerializeField] private Image musicSprite;

    public void ChangeMusic()
    {
        if(music)
        {
            music = false;
            musicSprite.sprite = musicOFF;
            
        }
        else
        {
            music = true;
            musicSprite.sprite = musicON;
        }
    }

}
