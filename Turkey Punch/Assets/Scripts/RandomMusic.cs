using UnityEngine;
using System.Collections;

public class RandomMusic : MonoBehaviour {

    public AudioClip[] musicList;

    private AudioSource aud;

	// Use this for initialization
	void Start () {
        musicList = new AudioClip[4];
        aud = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!aud.isPlaying)
            PlayRandomMusic();
    }

    private void PlayRandomMusic()
    {
        Random.seed = (int)Time.time;
        int i = Random.Range(0, musicList.Length);
        aud.clip = musicList[i];
        aud.Play();
    }
}
