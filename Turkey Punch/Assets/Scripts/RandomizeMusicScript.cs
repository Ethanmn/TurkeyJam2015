using UnityEngine;
using System.Collections;

public class RandomizeMusicScript : MonoBehaviour {

    AudioSource aSource;

	// Use this for initialization
	void Start ()
    {
        aSource = gameObject.GetComponent<AudioSource>();
        float temp = Random.value;
        if (temp < .5f)
            aSource.clip = Resources.Load("Music/SantaTheme") as AudioClip;
        else
            aSource.clip = Resources.Load("Music/TurkeyTheme") as AudioClip;
        aSource.Play();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
