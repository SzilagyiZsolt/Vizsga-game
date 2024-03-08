using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Menumusic : MonoBehaviour
{
    private AudioMixer myMixer;
    private Slider musicSlider;
    private Text musicText = null;
    public AudioClip[] music;
    public new AudioSource audio;
    private float timer;
    private float newMusic;
    private int random;
    void Start()
    {
        audio = gameObject.AddComponent<AudioSource>();
        LoadValues();
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= newMusic)
        {
            newmusic();
            timer = 0;
        }
    }
    public void SetDefault()
    {
        musicSlider.value = (float)1.0;
    }
    public void VolumeText(float volume)
    {
        musicText.text=volume.ToString("0"+"%");
    }
    public void SaveVolumeButton()
    {
        float volumeValue=musicSlider.value;
        myMixer.SetFloat("Menumusic", Mathf.Log10(volumeValue)*20);
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        LoadValues();
    }
    public void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        musicSlider.value = volumeValue;
        AudioListener.volume=volumeValue;
    }
    public void newmusic()
    {
        random = Random.Range(0, music.Length);
        if (!audio.isPlaying)
        {
            audio.volume = (float)0.5;
            audio.PlayOneShot(music[random]);
        }
        newMusic = music[random].length;
    }
}
