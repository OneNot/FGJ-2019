using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider_Script : MonoBehaviour {

    //If you use int, remember to tick Whole Numbers on slider
    public string settingInt;
    public string settingFloat;

	// Use this for initialization
	void Start () {

        if (settingInt == "" && PlayerPrefs.HasKey(settingFloat) == true && settingFloat!="")
            gameObject.GetComponent<Slider>().value = PlayerPrefs.GetFloat(settingFloat);

        if (settingFloat == "" && PlayerPrefs.HasKey(settingInt) == true && settingInt != "")
            gameObject.GetComponent<Slider>().value = PlayerPrefs.GetInt(settingInt);

        if (settingFloat == "" && settingInt == "" && PlayerPrefs.HasKey("MasterAudio") == true)
            gameObject.GetComponent<Slider>().value = PlayerPrefs.GetFloat("MasterAudio") * 100;

        //print(PlayerPrefs.GetFloat("MasterAudio"));

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void updateSetting()
    {
        if(settingFloat == "")
        PlayerPrefs.SetInt(settingInt, Mathf.RoundToInt(gameObject.GetComponent<Slider>().value));

        if (settingInt == "")
        PlayerPrefs.SetFloat(settingFloat,gameObject.GetComponent<Slider>().value);

        gameObject.GetComponentInChildren<Slider_Script_ValueText>().UpdateText();
    }

    public void updateSettingMasterAudio()
    {
        PlayerPrefs.SetFloat("MasterAudio", gameObject.GetComponent<Slider>().value / 100);
        AudioListener.volume = gameObject.GetComponent<Slider>().value / 100;

        gameObject.GetComponentInChildren<Slider_Script_ValueText>().UpdateText();
    }
}
