using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_Script : MonoBehaviour {

    public GameObject MenuController;

    // Use this for initialization
    void Start()
    {
        if (MenuController == null)
        {
            MenuController = GameObject.Find("MenuController");
        }

        MenuController.GetComponent<MenuController>().canvasList.Add(gameObject.name);

    }

    // Update is called once per frame
    void Update () {
		
	}

    
}
