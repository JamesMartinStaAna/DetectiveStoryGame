using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Sprite MuteImage;
    public Sprite HasSoundImage;
    public Image VolumeImage;
    public Slider volumeSlider;
    AudioSource audioSource;

    private void Start() {
    audioSource = GetComponent<AudioSource>();    
    }

    public void PlaySound(AudioClip clip){
        audioSource.PlayOneShot(clip, 1f);
    }

    public void ChangeBGM(AudioClip bgm){
        audioSource.clip = bgm;
        audioSource.Play();
    }

    public void ChangeVolume(){
        if(volumeSlider.value <= 0){
            AudioListener.volume = volumeSlider.value;
            VolumeImage.sprite = MuteImage;
        }
        else{
            AudioListener.volume = volumeSlider.value;
            VolumeImage.sprite = HasSoundImage;
        }
    }
}
