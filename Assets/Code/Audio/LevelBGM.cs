using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBGM : MonoBehaviour {

    private AudioSource bgmSource;

    public AudioClip herNameisCoco;
    public AudioClip bububu;

    public Text songText;   

	// Use this for initialization
	void Start () {
		songText.text = "Song: Time to Attack (Santa)";
        bgmSource = GetComponent<AudioSource>();

        if (bgmSource.isPlaying)
            bgmSource.Stop();

        bgmSource.clip = herNameisCoco;
        bgmSource.Play();
    }
	
	// Update is called once per frame
	void Update () {
		if (!bgmSource.isPlaying)
        {
            if (bgmSource.clip == herNameisCoco)
            {
                songText.text = "Song: Bububu ( REDALiCE)";
                bgmSource.clip = bububu;
                bgmSource.volume = 0.17f;
                bgmSource.Play();
            }
            else
            {
                songText.text = "Song: Time to Attack (Santa)";
                bgmSource.clip = herNameisCoco;
                bgmSource.volume = 0.2f;
                bgmSource.Play();
            }
        }
	}
}
