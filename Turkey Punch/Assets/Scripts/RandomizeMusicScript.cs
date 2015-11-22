using UnityEngine;
using System.Collections;

public class RandomizeMusicScript : MonoBehaviour {

    AudioSource aSource;

	// Use this for initialization
	void Start () {
        aSource = gameObject.GetComponent<AudioSource>();
        float temp = Random.value;
        if (temp < .5f)
            aSource.clip = AudioClip.Create("Assets/Resources/Music/SantaTheme.mp3", 10, 10, 10, false);
        else
            aSource.clip = AudioClip.Create("Assets/Resources/Music/TurkeyTheme.mp3", 10, 10, 10, false);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
