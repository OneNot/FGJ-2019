using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterAudio : MonoBehaviour {

	// Use this for initialization
	void Start () {

        if (PlayerPrefs.HasKey("MasterAudio") == true)
            AudioListener.volume = PlayerPrefs.GetFloat("MasterAudio");


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
