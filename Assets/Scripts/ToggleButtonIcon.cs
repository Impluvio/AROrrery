using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButtonIcon : MonoBehaviour
{

    public Button MuteButton;
    public Sprite muted;
    public Sprite unmuted;
    private Image buttonImage;

    // Start is called before the first frame update
    private void Awake()
    {
        buttonImage = MuteButton.GetComponent<Image>();
        buttonImage.sprite = muted;
    }

    public void switchIcon()
    {
        buttonImage.sprite = (buttonImage.sprite == muted) ? unmuted : muted;
       
    }



}
