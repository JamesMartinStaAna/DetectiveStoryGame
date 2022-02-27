using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetInteractCanvasUI : MonoBehaviour
{
    public Image InteractImage;
    public GameObject panel;
    
    public void SetImageUI(Sprite spriteImage)
    {
        InteractImage.sprite = spriteImage;
    }

    public void SetInteractUI(bool value)
    {
        InteractImage.gameObject.SetActive(value);
        panel.gameObject.SetActive(value);
    }
}
