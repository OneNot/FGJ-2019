using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dropdown_Script : MonoBehaviour {

    public string setting;

	// Use this for initialization
	void Start () {
        selectCurrentOption();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void updateOption()
    {
        PlayerPrefs.SetString(setting, gameObject.GetComponent<Dropdown>().captionText.text);
        //print(PlayerPrefs.GetString(setting));
    }

    public void selectCurrentOption()
    {
        int counter = 0;

        foreach(Dropdown.OptionData o in gameObject.GetComponent<Dropdown>().options)
        {

            if (o.text == PlayerPrefs.GetString(setting))
            {
                gameObject.GetComponent<Dropdown>().value = counter;
            }

            counter++;
        }
    }

}
