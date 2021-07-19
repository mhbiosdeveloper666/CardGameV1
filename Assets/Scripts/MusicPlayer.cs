using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;

	void Awake(){
		if (instance != null) {
			Destroy (gameObject);
			print ("Duplicate Music Player!");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
		}

	}
	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
	
	}
}
