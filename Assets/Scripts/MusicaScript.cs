using UnityEngine;
using System.Collections;

public class MusicaScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (GameObject.Find("Audio Source") != null && GameObject.Find("Audio Source")!=gameObject)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
	}
}
