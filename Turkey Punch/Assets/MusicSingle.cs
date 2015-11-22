using UnityEngine;
using System.Collections;

public class MusicSingle : MonoBehaviour {

    GameObject instance;

    void Awake()
    {
     if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        } else {
            instance = gameObject;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
