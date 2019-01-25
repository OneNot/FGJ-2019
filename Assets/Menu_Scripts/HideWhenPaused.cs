using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideWhenPaused : MonoBehaviour {
    public bool hideWhenPaused;
    public GameObject menuController;


    private float originalscaleX;
    private float originalscaleY;
    private float originalscaleZ;

    // Use this for initialization
    void Start () {
        UpdateScales();

        if (menuController == null)
        {
            menuController = GameObject.Find("MenuController");
        }

        menuController.GetComponent<MenuController>().hideableButtons.Add(gameObject.name);

        if (hideWhenPaused == false)
        {
            NullifyScales();
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Use if you update the scale during the game for some reason
    public void UpdateScales()
    {
        originalscaleX = transform.localScale.x;
        originalscaleY = transform.localScale.y;
        originalscaleZ = transform.localScale.z;
    }

    public void SetScales()
    {
        transform.localScale = new Vector3(originalscaleX, originalscaleY, originalscaleZ);
    }

    public void NullifyScales()
    {
        transform.localScale = new Vector3(0, 0, 0);
    }
}
