using UnityEngine;
using System.Collections;

public class RandomizeMenuMusicScript : MonoBehaviour {

    AudioSource aSource;

	// Use this for initialization
	void Start ()
    {
        aSource = gameObject.GetComponent<AudioSource>();
        float temp = Random.value;
        print(temp);
        if (temp < .5f)
            aSource.clip = Resources.Load("Music/We Wish You") as AudioClip;
        else
            aSource.clip = Resources.Load("Music/J_Arthur_Keenes_-_04_-_The_Day_Before_Boxing_Day_Eve") as AudioClip;
        aSource.Play();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
