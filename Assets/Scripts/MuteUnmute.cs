using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteUnmute : MonoBehaviour
{

    public Button MuteButton;
    public Sprite muted;
    public Sprite unmuted;
    private Image buttonImage;

    private bool isMuted = false;

    // Start is called before the first frame update
    private void Awake()
    {
        buttonImage = MuteButton.GetComponent<Image>();
        buttonImage.sprite = muted;
    }

    public void OnButtonPress()
    {
        buttonImage.sprite = (buttonImage.sprite == muted) ? unmuted : muted; //switches the icon of the button.

        if (isMuted == false)
        {
            isMuted = true;
            AudioListener.pause = true;
        }
        else
        {
            isMuted = false;
            AudioListener.pause = false;
        }

    }



}
