using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TickBox_Script : MonoBehaviour {

    public string setting;

	// Use this for initialization
	void Start ()
    {
        if (PlayerPrefs.HasKey(setting) == true)
            gameObject.GetComponent<Toggle>().isOn = IntToBool(PlayerPrefs.GetInt(setting));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool IntToBool(int zero_or_one)
    {
        if (zero_or_one == 0)
            return false;

        else return true;
    }

    public int BoolToInt(bool statement)
    {
        if (statement == false)
            return 0;
        else
            return 1;
    }
   
    public void UpdateSetting()
    {
        PlayerPrefs.SetInt(setting, BoolToInt(gameObject.GetComponent<Toggle>().isOn));
    }
}
