using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	public void ChangeToScene(string scene) {
        //Application.LoadLevel (scene);

        if (scene == "FightingScene")
        {
            Destroy(GameObject.Find("Music"));
            Application.LoadLevel(scene);
            return;
        }
        else
        {
            foreach (Transform child in GameObject.Find(scene).transform)
            {
                Debug.Log(scene + " child " + child.name);
                child.gameObject.SetActive(true);
            }
            foreach (Transform child in transform.parent)
            {
                child.gameObject.SetActive(false);
            }
        }
        
	}

	public void ExitGame() {
		Application.Quit ();
	}

	void Update() {
		if (Input.GetKey("escape"))
			Application.Quit();
		
	}
}
