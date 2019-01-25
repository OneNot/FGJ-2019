using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider_Script_ValueText : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Text>().text = gameObject.GetComponentInParent<Slider>().value.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateText()
    {
        gameObject.GetComponent<Text>().text = gameObject.GetComponentInParent<Slider>().value.ToString();
    }
}
