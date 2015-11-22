using UnityEngine;
using System.Collections;

public class RandomizeBattleMusicScript : MonoBehaviour {

    AudioSource aSource;

	// Use this for initialization
	void Start ()
    {
        aSource = gameObject.GetComponent<AudioSource>();
        float temp = Random.value;
        if (temp < .25f)
            aSource.clip = Resources.Load("Music/Lately_Kind_of_Yeah_-_07_-_PMantium") as AudioClip;
        else if (temp < .5f)
            aSource.clip = Resources.Load("Music/FightemUp(speedyOcereal_320BPM)") as AudioClip;
        else if (temp < .75f)
            aSource.clip = Resources.Load("Music/RoccoW_-_Ideetje_Extended") as AudioClip;
        else
            aSource.clip = Resources.Load("Music/McTurkey(240BPM)") as AudioClip;
        aSource.Play();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
